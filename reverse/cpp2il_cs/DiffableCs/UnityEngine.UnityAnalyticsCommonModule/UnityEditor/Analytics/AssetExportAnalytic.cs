namespace UnityEditor.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
internal class AssetExportAnalytic : AnalyticsEventBase
{
	public string package_name; //Field offset: 0x30
	public string error_message; //Field offset: 0x38
	public int items_count; //Field offset: 0x40
	public String[] asset_extensions; //Field offset: 0x48
	public bool include_upm_dependencies; //Field offset: 0x50

	public AssetExportAnalytic() { }

	[RequiredByNativeCode]
	public static AssetExportAnalytic CreateAssetExportAnalytic() { }

}

