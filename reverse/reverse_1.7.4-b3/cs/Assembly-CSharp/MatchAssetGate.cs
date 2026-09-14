/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class MatchAssetGate // TypeDefIndex: 1783
{
	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass1_0 // TypeDefIndex: 1784
	{
		// Fields
		public AnimationClip[] result; // 0x10
		public bool done; // 0x18

		// Constructors
		public __c__DisplayClass1_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EnsureReady_b__0(AnimationClip[] clips); // 0x000000018076D550-0x000000018076D5B0
	}

	[CompilerGenerated]
	private sealed class _EnsureReady_d__1 : IEnumerator<object> // TypeDefIndex: 1785
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _EnsureReady_d__1(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808DBBF0-0x00000001808DBD00
		private bool MoveNext(); // 0x00000001808DBD00-0x00000001808DCAA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808DCAA0-0x00000001808DCAE0
	}

	// Methods
	[IteratorStateMachine(typeof(_EnsureReady_d__1))]
	public static IEnumerator EnsureReady(MatchKind kind, IEnumerable<int> petIds, Action<string> onProgress = null); // 0x00000001808DB930-0x00000001808DBA40
	public static IEnumerator EnsureReady(MatchKind kind, int myPetId, int enemyPetId, Action<string> onProgress = null); // 0x00000001808DBA40-0x00000001808DBAE0
	private static bool TimedOut(float t0); // 0x00000001808DBAE0-0x00000001808DBB50
	private static void Report(Action<string> onProgress, string message); // 0x00000001808DBB50-0x00000001808DBBF0
}

