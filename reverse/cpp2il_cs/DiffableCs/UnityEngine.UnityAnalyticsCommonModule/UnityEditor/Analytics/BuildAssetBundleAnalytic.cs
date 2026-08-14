namespace UnityEditor.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
public class BuildAssetBundleAnalytic : AnalyticsEventBase
{
	public bool success; //Field offset: 0x30
	public string error; //Field offset: 0x38

	public BuildAssetBundleAnalytic() { }

	[RequiredByNativeCode]
	internal static BuildAssetBundleAnalytic CreateBuildAssetBundleAnalytic() { }

}

