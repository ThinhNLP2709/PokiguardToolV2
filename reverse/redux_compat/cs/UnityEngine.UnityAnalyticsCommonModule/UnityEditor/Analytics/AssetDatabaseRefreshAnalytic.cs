/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 58: UnityEngine.UnityAnalyticsCommonModule.dll - Assembly: UnityEngine.UnityAnalyticsCommonModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15685-15721

namespace UnityEditor.Analytics
{
	[Serializable]
	[ExcludeFromDocs]
	[RequiredByNativeCode(GenerateProxy = true)]
	public class AssetDatabaseRefreshAnalytic : AnalyticsEventBase // TypeDefIndex: 15697
	{
		// Fields
		[SerializeField]
		public bool isV2; // 0x30
		[SerializeField]
		public long Imports_Imported; // 0x38
		[SerializeField]
		public long Imports_ImportedInProcess; // 0x40
		[SerializeField]
		public long Imports_ImportedOutOfProcess; // 0x48
		[SerializeField]
		public long Imports_Refresh; // 0x50
		[SerializeField]
		public long Imports_DomainReload; // 0x58
		[SerializeField]
		public long CacheServer_MetadataRequested; // 0x60
		[SerializeField]
		public long CacheServer_MetadataDownloaded; // 0x68
		[SerializeField]
		public long CacheServer_MetadataFailedToDownload; // 0x70
		[SerializeField]
		public long CacheServer_MetadataUploaded; // 0x78
		[SerializeField]
		public long CacheServer_ArtifactsFailedToUpload; // 0x80
		[SerializeField]
		public long CacheServer_MetadataVersionsDownloaded; // 0x88
		[SerializeField]
		public long CacheServer_MetadataMatched; // 0x90
		[SerializeField]
		public long CacheServer_ArtifactsDownloaded; // 0x98
		[SerializeField]
		public long CacheServer_ArtifactFilesDownloaded; // 0xA0
		[SerializeField]
		public long CacheServer_ArtifactFilesFailedToDownload; // 0xA8
		[SerializeField]
		public long CacheServer_ArtifactsUploaded; // 0xB0
		[SerializeField]
		public long CacheServer_ArtifactFilesUploaded; // 0xB8
		[SerializeField]
		public long CacheServer_ArtifactFilesFailedToUpload; // 0xC0
		[SerializeField]
		public long CacheServer_Connects; // 0xC8
		[SerializeField]
		public long CacheServer_Disconnects; // 0xD0
	
		// Constructors
		public AssetDatabaseRefreshAnalytic(); // 0x00000001825C6440-0x00000001825C64B0
	
		// Methods
		[RequiredByNativeCode]
		internal static AssetDatabaseRefreshAnalytic CreateAssetDatabaseRefreshAnalytic(); // 0x00000001825C63B0-0x00000001825C6440
	}
}
