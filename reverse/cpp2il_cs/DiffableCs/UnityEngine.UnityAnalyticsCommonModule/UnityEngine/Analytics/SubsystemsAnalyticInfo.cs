namespace UnityEngine.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
public class SubsystemsAnalyticInfo : SubsystemsAnalyticBase
{
	private string id; //Field offset: 0x38
	private string plugin_name; //Field offset: 0x40
	private string version; //Field offset: 0x48
	private string library_name; //Field offset: 0x50

	public SubsystemsAnalyticInfo() { }

	[RequiredByNativeCode]
	internal static SubsystemsAnalyticInfo CreateSubsystemsAnalyticInfo() { }

}

