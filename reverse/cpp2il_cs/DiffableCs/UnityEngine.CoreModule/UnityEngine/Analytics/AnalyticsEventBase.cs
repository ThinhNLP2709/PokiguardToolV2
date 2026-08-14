namespace UnityEngine.Analytics;

[RequiredByNativeCode(GenerateProxy = True)]
public class AnalyticsEventBase
{
	private string eventName; //Field offset: 0x10
	private int eventVersion; //Field offset: 0x18
	private string eventPrefix; //Field offset: 0x20
	private SendEventOptions sendEventOptions; //Field offset: 0x28

	public AnalyticsEventBase(string eventName, int eventVersion, SendEventOptions sendEventOptions = 0, string eventPrefix = "") { }

}

