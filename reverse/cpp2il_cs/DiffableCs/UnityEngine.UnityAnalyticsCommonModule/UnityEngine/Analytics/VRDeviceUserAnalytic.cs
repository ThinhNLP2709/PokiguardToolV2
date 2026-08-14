namespace UnityEngine.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
public class VRDeviceUserAnalytic : VRDeviceAnalyticBase
{
	public int vr_user_presence; //Field offset: 0x30

	public VRDeviceUserAnalytic() { }

	[RequiredByNativeCode]
	internal static VRDeviceUserAnalytic CreateVRDeviceUserAnalytic() { }

}

