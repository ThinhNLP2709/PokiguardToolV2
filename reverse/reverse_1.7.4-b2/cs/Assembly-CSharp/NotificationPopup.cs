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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class NotificationPopup : MonoBehaviour // TypeDefIndex: 1183
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
	private sealed class _AutoClose_d__20 : IEnumerator<object> // TypeDefIndex: 1184
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NotificationPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AutoClose_d__20(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018058B410-0x000000018058B540
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018058B540-0x000000018058B580
	}

	[CompilerGenerated]
	private sealed class _FadeIn_d__18 : IEnumerator<object> // TypeDefIndex: 1185
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NotificationPopup __4__this; // 0x20
		private float _elapsed_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FadeIn_d__18(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018058B760-0x000000018058B890
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018058B890-0x000000018058B8D0
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__19 : IEnumerator<object> // TypeDefIndex: 1186
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NotificationPopup __4__this; // 0x20
		private float _elapsed_5__2; // 0x28
		private float _startAlpha_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FadeOut_d__19(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018058B8D0-0x000000018058BA10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018058BA10-0x000000018058BA50
	}

	// Constructors
	public NotificationPopup(); // 0x000000018058A940-0x000000018058A960

	// Methods
	private void Awake(); // 0x000000018058A0C0-0x000000018058A2A0
	public void ShowSuccess(string title, string message, Sprite rewardSprite, string rewardText); // 0x000000018058A600-0x000000018058A780
	public void ShowError(string title, string message); // 0x000000018058A4A0-0x000000018058A550
	public void ShowMessage(string title, string message); // 0x000000018058A550-0x000000018058A600
	private void Show(string title, string message, bool isSuccess); // 0x000000018058A780-0x000000018058A940
	public void Close(); // 0x000000018058A2A0-0x000000018058A320
	[IteratorStateMachine(typeof(_FadeIn_d__18))]
	private IEnumerator FadeIn(); // 0x000000018058A320-0x000000018058A390
	[IteratorStateMachine(typeof(_FadeOut_d__19))]
	private IEnumerator FadeOut(); // 0x000000018058A390-0x000000018058A400
	[IteratorStateMachine(typeof(_AutoClose_d__20))]
	private IEnumerator AutoClose(); // 0x000000018058A050-0x000000018058A0C0
	private void PlaySound(AudioClip clip); // 0x000000018058A400-0x000000018058A4A0
}

