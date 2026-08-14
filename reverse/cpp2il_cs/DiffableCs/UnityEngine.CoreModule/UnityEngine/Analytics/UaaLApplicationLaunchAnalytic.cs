namespace UnityEngine.Analytics;

[RequiredByNativeCode(GenerateProxy = True)]
internal class UaaLApplicationLaunchAnalytic : AnalyticsEventBase
{
	public int launch_type; //Field offset: 0x30
	public int launch_process_type; //Field offset: 0x34

	public UaaLApplicationLaunchAnalytic() { }

	[RequiredByNativeCode]
	public static UaaLApplicationLaunchAnalytic CreateUaaLApplicationLaunchAnalytic() { }

}

