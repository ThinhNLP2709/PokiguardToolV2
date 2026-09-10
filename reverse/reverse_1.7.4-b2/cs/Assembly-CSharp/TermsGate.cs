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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class TermsGate // TypeDefIndex: 1426
{
	// Fields
	public const string PANEL_KEY = "PanelTerms"; // Metadata: 0x0068D09B
	private const int TIMEOUT_SECONDS = 10; // Metadata: 0x0068D0A6
	private const int CONTENT_RETRY = 2; // Metadata: 0x0068D0A7
	private const int STATUS_RETRY = 3; // Metadata: 0x0068D0A8
	private const string PREF_LAST_ACCEPTED = "TermsAcceptedVersion"; // Metadata: 0x0068D0A9
	[CompilerGenerated]
	private static TermsContentData _Content_k__BackingField; // 0x00

	// Properties
	public static TermsContentData Content { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805CF980-0x00000001805CF9C0 0x00000001805CF9C0-0x00000001805CFA20

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass9_0 // TypeDefIndex: 1427
	{
		// Fields
		public TermsStatusData status; // 0x10
		public bool panelReady; // 0x18
		public bool? decision; // 0x19
		public int userId; // 0x1C
		public Action<bool> __9__2; // 0x20

		// Constructors
		public __c__DisplayClass9_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _EnsureAccepted_b__0(TermsStatusData s); // 0x0000000180317090-0x00000001803170A0
		internal void _EnsureAccepted_b__1(GameObject panel); // 0x00000001805D58A0-0x00000001805D5AC0
		internal void _EnsureAccepted_b__2(bool accepted); // 0x00000001805D5AC0-0x00000001805D5AF0
	}

	[CompilerGenerated]
	private sealed class _EnsureAccepted_d__9 : IEnumerator<object> // TypeDefIndex: 1428
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		private __c__DisplayClass9_0 __8__1; // 0x28
		public Action<bool> onDone; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _EnsureAccepted_d__9(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180315760-0x0000000180315790
		private bool MoveNext(); // 0x00000001805CFB20-0x00000001805D0140
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D0140-0x00000001805D0180
	}

	[CompilerGenerated]
	private sealed class _FetchContent_d__11 : IEnumerator<object> // TypeDefIndex: 1429
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private int _attempt_5__2; // 0x20
		private UnityWebRequest _req_5__3; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FetchContent_d__11(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805D2160-0x00000001805D2240
		private bool MoveNext(); // 0x00000001805D1BB0-0x00000001805D2120
		private void __m__Finally1(); // 0x00000001805D2240-0x00000001805D2290
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D2120-0x00000001805D2160
	}

	[CompilerGenerated]
	private sealed class _FetchStatus_d__10 : IEnumerator<object> // TypeDefIndex: 1430
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _FetchStatus_d__10(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805D2990-0x00000001805D2AA0
		private bool MoveNext(); // 0x00000001805D2290-0x00000001805D2950
		private void __m__Finally1(); // 0x00000001805D2AA0-0x00000001805D2AF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D2950-0x00000001805D2990
	}

	[CompilerGenerated]
	private sealed class _RefetchContent_d__13 : IEnumerator<object> // TypeDefIndex: 1431
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<TermsContentData> done; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RefetchContent_d__13(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805D4420-0x00000001805D4500
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D4500-0x00000001805D4540
	}

	[CompilerGenerated]
	private sealed class _SendAccept_d__12 : IEnumerator<object> // TypeDefIndex: 1432
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<bool, string> done; // 0x20
		public int termsVersion; // 0x28
		public int userId; // 0x2C
		private UnityWebRequest _req_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SendAccept_d__12(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805D4DB0-0x00000001805D4E90
		private bool MoveNext(); // 0x00000001805D4790-0x00000001805D4D70
		private void __m__Finally1(); // 0x00000001805D4E90-0x00000001805D4EE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805D4D70-0x00000001805D4DB0
	}

	// Methods
	[IteratorStateMachine(typeof(_EnsureAccepted_d__9))]
	public static IEnumerator EnsureAccepted(int userId, Action<bool> onDone); // 0x00000001805CF730-0x00000001805CF7B0
	[IteratorStateMachine(typeof(_FetchStatus_d__10))]
	private static IEnumerator FetchStatus(int userId, Action<TermsStatusData> done); // 0x00000001805CF800-0x00000001805CF880
	[IteratorStateMachine(typeof(_FetchContent_d__11))]
	private static IEnumerator FetchContent(); // 0x00000001805CF7B0-0x00000001805CF800
	[IteratorStateMachine(typeof(_SendAccept_d__12))]
	public static IEnumerator SendAccept(int userId, int termsVersion, Action<bool, string> done); // 0x00000001805CF8F0-0x00000001805CF980
	[IteratorStateMachine(typeof(_RefetchContent_d__13))]
	public static IEnumerator RefetchContent(Action<TermsContentData> done); // 0x00000001805CF880-0x00000001805CF8F0
}

