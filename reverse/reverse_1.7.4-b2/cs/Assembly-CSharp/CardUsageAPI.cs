/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class CardUsageAPI // TypeDefIndex: 930
{
	// Nested types
	[CompilerGenerated]
	private sealed class _SubmitUseCard_d__0 : IEnumerator<object> // TypeDefIndex: 931
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public long cardId; // 0x20
		public int quantity; // 0x28
		private UnityWebRequest _request_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SubmitUseCard_d__0(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804E1330-0x00000001804E1410
		private bool MoveNext(); // 0x00000001804E0940-0x00000001804E12F0
		private void __m__Finally1(); // 0x00000001804E1410-0x00000001804E1460
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804E12F0-0x00000001804E1330
	}

	// Methods
	[IteratorStateMachine(typeof(_SubmitUseCard_d__0))]
	public static IEnumerator SubmitUseCard(long cardId, int quantity); // 0x00000001804C8500-0x00000001804C8570
	private static string Esc(string s); // 0x00000001804C8440-0x00000001804C8500
}

