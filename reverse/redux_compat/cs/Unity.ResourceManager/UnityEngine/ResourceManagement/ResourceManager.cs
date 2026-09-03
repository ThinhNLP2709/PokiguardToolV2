/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.ResourceManagement.Util;
using UnityEngine.SceneManagement;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement
{
	public class ResourceManager : IDisposable // TypeDefIndex: 13671
	{
		// Fields
		[CompilerGenerated]
		private static Action<AsyncOperationHandle, Exception> _ExceptionHandler_k__BackingField; // 0x00
		[CompilerGenerated]
		private Func<IResourceLocation, string> _InternalIdTransformFunc_k__BackingField; // 0x10
		[CompilerGenerated]
		private Action<UnityWebRequest> _WebRequestOverride_k__BackingField; // 0x18
		internal bool CallbackHooksEnabled; // 0x20
		private ListWithEvents<IResourceProvider> m_ResourceProviders; // 0x28
		private IAllocationStrategy m_allocator; // 0x30
		internal ListWithEvents<IUpdateReceiver> m_UpdateReceivers; // 0x38
		private List<IUpdateReceiver> m_UpdateReceiversToRemove; // 0x40
		private bool m_UpdatingReceivers; // 0x48
		private bool m_InsideUpdateMethod; // 0x49
		internal Dictionary<int, IResourceProvider> m_providerMap; // 0x50
		private Dictionary<IOperationCacheKey, IAsyncOperation> m_AssetOperationCache; // 0x58
		private HashSet<InstanceOperation> m_TrackedInstanceOperations; // 0x60
		internal DelegateList<float> m_UpdateCallbacks; // 0x68
		private List<IAsyncOperation> m_DeferredCompleteCallbacks; // 0x70
		private bool m_InsideExecuteDeferredCallbacksMethod; // 0x78
		private List<DeferredCallbackRegisterRequest> m_DeferredCallbacksToRegister; // 0x80
		private Action<IAsyncOperation> m_ReleaseOpNonCached; // 0x88
		private Action<IAsyncOperation> m_ReleaseOpCached; // 0x90
		private Action<IAsyncOperation> m_ReleaseInstanceOp; // 0x98
		private static readonly int s_GroupOperationTypeHash; // 0x08
		private static readonly int s_InstanceOperationTypeHash; // 0x0C
		[CompilerGenerated]
		private CertificateHandler _CertificateHandlerInstance_k__BackingField; // 0xA0
		private bool m_RegisteredForCallbacks; // 0xA8
		private Dictionary<Type, Type> m_ProviderOperationTypeCache; // 0xB0
	
		// Properties
		public static Action<AsyncOperationHandle, Exception> ExceptionHandler { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182057A10-0x0000000182057A60 0x0000000182057A60-0x0000000182057AD0
		public Func<IResourceLocation, string> InternalIdTransformFunc { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public Action<UnityWebRequest> WebRequestOverride { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		internal int OperationCacheCount { get; } // 0x0000000182053AF0-0x0000000182053B10 
		internal int InstanceOperationCount { get; } // 0x00000001817758F0-0x0000000181775910 
		internal int DeferredCompleteCallbacksCount { get; } // 0x00000001820579F0-0x0000000182057A10 
		internal int DeferredCallbackCount { get; } // 0x00000001820579D0-0x00000001820579F0 
		public IAllocationStrategy Allocator { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public IList<IResourceProvider> ResourceProviders { get; } // 0x000000018033D240-0x000000018033D250 
		public CertificateHandler CertificateHandlerInstance { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
	
		// Nested types
		public enum DiagnosticEventType // TypeDefIndex: 13672
		{
			AsyncOperationFail = 0,
			AsyncOperationCreate = 1,
			AsyncOperationPercentComplete = 2,
			AsyncOperationComplete = 3,
			AsyncOperationReferenceCount = 4,
			AsyncOperationDestroy = 5
		}
	
		private struct DeferredCallbackRegisterRequest // TypeDefIndex: 13673
		{
			// Fields
			internal IAsyncOperation operation; // 0x00
			internal bool incrementRefCount; // 0x08
		}
	
		private class CompletedOperation<TObject> : AsyncOperationBase<TObject> // TypeDefIndex: 13674
		{
			// Fields
			private bool m_Success;
			private Exception m_Exception;
			private bool m_ReleaseDependenciesOnFailure;
	
			// Properties
			protected override string DebugName { get; }
	
			// Constructors
			public CompletedOperation();
	
			// Methods
			public void Init(TObject result, bool success, string errorMsg, bool releaseDependenciesOnFailure = true /* Metadata: 0x006A7E15 */);
			public void Init(TObject result, bool success, Exception exception, bool releaseDependenciesOnFailure = true /* Metadata: 0x006A7E16 */);
			protected override bool InvokeWaitForCompletion();
			protected override void Execute();
		}
	
		internal class InstanceOperation : AsyncOperationBase<GameObject> // TypeDefIndex: 13675
		{
			// Fields
			private AsyncOperationHandle<GameObject> m_dependency; // 0x98
			private InstantiationParameters m_instantiationParams; // 0xB0
			private IInstanceProvider m_instanceProvider; // 0xE0
			private GameObject m_instance; // 0xE8
			private Scene m_scene; // 0xF0
	
			// Properties
			protected override string DebugName { get; } // 0x000000018204B360-0x000000018204B460 
			protected override float Progress { get; } // 0x000000018204B460-0x000000018204B4A0 
	
			// Constructors
			public InstanceOperation(); // 0x000000018204B320-0x000000018204B360
	
			// Methods
			public void Init(ResourceManager rm, IInstanceProvider instanceProvider, InstantiationParameters instantiationParams, AsyncOperationHandle<GameObject> dependency); // 0x000000018204B180-0x000000018204B230
			internal override DownloadStatus GetDownloadStatus(HashSet<object> visited); // 0x000000018204B0C0-0x000000018204B180
			public override void GetDependencies(List<AsyncOperationHandle> deps); // 0x000000018204AFB0-0x000000018204B0C0
			public Scene InstanceScene(); // 0x0000000180CC3740-0x0000000180CC3750
			protected override void Destroy(); // 0x000000018204AC00-0x000000018204AD10
			protected override bool InvokeWaitForCompletion(); // 0x000000018204B230-0x000000018204B320
			protected override void Execute(); // 0x000000018204AD10-0x000000018204AFB0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass90_0<TObject> // TypeDefIndex: 13676
		{
			// Fields
			public Action<TObject> callback;
			public bool releaseDependenciesOnFailure;
			public ResourceManager __4__this;
	
			// Constructors
			public __c__DisplayClass90_0();
	
			// Methods
			internal void _ProvideResources_b__0(AsyncOperationHandle x);
			internal AsyncOperationHandle<IList<TObject>> _ProvideResources_b__1(AsyncOperationHandle resultHandle);
		}
	
		// Constructors
		public ResourceManager(IAllocationStrategy alloc = null); // 0x0000000182057530-0x00000001820579D0
		static ResourceManager(); // 0x0000000182057470-0x0000000182057530
	
		// Methods
		public string TransformInternalId(IResourceLocation location); // 0x0000000182057040-0x00000001820570C0
		public void AddUpdateReceiver(IUpdateReceiver receiver); // 0x0000000182053A90-0x0000000182053AF0
		public void RemoveUpdateReciever(IUpdateReceiver receiver); // 0x0000000182056D50-0x0000000182056E90
		private void OnObjectAdded(object obj); // 0x0000000182054D50-0x0000000182054DE0
		private void OnObjectRemoved(object obj); // 0x0000000182054DE0-0x0000000182054E40
		internal void RegisterForCallbacks(); // 0x0000000182056720-0x0000000182056870
		public IResourceProvider GetResourceProvider(Type t, IResourceLocation location); // 0x0000000182054960-0x0000000182054BD0
		private Type GetDefaultTypeForLocation(IResourceLocation loc); // 0x00000001820547D0-0x00000001820548B0
		private int CalculateLocationsHash(IList<IResourceLocation> locations, Type t = null); // 0x0000000182053B10-0x0000000182053DA0
		private AsyncOperationHandle ProvideResource(IResourceLocation location, Type desiredType = null, bool releaseDependenciesOnFailure = true /* Metadata: 0x006A7E08 */); // 0x0000000182055B70-0x00000001820563D0
		internal IAsyncOperation GetOperationFromCache(IResourceLocation location, Type desiredType); // 0x00000001820548B0-0x0000000182054960
		internal IOperationCacheKey CreateCacheKeyForLocation(IResourceProvider provider, IResourceLocation location, Type desiredType = null); // 0x00000001820540C0-0x0000000182054270
		public AsyncOperationHandle<TObject> ProvideResource<TObject>(IResourceLocation location);
		public AsyncOperationHandle<TObject> StartOperation<TObject>(AsyncOperationBase<TObject> operation, AsyncOperationHandle dependency);
		internal AsyncOperationHandle StartOperation(IAsyncOperation operation, AsyncOperationHandle dependency); // 0x0000000182056E90-0x0000000182057040
		private void OnInstanceOperationDestroy(IAsyncOperation o); // 0x0000000182054C30-0x0000000182054D50
		private void OnOperationDestroyNonCached(IAsyncOperation o); // 0x0000000182054FC0-0x0000000182055050
		private void OnOperationDestroyCached(IAsyncOperation o); // 0x0000000182054E40-0x0000000182054FC0
		internal T CreateOperation<T>(Type actualType, int typeHash, IOperationCacheKey cacheKey, Action<IAsyncOperation> onDestroyAction)
			where T : IAsyncOperation;
		internal void AddOperationToCache(IOperationCacheKey key, IAsyncOperation operation); // 0x00000001820539F0-0x0000000182053A90
		internal bool RemoveOperationFromCache(IOperationCacheKey key); // 0x0000000182056CB0-0x0000000182056D50
		internal bool IsOperationCached(IOperationCacheKey key); // 0x0000000182054BD0-0x0000000182054C30
		internal int CachedOperationCount(); // 0x0000000182053AF0-0x0000000182053B10
		internal void ClearOperationCache(); // 0x00000001820540A0-0x00000001820540C0
		public AsyncOperationHandle<TObject> CreateCompletedOperation<TObject>(TObject result, string errorMsg);
		public AsyncOperationHandle<TObject> CreateCompletedOperationWithException<TObject>(TObject result, Exception exception);
		internal AsyncOperationHandle<TObject> CreateCompletedOperationInternal<TObject>(TObject result, bool success, Exception exception, bool releaseDependenciesOnFailure = true /* Metadata: 0x006A7E09 */);
		public void Release(AsyncOperationHandle handle); // 0x0000000182056C40-0x0000000182056CB0
		public AsyncOperationHandle<TObject> Acquire<TObject>(AsyncOperationHandle<TObject> handle);
		public void Acquire(AsyncOperationHandle handle); // 0x0000000182053990-0x00000001820539F0
		private GroupOperation AcquireGroupOpFromCache(IOperationCacheKey key); // 0x0000000182053880-0x0000000182053990
		public AsyncOperationHandle<IList<AsyncOperationHandle>> CreateGroupOperation<T>(IList<IResourceLocation> locations);
		internal AsyncOperationHandle<IList<AsyncOperationHandle>> CreateGroupOperation<T>(IList<IResourceLocation> locations, bool allowFailedDependencies);
		public AsyncOperationHandle<IList<AsyncOperationHandle>> CreateGenericGroupOperation(List<AsyncOperationHandle> operations, bool releasedCachedOpOnComplete = false /* Metadata: 0x006A7E0A */); // 0x0000000182054270-0x0000000182054470
		internal AsyncOperationHandle<IList<AsyncOperationHandle>> ProvideResourceGroupCached(IList<IResourceLocation> locations, int groupHash, Type desiredType, Action<AsyncOperationHandle> callback, bool releaseDependenciesOnFailure = true /* Metadata: 0x006A7E0B */); // 0x0000000182055340-0x0000000182055B70
		public AsyncOperationHandle<IList<TObject>> ProvideResources<TObject>(IList<IResourceLocation> locations, Action<TObject> callback = null);
		public AsyncOperationHandle<IList<TObject>> ProvideResources<TObject>(IList<IResourceLocation> locations, bool releaseDependenciesOnFailure, Action<TObject> callback = null);
		public AsyncOperationHandle<TObject> CreateChainOperation<TObject, TObjectDependency>(AsyncOperationHandle<TObjectDependency> dependentOp, Func<AsyncOperationHandle<TObjectDependency>, AsyncOperationHandle<TObject>> callback);
		public AsyncOperationHandle<TObject> CreateChainOperation<TObject>(AsyncOperationHandle dependentOp, Func<AsyncOperationHandle, AsyncOperationHandle<TObject>> callback);
		public AsyncOperationHandle<TObject> CreateChainOperation<TObject, TObjectDependency>(AsyncOperationHandle<TObjectDependency> dependentOp, Func<AsyncOperationHandle<TObjectDependency>, AsyncOperationHandle<TObject>> callback, bool releaseDependenciesOnFailure = true /* Metadata: 0x006A7E0C */);
		public AsyncOperationHandle<TObject> CreateChainOperation<TObject>(AsyncOperationHandle dependentOp, Func<AsyncOperationHandle, AsyncOperationHandle<TObject>> callback, bool releaseDependenciesOnFailure = true /* Metadata: 0x006A7E0D */);
		public AsyncOperationHandle<SceneInstance> ProvideScene(ISceneProvider sceneProvider, IResourceLocation location, LoadSceneMode loadSceneMode, bool activateOnLoad, int priority); // 0x00000001820565F0-0x0000000182056720
		public AsyncOperationHandle<SceneInstance> ProvideScene(ISceneProvider sceneProvider, IResourceLocation location, LoadSceneParameters loadSceneParameters, bool activateOnLoad, int priority); // 0x00000001820564E0-0x00000001820565F0
		public AsyncOperationHandle<SceneInstance> ProvideScene(ISceneProvider sceneProvider, IResourceLocation location, LoadSceneParameters loadSceneParameters, SceneReleaseMode releaseMode, bool activateOnLoad, int priority); // 0x00000001820563D0-0x00000001820564E0
		public AsyncOperationHandle<SceneInstance> ReleaseScene(ISceneProvider sceneProvider, AsyncOperationHandle<SceneInstance> sceneLoadHandle); // 0x0000000182056AE0-0x0000000182056C40
		public AsyncOperationHandle<GameObject> ProvideInstance(IInstanceProvider provider, IResourceLocation location, InstantiationParameters instantiateParameters); // 0x0000000182055050-0x0000000182055340
		public void CleanupSceneInstances(Scene scene); // 0x0000000182053DA0-0x00000001820540A0
		private void ExecuteDeferredCallbacks(); // 0x00000001820545E0-0x00000001820547D0
		internal void RegisterForDeferredCallback(IAsyncOperation op, bool incrementRefCount = true /* Metadata: 0x006A7E0E */); // 0x0000000182056870-0x0000000182056AE0
		internal void Update(float unscaledDeltaTime); // 0x00000001820570D0-0x0000000182057470
		public void Dispose(); // 0x0000000182054470-0x00000001820545E0
		[CompilerGenerated]
		private void _.ctor_b__53_0(IUpdateReceiver x); // 0x00000001820570C0-0x00000001820570D0
	}
}
