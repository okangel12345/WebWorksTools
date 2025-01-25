using WebWorks;
using WebWorks.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebWorks.Utilities
{
    public class WWProj
    {
        // Read .wwproj format
        //------------------------------------------------------------------------------------------
        public static void Read(string filePath)
        {
            MainWindow Instance = MainWindow.Instance;

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (var reader = new BinaryReader(fileStream))
                {
                    string toc = reader.ReadString();
                    if (toc != "NoAssociatedTOC")
                    {
                        Instance.StartLoadTOCThread(toc);
                    }

                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        // Read the marker
                        string marker = reader.ReadString();

                        // Read the asset data
                        byte span = reader.ReadByte();
                        ulong id = reader.ReadUInt64();
                        string name = reader.ReadString();
                        string archive = reader.ReadString();
                        string fullPath = reader.ReadString();
                        string refPath = reader.ReadString();
                        byte hasHeader = reader.ReadByte();
                        string associatedString = reader.ReadString();

                        Asset asset = new Asset
                        {
                            Span = span,
                            Id = id,
                            Name = name,
                            Archive = archive,
                            FullPath = fullPath,
                            HasHeader = hasHeader != 0
                        };

                        // Determine the target dictionary
                        if (marker == "R")
                        {
                            if (!Instance._replacedAssets.ContainsKey(asset))
                            {
                                Instance._replacedAssets[asset] = associatedString;
                            }
                        }
                        else if (marker == "A")
                        {
                            if (!Instance._addedAssets.ContainsKey(asset))
                            {
                                Instance._addedAssets[asset] = associatedString;
                            }
                        }
                    }
                }
            }
        }

        // Write .wwproj format
        //------------------------------------------------------------------------------------------
        public static void Write(string filePath)
        {
            MainWindow Instance = MainWindow.Instance;
            var assetsToSave = new List<AssetWWPROJHelper>();

            foreach (var entry in Instance._replacedAssets)
            {
                assetsToSave.Add(new AssetWWPROJHelper(entry.Key, entry.Value));
            }

            foreach (var entry in Instance._addedAssets)
            {
                assetsToSave.Add(new AssetWWPROJHelper(entry.Key, entry.Value));
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                using (var writer = new BinaryWriter(fileStream))
                {
                    writer.Write(Instance._tocPath ?? "NoAssociatedTOC");

                    foreach (var entry in Instance._replacedAssets)
                    {
                        writer.Write("R"); // Marker for replaced assets
                        writer.Write(entry.Key.Span);
                        writer.Write(entry.Key.Id);
                        writer.Write(entry.Key.Name ?? string.Empty);
                        writer.Write(entry.Key.Archive ?? string.Empty);
                        writer.Write(entry.Key.FullPath ?? string.Empty);
                        writer.Write(entry.Key.RefPath);
                        writer.Write(entry.Key.HasHeader);
                        writer.Write(entry.Value ?? string.Empty);
                    }

                    // Write _addedAssets
                    foreach (var entry in Instance._addedAssets)
                    {
                        writer.Write("A"); // Marker for added assets
                        writer.Write(entry.Key.Span);
                        writer.Write(entry.Key.Id);
                        writer.Write(entry.Key.Name ?? string.Empty);
                        writer.Write(entry.Key.Archive ?? string.Empty);
                        writer.Write(entry.Key.FullPath ?? string.Empty);
                        writer.Write(entry.Key.RefPath);
                        writer.Write(entry.Key.HasHeader);
                        writer.Write(entry.Value ?? string.Empty);
                    }
                }
            }
        }
    }
}
