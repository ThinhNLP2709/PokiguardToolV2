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
	internal interface IAsyncOperation // TypeDefIndex: 13788
	{
		// Properties
		Type ResultType { get; }
		int Version { get; }
		string DebugName { get; }
		int ReferenceCount { get; }
		float PercentComplete { get; }
		AsyncOperationStatus Status { get; }
		Exception OperationException { get; }
		bool IsDone { get; }
		Action<IAsyncOperation> OnDestroy { set; }
		bool IsRunning { get; }
		Task<object> Task { get; }
		AsyncOperationHandle Handle { get; }
	
		// Events
		event Action<AsyncOperationHandle> CompletedTypeless {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
		event Action<AsyncOperationHandle> Destroyed {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
	
		// Methods
		object GetResultAsObject();
		void DecrementReferenceCount();
		void IncrementReferenceCount();
		DownloadStatus GetDownloadStatus(HashSet<object> visited);
		void GetDependencies(List<AsyncOperationHandle> deps);
		void InvokeCompletionEvent();
		void Start(ResourceManager rm, AsyncOperationHandle dependency, DelegateList<float> updateCallbacks);
		void WaitForCompletion();
	}
}
