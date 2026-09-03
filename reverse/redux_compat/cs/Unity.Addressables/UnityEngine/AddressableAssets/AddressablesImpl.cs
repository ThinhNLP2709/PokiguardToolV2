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
using UnityEngine.ResourceManagement.Util;
using UnityEngine.SceneManagement;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets
{
	internal class AddressablesImpl : IEqualityComparer<IResourceLocation> // TypeDefIndex: 14034
	{
		// Fields
		private ResourceManager m_ResourceManager; // 0x10
		private IInstanceProvider m_InstanceProvider; // 0x18
		private int m_CatalogRequestsTimeout; // 0x20
		internal const string kCacheDataFolder = "{UnityEngine.Application.persistentDataPath}/com.unity.addressables/"; // Metadata: 0x006A94E7
		public ISceneProvider SceneProvider; // 0x28
		internal List<ResourceLocatorInfo> m_ResourceLocators; // 0x30
		private AsyncOperationHandle<IResourceLocator> m_InitializationOperation; // 0x38
		private AsyncOperationHandle<List<string>> m_ActiveCheckUpdateOperation; // 0x50
		internal AsyncOperationHandle<List<IResourceLocator>> m_ActiveUpdateOperation; // 0x68
		private Action<AsyncOperationHandle> m_OnHandleCompleteAction; // 0x80
		private Action<AsyncOperationHandle> m_OnSceneHandleCompleteAction; // 0x88
		private Action<AsyncOperationHandle> m_OnHandleDestroyedAction; // 0x90
		private Dictionary<object, AsyncOperationHandle> m_resultToHandle; // 0x98
		internal HashSet<AsyncOperationHandle> m_SceneInstances; // 0xA0
		private AsyncOperationHandle<bool> m_ActiveCleanBundleCacheOperation; // 0xA8
		internal bool hasStartedInitialization; // 0xC0
	
		// Properties
		public IInstanceProvider InstanceProvider { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x0000000181C6E7B0-0x0000000181C6E830
		public ResourceManager ResourceManager { get; } // 0x0000000180377550-0x0000000180377560 
		public int CatalogRequestsTimeout { get; set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		internal int ActiveSceneInstances { get; } // 0x0000000181C6DF60-0x0000000181C6DF80 
		internal int TrackedHandleCount { get; } // 0x000000018188A540-0x000000018188A570 
		public Func<IResourceLocation, string> InternalIdTransformFunc { get; set; } // 0x0000000180FB1BE0-0x0000000180FB1C00 0x0000000181C6E830-0x0000000181C6E860
		public Action<UnityWebRequest> WebRequestOverride { get; set; } // 0x00000001814C98E0-0x00000001814C9900 0x0000000181C6E860-0x0000000181C6E890
		public AsyncOperationHandle ChainOperation { get; } // 0x0000000181C6E360-0x0000000181C6E540 
		internal bool ShouldChainRequest { get; } // 0x0000000181C6E6E0-0x0000000181C6E780 
		public static string StreamingAssetsSubFolder { get; } // 0x0000000181C6E780-0x0000000181C6E7B0 
		public static string BuildPath { get; } // 0x0000000181C6DF80-0x0000000181C6E1C0 
		public static string PlayerBuildDataPath { get; } // 0x0000000181C6E540-0x0000000181C6E5D0 
		public static string RuntimePath { get; } // 0x0000000181C6E6D0-0x0000000181C6E6E0 
		public IEnumerable<IResourceLocator> ResourceLocators { get; } // 0x0000000181C6E5D0-0x0000000181C6E6D0 
		internal IEnumerable<string> CatalogsWithAvailableUpdates { get; } // 0x0000000181C6E1C0-0x0000000181C6E360 
	
		// Nested types
		private class LoadResourceLocationKeyOp : AsyncOperationBase<IList<IResourceLocation>> // TypeDefIndex: 14035
		{
			// Fields
			private object m_Keys; // 0x98
			private IList<IResourceLocation> m_locations; // 0xA0
			private AddressablesImpl m_Addressables; // 0xA8
			private Type m_ResourceType; // 0xB0
	
			// Properties
			protected override string DebugName { get; } // 0x0000000181C7DFA0-0x0000000181C7DFD0 
	
			// Constructors
			public LoadResourceLocationKeyOp(); // 0x0000000181C7DF60-0x0000000181C7DFA0
	
			// Methods
			public void Init(AddressablesImpl aa, Type t, object keys); // 0x0000000181C7DEF0-0x0000000181C7DF60
			protected override bool InvokeWaitForCompletion(); // 0x0000000180DB12F0-0x0000000180DB1340
			protected override void Execute(); // 0x0000000181C7DDF0-0x0000000181C7DEF0
		}
	
		private class LoadResourceLocationKeysOp : AsyncOperationBase<IList<IResourceLocation>> // TypeDefIndex: 14036
		{
			// Fields
			private IEnumerable m_Key; // 0x98
			private Addressables.MergeMode m_MergeMode; // 0xA0
			private IList<IResourceLocation> m_locations; // 0xA8
			private AddressablesImpl m_Addressables; // 0xB0
			private Type m_ResourceType; // 0xB8
	
			// Properties
			protected override string DebugName { get; } // 0x0000000181C7E190-0x0000000181C7E1C0 
	
			// Constructors
			public LoadResourceLocationKeysOp(); // 0x0000000181C7E150-0x0000000181C7E190
	
			// Methods
			public void Init(AddressablesImpl aa, Type t, IEnumerable key, Addressables.MergeMode mergeMode); // 0x0000000181C7E0D0-0x0000000181C7E150
			protected override void Execute(); // 0x0000000181C7DFD0-0x0000000181C7E0D0
			protected override bool InvokeWaitForCompletion(); // 0x0000000180DB12F0-0x0000000180DB1340
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14037
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<ResourceLocatorInfo, IResourceLocator> __9__59_0; // 0x08
			public static Func<ResourceLocatorInfo, bool> __9__142_0; // 0x10
			public static Func<ResourceLocatorInfo, string> __9__142_1; // 0x18
			public static Func<ResourceLocatorInfo, string> __9__146_0; // 0x20
	
			// Constructors
			static __c(); // 0x0000000181C83FC0-0x0000000181C84030
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal IResourceLocator _get_ResourceLocators_b__59_0(ResourceLocatorInfo l); // 0x000000018052BA80-0x000000018052BAA0
			internal bool _get_CatalogsWithAvailableUpdates_b__142_0(ResourceLocatorInfo s); // 0x0000000181C831D0-0x0000000181C831F0
			internal string _get_CatalogsWithAvailableUpdates_b__142_1(ResourceLocatorInfo s); // 0x0000000181C831F0-0x0000000181C83240
			internal string _CleanBundleCache_b__146_0(ResourceLocatorInfo s); // 0x0000000181C830E0-0x0000000181C83130
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__114<TObject> // TypeDefIndex: 14038
		{
			// Fields
			public static readonly __c__114<TObject> __9;
			public static Action<AsyncOperationHandle> __9__114_0;
	
			// Constructors
			static __c__114();
			public __c__114();
	
			// Methods
			internal void _AutoReleaseHandleOnTypelessCompletion_b__114_0(AsyncOperationHandle op);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass102_0 // TypeDefIndex: 14039
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public IEnumerable keys; // 0x18
	
			// Constructors
			public __c__DisplayClass102_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<long> _GetDownloadSizeWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C83240-0x0000000181C83290
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass105_0 // TypeDefIndex: 14040
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public object key; // 0x18
	
			// Constructors
			public __c__DisplayClass105_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<IList<IAssetBundleResource>> _DownloadDependenciesAsyncWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C83290-0x0000000181C83340
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass109_0 // TypeDefIndex: 14041
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public IList<IResourceLocation> locations; // 0x18
	
			// Constructors
			public __c__DisplayClass109_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<IList<IAssetBundleResource>> _DownloadDependenciesAsyncWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C83340-0x0000000181C833F0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass111_0 // TypeDefIndex: 14042
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public IEnumerable keys; // 0x18
			public Addressables.MergeMode mode; // 0x20
	
			// Constructors
			public __c__DisplayClass111_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<IList<IAssetBundleResource>> _DownloadDependenciesAsyncWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C833F0-0x0000000181C834A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass115_0 // TypeDefIndex: 14043
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public object key; // 0x18
			public bool autoReleaseHandle; // 0x20
	
			// Constructors
			public __c__DisplayClass115_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<bool> _ClearDependencyCacheAsync_b__0(AsyncOperationHandle op); // 0x0000000181C834A0-0x0000000181C834F0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass116_0 // TypeDefIndex: 14044
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public IList<IResourceLocation> locations; // 0x18
			public bool autoReleaseHandle; // 0x20
	
			// Constructors
			public __c__DisplayClass116_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<bool> _ClearDependencyCacheAsync_b__0(AsyncOperationHandle op); // 0x0000000181C834F0-0x0000000181C83540
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass117_0 // TypeDefIndex: 14045
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public IEnumerable keys; // 0x18
			public bool autoReleaseHandle; // 0x20
	
			// Constructors
			public __c__DisplayClass117_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<bool> _ClearDependencyCacheAsync_b__0(AsyncOperationHandle op); // 0x0000000181C83540-0x0000000181C83590
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass122_0 // TypeDefIndex: 14046
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public object key; // 0x18
			public InstantiationParameters instantiateParameters; // 0x20
	
			// Constructors
			public __c__DisplayClass122_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<GameObject> _InstantiateWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C836F0-0x0000000181C83770
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass124_0 // TypeDefIndex: 14047
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public IResourceLocation location; // 0x18
			public InstantiationParameters instantiateParameters; // 0x20
	
			// Constructors
			public __c__DisplayClass124_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<GameObject> _InstantiateWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C83770-0x0000000181C837F0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass127_0 // TypeDefIndex: 14048
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public object key; // 0x18
			public LoadSceneParameters loadSceneParameters; // 0x20
			public SceneReleaseMode releaseMode; // 0x28
			public bool activateOnLoad; // 0x2C
			public int priority; // 0x30
	
			// Constructors
			public __c__DisplayClass127_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<SceneInstance> _LoadSceneWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C837F0-0x0000000181C83860
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass128_0 // TypeDefIndex: 14049
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public IResourceLocation key; // 0x18
			public LoadSceneParameters loadSceneParameters; // 0x20
			public SceneReleaseMode releaseMode; // 0x28
			public bool activateOnLoad; // 0x2C
			public int priority; // 0x30
	
			// Constructors
			public __c__DisplayClass128_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<SceneInstance> _LoadSceneWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C83860-0x0000000181C838D0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass134_0 // TypeDefIndex: 14050
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public UnloadSceneOptions unloadOptions; // 0x18
			public bool autoReleaseHandle; // 0x1C
	
			// Constructors
			public __c__DisplayClass134_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<SceneInstance> _CreateUnloadSceneWithChain_b__0(AsyncOperationHandle completedHandle); // 0x0000000181C838D0-0x0000000181C83A10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass135_0 // TypeDefIndex: 14051
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public UnloadSceneOptions unloadOptions; // 0x18
			public bool autoReleaseHandle; // 0x1C
	
			// Constructors
			public __c__DisplayClass135_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<SceneInstance> _CreateUnloadSceneWithChain_b__0(AsyncOperationHandle<SceneInstance> completedHandle); // 0x0000000181C83A10-0x0000000181C83B10
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass139_0 // TypeDefIndex: 14052
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public bool autoReleaseHandle; // 0x18
	
			// Constructors
			public __c__DisplayClass139_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<List<string>> _CheckForCatalogUpdatesWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C83B10-0x0000000181C83B60
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass143_0 // TypeDefIndex: 14053
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public bool autoReleaseHandle; // 0x18
			public bool autoCleanBundleCache; // 0x19
	
			// Constructors
			public __c__DisplayClass143_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<List<IResourceLocator>> _UpdateCatalogs_b__0(AsyncOperationHandle<List<string>> depOp); // 0x0000000181C83B60-0x0000000181C83BE0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass148_0 // TypeDefIndex: 14054
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public AsyncOperationHandle<IList<AsyncOperationHandle>> depOp; // 0x18
			public bool forceSingleThreading; // 0x30
	
			// Constructors
			public __c__DisplayClass148_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<bool> _CleanBundleCacheWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C83BE0-0x0000000181C83C50
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass149_0 // TypeDefIndex: 14055
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public IEnumerable<string> catalogIds; // 0x18
			public bool forceSingleThreading; // 0x20
	
			// Constructors
			public __c__DisplayClass149_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<bool> _CleanBundleCacheWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C83C50-0x0000000181C83CA0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass61_0 // TypeDefIndex: 14056
		{
			// Fields
			public IResourceLocator loc; // 0x10
	
			// Constructors
			public __c__DisplayClass61_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _RemoveResourceLocator_b__0(ResourceLocatorInfo l); // 0x0000000181C83CD0-0x0000000181C83CF0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass72_0 // TypeDefIndex: 14057
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public string catalogPath; // 0x18
			public bool autoReleaseHandle; // 0x20
			public string providerSuffix; // 0x28
	
			// Constructors
			public __c__DisplayClass72_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<IResourceLocator> _LoadContentCatalogAsync_b__0(AsyncOperationHandle op); // 0x0000000181C83CF0-0x0000000181C83D50
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass78_0<TObject> // TypeDefIndex: 14058
		{
			// Fields
			public AddressablesImpl __4__this;
			public IResourceLocation loc;
	
			// Constructors
			public __c__DisplayClass78_0();
	
			// Methods
			internal AsyncOperationHandle<TObject> _LoadAssetWithChain_b__0(AsyncOperationHandle op);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass79_0<TObject> // TypeDefIndex: 14059
		{
			// Fields
			public AddressablesImpl __4__this;
			public object key;
	
			// Constructors
			public __c__DisplayClass79_0();
	
			// Methods
			internal AsyncOperationHandle<TObject> _LoadAssetWithChain_b__0(AsyncOperationHandle op);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass83_0 // TypeDefIndex: 14060
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public IEnumerable keys; // 0x18
			public Addressables.MergeMode mode; // 0x20
			public Type type; // 0x28
	
			// Constructors
			public __c__DisplayClass83_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<IList<IResourceLocation>> _LoadResourceLocationsWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C83D50-0x0000000181C83DB0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass85_0 // TypeDefIndex: 14061
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public object key; // 0x18
			public Type type; // 0x20
	
			// Constructors
			public __c__DisplayClass85_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<IList<IResourceLocation>> _LoadResourceLocationsWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C83DB0-0x0000000181C83E00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass88_0<TObject> // TypeDefIndex: 14062
		{
			// Fields
			public AddressablesImpl __4__this;
			public IList<IResourceLocation> locations;
			public Action<TObject> callback;
			public bool releaseDependenciesOnFailure;
	
			// Constructors
			public __c__DisplayClass88_0();
	
			// Methods
			internal AsyncOperationHandle<IList<TObject>> _LoadAssetsWithChain_b__0(AsyncOperationHandle op);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass89_0<TObject> // TypeDefIndex: 14063
		{
			// Fields
			public AddressablesImpl __4__this;
			public IEnumerable keys;
			public Action<TObject> callback;
			public Addressables.MergeMode mode;
			public bool releaseDependenciesOnFailure;
	
			// Constructors
			public __c__DisplayClass89_0();
	
			// Methods
			internal AsyncOperationHandle<IList<TObject>> _LoadAssetsWithChain_b__0(AsyncOperationHandle op);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass91_0<TObject> // TypeDefIndex: 14064
		{
			// Fields
			public AddressablesImpl __4__this;
			public object key;
			public Action<TObject> callback;
			public bool releaseDependenciesOnFailure;
	
			// Constructors
			public __c__DisplayClass91_0();
	
			// Methods
			internal AsyncOperationHandle<IList<TObject>> _LoadAssetsWithChain_b__0(AsyncOperationHandle op2);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass99_0 // TypeDefIndex: 14065
		{
			// Fields
			public AddressablesImpl __4__this; // 0x10
			public IResourceLocation catalogLoc; // 0x18
	
			// Constructors
			public __c__DisplayClass99_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AsyncOperationHandle<long> _ComputeCatalogSizeWithChain_b__0(AsyncOperationHandle op); // 0x0000000181C83E00-0x0000000181C83FC0
		}
	
		// Constructors
		public AddressablesImpl(IAllocationStrategy alloc); // 0x0000000181C6DDA0-0x0000000181C6DF60
	
		// Methods
		internal void ReleaseSceneManagerOperation(); // 0x0000000181C6CF20-0x0000000181C6CFB0
		internal void OnSceneUnloaded(Scene scene); // 0x0000000181C6CA20-0x0000000181C6CE10
		public static void Log(string msg); // 0x0000000181C6C7B0-0x0000000181C6C800
		public static void LogFormat(string format, params object[] args); // 0x0000000181C6C6A0-0x0000000181C6C700
		public static void LogWarning(string msg); // 0x0000000181C6C760-0x0000000181C6C7B0
		public static void LogWarningFormat(string format, params object[] args); // 0x0000000181C6C700-0x0000000181C6C760
		public static void LogError(string msg); // 0x0000000181C6C5C0-0x0000000181C6C610
		public static void LogException(AsyncOperationHandle op, Exception ex); // 0x0000000181C6C610-0x0000000181C6C6A0
		public static void LogException(Exception ex); // 0x00000001802E76C0-0x00000001802E76D0
		public static void LogErrorFormat(string format, params object[] args); // 0x0000000181C6C560-0x0000000181C6C5C0
		public static string ResolveInternalId(string id); // 0x0000000181C6D0C0-0x0000000181C6D260
		public void AddResourceLocator(IResourceLocator loc, string localCatalogHash = null, IResourceLocation remoteCatalogLocation = null); // 0x0000000181C640C0-0x0000000181C641E0
		public void RemoveResourceLocator(IResourceLocator loc); // 0x0000000181C6CFF0-0x0000000181C6D0C0
		public void ClearResourceLocators(); // 0x0000000181C663C0-0x0000000181C66400
		internal bool GetResourceLocations(object key, Type type, out IList<IResourceLocation> locations); // 0x0000000181C69040-0x0000000181C69570
		internal bool GetResourceLocations(IEnumerable keys, Type type, Addressables.MergeMode merge, out IList<IResourceLocation> locations); // 0x0000000181C69570-0x0000000181C698E0
		public AsyncOperationHandle<IResourceLocator> InitializeAsync(string runtimeDataPath, string providerSuffix = null, bool autoReleaseHandle = true /* Metadata: 0x006A94BD */); // 0x0000000181C69A10-0x0000000181C69E80
		public AsyncOperationHandle<IResourceLocator> InitializeAsync(); // 0x0000000181C698E0-0x0000000181C69970
		public AsyncOperationHandle<IResourceLocator> InitializeAsync(bool autoReleaseHandle); // 0x0000000181C69970-0x0000000181C69A10
		public ResourceLocationBase CreateCatalogLocationWithHashDependencies<T>(IResourceLocation catalogLocation)
			where T : IResourceProvider;
		public ResourceLocationBase CreateCatalogLocationWithHashDependencies<T>(string catalogLocation)
			where T : IResourceProvider;
		public ResourceLocationBase CreateCatalogLocationWithHashDependencies<T>(string catalogPath, string hashFilePath)
			where T : IResourceProvider;
		[Conditional("UNITY_EDITOR")]
		private void QueueEditorUpdateIfNeeded(); // 0x00000001802E76C0-0x00000001802E76D0
		public AsyncOperationHandle<IResourceLocator> LoadContentCatalogAsync(string catalogPath, bool autoReleaseHandle = true /* Metadata: 0x006A94BE */, string providerSuffix = null); // 0x0000000181C6B050-0x0000000181C6B270
		private AsyncOperationHandle<SceneInstance> TrackHandle(AsyncOperationHandle<SceneInstance> handle); // 0x0000000181C6D2A0-0x0000000181C6D350
		private AsyncOperationHandle<TObject> TrackHandle<TObject>(AsyncOperationHandle<TObject> handle);
		private AsyncOperationHandle TrackHandle(AsyncOperationHandle handle); // 0x0000000181C6D260-0x0000000181C6D2A0
		internal void ClearTrackHandles(); // 0x0000000181C66400-0x0000000181C66430
		public AsyncOperationHandle<TObject> LoadAssetAsync<TObject>(IResourceLocation location);
		private AsyncOperationHandle<TObject> LoadAssetWithChain<TObject>(AsyncOperationHandle dep, IResourceLocation loc);
		private AsyncOperationHandle<TObject> LoadAssetWithChain<TObject>(AsyncOperationHandle dep, object key);
		public AsyncOperationHandle<TObject> LoadAssetAsync<TObject>(object key);
		public AsyncOperationHandle<IList<IResourceLocation>> LoadResourceLocationsWithChain(AsyncOperationHandle dep, IEnumerable keys, Addressables.MergeMode mode, Type type); // 0x0000000181C6B9B0-0x0000000181C6BB10
		public AsyncOperationHandle<IList<IResourceLocation>> LoadResourceLocationsAsync(IEnumerable keys, Addressables.MergeMode mode, Type type = null); // 0x0000000181C6B270-0x0000000181C6B560
		public AsyncOperationHandle<IList<IResourceLocation>> LoadResourceLocationsWithChain(AsyncOperationHandle dep, object key, Type type); // 0x0000000181C6B850-0x0000000181C6B9B0
		public AsyncOperationHandle<IList<IResourceLocation>> LoadResourceLocationsAsync(object key, Type type = null); // 0x0000000181C6B560-0x0000000181C6B850
		public AsyncOperationHandle<IList<TObject>> LoadAssetsAsync<TObject>(IList<IResourceLocation> locations, Action<TObject> callback, bool releaseDependenciesOnFailure);
		private AsyncOperationHandle<IList<TObject>> LoadAssetsWithChain<TObject>(AsyncOperationHandle dep, IList<IResourceLocation> locations, Action<TObject> callback, bool releaseDependenciesOnFailure);
		private AsyncOperationHandle<IList<TObject>> LoadAssetsWithChain<TObject>(AsyncOperationHandle dep, IEnumerable keys, Action<TObject> callback, Addressables.MergeMode mode, bool releaseDependenciesOnFailure);
		public AsyncOperationHandle<IList<TObject>> LoadAssetsAsync<TObject>(IEnumerable keys, Action<TObject> callback, Addressables.MergeMode mode, bool releaseDependenciesOnFailure);
		private AsyncOperationHandle<IList<TObject>> LoadAssetsWithChain<TObject>(AsyncOperationHandle dep, object key, Action<TObject> callback, bool releaseDependenciesOnFailure);
		public AsyncOperationHandle<IList<TObject>> LoadAssetsAsync<TObject>(object key, Action<TObject> callback, bool releaseDependenciesOnFailure);
		private void OnHandleDestroyed(AsyncOperationHandle handle); // 0x0000000181C6C8B0-0x0000000181C6C930
		private void OnSceneHandleCompleted(AsyncOperationHandle handle); // 0x0000000181C6C930-0x0000000181C6CA20
		private void OnHandleCompleted(AsyncOperationHandle handle); // 0x0000000181C6C800-0x0000000181C6C8B0
		public void Release<TObject>(TObject obj);
		public void Release<TObject>(AsyncOperationHandle<TObject> handle);
		public void Release(AsyncOperationHandle handle); // 0x0000000181C6CFB0-0x0000000181C6CFF0
		private AsyncOperationHandle<long> ComputeCatalogSizeWithChain(IResourceLocation catalogLoc); // 0x0000000181C66430-0x0000000181C666B0
		internal bool IsCatalogCached(IResourceLocation catalogLoc, Hash128 remoteHash); // 0x0000000181C6AEA0-0x0000000181C6B050
		internal AsyncOperationHandle<long> GetRemoteCatalogHeaderSize(IResourceLocation catalogLoc); // 0x0000000181C68D50-0x0000000181C69040
		private AsyncOperationHandle<long> GetDownloadSizeWithChain(AsyncOperationHandle dep, IEnumerable keys); // 0x0000000181C68A10-0x0000000181C68B50
		public AsyncOperationHandle<long> GetDownloadSizeAsync(object key); // 0x0000000181C67FB0-0x0000000181C68090
		public AsyncOperationHandle<long> GetDownloadSizeAsync(IEnumerable keys); // 0x0000000181C68090-0x0000000181C68A10
		private AsyncOperationHandle DownloadDependenciesAsyncWithChain(AsyncOperationHandle dep, object key, bool autoReleaseHandle); // 0x0000000181C66CD0-0x0000000181C66EA0
		internal static void WrapAsDownloadLocations(List<IResourceLocation> locations); // 0x0000000181C6DCF0-0x0000000181C6DDA0
		private static List<IResourceLocation> GatherDependenciesFromLocations(IList<IResourceLocation> locations); // 0x0000000181C67B10-0x0000000181C67FB0
		public AsyncOperationHandle DownloadDependenciesAsync(object key, bool autoReleaseHandle = false /* Metadata: 0x006A94BF */); // 0x0000000181C67130-0x0000000181C67510
		private AsyncOperationHandle DownloadDependenciesAsyncWithChain(AsyncOperationHandle dep, IList<IResourceLocation> locations, bool autoReleaseHandle); // 0x0000000181C66B00-0x0000000181C66CD0
		public AsyncOperationHandle DownloadDependenciesAsync(IList<IResourceLocation> locations, bool autoReleaseHandle = false /* Metadata: 0x006A94C0 */); // 0x0000000181C66EA0-0x0000000181C67130
		private AsyncOperationHandle DownloadDependenciesAsyncWithChain(AsyncOperationHandle dep, IEnumerable keys, Addressables.MergeMode mode, bool autoReleaseHandle); // 0x0000000181C66930-0x0000000181C66B00
		public AsyncOperationHandle DownloadDependenciesAsync(IEnumerable keys, Addressables.MergeMode mode, bool autoReleaseHandle = false /* Metadata: 0x006A94C1 */); // 0x0000000181C67510-0x0000000181C67940
		internal bool ClearDependencyCacheForKey(object key); // 0x0000000181C65D90-0x0000000181C663C0
		internal void AutoReleaseHandleOnTypelessCompletion<TObject>(AsyncOperationHandle<TObject> handle);
		public AsyncOperationHandle<bool> ClearDependencyCacheAsync(object key, bool autoReleaseHandle); // 0x0000000181C65B10-0x0000000181C65D90
		public AsyncOperationHandle<bool> ClearDependencyCacheAsync(IList<IResourceLocation> locations, bool autoReleaseHandle); // 0x0000000181C65200-0x0000000181C65670
		public AsyncOperationHandle<bool> ClearDependencyCacheAsync(IEnumerable keys, bool autoReleaseHandle); // 0x0000000181C65670-0x0000000181C65B10
		public AsyncOperationHandle<GameObject> InstantiateAsync(IResourceLocation location, Transform parent = null, bool instantiateInWorldSpace = false /* Metadata: 0x006A94C2 */, bool trackHandle = true /* Metadata: 0x006A94C3 */); // 0x0000000181C6A9B0-0x0000000181C6AA80
		public AsyncOperationHandle<GameObject> InstantiateAsync(IResourceLocation location, Vector3 position, Quaternion rotation, Transform parent = null, bool trackHandle = true /* Metadata: 0x006A94C4 */); // 0x0000000181C69E80-0x0000000181C69F80
		public AsyncOperationHandle<GameObject> InstantiateAsync(object key, Transform parent = null, bool instantiateInWorldSpace = false /* Metadata: 0x006A94C5 */, bool trackHandle = true /* Metadata: 0x006A94C6 */); // 0x0000000181C6A250-0x0000000181C6A320
		public AsyncOperationHandle<GameObject> InstantiateAsync(object key, Vector3 position, Quaternion rotation, Transform parent = null, bool trackHandle = true /* Metadata: 0x006A94C7 */); // 0x0000000181C6A320-0x0000000181C6A420
		private AsyncOperationHandle<GameObject> InstantiateWithChain(AsyncOperationHandle dep, object key, InstantiationParameters instantiateParameters, bool trackHandle = true /* Metadata: 0x006A94C8 */); // 0x0000000181C6AA80-0x0000000181C6AC30
		public AsyncOperationHandle<GameObject> InstantiateAsync(object key, InstantiationParameters instantiateParameters, bool trackHandle = true /* Metadata: 0x006A94C9 */); // 0x0000000181C6A420-0x0000000181C6A9B0
		private AsyncOperationHandle<GameObject> InstantiateWithChain(AsyncOperationHandle dep, IResourceLocation location, InstantiationParameters instantiateParameters, bool trackHandle = true /* Metadata: 0x006A94CA */); // 0x0000000181C6AC30-0x0000000181C6ADE0
		public AsyncOperationHandle<GameObject> InstantiateAsync(IResourceLocation location, InstantiationParameters instantiateParameters, bool trackHandle = true /* Metadata: 0x006A94CB */); // 0x0000000181C69F80-0x0000000181C6A250
		public bool ReleaseInstance(GameObject instance); // 0x0000000181C6CE10-0x0000000181C6CF20
		internal AsyncOperationHandle<SceneInstance> LoadSceneWithChain(AsyncOperationHandle dep, object key, LoadSceneParameters loadSceneParameters, SceneReleaseMode releaseMode = SceneReleaseMode.ReleaseSceneWhenSceneUnloaded /* Metadata: 0x006A94CC */, bool activateOnLoad = true /* Metadata: 0x006A94CD */, int priority = 100 /* Metadata: 0x006A94CE */); // 0x0000000181C6C360-0x0000000181C6C560
		internal AsyncOperationHandle<SceneInstance> LoadSceneWithChain(AsyncOperationHandle dep, IResourceLocation key, LoadSceneParameters loadSceneParameters, SceneReleaseMode releaseMode = SceneReleaseMode.ReleaseSceneWhenSceneUnloaded /* Metadata: 0x006A94D0 */, bool activateOnLoad = true /* Metadata: 0x006A94D1 */, int priority = 100 /* Metadata: 0x006A94D2 */); // 0x0000000181C6C160-0x0000000181C6C360
		public AsyncOperationHandle<SceneInstance> LoadSceneAsync(object key, LoadSceneParameters loadSceneParameters, SceneReleaseMode releaseMode = SceneReleaseMode.ReleaseSceneWhenSceneUnloaded /* Metadata: 0x006A94D4 */, bool activateOnLoad = true /* Metadata: 0x006A94D5 */, int priority = 100 /* Metadata: 0x006A94D6 */, bool trackHandle = true /* Metadata: 0x006A94D8 */); // 0x0000000181C6BDA0-0x0000000181C6C160
		public AsyncOperationHandle<SceneInstance> LoadSceneAsync(IResourceLocation location, LoadSceneParameters loadSceneParameters, SceneReleaseMode releaseMode = SceneReleaseMode.ReleaseSceneWhenSceneUnloaded /* Metadata: 0x006A94D9 */, bool activateOnLoad = true /* Metadata: 0x006A94DA */, int priority = 100 /* Metadata: 0x006A94DB */, bool trackHandle = true /* Metadata: 0x006A94DD */); // 0x0000000181C6BB10-0x0000000181C6BDA0
		public AsyncOperationHandle<SceneInstance> UnloadSceneAsync(SceneInstance scene, UnloadSceneOptions unloadOptions = UnloadSceneOptions.None /* Metadata: 0x006A94DE */, bool autoReleaseHandle = true /* Metadata: 0x006A94DF */); // 0x0000000181C6D620-0x0000000181C6D840
		public AsyncOperationHandle<SceneInstance> UnloadSceneAsync(AsyncOperationHandle handle, UnloadSceneOptions unloadOptions = UnloadSceneOptions.None /* Metadata: 0x006A94E0 */, bool autoReleaseHandle = true /* Metadata: 0x006A94E1 */); // 0x0000000181C6D4F0-0x0000000181C6D620
		public AsyncOperationHandle<SceneInstance> UnloadSceneAsync(AsyncOperationHandle<SceneInstance> handle, UnloadSceneOptions unloadOptions = UnloadSceneOptions.None /* Metadata: 0x006A94E2 */, bool autoReleaseHandle = true /* Metadata: 0x006A94E3 */); // 0x0000000181C6D840-0x0000000181C6DA40
		internal AsyncOperationHandle<SceneInstance> CreateUnloadSceneWithChain(AsyncOperationHandle handle, UnloadSceneOptions unloadOptions, bool autoReleaseHandle); // 0x0000000181C667F0-0x0000000181C66930
		internal AsyncOperationHandle<SceneInstance> CreateUnloadSceneWithChain(AsyncOperationHandle<SceneInstance> handle, UnloadSceneOptions unloadOptions, bool autoReleaseHandle); // 0x0000000181C666B0-0x0000000181C667F0
		internal AsyncOperationHandle<SceneInstance> InternalUnloadScene(AsyncOperationHandle<SceneInstance> handle, UnloadSceneOptions unloadOptions, bool autoReleaseHandle); // 0x0000000181C6ADE0-0x0000000181C6AEA0
		private object EvaluateKey(object obj); // 0x0000000181C67A80-0x0000000181C67B10
		internal AsyncOperationHandle<List<string>> CheckForCatalogUpdates(bool autoReleaseHandle = true /* Metadata: 0x006A94E4 */); // 0x0000000181C64340-0x0000000181C645C0
		internal AsyncOperationHandle<List<string>> CheckForCatalogUpdatesWithChain(bool autoReleaseHandle); // 0x0000000181C641E0-0x0000000181C64340
		public ResourceLocatorInfo GetLocatorInfo(string c); // 0x0000000181C68C00-0x0000000181C68D50
		internal AsyncOperationHandle<List<IResourceLocator>> UpdateCatalogs(IEnumerable<string> catalogIds = null, bool autoReleaseHandle = true /* Metadata: 0x006A94E5 */, bool autoCleanBundleCache = false /* Metadata: 0x006A94E6 */); // 0x0000000181C6DA40-0x0000000181C6DCF0
		public bool Equals(IResourceLocation x, IResourceLocation y); // 0x0000000181C67940-0x0000000181C67A80
		public int GetHashCode(IResourceLocation loc); // 0x0000000181C68B50-0x0000000181C68C00
		internal AsyncOperationHandle<bool> CleanBundleCache(IEnumerable<string> catalogIds, bool forceSingleThreading); // 0x0000000181C64890-0x0000000181C64E00
		internal AsyncOperationHandle<bool> CleanBundleCache(AsyncOperationHandle<IList<AsyncOperationHandle>> depOp, bool forceSingleThreading); // 0x0000000181C64E00-0x0000000181C65200
		internal AsyncOperationHandle<bool> CleanBundleCacheWithChain(AsyncOperationHandle<IList<AsyncOperationHandle>> depOp, bool forceSingleThreading); // 0x0000000181C64720-0x0000000181C64890
		internal AsyncOperationHandle<bool> CleanBundleCacheWithChain(IEnumerable<string> catalogIds, bool forceSingleThreading); // 0x0000000181C645C0-0x0000000181C64720
		[CompilerGenerated]
		private void _TrackHandle_b__73_0(AsyncOperationHandle<SceneInstance> sceneHandle); // 0x0000000181C6D480-0x0000000181C6D4F0
		[CompilerGenerated]
		private AsyncOperationHandle<long> _GetRemoteCatalogHeaderSize_b__101_0(AsyncOperationHandle<UnityWebRequest> getOp); // 0x0000000181C6D350-0x0000000181C6D480
	}
}
