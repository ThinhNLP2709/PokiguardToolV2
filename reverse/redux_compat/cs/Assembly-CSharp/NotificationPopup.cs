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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class NotificationPopup : MonoBehaviour // TypeDefIndex: 985
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
	private sealed class _AutoClose_d__20 : IEnumerator<object> // TypeDefIndex: 986
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NotificationPopup __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AutoClose_d__20(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180492E20-0x0000000180492F50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180492F50-0x0000000180492F90
	}

	[CompilerGenerated]
	private sealed class _FadeIn_d__18 : IEnumerator<object> // TypeDefIndex: 987
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NotificationPopup __4__this; // 0x20
		private float _elapsed_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FadeIn_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804933A0-0x00000001804934D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804934D0-0x0000000180493510
	}

	[CompilerGenerated]
	private sealed class _FadeOut_d__19 : IEnumerator<object> // TypeDefIndex: 988
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public NotificationPopup __4__this; // 0x20
		private float _elapsed_5__2; // 0x28
		private float _startAlpha_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FadeOut_d__19(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180493510-0x0000000180493650
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180493650-0x0000000180493690
	}

	// Constructors
	public NotificationPopup(); // 0x0000000180492E00-0x0000000180492E20

	// Methods
	private void Awake(); // 0x0000000180492580-0x0000000180492760
	public void ShowSuccess(string title, string message, Sprite rewardSprite, string rewardText); // 0x0000000180492AC0-0x0000000180492C40
	public void ShowError(string title, string message); // 0x0000000180492960-0x0000000180492A10
	public void ShowMessage(string title, string message); // 0x0000000180492A10-0x0000000180492AC0
	private void Show(string title, string message, bool isSuccess); // 0x0000000180492C40-0x0000000180492E00
	public void Close(); // 0x0000000180492760-0x00000001804927E0
	[IteratorStateMachine(typeof(_FadeIn_d__18))]
	private IEnumerator FadeIn(); // 0x00000001804927E0-0x0000000180492850
	[IteratorStateMachine(typeof(_FadeOut_d__19))]
	private IEnumerator FadeOut(); // 0x0000000180492850-0x00000001804928C0
	[IteratorStateMachine(typeof(_AutoClose_d__20))]
	private IEnumerator AutoClose(); // 0x0000000180492510-0x0000000180492580
	private void PlaySound(AudioClip clip); // 0x00000001804928C0-0x0000000180492960
}

