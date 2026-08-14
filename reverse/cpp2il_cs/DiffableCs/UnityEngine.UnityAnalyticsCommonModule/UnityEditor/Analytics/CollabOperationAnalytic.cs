namespace UnityEditor.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
public class CollabOperationAnalytic : AnalyticsEventBase
{
	public string category; //Field offset: 0x30
	public string operation; //Field offset: 0x38
	public string result; //Field offset: 0x40
	public long start_ts; //Field offset: 0x48
	public long duration; //Field offset: 0x50

	public CollabOperationAnalytic() { }

	[RequiredByNativeCode]
	internal static CollabOperationAnalytic CreateCollabOperationAnalytic() { }

}

