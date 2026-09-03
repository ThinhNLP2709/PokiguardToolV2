/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.AsyncOperations
{
	public struct AsyncOperationHandle<TObject> : IEnumerator, IEquatable<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<TObject>> // TypeDefIndex: 13792
	{
		// Fields
		internal AsyncOperationBase<TObject> m_InternalOp;
		private int m_Version;
		private string m_LocationName;
	
		// Properties
		internal int Version { get; }
		internal string LocationName { get; set; }
		public string DebugName { get; }
		internal AsyncOperationBase<TObject> InternalOp { get; }
		public bool IsDone { get; }
		public Exception OperationException { get; }
		public float PercentComplete { get; }
		internal int ReferenceCount { get; }
		public TObject Result { get; }
		public AsyncOperationStatus Status { get; }
		public Task<TObject> Task { get; }
		object IEnumerator.Current { get; }
	
		// Events
		public event Action<AsyncOperationHandle<TObject>> Completed {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
		public event Action<AsyncOperationHandle> CompletedTypeless {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
		public event Action<AsyncOperationHandle> Destroyed {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 13793
		{
			// Fields
			public static readonly __c<TObject> __9;
			public static Action<AsyncOperationHandle<TObject>> __9__20_0;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal void _ReleaseHandleOnCompletion_b__20_0(AsyncOperationHandle<TObject> op);
		}
	
		// Constructors
		internal AsyncOperationHandle(AsyncOperationBase<TObject> op);
		internal AsyncOperationHandle(IAsyncOperation op);
		internal AsyncOperationHandle(IAsyncOperation op, int version);
		internal AsyncOperationHandle(IAsyncOperation op, string locationName);
		internal AsyncOperationHandle(IAsyncOperation op, int version, string locationName);
	
		// Methods
		public static implicit operator AsyncOperationHandle(AsyncOperationHandle<TObject> obj);
		public DownloadStatus GetDownloadStatus();
		internal DownloadStatus InternalGetDownloadStatus(HashSet<object> visited);
		internal AsyncOperationHandle<TObject> Acquire();
		public void ReleaseHandleOnCompletion();
		public void GetDependencies(List<AsyncOperationHandle> deps);
		public bool Equals(AsyncOperationHandle<TObject> other);
		public override int GetHashCode();
		public TObject WaitForCompletion();
		public bool IsValid();
		public void Release();
		bool IEnumerator.MoveNext();
		void IEnumerator.Reset();
	}
}
