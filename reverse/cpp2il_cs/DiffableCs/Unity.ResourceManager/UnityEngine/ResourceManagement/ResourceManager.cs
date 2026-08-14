namespace UnityEngine.ResourceManagement;

public class ResourceManager : IDisposable
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass90_0
	{
		public Action<TObject> callback; //Field offset: 0x0
		public bool releaseDependenciesOnFailure; //Field offset: 0x0
		public ResourceManager <>4__this; //Field offset: 0x0

		public <>c__DisplayClass90_0`1() { }

		internal void <ProvideResources>b__0(AsyncOperationHandle x) { }

		internal AsyncOperationHandle<IList`1<TObject>> <ProvideResources>b__1(AsyncOperationHandle resultHandle) { }

	}

	private class CompletedOperation : AsyncOperationBase<TObject>
	{
		private bool m_Success; //Field offset: 0x0
		private Exception m_Exception; //Field offset: 0x0
		private bool m_ReleaseDependenciesOnFailure; //Field offset: 0x0

		protected virtual string DebugName
		{
			 get { } //Length: 44
		}

		public CompletedOperation`1() { }

		protected virtual void Execute() { }

		protected virtual string get_DebugName() { }

		public void Init(TObject result, bool success, string errorMsg, bool releaseDependenciesOnFailure = true) { }

		public void Init(TObject result, bool success, Exception exception, bool releaseDependenciesOnFailure = true) { }

		protected virtual bool InvokeWaitForCompletion() { }

	}

	private struct DeferredCallbackRegisterRequest
	{
		internal IAsyncOperation operation; //Field offset: 0x0
		internal bool incrementRefCount; //Field offset: 0x8

	}

	internal enum DiagnosticEventType
	{
		AsyncOperationFail = 0,
		AsyncOperationCreate = 1,
		AsyncOperationPercentComplete = 2,
		AsyncOperationComplete = 3,
		AsyncOperationReferenceCount = 4,
		AsyncOperationDestroy = 5,
	}

	public class InstanceOperation : AsyncOperationBase<GameObject>
	{
		private AsyncOperationHandle<GameObject> m_dependency; //Field offset: 0x98
		private InstantiationParameters m_instantiationParams; //Field offset: 0xB0
		private IInstanceProvider m_instanceProvider; //Field offset: 0xE0
		private GameObject m_instance; //Field offset: 0xE8
		private Scene m_scene; //Field offset: 0xF0

		protected virtual string DebugName
		{
			 get { } //Length: 266
		}

		protected virtual float Progress
		{
			 get { } //Length: 61
		}

		public InstanceOperation() { }

		protected virtual void Destroy() { }

		protected virtual void Execute() { }

		protected virtual string get_DebugName() { }

		protected virtual float get_Progress() { }

		public virtual void GetDependencies(List<AsyncOperationHandle> deps) { }

		internal virtual DownloadStatus GetDownloadStatus(HashSet<Object> visited) { }

		public void Init(ResourceManager rm, IInstanceProvider instanceProvider, InstantiationParameters instantiationParams, AsyncOperationHandle<GameObject> dependency) { }

		public Scene InstanceScene() { }

		protected virtual bool InvokeWaitForCompletion() { }

	}

	[CompilerGenerated]
	private static Action<AsyncOperationHandle, Exception> <ExceptionHandler>k__BackingField; //Field offset: 0x0
	private static int s_GroupOperationTypeHash; //Field offset: 0x8
	private static int s_InstanceOperationTypeHash; //Field offset: 0xC
	[CompilerGenerated]
	private Func<IResourceLocation, String> <InternalIdTransformFunc>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private Action<UnityWebRequest> <WebRequestOverride>k__BackingField; //Field offset: 0x18
	internal bool CallbackHooksEnabled; //Field offset: 0x20
	private ListWithEvents<IResourceProvider> m_ResourceProviders; //Field offset: 0x28
	private IAllocationStrategy m_allocator; //Field offset: 0x30
	internal ListWithEvents<IUpdateReceiver> m_UpdateReceivers; //Field offset: 0x38
	private List<IUpdateReceiver> m_UpdateReceiversToRemove; //Field offset: 0x40
	private bool m_UpdatingReceivers; //Field offset: 0x48
	private bool m_InsideUpdateMethod; //Field offset: 0x49
	internal Dictionary<Int32, IResourceProvider> m_providerMap; //Field offset: 0x50
	private Dictionary<IOperationCacheKey, IAsyncOperation> m_AssetOperationCache; //Field offset: 0x58
	private HashSet<InstanceOperation> m_TrackedInstanceOperations; //Field offset: 0x60
	internal DelegateList<Single> m_UpdateCallbacks; //Field offset: 0x68
	private List<IAsyncOperation> m_DeferredCompleteCallbacks; //Field offset: 0x70
	private bool m_InsideExecuteDeferredCallbacksMethod; //Field offset: 0x78
	private List<DeferredCallbackRegisterRequest> m_DeferredCallbacksToRegister; //Field offset: 0x80
	private Action<IAsyncOperation> m_ReleaseOpNonCached; //Field offset: 0x88
	private Action<IAsyncOperation> m_ReleaseOpCached; //Field offset: 0x90
	private Action<IAsyncOperation> m_ReleaseInstanceOp; //Field offset: 0x98
	[CompilerGenerated]
	private CertificateHandler <CertificateHandlerInstance>k__BackingField; //Field offset: 0xA0
	private bool m_RegisteredForCallbacks; //Field offset: 0xA8
	private Dictionary<Type, Type> m_ProviderOperationTypeCache; //Field offset: 0xB0

	public IAllocationStrategy Allocator
	{
		 get { } //Length: 5
		 set { } //Length: 13
	}

	public CertificateHandler CertificateHandlerInstance
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	internal int DeferredCallbackCount
	{
		internal get { } //Length: 64
	}

	internal int DeferredCompleteCallbacksCount
	{
		internal get { } //Length: 60
	}

	public static Action<AsyncOperationHandle, Exception> ExceptionHandler
	{
		[CompilerGenerated]
		 get { } //Length: 78
		[CompilerGenerated]
		 set { } //Length: 105
	}

	internal int InstanceOperationCount
	{
		internal get { } //Length: 60
	}

	public Func<IResourceLocation, String> InternalIdTransformFunc
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	internal int OperationCacheCount
	{
		internal get { } //Length: 68
	}

	public IList<IResourceProvider> ResourceProviders
	{
		 get { } //Length: 5
	}

	public Action<UnityWebRequest> WebRequestOverride
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	private static ResourceManager() { }

	public ResourceManager(IAllocationStrategy alloc = null) { }

	[CompilerGenerated]
	private void <.ctor>b__53_0(IUpdateReceiver x) { }

	public AsyncOperationHandle<TObject> Acquire(AsyncOperationHandle<TObject> handle) { }

	public void Acquire(AsyncOperationHandle handle) { }

	private GroupOperation AcquireGroupOpFromCache(IOperationCacheKey key) { }

	internal void AddOperationToCache(IOperationCacheKey key, IAsyncOperation operation) { }

	public void AddUpdateReceiver(IUpdateReceiver receiver) { }

	internal int CachedOperationCount() { }

	private int CalculateLocationsHash(IList<IResourceLocation> locations, Type t = null) { }

	public void CleanupSceneInstances(Scene scene) { }

	internal void ClearOperationCache() { }

	internal IOperationCacheKey CreateCacheKeyForLocation(IResourceProvider provider, IResourceLocation location, Type desiredType = null) { }

	public AsyncOperationHandle<TObject> CreateChainOperation(AsyncOperationHandle<TObjectDependency> dependentOp, Func<AsyncOperationHandle`1<TObjectDependency>, AsyncOperationHandle`1<TObject>> callback) { }

	public AsyncOperationHandle<TObject> CreateChainOperation(AsyncOperationHandle dependentOp, Func<AsyncOperationHandle, AsyncOperationHandle`1<TObject>> callback) { }

	public AsyncOperationHandle<TObject> CreateChainOperation(AsyncOperationHandle<TObjectDependency> dependentOp, Func<AsyncOperationHandle`1<TObjectDependency>, AsyncOperationHandle`1<TObject>> callback, bool releaseDependenciesOnFailure = true) { }

	public AsyncOperationHandle<TObject> CreateChainOperation(AsyncOperationHandle dependentOp, Func<AsyncOperationHandle, AsyncOperationHandle`1<TObject>> callback, bool releaseDependenciesOnFailure = true) { }

	public AsyncOperationHandle<TObject> CreateCompletedOperation(TObject result, string errorMsg) { }

	internal AsyncOperationHandle<TObject> CreateCompletedOperationInternal(TObject result, bool success, Exception exception, bool releaseDependenciesOnFailure = true) { }

	public AsyncOperationHandle<TObject> CreateCompletedOperationWithException(TObject result, Exception exception) { }

	public AsyncOperationHandle<IList`1<AsyncOperationHandle>> CreateGenericGroupOperation(List<AsyncOperationHandle> operations, bool releasedCachedOpOnComplete = false) { }

	public AsyncOperationHandle<IList`1<AsyncOperationHandle>> CreateGroupOperation(IList<IResourceLocation> locations) { }

	internal AsyncOperationHandle<IList`1<AsyncOperationHandle>> CreateGroupOperation(IList<IResourceLocation> locations, bool allowFailedDependencies) { }

	internal T CreateOperation(Type actualType, int typeHash, IOperationCacheKey cacheKey, Action<IAsyncOperation> onDestroyAction) { }

	public override void Dispose() { }

	private void ExecuteDeferredCallbacks() { }

	public IAllocationStrategy get_Allocator() { }

	[CompilerGenerated]
	public CertificateHandler get_CertificateHandlerInstance() { }

	internal int get_DeferredCallbackCount() { }

	internal int get_DeferredCompleteCallbacksCount() { }

	[CompilerGenerated]
	public static Action<AsyncOperationHandle, Exception> get_ExceptionHandler() { }

	internal int get_InstanceOperationCount() { }

	[CompilerGenerated]
	public Func<IResourceLocation, String> get_InternalIdTransformFunc() { }

	internal int get_OperationCacheCount() { }

	public IList<IResourceProvider> get_ResourceProviders() { }

	[CompilerGenerated]
	public Action<UnityWebRequest> get_WebRequestOverride() { }

	private Type GetDefaultTypeForLocation(IResourceLocation loc) { }

	internal IAsyncOperation GetOperationFromCache(IResourceLocation location, Type desiredType) { }

	public IResourceProvider GetResourceProvider(Type t, IResourceLocation location) { }

	internal bool IsOperationCached(IOperationCacheKey key) { }

	private void OnInstanceOperationDestroy(IAsyncOperation o) { }

	private void OnObjectAdded(object obj) { }

	private void OnObjectRemoved(object obj) { }

	private void OnOperationDestroyCached(IAsyncOperation o) { }

	private void OnOperationDestroyNonCached(IAsyncOperation o) { }

	public AsyncOperationHandle<GameObject> ProvideInstance(IInstanceProvider provider, IResourceLocation location, InstantiationParameters instantiateParameters) { }

	public AsyncOperationHandle<TObject> ProvideResource(IResourceLocation location) { }

	private AsyncOperationHandle ProvideResource(IResourceLocation location, Type desiredType = null, bool releaseDependenciesOnFailure = true) { }

	internal AsyncOperationHandle<IList`1<AsyncOperationHandle>> ProvideResourceGroupCached(IList<IResourceLocation> locations, int groupHash, Type desiredType, Action<AsyncOperationHandle> callback, bool releaseDependenciesOnFailure = true) { }

	public AsyncOperationHandle<IList`1<TObject>> ProvideResources(IList<IResourceLocation> locations, Action<TObject> callback = null) { }

	public AsyncOperationHandle<IList`1<TObject>> ProvideResources(IList<IResourceLocation> locations, bool releaseDependenciesOnFailure, Action<TObject> callback = null) { }

	public AsyncOperationHandle<SceneInstance> ProvideScene(ISceneProvider sceneProvider, IResourceLocation location, LoadSceneMode loadSceneMode, bool activateOnLoad, int priority) { }

	public AsyncOperationHandle<SceneInstance> ProvideScene(ISceneProvider sceneProvider, IResourceLocation location, LoadSceneParameters loadSceneParameters, bool activateOnLoad, int priority) { }

	public AsyncOperationHandle<SceneInstance> ProvideScene(ISceneProvider sceneProvider, IResourceLocation location, LoadSceneParameters loadSceneParameters, SceneReleaseMode releaseMode, bool activateOnLoad, int priority) { }

	internal void RegisterForCallbacks() { }

	internal void RegisterForDeferredCallback(IAsyncOperation op, bool incrementRefCount = true) { }

	public void Release(AsyncOperationHandle handle) { }

	public AsyncOperationHandle<SceneInstance> ReleaseScene(ISceneProvider sceneProvider, AsyncOperationHandle<SceneInstance> sceneLoadHandle) { }

	internal bool RemoveOperationFromCache(IOperationCacheKey key) { }

	public void RemoveUpdateReciever(IUpdateReceiver receiver) { }

	public void set_Allocator(IAllocationStrategy value) { }

	[CompilerGenerated]
	public void set_CertificateHandlerInstance(CertificateHandler value) { }

	[CompilerGenerated]
	public static void set_ExceptionHandler(Action<AsyncOperationHandle, Exception> value) { }

	[CompilerGenerated]
	public void set_InternalIdTransformFunc(Func<IResourceLocation, String> value) { }

	[CompilerGenerated]
	public void set_WebRequestOverride(Action<UnityWebRequest> value) { }

	internal AsyncOperationHandle StartOperation(IAsyncOperation operation, AsyncOperationHandle dependency) { }

	public AsyncOperationHandle<TObject> StartOperation(AsyncOperationBase<TObject> operation, AsyncOperationHandle dependency) { }

	public string TransformInternalId(IResourceLocation location) { }

	internal void Update(float unscaledDeltaTime) { }

}

