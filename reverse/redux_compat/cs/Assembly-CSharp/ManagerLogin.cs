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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerLogin : MonoBehaviour // TypeDefIndex: 1389
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
	private const string SAVED_USERNAME_KEY = "SavedUsername"; // Metadata: 0x0064D658
	private const string SAVED_PASSWORD_KEY = "SavedPassword"; // Metadata: 0x0064D666
	private const string REMEMBER_ME_KEY = "RememberMe"; // Metadata: 0x0064D674
	private const string ENCRYPTION_KEY = "MySecretKey12345"; // Metadata: 0x0064D67F
	private static readonly string[] VOLATILE_PREF_KEYS; // 0x00

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1390
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static UnityAction __9__13_0; // 0x08

		// Constructors
		static __c(); // 0x000000018054EE40-0x000000018054EEB0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _Start_b__13_0(); // 0x000000018054DFA0-0x000000018054E030
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass29_0 // TypeDefIndex: 1391
	{
		// Fields
		public bool accepted; // 0x10

		// Constructors
		public __c__DisplayClass29_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _TermsThenLoadGame_b__0(bool ok); // 0x00000001804C2E20-0x00000001804C2E30
	}

	[CompilerGenerated]
	private sealed class _AutoLoginWithCredentials_d__23 : IEnumerator<object> // TypeDefIndex: 1392
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _AutoLoginWithCredentials_d__23(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180549750-0x0000000180549840
		private bool MoveNext(); // 0x0000000180548C90-0x0000000180549710
		private void __m__Finally1(); // 0x0000000180549840-0x0000000180549890
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180549710-0x0000000180549750
	}

	[CompilerGenerated]
	private sealed class _CheckAutoLogin_d__22 : IEnumerator<object> // TypeDefIndex: 1393
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerLogin __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CheckAutoLogin_d__22(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180549890-0x0000000180549B90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180549B90-0x0000000180549BD0
	}

	[CompilerGenerated]
	private sealed class _HideMessageAfterDelay_d__37 : IEnumerator<object> // TypeDefIndex: 1394
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public float delay; // 0x20
		public ManagerLogin __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _HideMessageAfterDelay_d__37(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180549F30-0x000000018054A040
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054A040-0x000000018054A080
	}

	[CompilerGenerated]
	private sealed class _LoadGameSceneAsync_d__30 : IEnumerator<object> // TypeDefIndex: 1395
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerLogin __4__this; // 0x20
		private AsyncOperation _op_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadGameSceneAsync_d__30(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x000000018054A4F0-0x000000018054A670
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054A670-0x000000018054A6B0
	}

	[CompilerGenerated]
	private sealed class _LoginCoroutine_d__27 : IEnumerator<object> // TypeDefIndex: 1396
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerLogin __4__this; // 0x20
		private LoginRequest _loginData_5__2; // 0x28
		private UnityWebRequest _request_5__3; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoginCoroutine_d__27(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x000000018054CCA0-0x000000018054CD90
		private bool MoveNext(); // 0x000000018054C090-0x000000018054CC60
		private void __m__Finally1(); // 0x000000018054CD90-0x000000018054CDE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054CC60-0x000000018054CCA0
	}

	[CompilerGenerated]
	private sealed class _TermsThenLoadGame_d__29 : IEnumerator<object> // TypeDefIndex: 1397
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerLogin __4__this; // 0x20
		public int userId; // 0x28
		private __c__DisplayClass29_0 __8__1; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _TermsThenLoadGame_d__29(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802FB8A0-0x00000001802FB8D0
		private bool MoveNext(); // 0x000000018054D580-0x000000018054D860
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018054D860-0x000000018054D8A0
	}

	// Constructors
	public ManagerLogin(); // 0x00000001805309A0-0x00000001805309B0
	static ManagerLogin(); // 0x0000000180530000-0x00000001805309A0

	// Methods
	private void Start(); // 0x000000018052F970-0x000000018052FB50
	private string Encrypt(string plainText); // 0x000000018052E1A0-0x000000018052E760
	private string Decrypt(string cipherText); // 0x000000018052DB60-0x000000018052E1A0
	private bool IsBase64String(string value); // 0x000000018052F250-0x000000018052F2D0
	private void LoadSavedCredentials(); // 0x000000018052F340-0x000000018052F560
	private void SaveCredentials(string username, string password); // 0x000000018052F6C0-0x000000018052F830
	private void ClearSavedPassword(); // 0x000000018052DB00-0x000000018052DB60
	public static void ClearSavedPasswordAfterChange(); // 0x000000018052DAA0-0x000000018052DB00
	private void ClearSavedCredentials(); // 0x000000018052DA30-0x000000018052DAA0
	[IteratorStateMachine(typeof(_CheckAutoLogin_d__22))]
	private IEnumerator CheckAutoLogin(); // 0x000000018052D9C0-0x000000018052DA30
	[IteratorStateMachine(typeof(_AutoLoginWithCredentials_d__23))]
	private IEnumerator AutoLoginWithCredentials(string username, string password); // 0x000000018052D910-0x000000018052D9C0
	private void HandleAutoLoginFailure(string message); // 0x000000018052EF10-0x000000018052EFC0
	private void HandleAutoLoginError(UnityWebRequest request); // 0x000000018052ECA0-0x000000018052EF10
	private void Login(); // 0x000000018052F5D0-0x000000018052F6C0
	[IteratorStateMachine(typeof(_LoginCoroutine_d__27))]
	private IEnumerator LoginCoroutine(); // 0x000000018052F560-0x000000018052F5D0
	private void HandleLoginError(UnityWebRequest request); // 0x000000018052EFC0-0x000000018052F1D0
	[IteratorStateMachine(typeof(_TermsThenLoadGame_d__29))]
	private IEnumerator TermsThenLoadGame(int userId); // 0x000000018052FD60-0x000000018052FDE0
	[IteratorStateMachine(typeof(_LoadGameSceneAsync_d__30))]
	private IEnumerator LoadGameSceneAsync(); // 0x000000018052F2D0-0x000000018052F340
	private void SyncServerTime(UnityWebRequest request, long jsonServerTimestamp); // 0x000000018052FB50-0x000000018052FD60
	private string GetDeviceId(); // 0x00000001804B9950-0x00000001804B9960
	private string GetDeviceName(); // 0x000000018052EC30-0x000000018052ECA0
	private void UpdateUserData(UserDTO user); // 0x000000018052FDE0-0x0000000180530000
	private void ForceCleanOldData(); // 0x000000018052E7F0-0x000000018052EC30
	[IteratorStateMachine(typeof(_HideMessageAfterDelay_d__37))]
	private IEnumerator HideMessageAfterDelay(float delay); // 0x000000018052F1D0-0x000000018052F250
	private string ExtractServerMessage(string responseText, string fallback); // 0x000000018052E760-0x000000018052E7F0
	private void ShowError(string message); // 0x000000018052F830-0x000000018052F970
}

