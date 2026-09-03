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
	public struct AsyncOperationHandle : IEnumerator // TypeDefIndex: 13794
	{
		// Fields
		internal IAsyncOperation m_InternalOp; // 0x00
		private int m_Version; // 0x08
		private string m_LocationName; // 0x10
	
		// Properties
		internal int Version { get; } // 0x0000000180732D20-0x0000000180732D30 
		internal string LocationName { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public string DebugName { get; } // 0x0000000182047420-0x00000001820474D0 
		private IAsyncOperation InternalOp { get; } // 0x00000001820474D0-0x0000000182047560 
		public bool IsDone { get; } // 0x0000000182047560-0x0000000182047600 
		public Exception OperationException { get; } // 0x0000000182047600-0x00000001820476D0 
		public float PercentComplete { get; } // 0x00000001820476D0-0x00000001820477A0 
		internal int ReferenceCount { get; } // 0x00000001820477A0-0x0000000182047800 
		public object Result { get; } // 0x0000000182047010-0x0000000182047060 
		public AsyncOperationStatus Status { get; } // 0x0000000182047800-0x0000000182047860 
		public Task<object> Task { get; } // 0x0000000182047860-0x0000000182047930 
		object IEnumerator.Current { get; } // 0x0000000182047010-0x0000000182047060 
	
		// Events
		public event Action<AsyncOperationHandle> Completed {
			add; // 0x0000000182047340-0x00000001820473B0
			remove; // 0x0000000182047930-0x00000001820479A0
		}
		public event Action<AsyncOperationHandle> Destroyed {
			add; // 0x00000001820473B0-0x0000000182047420
			remove; // 0x00000001820479A0-0x0000000182047A10
		}
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 13795
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action<AsyncOperationHandle> __9__16_0; // 0x08
	
			// Constructors
			static __c(); // 0x000000018205F4E0-0x000000018205F550
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _ReleaseHandleOnCompletion_b__16_0(AsyncOperationHandle op); // 0x0000000180A68EC0-0x0000000180A68EE0
		}
	
		// Constructors
		internal AsyncOperationHandle(IAsyncOperation op); // 0x0000000182047230-0x00000001820472B0
		internal AsyncOperationHandle(IAsyncOperation op, int version); // 0x00000001820471A0-0x00000001820471E0
		internal AsyncOperationHandle(IAsyncOperation op, string locationName); // 0x00000001820472B0-0x0000000182047340
		internal AsyncOperationHandle(IAsyncOperation op, int version, string locationName); // 0x00000001820471E0-0x0000000182047230
	
		// Methods
		internal AsyncOperationHandle Acquire(); // 0x0000000182046950-0x00000001820469D0
		public void ReleaseHandleOnCompletion(); // 0x0000000182046E60-0x0000000182046F80
		public AsyncOperationHandle<T> Convert<T>();
		public bool Equals(AsyncOperationHandle other); // 0x0000000180B26E40-0x0000000180B26E70
		public void GetDependencies(List<AsyncOperationHandle> deps); // 0x00000001820469D0-0x0000000182046AA0
		public override int GetHashCode(); // 0x0000000180B273C0-0x0000000180B27400
		public bool IsValid(); // 0x0000000182046E00-0x0000000182046E60
		public DownloadStatus GetDownloadStatus(); // 0x0000000182046AA0-0x0000000182046C60
		internal DownloadStatus InternalGetDownloadStatus(HashSet<object> visited); // 0x0000000182046C60-0x0000000182046E00
		public void Release(); // 0x0000000182046F80-0x0000000182046FF0
		bool IEnumerator.MoveNext(); // 0x0000000182046FF0-0x0000000182047010
		void IEnumerator.Reset(); // 0x00000001802E76C0-0x00000001802E76D0
		public object WaitForCompletion(); // 0x0000000182047060-0x00000001820471A0
	}
}
