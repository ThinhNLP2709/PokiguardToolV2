/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class LoginSuccessPipeline // TypeDefIndex: 1013
{
	// Fields
	private static readonly string[] VOLATILE_PREF_KEYS; // 0x00

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass1_0 // TypeDefIndex: 1014
	{
		// Fields
		public bool accepted; // 0x10

		// Constructors
		public __c__DisplayClass1_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _TermsThenLoadGame_b__0(bool ok); // 0x0000000180290F20-0x0000000180290F30
	}

	[CompilerGenerated]
	private sealed class _LoadGameSceneAsync_d__2 : IEnumerator<object> // TypeDefIndex: 1015
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private AsyncOperation _op_5__2; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadGameSceneAsync_d__2(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001805EE460-0x00000001805EE4D0
		private bool MoveNext(); // 0x0000000180609CF0-0x0000000180609F70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180609F70-0x0000000180609FB0
	}

	[CompilerGenerated]
	private sealed class _Run_d__0 : IEnumerator<object> // TypeDefIndex: 1016
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public LoginResponse r; // 0x20
		public Action<bool> onTermsDecided; // 0x28
		public string dateHeader; // 0x30
		public string username; // 0x38
		public MonoBehaviour host; // 0x40

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _Run_d__0(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180609FB0-0x000000018060AB00
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x000000018060AB00-0x000000018060AB90
	}

	[CompilerGenerated]
	private sealed class _TermsThenLoadGame_d__1 : IEnumerator<object> // TypeDefIndex: 1017
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		private __c__DisplayClass1_0 __8__1; // 0x28
		public Action<bool> onTermsDecided; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TermsThenLoadGame_d__1(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
		private bool MoveNext(); // 0x0000000180633BC0-0x0000000180633F30
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180633F30-0x0000000180633F70
	}

	// Constructors
	static LoginSuccessPipeline(); // 0x0000000180609480-0x0000000180609CF0

	// Methods
	[IteratorStateMachine(typeof(_Run_d__0))]
	public static IEnumerator Run(MonoBehaviour host, LoginResponse r, string username, Action<bool> onTermsDecided, string dateHeader = null); // 0x00000001806087A0-0x00000001806089C0
	[IteratorStateMachine(typeof(_TermsThenLoadGame_d__1))]
	private static IEnumerator TermsThenLoadGame(MonoBehaviour host, int userId, Action<bool> onTermsDecided); // 0x00000001806089C0-0x0000000180608A60
	[IteratorStateMachine(typeof(_LoadGameSceneAsync_d__2))]
	public static IEnumerator LoadGameSceneAsync(); // 0x0000000180608A60-0x0000000180608AA0
	public static void SyncServerTime(long jsonServerTimestamp, string dateHeader); // 0x0000000180608AA0-0x0000000180608D50
	public static void UpdateUserData(UserDTO user); // 0x0000000180608D50-0x0000000180609010
	public static bool ForceCleanOldData(); // 0x0000000180609010-0x0000000180609480
}

