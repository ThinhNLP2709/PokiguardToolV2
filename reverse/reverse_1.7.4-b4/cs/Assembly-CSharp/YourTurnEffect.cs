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

public class YourTurnEffect : MonoBehaviour // TypeDefIndex: 2157
{
	// Fields
	[Header("Effect Settings")]
	[SerializeField]
	private float fadeInDuration; // 0x20
	[SerializeField]
	private float fadeOutDuration; // 0x24
	[SerializeField]
	private float peakDuration; // 0x28
	[SerializeField]
	private float scaleAmount; // 0x2C
	private CanvasGroup canvasGroup; // 0x30
	private RectTransform rectTransform; // 0x38

	// Nested types
	[CompilerGenerated]
	private sealed class _PlayEffect_d__7 : IEnumerator<object> // TypeDefIndex: 2158
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public YourTurnEffect __4__this; // 0x20
		private float _timer_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _PlayEffect_d__7(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180A26330-0x0000000180A26CF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180A26CF0-0x0000000180A26D30
	}

	// Constructors
	public YourTurnEffect(); // 0x0000000180A262C0-0x0000000180A26330

	// Methods
	private void Awake(); // 0x0000000180A26100-0x0000000180A26220
	[IteratorStateMachine(typeof(_PlayEffect_d__7))]
	public IEnumerator PlayEffect(); // 0x0000000180A26220-0x0000000180A262C0
}

