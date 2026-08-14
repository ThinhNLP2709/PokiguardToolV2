namespace UnityEditor.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
public class LicensingErrorAnalytic : AnalyticsEventBase
{
	public string licensingErrorType; //Field offset: 0x30
	public string additionalData; //Field offset: 0x38
	public string errorMessage; //Field offset: 0x40
	public string correlationId; //Field offset: 0x48
	public string sessionId; //Field offset: 0x50

	public LicensingErrorAnalytic() { }

	[RequiredByNativeCode]
	internal static LicensingErrorAnalytic CreateLicensingErrorAnalytic() { }

}

