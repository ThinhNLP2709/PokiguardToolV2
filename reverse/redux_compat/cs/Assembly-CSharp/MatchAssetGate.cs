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

public static class MatchAssetGate // TypeDefIndex: 1181
{
	// Fields
	private const float TIMEOUT_SECONDS = 25f; // Metadata: 0x0064D41A

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass1_0 // TypeDefIndex: 1182
	{
		// Fields
		public AnimationClip[] result; // 0x10
		public bool done; // 0x18

		// Constructors
		public __c__DisplayClass1_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _EnsureReady_b__0(AnimationClip[] clips); // 0x0000000180439DF0-0x0000000180439E10
	}

	[CompilerGenerated]
	private sealed class _EnsureReady_d__1 : IEnumerator<object> // TypeDefIndex: 1183
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _EnsureReady_d__1(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804BBE00-0x00000001804BBE50
		private bool MoveNext(); // 0x00000001804BB480-0x00000001804BBDC0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BBDC0-0x00000001804BBE00
	}

	// Methods
	[IteratorStateMachine(typeof(_EnsureReady_d__1))]
	public static IEnumerator EnsureReady(MatchKind kind, IEnumerable<int> petIds, Action<string> onProgress = null); // 0x00000001804B5700-0x00000001804B57A0
	public static IEnumerator EnsureReady(MatchKind kind, int myPetId, int enemyPetId, Action<string> onProgress = null); // 0x00000001804B55F0-0x00000001804B5700
	private static bool TimedOut(float t0); // 0x00000001804B5830-0x00000001804B5860
	private static void Report(Action<string> onProgress, string message); // 0x00000001804B57A0-0x00000001804B5830
}

