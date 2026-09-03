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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class TermsGate // TypeDefIndex: 1198
{
	// Fields
	public const string PANEL_KEY = "PanelTerms"; // Metadata: 0x0064D4B4
	private const int TIMEOUT_SECONDS = 10; // Metadata: 0x0064D4BF
	private const int CONTENT_RETRY = 2; // Metadata: 0x0064D4C0
	private const int STATUS_RETRY = 3; // Metadata: 0x0064D4C1
	private const string PREF_LAST_ACCEPTED = "TermsAcceptedVersion"; // Metadata: 0x0064D4C2
	[CompilerGenerated]
	private static TermsContentData _Content_k__BackingField; // 0x00

	// Properties
	public static TermsContentData Content { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804D03D0-0x00000001804D0410 0x00000001804D0410-0x00000001804D0470

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass9_0 // TypeDefIndex: 1199
	{
		// Fields
		public TermsStatusData status; // 0x10
		public bool panelReady; // 0x18
		public bool? decision; // 0x19
		public int userId; // 0x1C
		public Action<bool> __9__2; // 0x20

		// Constructors
		public __c__DisplayClass9_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _EnsureAccepted_b__0(TermsStatusData s); // 0x00000001803780D0-0x00000001803780E0
		internal void _EnsureAccepted_b__1(GameObject panel); // 0x00000001804D7A30-0x00000001804D7C50
		internal void _EnsureAccepted_b__2(bool accepted); // 0x00000001804D7C50-0x00000001804D7C80
	}

	[CompilerGenerated]
	private sealed class _EnsureAccepted_d__9 : IEnumerator<object> // TypeDefIndex: 1200
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		private __c__DisplayClass9_0 __8__1; // 0x28
		public Action<bool> onDone; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _EnsureAccepted_d__9(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
		private bool MoveNext(); // 0x00000001804D2A70-0x00000001804D3090
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D3090-0x00000001804D30D0
	}

	[CompilerGenerated]
	private sealed class _FetchContent_d__11 : IEnumerator<object> // TypeDefIndex: 1201
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private int _attempt_5__2; // 0x20
		private UnityWebRequest _req_5__3; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FetchContent_d__11(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804D4740-0x00000001804D4820
		private bool MoveNext(); // 0x00000001804D4190-0x00000001804D4700
		private void __m__Finally1(); // 0x00000001804D4820-0x00000001804D4870
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D4700-0x00000001804D4740
	}

	[CompilerGenerated]
	private sealed class _FetchStatus_d__10 : IEnumerator<object> // TypeDefIndex: 1202
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<TermsStatusData> done; // 0x20
		public int userId; // 0x28
		private string _token_5__2; // 0x30
		private int _attempt_5__3; // 0x38
		private TermsStatusData _parsed_5__4; // 0x40
		private bool _retryable_5__5; // 0x48
		private UnityWebRequest _req_5__6; // 0x50

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _FetchStatus_d__10(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804D4F70-0x00000001804D5080
		private bool MoveNext(); // 0x00000001804D4870-0x00000001804D4F30
		private void __m__Finally1(); // 0x00000001804D5080-0x00000001804D50D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D4F30-0x00000001804D4F70
	}

	[CompilerGenerated]
	private sealed class _RefetchContent_d__13 : IEnumerator<object> // TypeDefIndex: 1203
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<TermsContentData> done; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _RefetchContent_d__13(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804D66F0-0x00000001804D67D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D67D0-0x00000001804D6810
	}

	[CompilerGenerated]
	private sealed class _SendAccept_d__12 : IEnumerator<object> // TypeDefIndex: 1204
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<bool, string> done; // 0x20
		public int termsVersion; // 0x28
		public int userId; // 0x2C
		private UnityWebRequest _req_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SendAccept_d__12(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001804D6E30-0x00000001804D6F10
		private bool MoveNext(); // 0x00000001804D6810-0x00000001804D6DF0
		private void __m__Finally1(); // 0x00000001804D6F10-0x00000001804D6F60
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804D6DF0-0x00000001804D6E30
	}

	// Methods
	[IteratorStateMachine(typeof(_EnsureAccepted_d__9))]
	public static IEnumerator EnsureAccepted(int userId, Action<bool> onDone); // 0x00000001804D0180-0x00000001804D0200
	[IteratorStateMachine(typeof(_FetchStatus_d__10))]
	private static IEnumerator FetchStatus(int userId, Action<TermsStatusData> done); // 0x00000001804D0250-0x00000001804D02D0
	[IteratorStateMachine(typeof(_FetchContent_d__11))]
	private static IEnumerator FetchContent(); // 0x00000001804D0200-0x00000001804D0250
	[IteratorStateMachine(typeof(_SendAccept_d__12))]
	public static IEnumerator SendAccept(int userId, int termsVersion, Action<bool, string> done); // 0x00000001804D0340-0x00000001804D03D0
	[IteratorStateMachine(typeof(_RefetchContent_d__13))]
	public static IEnumerator RefetchContent(Action<TermsContentData> done); // 0x00000001804D02D0-0x00000001804D0340
}

