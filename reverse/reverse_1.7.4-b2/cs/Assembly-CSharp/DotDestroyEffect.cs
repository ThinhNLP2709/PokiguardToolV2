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

public class DotDestroyEffect : MonoBehaviour // TypeDefIndex: 1925
{
	// Fields
	[Header("Delay Settings")]
	[Tooltip("Th\u1EDDi gian ch\u1EDD tr\u01B0\u1EDBc khi destroy (gi\u00E2y)")]
	public float duration; // 0x20
	private bool isDestroying; // 0x24

	// Nested types
	[CompilerGenerated]
	private sealed class _DelayThenComplete_d__3 : IEnumerator<object> // TypeDefIndex: 1926
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public DotDestroyEffect __4__this; // 0x20
		public Action onComplete; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _DelayThenComplete_d__3(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806F3030-0x00000001806F3100
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806F3100-0x00000001806F3140
	}

	// Constructors
	public DotDestroyEffect(); // 0x00000001806E9B40-0x00000001806E9B50

	// Methods
	public void PlayDestroyEffect(Action onComplete = null); // 0x00000001806E9800-0x00000001806E98F0
	[IteratorStateMachine(typeof(_DelayThenComplete_d__3))]
	private IEnumerator DelayThenComplete(Action onComplete); // 0x00000001806E9770-0x00000001806E9800
	public static void PlayEffect(GameObject dotObject, Action onComplete = null); // 0x00000001806E98F0-0x00000001806E9B40
}

