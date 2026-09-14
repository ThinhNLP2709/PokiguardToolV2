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

public class BlinkEffect : MonoBehaviour // TypeDefIndex: 2137
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
	private static float FadeStepSeconds { get; } // 0x0000000180A16F10-0x0000000180A16F60 

	// Nested types
	[CompilerGenerated]
	private sealed class _BlinkEffectt_d__12 : IEnumerator<object> // TypeDefIndex: 2138
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public BlinkEffect __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BlinkEffectt_d__12(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A17610-0x0000000180A17770
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A17770-0x0000000180A177B0
	}

	[CompilerGenerated]
	private sealed class _Fade_d__13 : IEnumerator<object> // TypeDefIndex: 2139
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Fade_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180A177B0-0x0000000180A17C80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A17C80-0x0000000180A17CC0
	}

	// Constructors
	public BlinkEffect(); // 0x0000000180A175A0-0x0000000180A17610

	// Methods
	private void OnEnable(); // 0x0000000180A16F60-0x0000000180A17440
	private void OnDisable(); // 0x000000018059C830-0x000000018059C8B0
	[IteratorStateMachine(typeof(_BlinkEffectt_d__12))]
	private IEnumerator BlinkEffectt(); // 0x0000000180A17440-0x0000000180A174E0
	[IteratorStateMachine(typeof(_Fade_d__13))]
	private IEnumerator Fade(float targetAlpha); // 0x0000000180A174E0-0x0000000180A175A0
}

