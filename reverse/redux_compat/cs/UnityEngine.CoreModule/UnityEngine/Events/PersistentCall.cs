/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.Serialization;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Events
{
	[Serializable]
	[UsedByNativeCode]
	internal class PersistentCall : ISerializationCallbackReceiver // TypeDefIndex: 7930
	{
		// Fields
		[FormerlySerializedAs("instance")]
		[SerializeField]
		private UnityEngine.Object m_Target; // 0x10
		[SerializeField]
		private string m_TargetAssemblyTypeName; // 0x18
		[FormerlySerializedAs("methodName")]
		[SerializeField]
		private string m_MethodName; // 0x20
		[FormerlySerializedAs("mode")]
		[SerializeField]
		private PersistentListenerMode m_Mode; // 0x28
		[FormerlySerializedAs("arguments")]
		[SerializeField]
		private ArgumentCache m_Arguments; // 0x30
		[FormerlySerializedAs("m_Enabled")]
		[FormerlySerializedAs("enabled")]
		[SerializeField]
		private UnityEventCallState m_CallState; // 0x38
	
		// Properties
		public UnityEngine.Object target { get; } // 0x0000000180377550-0x0000000180377560 
		public string targetAssemblyTypeName { get; } // 0x00000001822083E0-0x00000001822084A0 
		public string methodName { get; } // 0x00000001802F8630-0x00000001802F8640 
		public PersistentListenerMode mode { get; } // 0x0000000180377930-0x0000000180377940 
		public ArgumentCache arguments { get; } // 0x000000018031E110-0x000000018031E120 
	
		// Constructors
		public PersistentCall(); // 0x0000000182208370-0x00000001822083E0
	
		// Methods
		public bool IsValid(); // 0x0000000182208330-0x0000000182208370
		public BaseInvokableCall GetRuntimeCall(UnityEventBase theEvent); // 0x0000000182207F10-0x0000000182208330
		private static BaseInvokableCall GetObjectCall(UnityEngine.Object target, MethodInfo method, ArgumentCache arguments); // 0x0000000182207A80-0x0000000182207F10
		public void OnBeforeSerialize(); // 0x00000001822005D0-0x0000000182200600
		public void OnAfterDeserialize(); // 0x00000001822005D0-0x0000000182200600
	}
}
