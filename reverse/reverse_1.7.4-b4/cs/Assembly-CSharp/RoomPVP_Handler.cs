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
	public const int TEAM_A = 0; // Metadata: 0x005EED6F
	public const int TEAM_B = 1; // Metadata: 0x005EED70
	public const int MAX_PER_TEAM = 2; // Metadata: 0x005EED71
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180D5FF60-0x0000000180D60670
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D60670-0x0000000180D606B0
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180D606B0-0x0000000180D608B0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D608B0-0x0000000180D608F0
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180D608F0-0x0000000180D60970
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D60970-0x0000000180D609B0
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180D609B0-0x0000000180D60AD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D60AD0-0x0000000180D60B10
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x0000000180D60B10-0x0000000180D60C90
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x0000000180D60C90-0x0000000180D60CD0
	}

	// Constructors
	public RoomPVP_Handler(); // 0x0000000180CA5120-0x0000000180CA5180

	// Methods
	private void Awake(); // 0x0000000180C9BA40-0x0000000180C9BF30
	private void HandleWsStartMatchFailed(ChatMessageDTO msg); // 0x0000000180C9BF30-0x0000000180C9C180
	private void HandleWsRoomEntered(string roomId); // 0x0000000180C9C180-0x0000000180C9C240
	private void HandleWsPlayerStatesChanged(); // 0x0000000180C9C240-0x0000000180C9C2B0
	private void HandleWsMembersChanged(); // 0x0000000180C9C2B0-0x0000000180C9C340
	private void HandleWsKicked(string reason); // 0x0000000180C9C340-0x0000000180C9CE90
	private void HandleWsKickFailed(string reason); // 0x0000000180C9CE90-0x0000000180C9CEF0
	private void HandleWsRoomLeft(string oldRoomId); // 0x0000000180C9CEF0-0x0000000180C9D5C0
	public static RoomPVP_Handler Resolve(); // 0x0000000180C9D5C0-0x0000000180C9D6F0
	private void Start(); // 0x0000000180C9D6F0-0x0000000180C9E2E0
	private void OnJoinIdInputChanged(string value); // 0x0000000180C9E2E0-0x0000000180C9E400
	public void CreatePVPRoom(); // 0x0000000180C9E400-0x0000000180C9E8D0
	public void LeaveRoomAndReturnToPVPLobby(); // 0x0000000180C9E8D0-0x0000000180C9E8E0
	public void LeaveRoomAndReturnToQuangTruong(); // 0x0000000180C9E8E0-0x0000000180C9E8F0
	public void LeaveRoom(); // 0x0000000180C9E8F0-0x0000000180C9F1C0
	public void ClearAllUISlots(); // 0x0000000180C9F1C0-0x0000000180C9F730
	public void JoinRoomByID(); // 0x0000000180C9F730-0x0000000180C9F930
	private void UndoJoinByIdUISwitch(); // 0x0000000180C9F930-0x0000000180CA0040
	private void ShowJoinError(string msg); // 0x0000000180CA0040-0x0000000180CA0680
	[IteratorStateMachine(typeof(_ClearJoinErrorAfterDelay_d__45))]
	private IEnumerator ClearJoinErrorAfterDelay(); // 0x0000000180CA0680-0x0000000180CA0720
	public static bool IsRankedRoom(); // 0x0000000180CA0720-0x0000000180CA0910
	public void HidePanelLoading(); // 0x0000000180CA0910-0x0000000180CA0A50
	internal static bool CanSendJoinRoomToMaster(); // 0x0000000180CA0A50-0x0000000180CA0B70
	public void JoinPVPRoomFromBrowseList(string wsRoomId); // 0x0000000180CA0B70-0x0000000180CA10B0
	private void HandleBridgeJoinFailed(string reason); // 0x0000000180CA10B0-0x0000000180CA1120
	private void StartBridgeJoinWatchdog(string roomId); // 0x0000000180CA1120-0x0000000180CA1800
	[IteratorStateMachine(typeof(_BridgeJoinWatchdog_d__56))]
	private IEnumerator BridgeJoinWatchdog(string roomId); // 0x0000000180CA1800-0x0000000180CA1910
	public void SetupPVPRoomUI(bool calledFromFastReturn = false /* Metadata: 0x005EED6E */); // 0x0000000180CA1910-0x0000000180CA2420
	public void RefreshRoomOnReturn(); // 0x0000000180CA2420-0x0000000180CA29A0
	public void OnKickPlayerByUsername(string targetUsername, int actorNumberHint); // 0x0000000180CA29A0-0x0000000180CA2CD0
	[IteratorStateMachine(typeof(_CoRefreshAfterKickPVP_d__60))]
	private IEnumerator CoRefreshAfterKickPVP(int kickedActor); // 0x0000000180CA2CD0-0x0000000180CA2D10
	public void OnReadyButtonClicked(); // 0x0000000180CA2D10-0x0000000180CA2E40
	private void OnClickReady(); // 0x0000000180CA2E40-0x0000000180CA30E0
	private void OnClickCancelReady(); // 0x0000000180CA30E0-0x0000000180CA3190
	private void OnClickStartGame(); // 0x0000000180CA3190-0x0000000180CA3280
	private void KickOffAssetGate(); // 0x0000000180CA3280-0x0000000180CA3620
	[IteratorStateMachine(typeof(_RunAssetGate_d__67))]
	private IEnumerator RunAssetGate(List<int> petIds); // 0x0000000180CA3620-0x0000000180CA3730
	internal void InitReadyButton(); // 0x0000000180CA3730-0x0000000180CA3D40
	private void UpdateButtonVisibility(bool isReady); // 0x0000000180CA3D40-0x0000000180CA3FD0
	private bool CanStartGame(); // 0x0000000180CA3FD0-0x0000000180CA43A0
	private void RefreshStartButton(); // 0x0000000180CA43A0-0x0000000180CA4590
	private void SendMySlotProps(); // 0x0000000180CA4590-0x0000000180CA47F0
	[IteratorStateMachine(typeof(_WaitForUserAndSend_d__73))]
	private IEnumerator WaitForUserAndSend(); // 0x0000000180CA47F0-0x0000000180CA4890
	private void DoSendSlotProps(UserDTO user); // 0x0000000180CA4890-0x0000000180CA49F0
	private bool GetLocalWsReady(); // 0x0000000180CA49F0-0x0000000180CA4B10
	public void SendSlotPropsPublic(); // 0x0000000180CA4B10-0x0000000180CA4B20
	public void RefreshSlotProps(); // 0x0000000180CA4B20-0x0000000180CA4B40
	public void PreassignLocalSlot(); // 0x0000000180CA4B40-0x0000000180CA4CB0
	public void SetLeavingToJoin(); // 0x0000000180CA4CB0-0x0000000180CA4CC0
	private void OnDisable(); // 0x0000000180CA4CC0-0x0000000180CA4D50
	private void OnDestroy(); // 0x0000000180CA4D50-0x0000000180CA5120
}

