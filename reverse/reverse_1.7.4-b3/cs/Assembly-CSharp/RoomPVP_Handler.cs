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
	public const int TEAM_A = 0; // Metadata: 0x005ED99F
	public const int TEAM_B = 1; // Metadata: 0x005ED9A0
	public const int MAX_PER_TEAM = 2; // Metadata: 0x005ED9A1
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _BridgeJoinWatchdog_d__56(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180D521A0-0x0000000180D528B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D528B0-0x0000000180D528F0
	}

	[CompilerGenerated]
	private sealed class _ClearJoinErrorAfterDelay_d__45 : IEnumerator<object> // TypeDefIndex: 235
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public RoomPVP_Handler __4__this; // 0x20

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClearJoinErrorAfterDelay_d__45(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180D528F0-0x0000000180D52AF0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D52AF0-0x0000000180D52B30
	}

	[CompilerGenerated]
	private sealed class _CoRefreshAfterKickPVP_d__60 : IEnumerator<object> // TypeDefIndex: 236
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CoRefreshAfterKickPVP_d__60(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180D52B30-0x0000000180D52BB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D52BB0-0x0000000180D52BF0
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _RunAssetGate_d__67(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180D52BF0-0x0000000180D52D10
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D52D10-0x0000000180D52D50
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
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _WaitForUserAndSend_d__73(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x0000000180D52D50-0x0000000180D52ED0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D52ED0-0x0000000180D52F10
	}

	// Constructors
	public RoomPVP_Handler(); // 0x0000000180CA2FC0-0x0000000180CA3020

	// Methods
	private void Awake(); // 0x0000000180C998E0-0x0000000180C99DD0
	private void HandleWsStartMatchFailed(ChatMessageDTO msg); // 0x0000000180C99DD0-0x0000000180C9A020
	private void HandleWsRoomEntered(string roomId); // 0x0000000180C9A020-0x0000000180C9A0E0
	private void HandleWsPlayerStatesChanged(); // 0x0000000180C9A0E0-0x0000000180C9A150
	private void HandleWsMembersChanged(); // 0x0000000180C9A150-0x0000000180C9A1E0
	private void HandleWsKicked(string reason); // 0x0000000180C9A1E0-0x0000000180C9AD30
	private void HandleWsKickFailed(string reason); // 0x0000000180C9AD30-0x0000000180C9AD90
	private void HandleWsRoomLeft(string oldRoomId); // 0x0000000180C9AD90-0x0000000180C9B460
	public static RoomPVP_Handler Resolve(); // 0x0000000180C9B460-0x0000000180C9B590
	private void Start(); // 0x0000000180C9B590-0x0000000180C9C180
	private void OnJoinIdInputChanged(string value); // 0x0000000180C9C180-0x0000000180C9C2A0
	public void CreatePVPRoom(); // 0x0000000180C9C2A0-0x0000000180C9C770
	public void LeaveRoomAndReturnToPVPLobby(); // 0x0000000180C9C770-0x0000000180C9C780
	public void LeaveRoomAndReturnToQuangTruong(); // 0x0000000180C9C780-0x0000000180C9C790
	public void LeaveRoom(); // 0x0000000180C9C790-0x0000000180C9D060
	public void ClearAllUISlots(); // 0x0000000180C9D060-0x0000000180C9D5D0
	public void JoinRoomByID(); // 0x0000000180C9D5D0-0x0000000180C9D7D0
	private void UndoJoinByIdUISwitch(); // 0x0000000180C9D7D0-0x0000000180C9DEE0
	private void ShowJoinError(string msg); // 0x0000000180C9DEE0-0x0000000180C9E520
	[IteratorStateMachine(typeof(_ClearJoinErrorAfterDelay_d__45))]
	private IEnumerator ClearJoinErrorAfterDelay(); // 0x0000000180C9E520-0x0000000180C9E5C0
	public static bool IsRankedRoom(); // 0x0000000180C9E5C0-0x0000000180C9E7B0
	public void HidePanelLoading(); // 0x0000000180C9E7B0-0x0000000180C9E8F0
	internal static bool CanSendJoinRoomToMaster(); // 0x0000000180C9E8F0-0x0000000180C9EA10
	public void JoinPVPRoomFromBrowseList(string wsRoomId); // 0x0000000180C9EA10-0x0000000180C9EF50
	private void HandleBridgeJoinFailed(string reason); // 0x0000000180C9EF50-0x0000000180C9EFC0
	private void StartBridgeJoinWatchdog(string roomId); // 0x0000000180C9EFC0-0x0000000180C9F6A0
	[IteratorStateMachine(typeof(_BridgeJoinWatchdog_d__56))]
	private IEnumerator BridgeJoinWatchdog(string roomId); // 0x0000000180C9F6A0-0x0000000180C9F7B0
	public void SetupPVPRoomUI(bool calledFromFastReturn = false /* Metadata: 0x005ED99E */); // 0x0000000180C9F7B0-0x0000000180CA02C0
	public void RefreshRoomOnReturn(); // 0x0000000180CA02C0-0x0000000180CA0840
	public void OnKickPlayerByUsername(string targetUsername, int actorNumberHint); // 0x0000000180CA0840-0x0000000180CA0B70
	[IteratorStateMachine(typeof(_CoRefreshAfterKickPVP_d__60))]
	private IEnumerator CoRefreshAfterKickPVP(int kickedActor); // 0x0000000180CA0B70-0x0000000180CA0BB0
	public void OnReadyButtonClicked(); // 0x0000000180CA0BB0-0x0000000180CA0CE0
	private void OnClickReady(); // 0x0000000180CA0CE0-0x0000000180CA0F80
	private void OnClickCancelReady(); // 0x0000000180CA0F80-0x0000000180CA1030
	private void OnClickStartGame(); // 0x0000000180CA1030-0x0000000180CA1120
	private void KickOffAssetGate(); // 0x0000000180CA1120-0x0000000180CA14C0
	[IteratorStateMachine(typeof(_RunAssetGate_d__67))]
	private IEnumerator RunAssetGate(List<int> petIds); // 0x0000000180CA14C0-0x0000000180CA15D0
	internal void InitReadyButton(); // 0x0000000180CA15D0-0x0000000180CA1BE0
	private void UpdateButtonVisibility(bool isReady); // 0x0000000180CA1BE0-0x0000000180CA1E70
	private bool CanStartGame(); // 0x0000000180CA1E70-0x0000000180CA2240
	private void RefreshStartButton(); // 0x0000000180CA2240-0x0000000180CA2430
	private void SendMySlotProps(); // 0x0000000180CA2430-0x0000000180CA2690
	[IteratorStateMachine(typeof(_WaitForUserAndSend_d__73))]
	private IEnumerator WaitForUserAndSend(); // 0x0000000180CA2690-0x0000000180CA2730
	private void DoSendSlotProps(UserDTO user); // 0x0000000180CA2730-0x0000000180CA2890
	private bool GetLocalWsReady(); // 0x0000000180CA2890-0x0000000180CA29B0
	public void SendSlotPropsPublic(); // 0x0000000180CA29B0-0x0000000180CA29C0
	public void RefreshSlotProps(); // 0x0000000180CA29C0-0x0000000180CA29E0
	public void PreassignLocalSlot(); // 0x0000000180CA29E0-0x0000000180CA2B50
	public void SetLeavingToJoin(); // 0x0000000180CA2B50-0x0000000180CA2B60
	private void OnDisable(); // 0x0000000180CA2B60-0x0000000180CA2BF0
	private void OnDestroy(); // 0x0000000180CA2BF0-0x0000000180CA2FC0
}

