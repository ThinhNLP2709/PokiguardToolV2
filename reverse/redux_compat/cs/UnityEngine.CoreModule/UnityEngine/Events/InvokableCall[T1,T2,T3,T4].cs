/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Events
{
	internal class InvokableCall<T1, T2, T3, T4> : BaseInvokableCall // TypeDefIndex: 7927
	{
		// Fields
		[CompilerGenerated]
		private UnityAction<T1, T2, T3, T4> Delegate;
	
		// Constructors
		public InvokableCall(object target, MethodInfo theFunction);
	
		// Methods
		public override void Invoke(object[] args);
		public override bool Find(object targetObj, MethodInfo method);
	}
}
