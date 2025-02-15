using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebWorksCore.Sections.Section;

namespace WebWave
{
    internal class BnkEditor
    {
        public byte[] fileBytes;
        public string outputPath = "changed.bnk";
        private List<WemFile> audioData = new List<WemFile>();
        private List<WemFile> newFiles = new List<WemFile>();
        private int audioLen;
        private int seekAudio;
        private int DIDX_PrePos;
        private int DIDXChunkLenPos;

        public BnkEditor(byte[] file)
        {
            fileBytes = file;
            Parse();
        }

        private void Parse()
        {
            using (MemoryStream memoryStream = new MemoryStream(fileBytes))
            using (BinaryReader reader = new BinaryReader(memoryStream))
            {
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                // Read Header
                int magicNumber = reader.ReadInt32();
                int headerLength = reader.ReadInt32();
                int version = reader.ReadInt32();
                int soundbankId = reader.ReadInt32();

                // Skip Unknowns
                int currentPos = 8;
                while (currentPos < headerLength)
                {
                    reader.ReadInt32();
                    currentPos += 4;
                }

                DIDX_PrePos = (int)reader.BaseStream.Position;

                // Read DIDX Header
                int didxMagic = reader.ReadInt32();
                DIDXChunkLenPos = (int)reader.BaseStream.Position;
                int chunkLength = reader.ReadInt32();

                int audioLength = 0;
                if (chunkLength > 0)
                {
                    audioLen = chunkLength / 12;
                    for (int i = 0; i < audioLen; i++)
                    {
                        int fileID = reader.ReadInt32();
                        int offsetData = reader.ReadInt32();
                        int fileLength = reader.ReadInt32();

                        audioLength += fileLength;
                        audioData.Add(new WemFile { Name = fileID.ToString(), Offset = offsetData, Length = fileLength });
                    }
                }

                // Read DATA Chunk
                int dataMagic = reader.ReadInt32();
                int dataChunkLength = reader.ReadInt32();

                seekAudio = (int)reader.BaseStream.Position;

                Console.WriteLine($"Sound items: {audioLen}");

                // Read Audio Data
                foreach (var wem in audioData)
                {
                    reader.BaseStream.Seek(seekAudio + wem.Offset, SeekOrigin.Begin);
                    wem.Content = reader.ReadBytes(wem.Length);
                }
            }
        }

        public void Extract(string outputPath, List<string> files = null, string specificFileName = null)
        {
            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);

            foreach (var wem in audioData)
            {
                string fileName = wem.Name + ".wem";

                if (specificFileName != null && specificFileName != fileName)
                    continue;

                if (files != null && !files.Contains(fileName))
                    continue;

                Console.WriteLine($"Extracting {fileName}");
                File.WriteAllBytes(Path.Combine(outputPath, fileName), wem.Content);
            }
        }


        public string[] ListAudio()
        {
            string[] wems = audioData.Select(wem => $"{wem.Name}.wem").ToArray();

            foreach (var wem in wems)
            {
                Debug.WriteLine(wem);
            }

            return wems;
        }

        public void Update(List<string> replacements)
        {
            if (!newFiles.Any())
            {
                Console.WriteLine("New files are not selected. Ignoring replace command.");
                return;
            }

            LoadReplacements();

            using (MemoryStream memoryStream = new MemoryStream(fileBytes))
            using (BinaryReader reader = new BinaryReader(memoryStream))
            using (MemoryStream updatedMemoryStream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(updatedMemoryStream))
            {
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                writer.Write(reader.ReadBytes(DIDX_PrePos));  // Write header

                // DIDX
                writer.Write(0x58444944); // "DIDX"
                byte[] didxItems = new byte[audioLen * 12];
                writer.Write(didxItems.Length);
                writer.Write(didxItems);

                // DATA
                writer.Write(0x41544144); // "DATA"
                List<byte> audioBytes = new List<byte>();
                List<(int Offset, int Length)> offsets = new List<(int, int)>();
                int offset = 0;

                foreach (var wem in audioData)
                {
                    byte[] content = replacements.Contains(wem.Name + ".wem")
                        ? File.ReadAllBytes(newFiles.First(n => n.Name == wem.Name).Path)
                        : wem.Content;

                    offsets.Add((offset, content.Length));
                    audioBytes.AddRange(content);

                    while (audioBytes.Count % 16 != 0)
                        audioBytes.Add(0); // Align to 16 bytes

                    offset += content.Length;
                }

                writer.Write(audioBytes.Count);
                writer.Write(audioBytes.ToArray());

                // Write DIDX items
                writer.Seek(DIDXChunkLenPos + 4, SeekOrigin.Begin);
                foreach (var (offsetData, fileLength) in offsets)
                {
                    writer.Write(offsetData);
                    writer.Write(fileLength);
                }

                // Write remaining data
                writer.Seek(0, SeekOrigin.End);
                writer.Write(reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position)));

                // Update the fileBytes with the modified data
                fileBytes = updatedMemoryStream.ToArray();
            }
        }


        private void LoadReplacements()
        {
            foreach (var wem in newFiles)
            {
                wem.Content = File.ReadAllBytes(wem.Path);
            }
        }

        public void AddReplacement(string wemFilePath)
        {
            if (!File.Exists(wemFilePath))
                throw new FileNotFoundException("WEM file not found", wemFilePath);

            string fileName = Path.GetFileNameWithoutExtension(wemFilePath);
            newFiles.Add(new WemFile { Name = fileName, Path = wemFilePath });
        }

        private class WemFile
        {
            public string Name { get; set; }
            public int Offset { get; set; }
            public int Length { get; set; }
            public byte[] Content { get; set; }
            public string Path { get; set; }
        }
    }
}