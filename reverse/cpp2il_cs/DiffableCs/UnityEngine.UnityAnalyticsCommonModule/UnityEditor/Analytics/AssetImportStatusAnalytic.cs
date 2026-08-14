namespace UnityEditor.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
internal class AssetImportStatusAnalytic : AnalyticsEventBase
{
	public string package_name; //Field offset: 0x30
	public int package_items_count; //Field offset: 0x38
	public int package_import_status; //Field offset: 0x3C
	public string error_message; //Field offset: 0x40
	public int project_assets_count; //Field offset: 0x48
	public int unselected_assets_count; //Field offset: 0x4C
	public int selected_new_assets_count; //Field offset: 0x50
	public int selected_changed_assets_count; //Field offset: 0x54
	public int unchanged_assets_count; //Field offset: 0x58
	public String[] selected_asset_extensions; //Field offset: 0x60

	public AssetImportStatusAnalytic() { }

	[RequiredByNativeCode]
	public static AssetImportStatusAnalytic CreateAssetImportStatusAnalytic() { }

}

