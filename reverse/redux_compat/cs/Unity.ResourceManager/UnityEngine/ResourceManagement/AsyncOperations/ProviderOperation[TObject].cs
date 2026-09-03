/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.ResourceManagement.Util;
using UnityEngine.Scripting;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.AsyncOperations
{
	[Preserve]
	internal class ProviderOperation<TObject> : AsyncOperationBase<TObject>, IGenericProviderOperation, ICachable // TypeDefIndex: 13802
	{
		// Fields
		private bool m_ReleaseDependenciesOnFailure;
		private Func<float> m_GetProgressCallback;
		private Func<DownloadStatus> m_GetDownloadProgressCallback;
		private Func<bool> m_WaitForCompletionCallback;
		private bool m_ProviderCompletedCalled;
		private DownloadStatus m_DownloadStatus;
		private IResourceProvider m_Provider;
		internal AsyncOperationHandle<IList<AsyncOperationHandle>> m_DepOp;
		private IResourceLocation m_Location;
		private int m_ProvideHandleVersion;
		private bool m_NeedsRelease;
		[CompilerGenerated]
		private IOperationCacheKey _UnityEngine_ResourceManagement_AsyncOperations_ICachable_Key_k__BackingField;
		private ResourceManager m_ResourceManager;
		private const float k_OperationWaitingToCompletePercentComplete = 0.99f; // Metadata: 0x006A7E97
		internal const string kInvalidHandleMsg = "The ProvideHandle is invalid. After the handle has been completed, it can no longer be used"; // Metadata: 0x006A7E9B
	
		// Properties
		IOperationCacheKey ICachable.Key { [CompilerGenerated] get; [CompilerGenerated] set; }
		public int ProvideHandleVersion { get; }
		public IResourceLocation Location { get; }
		protected override string DebugName { get; }
		public Type RequestedType { get; }
		public int DependencyCount { get; }
		protected override float Progress { get; }
	
		// Constructors
		public ProviderOperation();
	
		// Methods
		public void SetDownloadProgressCallback(Func<DownloadStatus> callback);
		public void SetWaitForCompletionCallback(Func<bool> callback);
		protected override bool InvokeWaitForCompletion();
		internal override DownloadStatus GetDownloadStatus(HashSet<object> visited);
		public override void GetDependencies(List<AsyncOperationHandle> deps);
		internal override void ReleaseDependencies();
		public void GetDependencies(IList<object> dstList);
		public TDepObject GetDependency<TDepObject>(int index);
		public void SetProgressCallback(Func<float> callback);
		public void ProviderCompleted<T>(T result, bool status, Exception e);
		protected override void Execute();
		public void Init(ResourceManager rm, IResourceProvider provider, IResourceLocation location, AsyncOperationHandle<IList<AsyncOperationHandle>> depOp);
		public void Init(ResourceManager rm, IResourceProvider provider, IResourceLocation location, AsyncOperationHandle<IList<AsyncOperationHandle>> depOp, bool releaseDependenciesOnFailure);
		private bool WaitForCompletionHandler();
		protected override void Destroy();
	}
}
