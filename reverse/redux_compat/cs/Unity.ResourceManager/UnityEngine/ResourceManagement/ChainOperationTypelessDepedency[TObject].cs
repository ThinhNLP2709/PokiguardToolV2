/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement.AsyncOperations;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement
{
	internal class ChainOperationTypelessDepedency<TObject> : AsyncOperationBase<TObject> // TypeDefIndex: 13670
	{
		// Fields
		private AsyncOperationHandle m_DepOp;
		private AsyncOperationHandle<TObject> m_WrappedOp;
		private DownloadStatus m_depStatus;
		private DownloadStatus m_wrapStatus;
		private Func<AsyncOperationHandle, AsyncOperationHandle<TObject>> m_Callback;
		private Action<AsyncOperationHandle<TObject>> m_CachedOnWrappedCompleted;
		private bool m_ReleaseDependenciesOnFailure;
	
		// Properties
		internal AsyncOperationHandle<TObject> WrappedOp { get; }
		protected override string DebugName { get; }
		protected override float Progress { get; }
	
		// Constructors
		public ChainOperationTypelessDepedency();
	
		// Methods
		public override void GetDependencies(List<AsyncOperationHandle> deps);
		public void Init(AsyncOperationHandle dependentOp, Func<AsyncOperationHandle, AsyncOperationHandle<TObject>> callback, bool releaseDependenciesOnFailure);
		protected override bool InvokeWaitForCompletion();
		protected override void Execute();
		private void OnWrappedCompleted(AsyncOperationHandle<TObject> x);
		protected override void Destroy();
		internal override void ReleaseDependencies();
		internal override DownloadStatus GetDownloadStatus(HashSet<object> visited);
		private void RefreshDownloadStatus(HashSet<object> visited = null);
	}
}
