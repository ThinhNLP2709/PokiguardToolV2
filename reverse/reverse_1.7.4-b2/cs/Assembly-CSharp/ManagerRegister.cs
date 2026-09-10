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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerRegister : MonoBehaviour // TypeDefIndex: 1712
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
	private sealed class _CloseAfterDelay_d__18 : IEnumerator<object> // TypeDefIndex: 1713
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerRegister __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CloseAfterDelay_d__18(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180667830-0x0000000180667950
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180667950-0x0000000180667990
	}

	[CompilerGenerated]
	private sealed class _RegisterCoroutine_d__15 : IEnumerator<object> // TypeDefIndex: 1714
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerRegister __4__this; // 0x20
		private RegisterRequest _registerData_5__2; // 0x28
		private UnityWebRequest _request_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RegisterCoroutine_d__15(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018066D9A0-0x000000018066DA90
		private bool MoveNext(); // 0x000000018066D250-0x000000018066D960
		private void __m__Finally1(); // 0x000000018066DA90-0x000000018066DAE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018066D960-0x000000018066D9A0
	}

	// Constructors
	public ManagerRegister(); // 0x000000018065D580-0x000000018065D590

	// Methods
	private void Start(); // 0x000000018065D060-0x000000018065D1D0
	public void OpenRegisterPanel(); // 0x000000018065CD30-0x000000018065CDC0
	public void ClosePanel(); // 0x000000018065C660-0x000000018065C6F0
	private void OnRegisterClicked(); // 0x000000018065CCA0-0x000000018065CD30
	private bool ValidateInputs(); // 0x000000018065D1D0-0x000000018065D580
	[IteratorStateMachine(typeof(_RegisterCoroutine_d__15))]
	private IEnumerator RegisterCoroutine(); // 0x000000018065CDC0-0x000000018065CE30
	private void HandleSuccessResponse(string responseText, string username); // 0x000000018065C8A0-0x000000018065CC10
	private void HandleErrorResponse(long responseCode, string responseText); // 0x000000018065C7B0-0x000000018065C8A0
	[IteratorStateMachine(typeof(_CloseAfterDelay_d__18))]
	private IEnumerator CloseAfterDelay(float delay); // 0x000000018065C5E0-0x000000018065C660
	private void AutoFillLoginUsername(string username); // 0x000000018065C3F0-0x000000018065C4D0
	private string GetOrCreateDeviceId(); // 0x000000018065C6F0-0x000000018065C7B0
	private void ShowError(string message); // 0x000000018065CE30-0x000000018065CF70
	private void ShowSuccess(string message); // 0x000000018065CF70-0x000000018065D060
	private void HideErrorMessage(); // 0x000000018065CC10-0x000000018065CCA0
	private void ClearAllInputs(); // 0x000000018065C4D0-0x000000018065C5E0
}

