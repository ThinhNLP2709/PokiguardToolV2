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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class GiftCodePanelController : MonoBehaviour // TypeDefIndex: 1634
{
	// Fields
	public const string PANEL_KEY = "PanelGiftCode"; // Metadata: 0x005F00C9
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
	private sealed class _CloseAfterDelay_d__22 : IEnumerator<object> // TypeDefIndex: 1635
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public GiftCodePanelController __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CloseAfterDelay_d__22(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001808A57D0-0x00000001808A59F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808A59F0-0x00000001808A5A30
	}

	[CompilerGenerated]
	private sealed class _RedeemGiftCode_d__19 : IEnumerator<object> // TypeDefIndex: 1636
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GiftCodePanelController __4__this; // 0x20
		public string code; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RedeemGiftCode_d__19(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001808A5A30-0x00000001808A5E60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808A5E60-0x00000001808A5EA0
	}

	// Constructors
	public GiftCodePanelController(); // 0x00000001808A55D0-0x00000001808A5630

	// Methods
	private void OnDisable(); // 0x00000001808A3A80-0x00000001808A3B80
	private void Awake(); // 0x00000001808A3B80-0x00000001808A4110
	public void OpenPanel(); // 0x00000001808A4110-0x00000001808A44B0
	public void ClosePanel(); // 0x00000001808A44B0-0x00000001808A4600
	private void OnRedeemClicked(); // 0x00000001808A4600-0x00000001808A47E0
	[IteratorStateMachine(typeof(_RedeemGiftCode_d__19))]
	private IEnumerator RedeemGiftCode(string code); // 0x00000001808A47E0-0x00000001808A48F0
	private void OnRedeemSuccess(string response); // 0x00000001808A48F0-0x00000001808A4D50
	private void OnRedeemError(string error); // 0x00000001808A4D50-0x00000001808A4F80
	[IteratorStateMachine(typeof(_CloseAfterDelay_d__22))]
	private IEnumerator CloseAfterDelay(float delay); // 0x00000001808A4F80-0x00000001808A5040
	private void ShowMessage(string message, Color color); // 0x00000001808A5040-0x00000001808A5190
	private void OnDestroy(); // 0x00000001808A5190-0x00000001808A55D0
	[CompilerGenerated]
	private void _OpenPanel_b__16_0(); // 0x00000001808A5630-0x00000001808A5640
	[CompilerGenerated]
	private void _ClosePanel_b__17_0(); // 0x00000001808A5640-0x00000001808A57D0
}

