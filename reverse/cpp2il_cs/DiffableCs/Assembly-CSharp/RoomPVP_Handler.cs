//Type is in global namespace

public class RoomPVP_Handler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <BridgeJoinWatchdog>d__56 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public RoomPVP_Handler <>4__this; //Field offset: 0x20
		public string roomId; //Field offset: 0x28
		private float <start>5__2; //Field offset: 0x30
		private bool <joined>5__3; //Field offset: 0x34

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <BridgeJoinWatchdog>d__56(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <ClearJoinErrorAfterDelay>d__45 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public RoomPVP_Handler <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <ClearJoinErrorAfterDelay>d__45(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <CoRefreshAfterKickPVP>d__60 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <CoRefreshAfterKickPVP>d__60(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <WaitForUserAndSend>d__70 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public RoomPVP_Handler <>4__this; //Field offset: 0x20
		private float <timeout>5__2; //Field offset: 0x28
		private float <elapsed>5__3; //Field offset: 0x2C

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <WaitForUserAndSend>d__70(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	public static RoomPVP_Handler Instance; //Field offset: 0x0
	public const int MAX_PER_TEAM = 2; //Field offset: 0x0
	public const int TEAM_B = 1; //Field offset: 0x0
	public const int TEAM_A = 0; //Field offset: 0x0
	[SerializeField]
	private GameObject panelLoading; //Field offset: 0x20
	[Header("Room ID")]
	[SerializeField]
	internal Text txtRoomID; //Field offset: 0x28
	[Header("Join Room by ID")]
	[SerializeField]
	private InputField inputJoinRoomID; //Field offset: 0x30
	[SerializeField]
	private Button btnJoinByID; //Field offset: 0x38
	[Header("Room Settings")]
	[SerializeField]
	private byte maxPlayers; //Field offset: 0x40
	[Header("Ready / Start")]
	[SerializeField]
	internal Button readyButton; //Field offset: 0x48
	[SerializeField]
	private Text txtReadyButton; //Field offset: 0x50
	[Header("New Buttons")]
	public Button btnSS; //Field offset: 0x58
	public Button btnCancless; //Field offset: 0x60
	public Button btnPlayGame; //Field offset: 0x68
	public Transform[] panelCard; //Field offset: 0x70
	public Image[] rankIcons; //Field offset: 0x78
	public Sprite Def_RankIcon; //Field offset: 0x80
	internal int cachedLocalTeam; //Field offset: 0x88
	internal int cachedLocalSlot; //Field offset: 0x8C
	public string currentRoomName; //Field offset: 0x90
	public GameObject roomPVP_Panel; //Field offset: 0x98
	public GameObject BtnBackLobby; //Field offset: 0xA0
	public GameObject BtnBackQuangTruong; //Field offset: 0xA8
	public Button btnCancel; //Field offset: 0xB0
	private bool _isLeavingToJoin; //Field offset: 0xB8
	private bool _leavePvpToPlaza; //Field offset: 0xB9
	private Coroutine _bridgeJoinWatchdog; //Field offset: 0xC0
	private MonoBehaviour _bridgeJoinWatchdogHost; //Field offset: 0xC8
	private bool _bridgeJoinFailed; //Field offset: 0xD0
	private string _bridgeJoinFailReason; //Field offset: 0xD8

	public RoomPVP_Handler() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<BridgeJoinWatchdog>d__56))]
	private IEnumerator BridgeJoinWatchdog(string roomId) { }

	internal static bool CanSendJoinRoomToMaster() { }

	private bool CanStartGame() { }

	public void ClearAllUISlots() { }

	[IteratorStateMachine(typeof(<ClearJoinErrorAfterDelay>d__45))]
	private IEnumerator ClearJoinErrorAfterDelay() { }

	[IteratorStateMachine(typeof(<CoRefreshAfterKickPVP>d__60))]
	private IEnumerator CoRefreshAfterKickPVP(int kickedActor) { }

	public void CreatePVPRoom() { }

	private void DoSendSlotProps(UserDTO user) { }

	private bool GetLocalWsReady() { }

	private void HandleBridgeJoinFailed(string reason) { }

	private void HandleWsKicked(string reason) { }

	private void HandleWsKickFailed(string reason) { }

	private void HandleWsMembersChanged() { }

	private void HandleWsPlayerStatesChanged() { }

	private void HandleWsRoomEntered(string roomId) { }

	private void HandleWsRoomLeft(string oldRoomId) { }

	private void HandleWsStartMatchFailed(ChatMessageDTO msg) { }

	public void HidePanelLoading() { }

	internal void InitReadyButton() { }

	public static bool IsRankedRoom() { }

	public void JoinPVPRoomFromBrowseList(string wsRoomId) { }

	public void JoinRoomByID() { }

	public void LeaveRoom() { }

	public void LeaveRoomAndReturnToPVPLobby() { }

	public void LeaveRoomAndReturnToQuangTruong() { }

	private void OnClickCancelReady() { }

	private void OnClickReady() { }

	private void OnClickStartGame() { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnJoinIdInputChanged(string value) { }

	public void OnKickPlayerByUsername(string targetUsername, int actorNumberHint) { }

	public void OnReadyButtonClicked() { }

	public void PreassignLocalSlot() { }

	public void RefreshRoomOnReturn() { }

	public void RefreshSlotProps() { }

	private void RefreshStartButton() { }

	public static RoomPVP_Handler Resolve() { }

	private void SendMySlotProps() { }

	public void SendSlotPropsPublic() { }

	public void SetLeavingToJoin() { }

	public void SetupPVPRoomUI(bool calledFromFastReturn = false) { }

	private void ShowJoinError(string msg) { }

	private void Start() { }

	private void StartBridgeJoinWatchdog(string roomId) { }

	private void UndoJoinByIdUISwitch() { }

	private void UpdateButtonVisibility(bool isReady) { }

	[IteratorStateMachine(typeof(<WaitForUserAndSend>d__70))]
	private IEnumerator WaitForUserAndSend() { }

}

