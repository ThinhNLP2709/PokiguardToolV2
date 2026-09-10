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

public class YourTurnEffect : MonoBehaviour // TypeDefIndex: 1793
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
	private sealed class _PlayEffect_d__7 : IEnumerator<object> // TypeDefIndex: 1794
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public YourTurnEffect __4__this; // 0x20
		private float _timer_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _PlayEffect_d__7(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180699360-0x0000000180699820
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180699820-0x0000000180699860
	}

	// Constructors
	public YourTurnEffect(); // 0x000000018069C370-0x000000018069C3A0

	// Methods
	private void Awake(); // 0x000000018069C280-0x000000018069C300
	[IteratorStateMachine(typeof(_PlayEffect_d__7))]
	public IEnumerator PlayEffect(); // 0x000000018069C300-0x000000018069C370
}

