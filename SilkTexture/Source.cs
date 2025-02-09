using Accessibility;
using WebWorksCore;

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
        }

        // Global SM2 texture enable
        public static bool isSM2Texture = false;

        public override bool Read(out string output, out int errorrow, out int errorcol)
        {
            output = "";
            errorrow = 0;
            errorcol = -1;
            exportable = false;

            if (!IsValidTextureFile(out output))
            {
                errorcol = 1;
                return false;
            }

            try
            {
                // Create AssetManager instance for _texture
                var _texture = new AssetManager(File.ReadAllBytes(Filename));
                int dat1Offset = _texture._DAT1Offset;

                using var fs = File.Open(Filename, FileMode.Open, FileAccess.Read);
                using var br = new BinaryReader(fs);

                // Prevent multiple asset sections from being loaded
                if (_texture._assetSections > 1)
                {
                    output += "Multiple sections not implemented. Woops\r\n";
                    errorcol = 1;
                    return false;
                }

                if (!ExtractTextureHeaders(br, _texture, out output, out errorcol))
                    return false;

                VerifyHdTexture(out output, out errorcol);

                // Display game in output
                output += GetGameTypeMessage(_texture._assetGame);

                Ready = errorcol == -1;
                return true;
            }
            catch (Exception ex)
            {
                output += $"Error reading file: {ex.Message}\r\n";
                errorcol = 1;
                return false;
            }
        }

        //------------------------------------------------------------------------------------------
        //
        // Texture checks before converting
        //
        //------------------------------------------------------------------------------------------

        // Verify it contains the string "Texture Built" for full compatibility
        private bool IsValidTextureFile(out string output)
        {
            try
            {
                string fileContent = File.ReadAllText(Filename);
                if (!fileContent.Contains("Texture Built"))
                {
                    output = "Not a texture asset. Please import the lowest resolution copy.\r\n";
                    return false;
                }
            }
            catch (Exception ex)
            {
                output = $"Error reading file: {ex.Message}\r\n";
                return false;
            }
            output = "";
            return true;
        }

        // Output message based on the game detected, check AssetManager.Game for supported games
        private string GetGameTypeMessage(AssetManager.Game assetGame) => assetGame switch
        {
            AssetManager.Game.MSM1 => "Marvel's Spider-Man texture.\r\n",
            AssetManager.Game.RCRA => "Ratchet & Clank: Rift Apart texture.\r\n",
            AssetManager.Game.MSM2 => "Marvel's Spider-Man 2 texture.\r\n",
            _ => "Unknown game texture.\r\n"
        };

        // Verify HD counterpart exists in the same directory
        private void VerifyHdTexture(out string output, out int errorCol)
        {
            output = "";
            errorCol = -1;
            hdfilename = Path.ChangeExtension(Filename, ".hd.texture");
            string hdTxt;

            if (HDSize == 0)
            {
                hdTxt = "single-part texture";
                hdfilename = "";
            }
            else if (File.Exists(hdfilename))
            {
                hdTxt = "hd part found";
            }
            else if (File.Exists(hdfilename.Replace(".hd.texture", "_hd.texture")))
            {
                hdfilename = hdfilename.Replace(".hd.texture", "_hd.texture");
                hdTxt = "found SpiderTex style _hd file";
            }
            else
            {
                hdTxt = "hd part MISSING";
                hdfilename = "";
            }

            var arrayTxt = Images > 1 ? $"with {Images} packed textures " : "";
            output += $"Source {arrayTxt}loaded ({hdTxt})\r\n";

            if (!string.IsNullOrEmpty(hdfilename))
            {
                var hdFileSize = new FileInfo(hdfilename).Length;
                if (hdFileSize != HDSize)
                {
                    output += $"HD component is the wrong size (expected {HDSize} bytes, got {hdFileSize})\r\n";
                    errorCol = 8;
                }
            }
        }

        // Calculate Mip Maps - should probably not be used
        private uint? CalculateMipmaps(uint? totalSize, uint? images)
        {
            if (totalSize == 0) return 0;

            int s = (int)(totalSize / images);
            int maxmipexp = (int)Math.Floor(Math.Log(s) / Math.Log(2));
            int mipmaps = 0;

            for (int i = maxmipexp; s >= (1 << i) && (s & (1 << i)) > 0; i -= 2)
            {
                mipmaps++;
                s -= 1 << i;
            }

            return (uint)mipmaps;
        }

        //------------------------------------------------------------------------------------------
        //
        // Extract texture file headers and data
        //
        //------------------------------------------------------------------------------------------
        private bool ExtractTextureHeaders(BinaryReader br, AssetManager _texture, out string output, out int errorCol)
        {
            output = "";
            errorCol = -1;

            // Get texture content offset and size
            var offset = _texture.GetAssetSectionOffset(WebWorksCore.Sections.Section.Texture.Content);
            var size = _texture.GetAssetSectionSize(WebWorksCore.Sections.Section.Texture.Content);

            // Read texture headers
            br.BaseStream.Seek(0, SeekOrigin.Begin);
            header = br.ReadBytes(offset);              // File header
            textureheader = br.ReadBytes(size);         // Texture content header

            // Start reading texture data
            br.BaseStream.Seek(offset, SeekOrigin.Begin);
            Size = br.ReadUInt32();
            HDSize = br.ReadUInt32();
            Width = br.ReadUInt16();
            Height = br.ReadUInt16();
            sd_width = br.ReadUInt16();
            sd_height = br.ReadUInt16();
            Images = br.ReadUInt16();

            // Mips were originally calculated, we're taking them from the file instead

            // HDMipmaps = 0;
            // Mipmaps = 0;

            // Never used
            var channels = br.ReadByte();

            string SDmipmapDiscrepancy = "Mipmap count discrepancy\r\n";
            string HDmipmapDiscrepancy = "HDMipmap count discrepancy\r\n";

            mipmaps = new List<byte[]>();

            HDMipmaps = CalculateMipmaps(HDSize, Images);
            Mipmaps = CalculateMipmaps(Size, Images);

            // Read MSM2 .texture differently, everything before has stayed the same
            //--------------------------------------------------------------------------------------
            if (_texture._assetGame == AssetManager.Game.MSM2)
            {
                isSM2Texture = true;
                
                br.ReadBytes(5);

                Format = (DXGI_FORMAT?)br.ReadByte(); // DXGI Format
                br.ReadByte(); // Unknown

                Mipmaps = br.ReadByte();
                HDMipmaps = br.ReadByte();

                br.BaseStream.Seek(4, SeekOrigin.Current);

                for (int i = 0; i < Images; i++)
                    mipmaps.Add(br.ReadBytes((int)(Size / Images)));
            }

            // Read legacy textures (not MSM2) - MSMR, MSMM, RCRA
            //--------------------------------------------------------------------------------------
            else
            {
                br.ReadByte();

                Format = (DXGI_FORMAT?)br.ReadUInt16();

                br.ReadBytes(8); // Unknown

                if (Mipmaps != br.ReadByte())
                {
                    output += SDmipmapDiscrepancy;
                    errorCol = 4;
                    return false;
                }
                br.ReadByte();
                if (HDMipmaps != br.ReadByte())
                {
                    output += HDmipmapDiscrepancy;
                    errorCol = 5;
                    return false;
                }

                br.BaseStream.Seek(11, SeekOrigin.Current);

                for (int i = 0; i < Images; i++)
                    mipmaps.Add(br.ReadBytes((int)(Size / Images)));
            }

            return true;
        }
    }
}