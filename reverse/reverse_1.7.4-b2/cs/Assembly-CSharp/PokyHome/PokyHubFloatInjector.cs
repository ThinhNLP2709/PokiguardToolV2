/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	public static class PokyHubFloatInjector // TypeDefIndex: 2240
	{
		// Fields
		private const string NODE_TRIEU_HOI = "btnTrieuhoi"; // Metadata: 0x0068E337
		private const string NODE_CHINH_PHUC = "btnChinhPhuc"; // Metadata: 0x0068E343
		private const string NODE_THUC_TINH = "btnMega"; // Metadata: 0x0068E350
		public const string FLAG_OFF = "pokyhub.float.off"; // Metadata: 0x0068E358
		private const float AMP_DEFAULT = 5f; // Metadata: 0x0068E36A
		private const float AMP_THUC_TINH = 3f; // Metadata: 0x0068E36E
	
		// Nested types
		[CompilerGenerated]
		private sealed class _ApplyNextFrame_d__7 : IEnumerator<object> // TypeDefIndex: 2241
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ManagerQuangTruong qt; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
	
			// Constructors
			[DebuggerHidden]
			public _ApplyNextFrame_d__7(int __1__state); // 0x0000000180300530-0x0000000180300560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
			private bool MoveNext(); // 0x0000000180790290-0x0000000180790360
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180790360-0x00000001807903A0
		}
	
		// Methods
		public static void TryApply(ManagerQuangTruong qt); // 0x0000000180788530-0x00000001807886C0
		[IteratorStateMachine(typeof(_ApplyNextFrame_d__7))]
		private static IEnumerator ApplyNextFrame(ManagerQuangTruong qt); // 0x0000000180788090-0x0000000180788100
		private static void AttachAll(ManagerQuangTruong qt); // 0x0000000180788100-0x00000001807883A0
		private static bool Attach(Transform t, string name, float amplitude, float halfPeriod, float startDelay); // 0x00000001807883A0-0x0000000180788530
	}
}
