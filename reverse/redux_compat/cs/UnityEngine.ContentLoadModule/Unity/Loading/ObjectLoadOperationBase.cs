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
	internal abstract class ObjectLoadOperationBase : IEnumerator // TypeDefIndex: 15726
	{
		// Fields
		protected bool m_IsDone; // 0x10
	
		// Properties
		public bool isDone { get; } // 0x00000001805625D0-0x00000001805625E0 
		[ExcludeFromDocs]
		public object Current { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Methods
		[ExcludeFromDocs]
		internal abstract bool Complete(EntityId entityId, bool logErrors);
		[ExcludeFromDocs]
		public bool MoveNext(); // 0x0000000182175B30-0x0000000182175B40
		[ExcludeFromDocs]
		public void Reset(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
