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

public class RoomPVP_Handler : MonoBehaviour // TypeDefIndex: 233
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
	public const int TEAM_A = 0; // Metadata: 0x0068AD74
	public const int TEAM_B = 1; // Metadata: 0x0068AD75
	public const int MAX_PER_TEAM = 2; // Metadata: 0x0068AD76
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
	private Coroutine _assetGateCo; // 0xE0

	// Nested types
	[CompilerGenerated]
	private sealed class _BridgeJoinWatchdog_d__56 : IEnumerator<object> // TypeDefIndex: 234
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RoomPVP_Handler __4__this; // 0x20
		public string roomId; // 0x28
		private float _start_5__2; // 0x30
		private bool _joined_5__3; // 0x34

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _BridgeJoinWatchdog_d__56(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180851730-0x0000000180851BE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180851BE0-0x0000000180851C20
	}

	[CompilerGenerated]
	private sealed class _ClearJoinErrorAfterDelay_d__45 : IEnumerator<object> // TypeDefIndex: 235
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RoomPVP_Handler __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClearJoinErrorAfterDelay_d__45(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180851C20-0x0000000180851D50
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180851D50-0x0000000180851D90
	}

	[CompilerGenerated]
	private sealed class _CoRefreshAfterKickPVP_d__60 : IEnumerator<object> // TypeDefIndex: 236
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CoRefreshAfterKickPVP_d__60(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180852130-0x00000001808521B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808521B0-0x00000001808521F0
	}

	[CompilerGenerated]
	private sealed class _RunAssetGate_d__67 : IEnumerator<object> // TypeDefIndex: 237
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public List<int> petIds; // 0x20
		public RoomPVP_Handler __4__this; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _RunAssetGate_d__67(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001808527F0-0x0000000180852880
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180852880-0x00000001808528C0
	}

	[CompilerGenerated]
	private sealed class _WaitForUserAndSend_d__73 : IEnumerator<object> // TypeDefIndex: 238
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RoomPVP_Handler __4__this; // 0x20
		private float _timeout_5__2; // 0x28
		private float _elapsed_5__3; // 0x2C

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _WaitForUserAndSend_d__73(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x0000000180853B50-0x0000000180853C80
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180853C80-0x0000000180853CC0
	}

	// Constructors
	public RoomPVP_Handler(); // 0x000000018083E160-0x000000018083E180

	// Methods
	private void Awake(); // 0x0000000180838870-0x0000000180838BD0
	private void HandleWsStartMatchFailed(ChatMessageDTO msg); // 0x000000018083A6A0-0x000000018083A880
	private void HandleWsRoomEntered(string roomId); // 0x000000018083A1B0-0x000000018083A270
	private void HandleWsPlayerStatesChanged(); // 0x000000018083A140-0x000000018083A1B0
	private void HandleWsMembersChanged(); // 0x000000018083A0B0-0x000000018083A140
	private void HandleWsKicked(string reason); // 0x0000000180839940-0x000000018083A0B0
	private void HandleWsKickFailed(string reason); // 0x00000001808398E0-0x0000000180839940
	private void HandleWsRoomLeft(string oldRoomId); // 0x000000018083A270-0x000000018083A6A0
	public static RoomPVP_Handler Resolve(); // 0x000000018083CA80-0x000000018083CB20
	private void Start(); // 0x000000018083D8B0-0x000000018083DE80
	private void OnJoinIdInputChanged(string value); // 0x000000018083C130-0x000000018083C1D0
	public void CreatePVPRoom(); // 0x00000001808393F0-0x0000000180839680
	public void LeaveRoomAndReturnToPVPLobby(); // 0x000000018083B350-0x000000018083B360
	public void LeaveRoomAndReturnToQuangTruong(); // 0x000000018083B360-0x000000018083B370
	public void LeaveRoom(); // 0x000000018083B370-0x000000018083B8B0
	public void ClearAllUISlots(); // 0x0000000180838FB0-0x0000000180839330
	public void JoinRoomByID(); // 0x000000018083AFA0-0x000000018083B100
	private void UndoJoinByIdUISwitch(); // 0x000000018083DE80-0x000000018083E020
	private void ShowJoinError(string msg); // 0x000000018083D3A0-0x000000018083D5D0
	[IteratorStateMachine(typeof(_ClearJoinErrorAfterDelay_d__45))]
	private IEnumerator ClearJoinErrorAfterDelay(); // 0x0000000180839330-0x00000001808393A0
	public static bool IsRankedRoom(); // 0x000000018083ABC0-0x000000018083ACE0
	public void HidePanelLoading(); // 0x000000018083A880-0x000000018083A900
	internal static bool CanSendJoinRoomToMaster(); // 0x0000000180838C60-0x0000000180838D00
	public void JoinPVPRoomFromBrowseList(string wsRoomId); // 0x000000018083ACE0-0x000000018083AFA0
	private void HandleBridgeJoinFailed(string reason); // 0x00000001808398C0-0x00000001808398E0
	private void StartBridgeJoinWatchdog(string roomId); // 0x000000018083D5D0-0x000000018083D8B0
	[IteratorStateMachine(typeof(_BridgeJoinWatchdog_d__56))]
	private IEnumerator BridgeJoinWatchdog(string roomId); // 0x0000000180838BD0-0x0000000180838C60
	public void SetupPVPRoomUI(bool calledFromFastReturn = false /* Metadata: 0x0068AD73 */); // 0x000000018083CE70-0x000000018083D3A0
	public void RefreshRoomOnReturn(); // 0x000000018083C600-0x000000018083C980
	public void OnKickPlayerByUsername(string targetUsername, int actorNumberHint); // 0x000000018083C1D0-0x000000018083C450
	[IteratorStateMachine(typeof(_CoRefreshAfterKickPVP_d__60))]
	private IEnumerator CoRefreshAfterKickPVP(int kickedActor); // 0x00000001808393A0-0x00000001808393F0
	public void OnReadyButtonClicked(); // 0x000000018083C450-0x000000018083C4B0
	private void OnClickReady(); // 0x000000018083B980-0x000000018083BB40
	private void OnClickCancelReady(); // 0x000000018083B8B0-0x000000018083B980
	private void OnClickStartGame(); // 0x000000018083BB40-0x000000018083BDE0
	private void KickOffAssetGate(); // 0x000000018083B100-0x000000018083B350
	[IteratorStateMachine(typeof(_RunAssetGate_d__67))]
	private IEnumerator RunAssetGate(List<int> petIds); // 0x000000018083CB20-0x000000018083CBB0
	internal void InitReadyButton(); // 0x000000018083A900-0x000000018083ABC0
	private void UpdateButtonVisibility(bool isReady); // 0x000000018083E020-0x000000018083E0F0
	private bool CanStartGame(); // 0x0000000180838D00-0x0000000180838FB0
	private void RefreshStartButton(); // 0x000000018083C9A0-0x000000018083CA80
	private void SendMySlotProps(); // 0x000000018083CBB0-0x000000018083CE50
	[IteratorStateMachine(typeof(_WaitForUserAndSend_d__73))]
	private IEnumerator WaitForUserAndSend(); // 0x000000018083E0F0-0x000000018083E160
	private void DoSendSlotProps(UserDTO user); // 0x0000000180839680-0x00000001808397A0
	private bool GetLocalWsReady(); // 0x00000001808397A0-0x00000001808398C0
	public void SendSlotPropsPublic(); // 0x000000018083CE50-0x000000018083CE60
	public void RefreshSlotProps(); // 0x000000018083C980-0x000000018083C9A0
	public void PreassignLocalSlot(); // 0x000000018083C4B0-0x000000018083C600
	public void SetLeavingToJoin(); // 0x000000018083CE60-0x000000018083CE70
	private void OnDisable(); // 0x000000018083C0F0-0x000000018083C130
	private void OnDestroy(); // 0x000000018083BDE0-0x000000018083C0F0
}

