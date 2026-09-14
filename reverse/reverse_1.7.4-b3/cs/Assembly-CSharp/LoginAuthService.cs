/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class LoginAuthService // TypeDefIndex: 1025
{
	// Nested types
	[CompilerGenerated]
	private sealed class _Login_d__2 : IEnumerator<object> // TypeDefIndex: 1026
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string user; // 0x20
		public string pass; // 0x28
		public bool rememberMe; // 0x30
		public Action<AuthResult> cb; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Login_d__2(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180637D50-0x00000001806381D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806381D0-0x0000000180638210
	}

	[CompilerGenerated]
	private sealed class _LoginWithToken_d__3 : IEnumerator<object> // TypeDefIndex: 1027
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string token; // 0x20
		public Action<AuthResult> cb; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoginWithToken_d__3(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180638210-0x0000000180638630
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180638630-0x0000000180638670
	}

	[CompilerGenerated]
	private sealed class _Register_d__4 : IEnumerator<object> // TypeDefIndex: 1028
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string user; // 0x20
		public string name; // 0x28
		public string pass; // 0x30
		public Action<AuthResult> cb; // 0x38

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Register_d__4(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180638670-0x0000000180638B40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180638B40-0x0000000180638B80
	}

	[CompilerGenerated]
	private sealed class _Send_d__5 : IEnumerator<object> // TypeDefIndex: 1029
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string url; // 0x20
		public string json; // 0x28
		public string tag; // 0x30
		public Action<AuthResult> cb; // 0x38
		public bool tokenLogin; // 0x40
		private AuthResult _res_5__2; // 0x48
		private UnityWebRequest _req_5__3; // 0x50

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Send_d__5(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180638B80-0x0000000180638D30
		private bool MoveNext(); // 0x0000000180638D30-0x0000000180639800
		private void __m__Finally1(); // 0x0000000180639800-0x0000000180639860
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180639860-0x00000001806398A0
	}

	[CompilerGenerated]
	private sealed class _SendRegister_d__6 : IEnumerator<object> // TypeDefIndex: 1030
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public string url; // 0x20
		public string json; // 0x28
		public Action<AuthResult> cb; // 0x30
		private AuthResult _res_5__2; // 0x38
		private UnityWebRequest _req_5__3; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SendRegister_d__6(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001806398A0-0x0000000180639A50
		private bool MoveNext(); // 0x0000000180639A50-0x000000018063A430
		private void __m__Finally1(); // 0x000000018063A430-0x000000018063A490
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018063A490-0x000000018063A4D0
	}

	// Methods
	[IteratorStateMachine(typeof(_Login_d__2))]
	public static IEnumerator Login(string user, string pass, bool rememberMe, Action<AuthResult> cb); // 0x00000001806369A0-0x0000000180636B20
	[IteratorStateMachine(typeof(_LoginWithToken_d__3))]
	public static IEnumerator LoginWithToken(string token, Action<AuthResult> cb); // 0x0000000180636B20-0x0000000180636C30
	[IteratorStateMachine(typeof(_Register_d__4))]
	public static IEnumerator Register(string name, string user, string pass, Action<AuthResult> cb); // 0x0000000180636C30-0x0000000180636E00
	[IteratorStateMachine(typeof(_Send_d__5))]
	private static IEnumerator Send(string tag, string url, string json, bool tokenLogin, Action<AuthResult> cb); // 0x0000000180636E00-0x0000000180636FE0
	[IteratorStateMachine(typeof(_SendRegister_d__6))]
	private static IEnumerator SendRegister(string url, string json, Action<AuthResult> cb); // 0x0000000180636FE0-0x0000000180637140
	private static void Classify(AuthResult res, string text, bool tokenLogin, UnityWebRequest req); // 0x0000000180637140-0x0000000180637580
	private static string DefaultMessage(string code, int retryAfterSec); // 0x0000000180637580-0x0000000180637A80
	private static int ParseRetryAfter(string raw); // 0x0000000180637A80-0x0000000180637D30
	private static string SafeHeader(UnityWebRequest req, string name); // 0x0000000180637D30-0x0000000180637D50
}

