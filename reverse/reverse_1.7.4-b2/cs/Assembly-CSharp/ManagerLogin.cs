/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerLogin : MonoBehaviour // TypeDefIndex: 1633
{
	// Fields
	public InputField usernameInput; // 0x20
	public InputField passwordInput; // 0x28
	public Button loginBtn; // 0x30
	public GameObject LoadingPanel; // 0x38
	public UnityEngine.UI.Text errorText; // 0x40
	public Button registerOpenButton; // 0x48
	[Header("Debug")]
	public UnityEngine.UI.Text versionText; // 0x50
	[Header("Auto Login")]
	public float autoLoginDelay; // 0x58
	public Toggle rememberMeToggle; // 0x60
	private const string SAVED_USERNAME_KEY = "SavedUsername"; // Metadata: 0x0068D541
	private const string SAVED_PASSWORD_KEY = "SavedPassword"; // Metadata: 0x0068D54F
	private const string REMEMBER_ME_KEY = "RememberMe"; // Metadata: 0x0068D55D
	private const string ENCRYPTION_KEY = "MySecretKey12345"; // Metadata: 0x0068D568
	private static readonly string[] VOLATILE_PREF_KEYS; // 0x00

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1634
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static UnityAction __9__13_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180644870-0x00000001806448E0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Start_b__13_0(); // 0x0000000180643C40-0x0000000180643CD0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass29_0 // TypeDefIndex: 1635
	{
		// Fields
		public bool accepted; // 0x10

		// Constructors
		public __c__DisplayClass29_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _TermsThenLoadGame_b__0(bool ok); // 0x0000000180300940-0x0000000180300950
	}

	[CompilerGenerated]
	private sealed class _AutoLoginWithCredentials_d__23 : IEnumerator<object> // TypeDefIndex: 1636
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string username; // 0x20
		public string password; // 0x28
		public ManagerLogin __4__this; // 0x30
		private LoginRequest _loginData_5__2; // 0x38
		private UnityWebRequest _request_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _AutoLoginWithCredentials_d__23(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018063F2F0-0x000000018063F3E0
		private bool MoveNext(); // 0x000000018063E730-0x000000018063F2B0
		private void __m__Finally1(); // 0x000000018063F3E0-0x000000018063F430
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018063F2B0-0x000000018063F2F0
	}

	[CompilerGenerated]
	private sealed class _CheckAutoLogin_d__22 : IEnumerator<object> // TypeDefIndex: 1637
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerLogin __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CheckAutoLogin_d__22(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018063F430-0x000000018063F730
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018063F730-0x000000018063F770
	}

	[CompilerGenerated]
	private sealed class _HideMessageAfterDelay_d__37 : IEnumerator<object> // TypeDefIndex: 1638
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerLogin __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _HideMessageAfterDelay_d__37(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x000000018063FAD0-0x000000018063FBE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018063FBE0-0x000000018063FC20
	}

	[CompilerGenerated]
	private sealed class _LoadGameSceneAsync_d__30 : IEnumerator<object> // TypeDefIndex: 1639
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerLogin __4__this; // 0x20
		private AsyncOperation _op_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadGameSceneAsync_d__30(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x0000000180640090-0x0000000180640210
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180640210-0x0000000180640250
	}

	[CompilerGenerated]
	private sealed class _LoginCoroutine_d__27 : IEnumerator<object> // TypeDefIndex: 1640
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerLogin __4__this; // 0x20
		private LoginRequest _loginData_5__2; // 0x28
		private UnityWebRequest _request_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoginCoroutine_d__27(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180642A00-0x0000000180642AF0
		private bool MoveNext(); // 0x0000000180641CE0-0x00000001806429C0
		private void __m__Finally1(); // 0x0000000180642AF0-0x0000000180642B40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806429C0-0x0000000180642A00
	}

	[CompilerGenerated]
	private sealed class _TermsThenLoadGame_d__29 : IEnumerator<object> // TypeDefIndex: 1641
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerLogin __4__this; // 0x20
		public int userId; // 0x28
		private __c__DisplayClass29_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _TermsThenLoadGame_d__29(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803007C0-0x00000001803007F0
		private bool MoveNext(); // 0x00000001806432E0-0x00000001806435C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806435C0-0x0000000180643600
	}

	// Constructors
	public ManagerLogin(); // 0x0000000180624770-0x0000000180624780
	static ManagerLogin(); // 0x0000000180623DD0-0x0000000180624770

	// Methods
	private void Start(); // 0x0000000180623740-0x0000000180623920
	private string Encrypt(string plainText); // 0x0000000180621F70-0x0000000180622530
	private string Decrypt(string cipherText); // 0x0000000180621930-0x0000000180621F70
	private bool IsBase64String(string value); // 0x0000000180623020-0x00000001806230A0
	private void LoadSavedCredentials(); // 0x0000000180623110-0x0000000180623330
	private void SaveCredentials(string username, string password); // 0x0000000180623490-0x0000000180623600
	private void ClearSavedPassword(); // 0x00000001806218D0-0x0000000180621930
	public static void ClearSavedPasswordAfterChange(); // 0x0000000180621870-0x00000001806218D0
	private void ClearSavedCredentials(); // 0x0000000180621800-0x0000000180621870
	[IteratorStateMachine(typeof(_CheckAutoLogin_d__22))]
	private IEnumerator CheckAutoLogin(); // 0x0000000180621790-0x0000000180621800
	[IteratorStateMachine(typeof(_AutoLoginWithCredentials_d__23))]
	private IEnumerator AutoLoginWithCredentials(string username, string password); // 0x00000001806216E0-0x0000000180621790
	private void HandleAutoLoginFailure(string message); // 0x0000000180622CE0-0x0000000180622D90
	private void HandleAutoLoginError(UnityWebRequest request); // 0x0000000180622A70-0x0000000180622CE0
	private void Login(); // 0x00000001806233A0-0x0000000180623490
	[IteratorStateMachine(typeof(_LoginCoroutine_d__27))]
	private IEnumerator LoginCoroutine(); // 0x0000000180623330-0x00000001806233A0
	private void HandleLoginError(UnityWebRequest request); // 0x0000000180622D90-0x0000000180622FA0
	[IteratorStateMachine(typeof(_TermsThenLoadGame_d__29))]
	private IEnumerator TermsThenLoadGame(int userId); // 0x0000000180623B30-0x0000000180623BB0
	[IteratorStateMachine(typeof(_LoadGameSceneAsync_d__30))]
	private IEnumerator LoadGameSceneAsync(); // 0x00000001806230A0-0x0000000180623110
	private void SyncServerTime(UnityWebRequest request, long jsonServerTimestamp); // 0x0000000180623920-0x0000000180623B30
	private string GetDeviceId(); // 0x00000001805B5470-0x00000001805B5480
	private string GetDeviceName(); // 0x0000000180622A00-0x0000000180622A70
	private void UpdateUserData(UserDTO user); // 0x0000000180623BB0-0x0000000180623DD0
	private void ForceCleanOldData(); // 0x00000001806225C0-0x0000000180622A00
	[IteratorStateMachine(typeof(_HideMessageAfterDelay_d__37))]
	private IEnumerator HideMessageAfterDelay(float delay); // 0x0000000180622FA0-0x0000000180623020
	private string ExtractServerMessage(string responseText, string fallback); // 0x0000000180622530-0x00000001806225C0
	private void ShowError(string message); // 0x0000000180623600-0x0000000180623740
}

