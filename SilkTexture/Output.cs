namespace SpideyTextureScaler
{
    public class Output : TextureBase
    {
        public Output()
        {
            Name = "Output";
        }

        public override bool Read(out string output, out int errorrow, out int errorcol)
        {
            // nothing to do
            output = "";
            errorrow = 0;
            errorcol = -1;
            Ready = true;
            return true;
        }

        internal void Generate(Source tex, List<DDS> ddss, bool testmode, bool? ignoreformat, uint extrasd, out string output, out int errorrow, out int errorcol)
        {
            output = "";
            errorrow = 0;
            errorcol = -1;

            // pre-flights
            var dds = ddss[0];
            if (dds.Width < tex.Width || dds.Height < tex.Height)
            {
                output += "Replacement image is smaller than source.\r\n";
                errorrow = 1;
                errorcol = 1;
                return;
            }

            if (tex.BytesPerPixel != dds.BytesPerPixel)
            {
                output += "Bytes per pixel is different between files, formats are incompatible.\r\n";
                errorrow = 1;
                errorcol = 7;
                return;
            }

            if (tex.aspect != dds.aspect)
            {
                output += "Aspect ratio is different between files.\r\n";
                errorrow = 1;
                errorcol = 2;
                return;
            }

            if (tex.Format != dds.Format)
            {
                switch (ignoreformat)
                {
                    case null:
                        // GUI only
                        if (MessageBox.Show("Files have different DXGI formats.\r\n\r\nAre you sure you want to continue?",
                            "DXGI format mismatch", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                        {
                            output += "Canceled due to DDS format mismatch.\r\n";
                            errorrow = 1;
                            errorcol = 10;
                            return;
                        }
                        break;

                    case true:
                        // command line or GUI
                        break;

                    case false:
                        // command line only
                        errorcol = 99;
                        output += $"DDS format mismatch: {tex.Format} != {dds.Format}";
                        return;
                }
            }

            if (ddss.Count > 1)
            {
                string[] props = new string[] {
                    nameof(Width),
                    nameof(Height),
                    nameof(Format)
                };
                for (int i = 1; i < ddss.Count; i++)
                {
                    for (int j = 0; j < props.Length; j++)
                    {
                        var a = dds.GetType().GetProperty(props[j]).GetValue(dds) as uint?;
                        var b = dds.GetType().GetProperty(props[j]).GetValue(ddss[i]) as uint?;
                        if (a != b)
                        {
                            output += $"Array image A{i} {props[j]} {b} doesn't match A0 {a}\r\n";
                            errorrow = 1;
                            errorcol = 1;
                            return;
                        }
                    }
                }
            }

            Width = dds.Width;
            Height = dds.Height;
            sd_width = tex.sd_width;
            sd_height = tex.sd_height;
            Images = tex.Images;
            Size = tex.Size;
            Mipmaps = tex.Mipmaps;
            uint extrasdmipsize = 0;

            uint extrasdmipmaps = (uint)(Math.Log((uint)dds.Width / tex.sd_width) / Math.Log(2));
            uint sizeincrease = 0;

            // HD mips
            if (tex.HDSize > 0 && extrasd > HDMipmaps)
                throw new ArgumentOutOfRangeException("Unchecked extrasd value");
            for (int i = (int)extrasdmipmaps; i > extrasd; i--)
                sizeincrease += (uint)(tex.basemipsize << (2 * i));

            if (tex.HDSize > 0)
            {
                HDMipmaps = extrasdmipmaps - extrasd;
                extrasdmipmaps = extrasd;
                HDSize = sizeincrease * Images;
                sizeincrease = 0;
            }
            else
            {
                HDSize = 0;
                HDMipmaps = 0;
            }

            // extra SD
            for (int i = (int)extrasdmipmaps; i > 0; i--)
                sizeincrease += (uint)(tex.basemipsize << (2 * i));

            extrasdmipsize = sizeincrease * (uint)Images;
            sd_width <<= (int)extrasdmipmaps;
            sd_height <<= (int)extrasdmipmaps;

            for (int i = 0; i < ddss.Count; i++)
            {
                if (ddss[i].Mipmaps < HDMipmaps + extrasdmipmaps + tex.Mipmaps)
                {
                    output += $"Not enough mipmaps in DDS file {(tex.Images > 1 ? "A{i} " : " ")}to replace this texture (needs {HDMipmaps + extrasdmipmaps + tex.Mipmaps})\r\n";
                    errorrow = 1;
                    errorcol = 4;
                    return;
                }
            }

            List<byte[]> hdmips = new(), extrasdmips = new(), sdmips = new();
            for (int i = 0; i < ddss.Count; i++)
            {
                string fn;
                if (ddss.Count == 1)
                    fn = dds.Filename;
                else
                    fn = dds.Filename.Substring(0, dds.Filename.Length - ".a0.dds".Length);

                using (var fs = File.Open(ddss[i].Filename, FileMode.Open, FileAccess.Read))
                using (var br = new BinaryReader(fs))
                {
                    fs.Seek(ddss[i].dataoffset, SeekOrigin.Begin);
                    hdmips.Add(br.ReadBytes((int)(HDSize / Images)));
                    extrasdmips.Add(br.ReadBytes((int)(extrasdmipsize / Images)));
                    sdmips.Add(br.ReadBytes((int)(tex.Size / Images)));
                }
            }

            if (tex.HDSize > 0)
            {
                string hdtexturefile = Path.ChangeExtension(Filename, "hd.texture");
                using (var fs = File.Open(hdtexturefile, FileMode.Create))
                using (var bw = new BinaryWriter(fs))
                {
                    if (HDMipmaps > 0)
                        for (int i = 0; i < ddss.Count; i++)
                            bw.Write(hdmips[i]);
                    output += $"Wrote {hdtexturefile} ({fs.Position} bytes, max {Width}x{Height})\r\n";
                }
            }

            Mipmaps += extrasdmipmaps;
            Size += extrasdmipsize;
            if (extrasdmipsize > 0)
            {
                BitConverter.GetBytes((uint)Size).CopyTo(tex.header, 0x8);
                BitConverter.GetBytes((uint)Size).CopyTo(tex.header, 0x14);
            }

            using (var fs = File.Open(Filename, FileMode.Create))
            using (var bw = new BinaryWriter(fs))
            {
                bw.Write(tex.header);
                bw.Write((uint)Size);
                bw.Write((uint)(HDSize));
                bw.Write((ushort)dds.Width);
                bw.Write((ushort)dds.Height);
                bw.Write((ushort)sd_width);
                bw.Write((ushort)sd_height);

                if (Source.isSM2Texture)
                {
                    bw.Write(tex.textureheader.Skip(16).Take(10).ToArray());
                    bw.Write((byte)Mipmaps);
                    bw.Write((byte)HDMipmaps);
                    bw.Write(tex.textureheader.Skip(28).ToArray());

                }
                else
                {
                    bw.Write(tex.textureheader.Skip(16).Take(14).ToArray());
                    bw.Write((byte)Mipmaps);
                    bw.Write(tex.textureheader[24]);
                    bw.Write((byte)HDMipmaps);
                    bw.Write(tex.textureheader.Skip(33).ToArray());

                }

                for (int i = 0; i < ddss.Count; i++)
                {
                    bw.Write(extrasdmips[i]);
                    if (testmode)
                        // keep original sd mipmaps
                        bw.Write(tex.mipmaps[i]);
                    else
                        bw.Write(sdmips[i]);
                }

                output += $"Wrote {Filename} ({fs.Position} bytes, max {sd_width}x{sd_height})\r\n";
            }

            output += $"Finished ({DateTime.Now})\n";
            return;

        }
    }
}
