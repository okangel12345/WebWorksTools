using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiderman
{
    // base class for parsing game assets
    public class Asset<GenericSectionType>
    {
        public byte[] binary;
        public byte[] newbinary;

        public byte[] headerSM2;
        public bool isMSM2;

        public string assetfile;

        public PS4Header ps4header;
        public Header header;
        // should not be edited
        protected string description;
        public OrderedDictionary sectionheaders;
        public DataSegmentHeader[] segments;
        public SectionLayout sectionlayout;
        public OrderedDictionary sections;

        public Asset(string filename)
        {
            // read source
            binary = File.ReadAllBytes(filename);
            assetfile = filename;

            // Header trick for SM2 - TODO: find a better approach
            //--------------------------------------------------------------------------------------
            int offset = WebWorksCore.AssetUtilities.Find1TADMarker(binary);

            if (offset != -1 && binary.Length >= offset + 8)
            {
                byte[] expectedBytes = new byte[] { 0xB4, 0x0D, 0x18, 0x3B };
                isMSM2 = true;

                // Check MAGIC
                for (int i = 0; i < 4; i++)
                {
                    if (binary[offset + 4 + i] != expectedBytes[i])
                    {
                        isMSM2 = false;
                        break;
                    }
                }

                if (isMSM2)
                {
                    byte[] bytesToInsert = new byte[] { 0x00, 0x00, 0x00, 0x00 };
                    binary = InsertBytesAtOffset(binary, offset, bytesToInsert);

                    headerSM2 = new byte[0x20];
                    Array.Copy(binary, 0, headerSM2, 0, 0x20);
                }
            }
            //--------------------------------------------------------------------------------------

            Parse();
        }

        private byte[] InsertBytesAtOffset(byte[] original, int offset, byte[] bytesToInsert)
        {
            byte[] result = new byte[original.Length + bytesToInsert.Length];
            Buffer.BlockCopy(original, 0, result, 0, offset);
            Buffer.BlockCopy(bytesToInsert, 0, result, offset, bytesToInsert.Length);
            Buffer.BlockCopy(original, offset, result, offset + bytesToInsert.Length, original.Length - offset);

            return result;
        }

        public void Parse()
        {
            sectionheaders = new OrderedDictionary();
            sections = new OrderedDictionary();
            using (var ms = new MemoryStream(binary))
            using (var br = new BinaryReader(ms))
            {
                ps4header = new PS4Header(br.ReadBytes(PS4Header.length));
                var s = ms.Length - ms.Position;
                header = new Header(br.ReadBytes(Header.length));
                if (s < header.fileSize)
                    throw new Exception("Too little data");

                for (int i = 0; i < header.sectionCount; i++)
                {
                    var sh = new SectionHeader(br.ReadBytes(0xC));
                    sectionheaders[sh.type] = sh;
                }
                sectionlayout = new SectionLayout(sectionheaders.Cast<DictionaryEntry>().
                    OrderBy(s => ((SectionHeader)s.Value).offset).
                    ToDictionary(s => ((SectionHeader)s.Value).type, v => (SectionHeader)v.Value)
                );

                segments = new DataSegmentHeader[header.dataSegmentCount];
                for (int i = 0; i < header.dataSegmentCount; i++)
                {
                    // assuming there can be more than one
                    segments[i] = new DataSegmentHeader(br.ReadBytes(8));
                    segments[i].ParseExternalData(br, PS4Header.length, sectionlayout);
                    sectionlayout.Insert(i, $"data{i}", segments[i]);
                }

                description = ReadStringZ(br);
                if (segments.Length == 0)
                {
                    uint segsize = ((SectionHeader)sectionlayout[0]).offset + PS4Header.length - (uint)br.BaseStream.Position;
                    if (segsize > 0)
                    {
                        uint start = (uint)br.BaseStream.Position - PS4Header.length;
                        var headerless = new Headerless(br.ReadBytes((int)segsize));
                        headerless.offset = start;
                        headerless.size = segsize;
                        headerless.type = default(GenericSectionType);
                        if (UnpackStrings(headerless.data).Item1.Count > 0)
                            sectionlayout.Insert(0, "headerless0", headerless);
                    }
                }

                uint lastsectionend = 0;
                for (int i = 0; i < sectionlayout.Count; i++)
                {
                    // find headerless stretches of data
                    // these sections should be considered unmoveable unless references to them can be patched
                    var sh = (SectionHeader)sectionlayout[i];
                    if (i > 0 && sh.offset > lastsectionend)
                    {
                        br.BaseStream.Seek(lastsectionend + PS4Header.length, SeekOrigin.Begin);
                        var d = br.ReadBytes((int)(sh.offset - lastsectionend));
                        if (UnpackStrings(d).Item1.Count > 0)
                        {
                            var newsh = new Headerless(d);
                            newsh.offset = lastsectionend;
                            newsh.size = sh.offset - lastsectionend;
                            sectionlayout.Insert(i, $"headerless{i}", newsh);
                            lastsectionend = sh.offset;
                        }
                    }

                    lastsectionend = sh.offset + sh.size;
                    for (; lastsectionend % 16 != 0; lastsectionend++) ;
                }

                for (int i = 0; i < header.sectionCount; i++)
                {
                    var sh = sectionheaders.Values.OfType<SectionHeader>().Skip(i).First();
                    ms.Seek(sh.offset + PS4Header.length, SeekOrigin.Begin);
                    byte[] data = br.ReadBytes((int)sh.size);
                    if (sections.Contains(sh.type))
                        throw new Exception("Duplicate sections");
                    sections[sh.type] = MapTypeToSection(sh.type, data);
                }

                // processing that relies on other section data
                foreach (DictionaryEntry kv in sections)
                    ((Section)kv.Value).PostProcess(this);

                // processing that references other data by offset
                // sections should override ExternalDataParser()
                foreach (DictionaryEntry kv in sections)
                    ((Section)kv.Value).ParseExternalData(br, PS4Header.length, sectionlayout);
            }
        }

        public virtual Section MapTypeToSection(GenericSectionType type, byte[] data)
        {
            return new Section(data);
        }

        public byte[] ToBytes()
        {
            for (int i = 0; i < sectionlayout.Count; i++)
            {
                SectionHeader h = (SectionHeader)sectionlayout[i];
                Section section;

                var key = sectionlayout.Cast<DictionaryEntry>().ElementAt(i).Key;
                switch (key)
                {
                    case GenericSectionType:
                        section = (Section)sections[key];
                        break;
                    case string s:
                        section = (Section)h;
                        break;
                    default:
                        throw new Exception();
                }

                if (section.ToBytes())
                    sectionlayout.SetSize(key, (uint)section.newdata.Length, null);
            }

            if (sectionlayout.GetTotalSize() > UInt32.MaxValue)
                throw new Exception($"File size overflow beyond {UInt32.MaxValue} byte limit");
            uint size = (uint)sectionlayout.GetTotalSize();
            ps4header.facedataoffset = size;
            ps4header.remainingsize = 0;
            newbinary = new byte[size + PS4Header.length];
            binary.Take(Math.Min(binary.Length, newbinary.Length)).ToArray().CopyTo(newbinary, 0);

            using (var ms = new MemoryStream(newbinary))
            using (BinaryWriter w = new BinaryWriter(ms))
            {
                ps4header.ToBytes();
                w.Write(ps4header.newdata);

                header.fileSize = (uint)size;
                header.ToBytes();
                w.Write(header.newdata);

                foreach (DictionaryEntry kv in sectionheaders)
                {
                    SectionHeader h = (SectionHeader)kv.Value;
                    h.ToBytes();
                    w.Write(h.newdata);
                }

                for (int i = 0; i < segments.Length; i++)
                {
                    w.Write(segments[i].endoffset);
                    w.Write(segments[i].startoffset);
                }
                w.Write(Encoding.ASCII.GetBytes(description));
                w.Write((byte)0);

                for (int i = 0; i < sectionlayout.Count; i++)
                {
                    SectionHeader h = (SectionHeader)sectionlayout[i];
                    Section section;

                    var key = sectionlayout.Cast<DictionaryEntry>().ElementAt(i).Key;
                    switch (key)
                    {
                        case GenericSectionType:
                            section = (Section)sections[key];
                            break;
                        case string s:
                            section = (Section)h;
                            break;
                        default:
                            throw new Exception();
                    }

                    //if (section.newdata is not null)
                    //{
                    //    w.BaseStream.Seek(h.offset + PS4Header.length, SeekOrigin.Begin);
                    //    w.Write(section.newdata);
                    //    while (w.BaseStream.Position % 16 != 4)
                    //        w.Write((byte)0);
                    //    if (i + 1 < sectionlayout.Count)
                    //    {
                    //        uint padding = ((SectionHeader)sectionlayout[i + 1]).offset + PS4Header.length - (uint)w.BaseStream.Position;
                    //        w.Write(new byte[padding]);
                    //    }
                    //}

                    // Okangel: Do this to fix SM2 materials

                    if (section.newdata is not null)
                    {
                        w.BaseStream.Seek(h.offset + PS4Header.length, SeekOrigin.Begin);
                        w.Write(section.newdata);
                        while (w.BaseStream.Position % 16 != 4)
                            w.Write((byte)0);

                        if (i + 1 < sectionlayout.Count)
                        {
                            uint nextOffset = ((SectionHeader)sectionlayout[i + 1]).offset + PS4Header.length;
                            long position = w.BaseStream.Position;

                            if (nextOffset > position)
                            {
                                uint padding = (uint)(nextOffset - position);
                                w.Write(new byte[padding]);
                            }
                        }
                    }
                }
            }

            return newbinary;
        }
        public void Save(string? filename = null)
        {
            string f = filename ?? Path.ChangeExtension(assetfile, $"modified.{Path.GetExtension(assetfile)}");

            byte[] sizeBytes;
            if (isMSM2)
            {
                sizeBytes = new byte[4];

                Array.Copy(newbinary, 0x4, sizeBytes, 0, 4);

                string sizeBytesHex = BitConverter.ToString(sizeBytes).Replace("-", " ");

                Array.Copy(headerSM2, 0, newbinary, 0, 32);

                byte[] resizedBinary = new byte[newbinary.Length];

                Array.Copy(newbinary, 0, resizedBinary, 0, 0x20);
                Array.Copy(newbinary, 0x24, resizedBinary, 0x20, newbinary.Length - 0x24);

                Array.Copy(sizeBytes, 0, resizedBinary, 0x18, 3);
                Array.Copy(sizeBytes, 0, resizedBinary, 0x28, 4);

                newbinary = resizedBinary;
            }

            File.WriteAllBytes(f, newbinary);
        }

        public class Section
        {
            public byte[] data;
            public byte[] newdata;

            public Section(byte[] data)
            {
                this.data = data;
            }

            public virtual bool ToBytes()
            {
                if (newdata == null)
                {
                    newdata = new byte[data.Length];
                    Array.Copy(data, 0, newdata, 0, data.Length);
                }
                return newdata != data;
            }

            public void ParseExternalData(BinaryReader br, uint offsetbase, SectionLayout layout)
            {
                long savepos = br.BaseStream.Position;
                br.BaseStream.Seek(offsetbase, SeekOrigin.Begin);
                ExternalDataParser(br);
                layout.lastreference = br.BaseStream.Position;
                br.BaseStream.Seek(savepos, SeekOrigin.Begin);
            }

            public virtual void PostProcess(Asset<GenericSectionType> asset) { }
            public virtual void ExternalDataParser(BinaryReader br) { }
        }

        public class SectionHeader : Section
        {
            public GenericSectionType type;
            public uint offset;
            public uint size;

            public SectionHeader(byte[] data) : base(new byte[12])
            {
                this.data = data;
                type = (GenericSectionType)(object)BitConverter.ToUInt32(data, 0);
                offset = BitConverter.ToUInt32(data, 4);
                size = BitConverter.ToUInt32(data, 8);
            }

            public virtual bool ToBytes()
            {
                newdata = new byte[data.Length];
                BitConverter.GetBytes((uint)(object)type).CopyTo(newdata, 0);
                BitConverter.GetBytes(offset).CopyTo(newdata, 4);
                BitConverter.GetBytes(size).CopyTo(newdata, 8);
                return true;
            }
        }

        public SectionHeader CreateSectionHeader(GenericSectionType type)
        {
            // this is a dangerous function that will break all offsets into data segments
            SectionHeader sh = new SectionHeader(new byte[12]);
            sh.type = type;
            sectionheaders[type] = sh;
            header.sectionCount++;

            for (int i = 0; i < sectionlayout.Count; i++)
            {
                if (sectionlayout[i] is DataSegmentHeader)
                {
                    var dsh = (DataSegmentHeader)sectionlayout[i];
                    dsh.startoffset += 12;
                    dsh.offset += 12;
                    // wastes a little space on multiple calls
                    dsh.endoffset += 16;
                    dsh.size += 16;
                }
                else
                    ((SectionHeader)sectionlayout[i]).offset += 16;
            }

            sh.offset = (uint)sectionlayout.GetTotalSize();
            for (; sh.offset % 16 != 0; sh.offset++) ;

            sectionlayout[type] = sh;
            return sh;
        }

        public class SectionLayout : OrderedDictionary
        {
            protected long lastref;
            public long lastreference { get { return lastref; } set { lastref = Math.Max(value, lastref); } }

            public SectionLayout(Dictionary<GenericSectionType, SectionHeader> d)
            {
                foreach (var kv in d)
                    this[kv.Key] = kv.Value;

                lastref = 0;
            }

            public int GetKeyIndex(object t)
            {
                int idx = 0;
                foreach (DictionaryEntry kv in this)
                {
                    switch (t)
                    {
                        case GenericSectionType s when kv.Key is GenericSectionType:
                            if ((uint)kv.Key == (uint)t)
                                return idx;
                            break;
                        case string s when kv.Key is string:
                            if ((string)kv.Key == (string)t)
                                return idx;
                            break;
                    }
                    if (kv.Key == t)
                        return idx;
                    idx++;
                }
                return -1;
            }

            public SectionHeader? GetSectionByOffset(uint offset)
            {
                foreach (DictionaryEntry kv in this)
                {
                    var sh = (SectionHeader)kv.Value;
                    if (sh.offset <= offset && offset <= sh.offset + sh.size)
                        return sh;
                }

                return null;
            }

            public SectionHeader NewSection(uint size, int idx)
            {
                SectionHeader section = new SectionHeader(new byte[size]);
                this.Insert(idx, $"new{idx}", section);
                if (size > 0)
                    ExpandSection(idx, size);

                return section;
            }

            public bool IsResizable(Object t)
            {
                var sectionidx = GetKeyIndex(t);
                if (sectionidx < 0) throw new ArgumentException("Missing key");
                if (sectionidx == this.Count)
                    return true;
                for (int i = sectionidx + 1; i < this.Count; i++)
                    if (this[i] is Headerless && ((Headerless)this[i]).moveable == false)
                        return false;
                return true;
            }

            public void SetSize(Object t, uint newsize, int? moveidx, bool? move = null)
            {
                // moveidx:  where to put it if it must be moved
                var section = (SectionHeader)this[t] ?? throw new ArgumentException();
                var sectionidx = GetKeyIndex(t);
                if (newsize <= section.size)
                {
                    // resize in place
                    section.size = newsize;
                    return;
                }

                move ??= !IsResizable(t);
                if ((bool)move)
                {
                    // move after referenced data
                    this.RemoveAt(sectionidx);
                    var orphan = new Headerless(section.data);
                    orphan.offset = section.offset;
                    orphan.size = section.size;
                    this.Insert(sectionidx, $"moved{sectionidx}", orphan);

                    if (moveidx == null)
                    {
                        var last = (SectionHeader)this[this.Count - 1];
                        section.offset = last.offset + last.size;
                        section.size = 0;
                        this.Add(t, section);
                    }
                    else
                    {
                        var current = (SectionHeader)this[moveidx];
                        section.offset = current.offset;
                        section.size = 0;
                        this.Insert((int)moveidx, t, section);
                    }

                    section.size = newsize;
                }

                ExpandSection(sectionidx, newsize);
            }

            protected void ExpandSection(int startidx, uint newsize)
            {
                SectionHeader section = (SectionHeader)this[startidx];
                if (startidx == this.Count - 1)
                {
                    section.size = newsize;
                    return;
                }
                if (newsize <= section.size)
                {
                    section.size = newsize;
                    return;
                }
                // assume everything is byte aligned already and just keep it that way
                uint sizeincrease = newsize - section.size;
                for (; sizeincrease % 16 != 0; sizeincrease++) ;
                if (section is DataSegmentHeader)
                    ((DataSegmentHeader)section).endoffset += sizeincrease;

                for (int i = startidx + 1; i < this.Count; i++)
                    ((SectionHeader)this[i]).offset += sizeincrease;
            }

            public long GetTotalSize()
            {
                var s = ((SectionHeader)this[this.Keys.Count - 1]);
                var size = s.offset + s.size;
                for (; size % 16 != 0; size++) ;
                return size;
            }
        }

        public SectionType? GetSection<SectionType>()
        {

            for (int i = 0; i < sections.Keys.Count; i++)
            {
                if (sections[i] is SectionType)
                    return (SectionType?)sections[i];
            }
            return default;
        }

        public SectionHeader? GetSectionHeader(GenericSectionType t)
        {
            foreach (DictionaryEntry h in sectionheaders)
            {
                if (h.Key is GenericSectionType && ((uint)h.Key == (uint)(object)t))
                    return (SectionHeader)h.Value;
            }
            return null;
        }

        public static string ReadStringZ(BinaryReader br)
        {
            var s = new StringBuilder();
            for (byte c = br.ReadByte(); c > 0; c = br.ReadByte())
                s.Append((char)c);

            return s.ToString();
        }

        public static (List<string>, uint[]) UnpackStrings(byte[] data, uint[] offsets = null)
        {
            List<string> strings = new List<string>();

            if (offsets != null)
            {
                for (int i = 0; i < offsets.Length; i++)
                {
                    for (uint j = offsets[i]; j < data.Length; j++)
                    {
                        if (data[j] == 0)
                        {
                            strings.Add(Encoding.ASCII.GetString(data.Skip((int)offsets[i]).Take((int)(j - offsets[i])).ToArray()));
                            break;
                        }
                    }
                }
            }
            else
            {
                List<uint> off = new List<uint>();
                uint start = 0;
                for (uint i = 0; i < data.Length; i++)
                {
                    if (data[i] == 0)
                    {
                        if (i == 0)
                        {
                            // special case for empty starting string
                            strings.Add("");
                            off.Add(0);
                        }
                        else if (start != i)
                        {
                            strings.Add(Encoding.ASCII.GetString(data.Skip((int)start).Take((int)(i - start)).ToArray()));
                            off.Add(start);
                        }
                        start = i + 1;
                    }
                }
                offsets = off.ToArray();
            }
            return (strings, offsets);
        }

        public static (byte[], uint[]) PackStrings(List<string> strings)
        {
            uint[] offsets = new uint[strings.Count];
            var data = new byte[strings.Sum(s => s.Length + 1)];

            uint offset = 0;
            for (int i = 0; i < strings.Count; i++)
            {
                offsets[i] = offset;
                var s = Encoding.ASCII.GetBytes(strings[i]);
                s.CopyTo(data, offset);
                offset += (uint)s.Length;
                data[offset++] = 0;
            }

            return (data, offsets);
        }

        public class PS4Header : Section
        {
            public GenericSectionType type;
            // starts counting after the header
            public uint facedataoffset;
            public uint remainingsize;
            public byte[] padding;
            public const int length = 0x24;

            public PS4Header(byte[] data) : base(data)
            {
                this.data = data;
                type = (GenericSectionType)(object)BitConverter.ToUInt32(data, 0);
                facedataoffset = BitConverter.ToUInt32(data, 4);
                remainingsize = BitConverter.ToUInt32(data, 8);
                padding = data.Skip(0xC).ToArray();
            }

            public override bool ToBytes()
            {
                newdata = new byte[data.Length];
                BitConverter.GetBytes((uint)(object)type).CopyTo(newdata, 0);
                BitConverter.GetBytes(facedataoffset).CopyTo(newdata, 4);
                BitConverter.GetBytes(remainingsize).CopyTo(newdata, 8);
                padding.CopyTo(newdata, 12);
                return true;
            }
        }

        public class Header : Section
        {
            public uint magic;
            public GenericSectionType type;
            public uint fileSize;
            public ushort sectionCount;
            // occurs in material files
            public ushort dataSegmentCount;
            public const int length = 0x10;

            public Header(byte[] data) : base(data)
            {
                this.data = data;
                magic = BitConverter.ToUInt32(data, 0);
                type = (GenericSectionType)(object)BitConverter.ToUInt32(data, 4);
                fileSize = BitConverter.ToUInt32(data, 8);
                sectionCount = BitConverter.ToUInt16(data, 12);
                dataSegmentCount = BitConverter.ToUInt16(data, 14);
            }

            public override bool ToBytes()
            {
                newdata = new byte[data.Length];
                BitConverter.GetBytes(magic).CopyTo(newdata, 0);
                BitConverter.GetBytes((uint)(object)type).CopyTo(newdata, 4);
                BitConverter.GetBytes(fileSize).CopyTo(newdata, 8);
                BitConverter.GetBytes(sectionCount).CopyTo(newdata, 12);
                BitConverter.GetBytes(dataSegmentCount).CopyTo(newdata, 14);
                return true;
            }
        }

        public class DataSegmentHeader : SectionHeader
        {
            public uint endoffset;
            public uint startoffset;

            public DataSegmentHeader(byte[] data) : base(new byte[12])
            {
                endoffset = BitConverter.ToUInt32(data, 0);
                startoffset = BitConverter.ToUInt32(data, 4);
                offset = startoffset;
                size = endoffset - startoffset;
            }

            public override void ExternalDataParser(BinaryReader br)
            {
                br.BaseStream.Seek(startoffset, SeekOrigin.Current);
                data = br.ReadBytes((int)size);
            }

            public override bool ToBytes()
            {
                newdata = newdata ?? data;
                return newdata != data;
                return true;
            }
        }

        public class Headerless : SectionHeader
        {
            public bool moveable;
            public Headerless(byte[] data) : base(new byte[12])
            {
                this.data = data;
                moveable = false;
            }
        }
    }
}