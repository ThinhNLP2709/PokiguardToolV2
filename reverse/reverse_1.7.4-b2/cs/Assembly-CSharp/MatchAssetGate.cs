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

public static class MatchAssetGate // TypeDefIndex: 1401
{
	// Fields
	private const float TIMEOUT_SECONDS = 25f; // Metadata: 0x0068CF7B

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass1_0 // TypeDefIndex: 1402
	{
		// Fields
		public AnimationClip[] result; // 0x10
		public bool done; // 0x18

		// Constructors
		public __c__DisplayClass1_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _EnsureReady_b__0(AnimationClip[] clips); // 0x00000001804F8C00-0x00000001804F8C20
	}

	[CompilerGenerated]
	private sealed class _EnsureReady_d__1 : IEnumerator<object> // TypeDefIndex: 1403
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchKind kind; // 0x20
		public Action<string> onProgress; // 0x28
		public IEnumerable<int> petIds; // 0x30
		private __c__DisplayClass1_0 __8__1; // 0x38
		private float _t0_5__2; // 0x40
		private List<int> _unique_5__3; // 0x48
		private int _i_5__4; // 0x50
		private string _petPath_5__5; // 0x58

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _EnsureReady_d__1(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805B78C0-0x00000001805B7910
		private bool MoveNext(); // 0x00000001805B6EA0-0x00000001805B7880
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B7880-0x00000001805B78C0
	}

	// Methods
	[IteratorStateMachine(typeof(_EnsureReady_d__1))]
	public static IEnumerator EnsureReady(MatchKind kind, IEnumerable<int> petIds, Action<string> onProgress = null); // 0x00000001805B1A90-0x00000001805B1B30
	public static IEnumerator EnsureReady(MatchKind kind, int myPetId, int enemyPetId, Action<string> onProgress = null); // 0x00000001805B1980-0x00000001805B1A90
	private static bool TimedOut(float t0); // 0x00000001805B1BC0-0x00000001805B1BF0
	private static void Report(Action<string> onProgress, string message); // 0x00000001805B1B30-0x00000001805B1BC0
}

