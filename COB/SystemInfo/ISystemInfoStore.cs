using System;
using CC.Base;

namespace CC.COB.SystemInfo
{
    public interface ISystemInfoStore
    {
        DateTime SystemTime { get; }
        string SystemInformation { get; }

        void Refresh();
    }
}