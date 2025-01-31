namespace SpideyTextureScaler
{
    public class Source : TextureBase
    {
        public byte[] header;
        public byte[] textureheader;
        public List<byte[]> mipmaps;
        public string hdfilename;
        public bool exportable;
        public List<uint> resourceids;

        public Source()
        {
            Name = "Source";

            resourceids = new List<uint>()
            {
                // Texture resource IDs for:

                // Marvel's Spider-Man Remastered
                // Marvel's Spider-Man: Miles Morales
                0x5C4580B9,
                // Ratchet & Clank: Rift Apart
                0x8F53A199,
                // Marvel's Spider-Man 2
                // Varied textures
            };
        }

        // Global SM2 texture enable
        public static bool isSM2Texture = false;

        public override bool Read(out string output, out int errorrow, out int errorcol)
        {
            output = "";
            errorrow = 0;
            errorcol = -1;
            exportable = false;

            // Check if the string "Texture Built" is present for full compatibility
            try
            {
                string fileContent = File.ReadAllText(Filename);

                if (!fileContent.Contains("Texture Built"))
                {
                    output += "Not a texture asset.  Please import the lowest resolution copy.\r\n";
                    errorcol = 1;
                    return false;
                }
            }
            catch (Exception ex)
            {
                output += $"Error reading file: {ex.Message}\r\n";
                errorcol = 1;
                return false;
            }

            using (var fs = File.Open(Filename, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                // Check for "Text"- ure
                fs.Seek(64, SeekOrigin.Begin);
                var Text = br.ReadUInt32();
                if (Text != 1954047316)
                {
                    MessageBox.Show("Not a texture file.");
                    return false;
                }
                fs.Seek(0, SeekOrigin.Begin);

                if (!resourceids.Contains(br.ReadUInt32()) ||
                    fs.Seek(32, SeekOrigin.Current) < 1 ||
                    br.ReadUInt32() != 1145132081 ||
                    !resourceids.Contains(br.ReadUInt32()))
                {
                    // Position again for SM2 textures
                    br.ReadUInt32();
                    fs.Seek(32, SeekOrigin.Current);
                    br.ReadUInt32();
                    output += "Marvel's Spider-Man 2 texture.\r\n";
                    isSM2Texture = true;
                }
                else
                {
                    output += "Marvel's Spider-Man texture.\r\n";
                    isSM2Texture = false;
                };

                br.ReadUInt32();

                // Don't take any sections errors into account when it's SM2 due to the variable header

                if (br.ReadUInt32() != 1)
                {
                    if (!isSM2Texture)
                    {
                        output += $"Multiple sections not implemented.  Woops\r\n";
                        errorcol = 1;
                        return false;
                    }
                }

                if (br.ReadUInt32() != 1323185555)
                {
                    if (!isSM2Texture)
                    {
                        output += "Unexpected section type\r\n";
                        errorcol = 1;
                        return false;
                    }
                }

                // Read the file

                var offset = br.ReadUInt32();
                var size = br.ReadUInt32();

                fs.Seek(0, SeekOrigin.Begin);
                header = br.ReadBytes((int)offset + 36);
                textureheader = br.ReadBytes((int)size);

                fs.Seek((int)offset + 36, SeekOrigin.Begin);
                Size = br.ReadUInt32();
                HDSize = br.ReadUInt32();
                HDMipmaps = 0;
                Mipmaps = 0;
                Width = br.ReadUInt16();
                Height = br.ReadUInt16();
                sd_width = br.ReadUInt16();
                sd_height = br.ReadUInt16();
                Images = br.ReadUInt16();

                var channels = br.ReadByte();

                string SDmipmapDiscrepancy = "Mipmap count discrepancy\r\n";
                string HDmipmapDiscrepancy = "HDMipmap count discrepancy\r\n";

                if (isSM2Texture)
                {
                    br.ReadBytes(5);

                    var dxgi_format = br.ReadByte();
                    Format = (DXGI_FORMAT?)dxgi_format;

                    // Unknown
                    br.ReadByte();

                    Mipmaps = br.ReadByte();
                    HDMipmaps = br.ReadByte();

                    fs.Seek(4, SeekOrigin.Current);
                    mipmaps = new();

                    for (int i = 0; i < Images; i++)
                        mipmaps.Add(br.ReadBytes((int)(Size / Images)));

                    int s = (int)(HDSize / Images);
                    int maxmipexp = (int)Math.Floor(Math.Log(s) / Math.Log(2));


                    s = (int)(Size / Images);
                    maxmipexp = (int)Math.Floor(Math.Log(s) / Math.Log(2));
                    basemipsize = 1 << maxmipexp;
                }
                else
                {
                    br.ReadByte();

                    var dxgi_format = br.ReadUInt16();
                    Format = (DXGI_FORMAT?)dxgi_format;
                    br.ReadBytes(8);

                    br.ReadBytes(7);
                    if (Mipmaps != br.ReadByte())
                    {
                        output += SDmipmapDiscrepancy;
                        errorcol = 4;
                        return false;
                    }
                    br.ReadByte();
                    if (HDMipmaps != br.ReadByte())
                    {
                        output += HDmipmapDiscrepancy;
                        errorcol = 5;
                        return false;
                    }

                    fs.Seek(4, SeekOrigin.Current);
                    mipmaps = new();
                    for (int i = 0; i < Images; i++)
                        mipmaps.Add(br.ReadBytes((int)(Size / Images)));

                    int s = (int)(HDSize / Images);
                    int maxmipexp = (int)Math.Floor(Math.Log(s) / Math.Log(2));
                    if (HDSize > 0)
                    {
                        for (int i = maxmipexp; s >= 1 << i && (s & (1 << i)) > 0; i -= 2)
                        {
                            HDMipmaps++;
                            s -= 1 << i;
                        }
                    }

                    s = (int)(Size / Images);
                    maxmipexp = (int)Math.Floor(Math.Log(s) / Math.Log(2));
                    basemipsize = 1 << maxmipexp;
                    for (int i = maxmipexp; s >= 1 << i && (s & (1 << i)) > 0; i -= 2)
                    {
                        Mipmaps++;
                        s -= 1 << i;
                    }
                }

                BytesPerPixel = Math.Pow(2, (Math.Floor(Math.Log((double)basemipsize / sd_width / sd_height) / Math.Log(2))));
                aspect = (int)(Math.Log((double)Width / (double)Height) / Math.Log(2));

                hdfilename = Path.ChangeExtension(Filename, ".hd.texture");
                string hdtxt;
                if (HDSize == 0)
                {
                    hdtxt = "single-part texture";
                    hdfilename = "";
                }
                else if (File.Exists(hdfilename))
                    hdtxt = "hd part found";
                else if (File.Exists(hdfilename.Replace(".hd.texture", "_hd.texture")))
                {
                    hdfilename = hdfilename.Replace(".hd.texture", "_hd.texture");
                    hdtxt = "found SpiderTex style _hd file";
                }
                else
                {
                    hdtxt = "hd part MISSING";
                    hdfilename = "";
                }
                var arraytxt = Images > 1 ? $"with {Images} packed textures " : "";
                output += $"Source {arraytxt}loaded ({hdtxt})\r\n";

                if (hdfilename != "")
                {
                    var hdfilesize = new FileInfo(hdfilename).Length;
                    if (hdfilesize != HDSize)
                    {
                        output += $"HD component is the wrong size (expected {HDSize} bytes, got {hdfilesize})\r\n";
                        errorcol = 8;
                        return false;
                    }
                }

                Ready = errorcol == -1;
                return true;
            }
        }
    }
}
