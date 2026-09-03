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

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Events
{
	[Serializable]
	public class UnityEvent : UnityEventBase // TypeDefIndex: 7935
	{
		// Fields
		private object[] m_InvokeArray; // 0x28
	
		// Constructors
		[RequiredByNativeCode]
		public UnityEvent(); // 0x00000001822282C0-0x0000000182228480
	
		// Methods
		public void AddListener(UnityAction call); // 0x0000000182228680-0x0000000182228780
		public void RemoveListener(UnityAction call); // 0x0000000182228AE0-0x0000000182228B30
		protected override MethodInfo FindMethod_Impl(string name, Type targetObjType); // 0x0000000182228780-0x00000001822287E0
		internal override BaseInvokableCall GetDelegate(object target, MethodInfo theFunction); // 0x00000001822287E0-0x0000000182228850
		private static BaseInvokableCall GetDelegate(UnityAction action); // 0x0000000182228850-0x00000001822288B0
		public void Invoke(); // 0x00000001822288B0-0x0000000182228AE0
	}
}
