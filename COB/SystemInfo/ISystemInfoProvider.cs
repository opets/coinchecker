using System;

namespace CC.COB.SystemInfo
{
	public interface ISystemInfoProvider {
	    DateTime GetSystemTime();
	    string GetSystemInformation();

	}
}
