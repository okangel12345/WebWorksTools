using System.CommandLine;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SpideyTextureScaler
{
    public class Program
    {
        public List<TextureBase> texturestats { get; set; }

        [STAThread]
        public static int Main(string[] args)
        {
            var p = new Program();
            p.texturestats = new List<TextureBase>() {
                new Source(),
                new DDS(),
                new Output(),
            };

            string filePath;

            if (args.Length > 0)
            {
                filePath = args[0];

                ApplicationConfiguration.Initialize();
                Application.Run(new SpideyTexture(p, false, filePath));
                return 0;
            }
            else
            {
                filePath = "";
                ApplicationConfiguration.Initialize();
                Application.Run(new SpideyTexture(p, false, filePath));
                return 0;
            }
        }

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        public int ConsoleMain(string[] args)
        {
            AttachConsole(ATTACH_PARENT_PROCESS);
            Console.WriteLine("\r\n");

            var rootcommand = new RootCommand($"(v{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}) Extract or replace textures.  See \"[command] --help\" for additional options.");
            // global
            var outputdir = new Option<DirectoryInfo?>(name: "--outputdir", description: "Output directory for generated files");
            outputdir.AddAlias("-o");
            rootcommand.AddGlobalOption(outputdir);
            // extract
            var source = new Argument<FileInfo?>(name: "source", "Source .texture file from the game");
            source.AddValidator(result => { if (!result.GetValueForArgument(source).Exists) result.ErrorMessage = "Source file not found"; });
            var allowsd = new Option<bool>("--allowsd", "Allow standard definition exports if the .hd.texture file is missing");
            var extractcommand = new Command("extract", "Extract .dds texture from input .texture/.hd.texture pairs.")
            {
                source,
                allowsd,
            };
            rootcommand.AddCommand(extractcommand);
            // replace
            var ddsfile = new Argument<FileInfo?>(name: "ddsfile", description: "Texture file in .dds format");
            ddsfile.AddValidator(result => { if (!result.GetValueForArgument(ddsfile).Exists) result.ErrorMessage = "DDS texture file not found"; });
            var ignoreformat = new Option<bool>("--ignoreformat", "Ignore DXGI format mismatches");
            var testmode = new Option<bool>("--testmode", "Replace only HD mipmaps");
            var extrasd = new Option<uint>("--extrasd", "Maximum number of mipmaps to move from .hd.texture to .texture");
            extrasd.SetDefaultValue(0);
            var replacecommand = new Command("replace", "Inject .dds texture into new .texture/.hd.texture files")
            {
                source,
                ddsfile,
                extrasd,
                ignoreformat,
                testmode
            };
            rootcommand.AddCommand(replacecommand);

            extractcommand.SetHandler((source, outputdir, allowsd) => { Extract(source, outputdir, allowsd); }, source, outputdir, allowsd);
            replacecommand.SetHandler((source, ddsfile, outputdir, extrasd, ignoreformat, testmode) => { Replace(source, ddsfile, outputdir, extrasd, ignoreformat, testmode); }, source, ddsfile, outputdir, extrasd, ignoreformat, testmode);
            var ret = rootcommand.Invoke(args);
            FreeConsole();
            return ret;
        }

        public void InitGlobals(FileInfo sourceInfo, DirectoryInfo? outputdirInfo, out string outputdir)
        {
            if (!sourceInfo.Exists)
            {
                Console.WriteLine("Source file not found");
                throw new FileNotFoundException();
            }

            if (outputdirInfo is not null && !outputdirInfo.Exists)
            {
                Console.WriteLine("Output directory not found");
                throw new FileNotFoundException();
            }

            outputdir = outputdirInfo?.FullName ?? "";
            string output;
            int errorrow;
            int errorcol;
            var source = (Source)texturestats[0];
            source.Filename = sourceInfo.FullName;
            source.Read(out output, out errorrow, out errorcol);

            Console.WriteLine(output);
            if (!source.Ready)
                throw new Exception("Problem with source file");
        }

        public void Extract(FileInfo sourceInfo, DirectoryInfo? outputdirInfo, bool allowsd)
        {
            string outputdir;
            Console.WriteLine($"Extract {sourceInfo.FullName}");
            InitGlobals(sourceInfo, outputdirInfo, out outputdir);

            var tex = (Source)texturestats[0];
            var savedds = new DDS();
            savedds.Filename = Path.ChangeExtension(tex.Filename, ".dds");
            savedds.Filename = outputdir != "" ? Path.Combine(outputdir, Path.GetFileName(savedds.Filename)) : savedds.Filename;
            savedds.Mipmaps = tex.Mipmaps;
            savedds.ArrayCount = tex.ArrayCount;
            savedds.Format = tex.Format;
            savedds.basemipsize = tex.basemipsize;
            byte[] hdmips = null;
            string output;

            savedds.HDMipmaps = 0;
            savedds.Width = tex.Width;
            savedds.Height = tex.Height;

            if (tex.HDSize > 0)
            {
                if (tex.hdfilename == "")
                {
                    if (!allowsd)
                        throw new Exception("HD texture data not available.  Provide a .hd.texture/_hd.texture file or enable --allowsd");
                    savedds.Width = (uint)tex.sd_width;
                    savedds.Height = (uint)tex.sd_height;
                }
                else
                {
                    savedds.HDMipmaps = tex.HDMipmaps;
                    hdmips = File.ReadAllBytes(tex.hdfilename);
                }
            }

            if (!savedds.Write(hdmips, tex.mipmaps, out output))
            {
                Console.WriteLine(output);
                throw new Exception("Extraction failed");
            };

            Console.WriteLine(output);
        }

        public void RunReplace(FileInfo sourceInfo, FileInfo ddsInfo, DirectoryInfo? outputdirInfo, uint extrasd, bool ignoreformat, bool testmode)
        {
            Replace(sourceInfo, ddsInfo, outputdirInfo, extrasd, ignoreformat, testmode);
        }

        private void Replace(FileInfo sourceInfo, FileInfo ddsInfo, DirectoryInfo? outputdirInfo, uint extrasd, bool ignoreformat, bool testmode)
        {
            string outputdir;
            Console.WriteLine($"Extract {sourceInfo.FullName}");
            InitGlobals(sourceInfo, outputdirInfo, out outputdir);
            var tex = (Source)texturestats[0];

            string output;
            int errorrow;
            int errorcol;
            var dds = (DDS)texturestats[1];
            dds.Filename = ddsInfo.FullName;
            if (tex.ArrayCount > 1 && !dds.Filename.ToLower().EndsWith(".a0.dds"))
                throw new Exception("Array textures must be named with .Ax.dds convention");
            dds.Read(out output, out errorrow, out errorcol);
            Console.WriteLine(output);
            if (!dds.Ready)
                throw new Exception("Problem with DDS file");

            var ddss = new List<DDS>() { dds };
            var stub = ddss[0].Filename.Substring(0, ddss[0].Filename.Length - ".a0.dds".Length);
            for (int i = 1; i < tex.ArrayCount; i++)
            {
                ddss.Add(new DDS());
                ddss[i].Filename = $"{stub}.A{i}.dds";
                if (!File.Exists(ddss[i].Filename))
                    throw new Exception($"Missing array image {i}: {ddss[i].Filename}");
                if (!ddss[i].Read(out output, out errorrow, out errorcol))
                {
                    Console.WriteLine(output);
                    return;
                }
                Console.WriteLine(output);
            }
            Output outobj = (Output)texturestats[2];
            outobj.Filename = Path.ChangeExtension(ddsInfo.FullName, ".texture");
            outobj.Filename = outputdir != "" ? Path.Combine(outputdir, Path.GetFileName(outobj.Filename)) : outobj.Filename;
            if (tex.Filename == outobj.Filename)
                throw new Exception("Input and output .texture files cannot be the same.  Choose an output directory, or rename your .dds");
            var scale = (uint)(Math.Floor(Math.Log(dds.basemipsize / (float)tex.basemipsize) / Math.Log(2.0f)) / 2.0f);
            outobj.Generate(
                (Source)(texturestats[0]),
                ddss,
                testmode,
                ignoreformat,
                Math.Min(extrasd, scale),
                out output, out errorrow, out errorcol);

            Console.WriteLine(output);
            if (errorcol > -1)
                throw new Exception("Error writing output texture");
        }
    }

    public abstract class TextureBase
    {
        // grid display fields
        public string? Name { get; set; }
        public bool Ready { get; set; }
        public uint? Width { get; set; }
        public uint? Height { get; set; }
        public uint? Mipmaps { get; set; }
        public uint? HDMipmaps { get; set; }
        public double? BytesPerPixel { get; set; }
        public uint? ArrayCount { get; set; }
        public uint? Cubemaps { get; set; }

        private uint? _images;

        public uint? Images
        {
            get { return _images ?? (ArrayCount * (Cubemaps ?? 1)); }
            set { _images = value; }
        }
        public uint? Size { get; set; }
        public uint? HDSize { get; set; }
        public DXGI_FORMAT? Format { get; set; }

        // display
        public string? Filename { get; set; }

        // non-display
        public int basemipsize;
        public int sd_width;
        public int sd_height;
        public int aspect;

        public const string defaultfilelabel = "Choose a file...";

        public abstract bool Read(out string output, out int errorrow, out int errorcol);
        public void ResetVisible()
        {
            Width = null;
            Height = null;
            Mipmaps = null;
            HDMipmaps = null;
            BytesPerPixel = null;
            Size = null;
            HDSize = null;
            Format = null;
            Ready = false;
            Filename = defaultfilelabel;
        }

        public int CalculateExpectedSize()
        {
            // avoid float errors
            int divisor = 0, multiplier = 1;
            bool compressed = true;
            switch (((ushort)Format, (ushort)Format))
            {
                // BC1
                case ( >= 70, <= 72):
                    divisor = 16 / 8;
                    break;
                // BC2
                case ( >= 73, <= 75):
                // BC3
                case ( >= 76, <= 78):
                    divisor = 16 / 16;
                    break;
                // BC4
                case ( >= 79, <= 81):
                    divisor = 16 / 8;
                    break;
                // BC5
                case ( >= 82, <= 84):
                // BC6H
                case ( >= 94, <= 96):
                // BC7
                case ( >= 97, <= 99):
                    divisor = 16 / 16;
                    break;
                default:
                    compressed = false;
                    break;
            }

            if (divisor == 0)
                switch (((ushort)Format, (ushort)Format))
                {
                    // R8G8B8A8
                    case ( >= 27, <= 32):
                    // R16G16
                    case ( >= 33, <= 38):
                    // R10G10B10A2, R11G11B10
                    case ( >= 23, <= 26):
                    // *32, *24*8
                    case ( >= 39, <= 47):
                        divisor = 1;
                        multiplier = 4;
                        break;
                    // R8, A8
                    case ( >= 60, <= 65):
                        divisor = 1;
                        break;
                    // R8G8, R16, D16
                    case ( >= 48, <= 59):
                        divisor = 1;
                        multiplier = 2;
                        break;
                    // R16G16B16A16, R32G32, *32*8*24
                    case ( >= 9, <= 21):
                        divisor = 1;
                        multiplier = 8;
                        break;
                }

            if (divisor == 0)
                return 0;

            basemipsize = (int)((Height ?? 0) * (Width ?? 0) * multiplier / divisor);
            int expectedsize = 0;
            int minmipsize = compressed ? 16 / divisor : 0;
            for (int j = 0; j < HDMipmaps + Mipmaps; j++)
                expectedsize += Math.Max(basemipsize >> (j * 2), minmipsize);

            return expectedsize;
        }
    }
}