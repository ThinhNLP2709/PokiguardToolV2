/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine.ResourceManagement;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.AsyncOperations
{
	public abstract class AsyncOperationBase<TObject> : IAsyncOperation // TypeDefIndex: 13789
	{
		// Fields
		[CompilerGenerated]
		private TObject _Result_k__BackingField;
		private int m_referenceCount;
		internal AsyncOperationStatus m_Status;
		internal Exception m_Error;
		internal ResourceManager m_RM;
		internal int m_Version;
		private DelegateList<AsyncOperationHandle> m_DestroyedAction;
		private DelegateList<AsyncOperationHandle<TObject>> m_CompletedActionT;
		private Action<IAsyncOperation> m_OnDestroyAction;
		private Action<AsyncOperationHandle> m_dependencyCompleteAction;
		protected internal bool HasExecuted;
		[CompilerGenerated]
		private Action Executed;
		[CompilerGenerated]
		private bool _IsRunning_k__BackingField;
		private TaskCompletionSource<TObject> m_taskCompletionSource;
		private TaskCompletionSource<object> m_taskCompletionSourceTypeless;
		private bool m_InDeferredCallbackQueue;
		private DelegateList<float> m_UpdateCallbacks;
		private Action<float> m_UpdateCallback;
	
		// Properties
		protected virtual float Progress { get; }
		protected virtual string DebugName { get; }
		public TObject Result { [CompilerGenerated] get; [CompilerGenerated] set; }
		internal int Version { get; }
		internal bool CompletedEventHasListeners { get; }
		internal bool DestroyedEventHasListeners { get; }
		internal Action<IAsyncOperation> OnDestroy { set; }
		protected internal int ReferenceCount { get; }
		public bool IsRunning { [CompilerGenerated] get; [CompilerGenerated] internal set; }
		internal Task<TObject> Task { get; }
		Task<object> IAsyncOperation.Task { get; }
		internal AsyncOperationStatus Status { get; }
		internal Exception OperationException { get; private set; }
		internal object Current { get; }
		internal bool IsDone { get; }
		internal float PercentComplete { get; }
		internal AsyncOperationHandle<TObject> Handle { get; }
		int IAsyncOperation.Version { get; }
		int IAsyncOperation.ReferenceCount { get; }
		float IAsyncOperation.PercentComplete { get; }
		AsyncOperationStatus IAsyncOperation.Status { get; }
		Exception IAsyncOperation.OperationException { get; }
		bool IAsyncOperation.IsDone { get; }
		AsyncOperationHandle IAsyncOperation.Handle { get; }
		Action<IAsyncOperation> IAsyncOperation.OnDestroy { set; }
		string IAsyncOperation.DebugName { get; }
		Type IAsyncOperation.ResultType { get; }
	
		// Events
		internal event Action Executed {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
		internal event Action<AsyncOperationHandle<TObject>> Completed {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
		internal event Action<AsyncOperationHandle> Destroyed {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
		internal event Action<AsyncOperationHandle> CompletedTypeless {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
		event Action<AsyncOperationHandle> UnityEngine_ResourceManagement_AsyncOperations_IAsyncOperation_CompletedTypeless {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
		event Action<AsyncOperationHandle> UnityEngine_ResourceManagement_AsyncOperations_IAsyncOperation_Destroyed {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass60_0 // TypeDefIndex: 13790
		{
			// Fields
			public Action<AsyncOperationHandle> value;
	
			// Constructors
			public __c__DisplayClass60_0();
	
			// Methods
			internal void _add_CompletedTypeless_b__0(AsyncOperationHandle<TObject> s);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass61_0 // TypeDefIndex: 13791
		{
			// Fields
			public Action<AsyncOperationHandle> value;
	
			// Constructors
			public __c__DisplayClass61_0();
	
			// Methods
			internal void _remove_CompletedTypeless_b__0(AsyncOperationHandle<TObject> s);
		}
	
		// Constructors
		protected AsyncOperationBase();
	
		// Methods
		protected abstract void Execute();
		protected virtual void Destroy();
		public virtual void GetDependencies(List<AsyncOperationHandle> dependencies);
		internal static string ShortenPath(string p, bool keepExtension);
		public void WaitForCompletion();
		protected virtual bool InvokeWaitForCompletion();
		protected internal void IncrementReferenceCount();
		protected internal void DecrementReferenceCount();
		public override string ToString();
		private void RegisterForDeferredCallbackEvent(bool incrementReferenceCount = true /* Metadata: 0x006A7E8A */);
		internal bool MoveNext();
		internal void Reset();
		internal void InvokeCompletionEvent();
		private void UpdateCallback(float unscaledDeltaTime);
		public void Complete(TObject result, bool success, string errorMsg);
		public void Complete(TObject result, bool success, string errorMsg, bool releaseDependenciesOnFailure);
		public void Complete(TObject result, bool success, Exception exception, bool releaseDependenciesOnFailure = true /* Metadata: 0x006A7E8B */);
		internal void Start(ResourceManager rm, AsyncOperationHandle dependency, DelegateList<float> updateCallbacks);
		internal void InvokeExecute();
		object IAsyncOperation.GetResultAsObject();
		void IAsyncOperation.GetDependencies(List<AsyncOperationHandle> deps);
		void IAsyncOperation.DecrementReferenceCount();
		void IAsyncOperation.IncrementReferenceCount();
		void IAsyncOperation.InvokeCompletionEvent();
		void IAsyncOperation.Start(ResourceManager rm, AsyncOperationHandle dependency, DelegateList<float> updateCallbacks);
		internal virtual void ReleaseDependencies();
		DownloadStatus IAsyncOperation.GetDownloadStatus(HashSet<object> visited);
		internal virtual DownloadStatus GetDownloadStatus(HashSet<object> visited);
		[CompilerGenerated]
		private void _.ctor_b__38_0(AsyncOperationHandle o);
	}
}
