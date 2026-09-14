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

public class DotDestroyEffect : MonoBehaviour // TypeDefIndex: 2291
{
	// Fields
	[Header("Delay Settings")]
	[Tooltip("Th\u1EDDi gian ch\u1EDD tr\u01B0\u1EDBc khi destroy (gi\u00E2y)")]
	public float duration; // 0x20
	private bool isDestroying; // 0x24

	// Nested types
	[CompilerGenerated]
	private sealed class _DelayThenComplete_d__3 : IEnumerator<object> // TypeDefIndex: 2292
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public DotDestroyEffect __4__this; // 0x20
		public Action onComplete; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _DelayThenComplete_d__3(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180AE3660-0x0000000180AE3760
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AE3760-0x0000000180AE37A0
	}

	// Constructors
	public DotDestroyEffect(); // 0x0000000180AE3610-0x0000000180AE3660

	// Methods
	public void PlayDestroyEffect(Action onComplete = null); // 0x0000000180AE3020-0x0000000180AE31F0
	[IteratorStateMachine(typeof(_DelayThenComplete_d__3))]
	private IEnumerator DelayThenComplete(Action onComplete); // 0x0000000180AE31F0-0x0000000180AE3300
	public static void PlayEffect(GameObject dotObject, Action onComplete = null); // 0x0000000180AE3300-0x0000000180AE3610
}

