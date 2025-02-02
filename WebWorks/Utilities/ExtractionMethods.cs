using DAT1;
using SpideyTextureScaler;
using WebWorks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebWorks.Windows;
using WebWorks.Windows.Tools;

namespace WebWorks.Utilities
{
    public class ExtractionMethods
    {
        // Global method to extract an asset from loaded TOC
        //------------------------------------------------------------------------------------------
        public static void ExtractAsset(ulong assetID, byte span, string path, TOCBase _toc)
        {
            try
            {
                var bytes = _toc.GetAssetBytes(span, assetID);

                byte[] header = null;
                byte[] textureMeta = null;
                if (_toc is TOC_I29 toc_i29)
                {
                    var index = _toc.FindAssetIndex(span, assetID);
                    header = toc_i29.GetHeaderByAssetIndex(index);
                    textureMeta = toc_i29.GetTextureMetaByAssetIndex(index);
                }
                var packExtras = true; // TODO: make an option to control this
                var hasExtras = (header != null || textureMeta != null);
                if (packExtras && hasExtras)
                {
                    // TODO: make a class in DAT1 for that?
                    using var ms = new MemoryStream();
                    using var w = new BinaryWriter(ms);
                    w.Write(0x00475453); // STG\x00
                    uint flags = 0;
                    if (header != null) flags |= 0x1; // TODO: constant
                    if (textureMeta != null) flags |= 0x2; // TODO: constant
                    w.Write(flags);
                    w.Write((header == null ? 0 : header.Length));
                    w.Write((textureMeta == null ? 0 : textureMeta.Length));

                    if (header != null)
                    {
                        w.Write(header);
                        Align16(w);
                    }
                    if (textureMeta != null)
                    {
                        w.Write(textureMeta);
                        Align16(w);
                    }
                    w.Write(bytes);
                    File.WriteAllBytes(path, ms.ToArray());
                }
                else
                {
                    File.WriteAllBytes(path, bytes);
                }
            }

            catch { }

            static void Align16(BinaryWriter w)
            {
                var pos = w.BaseStream.Position % 16;
                if (pos != 0)
                {
                    var rem = 16 - pos;
                    w.Write(new byte[rem]);
                }
            }
        }

        // Extract to stage
        //------------------------------------------------------------------------------------------
        public static void ExtractToStage()
        {
            TOCBase _toc = MainWindow._toc;

            var window = new StageSelectorWindow();
            window.ShowDialog();

            if (window.Stage == null) return;

            var cwd = Directory.GetCurrentDirectory();
            var path = Path.Combine(cwd, "stages");
            var stagePath = Path.Combine(path, window.Stage);
            if (!Directory.Exists(stagePath)) Directory.CreateDirectory(stagePath);

            string[] assetPaths = GetCurrentAssets.Paths();
            ulong[] assetIDs = GetCurrentAssets.IDs();
            byte[] spans = GetCurrentAssets.Spans();

            for (int i = 0; i < assetPaths.Length; i++)
            {
                string assetPath = Path.Combine(stagePath, $"{spans[i]}", assetPaths[i]);
                ExtractAsset(assetIDs[i], spans[i], assetPath, _toc);
            }
        }

        // Extract as DDS
        //------------------------------------------------------------------------------------------
        public static void ExtractAsDDS()
        {
            string tempName = "temp_asset";
            string tempTexture = tempName + ".texture";
            string tempHDTexture = tempName + ".hd.texture";
            string tempDDS = tempName + ".dds";
            string assetName = Path.GetFileNameWithoutExtension(GetCurrentAssets.Names()[0]) + ".dds";

            using (var saveFileDialog = new SaveFileDialog
            {
                Title = "Save .dds file",
                Filter = "DDS Files (*.dds)|*.txt|All Files (*.*)|*.*",
                FileName = assetName,
                AddExtension = true
            })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string finalName = Path.GetFileName(saveFileDialog.FileName);
                    string workingDirectory = Path.GetDirectoryName(saveFileDialog.FileName);
                    string silkInput = Path.Combine(workingDirectory, tempTexture);
                    string silkHD = Path.Combine(workingDirectory, tempHDTexture);

                    try
                    {
                        ExtractAsset(GetCurrentAssets.IDs()[0], 0, silkInput, MainWindow._toc);
                        ExtractAsset(GetCurrentAssets.IDs()[0], 1, silkHD, MainWindow._toc);

                        var p = new SpideyTextureScaler.Program
                        {
                            texturestats = new List<TextureBase>
                            {
                                new Source(),
                                new DDS(),
                                new Output()
                            }
                        };

                        p.Extract(new FileInfo(silkInput), new DirectoryInfo(workingDirectory), true);

                        File.Delete(silkInput);
                        File.Delete(silkHD);

                        string tempNamePath = Path.Combine(workingDirectory, tempDDS);
                        string finalNamePath = Path.Combine(workingDirectory, finalName);

                        if (File.Exists(tempNamePath)) File.Move(tempNamePath, finalNamePath);
                    }
                    catch {}
                }
            }
        }

        // Extract as ASCII
        //------------------------------------------------------------------------------------------
        public static void ExtractAsASCII()
        {
            bool toci29;

            if (MainWindow._toc is TOC_I29)
            { toci29 = true; }
            else
            { toci29 = false; }

            var asset = GetCurrentAssets.Assets()[0];

            ExtractAsciiWindow extractAsciiWindow = new ExtractAsciiWindow(asset.FullPath, toci29, asset.Id, asset.Span, MainWindow._toc);

            extractAsciiWindow.ShowDialog();
        }
    }
}
