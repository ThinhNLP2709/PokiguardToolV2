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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
	private const float INVITE_TIMEOUT = 10f; // Metadata: 0x005ED5E1
	private Coroutine _countdownCoroutine; // 0x68
	private string _savedRichInfo; // 0x70
	private string _savedMessageText; // 0x78
	private bool _isJoiningRoom; // 0x80

	// Properties
	public static GetInvitation_FormOther Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802B6D80-0x00000001802B6DC0 0x00000001802B6DC0-0x00000001802B6E60

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
		internal void _JoinInviteRoomKeepingOldRoom_b__0(string r); // 0x00000001802B9410-0x00000001802B9470
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001802B9470-0x00000001802B9930
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802B9930-0x00000001802B9970
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
		void IDisposable.Dispose(); // 0x00000001802B9970-0x00000001802B9AD0
		private bool MoveNext(); // 0x00000001802B9AD0-0x00000001802BA170
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802BA170-0x00000001802BA1B0
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001802BA1B0-0x00000001802BA270
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802BA270-0x00000001802BA2B0
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001802BA1B0-0x00000001802BA270
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802BA2B0-0x00000001802BA2F0
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
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001802BA2F0-0x00000001802BA4A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802BA4A0-0x00000001802BA4E0
	}

	// Constructors
	public GetInvitation_FormOther(); // 0x00000001802B9340-0x00000001802B9410

	// Methods
	private void Awake(); // 0x00000001802B6E60-0x00000001802B7140
	public void ShowInvitationPanel(string sender, string roomName, string username = null, string[] energy = null, string[] pass = null, int avatarId = 1 /* Metadata: 0x005ED5DB */, int level = 10 /* Metadata: 0x005ED5DC */, int petId = 1 /* Metadata: 0x005ED5DD */, string roomType = "" /* Metadata: 0x005ED5DE */, int chienTich = 0 /* Metadata: 0x005ED5DF */, string bossName = null, int bossLevel = 0 /* Metadata: 0x005ED5E0 */); // 0x00000001802B7140-0x00000001802B7DC0
	private static string EscapeRichTextFragment(string s); // 0x00000001802B7DC0-0x00000001802B7EC0
	private static string BuildInvitationRichText(string playerName, int playerLevel, string roomType, string bossName, int bossLevel); // 0x00000001802B7EC0-0x00000001802B8140
	private void OnAccept(); // 0x00000001802B8140-0x00000001802B8640
	[IteratorStateMachine(typeof(_JoinInviteRoomKeepingOldRoom_d__23))]
	private IEnumerator JoinInviteRoomKeepingOldRoom(); // 0x00000001802B8640-0x00000001802B86E0
	private void OnDecline(); // 0x00000001802B86E0-0x00000001802B87C0
	[IteratorStateMachine(typeof(_InviteCountdownCoroutine_d__25))]
	private IEnumerator InviteCountdownCoroutine(); // 0x00000001802B87C0-0x00000001802B8860
	private void StopCountdown(); // 0x00000001802B8860-0x00000001802B88E0
	[IteratorStateMachine(typeof(_WaitToCheck_d__27))]
	private IEnumerator WaitToCheck(); // 0x00000001802B88E0-0x00000001802B8980
	[IteratorStateMachine(typeof(_OpenCoopPanelAndJoinWs_d__28))]
	private IEnumerator OpenCoopPanelAndJoinWs(); // 0x00000001802B8980-0x00000001802B8A20
	[IteratorStateMachine(typeof(_OpenPvpThenJoinInviteCo_d__29))]
	private IEnumerator OpenPvpThenJoinInviteCo(); // 0x00000001802B8A20-0x00000001802B8AC0
	private void OpenRoomPanel(string roomName); // 0x00000001802B8AC0-0x00000001802B9020
	public void ResetJoiningState(); // 0x00000001802B9020-0x00000001802B90A0
	private void JoinPendingRoom(); // 0x00000001802B90A0-0x00000001802B9340
}

