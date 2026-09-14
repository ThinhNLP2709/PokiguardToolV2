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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class TermsGate // TypeDefIndex: 1811
{
	// Fields
	[CompilerGenerated]
	private static TermsContentData _Content_k__BackingField; // 0x00

	// Properties
	public static TermsContentData Content { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001808EE360-0x00000001808EE3A0 0x00000001808EE3A0-0x00000001808EE440

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass9_0 // TypeDefIndex: 1812
	{
		// Fields
		public TermsStatusData status; // 0x10
		public bool panelReady; // 0x18
		public bool? decision; // 0x19
		public int userId; // 0x1C
		public Action<bool> __9__2; // 0x20

		// Constructors
		public __c__DisplayClass9_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _EnsureAccepted_b__0(TermsStatusData s); // 0x00000001802D8AB0-0x00000001802D8B10
		internal void _EnsureAccepted_b__1(GameObject panel); // 0x00000001808EE720-0x00000001808EEA20
		internal void _EnsureAccepted_b__2(bool accepted); // 0x00000001808EEA20-0x00000001808EEA40
	}

	[CompilerGenerated]
	private sealed class _EnsureAccepted_d__9 : IEnumerator<object> // TypeDefIndex: 1813
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		private __c__DisplayClass9_0 __8__1; // 0x28
		public Action<bool> onDone; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _EnsureAccepted_d__9(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x00000001808EEA40-0x00000001808EF030
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808EF030-0x00000001808EF070
	}

	[CompilerGenerated]
	private sealed class _FetchContent_d__11 : IEnumerator<object> // TypeDefIndex: 1814
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private int _attempt_5__2; // 0x20
		private UnityWebRequest _req_5__3; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FetchContent_d__11(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808EF070-0x00000001808EF1A0
		private bool MoveNext(); // 0x00000001808EF1A0-0x00000001808EF820
		private void __m__Finally1(); // 0x00000001808EF820-0x00000001808EF880
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808EF880-0x00000001808EF8C0
	}

	[CompilerGenerated]
	private sealed class _FetchStatus_d__10 : IEnumerator<object> // TypeDefIndex: 1815
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _FetchStatus_d__10(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808EF8C0-0x00000001808EFAD0
		private bool MoveNext(); // 0x00000001808EFAD0-0x00000001808F05E0
		private void __m__Finally1(); // 0x00000001808F05E0-0x00000001808F0640
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808F0640-0x00000001808F0680
	}

	[CompilerGenerated]
	private sealed class _RefetchContent_d__13 : IEnumerator<object> // TypeDefIndex: 1816
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<TermsContentData> done; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RefetchContent_d__13(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808F0680-0x00000001808F0770
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808F0770-0x00000001808F07B0
	}

	[CompilerGenerated]
	private sealed class _SendAccept_d__12 : IEnumerator<object> // TypeDefIndex: 1817
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public Action<bool, string> done; // 0x20
		public int termsVersion; // 0x28
		public int userId; // 0x2C
		private UnityWebRequest _req_5__2; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SendAccept_d__12(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001808F07B0-0x00000001808F08E0
		private bool MoveNext(); // 0x00000001808F08E0-0x00000001808F11F0
		private void __m__Finally1(); // 0x00000001808F11F0-0x00000001808F1250
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808F1250-0x00000001808F1290
	}

	// Methods
	[IteratorStateMachine(typeof(_EnsureAccepted_d__9))]
	public static IEnumerator EnsureAccepted(int userId, Action<bool> onDone); // 0x00000001808EE440-0x00000001808EE4E0
	[IteratorStateMachine(typeof(_FetchStatus_d__10))]
	private static IEnumerator FetchStatus(int userId, Action<TermsStatusData> done); // 0x00000001808EE4E0-0x00000001808EE580
	[IteratorStateMachine(typeof(_FetchContent_d__11))]
	private static IEnumerator FetchContent(); // 0x00000001808EE580-0x00000001808EE5C0
	[IteratorStateMachine(typeof(_SendAccept_d__12))]
	public static IEnumerator SendAccept(int userId, int termsVersion, Action<bool, string> done); // 0x00000001808EE5C0-0x00000001808EE680
	[IteratorStateMachine(typeof(_RefetchContent_d__13))]
	public static IEnumerator RefetchContent(Action<TermsContentData> done); // 0x00000001808EE680-0x00000001808EE720
}

