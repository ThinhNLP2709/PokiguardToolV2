namespace UnityEditor.Analytics;

[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = True)]
public class AssetDatabaseRefreshAnalytic : AnalyticsEventBase
{
	[SerializeField]
	public bool isV2; //Field offset: 0x30
	[SerializeField]
	public long Imports_Imported; //Field offset: 0x38
	[SerializeField]
	public long Imports_ImportedInProcess; //Field offset: 0x40
	[SerializeField]
	public long Imports_ImportedOutOfProcess; //Field offset: 0x48
	[SerializeField]
	public long Imports_Refresh; //Field offset: 0x50
	[SerializeField]
	public long Imports_DomainReload; //Field offset: 0x58
	[SerializeField]
	public long CacheServer_MetadataRequested; //Field offset: 0x60
	[SerializeField]
	public long CacheServer_MetadataDownloaded; //Field offset: 0x68
	[SerializeField]
	public long CacheServer_MetadataFailedToDownload; //Field offset: 0x70
	[SerializeField]
	public long CacheServer_MetadataUploaded; //Field offset: 0x78
	[SerializeField]
	public long CacheServer_ArtifactsFailedToUpload; //Field offset: 0x80
	[SerializeField]
	public long CacheServer_MetadataVersionsDownloaded; //Field offset: 0x88
	[SerializeField]
	public long CacheServer_MetadataMatched; //Field offset: 0x90
	[SerializeField]
	public long CacheServer_ArtifactsDownloaded; //Field offset: 0x98
	[SerializeField]
	public long CacheServer_ArtifactFilesDownloaded; //Field offset: 0xA0
	[SerializeField]
	public long CacheServer_ArtifactFilesFailedToDownload; //Field offset: 0xA8
	[SerializeField]
	public long CacheServer_ArtifactsUploaded; //Field offset: 0xB0
	[SerializeField]
	public long CacheServer_ArtifactFilesUploaded; //Field offset: 0xB8
	[SerializeField]
	public long CacheServer_ArtifactFilesFailedToUpload; //Field offset: 0xC0
	[SerializeField]
	public long CacheServer_Connects; //Field offset: 0xC8
	[SerializeField]
	public long CacheServer_Disconnects; //Field offset: 0xD0

	public AssetDatabaseRefreshAnalytic() { }

	[RequiredByNativeCode]
	internal static AssetDatabaseRefreshAnalytic CreateAssetDatabaseRefreshAnalytic() { }

}

