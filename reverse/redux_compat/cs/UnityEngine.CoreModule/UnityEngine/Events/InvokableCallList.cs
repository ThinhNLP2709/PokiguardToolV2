/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Events
{
	internal class InvokableCallList // TypeDefIndex: 7932
	{
		// Fields
		private readonly List<BaseInvokableCall> m_PersistentCalls; // 0x10
		private readonly List<BaseInvokableCall> m_RuntimeCalls; // 0x18
		private List<BaseInvokableCall> m_ExecutingCalls; // 0x20
		private bool m_NeedsUpdate; // 0x28
	
		// Properties
		public int Count { get; } // 0x0000000182206770-0x00000001822067A0 
	
		// Constructors
		public InvokableCallList(); // 0x0000000182206690-0x0000000182206770
	
		// Methods
		public void AddPersistentInvokableCall(BaseInvokableCall call); // 0x0000000182206190-0x0000000182206240
		public void AddListener(BaseInvokableCall call); // 0x00000001822060E0-0x0000000182206190
		public void RemoveListener(object targetObj, MethodInfo method); // 0x0000000182206460-0x0000000182206690
		public void Clear(); // 0x0000000182206300-0x00000001822063C0
		public void ClearPersistent(); // 0x0000000182206240-0x0000000182206300
		public List<BaseInvokableCall> PrepareInvoke(); // 0x00000001822063C0-0x0000000182206460
	}
}
