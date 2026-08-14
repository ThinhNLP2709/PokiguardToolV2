namespace UnityEngine;

[ExcludeFromDocs]
[NativeHeader("Modules/UnityAnalytics/RemoteSettings/RemoteSettings.h")]
[NativeHeader("UnityAnalyticsScriptingClasses.h")]
[NativeHeader("Modules/UnityAnalyticsCommon/Public/UnityAnalyticsCommon.h")]
public class RemoteConfigSettings
{
	internal IntPtr m_Ptr; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<Boolean> Updated; //Field offset: 0x18

	[RequiredByNativeCode]
	internal static void RemoteConfigSettingsUpdated(RemoteConfigSettings rcs, bool wasLastUpdatedFromServer) { }

}

