/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class NotificationPopup : MonoBehaviour // TypeDefIndex: 1586
{
	// Fields
	[Header("UI Components")]
	public TextMeshProUGUI txtTitle; // 0x20
	public TextMeshProUGUI txtMessage; // 0x28
	public Image imgReward; // 0x30
	public TextMeshProUGUI txtRewardAmount; // 0x38
	public Button btnClose; // 0x40
	public GameObject rewardContainer; // 0x48
	[Header("Animation")]
	public float fadeInDuration; // 0x50
	public float autoCloseDuration; // 0x54
	[Header("Audio")]
	public AudioClip successSound; // 0x58
	public AudioClip errorSound; // 0x60
	private CanvasGroup canvasGroup; // 0x68
	private AudioSource audioSource; // 0x70

	// Nested types
	[CompilerGenerated]
	private sealed class _AutoClose_d__20 : IEnumerator<object> // TypeDefIndex: 1587
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NotificationPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _AutoClose_d__20(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018087C150-0x000000018087C350
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018087C350-0x000000018087C390
	}

	[CompilerGenerated]
	private sealed class _FadeIn_d__18 : IEnumerator<object> // TypeDefIndex: 1588
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NotificationPopup __4__this; // 0x20
		private float _elapsed_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FadeIn_d__18(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018087C390-0x000000018087C620
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018087C620-0x000000018087C660
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__19 : IEnumerator<object> // TypeDefIndex: 1589
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NotificationPopup __4__this; // 0x20
		private float _elapsed_5__2; // 0x28
		private float _startAlpha_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FadeOut_d__19(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x000000018087C660-0x000000018087C970
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018087C970-0x000000018087C9B0
	}

	// Constructors
	public NotificationPopup(); // 0x000000018087C0F0-0x000000018087C150

	// Methods
	private void Awake(); // 0x000000018087AC80-0x000000018087B140
	public void ShowSuccess(string title, string message, Sprite rewardSprite, string rewardText); // 0x000000018087B140-0x000000018087B580
	public void ShowError(string title, string message); // 0x000000018087B580-0x000000018087B700
	public void ShowMessage(string title, string message); // 0x000000018087B700-0x000000018087B870
	private void Show(string title, string message, bool isSuccess); // 0x000000018087B870-0x000000018087BC60
	public void Close(); // 0x000000018087BC60-0x000000018087BD70
	[IteratorStateMachine(typeof(_FadeIn_d__18))]
	private IEnumerator FadeIn(); // 0x000000018087BD70-0x000000018087BE10
	[IteratorStateMachine(typeof(_FadeOut_d__19))]
	private IEnumerator FadeOut(); // 0x000000018087BE10-0x000000018087BEB0
	[IteratorStateMachine(typeof(_AutoClose_d__20))]
	private IEnumerator AutoClose(); // 0x000000018087BEB0-0x000000018087BF50
	private void PlaySound(AudioClip clip); // 0x000000018087BF50-0x000000018087C0F0
}

