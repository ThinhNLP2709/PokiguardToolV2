/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	public static class PokyHubFloatInjector // TypeDefIndex: 1914
	{
		// Fields
		private const string NODE_TRIEU_HOI = "btnTrieuhoi"; // Metadata: 0x0064DEB7
		private const string NODE_CHINH_PHUC = "btnChinhPhuc"; // Metadata: 0x0064DEC3
		private const string NODE_THUC_TINH = "btnMega"; // Metadata: 0x0064DED0
		public const string FLAG_OFF = "pokyhub.float.off"; // Metadata: 0x0064DED8
		private const float AMP_DEFAULT = 5f; // Metadata: 0x0064DEEA
		private const float AMP_THUC_TINH = 3f; // Metadata: 0x0064DEEE
	
		// Nested types
		[CompilerGenerated]
		private sealed class _ApplyNextFrame_d__7 : IEnumerator<object> // TypeDefIndex: 1915
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public ManagerQuangTruong qt; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _ApplyNextFrame_d__7(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x00000001806527C0-0x0000000180652890
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180652890-0x00000001806528D0
		}
	
		// Methods
		public static void TryApply(ManagerQuangTruong qt); // 0x0000000180644080-0x0000000180644210
		[IteratorStateMachine(typeof(_ApplyNextFrame_d__7))]
		private static IEnumerator ApplyNextFrame(ManagerQuangTruong qt); // 0x0000000180643BE0-0x0000000180643C50
		private static void AttachAll(ManagerQuangTruong qt); // 0x0000000180643C50-0x0000000180643EF0
		private static bool Attach(Transform t, string name, float amplitude, float halfPeriod, float startDelay); // 0x0000000180643EF0-0x0000000180644080
	}
}
