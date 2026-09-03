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
using UnityEngine.Scripting;
using UnityEngine.Serialization;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Events
{
	[Serializable]
	[UsedByNativeCode]
	public abstract class UnityEventBase : ISerializationCallbackReceiver // TypeDefIndex: 7933
	{
		// Fields
		private InvokableCallList m_Calls; // 0x10
		[FormerlySerializedAs("m_PersistentListeners")]
		[SerializeField]
		private PersistentCallGroup m_PersistentCalls; // 0x18
		private bool m_CallsDirty; // 0x20
	
		// Constructors
		protected UnityEventBase(); // 0x00000001822282C0-0x0000000182228480
	
		// Methods
		void ISerializationCallbackReceiver.OnBeforeSerialize(); // 0x00000001822282B0-0x00000001822282C0
		void ISerializationCallbackReceiver.OnAfterDeserialize(); // 0x00000001822282B0-0x00000001822282C0
		protected abstract MethodInfo FindMethod_Impl(string name, Type targetObjType);
		internal abstract BaseInvokableCall GetDelegate(object target, MethodInfo theFunction);
		internal MethodInfo FindMethod(PersistentCall call); // 0x00000001822278B0-0x0000000182227A10
		internal MethodInfo FindMethod(string name, Type listenerType, PersistentListenerMode mode, Type argumentType); // 0x0000000182227A10-0x0000000182227DC0
		internal int GetCallsCount(); // 0x0000000182227DC0-0x0000000182227DF0
		public int GetPersistentEventCount(); // 0x0000000182227DF0-0x0000000182227E20
		private void DirtyPersistentCalls(); // 0x00000001822277E0-0x00000001822278B0
		private void RebuildPersistentCallsIfNeeded(); // 0x0000000182228110-0x0000000182228150
		internal void AddCall(BaseInvokableCall call); // 0x0000000182227720-0x00000001822277E0
		protected void RemoveListener(object targetObj, MethodInfo method); // 0x0000000182228210-0x0000000182228230
		public void RemoveAllListeners(); // 0x0000000182228150-0x0000000182228210
		internal List<BaseInvokableCall> PrepareInvoke(); // 0x0000000182228040-0x0000000182228110
		public override string ToString(); // 0x0000000182228230-0x00000001822282B0
		public static MethodInfo GetValidMethodInfo(Type objectType, string functionName, Type[] argumentTypes); // 0x0000000182227E20-0x0000000182228040
	}
}
