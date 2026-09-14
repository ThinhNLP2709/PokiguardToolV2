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

public static class HubBadgeGate // TypeDefIndex: 1781
{
	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass1_0 // TypeDefIndex: 1782
	{
		// Fields
		public bool loaded; // 0x10

		// Constructors
		public __c__DisplayClass1_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _WaitBootstrapThenFetch_b__0(); // 0x0000000180308BD0-0x0000000180308BE0
	}

	[CompilerGenerated]
	private sealed class _WaitBootstrapThenFetch_d__1 : IEnumerator<object> // TypeDefIndex: 1783
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitBootstrapThenFetch_d__1(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808DDD80-0x00000001808DDEB0
		private bool MoveNext(); // 0x00000001808DDEB0-0x00000001808DE4D0
		private void __m__Finally1(); // 0x00000001808DE4D0-0x00000001808DE650
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808DE650-0x00000001808DE690
	}

	// Methods
	[IteratorStateMachine(typeof(_WaitBootstrapThenFetch_d__1))]
	public static IEnumerator WaitBootstrapThenFetch(MonoBehaviour host, float maxWait, Func<HubBadgesData, bool> tryApply, Action fetch); // 0x00000001808DD940-0x00000001808DDA50
	public static IEnumerator WaitBootstrapThenFetch(MonoBehaviour host, Func<HubBadgesData, bool> tryApply, Action fetch); // 0x00000001808DDA50-0x00000001808DDA80
	private static bool TryApplySafe(Func<HubBadgesData, bool> tryApply); // 0x00000001808DDA80-0x00000001808DDCE0
	private static void SafeFetch(Action fetch); // 0x00000001808DDCE0-0x00000001808DDD80
}

