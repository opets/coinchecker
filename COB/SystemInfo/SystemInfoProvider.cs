using System;
using System.Reflection;
using CC.Base.Common;
using CC.Base.Rest;
using log4net;

namespace CC.COB.SystemInfo
{
    internal partial class SystemInfoProvider : ISystemInfoProvider
    {
        private const string SystemTimeUrl = "/v1/system/time";
        private const string SystemInformationUrl = "/v1/system/info";
        public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IWebClient _webClient;

        public SystemInfoProvider(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public DateTime GetSystemTime()
        {
            try
            {
                var systemTimeJson = _webClient.GetObject<SystemTimeJson>(SystemTimeUrl);
                return JavaScriptDateConverter.FromJsDateTime(systemTimeJson.Time);
            }
            catch (Exception ex)
            {
                Log.Error("Unable to call GetSystemTime", ex);
                return DateTime.MinValue;
            }
        }

        public string GetSystemInformation()
        {
            try
            {
                var systemInformationJson = _webClient.GetObject<SystemInformationJson>(SystemInformationUrl);
                return $"{systemInformationJson.Info.Phase}:{systemInformationJson.Info.Revision}";
            }
            catch (Exception ex)
            {
                Log.Error("Unable to call GetSystemInformation", ex);
                return string.Empty;
            }
        }
    }
}