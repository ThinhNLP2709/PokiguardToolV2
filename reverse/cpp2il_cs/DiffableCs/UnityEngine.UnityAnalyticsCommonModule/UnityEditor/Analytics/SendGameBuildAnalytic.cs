namespace UnityEditor.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
public class SendGameBuildAnalytic : AnalyticsEventBase
{
	private int navmesh_count; //Field offset: 0x30

	public SendGameBuildAnalytic() { }

	[RequiredByNativeCode]
	internal static SendGameBuildAnalytic CreateSendGameBuildAnalytic() { }

}

