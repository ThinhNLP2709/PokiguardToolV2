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
	internal class InvokableCall<T1, T2> : BaseInvokableCall // TypeDefIndex: 7925
	{
		// Fields
		[CompilerGenerated]
		private UnityAction<T1, T2> Delegate;
	
		// Events
		protected event UnityAction<T1, T2> Delegate {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
	
		// Constructors
		public InvokableCall(object target, MethodInfo theFunction);
		public InvokableCall(UnityAction<T1, T2> action);
	
		// Methods
		public override void Invoke(object[] args);
		public void Invoke(T1 args0, T2 args1);
		public override bool Find(object targetObj, MethodInfo method);
	}
}
