/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class GetInvitation_FormOther : MonoBehaviour // TypeDefIndex: 37
{
	// Fields
	[CompilerGenerated]
	private static GetInvitation_FormOther _Instance_k__BackingField; // 0x00
	[Header("UI Panel Nh\u1EADn L\u1EDDi M\u1EDDi")]
	[SerializeField]
	private GameObject invitationPanel; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text messageText; // 0x28
	[SerializeField]
	private Button yesButton; // 0x30
	[SerializeField]
	private Button noButton; // 0x38
	[Header("New UI Fields")]
	[SerializeField]
	private UnityEngine.UI.Text txtRoomType; // 0x40
	[SerializeField]
	private UnityEngine.UI.Text txtInfo; // 0x48
	private string _pendingRoomName; // 0x50
	private string _pendingRoomType; // 0x58
	private int chienTichRq; // 0x60
	private int _pendingPetId; // 0x64
	private const float INVITE_TIMEOUT = 10f; // Metadata: 0x005EE9B1
	private Coroutine _countdownCoroutine; // 0x68
	private string _savedRichInfo; // 0x70
	private string _savedMessageText; // 0x78
	private bool _isJoiningRoom; // 0x80

	// Properties
	public static GetInvitation_FormOther Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802B6DB0-0x00000001802B6DF0 0x00000001802B6DF0-0x00000001802B6E90

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 38
	{
		// Fields
		public bool failed; // 0x10
		public string failReason; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _JoinInviteRoomKeepingOldRoom_b__0(string r); // 0x00000001802B9440-0x00000001802B94A0
	}

	[CompilerGenerated]
	private sealed class _InviteCountdownCoroutine_d__25 : IEnumerator<object> // TypeDefIndex: 39
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GetInvitation_FormOther __4__this; // 0x20
		private int _remaining_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _InviteCountdownCoroutine_d__25(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001802B94A0-0x00000001802B9960
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802B9960-0x00000001802B99A0
	}

	[CompilerGenerated]
	private sealed class _JoinInviteRoomKeepingOldRoom_d__23 : IEnumerator<object> // TypeDefIndex: 40
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GetInvitation_FormOther __4__this; // 0x20
		private __c__DisplayClass23_0 __8__1; // 0x28
		private WsRoomService _ws_5__2; // 0x30
		private string _targetRoom_5__3; // 0x38
		private Action<string> _onFail_5__4; // 0x40
		private float _start_5__5; // 0x48

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _JoinInviteRoomKeepingOldRoom_d__23(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B99A0-0x00000001802B9B00
		private bool MoveNext(); // 0x00000001802B9B00-0x00000001802BA1A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802BA1A0-0x00000001802BA1E0
	}

	[CompilerGenerated]
	private sealed class _OpenCoopPanelAndJoinWs_d__28 : IEnumerator<object> // TypeDefIndex: 41
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GetInvitation_FormOther __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _OpenCoopPanelAndJoinWs_d__28(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001802BA1E0-0x00000001802BA2A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802BA2A0-0x00000001802BA2E0
	}

	[CompilerGenerated]
	private sealed class _OpenPvpThenJoinInviteCo_d__29 : IEnumerator<object> // TypeDefIndex: 42
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GetInvitation_FormOther __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _OpenPvpThenJoinInviteCo_d__29(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001802BA1E0-0x00000001802BA2A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802BA2E0-0x00000001802BA320
	}

	[CompilerGenerated]
	private sealed class _WaitToCheck_d__27 : IEnumerator<object> // TypeDefIndex: 43
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GetInvitation_FormOther __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitToCheck_d__27(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001802BA320-0x00000001802BA4D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802BA4D0-0x00000001802BA510
	}

	// Constructors
	public GetInvitation_FormOther(); // 0x00000001802B9370-0x00000001802B9440

	// Methods
	private void Awake(); // 0x00000001802B6E90-0x00000001802B7170
	public void ShowInvitationPanel(string sender, string roomName, string username = null, string[] energy = null, string[] pass = null, int avatarId = 1 /* Metadata: 0x005EE9AB */, int level = 10 /* Metadata: 0x005EE9AC */, int petId = 1 /* Metadata: 0x005EE9AD */, string roomType = "" /* Metadata: 0x005EE9AE */, int chienTich = 0 /* Metadata: 0x005EE9AF */, string bossName = null, int bossLevel = 0 /* Metadata: 0x005EE9B0 */); // 0x00000001802B7170-0x00000001802B7DF0
	private static string EscapeRichTextFragment(string s); // 0x00000001802B7DF0-0x00000001802B7EF0
	private static string BuildInvitationRichText(string playerName, int playerLevel, string roomType, string bossName, int bossLevel); // 0x00000001802B7EF0-0x00000001802B8170
	private void OnAccept(); // 0x00000001802B8170-0x00000001802B8670
	[IteratorStateMachine(typeof(_JoinInviteRoomKeepingOldRoom_d__23))]
	private IEnumerator JoinInviteRoomKeepingOldRoom(); // 0x00000001802B8670-0x00000001802B8710
	private void OnDecline(); // 0x00000001802B8710-0x00000001802B87F0
	[IteratorStateMachine(typeof(_InviteCountdownCoroutine_d__25))]
	private IEnumerator InviteCountdownCoroutine(); // 0x00000001802B87F0-0x00000001802B8890
	private void StopCountdown(); // 0x00000001802B8890-0x00000001802B8910
	[IteratorStateMachine(typeof(_WaitToCheck_d__27))]
	private IEnumerator WaitToCheck(); // 0x00000001802B8910-0x00000001802B89B0
	[IteratorStateMachine(typeof(_OpenCoopPanelAndJoinWs_d__28))]
	private IEnumerator OpenCoopPanelAndJoinWs(); // 0x00000001802B89B0-0x00000001802B8A50
	[IteratorStateMachine(typeof(_OpenPvpThenJoinInviteCo_d__29))]
	private IEnumerator OpenPvpThenJoinInviteCo(); // 0x00000001802B8A50-0x00000001802B8AF0
	private void OpenRoomPanel(string roomName); // 0x00000001802B8AF0-0x00000001802B9050
	public void ResetJoiningState(); // 0x00000001802B9050-0x00000001802B90D0
	private void JoinPendingRoom(); // 0x00000001802B90D0-0x00000001802B9370
}

