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
	internal class InvokableCall : BaseInvokableCall // TypeDefIndex: 7923
	{
		// Fields
		[CompilerGenerated]
		private UnityAction Delegate; // 0x10
	
		// Events
		private event UnityAction Delegate {
			add; // 0x0000000182206A70-0x0000000182206B10
			remove; // 0x0000000182206B10-0x0000000182206BB0
		}
	
		// Constructors
		public InvokableCall(object target, MethodInfo theFunction); // 0x0000000182206880-0x0000000182206A70
		public InvokableCall(UnityAction action); // 0x0000000182206850-0x0000000182206880
	
		// Methods
		public override void Invoke(object[] args); // 0x00000001822067A0-0x0000000182206850
		public void Invoke(); // 0x00000001822067A0-0x0000000182206850
		public override bool Find(object targetObj, MethodInfo method); // 0x00000001812FF420-0x00000001812FF480
	}
}
