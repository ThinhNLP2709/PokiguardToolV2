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

public class GiftCodePanelController : MonoBehaviour // TypeDefIndex: 1233
{
	// Fields
	public const string PANEL_KEY = "PanelGiftCode"; // Metadata: 0x0068CE2E
	[Header("UI References")]
	public GameObject giftCodePanel; // 0x20
	public Button openButton; // 0x28
	[SerializeField]
	private Button closeButton; // 0x30
	[SerializeField]
	private InputField codeInputField; // 0x38
	[SerializeField]
	private Button redeemButton; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text messageText; // 0x48
	[Header("Animation Settings")]
	[SerializeField]
	private float animationDuration; // 0x50
	[SerializeField]
	private LeanTweenType easeType; // 0x54
	private CanvasGroup canvasGroup; // 0x58
	private bool isAnimating; // 0x60
	private bool isProcessing; // 0x61
	[Header("Panel Notice")]
	public GameObject panelNotice; // 0x68
	public UnityEngine.UI.Text txtNoticeMessage; // 0x70

	// Nested types
	[CompilerGenerated]
	private sealed class _CloseAfterDelay_d__22 : IEnumerator<object> // TypeDefIndex: 1234
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public GiftCodePanelController __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CloseAfterDelay_d__22(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A33A0-0x00000001805A3520
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A3520-0x00000001805A3560
	}

	[CompilerGenerated]
	private sealed class _RedeemGiftCode_d__19 : IEnumerator<object> // TypeDefIndex: 1235
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GiftCodePanelController __4__this; // 0x20
		public string code; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RedeemGiftCode_d__19(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805A49E0-0x00000001805A4C50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805A4C50-0x00000001805A4C90
	}

	// Constructors
	public GiftCodePanelController(); // 0x000000018058E8C0-0x000000018058E8E0

	// Methods
	private void OnDisable(); // 0x000000018058DD80-0x000000018058DE00
	private void Awake(); // 0x000000018058D7F0-0x000000018058DA40
	public void OpenPanel(); // 0x000000018058E420-0x000000018058E610
	public void ClosePanel(); // 0x000000018058DAC0-0x000000018058DBA0
	private void OnRedeemClicked(); // 0x000000018058DE00-0x000000018058DF50
	[IteratorStateMachine(typeof(_RedeemGiftCode_d__19))]
	private IEnumerator RedeemGiftCode(string code); // 0x000000018058E610-0x000000018058E6A0
	private void OnRedeemSuccess(string response); // 0x000000018058E130-0x000000018058E420
	private void OnRedeemError(string error); // 0x000000018058DF50-0x000000018058E130
	[IteratorStateMachine(typeof(_CloseAfterDelay_d__22))]
	private IEnumerator CloseAfterDelay(float delay); // 0x000000018058DA40-0x000000018058DAC0
	private void ShowMessage(string message, Color color); // 0x000000018058E6A0-0x000000018058E770
	private void OnDestroy(); // 0x000000018058DBA0-0x000000018058DD80
	[CompilerGenerated]
	private void _OpenPanel_b__16_0(); // 0x000000018058E8B0-0x000000018058E8C0
	[CompilerGenerated]
	private void _ClosePanel_b__17_0(); // 0x000000018058E770-0x000000018058E8B0
}

