/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets.ResourceProviders
{
	[DisplayName("Content Catalog Provider")]
	public class ContentCatalogProvider : ResourceProviderBase // TypeDefIndex: 14089
	{
		// Fields
		public bool DisableCatalogUpdateOnStart; // 0x20
		public bool IsLocalCatalogInBundle; // 0x21
		internal Dictionary<IResourceLocation, InternalOp> m_LocationToCatalogLoadOpMap; // 0x28
	
		// Nested types
		public enum DependencyHashIndex // TypeDefIndex: 14090
		{
			Remote = 0,
			Cache = 1,
			Local = 2,
			Count = 3
		}
	
		internal class InternalOp // TypeDefIndex: 14091
		{
			// Fields
			private string m_LocalDataPath; // 0x10
			private string m_RemoteHashValue; // 0x18
			internal string m_LocalHashValue; // 0x20
			private ProvideHandle m_ProviderInterface; // 0x28
			internal ContentCatalogData m_ContentCatalogData; // 0x40
			private AsyncOperationHandle<ContentCatalogData> m_ContentCatalogDataLoadOp; // 0x48
			private BundledCatalog m_BundledCatalog; // 0x60
			private bool m_Retried; // 0x68
			private bool m_DisableCatalogUpdateOnStart; // 0x69
			private bool m_IsLocalCatalogInBundle; // 0x6A
			private const string kCatalogExt = ".bin"; // Metadata: 0x006A954B
	
			// Nested types
			internal class BundledCatalog // TypeDefIndex: 14092
			{
				// Fields
				private readonly string m_BundlePath; // 0x10
				private bool m_OpInProgress; // 0x18
				private AssetBundleCreateRequest m_LoadBundleRequest; // 0x20
				internal AssetBundle m_CatalogAssetBundle; // 0x28
				private AssetBundleRequest m_LoadTextAssetRequest; // 0x30
				private ContentCatalogData m_CatalogData; // 0x38
				private WebRequestQueueOperation m_WebRequestQueueOperation; // 0x40
				private AsyncOperation m_RequestOperation; // 0x48
				private int m_WebRequestTimeout; // 0x50
				[CompilerGenerated]
				private Action<ContentCatalogData> OnLoaded; // 0x58
	
				// Properties
				public bool OpInProgress { get; } // 0x0000000180F9E350-0x0000000180F9E360 
				public bool OpIsSuccess { get; } // 0x0000000181C75950-0x0000000181C75970 
	
				// Events
				public event Action<ContentCatalogData> OnLoaded {
					add; // 0x0000000181C75890-0x0000000181C75950
					remove; // 0x0000000181C75970-0x0000000181C75A30
				}
	
				// Constructors
				public BundledCatalog(string bundlePath, int webRequestTimeout = 0 /* Metadata: 0x006A9550 */); // 0x0000000181C75750-0x0000000181C75890
	
				// Methods
				~BundledCatalog(); // 0x0000000181C74B90-0x0000000181C74C20
				private void Unload(); // 0x0000000181C753E0-0x0000000181C75420
				public void LoadCatalogFromBundleAsync(); // 0x0000000181C74C20-0x0000000181C74F40
				private void WebRequestOperationCompleted(AsyncOperation op); // 0x0000000181C754E0-0x0000000181C75750
				private void LoadTextAssetRequestComplete(AsyncOperation op); // 0x0000000181C74F40-0x0000000181C75110
				public bool WaitForCompletion(); // 0x0000000181C75420-0x0000000181C754E0
				[CompilerGenerated]
				private void _LoadCatalogFromBundleAsync_b__19_1(UnityWebRequestAsyncOperation asyncOp); // 0x0000000181C75340-0x0000000181C753E0
				[CompilerGenerated]
				private void _LoadCatalogFromBundleAsync_b__19_0(AsyncOperation loadOp); // 0x0000000181C75110-0x0000000181C75340
			}
	
			// Constructors
			public InternalOp(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Start(ProvideHandle providerInterface, bool disableCatalogUpdateOnStart, bool isLocalCatalogInBundle); // 0x0000000181C7ACE0-0x0000000181C7AF20
			private bool WaitForCompletionCallback(); // 0x0000000181C7AF60-0x0000000181C7B0F0
			public void Release(); // 0x0000000181C7AC90-0x0000000181C7ACE0
			internal bool CanLoadCatalogFromBundle(string idToLoad, IResourceLocation location); // 0x0000000181C79800-0x0000000181C79900
			internal void LoadCatalog(string idToLoad, bool loadCatalogFromLocalBundle); // 0x0000000181C79F20-0x0000000181C7A560
			private void CatalogLoadOpCompleteCallback(AsyncOperationHandle<ContentCatalogData> op); // 0x0000000181C79900-0x0000000181C79980
			private string GetTransformedInternalId(IResourceLocation loc); // 0x0000000181C79EA0-0x0000000181C79F20
			internal string DetermineIdToLoad(IResourceLocation location, IList<object> dependencyObjects, bool disableCatalogUpdateOnStart = false /* Metadata: 0x006A954A */); // 0x0000000181C79980-0x0000000181C79EA0
			private void OnCatalogLoaded(ContentCatalogData ccd); // 0x0000000181C7A560-0x0000000181C7AC90
			[CompilerGenerated]
			private void _LoadCatalog_b__14_0(ContentCatalogData ccd); // 0x0000000181C7AF20-0x0000000181C7AF60
		}
	
		// Constructors
		public ContentCatalogProvider(ResourceManager resourceManagerInstance); // 0x0000000181C781C0-0x0000000181C78240
	
		// Methods
		public override void Release(IResourceLocation location, object obj); // 0x0000000181C780B0-0x0000000181C781C0
		public override void Provide(ProvideHandle providerInterface); // 0x0000000181C77F50-0x0000000181C780B0
	}
}
