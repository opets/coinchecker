using System;
using System.IO;
using System.Reflection;
using CC.Base.Serialization;

namespace CC.Base.Configuration
{
    internal partial class BaseConfigurationProvider : IConfigurationProvider
    {
        protected virtual string ConfigFileName => "config.json";

        public string AuthToken { get; private set; }
        public string BaseUrl { get; private set; }
        public string[] ExcludeCurrencies { get; private set; }

        public BaseConfigurationProvider(IJsonConverter jsonConverter)
        {
            LoadConfig(GetConfig(), jsonConverter);
        }

        private void LoadConfig(string json, IJsonConverter jsonConverter)
        {
            var config = jsonConverter.DeserializeObject<ConfigurationJson>(json);
            BaseUrl = config.BaseUrl;
            ExcludeCurrencies = config.ExcludeCurrencies;
            AuthToken = config.AuthToken;
        }

        private string GetConfig()
        {
            var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName);
            if (!File.Exists(configFilePath))
            {
                var baseDir = Path.GetDirectoryName(Assembly.GetAssembly(typeof(BaseConfigurationProvider)).Location);
                configFilePath = Path.Combine(baseDir, ConfigFileName);
            }
            if (!File.Exists(configFilePath))
                throw new ArgumentException(
                    $"Config file '{ConfigFileName}' doesn't exists in {AppDomain.CurrentDomain.BaseDirectory}");

            return File.ReadAllText(configFilePath);
        }
    }
}