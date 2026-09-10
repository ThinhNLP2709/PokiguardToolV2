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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GetInvitation_FormOther : MonoBehaviour // TypeDefIndex: 36
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
	private const float INVITE_TIMEOUT = 10f; // Metadata: 0x0068A98C
	private Coroutine _countdownCoroutine; // 0x68
	private string _savedRichInfo; // 0x70
	private string _savedMessageText; // 0x78
	private bool _isJoiningRoom; // 0x80

	// Properties
	public static GetInvitation_FormOther Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180304250-0x0000000180304290 0x0000000180304290-0x00000001803042F0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 37
	{
		// Fields
		public bool failed; // 0x10
		public string failReason; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _JoinInviteRoomKeepingOldRoom_b__0(string r); // 0x0000000180316FC0-0x0000000180316FE0
	}

	[CompilerGenerated]
	private sealed class _InviteCountdownCoroutine_d__25 : IEnumerator<object> // TypeDefIndex: 38
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GetInvitation_FormOther __4__this; // 0x20
		private int _remaining_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _InviteCountdownCoroutine_d__25(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180314A40-0x0000000180314CB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180314CB0-0x0000000180314CF0
	}

	[CompilerGenerated]
	private sealed class _JoinInviteRoomKeepingOldRoom_d__23 : IEnumerator<object> // TypeDefIndex: 39
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _JoinInviteRoomKeepingOldRoom_d__23(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001803151D0-0x0000000180315230
		private bool MoveNext(); // 0x0000000180314CF0-0x0000000180315190
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180315190-0x00000001803151D0
	}

	[CompilerGenerated]
	private sealed class _OpenCoopPanelAndJoinWs_d__28 : IEnumerator<object> // TypeDefIndex: 40
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GetInvitation_FormOther __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _OpenCoopPanelAndJoinWs_d__28(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180316B00-0x0000000180316B80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180316B80-0x0000000180316BC0
	}

	[CompilerGenerated]
	private sealed class _OpenPvpThenJoinInviteCo_d__29 : IEnumerator<object> // TypeDefIndex: 41
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GetInvitation_FormOther __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _OpenPvpThenJoinInviteCo_d__29(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180316B00-0x0000000180316B80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180316BC0-0x0000000180316C00
	}

	[CompilerGenerated]
	private sealed class _WaitToCheck_d__27 : IEnumerator<object> // TypeDefIndex: 42
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GetInvitation_FormOther __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitToCheck_d__27(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180317540-0x0000000180317610
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180317610-0x0000000180317650
	}

	// Constructors
	public GetInvitation_FormOther(); // 0x00000001803041F0-0x0000000180304250

	// Methods
	private void Awake(); // 0x0000000180302970-0x0000000180302B20
	public void ShowInvitationPanel(string sender, string roomName, string username = null, string[] energy = null, string[] pass = null, int avatarId = 1 /* Metadata: 0x0068A986 */, int level = 10 /* Metadata: 0x0068A987 */, int petId = 1 /* Metadata: 0x0068A988 */, string roomType = "" /* Metadata: 0x0068A989 */, int chienTich = 0 /* Metadata: 0x0068A98A */, string bossName = null, int bossLevel = 0 /* Metadata: 0x0068A98B */); // 0x0000000180303790-0x0000000180304140
	private static string EscapeRichTextFragment(string s); // 0x0000000180302CC0-0x0000000180302DA0
	private static string BuildInvitationRichText(string playerName, int playerLevel, string roomType, string bossName, int bossLevel); // 0x0000000180302B20-0x0000000180302CC0
	private void OnAccept(); // 0x0000000180303050-0x00000001803032D0
	[IteratorStateMachine(typeof(_JoinInviteRoomKeepingOldRoom_d__23))]
	private IEnumerator JoinInviteRoomKeepingOldRoom(); // 0x0000000180302E10-0x0000000180302E80
	private void OnDecline(); // 0x00000001803032D0-0x0000000180303370
	[IteratorStateMachine(typeof(_InviteCountdownCoroutine_d__25))]
	private IEnumerator InviteCountdownCoroutine(); // 0x0000000180302DA0-0x0000000180302E10
	private void StopCountdown(); // 0x0000000180304140-0x0000000180304180
	[IteratorStateMachine(typeof(_WaitToCheck_d__27))]
	private IEnumerator WaitToCheck(); // 0x0000000180304180-0x00000001803041F0
	[IteratorStateMachine(typeof(_OpenCoopPanelAndJoinWs_d__28))]
	private IEnumerator OpenCoopPanelAndJoinWs(); // 0x0000000180303370-0x00000001803033E0
	[IteratorStateMachine(typeof(_OpenPvpThenJoinInviteCo_d__29))]
	private IEnumerator OpenPvpThenJoinInviteCo(); // 0x00000001803033E0-0x0000000180303450
	private void OpenRoomPanel(string roomName); // 0x0000000180303450-0x0000000180303720
	public void ResetJoiningState(); // 0x0000000180303720-0x0000000180303790
	private void JoinPendingRoom(); // 0x0000000180302E80-0x0000000180303050
}

