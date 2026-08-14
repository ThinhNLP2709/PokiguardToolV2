namespace UnityEditor.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
public class ProjectSettingsInformationAnalytic : AnalyticsEventBase
{
	private int agent_types_count; //Field offset: 0x30
	private int areas_count; //Field offset: 0x34

	public ProjectSettingsInformationAnalytic() { }

	[RequiredByNativeCode]
	internal static ProjectSettingsInformationAnalytic CreateProjectSettingsInformationAnalytic() { }

}

