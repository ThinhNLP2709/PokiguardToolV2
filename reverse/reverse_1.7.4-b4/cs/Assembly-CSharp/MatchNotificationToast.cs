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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class MatchNotificationToast : MonoBehaviour // TypeDefIndex: 48
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
	private const int MaxQueue = 4; // Metadata: 0x005EEA79
	private bool _isShowing; // 0x50
	private Coroutine _processRoutine; // 0x58
	private string _lastQueued; // 0x60

	// Nested types
	[CompilerGenerated]
	private sealed class _Fade_d__15 : IEnumerator<object> // TypeDefIndex: 49
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Fade_d__15(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001802C9F90-0x00000001802CA300
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802CA300-0x00000001802CA340
	}

	[CompilerGenerated]
	private sealed class _ProcessQueue_d__14 : IEnumerator<object> // TypeDefIndex: 50
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public MatchNotificationToast __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ProcessQueue_d__14(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001802CA340-0x00000001802CA770
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802CA770-0x00000001802CA7B0
	}

	// Constructors
	public MatchNotificationToast(); // 0x00000001802C9E80-0x00000001802C9F90

	// Methods
	private void Awake(); // 0x00000001802C8B10-0x00000001802C8CF0
	private void OnDisable(); // 0x00000001802C8CF0-0x00000001802C8F60
	public void Show(string message); // 0x00000001802C8F60-0x00000001802C9170
	[IteratorStateMachine(typeof(_ProcessQueue_d__14))]
	private IEnumerator ProcessQueue(); // 0x00000001802C9170-0x00000001802C9210
	[IteratorStateMachine(typeof(_Fade_d__15))]
	private IEnumerator Fade(float from, float to, float duration); // 0x00000001802C9210-0x00000001802C92E0
	private void AutoBuildUI(); // 0x00000001802C92E0-0x00000001802C9E80
}

