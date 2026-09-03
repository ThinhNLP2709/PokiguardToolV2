/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Serialization;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Events
{
	[Serializable]
	internal class PersistentCallGroup // TypeDefIndex: 7931
	{
		// Fields
		[FormerlySerializedAs("m_Listeners")]
		[SerializeField]
		private List<PersistentCall> m_Calls; // 0x10
	
		// Properties
		public int Count { get; } // 0x0000000180B5F570-0x0000000180B5F590 
	
		// Constructors
		public PersistentCallGroup(); // 0x0000000182207A00-0x0000000182207A80
	
		// Methods
		public void Initialize(InvokableCallList invokableList, UnityEventBase unityEventBase); // 0x00000001822078C0-0x0000000182207A00
	}
}
