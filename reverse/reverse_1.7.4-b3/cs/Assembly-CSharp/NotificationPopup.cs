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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class NotificationPopup : MonoBehaviour // TypeDefIndex: 1584
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
	private sealed class _AutoClose_d__20 : IEnumerator<object> // TypeDefIndex: 1585
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180879E70-0x000000018087A070
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018087A070-0x000000018087A0B0
	}

	[CompilerGenerated]
	private sealed class _FadeIn_d__18 : IEnumerator<object> // TypeDefIndex: 1586
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018087A0B0-0x000000018087A340
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018087A340-0x000000018087A380
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__19 : IEnumerator<object> // TypeDefIndex: 1587
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x000000018087A380-0x000000018087A690
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018087A690-0x000000018087A6D0
	}

	// Constructors
	public NotificationPopup(); // 0x0000000180879E10-0x0000000180879E70

	// Methods
	private void Awake(); // 0x00000001808789A0-0x0000000180878E60
	public void ShowSuccess(string title, string message, Sprite rewardSprite, string rewardText); // 0x0000000180878E60-0x00000001808792A0
	public void ShowError(string title, string message); // 0x00000001808792A0-0x0000000180879420
	public void ShowMessage(string title, string message); // 0x0000000180879420-0x0000000180879590
	private void Show(string title, string message, bool isSuccess); // 0x0000000180879590-0x0000000180879980
	public void Close(); // 0x0000000180879980-0x0000000180879A90
	[IteratorStateMachine(typeof(_FadeIn_d__18))]
	private IEnumerator FadeIn(); // 0x0000000180879A90-0x0000000180879B30
	[IteratorStateMachine(typeof(_FadeOut_d__19))]
	private IEnumerator FadeOut(); // 0x0000000180879B30-0x0000000180879BD0
	[IteratorStateMachine(typeof(_AutoClose_d__20))]
	private IEnumerator AutoClose(); // 0x0000000180879BD0-0x0000000180879C70
	private void PlaySound(AudioClip clip); // 0x0000000180879C70-0x0000000180879E10
}

