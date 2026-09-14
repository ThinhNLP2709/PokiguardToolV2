/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	public static class PokyHubFloatInjector // TypeDefIndex: 2683
	{
		// Nested types
		[CompilerGenerated]
		private sealed class _ApplyNextFrame_d__7 : IEnumerator<object> // TypeDefIndex: 2684
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ManagerQuangTruong qt; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _ApplyNextFrame_d__7(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180C45F70-0x0000000180C46080
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180C46080-0x0000000180C460C0
		}
	
		// Methods
		public static void TryApply(ManagerQuangTruong qt); // 0x0000000180C452C0-0x0000000180C45510
		[IteratorStateMachine(typeof(_ApplyNextFrame_d__7))]
		private static IEnumerator ApplyNextFrame(ManagerQuangTruong qt); // 0x0000000180C45510-0x0000000180C455B0
		private static void AttachAll(ManagerQuangTruong qt); // 0x0000000180C455B0-0x0000000180C45C60
		private static bool Attach(Transform t, string name, float amplitude, float halfPeriod, float startDelay); // 0x0000000180C45C60-0x0000000180C45F70
	}
}
