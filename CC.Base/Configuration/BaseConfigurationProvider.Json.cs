namespace CC.Base.Configuration
{
    internal partial class BaseConfigurationProvider
    {
        private class ConfigurationJson
        {
            public string BaseUrl { get; set; }
            public string AuthToken { get; set; }
            public string[] ExcludeCurrencies { get; set; }
        }
    }
}
