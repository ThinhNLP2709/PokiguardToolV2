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

public static class HubBadgeGate // TypeDefIndex: 1397
{
	// Fields
	public const float DEFAULT_MAX_WAIT = 8f; // Metadata: 0x0068CF77

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass1_0 // TypeDefIndex: 1398
	{
		// Fields
		public bool loaded; // 0x10

		// Constructors
		public __c__DisplayClass1_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _WaitBootstrapThenFetch_b__0(); // 0x000000018034AB40-0x000000018034AB50
	}

	[CompilerGenerated]
	private sealed class _WaitBootstrapThenFetch_d__1 : IEnumerator<object> // TypeDefIndex: 1399
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Func<HubBadgesData, bool> tryApply; // 0x20
		public Action fetch; // 0x28
		private __c__DisplayClass1_0 __8__1; // 0x30
		public float maxWait; // 0x38
		private Action _onLoaded_5__2; // 0x40
		private float _deadline_5__3; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitBootstrapThenFetch_d__1(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805BEA10-0x00000001805BEAA0
		private bool MoveNext(); // 0x00000001805BE490-0x00000001805BE9D0
		private void __m__Finally1(); // 0x00000001805BEAA0-0x00000001805BEBC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805BE9D0-0x00000001805BEA10
	}

	// Methods
	[IteratorStateMachine(typeof(_WaitBootstrapThenFetch_d__1))]
	public static IEnumerator WaitBootstrapThenFetch(MonoBehaviour host, float maxWait, Func<HubBadgesData, bool> tryApply, Action fetch); // 0x00000001805AB160-0x00000001805AB200
	public static IEnumerator WaitBootstrapThenFetch(MonoBehaviour host, Func<HubBadgesData, bool> tryApply, Action fetch); // 0x00000001805AB0D0-0x00000001805AB160
	private static bool TryApplySafe(Func<HubBadgesData, bool> tryApply); // 0x00000001805AAE00-0x00000001805AB0D0
	private static void SafeFetch(Action fetch); // 0x00000001805AAD70-0x00000001805AAE00
}

