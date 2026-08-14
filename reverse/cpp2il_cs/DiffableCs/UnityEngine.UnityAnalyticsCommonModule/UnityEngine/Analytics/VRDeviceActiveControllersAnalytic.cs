namespace UnityEngine.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
public class VRDeviceActiveControllersAnalytic : VRDeviceAnalyticBase
{
	public String[] vr_active_controllers; //Field offset: 0x30

	public VRDeviceActiveControllersAnalytic() { }

	[RequiredByNativeCode]
	internal static VRDeviceActiveControllersAnalytic CreateVRDeviceActiveControllersAnalytic() { }

}

