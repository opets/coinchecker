using System;

namespace CC.Base.Rest
{
    public interface IWebClient
    {
        T GetObject<T>(string relativeUrl);

        T GetObjectWithAuth<T>(string relativeUrl);

        [Obsolete("for tests only")]
        string GetStringWithAuth(string relativeUrl);
    }
}