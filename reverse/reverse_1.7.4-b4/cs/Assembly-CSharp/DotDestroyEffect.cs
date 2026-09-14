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

public class DotDestroyEffect : MonoBehaviour // TypeDefIndex: 2298
{
	// Fields
	[Header("Delay Settings")]
	[Tooltip("Th\u1EDDi gian ch\u1EDD tr\u01B0\u1EDBc khi destroy (gi\u00E2y)")]
	public float duration; // 0x20
	private bool isDestroying; // 0x24

	// Nested types
	[CompilerGenerated]
	private sealed class _DelayThenComplete_d__3 : IEnumerator<object> // TypeDefIndex: 2299
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180AF08D0-0x0000000180AF09D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180AF09D0-0x0000000180AF0A10
	}

	// Constructors
	public DotDestroyEffect(); // 0x0000000180AF0880-0x0000000180AF08D0

	// Methods
	public void PlayDestroyEffect(Action onComplete = null); // 0x0000000180AF0290-0x0000000180AF0460
	[IteratorStateMachine(typeof(_DelayThenComplete_d__3))]
	private IEnumerator DelayThenComplete(Action onComplete); // 0x0000000180AF0460-0x0000000180AF0570
	public static void PlayEffect(GameObject dotObject, Action onComplete = null); // 0x0000000180AF0570-0x0000000180AF0880
}

