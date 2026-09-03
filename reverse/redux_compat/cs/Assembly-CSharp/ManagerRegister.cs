/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerRegister : MonoBehaviour // TypeDefIndex: 1463
{
	// Fields
	[Header("UI References")]
	public GameObject registerPanel; // 0x20
	public InputField nameInput; // 0x28
	public InputField usernameInput; // 0x30
	public InputField passwordInput; // 0x38
	public InputField confirmPasswordInput; // 0x40
	public Button registerButton; // 0x48
	public Button closeButton; // 0x50
	public UnityEngine.UI.Text errorMessageText; // 0x58
	public GameObject loadingPanel; // 0x60
	[Header("Debug")]
	public bool enableDebugLogs; // 0x68

	// Nested types
	[CompilerGenerated]
	private sealed class _CloseAfterDelay_d__18 : IEnumerator<object> // TypeDefIndex: 1464
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerRegister __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CloseAfterDelay_d__18(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180559490-0x00000001805595B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805595B0-0x00000001805595F0
	}

	[CompilerGenerated]
	private sealed class _RegisterCoroutine_d__15 : IEnumerator<object> // TypeDefIndex: 1465
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRegister __4__this; // 0x20
		private RegisterRequest _registerData_5__2; // 0x28
		private UnityWebRequest _request_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RegisterCoroutine_d__15(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018055EE30-0x000000018055EF20
		private bool MoveNext(); // 0x000000018055E6E0-0x000000018055EDF0
		private void __m__Finally1(); // 0x000000018055EF20-0x000000018055EF70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018055EDF0-0x000000018055EE30
	}

	// Constructors
	public ManagerRegister(); // 0x0000000180551230-0x0000000180551240

	// Methods
	private void Start(); // 0x0000000180550D10-0x0000000180550E80
	public void OpenRegisterPanel(); // 0x00000001805509E0-0x0000000180550A70
	public void ClosePanel(); // 0x0000000180550310-0x00000001805503A0
	private void OnRegisterClicked(); // 0x0000000180550950-0x00000001805509E0
	private bool ValidateInputs(); // 0x0000000180550E80-0x0000000180551230
	[IteratorStateMachine(typeof(_RegisterCoroutine_d__15))]
	private IEnumerator RegisterCoroutine(); // 0x0000000180550A70-0x0000000180550AE0
	private void HandleSuccessResponse(string responseText, string username); // 0x0000000180550550-0x00000001805508C0
	private void HandleErrorResponse(long responseCode, string responseText); // 0x0000000180550460-0x0000000180550550
	[IteratorStateMachine(typeof(_CloseAfterDelay_d__18))]
	private IEnumerator CloseAfterDelay(float delay); // 0x0000000180550290-0x0000000180550310
	private void AutoFillLoginUsername(string username); // 0x00000001805500A0-0x0000000180550180
	private string GetOrCreateDeviceId(); // 0x00000001805503A0-0x0000000180550460
	private void ShowError(string message); // 0x0000000180550AE0-0x0000000180550C20
	private void ShowSuccess(string message); // 0x0000000180550C20-0x0000000180550D10
	private void HideErrorMessage(); // 0x00000001805508C0-0x0000000180550950
	private void ClearAllInputs(); // 0x0000000180550180-0x0000000180550290
}

