using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWorksCore;
using WebWorksCore.Sections;

namespace WebWave
{
    internal class SoundbankConversion
    {
        // Extract sections from soundbank
        //------------------------------------------------------------------------------------------
        public static void ExtractBnk(AssetManager _soundbank, string outputDir)
        {
            byte[] extractedBnk = _soundbank.GetAssetSection(Section.Soundbank.bnkData);

            File.WriteAllBytes(outputDir, extractedBnk);
        }

        public static void ExtractEventNames(AssetManager _soundbank, List<string> eventNames)
        {
            byte[] secBytes = _soundbank.GetAssetSection(Section.Soundbank.wemnames);
            int secSize = secBytes.Length;

            var fs = new MemoryStream(secBytes);
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (fs.Position != secSize)
                {
                    fs.Seek(AlignSizeToBlock(fs.Position, 4), SeekOrigin.Begin);
                    string str = ReadNullTerminatedString(br);
                    if (!str.Contains("\\"))
                        eventNames.Add(str);
                }
            }
        }

        //------------------------------------------------------------------------------------------
        static long AlignSizeToBlock(long size, int blockSize)
        {
            return (size + (blockSize - 1)) & ~(blockSize - 1);
        }

        //------------------------------------------------------------------------------------------
        static string ReadNullTerminatedString(BinaryReader reader)
        {
            List<byte> bytes = new List<byte>();
            byte b;
            while ((b = reader.ReadByte()) != 0)
            {
                bytes.Add(b);
            }
            return Encoding.UTF8.GetString(bytes.ToArray());
        }
    }
}
