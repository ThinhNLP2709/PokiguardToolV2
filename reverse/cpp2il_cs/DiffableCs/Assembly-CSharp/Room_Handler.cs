//Type is in global namespace

public class Room_Handler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <LoadRoomThenHideGlobalLoading>d__37 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRoom mgr; //Field offset: 0x20

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
		public <LoadRoomThenHideGlobalLoading>d__37(int <>1__state) { }

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
	private sealed class <WaitForDataAndSend>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerRoom manager; //Field offset: 0x20
		public Room_Handler <>4__this; //Field offset: 0x28
		public int slotIndex; //Field offset: 0x30
		private float <timeout>5__2; //Field offset: 0x34
		private float <elapsed>5__3; //Field offset: 0x38

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
		public <WaitForDataAndSend>d__40(int <>1__state) { }

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
	private sealed class <WaitToGetData>d__44 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float s; //Field offset: 0x20
		public Room_Handler <>4__this; //Field offset: 0x28
		public int slotIndex; //Field offset: 0x30
		public UserDTO user; //Field offset: 0x38
		public ManagerRoom manager; //Field offset: 0x40
		public int retryCount; //Field offset: 0x48

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
		public <WaitToGetData>d__44(int <>1__state) { }

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

	public static Room_Handler Instance; //Field offset: 0x0
	private const int SEND_PROPS_MAX_RETRY = 3; //Field offset: 0x0
	private static bool _forceCloseRoomOnReturn; //Field offset: 0x8
	[Header("Room Settings")]
	[SerializeField]
	private byte maxPlayers; //Field offset: 0x20
	[Header("UI")]
	public GameObject panelRoom; //Field offset: 0x28
	[Header("Ready Button Settings")]
	[SerializeField]
	internal Button readyButton; //Field offset: 0x30
	[SerializeField]
	internal Color disabledColor; //Field offset: 0x38
	public string currentRoomName; //Field offset: 0x48
	public Transform[] panelCard; //Field offset: 0x50
	internal ManagerRoom managerRoom; //Field offset: 0x58
	private string _lastKnownOwner; //Field offset: 0x60
	private Button _btnLockRoom; //Field offset: 0x68
	private Text _btnLockRoomLabel; //Field offset: 0x70

	public Room_Handler() { }

	private void Awake() { }

	internal void CleanupLocalRoomState() { }

	private void ClearAllUISlots() { }

	private static Transform FindDeepChild(Transform root, string name) { }

	private void HandleWsKicked(string reason) { }

	private void HandleWsKickFailed(string reason) { }

	private void HandleWsMembersChanged() { }

	private void HandleWsPlayerStatesChanged() { }

	private void HandleWsPropertiesChanged() { }

	private void HandleWsRoomEnteredLobby(string roomId) { }

	private void HandleWsRoomLeft(string oldRoomId) { }

	private void HandleWsStartMatchFailed(ChatMessageDTO msg) { }

	private void InitLockButton() { }

	internal void InitReadyButton() { }

	public static bool IsCreatorName(string username) { }

	public static bool IsRoomLocked() { }

	public static bool IsRoomOwner() { }

	public void LeaveRoom() { }

	[IteratorStateMachine(typeof(<LoadRoomThenHideGlobalLoading>d__37))]
	private IEnumerator LoadRoomThenHideGlobalLoading(ManagerRoom mgr) { }

	private void OnDestroy() { }

	public void OnKickPlayerByName(string targetUsername) { }

	private void OnLockRoomClicked() { }

	public void OnReadyButtonClicked(Button button) { }

	private void RefreshLockButtonVisual() { }

	public void RefreshRoomOnReturn() { }

	private int ResolveMySlotFromWs() { }

	private void SendMySlotProps(int slotIndex) { }

	private void SendPropsWithData(int slotIndex, UserDTO user, ManagerRoom manager) { }

	private void SendPropsWithDataInternal(int slotIndex, UserDTO user, ManagerRoom manager, int retryCount) { }

	private void ShowRoomNotice(string message) { }

	private void UpdatePlayerSlotsAfterReconnect() { }

	public void UpdatePlayerSlotsFromTracker() { }

	private void UpdateReadyButtonVisual(Button button, Text buttonText, bool isReady) { }

	[IteratorStateMachine(typeof(<WaitForDataAndSend>d__40))]
	private IEnumerator WaitForDataAndSend(int slotIndex, ManagerRoom manager) { }

	[IteratorStateMachine(typeof(<WaitToGetData>d__44))]
	private IEnumerator WaitToGetData(float s, int slotIndex, UserDTO user, ManagerRoom manager, int retryCount) { }

}

