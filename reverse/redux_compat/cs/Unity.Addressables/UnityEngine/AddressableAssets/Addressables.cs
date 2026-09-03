/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
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
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets
{
	public static class Addressables // TypeDefIndex: 14032
	{
		// Fields
		internal static bool reinitializeAddressables; // 0x00
		internal static bool isExitingPlaymode; // 0x01
		internal static AddressablesImpl m_AddressablesInstance; // 0x08
		public const string kAddressablesRuntimeDataPath = "AddressablesRuntimeDataPath"; // Metadata: 0x006A946C
		private const string k_AddressablesLogConditional = "ADDRESSABLES_LOG_ALL"; // Metadata: 0x006A9488
		public const string kAddressablesRuntimeBuildLogPath = "AddressablesRuntimeBuildLog"; // Metadata: 0x006A949D
		public static string LibraryPath; // 0x10
		public static string BuildReportPath; // 0x18
	
		// Properties
		private static AddressablesImpl m_Addressables { get; } // 0x0000000181C73520-0x0000000181C73570 
		public static string Version { get; } // 0x0000000181C73440-0x0000000181C73470 
		public static ResourceManager ResourceManager { get; } // 0x0000000181C733A0-0x0000000181C73440 
		internal static AddressablesImpl Instance { get; } // 0x0000000181C731C0-0x0000000181C73250 
		public static IInstanceProvider InstanceProvider { get; } // 0x0000000181C73120-0x0000000181C731C0 
		public static Func<IResourceLocation, string> InternalIdTransformFunc { get; set; } // 0x0000000181C73250-0x0000000181C73300 0x0000000181C73570-0x0000000181C73630
		public static Action<UnityWebRequest> WebRequestOverride { get; set; } // 0x0000000181C73470-0x0000000181C73520 0x0000000181C73630-0x0000000181C736F0
		public static string StreamingAssetsSubFolder { get; } // 0x0000000181C6E780-0x0000000181C6E7B0 
		public static string BuildPath { get; } // 0x0000000181C73110-0x0000000181C73120 
		public static string PlayerBuildDataPath { get; } // 0x0000000181C6E6D0-0x0000000181C6E6E0 
		[Preserve]
		public static string RuntimePath { get; } // 0x0000000181C6E6D0-0x0000000181C6E6E0 
		public static IEnumerable<IResourceLocator> ResourceLocators { get; } // 0x0000000181C73300-0x0000000181C733A0 
	
		// Nested types
		public enum MergeMode // TypeDefIndex: 14033
		{
			None = 0,
			UseFirst = 0,
			Union = 1,
			Intersection = 2
		}
	
		// Constructors
		static Addressables(); // 0x0000000181C72E20-0x0000000181C73110
	
		// Methods
		public static string ResolveInternalId(string id); // 0x0000000181C72700-0x0000000181C72710
		[Conditional("ADDRESSABLES_LOG_ALL")]
		internal static void InternalSafeSerializationLog(string msg, LogType logType = LogType.Log /* Metadata: 0x006A943C */); // 0x0000000181C71510-0x0000000181C71600
		[Conditional("ADDRESSABLES_LOG_ALL")]
		internal static void InternalSafeSerializationLogFormat(string format, LogType logType = LogType.Log /* Metadata: 0x006A943D */, params object[] args); // 0x0000000181C714D0-0x0000000181C71510
		[Conditional("ADDRESSABLES_LOG_ALL")]
		public static void Log(string msg); // 0x0000000181C6C7B0-0x0000000181C6C800
		[Conditional("ADDRESSABLES_LOG_ALL")]
		public static void LogFormat(string format, params object[] args); // 0x0000000181C6C6A0-0x0000000181C6C700
		public static void LogWarning(string msg); // 0x0000000181C6C760-0x0000000181C6C7B0
		public static void LogWarningFormat(string format, params object[] args); // 0x0000000181C6C700-0x0000000181C6C760
		public static void LogError(string msg); // 0x0000000181C6C5C0-0x0000000181C6C610
		public static void LogException(AsyncOperationHandle op, Exception ex); // 0x0000000181C72300-0x0000000181C723A0
		public static void LogException(Exception ex); // 0x00000001802E76C0-0x00000001802E76D0
		public static void LogErrorFormat(string format, params object[] args); // 0x0000000181C6C560-0x0000000181C6C5C0
		public static AsyncOperationHandle<IResourceLocator> InitializeAsync(); // 0x0000000181C70B70-0x0000000181C70C90
		public static AsyncOperationHandle<IResourceLocator> InitializeAsync(bool autoReleaseHandle); // 0x0000000181C70A40-0x0000000181C70B70
		public static AsyncOperationHandle<IResourceLocator> LoadContentCatalogAsync(string catalogPath, string providerSuffix = null); // 0x0000000181C71600-0x0000000181C716F0
		public static AsyncOperationHandle<IResourceLocator> LoadContentCatalogAsync(string catalogPath, bool autoReleaseHandle, string providerSuffix = null); // 0x0000000181C716F0-0x0000000181C717F0
		public static AsyncOperationHandle<TObject> LoadAssetAsync<TObject>(IResourceLocation location);
		public static AsyncOperationHandle<TObject> LoadAssetAsync<TObject>(object key);
		public static AsyncOperationHandle<IList<IResourceLocation>> LoadResourceLocationsAsync(IEnumerable keys, MergeMode mode, Type type = null); // 0x0000000181C718D0-0x0000000181C719D0
		public static AsyncOperationHandle<IList<IResourceLocation>> LoadResourceLocationsAsync(object key, Type type = null); // 0x0000000181C717F0-0x0000000181C718D0
		public static AsyncOperationHandle<IList<TObject>> LoadAssetsAsync<TObject>(IList<IResourceLocation> locations, Action<TObject> callback);
		public static AsyncOperationHandle<IList<TObject>> LoadAssetsAsync<TObject>(IList<IResourceLocation> locations, Action<TObject> callback, bool releaseDependenciesOnFailure);
		public static AsyncOperationHandle<IList<TObject>> LoadAssetsAsync<TObject>(IEnumerable keys, Action<TObject> callback, MergeMode mode);
		public static AsyncOperationHandle<IList<TObject>> LoadAssetsAsync<TObject>(string key, Action<TObject> callback = null);
		public static AsyncOperationHandle<IList<TObject>> LoadAssetsAsync<TObject>(IEnumerable keys, Action<TObject> callback, MergeMode mode, bool releaseDependenciesOnFailure);
		public static AsyncOperationHandle<IList<TObject>> LoadAssetsAsync<TObject>(string key, bool releaseDependenciesOnFailure, Action<TObject> callback = null);
		public static AsyncOperationHandle<IList<TObject>> LoadAssetsAsync<TObject>(object key, Action<TObject> callback);
		public static AsyncOperationHandle<IList<TObject>> LoadAssetsAsync<TObject>(object key, Action<TObject> callback, bool releaseDependenciesOnFailure);
		public static void Release<TObject>(TObject obj);
		public static void Release<TObject>(AsyncOperationHandle<TObject> handle);
		public static void Release(AsyncOperationHandle handle); // 0x0000000181C725A0-0x0000000181C725B0
		public static bool ReleaseInstance(GameObject instance); // 0x0000000181C723A0-0x0000000181C72540
		public static bool ReleaseInstance(AsyncOperationHandle handle); // 0x0000000181C72540-0x0000000181C72560
		public static bool ReleaseInstance(AsyncOperationHandle<GameObject> handle); // 0x0000000181C72560-0x0000000181C725A0
		public static AsyncOperationHandle<long> GetDownloadSizeAsync(object key); // 0x0000000181C70750-0x0000000181C708B0
		public static AsyncOperationHandle<long> GetDownloadSizeAsync(string key); // 0x0000000181C70520-0x0000000181C70680
		public static AsyncOperationHandle<long> GetDownloadSizeAsync(IEnumerable keys); // 0x0000000181C70680-0x0000000181C70750
		public static AsyncOperationHandle DownloadDependenciesAsync(object key, bool autoReleaseHandle = false /* Metadata: 0x006A943E */); // 0x0000000181C70430-0x0000000181C70520
		public static AsyncOperationHandle DownloadDependenciesAsync(IList<IResourceLocation> locations, bool autoReleaseHandle = false /* Metadata: 0x006A943F */); // 0x0000000181C70340-0x0000000181C70430
		public static AsyncOperationHandle DownloadDependenciesAsync(IEnumerable keys, MergeMode mode, bool autoReleaseHandle = false /* Metadata: 0x006A9440 */); // 0x0000000181C70240-0x0000000181C70340
		public static void ClearDependencyCacheAsync(object key); // 0x0000000181C6FFF0-0x0000000181C700B0
		public static void ClearDependencyCacheAsync(IList<IResourceLocation> locations); // 0x0000000181C6FF30-0x0000000181C6FFF0
		public static void ClearDependencyCacheAsync(IEnumerable keys); // 0x0000000181C700B0-0x0000000181C70170
		public static void ClearDependencyCacheAsync(string key); // 0x0000000181C6FE70-0x0000000181C6FF30
		public static AsyncOperationHandle<bool> ClearDependencyCacheAsync(object key, bool autoReleaseHandle); // 0x0000000181C6FD80-0x0000000181C6FE70
		public static AsyncOperationHandle<bool> ClearDependencyCacheAsync(IList<IResourceLocation> locations, bool autoReleaseHandle); // 0x0000000181C6FAB0-0x0000000181C6FBA0
		public static AsyncOperationHandle<bool> ClearDependencyCacheAsync(IEnumerable keys, bool autoReleaseHandle); // 0x0000000181C6FBA0-0x0000000181C6FC90
		public static AsyncOperationHandle<bool> ClearDependencyCacheAsync(string key, bool autoReleaseHandle); // 0x0000000181C6FC90-0x0000000181C6FD80
		public static ResourceLocatorInfo GetLocatorInfo(string locatorId); // 0x0000000181C70990-0x0000000181C70A40
		public static ResourceLocatorInfo GetLocatorInfo(IResourceLocator locator); // 0x0000000181C708B0-0x0000000181C70990
		public static AsyncOperationHandle<GameObject> InstantiateAsync(IResourceLocation location, Transform parent = null, bool instantiateInWorldSpace = false /* Metadata: 0x006A9441 */, bool trackHandle = true /* Metadata: 0x006A9442 */); // 0x0000000181C70FB0-0x0000000181C71120
		public static AsyncOperationHandle<GameObject> InstantiateAsync(IResourceLocation location, Vector3 position, Quaternion rotation, Transform parent = null, bool trackHandle = true /* Metadata: 0x006A9443 */); // 0x0000000181C70C90-0x0000000181C70E20
		public static AsyncOperationHandle<GameObject> InstantiateAsync(object key, Transform parent = null, bool instantiateInWorldSpace = false /* Metadata: 0x006A9444 */, bool trackHandle = true /* Metadata: 0x006A9445 */); // 0x0000000181C71240-0x0000000181C713B0
		public static AsyncOperationHandle<GameObject> InstantiateAsync(object key, Vector3 position, Quaternion rotation, Transform parent = null, bool trackHandle = true /* Metadata: 0x006A9446 */); // 0x0000000181C70E20-0x0000000181C70FB0
		public static AsyncOperationHandle<GameObject> InstantiateAsync(object key, InstantiationParameters instantiateParameters, bool trackHandle = true /* Metadata: 0x006A9447 */); // 0x0000000181C71120-0x0000000181C71240
		public static AsyncOperationHandle<GameObject> InstantiateAsync(IResourceLocation location, InstantiationParameters instantiateParameters, bool trackHandle = true /* Metadata: 0x006A9448 */); // 0x0000000181C713B0-0x0000000181C714D0
		public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneMode loadMode = LoadSceneMode.Single /* Metadata: 0x006A9449 */, bool activateOnLoad = true /* Metadata: 0x006A944A */, int priority = 100 /* Metadata: 0x006A944B */, SceneReleaseMode releaseMode = SceneReleaseMode.ReleaseSceneWhenSceneUnloaded /* Metadata: 0x006A944D */); // 0x0000000181C719D0-0x0000000181C71B10
		public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneMode loadMode, SceneReleaseMode releaseMode, bool activateOnLoad = true /* Metadata: 0x006A944E */, int priority = 100 /* Metadata: 0x006A944F */); // 0x0000000181C71FA0-0x0000000181C720E0
		public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneParameters loadSceneParameters, bool activateOnLoad = true /* Metadata: 0x006A9451 */, int priority = 100 /* Metadata: 0x006A9452 */); // 0x0000000181C720E0-0x0000000181C721F0
		public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneParameters loadSceneParameters, SceneReleaseMode releaseMode, bool activateOnLoad = true /* Metadata: 0x006A9454 */, int priority = 100 /* Metadata: 0x006A9455 */); // 0x0000000181C721F0-0x0000000181C72300
		public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(IResourceLocation location, LoadSceneMode loadMode = LoadSceneMode.Single /* Metadata: 0x006A9457 */, bool activateOnLoad = true /* Metadata: 0x006A9458 */, int priority = 100 /* Metadata: 0x006A9459 */); // 0x0000000181C71D60-0x0000000181C71E90
		public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(IResourceLocation location, LoadSceneMode loadMode, SceneReleaseMode releaseMode, bool activateOnLoad = true /* Metadata: 0x006A945B */, int priority = 100 /* Metadata: 0x006A945C */); // 0x0000000181C71B10-0x0000000181C71C50
		public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(IResourceLocation location, LoadSceneParameters loadSceneParameters, bool activateOnLoad = true /* Metadata: 0x006A945E */, int priority = 100 /* Metadata: 0x006A945F */); // 0x0000000181C71C50-0x0000000181C71D60
		public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(IResourceLocation location, LoadSceneParameters loadSceneParameters, SceneReleaseMode releaseMode, bool activateOnLoad = true /* Metadata: 0x006A9461 */, int priority = 100 /* Metadata: 0x006A9462 */); // 0x0000000181C71E90-0x0000000181C71FA0
		public static AsyncOperationHandle<SceneInstance> UnloadSceneAsync(SceneInstance scene, UnloadSceneOptions unloadOptions, bool autoReleaseHandle = true /* Metadata: 0x006A9464 */); // 0x0000000181C72B20-0x0000000181C72C30
		public static AsyncOperationHandle<SceneInstance> UnloadSceneAsync(AsyncOperationHandle handle, UnloadSceneOptions unloadOptions, bool autoReleaseHandle = true /* Metadata: 0x006A9465 */); // 0x0000000181C72810-0x0000000181C72920
		public static AsyncOperationHandle<SceneInstance> UnloadSceneAsync(SceneInstance scene, bool autoReleaseHandle = true /* Metadata: 0x006A9466 */); // 0x0000000181C72920-0x0000000181C72A20
		public static AsyncOperationHandle<SceneInstance> UnloadSceneAsync(AsyncOperationHandle handle, bool autoReleaseHandle = true /* Metadata: 0x006A9467 */); // 0x0000000181C72A20-0x0000000181C72B20
		public static AsyncOperationHandle<SceneInstance> UnloadSceneAsync(AsyncOperationHandle<SceneInstance> handle, bool autoReleaseHandle = true /* Metadata: 0x006A9468 */); // 0x0000000181C72710-0x0000000181C72810
		public static AsyncOperationHandle<List<string>> CheckForCatalogUpdates(bool autoReleaseHandle = true /* Metadata: 0x006A9469 */); // 0x0000000181C6F900-0x0000000181C6F9D0
		public static AsyncOperationHandle<List<IResourceLocator>> UpdateCatalogs(IEnumerable<string> catalogs = null, bool autoReleaseHandle = true /* Metadata: 0x006A946A */); // 0x0000000181C72C30-0x0000000181C72D20
		public static AsyncOperationHandle<List<IResourceLocator>> UpdateCatalogs(bool autoCleanBundleCache, IEnumerable<string> catalogs = null, bool autoReleaseHandle = true /* Metadata: 0x006A946B */); // 0x0000000181C72D20-0x0000000181C72E20
		public static void AddResourceLocator(IResourceLocator locator, string localCatalogHash = null, IResourceLocation remoteCatalogLocation = null); // 0x0000000181C6F760-0x0000000181C6F900
		public static void RemoveResourceLocator(IResourceLocator locator); // 0x0000000181C725B0-0x0000000181C72700
		public static void ClearResourceLocators(); // 0x0000000181C70170-0x0000000181C70240
		public static AsyncOperationHandle<bool> CleanBundleCache(IEnumerable<string> catalogsIds = null); // 0x0000000181C6F9D0-0x0000000181C6FAB0
		public static ResourceLocationBase CreateCatalogLocationWithHashDependencies<T>(string remoteCatalogPath)
			where T : IResourceProvider;
		public static ResourceLocationBase CreateCatalogLocationWithHashDependencies<T>(IResourceLocation remoteCatalogLocation)
			where T : IResourceProvider;
		public static ResourceLocationBase CreateCatalogLocationWithHashDependencies<T>(string remoteCatalogPath, string remoteHashPath)
			where T : IResourceProvider;
	}
}
