namespace UnityEditor.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
public class StallSummaryAnalytic : AnalyticsEventBase
{
	public double Duration; //Field offset: 0x30

	public StallSummaryAnalytic() { }

	[RequiredByNativeCode]
	internal static StallSummaryAnalytic CreateStallSummaryAnalytic() { }

}

