/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class CoopMatchStarter : MonoBehaviour // TypeDefIndex: 399
{
	// Fields
	[CompilerGenerated]
	private static CoopMatchStarter _Instance_k__BackingField; // 0x00
	[CompilerGenerated]
	private static bool _IsStarting_k__BackingField; // 0x08
	private const float REJOIN_GRACE_SEC = 60f; // Metadata: 0x0064C2BA
	private const float REJOIN_SETTLE_DELAY = 1f; // Metadata: 0x0064C2BE
	private string _rejoinRoomId; // 0x20
	private float _rejoinDeadline; // 0x28
	private Coroutine _rejoinCoroutine; // 0x30
	private Coroutine _startCoroutine; // 0x38
	private bool _subscribed; // 0x40

	// Properties
	public static CoopMatchStarter Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180334520-0x0000000180334560 0x00000001803345A0-0x0000000180334600
	public static bool IsStarting { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180334560-0x00000001803345A0 0x0000000180334600-0x0000000180334640

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass26_0 // TypeDefIndex: 400
	{
		// Fields
		public bool failed; // 0x10
		public string failReason; // 0x18

		// Constructors
		public __c__DisplayClass26_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _TryRejoinLobby_b__0(string r); // 0x00000001802FACB0-0x00000001802FACD0
	}

	[CompilerGenerated]
	private sealed class _SnapshotWatchdog_d__22 : IEnumerator<object> // TypeDefIndex: 401
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private float _rigDeadline_5__2; // 0x20
		private int _attempt_5__3; // 0x24
		private float _deadline_5__4; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _SnapshotWatchdog_d__22(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001803439E0-0x0000000180343F40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180343F40-0x0000000180343F80
	}

	[CompilerGenerated]
	private sealed class _TryRejoinLobby_d__26 : IEnumerator<object> // TypeDefIndex: 402
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CoopMatchStarter __4__this; // 0x20
		private __c__DisplayClass26_0 __8__1; // 0x28
		private WsRoomService _ws_5__2; // 0x30
		private string _roomId_5__3; // 0x38
		private Action<string> _onFail_5__4; // 0x40
		private float _start_5__5; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _TryRejoinLobby_d__26(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9810-0x00000001802F9870
		private bool MoveNext(); // 0x0000000180343F80-0x00000001803444D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803444D0-0x0000000180344510
	}

	[CompilerGenerated]
	private sealed class _WsLoadMatchThenVoiceJoin_d__21 : IEnumerator<object> // TypeDefIndex: 403
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CoopMatchStarter __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WsLoadMatchThenVoiceJoin_d__21(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x0000000180346950-0x0000000180346DA0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180346DA0-0x0000000180346DE0
	}

	// Constructors
	public CoopMatchStarter(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x00000001803334A0-0x0000000180333590
	private void Awake(); // 0x0000000180333590-0x00000001803336E0
	private void OnDestroy(); // 0x0000000180333C50-0x0000000180333EE0
	private void Subscribe(); // 0x0000000180334040-0x0000000180334260
	private void Unsubscribe(); // 0x00000001803342D0-0x00000001803344B0
	private void HandleMatchStarting(string roomId, Dictionary<string, object> properties); // 0x00000001803337A0-0x00000001803339A0
	[IteratorStateMachine(typeof(_WsLoadMatchThenVoiceJoin_d__21))]
	private IEnumerator WsLoadMatchThenVoiceJoin(string roomId); // 0x00000001803344B0-0x0000000180334520
	[IteratorStateMachine(typeof(_SnapshotWatchdog_d__22))]
	private IEnumerator SnapshotWatchdog(); // 0x0000000180333FF0-0x0000000180334040
	private void HandleRoomEntered(string roomId); // 0x0000000180333A90-0x0000000180333B10
	private void HandleRoomLeft(string oldRoomId); // 0x0000000180333B10-0x0000000180333C50
	private void HandleConnectionChanged(bool connected); // 0x00000001803336E0-0x00000001803337A0
	[IteratorStateMachine(typeof(_TryRejoinLobby_d__26))]
	private IEnumerator TryRejoinLobby(); // 0x0000000180334260-0x00000001803342D0
	private void HandleRejoinFailedUI(string reason); // 0x00000001803339A0-0x0000000180333A90
	private static void ShowToast(string message); // 0x0000000180333EE0-0x0000000180333FF0
}

