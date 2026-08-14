namespace UnityEditor.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
public class LicensingInitAnalytic : AnalyticsEventBase
{
	public string licensingProtocolVersion; //Field offset: 0x30
	public string licensingClientVersion; //Field offset: 0x38
	public string channelType; //Field offset: 0x40
	public double initTime; //Field offset: 0x48
	public bool isLegacy; //Field offset: 0x50
	public string sessionId; //Field offset: 0x58
	public string correlationId; //Field offset: 0x60

	public LicensingInitAnalytic() { }

	[RequiredByNativeCode]
	internal static LicensingInitAnalytic CreateLicensingInitAnalytic() { }

}

