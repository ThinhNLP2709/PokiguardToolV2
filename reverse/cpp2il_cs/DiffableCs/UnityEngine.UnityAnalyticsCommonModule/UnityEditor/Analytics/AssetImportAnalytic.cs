namespace UnityEditor.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
internal class AssetImportAnalytic : AnalyticsEventBase
{
	public string package_name; //Field offset: 0x30
	public int package_import_choice; //Field offset: 0x38

	public AssetImportAnalytic() { }

	[RequiredByNativeCode]
	public static AssetImportAnalytic CreateAssetImportAnalytic() { }

}

