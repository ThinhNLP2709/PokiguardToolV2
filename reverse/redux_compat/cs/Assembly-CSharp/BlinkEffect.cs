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

public class BlinkEffect : MonoBehaviour // TypeDefIndex: 1511
{
	// Fields
	public float fadeDuration; // 0x20
	public float waitTime; // 0x24
	private CanvasGroup canvasGroup; // 0x28
	private Coroutine blinkCoroutine; // 0x30

	// Nested types
	[CompilerGenerated]
	private sealed class _BlinkEffectt_d__6 : IEnumerator<object> // TypeDefIndex: 1512
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BlinkEffect __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _BlinkEffectt_d__6(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001805791C0-0x00000001805793A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805793A0-0x00000001805793E0
	}

	[CompilerGenerated]
	private sealed class _Fade_d__7 : IEnumerator<object> // TypeDefIndex: 1513
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BlinkEffect __4__this; // 0x20
		public float targetAlpha; // 0x28
		private float _startAlpha_5__2; // 0x2C
		private float _elapsedTime_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _Fade_d__7(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x000000018057A790-0x000000018057A8C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018057A8C0-0x000000018057A900
	}

	// Constructors
	public BlinkEffect(); // 0x000000018056B090-0x000000018056B0B0

	// Methods
	private void OnEnable(); // 0x000000018056AF50-0x000000018056B090
	private void OnDisable(); // 0x000000018056AF10-0x000000018056AF50
	[IteratorStateMachine(typeof(_BlinkEffectt_d__6))]
	private IEnumerator BlinkEffectt(); // 0x000000018056AE20-0x000000018056AE90
	[IteratorStateMachine(typeof(_Fade_d__7))]
	private IEnumerator Fade(float targetAlpha); // 0x000000018056AE90-0x000000018056AF10
}

