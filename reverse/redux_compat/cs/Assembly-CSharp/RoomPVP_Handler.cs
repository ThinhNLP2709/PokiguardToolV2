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

public class RoomPVP_Handler : MonoBehaviour // TypeDefIndex: 208
{
	// Fields
	public static RoomPVP_Handler Instance; // 0x00
	[SerializeField]
	private GameObject panelLoading; // 0x20
	[Header("Room ID")]
	[SerializeField]
	internal UnityEngine.UI.Text txtRoomID; // 0x28
	[Header("Join Room by ID")]
	[SerializeField]
	private InputField inputJoinRoomID; // 0x30
	[SerializeField]
	private Button btnJoinByID; // 0x38
	[Header("Room Settings")]
	[SerializeField]
	private byte maxPlayers; // 0x40
	[Header("Ready / Start")]
	[SerializeField]
	internal Button readyButton; // 0x48
	[SerializeField]
	private UnityEngine.UI.Text txtReadyButton; // 0x50
	[Header("New Buttons")]
	public Button btnSS; // 0x58
	public Button btnCancless; // 0x60
	public Button btnPlayGame; // 0x68
	public Transform[] panelCard; // 0x70
	public Image[] rankIcons; // 0x78
	public Sprite Def_RankIcon; // 0x80
	public const int TEAM_A = 0; // Metadata: 0x0064C05C
	public const int TEAM_B = 1; // Metadata: 0x0064C05D
	public const int MAX_PER_TEAM = 2; // Metadata: 0x0064C05E
	internal int cachedLocalTeam; // 0x88
	internal int cachedLocalSlot; // 0x8C
	public string currentRoomName; // 0x90
	public GameObject roomPVP_Panel; // 0x98
	public GameObject BtnBackLobby; // 0xA0
	public GameObject BtnBackQuangTruong; // 0xA8
	public Button btnCancel; // 0xB0
	private bool _isLeavingToJoin; // 0xB8
	private bool _leavePvpToPlaza; // 0xB9
	private Coroutine _bridgeJoinWatchdog; // 0xC0
	private MonoBehaviour _bridgeJoinWatchdogHost; // 0xC8
	private bool _bridgeJoinFailed; // 0xD0
	private string _bridgeJoinFailReason; // 0xD8

	// Nested types
	[CompilerGenerated]
	private sealed class _BridgeJoinWatchdog_d__56 : IEnumerator<object> // TypeDefIndex: 209
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RoomPVP_Handler __4__this; // 0x20
		public string roomId; // 0x28
		private float _start_5__2; // 0x30
		private bool _joined_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _BridgeJoinWatchdog_d__56(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806A4000-0x00000001806A44A0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A44A0-0x00000001806A44E0
	}

	[CompilerGenerated]
	private sealed class _ClearJoinErrorAfterDelay_d__45 : IEnumerator<object> // TypeDefIndex: 210
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RoomPVP_Handler __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClearJoinErrorAfterDelay_d__45(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806A44E0-0x00000001806A4610
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A4610-0x00000001806A4650
	}

	[CompilerGenerated]
	private sealed class _CoRefreshAfterKickPVP_d__60 : IEnumerator<object> // TypeDefIndex: 211
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CoRefreshAfterKickPVP_d__60(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806A49F0-0x00000001806A4A70
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A4A70-0x00000001806A4AB0
	}

	[CompilerGenerated]
	private sealed class _WaitForUserAndSend_d__70 : IEnumerator<object> // TypeDefIndex: 212
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RoomPVP_Handler __4__this; // 0x20
		private float _timeout_5__2; // 0x28
		private float _elapsed_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _WaitForUserAndSend_d__70(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001806A60A0-0x00000001806A61D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001806A61D0-0x00000001806A6210
	}

	// Constructors
	public RoomPVP_Handler(); // 0x000000018069D730-0x000000018069D750

	// Methods
	private void Awake(); // 0x0000000180698400-0x0000000180698760
	private void HandleWsStartMatchFailed(ChatMessageDTO msg); // 0x000000018069A080-0x000000018069A240
	private void HandleWsRoomEntered(string roomId); // 0x0000000180699C20-0x0000000180699CE0
	private void HandleWsPlayerStatesChanged(); // 0x0000000180699BB0-0x0000000180699C20
	private void HandleWsMembersChanged(); // 0x0000000180699B20-0x0000000180699BB0
	private void HandleWsKicked(string reason); // 0x0000000180699540-0x0000000180699B20
	private void HandleWsKickFailed(string reason); // 0x00000001806994E0-0x0000000180699540
	private void HandleWsRoomLeft(string oldRoomId); // 0x0000000180699CE0-0x000000018069A080
	public static RoomPVP_Handler Resolve(); // 0x000000018069C1F0-0x000000018069C290
	private void Start(); // 0x000000018069CE80-0x000000018069D450
	private void OnJoinIdInputChanged(string value); // 0x000000018069B560-0x000000018069B600
	public void CreatePVPRoom(); // 0x0000000180699030-0x0000000180699280
	public void LeaveRoomAndReturnToPVPLobby(); // 0x000000018069AA70-0x000000018069AA80
	public void LeaveRoomAndReturnToQuangTruong(); // 0x000000018069AA80-0x000000018069AA90
	public void LeaveRoom(); // 0x000000018069AA90-0x000000018069AEC0
	public void ClearAllUISlots(); // 0x0000000180698B40-0x0000000180698F70
	public void JoinRoomByID(); // 0x000000018069A910-0x000000018069AA70
	private void UndoJoinByIdUISwitch(); // 0x000000018069D450-0x000000018069D5F0
	private void ShowJoinError(string msg); // 0x000000018069C980-0x000000018069CBA0
	[IteratorStateMachine(typeof(_ClearJoinErrorAfterDelay_d__45))]
	private IEnumerator ClearJoinErrorAfterDelay(); // 0x0000000180698F70-0x0000000180698FE0
	public static bool IsRankedRoom(); // 0x000000018069A580-0x000000018069A6A0
	public void HidePanelLoading(); // 0x000000018069A240-0x000000018069A2C0
	internal static bool CanSendJoinRoomToMaster(); // 0x00000001806987F0-0x0000000180698890
	public void JoinPVPRoomFromBrowseList(string wsRoomId); // 0x000000018069A6A0-0x000000018069A910
	private void HandleBridgeJoinFailed(string reason); // 0x00000001806994C0-0x00000001806994E0
	private void StartBridgeJoinWatchdog(string roomId); // 0x000000018069CBA0-0x000000018069CE80
	[IteratorStateMachine(typeof(_BridgeJoinWatchdog_d__56))]
	private IEnumerator BridgeJoinWatchdog(string roomId); // 0x0000000180698760-0x00000001806987F0
	public void SetupPVPRoomUI(bool calledFromFastReturn = false /* Metadata: 0x0064C05B */); // 0x000000018069C440-0x000000018069C980
	public void RefreshRoomOnReturn(); // 0x000000018069BD70-0x000000018069C0F0
	public void OnKickPlayerByUsername(string targetUsername, int actorNumberHint); // 0x000000018069B600-0x000000018069B960
	[IteratorStateMachine(typeof(_CoRefreshAfterKickPVP_d__60))]
	private IEnumerator CoRefreshAfterKickPVP(int kickedActor); // 0x0000000180698FE0-0x0000000180699030
	public void OnReadyButtonClicked(); // 0x000000018069B960-0x000000018069BC20
	private void OnClickReady(); // 0x000000018069AF90-0x000000018069B140
	private void OnClickCancelReady(); // 0x000000018069AEC0-0x000000018069AF90
	private void OnClickStartGame(); // 0x000000018069B140-0x000000018069B210
	internal void InitReadyButton(); // 0x000000018069A2C0-0x000000018069A580
	private void UpdateButtonVisibility(bool isReady); // 0x000000018069D5F0-0x000000018069D6C0
	private bool CanStartGame(); // 0x0000000180698890-0x0000000180698B40
	private void RefreshStartButton(); // 0x000000018069C110-0x000000018069C1F0
	private void SendMySlotProps(); // 0x000000018069C290-0x000000018069C420
	[IteratorStateMachine(typeof(_WaitForUserAndSend_d__70))]
	private IEnumerator WaitForUserAndSend(); // 0x000000018069D6C0-0x000000018069D730
	private void DoSendSlotProps(UserDTO user); // 0x0000000180699280-0x00000001806993A0
	private bool GetLocalWsReady(); // 0x00000001806993A0-0x00000001806994C0
	public void SendSlotPropsPublic(); // 0x000000018069C420-0x000000018069C430
	public void RefreshSlotProps(); // 0x000000018069C0F0-0x000000018069C110
	public void PreassignLocalSlot(); // 0x000000018069BC20-0x000000018069BD70
	public void SetLeavingToJoin(); // 0x000000018069C430-0x000000018069C440
	private void OnDisable(); // 0x000000018069B520-0x000000018069B560
	private void OnDestroy(); // 0x000000018069B210-0x000000018069B520
}

