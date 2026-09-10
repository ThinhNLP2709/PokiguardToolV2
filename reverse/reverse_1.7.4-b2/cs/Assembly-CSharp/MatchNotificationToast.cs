/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class MatchNotificationToast : MonoBehaviour // TypeDefIndex: 47
{
	// Fields
	[Header("Optional Inspector refs \u2014 auto-create n\u1EBFu null")]
	[SerializeField]
	private CanvasGroup canvasGroup; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text messageText; // 0x28
	[SerializeField]
	private Image background; // 0x30
	[Header("Timing (seconds)")]
	[SerializeField]
	private float fadeInDuration; // 0x38
	[SerializeField]
	private float holdDuration; // 0x3C
	[SerializeField]
	private float fadeOutDuration; // 0x40
	private readonly Queue<string> _queue; // 0x48
	private const int MaxQueue = 4; // Metadata: 0x0068AA5F
	private bool _isShowing; // 0x50
	private Coroutine _processRoutine; // 0x58
	private string _lastQueued; // 0x60

	// Nested types
	[CompilerGenerated]
	private sealed class _Fade_d__15 : IEnumerator<object> // TypeDefIndex: 48
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchNotificationToast __4__this; // 0x20
		public float from; // 0x28
		public float to; // 0x2C
		public float duration; // 0x30
		private float _elapsed_5__2; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _Fade_d__15(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180314870-0x00000001803149F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803149F0-0x0000000180314A30
	}

	[CompilerGenerated]
	private sealed class _ProcessQueue_d__14 : IEnumerator<object> // TypeDefIndex: 49
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchNotificationToast __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ProcessQueue_d__14(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180316C00-0x0000000180316E30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180316E30-0x0000000180316E70
	}

	// Constructors
	public MatchNotificationToast(); // 0x000000018030CCE0-0x000000018030CD70

	// Methods
	private void Awake(); // 0x000000018030C910-0x000000018030C9B0
	private void OnDisable(); // 0x000000018030CA60-0x000000018030CB20
	public void Show(string message); // 0x000000018030CB90-0x000000018030CCE0
	[IteratorStateMachine(typeof(_ProcessQueue_d__14))]
	private IEnumerator ProcessQueue(); // 0x000000018030CB20-0x000000018030CB90
	[IteratorStateMachine(typeof(_Fade_d__15))]
	private IEnumerator Fade(float from, float to, float duration); // 0x000000018030C9B0-0x000000018030CA60
	private void AutoBuildUI(); // 0x000000018030C310-0x000000018030C910
}

