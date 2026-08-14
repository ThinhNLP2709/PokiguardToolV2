namespace UnityEditor.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
internal class StallMarkerAnalytic : AnalyticsEventBase
{
	public string Name; //Field offset: 0x30
	public bool HasProgressMarkup; //Field offset: 0x38
	public double Duration; //Field offset: 0x40

	public StallMarkerAnalytic() { }

	[RequiredByNativeCode]
	internal static StallMarkerAnalytic CreateStallMarkerAnalytic() { }

}

