/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class CardUsageAPI // TypeDefIndex: 740
{
	// Nested types
	[CompilerGenerated]
	private sealed class _SubmitUseCard_d__0 : IEnumerator<object> // TypeDefIndex: 741
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long cardId; // 0x20
		public int quantity; // 0x28
		private UnityWebRequest _request_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SubmitUseCard_d__0(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018040B140-0x000000018040B220
		private bool MoveNext(); // 0x000000018040A750-0x000000018040B100
		private void __m__Finally1(); // 0x000000018040B220-0x000000018040B270
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018040B100-0x000000018040B140
	}

	// Methods
	[IteratorStateMachine(typeof(_SubmitUseCard_d__0))]
	public static IEnumerator SubmitUseCard(long cardId, int quantity); // 0x00000001803F05E0-0x00000001803F0650
	private static string Esc(string s); // 0x00000001803F0520-0x00000001803F05E0
}

