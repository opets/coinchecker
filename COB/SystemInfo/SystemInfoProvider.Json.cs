namespace CC.COB.SystemInfo
{
    internal partial class SystemInfoProvider
    {
        private class SystemTimeJson
        {
            public long Time { get; set; }
        }

        private class SystemInformationJson
        {
            public SystemInformationInfoJson Info { get; set; }
        }

        private class SystemInformationInfoJson
        {
            public string Phase { get; set; }
            public string Revision { get; set; }
        }
    }
}