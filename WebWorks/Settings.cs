namespace WebWorks
{
    public class AppSettings
    {
        // Modding settings
        //------------------------------------------------------------------------------------------
        public bool _autoloadRecent { get; set; }
        public string _authorName { get; set; }
        public string _recentHashes { get; set; }
        public bool _experimentalFeatures { get; set; }
        public bool _disableAutoUpdateCheck {  get; set; }
        public int _preferredGameIndex { get; set; }

        // Save most recent TOCs
        //------------------------------------------------------------------------------------------
        public string _recentTOC1 { get; set; }
        public string _recentTOC2 { get; set; }
        public string _recentTOC3 { get; set; }
        public string _recentTOC4 { get; set; }
        public string _recentTOC5 { get; set; }

        // Customization
        //------------------------------------------------------------------------------------------
        public string _accentColor { get; set; }
        public string _accentColorGrid { get; set; }
    }

}
