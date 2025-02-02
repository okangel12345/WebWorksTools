using System.Collections;
using System.Collections.Specialized;

namespace Spiderman
{
    public class Material : Asset<Material.SectionType>
    {
        public Material(string filename) : base(filename)
        {
            var a = new HashSet<SectionType>()
                {
                    SectionType.SM_MATERIALFILE,
                    SectionType.SM_MATERIALTEMPLATE,
                    SectionType.MM_MATERIALFILE,
                    SectionType.MM_MATERIALTEMPLATE,
                    SectionType.PS4MM_MATERIALFILE,
                    SectionType.PS4MM_MATERIALTEMPLATE,
                    SectionType.RC_MATERIALFILE,
                    SectionType.RC_MATERIALTEMPLATE,
                };

            // Okangel: new SM2 materials' headers vary a lot, disabling this is a workaround for the file to load.

            // Other solution is changing *where* the MaterialFile is read from, so instead of the beginning of the
            // file, do it at 0x28.

            // I ain't doing it though lol

            //if (!a.Contains(ps4header.type))
            //throw new Exception("Not a material or material template file");
        }

        public enum SectionType : uint
        {
            SHADERTEXTURE = 0x1CAFE804,
            MATUNK1 = 0x3E45AA13,
            SHADERFLOATS = 0x45C4F4C0,
            MATUNK3 = 0x8C049CCA,
            SHADERFLOATVALUES = 0xA59F667B,
            COMPILEDSHADERS = 0xBBFC8900,
            SHADERINTEGERS = 0xBC93FB5E,
            MATUNK7 = 0xE1275683,
            SHADEROVERRIDES = 0xF5260180,
            MATUNK9 = 0xF9C35F30,
            MATUNK10 = 0xFD113362,

            // filetypes
            SM_MATERIALFILE = 0x1C04EF8C,
            MM_MATERIALFILE = 0x18757E9C,
            SM_MATERIALTEMPLATE = 0x7DC03E3,
            MM_MATERIALTEMPLATE = 0xFF60342A,

            PS4MM_MATERIALFILE = 0x1FC2627,
            PS4MM_MATERIALTEMPLATE = 0x6100677A,

            // Ratchet & Clank: Rift Apart
            RC_MATERIALFILE = 0x7C7BD7D6,
            RC_MATERIALTEMPLATE = 0xB742D85D,
        }

        public override Section MapTypeToSection(SectionType sectiontype, byte[] data)
        {
            switch (sectiontype)
            {
                case SectionType.SHADERTEXTURE:
                    return new ShaderTextures(data);
                case SectionType.SHADEROVERRIDES:
                    return new ShaderOverrides(data);
                case SectionType.SHADERFLOATS:
                    return new ShaderFloats(data);
                case SectionType.SHADERFLOATVALUES:
                    return new ShaderFloatValues(data);
                case SectionType.SHADERINTEGERS:
                    return new ShaderIntegers(data);
                case SectionType.COMPILEDSHADERS:
                    return new CompiledShaders(data);
                default:
                    return new Section(data);
            }
        }

        public class ShaderTextures : Section
        {
            public OrderedDictionary entries;
            public SectionHeader dataseg;

            public ShaderTextures(byte[] data) : base(data)
            {
                entries = new OrderedDictionary();

                for (int i = 0; i < data.Length / 16; i++)
                {
                    var t = new ShaderTextureEntry(data.Skip(i * 16).Take(16).ToArray());
                    entries[t.InputID] = t;
                }
            }

            public override void ExternalDataParser(BinaryReader br)
            {
                foreach (DictionaryEntry kv in entries)
                {
                    var entry = (ShaderTextureEntry)kv.Value;
                    br.BaseStream.Seek(entry.nameoffset + DAT1OffsetUint, SeekOrigin.Begin);
                    entry.name = ReadStringZ(br);
                }
            }

            public override bool ToBytes()
            {
                newdata = new byte[entries.Values.Count * 16];
                for (int i = 0; i < entries.Values.Count; i++)
                {
                    ((ShaderTextureEntry)entries[i]).ToBytes().CopyTo(newdata, i * 16);
                }
                return true;
            }

            public class ShaderTextureEntry
            {
                public uint nameoffset;
                public ushort u1;
                public ushort u2;
                public uint InputID;
                public uint u4;
                public string name;

                public ShaderTextureEntry(byte[] data)
                {
                    nameoffset = BitConverter.ToUInt32(data, 0);
                    u1 = BitConverter.ToUInt16(data, 4);
                    u2 = BitConverter.ToUInt16(data, 6);
                    InputID = BitConverter.ToUInt32(data, 8);
                    u4 = BitConverter.ToUInt32(data, 12);
                }

                public byte[] ToBytes()
                {
                    byte[] data = new byte[16];
                    BitConverter.GetBytes(nameoffset).CopyTo(data, 0);
                    BitConverter.GetBytes(u1).CopyTo(data, 4);
                    BitConverter.GetBytes(u2).CopyTo(data, 6);
                    BitConverter.GetBytes(InputID).CopyTo(data, 8);
                    BitConverter.GetBytes(u4).CopyTo(data, 12);
                    return data;
                }
            }
        }

        public class ShaderOverrides : Section
        {
            public uint size;
            public uint floatcount;
            public uint floatoffset;
            public uint intcount;
            public uint intoffset;
            public uint texcount;
            public uint texoffset;
            public uint texdataoffset;
            public OrderedDictionary Floats;
            public OrderedDictionary Ints;
            public OrderedDictionary Textures;

            public ShaderOverrides(byte[] data) : base(data)
            {
                string hexData = BitConverter.ToString(data).Replace("-", " ");

                // Show in MessageBox
                MessageBox.Show(hexData, "Data (Hex)", MessageBoxButtons.OK, MessageBoxIcon.Information);

                size = BitConverter.ToUInt32(data, 0);
                floatcount = BitConverter.ToUInt32(data, 0x4);
                floatoffset = BitConverter.ToUInt32(data, 0x8);
                intcount = BitConverter.ToUInt32(data, 0xC);
                intoffset = BitConverter.ToUInt32(data, 0x10);
                texcount = BitConverter.ToUInt32(data, 0x14);
                texoffset = BitConverter.ToUInt32(data, 0x18);
                texdataoffset = BitConverter.ToUInt32(data, 0x1C);

                if (texoffset + 8 * texcount != texdataoffset)
                    throw new Exception("Overrides assertion failed");

                Floats = new OrderedDictionary();
                int floatdatasize = 0;
                for (int i = 0; i < floatcount; i++)
                {
                    var offset = BitConverter.ToUInt16(data, 0x28 + (i * 8));
                    var floatsize = BitConverter.ToUInt16(data, 0x28 + (i * 8) + 2);
                    floatdatasize += floatsize;
                    var id = BitConverter.ToUInt32(data, 0x28 + (i * 8) + 4);

                    if (floatsize % 4 == 0)
                    {
                        var datasize = 4;
                        var fs = new float[floatsize / datasize];
                        Floats[id] = fs;
                        for (int j = 0; j < floatsize / datasize; j++)
                            fs[j] = BitConverter.ToSingle(data, (int)(floatoffset + offset + j * datasize));
                    }
                    else if (floatsize % 2 == 0)
                    {
                        // not sure this is possible
                        var datasize = 2;
                        var fs = new ushort[floatsize / datasize];
                        Floats[id] = fs;
                        for (int j = 0; j < floatsize / datasize; j++)
                            fs[j] = BitConverter.ToUInt16(data, (int)(floatoffset + offset + j * datasize));
                    }
                    else
                    {
                        // or this
                        var fs = new byte[floatsize];
                        Floats[id] = fs;
                        for (int j = 0; j < floatsize; j++)
                            fs[j] = data[floatoffset + offset + j];
                    }
                }

                Ints = new OrderedDictionary();
                for (int i = 0; i < intcount; i++)
                {
                    var val = BitConverter.ToUInt32(data, (int)intoffset + (i * 8));
                    var id = BitConverter.ToUInt32(data, (int)intoffset + (i * 8) + 4);
                    Ints[id] = val;
                }

                Textures = new OrderedDictionary();

                var ids = new uint[texcount];
                var offsets = new uint[texcount];
                for (int i = 0; i < texcount; i++)
                {
                    offsets[i] = BitConverter.ToUInt32(data, (int)texoffset + (i * 8));
                    ids[i] = BitConverter.ToUInt32(data, (int)texoffset + (i * 8) + 4);
                }
                var outstrings = UnpackStrings(data.Skip((int)texdataoffset).ToArray(), offsets).Item1;

                for (int i = 0; i < texcount; i++)
                {
                    Textures[ids[i]] = outstrings[i];
                }
            }

            public override bool ToBytes()
            {
                (byte[] newtexdata, uint[] newstroffset) = PackStrings(Textures.Cast<DictionaryEntry>().Select(s => (string)s.Value).ToList());
                texcount = (uint)Textures.Count;
                byte[] newtexoffsetdata = new byte[Textures.Count * 8];
                for (int i = 0; i < texcount; i++)
                {
                    BitConverter.GetBytes(newstroffset[i]).CopyTo(newtexoffsetdata, i * 8);
                    BitConverter.GetBytes((uint)Textures.Cast<DictionaryEntry>().ElementAt(i).Key).CopyTo(newtexoffsetdata, i * 8 + 4);
                }

                byte[] newintdata = new byte[Ints.Count * 8];
                for (int i = 0; i < Ints.Count; i++)
                {
                    BitConverter.GetBytes((uint)Ints[i]).CopyTo(newintdata, i * 8);
                    BitConverter.GetBytes((uint)Ints.Cast<DictionaryEntry>().ElementAt(i).Key).CopyTo(newintdata, i * 8 + 4);
                }
                intcount = (uint)Ints.Count;

                byte[] newfloatoffsetdata = new byte[Floats.Count * 8];
                var newfloatdataarray = Floats.Cast<DictionaryEntry>().Select(kv =>
                {
                    switch (kv.Value)
                    {
                        case float[]:
                            return ((float[])kv.Value).ToList().Select(f => BitConverter.GetBytes(f).ToList()).SelectMany(f => f);
                            break;
                        case ushort[]:
                            return ((ushort[])kv.Value).ToList().Select(u => BitConverter.GetBytes(u).ToList()).SelectMany(u => u);
                            break;
                        case byte[]:
                            return (byte[])kv.Value;
                        default:
                            throw new Exception("Float value must be float[], ushort[], or byte[]");
                    }
                }).ToArray();

                byte[] newfloatdata = newfloatdataarray.SelectMany(f => f).ToArray();
                ushort soff = 0;
                for (int i = 0; i < Floats.Count; i++)
                {
                    BitConverter.GetBytes(soff).CopyTo(newfloatoffsetdata, i * 8);
                    BitConverter.GetBytes((ushort)newfloatdataarray[i].Count()).CopyTo(newfloatoffsetdata, i * 8 + 2);
                    soff += (ushort)newfloatdataarray[i].Count();
                    BitConverter.GetBytes((uint)Floats.Cast<DictionaryEntry>().ElementAt(i).Key).CopyTo(newfloatoffsetdata, i * 8 + 4);
                }
                floatcount = (uint)Floats.Count;

                uint newsize = (uint)(0x28 + newfloatoffsetdata.Length + newfloatdata.Length + newintdata.Length + newtexoffsetdata.Length + newtexdata.Length);
                for (; newsize % 16 != 0; newsize++) ;
                newdata = new byte[newsize];
                data.Take(0x28).ToArray().CopyTo(newdata, 0);
                BitConverter.GetBytes(newsize).CopyTo(newdata, 0);

                uint off = 0x28;
                newfloatoffsetdata.CopyTo(newdata, off);
                off += (uint)newfloatoffsetdata.Length;

                BitConverter.GetBytes(floatcount).CopyTo(newdata, 4);
                newfloatdata.CopyTo(newdata, off);
                BitConverter.GetBytes(off).CopyTo(newdata, 0x8);
                off += (uint)newfloatdata.Length;

                BitConverter.GetBytes(intcount).CopyTo(newdata, 0xC);
                newintdata.CopyTo(newdata, off);
                BitConverter.GetBytes(off).CopyTo(newdata, 0x10);
                off += (uint)newintdata.Length;

                BitConverter.GetBytes(texcount).CopyTo(newdata, 0x14);
                newtexoffsetdata.CopyTo(newdata, off);
                BitConverter.GetBytes(off).CopyTo(newdata, 0x18);
                off += (uint)newtexoffsetdata.Length;

                newtexdata.CopyTo(newdata, off);
                BitConverter.GetBytes(off).CopyTo(newdata, 0x1C);

                return true;
            }
        }

        public class ShaderFloats : Section
        {
            public ShaderFloatDefinition[] definitions;
            public OrderedDictionary values;

            public ShaderFloats(byte[] data) : base(data)
            {
                definitions = new ShaderFloatDefinition[data.Length / 8];
                for (int i = 0; i < data.Length / 8; i++)
                    definitions[i] = new ShaderFloatDefinition(data.Skip(i * 8).Take(8).ToArray());
            }

            public override bool ToBytes()
            {
                newdata = new byte[definitions.Length * 8];
                for (var i = 0; i < definitions.Length; i++)
                    definitions[i].ToBytes().CopyTo(newdata, i * 8);

                return true;
            }

            public override void PostProcess(Asset<SectionType> asset)
            {
                byte[] valuedata = asset.GetSection<ShaderFloatValues>()?.data ?? throw new Exception("Missing ShaderFloatValues");
                values = new OrderedDictionary();

                for (int i = 0; i < definitions.Length; i++)
                {
                    if (definitions[i].size % 4 == 0)
                    {
                        var fs = new float[definitions[i].size / 4];
                        values[definitions[i].ID] = fs;
                        for (int j = 0; j < fs.Length; j++)
                            fs[j] = BitConverter.ToSingle(valuedata, definitions[i].offset + j * 4);
                    }
                    else if (definitions[i].size % 2 == 0)
                    {
                        var us = new ushort[definitions[i].size / 2];
                        values[definitions[i].ID] = us;
                        for (int j = 0; j < us.Length; j++)
                            us[j] = BitConverter.ToUInt16(valuedata, definitions[i].offset + j * 2);
                    }
                    else
                        values[definitions[i].ID] = valuedata.Skip(definitions[i].offset).Take(definitions[i].size).ToArray();
                }
            }

            public void WriteValues(byte[] valuedata)
            {
                for (int i = 0; i < definitions.Length; i++)
                {
                    switch (values[i])
                    {
                        case float[]:
                            var f = (float[])values[i];
                            for (int j = 0; j < f.Length; j++)
                                BitConverter.GetBytes(f[j]).CopyTo(valuedata, definitions[i].offset + j * 4);
                            break;

                        case ushort[]:
                            var u = (ushort[])values[i];
                            for (int j = 0; j < u.Length; j++)
                                BitConverter.GetBytes(u[j]).CopyTo(valuedata, definitions[i].offset + j * 4);
                            break;

                        case byte[]:
                            var b = (byte[])values[i];
                            b.CopyTo(valuedata, definitions[i].offset);
                            break;

                    }
                }
            }

            public class ShaderFloatDefinition
            {
                public ushort offset;
                public ushort size;
                public uint ID;

                public ShaderFloatDefinition(byte[] data)
                {
                    offset = BitConverter.ToUInt16(data, 0);
                    size = BitConverter.ToUInt16(data, 2);
                    ID = BitConverter.ToUInt32(data, 4);
                }

                public byte[] ToBytes()
                {
                    byte[] newdata = new byte[8];
                    BitConverter.GetBytes(offset).CopyTo(newdata, 0);
                    BitConverter.GetBytes(size).CopyTo(newdata, 2);
                    BitConverter.GetBytes(ID).CopyTo(newdata, 4);
                    return newdata;
                }
            }
        }

        public class ShaderFloatValues : Section
        {
            public ShaderFloatValues(byte[] data) : base(data)
            {
                newdata = new byte[data.Length];
            }

            public override bool ToBytes()
            {
                return true;
            }
        }

        public class ShaderIntegers : Section
        {
            public OrderedDictionary integers;
            public ShaderIntegers(byte[] data) : base(data)
            {
                integers = new OrderedDictionary();
                for (int i = 0; i < data.Length / 8; i++)
                {
                    uint val = BitConverter.ToUInt32(data, i * 8);
                    uint ID = BitConverter.ToUInt32(data, i * 8 + 4);

                    if (ID > 0)
                        integers[ID] = val;
                    else
                        break;
                }
            }

            public override bool ToBytes()
            {
                newdata = new byte[data.Length];
                data.CopyTo(newdata, 0);
                for (int i = 0; i < integers.Count; i++)
                {
                    if (integers.Keys.Cast<uint>().ElementAt(i) != BitConverter.ToUInt32(data, i * 8 + 4))
                        throw new Exception("Cannot change integer IDs");
                    BitConverter.GetBytes((uint)integers[i]).CopyTo(newdata, i * 8);
                }

                return true;
            }
        }

        public class CompiledShaders : Section
        {
            public List<byte[]> vertex;
            public List<byte[]> fragment;

            public CompiledShaders(byte[] data) : base(data)
            {
                vertex = new List<byte[]>();
                fragment = new List<byte[]>();

                for (int i = 0; i < data.Length;)
                {
                    for (; i % 0x40 != 0; i++) ;
                    // IGSH signature
                    if (i + 4 + 4 > data.Length)
                        break;
                    if ((BitConverter.ToUInt32(data, i) != 0x48534749))
                    {
                        i++;
                        continue;
                    }
                    i += 4;
                    int vsize = BitConverter.ToInt32(data, i);
                    i += 4;
                    int fsize = BitConverter.ToInt32(data, i);
                    i += 4;

                    if (i + vsize + fsize > data.Length)
                        break;
                    vertex.Add(data.Skip(i).Take(vsize).ToArray());
                    i += vsize;
                    fragment.Add(data.Skip(i).Take(fsize).ToArray());
                    i += fsize;
                    for (; i % 0x10 != 0; i++) ;
                }
            }
        }
    }
}
