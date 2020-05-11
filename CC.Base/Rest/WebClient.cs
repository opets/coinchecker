using System;
using CC.Base.Configuration;
using CC.Base.Serialization;

namespace CC.Base.Rest
{
    internal sealed partial class WebClient: IWebClient
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IJsonConverter _jsonConverter;

        public WebClient(IConfigurationProvider configurationProvider, IJsonConverter jsonConverter)
        {
            _configurationProvider = configurationProvider;
            _jsonConverter = jsonConverter;
        }

        public T GetObject<T>(string relativeUrl)
        {
            using (var client = new System.Net.WebClient())
            {
                string url = GetFullUrl(relativeUrl);
                string json = client.DownloadString(url);
                ResponseObject<T> responce = _jsonConverter.DeserializeObject< ResponseObject < T > >(json);
                if (responce.Success)
                    return responce.Result;

                throw new UnsuccessfulResponseException(responce.Error.ErrorCode, json, typeof(T).Name);
            }
        }

        public T GetObjectWithAuth<T>(string relativeUrl)
        {
            using (var client = new System.Net.WebClient())
            {
                string url = GetFullUrl(relativeUrl);
                client.Headers.Add("authorization", _configurationProvider.AuthToken);
                string json = client.DownloadString(url);
                ResponseObject<T> responce = _jsonConverter.DeserializeObject<ResponseObject<T>>(json);
                if (responce.Success)
                    return responce.Result;

                throw new UnsuccessfulResponseException(responce.Error.ErrorCode, json, typeof(T).Name);
            }
        }

        private string GetFullUrl(string relativeUrl) => 
            $"{_configurationProvider.BaseUrl?.TrimEnd('/')}/{relativeUrl?.TrimStart('/')}";

        [Obsolete("for tests only")]
        public string GetStringWithAuth(string relativeUrl)
        {
            using (var client = new System.Net.WebClient())
            {
                client.Headers.Add("authorization", _configurationProvider.AuthToken);
                string url = GetFullUrl(relativeUrl);
                return client.DownloadString(url);
            }
        }

    }
}