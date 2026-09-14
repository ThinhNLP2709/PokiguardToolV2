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

public class CoopMatchStarter : MonoBehaviour // TypeDefIndex: 521
{
	// Fields
	[CompilerGenerated]
	private static CoopMatchStarter _Instance_k__BackingField; // 0x00
	[CompilerGenerated]
	private static bool _IsStarting_k__BackingField; // 0x08
	private const float REJOIN_GRACE_SEC = 60f; // Metadata: 0x005EE1E6
	private const float REJOIN_SETTLE_DELAY = 1f; // Metadata: 0x005EE1EA
	private string _rejoinRoomId; // 0x20
	private float _rejoinDeadline; // 0x28
	private Coroutine _rejoinCoroutine; // 0x30
	private Coroutine _startCoroutine; // 0x38
	private bool _subscribed; // 0x40

	// Properties
	public static CoopMatchStarter Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803BCF20-0x00000001803BCF60 0x00000001803BCF60-0x00000001803BD000
	public static bool IsStarting { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803BD000-0x00000001803BD040 0x00000001803BD040-0x00000001803BD090

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass28_0 // TypeDefIndex: 522
	{
		// Fields
		public bool failed; // 0x10
		public string failReason; // 0x18

		// Constructors
		public __c__DisplayClass28_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _TryRejoinLobby_b__0(string r); // 0x00000001802B9410-0x00000001802B9470
	}

	[CompilerGenerated]
	private sealed class _SnapshotWatchdog_d__23 : IEnumerator<object> // TypeDefIndex: 523
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001803BEC20-0x00000001803BF280
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BF280-0x00000001803BF2C0
	}

	[CompilerGenerated]
	private sealed class _TryRejoinLobby_d__28 : IEnumerator<object> // TypeDefIndex: 524
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
		void IDisposable.Dispose(); // 0x00000001802B9970-0x00000001802B9AD0
		private bool MoveNext(); // 0x00000001803BF2C0-0x00000001803BFA40
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BFA40-0x00000001803BFA80
	}

	[CompilerGenerated]
	private sealed class _WsLoadMatchThenVoiceJoin_d__22 : IEnumerator<object> // TypeDefIndex: 525
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001803BFA80-0x00000001803BFEE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001803BFEE0-0x00000001803BFF20
	}

	// Constructors
	public CoopMatchStarter(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void AutoInit(); // 0x00000001803BD090-0x00000001803BD220
	private void Awake(); // 0x00000001803BD220-0x00000001803BD4A0
	private void OnDestroy(); // 0x00000001803BD4A0-0x00000001803BD610
	private void Subscribe(); // 0x00000001803BD610-0x00000001803BD900
	private void Unsubscribe(); // 0x00000001803BD900-0x00000001803BDB90
	private void HandleMatchStarting(string roomId, Dictionary<string, object> properties); // 0x00000001803BDB90-0x00000001803BDE80
	private static void StampMatchModeFlags(string roomId); // 0x00000001803BDE80-0x00000001803BDF20
	[IteratorStateMachine(typeof(_WsLoadMatchThenVoiceJoin_d__22))]
	private IEnumerator WsLoadMatchThenVoiceJoin(string roomId); // 0x00000001803BDF20-0x00000001803BDFC0
	[IteratorStateMachine(typeof(_SnapshotWatchdog_d__23))]
	private IEnumerator SnapshotWatchdog(); // 0x00000001803BDFC0-0x00000001803BE000
	private static bool SnapshotArrived(); // 0x00000001803BE000-0x00000001803BE3E0
	private void HandleRoomEntered(string roomId); // 0x00000001803BE3E0-0x00000001803BE4D0
	private void HandleRoomLeft(string oldRoomId); // 0x00000001803BE4D0-0x00000001803BE640
	private void HandleConnectionChanged(bool connected); // 0x00000001803BE640-0x00000001803BE780
	[IteratorStateMachine(typeof(_TryRejoinLobby_d__28))]
	private IEnumerator TryRejoinLobby(); // 0x00000001803BE780-0x00000001803BE820
	private void HandleRejoinFailedUI(string reason); // 0x00000001803BE820-0x00000001803BEA70
	private static void ShowToast(string message); // 0x00000001803BEA70-0x00000001803BEC20
}

