/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class CoopMatchStarter : MonoBehaviour // TypeDefIndex: 467
{
	// Fields
	[CompilerGenerated]
	private static CoopMatchStarter _Instance_k__BackingField; // 0x00
	[CompilerGenerated]
	private static bool _IsStarting_k__BackingField; // 0x08
	private const float REJOIN_GRACE_SEC = 60f; // Metadata: 0x0068B327
	private const float REJOIN_SETTLE_DELAY = 1f; // Metadata: 0x0068B32B
	private string _rejoinRoomId; // 0x20
	private float _rejoinDeadline; // 0x28
	private Coroutine _rejoinCoroutine; // 0x30
	private Coroutine _startCoroutine; // 0x38
	private bool _subscribed; // 0x40

	// Properties
	public static CoopMatchStarter Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018038D7A0-0x000000018038D7E0 0x000000018038D820-0x000000018038D880
	public static bool IsStarting { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018038D7E0-0x000000018038D820 0x000000018038D880-0x000000018038D8C0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 468
	{
		// Fields
		public bool failed; // 0x10
		public string failReason; // 0x18

		// Constructors
		public __c__DisplayClass28_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _TryRejoinLobby_b__0(string r); // 0x0000000180316FC0-0x0000000180316FE0
	}

	[CompilerGenerated]
	private sealed class _SnapshotWatchdog_d__23 : IEnumerator<object> // TypeDefIndex: 469
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private float _rigDeadline_5__2; // 0x20
		private int _attempt_5__3; // 0x24
		private float _deadline_5__4; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _SnapshotWatchdog_d__23(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803A61E0-0x00000001803A65C0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803A65C0-0x00000001803A6600
	}

	[CompilerGenerated]
	private sealed class _TryRejoinLobby_d__28 : IEnumerator<object> // TypeDefIndex: 470
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CoopMatchStarter __4__this; // 0x20
		private __c__DisplayClass28_0 __8__1; // 0x28
		private WsRoomService _ws_5__2; // 0x30
		private string _roomId_5__3; // 0x38
		private Action<string> _onFail_5__4; // 0x40
		private float _start_5__5; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _TryRejoinLobby_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803151D0-0x0000000180315230
		private bool MoveNext(); // 0x00000001803A6600-0x00000001803A6B50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803A6B50-0x00000001803A6B90
	}

	[CompilerGenerated]
	private sealed class _WsLoadMatchThenVoiceJoin_d__22 : IEnumerator<object> // TypeDefIndex: 471
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CoopMatchStarter __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WsLoadMatchThenVoiceJoin_d__22(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001803A6F80-0x00000001803A73F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803A73F0-0x00000001803A7430
	}

	// Constructors
	public CoopMatchStarter(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x000000018038C230-0x000000018038C320
	private void Awake(); // 0x000000018038C320-0x000000018038C470
	private void OnDestroy(); // 0x000000018038CA80-0x000000018038CB60
	private void Subscribe(); // 0x000000018038D180-0x000000018038D440
	private void Unsubscribe(); // 0x000000018038D4B0-0x000000018038D730
	private void HandleMatchStarting(string roomId, Dictionary<string, object> properties); // 0x000000018038C530-0x000000018038C850
	private static void StampMatchModeFlags(string roomId); // 0x000000018038D040-0x000000018038D180
	[IteratorStateMachine(typeof(_WsLoadMatchThenVoiceJoin_d__22))]
	private IEnumerator WsLoadMatchThenVoiceJoin(string roomId); // 0x000000018038D730-0x000000018038D7A0
	[IteratorStateMachine(typeof(_SnapshotWatchdog_d__23))]
	private IEnumerator SnapshotWatchdog(); // 0x000000018038CFF0-0x000000018038D040
	private static bool SnapshotArrived(); // 0x000000018038CC70-0x000000018038CFF0
	private void HandleRoomEntered(string roomId); // 0x000000018038C950-0x000000018038C9D0
	private void HandleRoomLeft(string oldRoomId); // 0x000000018038C9D0-0x000000018038CA80
	private void HandleConnectionChanged(bool connected); // 0x000000018038C470-0x000000018038C530
	[IteratorStateMachine(typeof(_TryRejoinLobby_d__28))]
	private IEnumerator TryRejoinLobby(); // 0x000000018038D440-0x000000018038D4B0
	private void HandleRejoinFailedUI(string reason); // 0x000000018038C850-0x000000018038C950
	private static void ShowToast(string message); // 0x000000018038CB60-0x000000018038CC70
}

