using System;

namespace CC.COB.SystemInfo
{
    internal sealed class SystemInfoStore: ISystemInfoStore
    {
        private readonly ISystemInfoProvider _systemProvider;
        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SystemInfoStore(ISystemInfoProvider systemProvider)
        {
            _systemProvider = systemProvider;
        }

        public DateTime SystemTime { get; private set; }
        public string SystemInformation { get; private set; }

        public void Refresh()
        {
            SystemTime = _systemProvider.GetSystemTime();
            SystemInformation = _systemProvider.GetSystemInformation();
            Log.Debug($@"System Time:{SystemTime}, {SystemInformation}");
        }
    }
}