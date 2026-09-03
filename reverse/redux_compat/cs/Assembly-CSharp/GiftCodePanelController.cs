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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class GiftCodePanelController : MonoBehaviour // TypeDefIndex: 1034
{
	// Fields
	public const string PANEL_KEY = "PanelGiftCode"; // Metadata: 0x0064D2D7
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
	private sealed class _CloseAfterDelay_d__22 : IEnumerator<object> // TypeDefIndex: 1035
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public GiftCodePanelController __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CloseAfterDelay_d__22(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804A8AD0-0x00000001804A8C50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804A8C50-0x00000001804A8C90
	}

	[CompilerGenerated]
	private sealed class _RedeemGiftCode_d__19 : IEnumerator<object> // TypeDefIndex: 1036
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GiftCodePanelController __4__this; // 0x20
		public string code; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RedeemGiftCode_d__19(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804A9C30-0x00000001804A9EA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804A9EA0-0x00000001804A9EE0
	}

	// Constructors
	public GiftCodePanelController(); // 0x0000000180496BC0-0x0000000180496BE0

	// Methods
	private void OnDisable(); // 0x0000000180496080-0x0000000180496100
	private void Awake(); // 0x0000000180495AF0-0x0000000180495D40
	public void OpenPanel(); // 0x0000000180496720-0x0000000180496910
	public void ClosePanel(); // 0x0000000180495DC0-0x0000000180495EA0
	private void OnRedeemClicked(); // 0x0000000180496100-0x0000000180496250
	[IteratorStateMachine(typeof(_RedeemGiftCode_d__19))]
	private IEnumerator RedeemGiftCode(string code); // 0x0000000180496910-0x00000001804969A0
	private void OnRedeemSuccess(string response); // 0x0000000180496430-0x0000000180496720
	private void OnRedeemError(string error); // 0x0000000180496250-0x0000000180496430
	[IteratorStateMachine(typeof(_CloseAfterDelay_d__22))]
	private IEnumerator CloseAfterDelay(float delay); // 0x0000000180495D40-0x0000000180495DC0
	private void ShowMessage(string message, Color color); // 0x00000001804969A0-0x0000000180496A70
	private void OnDestroy(); // 0x0000000180495EA0-0x0000000180496080
	[CompilerGenerated]
	private void _OpenPanel_b__16_0(); // 0x0000000180496BB0-0x0000000180496BC0
	[CompilerGenerated]
	private void _ClosePanel_b__17_0(); // 0x0000000180496A70-0x0000000180496BB0
}

