/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Internal;

// Image 59: UnityEngine.ContentLoadModule.dll - Assembly: UnityEngine.ContentLoadModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15722-15736

namespace Unity.Loading
{
	internal sealed class ObjectReleaseOperation : IEnumerator // TypeDefIndex: 15727
	{
		// Fields
		private ContentLoadingSystem.ResourceOperationHandle m_OperationHandle; // 0x10
		private bool m_IsDone; // 0x18
		private Action<ObjectReleaseOperation> m_Completed; // 0x20
		private AwaitableCompletionSource m_CompletionSource; // 0x28
	
		// Properties
		public bool isDone { get; } // 0x0000000180F9E350-0x0000000180F9E360 
		[ExcludeFromDocs]
		public object Current { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Methods
		[ExcludeFromDocs]
		internal void Complete(); // 0x0000000182175B40-0x0000000182175CE0
		[ExcludeFromDocs]
		public bool MoveNext(); // 0x00000001818F51A0-0x00000001818F51B0
		[ExcludeFromDocs]
		public void Reset(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
