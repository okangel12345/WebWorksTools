namespace WebWorks
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string filePath = null;
            string tocPath = null;
            bool skipMostRecent = false;

            for (int i = 0; i < args.Length; i++)
            {
                // Handle optional file and TOC paths
                if (args[i].StartsWith("-"))
                {
                    if (args[i] == "-skipMostRecentTOC")
                    {
                        skipMostRecent = true;
                    }
                }
                else
                {
                    // Assign paths
                    if (filePath == null)
                    {
                        filePath = args[i]; // First non-flag argument is the file path
                    }
                    else
                    {
                        tocPath = args[i];  // Second non-flag argument is the TOC path
                    }
                }
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow(filePath, tocPath, skipMostRecent));
        }
    }
}