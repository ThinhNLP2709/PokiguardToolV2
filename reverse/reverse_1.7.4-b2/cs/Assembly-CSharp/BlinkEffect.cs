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

public class BlinkEffect : MonoBehaviour // TypeDefIndex: 1774
{
	// Fields
	public float fadeDuration; // 0x20
	public float waitTime; // 0x24
	private CanvasGroup canvasGroup; // 0x28
	private Coroutine blinkCoroutine; // 0x30
	private WaitForSecondsRealtime _stepWait; // 0x38
	private float _stepWaitFor; // 0x40
	private WaitForSecondsRealtime _holdWait; // 0x48
	private float _holdWaitFor; // 0x50

	// Properties
	private static float FadeStepSeconds { get; } // 0x0000000180691110-0x00000001806911A0 

	// Nested types
	[CompilerGenerated]
	private sealed class _BlinkEffectt_d__12 : IEnumerator<object> // TypeDefIndex: 1775
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BlinkEffect __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _BlinkEffectt_d__12(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001806973D0-0x00000001806974F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806974F0-0x0000000180697530
	}

	[CompilerGenerated]
	private sealed class _Fade_d__13 : IEnumerator<object> // TypeDefIndex: 1776
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BlinkEffect __4__this; // 0x20
		public float targetAlpha; // 0x28
		private float _startAlpha_5__2; // 0x2C
		private float _dur_5__3; // 0x30
		private float _startTime_5__4; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Fade_d__13(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180697E70-0x00000001806980A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806980A0-0x00000001806980E0
	}

	// Constructors
	public BlinkEffect(); // 0x00000001806910E0-0x0000000180691110

	// Methods
	private void OnEnable(); // 0x0000000180690E00-0x00000001806910E0
	private void OnDisable(); // 0x000000018047D140-0x000000018047D180
	[IteratorStateMachine(typeof(_BlinkEffectt_d__12))]
	private IEnumerator BlinkEffectt(); // 0x0000000180690D10-0x0000000180690D80
	[IteratorStateMachine(typeof(_Fade_d__13))]
	private IEnumerator Fade(float targetAlpha); // 0x0000000180690D80-0x0000000180690E00
}

