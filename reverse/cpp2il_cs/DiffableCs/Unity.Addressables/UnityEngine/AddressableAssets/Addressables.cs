namespace UnityEngine.AddressableAssets;

public static class Addressables
{
	internal enum MergeMode
	{
		None = 0,
		UseFirst = 0,
		Union = 1,
		Intersection = 2,
	}

	internal static bool reinitializeAddressables; //Field offset: 0x0
	public const string kAddressablesRuntimeDataPath = "AddressablesRuntimeDataPath"; //Field offset: 0x0
	private const string k_AddressablesLogConditional = "ADDRESSABLES_LOG_ALL"; //Field offset: 0x0
	public const string kAddressablesRuntimeBuildLogPath = "AddressablesRuntimeBuildLog"; //Field offset: 0x0
	internal static AddressablesImpl m_AddressablesInstance; //Field offset: 0x8
	public static string LibraryPath; //Field offset: 0x10
	public static string BuildReportPath; //Field offset: 0x18

	public static string BuildPath
	{
		 get { } //Length: 141
	}

	internal static AddressablesImpl Instance
	{
		internal get { } //Length: 138
	}

	public static IInstanceProvider InstanceProvider
	{
		 get { } //Length: 139
	}

	public static Func<IResourceLocation, String> InternalIdTransformFunc
	{
		 get { } //Length: 148
		 set { } //Length: 165
	}

	private static AddressablesImpl m_Addressables
	{
		private get { } //Length: 79
	}

	public static string PlayerBuildDataPath
	{
		 get { } //Length: 141
	}

	public static IEnumerable<IResourceLocator> ResourceLocators
	{
		 get { } //Length: 141
	}

	public static ResourceManager ResourceManager
	{
		 get { } //Length: 139
	}

	[Preserve]
	public static string RuntimePath
	{
		 get { } //Length: 141
	}

	public static string StreamingAssetsSubFolder
	{
		 get { } //Length: 168
	}

	public static string Version
	{
		 get { } //Length: 44
	}

	public static Action<UnityWebRequest> WebRequestOverride
	{
		 get { } //Length: 148
		 set { } //Length: 165
	}

	private static Addressables() { }

	public static void AddResourceLocator(IResourceLocator locator, string localCatalogHash = null, IResourceLocation remoteCatalogLocation = null) { }

	public static AsyncOperationHandle<List`1<String>> CheckForCatalogUpdates(bool autoReleaseHandle = true) { }

	public static AsyncOperationHandle<Boolean> CleanBundleCache(IEnumerable<String> catalogsIds = null) { }

	public static void ClearDependencyCacheAsync(object key) { }

	public static void ClearDependencyCacheAsync(IList<IResourceLocation> locations) { }

	public static void ClearDependencyCacheAsync(IEnumerable keys) { }

	public static void ClearDependencyCacheAsync(string key) { }

	public static AsyncOperationHandle<Boolean> ClearDependencyCacheAsync(object key, bool autoReleaseHandle) { }

	public static AsyncOperationHandle<Boolean> ClearDependencyCacheAsync(string key, bool autoReleaseHandle) { }

	public static AsyncOperationHandle<Boolean> ClearDependencyCacheAsync(IList<IResourceLocation> locations, bool autoReleaseHandle) { }

	public static AsyncOperationHandle<Boolean> ClearDependencyCacheAsync(IEnumerable keys, bool autoReleaseHandle) { }

	public static void ClearResourceLocators() { }

	public static ResourceLocationBase CreateCatalogLocationWithHashDependencies(string remoteCatalogPath, string remoteHashPath) { }

	public static ResourceLocationBase CreateCatalogLocationWithHashDependencies(string remoteCatalogPath) { }

	public static ResourceLocationBase CreateCatalogLocationWithHashDependencies(IResourceLocation remoteCatalogLocation) { }

	public static AsyncOperationHandle DownloadDependenciesAsync(IEnumerable keys, MergeMode mode, bool autoReleaseHandle = false) { }

	public static AsyncOperationHandle DownloadDependenciesAsync(IList<IResourceLocation> locations, bool autoReleaseHandle = false) { }

	public static AsyncOperationHandle DownloadDependenciesAsync(object key, bool autoReleaseHandle = false) { }

	public static string get_BuildPath() { }

	internal static AddressablesImpl get_Instance() { }

	public static IInstanceProvider get_InstanceProvider() { }

	public static Func<IResourceLocation, String> get_InternalIdTransformFunc() { }

	private static AddressablesImpl get_m_Addressables() { }

	public static string get_PlayerBuildDataPath() { }

	public static IEnumerable<IResourceLocator> get_ResourceLocators() { }

	public static ResourceManager get_ResourceManager() { }

	public static string get_RuntimePath() { }

	public static string get_StreamingAssetsSubFolder() { }

	public static string get_Version() { }

	public static Action<UnityWebRequest> get_WebRequestOverride() { }

	public static AsyncOperationHandle<Int64> GetDownloadSizeAsync(IEnumerable keys) { }

	public static AsyncOperationHandle<Int64> GetDownloadSizeAsync(string key) { }

	public static AsyncOperationHandle<Int64> GetDownloadSizeAsync(object key) { }

	public static ResourceLocatorInfo GetLocatorInfo(IResourceLocator locator) { }

	public static ResourceLocatorInfo GetLocatorInfo(string locatorId) { }

	public static AsyncOperationHandle<IResourceLocator> InitializeAsync() { }

	public static AsyncOperationHandle<IResourceLocator> InitializeAsync(bool autoReleaseHandle) { }

	public static AsyncOperationHandle<GameObject> InstantiateAsync(object key, Vector3 position, Quaternion rotation, Transform parent = null, bool trackHandle = true) { }

	public static AsyncOperationHandle<GameObject> InstantiateAsync(IResourceLocation location, Transform parent = null, bool instantiateInWorldSpace = false, bool trackHandle = true) { }

	public static AsyncOperationHandle<GameObject> InstantiateAsync(IResourceLocation location, Vector3 position, Quaternion rotation, Transform parent = null, bool trackHandle = true) { }

	public static AsyncOperationHandle<GameObject> InstantiateAsync(object key, Transform parent = null, bool instantiateInWorldSpace = false, bool trackHandle = true) { }

	public static AsyncOperationHandle<GameObject> InstantiateAsync(IResourceLocation location, InstantiationParameters instantiateParameters, bool trackHandle = true) { }

	public static AsyncOperationHandle<GameObject> InstantiateAsync(object key, InstantiationParameters instantiateParameters, bool trackHandle = true) { }

	[Conditional("ADDRESSABLES_LOG_ALL")]
	internal static void InternalSafeSerializationLog(string msg, LogType logType = 3) { }

	[Conditional("ADDRESSABLES_LOG_ALL")]
	internal static void InternalSafeSerializationLogFormat(string format, LogType logType = 3, Object[] args) { }

	public static AsyncOperationHandle<TObject> LoadAssetAsync(object key) { }

	public static AsyncOperationHandle<TObject> LoadAssetAsync(IResourceLocation location) { }

	public static AsyncOperationHandle<IList`1<TObject>> LoadAssetsAsync(object key, Action<TObject> callback, bool releaseDependenciesOnFailure) { }

	public static AsyncOperationHandle<IList`1<TObject>> LoadAssetsAsync(object key, Action<TObject> callback) { }

	public static AsyncOperationHandle<IList`1<TObject>> LoadAssetsAsync(string key, bool releaseDependenciesOnFailure, Action<TObject> callback = null) { }

	public static AsyncOperationHandle<IList`1<TObject>> LoadAssetsAsync(IEnumerable keys, Action<TObject> callback, MergeMode mode, bool releaseDependenciesOnFailure) { }

	public static AsyncOperationHandle<IList`1<TObject>> LoadAssetsAsync(string key, Action<TObject> callback = null) { }

	public static AsyncOperationHandle<IList`1<TObject>> LoadAssetsAsync(IEnumerable keys, Action<TObject> callback, MergeMode mode) { }

	public static AsyncOperationHandle<IList`1<TObject>> LoadAssetsAsync(IList<IResourceLocation> locations, Action<TObject> callback, bool releaseDependenciesOnFailure) { }

	public static AsyncOperationHandle<IList`1<TObject>> LoadAssetsAsync(IList<IResourceLocation> locations, Action<TObject> callback) { }

	public static AsyncOperationHandle<IResourceLocator> LoadContentCatalogAsync(string catalogPath, bool autoReleaseHandle, string providerSuffix = null) { }

	public static AsyncOperationHandle<IResourceLocator> LoadContentCatalogAsync(string catalogPath, string providerSuffix = null) { }

	public static AsyncOperationHandle<IList`1<IResourceLocation>> LoadResourceLocationsAsync(object key, Type type = null) { }

	public static AsyncOperationHandle<IList`1<IResourceLocation>> LoadResourceLocationsAsync(IEnumerable keys, MergeMode mode, Type type = null) { }

	public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(IResourceLocation location, LoadSceneMode loadMode, SceneReleaseMode releaseMode, bool activateOnLoad = true, int priority = 100) { }

	public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneParameters loadSceneParameters, bool activateOnLoad = true, int priority = 100) { }

	public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneParameters loadSceneParameters, SceneReleaseMode releaseMode, bool activateOnLoad = true, int priority = 100) { }

	public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(IResourceLocation location, LoadSceneMode loadMode = 0, bool activateOnLoad = true, int priority = 100) { }

	public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(IResourceLocation location, LoadSceneParameters loadSceneParameters, bool activateOnLoad = true, int priority = 100) { }

	public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(IResourceLocation location, LoadSceneParameters loadSceneParameters, SceneReleaseMode releaseMode, bool activateOnLoad = true, int priority = 100) { }

	public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneMode loadMode, SceneReleaseMode releaseMode, bool activateOnLoad = true, int priority = 100) { }

	public static AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneMode loadMode = 0, bool activateOnLoad = true, int priority = 100, SceneReleaseMode releaseMode = 0) { }

	[Conditional("ADDRESSABLES_LOG_ALL")]
	public static void Log(string msg) { }

	public static void LogError(string msg) { }

	public static void LogErrorFormat(string format, Object[] args) { }

	public static void LogException(AsyncOperationHandle op, Exception ex) { }

	public static void LogException(Exception ex) { }

	[Conditional("ADDRESSABLES_LOG_ALL")]
	public static void LogFormat(string format, Object[] args) { }

	public static void LogWarning(string msg) { }

	public static void LogWarningFormat(string format, Object[] args) { }

	public static void Release(TObject obj) { }

	public static void Release(AsyncOperationHandle<TObject> handle) { }

	public static void Release(AsyncOperationHandle handle) { }

	public static bool ReleaseInstance(AsyncOperationHandle<GameObject> handle) { }

	public static bool ReleaseInstance(GameObject instance) { }

	public static bool ReleaseInstance(AsyncOperationHandle handle) { }

	public static void RemoveResourceLocator(IResourceLocator locator) { }

	public static string ResolveInternalId(string id) { }

	public static void set_InternalIdTransformFunc(Func<IResourceLocation, String> value) { }

	public static void set_WebRequestOverride(Action<UnityWebRequest> value) { }

	public static AsyncOperationHandle<SceneInstance> UnloadSceneAsync(AsyncOperationHandle handle, bool autoReleaseHandle = true) { }

	public static AsyncOperationHandle<SceneInstance> UnloadSceneAsync(AsyncOperationHandle handle, UnloadSceneOptions unloadOptions, bool autoReleaseHandle = true) { }

	public static AsyncOperationHandle<SceneInstance> UnloadSceneAsync(SceneInstance scene, UnloadSceneOptions unloadOptions, bool autoReleaseHandle = true) { }

	public static AsyncOperationHandle<SceneInstance> UnloadSceneAsync(SceneInstance scene, bool autoReleaseHandle = true) { }

	public static AsyncOperationHandle<SceneInstance> UnloadSceneAsync(AsyncOperationHandle<SceneInstance> handle, bool autoReleaseHandle = true) { }

	public static AsyncOperationHandle<List`1<IResourceLocator>> UpdateCatalogs(IEnumerable<String> catalogs = null, bool autoReleaseHandle = true) { }

	public static AsyncOperationHandle<List`1<IResourceLocator>> UpdateCatalogs(bool autoCleanBundleCache, IEnumerable<String> catalogs = null, bool autoReleaseHandle = true) { }

}

