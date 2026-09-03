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
	public class UnityEvent<T0, T1, T2, T3> : UnityEventBase // TypeDefIndex: 7943
	{
		// Constructors
		[RequiredByNativeCode]
		public UnityEvent();
	
		// Methods
		protected override MethodInfo FindMethod_Impl(string name, Type targetObjType);
		internal override BaseInvokableCall GetDelegate(object target, MethodInfo theFunction);
	}
}
