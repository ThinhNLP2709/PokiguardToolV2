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

public class DotDestroyEffect : MonoBehaviour // TypeDefIndex: 1653
{
	// Fields
	[Header("Delay Settings")]
	[Tooltip("Th\u1EDDi gian ch\u1EDD tr\u01B0\u1EDBc khi destroy (gi\u00E2y)")]
	public float duration; // 0x20
	private bool isDestroying; // 0x24

	// Nested types
	[CompilerGenerated]
	private sealed class _DelayThenComplete_d__3 : IEnumerator<object> // TypeDefIndex: 1654
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public DotDestroyEffect __4__this; // 0x20
		public Action onComplete; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _DelayThenComplete_d__3(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805CD780-0x00000001805CD850
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805CD850-0x00000001805CD890
	}

	// Constructors
	public DotDestroyEffect(); // 0x00000001805C2890-0x00000001805C28A0

	// Methods
	public void PlayDestroyEffect(Action onComplete = null); // 0x00000001805C2550-0x00000001805C2640
	[IteratorStateMachine(typeof(_DelayThenComplete_d__3))]
	private IEnumerator DelayThenComplete(Action onComplete); // 0x00000001805C24C0-0x00000001805C2550
	public static void PlayEffect(GameObject dotObject, Action onComplete = null); // 0x00000001805C2640-0x00000001805C2890
}

