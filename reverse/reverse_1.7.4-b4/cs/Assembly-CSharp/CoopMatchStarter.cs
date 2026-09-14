/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class CoopMatchStarter : MonoBehaviour // TypeDefIndex: 522
{
	// Fields
	[CompilerGenerated]
	private static CoopMatchStarter _Instance_k__BackingField; // 0x00
	[CompilerGenerated]
	private static bool _IsStarting_k__BackingField; // 0x08
	private const float REJOIN_GRACE_SEC = 60f; // Metadata: 0x005EF5B7
	private const float REJOIN_SETTLE_DELAY = 1f; // Metadata: 0x005EF5BB
	private string _rejoinRoomId; // 0x20
	private float _rejoinDeadline; // 0x28
	private Coroutine _rejoinCoroutine; // 0x30
	private Coroutine _startCoroutine; // 0x38
	private bool _subscribed; // 0x40

	// Properties
	public static CoopMatchStarter Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803BDBF0-0x00000001803BDC30 0x00000001803BDC30-0x00000001803BDCD0
	public static bool IsStarting { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803BDCD0-0x00000001803BDD10 0x00000001803BDD10-0x00000001803BDD60

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 523
	{
		// Fields
		public bool failed; // 0x10
		public string failReason; // 0x18

		// Constructors
		public __c__DisplayClass28_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _TryRejoinLobby_b__0(string r); // 0x00000001802B9440-0x00000001802B94A0
	}

	[CompilerGenerated]
	private sealed class _SnapshotWatchdog_d__23 : IEnumerator<object> // TypeDefIndex: 524
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		private float _rigDeadline_5__2; // 0x20
		private int _attempt_5__3; // 0x24
		private float _deadline_5__4; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _SnapshotWatchdog_d__23(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001803BF8F0-0x00000001803BFF50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BFF50-0x00000001803BFF90
	}

	[CompilerGenerated]
	private sealed class _TryRejoinLobby_d__28 : IEnumerator<object> // TypeDefIndex: 525
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _TryRejoinLobby_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B99A0-0x00000001802B9B00
		private bool MoveNext(); // 0x00000001803BFF90-0x00000001803C0710
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803C0710-0x00000001803C0750
	}

	[CompilerGenerated]
	private sealed class _WsLoadMatchThenVoiceJoin_d__22 : IEnumerator<object> // TypeDefIndex: 526
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public CoopMatchStarter __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WsLoadMatchThenVoiceJoin_d__22(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001803C0750-0x00000001803C0BB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803C0BB0-0x00000001803C0BF0
	}

	// Constructors
	public CoopMatchStarter(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x00000001803BDD60-0x00000001803BDEF0
	private void Awake(); // 0x00000001803BDEF0-0x00000001803BE170
	private void OnDestroy(); // 0x00000001803BE170-0x00000001803BE2E0
	private void Subscribe(); // 0x00000001803BE2E0-0x00000001803BE5D0
	private void Unsubscribe(); // 0x00000001803BE5D0-0x00000001803BE860
	private void HandleMatchStarting(string roomId, Dictionary<string, object> properties); // 0x00000001803BE860-0x00000001803BEB50
	private static void StampMatchModeFlags(string roomId); // 0x00000001803BEB50-0x00000001803BEBF0
	[IteratorStateMachine(typeof(_WsLoadMatchThenVoiceJoin_d__22))]
	private IEnumerator WsLoadMatchThenVoiceJoin(string roomId); // 0x00000001803BEBF0-0x00000001803BEC90
	[IteratorStateMachine(typeof(_SnapshotWatchdog_d__23))]
	private IEnumerator SnapshotWatchdog(); // 0x00000001803BEC90-0x00000001803BECD0
	private static bool SnapshotArrived(); // 0x00000001803BECD0-0x00000001803BF0B0
	private void HandleRoomEntered(string roomId); // 0x00000001803BF0B0-0x00000001803BF1A0
	private void HandleRoomLeft(string oldRoomId); // 0x00000001803BF1A0-0x00000001803BF310
	private void HandleConnectionChanged(bool connected); // 0x00000001803BF310-0x00000001803BF450
	[IteratorStateMachine(typeof(_TryRejoinLobby_d__28))]
	private IEnumerator TryRejoinLobby(); // 0x00000001803BF450-0x00000001803BF4F0
	private void HandleRejoinFailedUI(string reason); // 0x00000001803BF4F0-0x00000001803BF740
	private static void ShowToast(string message); // 0x00000001803BF740-0x00000001803BF8F0
}

