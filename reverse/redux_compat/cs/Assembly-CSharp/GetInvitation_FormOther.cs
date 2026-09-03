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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class GetInvitation_FormOther : MonoBehaviour // TypeDefIndex: 29
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
	private const float INVITE_TIMEOUT = 10f; // Metadata: 0x0064BF72
	private Coroutine _countdownCoroutine; // 0x68
	private string _savedRichInfo; // 0x70
	private string _savedMessageText; // 0x78
	private bool _isJoiningRoom; // 0x80

	// Properties
	public static GetInvitation_FormOther Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F5930-0x00000001802F5970 0x00000001802F5970-0x00000001802F59D0

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass23_0 // TypeDefIndex: 30
	{
		// Fields
		public bool failed; // 0x10
		public string failReason; // 0x18

		// Constructors
		public __c__DisplayClass23_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _JoinInviteRoomKeepingOldRoom_b__0(string r); // 0x00000001802FACB0-0x00000001802FACD0
	}

	[CompilerGenerated]
	private sealed class _InviteCountdownCoroutine_d__25 : IEnumerator<object> // TypeDefIndex: 31
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GetInvitation_FormOther __4__this; // 0x20
		private int _remaining_5__2; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _InviteCountdownCoroutine_d__25(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001802F9070-0x00000001802F92E0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802F92E0-0x00000001802F9320
	}

	[CompilerGenerated]
	private sealed class _JoinInviteRoomKeepingOldRoom_d__23 : IEnumerator<object> // TypeDefIndex: 32
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _JoinInviteRoomKeepingOldRoom_d__23(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9810-0x00000001802F9870
		private bool MoveNext(); // 0x00000001802F9330-0x00000001802F97D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802F97D0-0x00000001802F9810
	}

	[CompilerGenerated]
	private sealed class _OpenCoopPanelAndJoinWs_d__28 : IEnumerator<object> // TypeDefIndex: 33
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GetInvitation_FormOther __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _OpenCoopPanelAndJoinWs_d__28(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001802FA910-0x00000001802FA990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802FA990-0x00000001802FA9D0
	}

	[CompilerGenerated]
	private sealed class _OpenPvpThenJoinInviteCo_d__29 : IEnumerator<object> // TypeDefIndex: 34
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GetInvitation_FormOther __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _OpenPvpThenJoinInviteCo_d__29(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001802FA910-0x00000001802FA990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802FA9D0-0x00000001802FAA10
	}

	[CompilerGenerated]
	private sealed class _WaitToCheck_d__27 : IEnumerator<object> // TypeDefIndex: 35
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public GetInvitation_FormOther __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitToCheck_d__27(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001802FB1A0-0x00000001802FB270
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001802FB270-0x00000001802FB2B0
	}

	// Constructors
	public GetInvitation_FormOther(); // 0x00000001802F58D0-0x00000001802F5930

	// Methods
	private void Awake(); // 0x00000001802F4080-0x00000001802F4230
	public void ShowInvitationPanel(string sender, string roomName, string username = null, string[] energy = null, string[] pass = null, int avatarId = 1 /* Metadata: 0x0064BF6C */, int level = 10 /* Metadata: 0x0064BF6D */, int petId = 1 /* Metadata: 0x0064BF6E */, string roomType = "" /* Metadata: 0x0064BF6F */, int chienTich = 0 /* Metadata: 0x0064BF70 */, string bossName = null, int bossLevel = 0 /* Metadata: 0x0064BF71 */); // 0x00000001802F4EA0-0x00000001802F5820
	private static string EscapeRichTextFragment(string s); // 0x00000001802F43D0-0x00000001802F44B0
	private static string BuildInvitationRichText(string playerName, int playerLevel, string roomType, string bossName, int bossLevel); // 0x00000001802F4230-0x00000001802F43D0
	private void OnAccept(); // 0x00000001802F4760-0x00000001802F49E0
	[IteratorStateMachine(typeof(_JoinInviteRoomKeepingOldRoom_d__23))]
	private IEnumerator JoinInviteRoomKeepingOldRoom(); // 0x00000001802F4520-0x00000001802F4590
	private void OnDecline(); // 0x00000001802F49E0-0x00000001802F4A80
	[IteratorStateMachine(typeof(_InviteCountdownCoroutine_d__25))]
	private IEnumerator InviteCountdownCoroutine(); // 0x00000001802F44B0-0x00000001802F4520
	private void StopCountdown(); // 0x00000001802F5820-0x00000001802F5860
	[IteratorStateMachine(typeof(_WaitToCheck_d__27))]
	private IEnumerator WaitToCheck(); // 0x00000001802F5860-0x00000001802F58D0
	[IteratorStateMachine(typeof(_OpenCoopPanelAndJoinWs_d__28))]
	private IEnumerator OpenCoopPanelAndJoinWs(); // 0x00000001802F4A80-0x00000001802F4AF0
	[IteratorStateMachine(typeof(_OpenPvpThenJoinInviteCo_d__29))]
	private IEnumerator OpenPvpThenJoinInviteCo(); // 0x00000001802F4AF0-0x00000001802F4B60
	private void OpenRoomPanel(string roomName); // 0x00000001802F4B60-0x00000001802F4E30
	public void ResetJoiningState(); // 0x00000001802F4E30-0x00000001802F4EA0
	private void JoinPendingRoom(); // 0x00000001802F4590-0x00000001802F4760
}

