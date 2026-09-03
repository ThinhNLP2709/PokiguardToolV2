/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.SceneManagement;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	public class SceneProvider : ISceneProvider2 // TypeDefIndex: 13768
	{
		// Nested types
		private class SceneOp : AsyncOperationBase<SceneInstance>, IUpdateReceiver // TypeDefIndex: 13769
		{
			// Fields
			private bool m_ActivateOnLoad; // 0xA8
			private SceneInstance m_Inst; // 0xB0
			private IResourceLocation m_Location; // 0xC8
			private LoadSceneParameters m_LoadSceneParameters; // 0xD0
			private SceneReleaseMode m_ReleaseMode; // 0xD8
			private int m_Priority; // 0xDC
			private AsyncOperationHandle<IList<AsyncOperationHandle>> m_DepOp; // 0xE0
			private ResourceManager m_ResourceManager; // 0xF8
			private ISceneProvider2 m_provider; // 0x100
	
			// Properties
			protected override string DebugName { get; } // 0x0000000182059080-0x0000000182059170 
			protected override float Progress { get; } // 0x0000000182059170-0x0000000182059230 
	
			// Constructors
			public SceneOp(ResourceManager rm, ISceneProvider2 provider); // 0x0000000182059000-0x0000000182059080
	
			// Methods
			internal override DownloadStatus GetDownloadStatus(HashSet<object> visited); // 0x0000000182058770-0x0000000182058830
			public void Init(IResourceLocation location, LoadSceneMode loadSceneMode, bool activateOnLoad, int priority, AsyncOperationHandle<IList<AsyncOperationHandle>> depOp); // 0x0000000182058930-0x0000000182058A60
			public void Init(IResourceLocation location, LoadSceneParameters loadSceneParameters, SceneReleaseMode releaseMode, bool activateOnLoad, int priority, AsyncOperationHandle<IList<AsyncOperationHandle>> depOp); // 0x0000000182058830-0x0000000182058930
			protected override bool InvokeWaitForCompletion(); // 0x0000000182058C50-0x0000000182058EE0
			public override void GetDependencies(List<AsyncOperationHandle> deps); // 0x0000000182058650-0x0000000182058770
			protected override void Execute(); // 0x0000000182058070-0x0000000182058650
			internal SceneInstance InternalLoadScene(IResourceLocation location, bool loadingFromBundle, LoadSceneParameters loadSceneParameters, bool activateOnLoad, int priority); // 0x0000000182058A60-0x0000000182058BF0
			private AsyncOperation InternalLoad(string path, bool loadingFromBundle, LoadSceneParameters loadSceneParameters); // 0x0000000182058BF0-0x0000000182058C50
			protected override void Destroy(); // 0x0000000182057E80-0x0000000182058070
			void IUpdateReceiver.Update(float unscaledDeltaTime); // 0x0000000182058EE0-0x0000000182059000
		}
	
		private class UnloadSceneOp : AsyncOperationBase<SceneInstance> // TypeDefIndex: 13770
		{
			// Fields
			private SceneInstance m_Instance; // 0xA8
			private AsyncOperationHandle<SceneInstance> m_sceneLoadHandle; // 0xC0
			private UnloadSceneOptions m_UnloadOptions; // 0xD8
	
			// Properties
			protected override float Progress { get; } // 0x000000018205B9C0-0x000000018205BA00 
	
			// Constructors
			public UnloadSceneOp(); // 0x000000018205B980-0x000000018205B9C0
	
			// Methods
			public void Init(AsyncOperationHandle<SceneInstance> sceneLoadHandle, UnloadSceneOptions options); // 0x000000018205B750-0x000000018205B810
			protected override void Execute(); // 0x000000018205B640-0x000000018205B750
			protected override bool InvokeWaitForCompletion(); // 0x000000018205B810-0x000000018205B8B0
			private void UnloadSceneCompleted(AsyncOperation obj); // 0x000000018205B8B0-0x000000018205B980
		}
	
		// Constructors
		public SceneProvider(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public AsyncOperationHandle<SceneInstance> ProvideScene(ResourceManager resourceManager, IResourceLocation location, LoadSceneMode loadSceneMode, bool activateOnLoad, int priority); // 0x00000001820594A0-0x0000000182059550
		public AsyncOperationHandle<SceneInstance> ProvideScene(ResourceManager resourceManager, IResourceLocation location, LoadSceneParameters loadSceneParameters, bool activateOnLoad, int priority); // 0x0000000182059890-0x00000001820598F0
		public AsyncOperationHandle<SceneInstance> ProvideScene(ResourceManager resourceManager, IResourceLocation location, LoadSceneParameters loadSceneParameters, SceneReleaseMode releaseMode, bool activateOnLoad, int priority); // 0x0000000182059550-0x0000000182059890
		public AsyncOperationHandle<SceneInstance> ReleaseScene(ResourceManager resourceManager, AsyncOperationHandle<SceneInstance> sceneLoadHandle); // 0x00000001820598F0-0x0000000182059A00
		AsyncOperationHandle<SceneInstance> ISceneProvider2.ReleaseScene(ResourceManager resourceManager, AsyncOperationHandle<SceneInstance> sceneLoadHandle, UnloadSceneOptions unloadOptions); // 0x0000000182059A00-0x0000000182059BE0
	}
}
