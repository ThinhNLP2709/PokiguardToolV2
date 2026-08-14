//Type is in global namespace

public class MatchmakingManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <ClearTransitioningAfter>d__33 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float sec; //Field offset: 0x20
		public MatchmakingManager <>4__this; //Field offset: 0x28

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
		public <ClearTransitioningAfter>d__33(int <>1__state) { }

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
	private sealed class <MmJoinWatchdog>d__44 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchmakingManager <>4__this; //Field offset: 0x20
		public string roomId; //Field offset: 0x28
		private float <t>5__2; //Field offset: 0x30

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
		public <MmJoinWatchdog>d__44(int <>1__state) { }

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
	private sealed class <SearchingStatusCoroutine>d__27 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchmakingManager <>4__this; //Field offset: 0x20
		private String[] <dots>5__2; //Field offset: 0x28
		private int <i>5__3; //Field offset: 0x30

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
		public <SearchingStatusCoroutine>d__27(int <>1__state) { }

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
	private sealed class <SearchTimeoutCoroutine>d__31 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchmakingManager <>4__this; //Field offset: 0x20
		private float <elapsed>5__2; //Field offset: 0x28

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
		public <SearchTimeoutCoroutine>d__31(int <>1__state) { }

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
	private sealed class <StopSearchingSafely>d__32 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchmakingManager <>4__this; //Field offset: 0x20

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
		public <StopSearchingSafely>d__32(int <>1__state) { }

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
	private static MatchmakingManager <Instance>k__BackingField; //Field offset: 0x0
	private const float CLICK_DEBOUNCE = 0.8; //Field offset: 0x0
	public float searchTimeout; //Field offset: 0x20
	[Header("UI tìm trận")]
	public GameObject panelSearching; //Field offset: 0x28
	public Text txtStatus; //Field offset: 0x30
	public GameObject BtnBackLobby; //Field offset: 0x38
	public GameObject BtnBackQuangTruong; //Field offset: 0x40
	public Button btnCancel; //Field offset: 0x48
	[Header("Lobby panel (optional)")]
	[Tooltip("Panel lobby PVP — gán nếu muốn SetLobbyVisible() điều khiển. Bỏ trống cũng OK.")]
	public GameObject lobbyPanel; //Field offset: 0x50
	[Header("Ghép trận button (optional — auto-disable khi click)")]
	[Tooltip("Button 'Ghép trận' — gán để auto-lock sau khi click, tránh spam")]
	public Button btnStartMatchmaking; //Field offset: 0x58
	[Header("Modal Blocker (optional — để trống sẽ auto-tạo)")]
	[Tooltip("GameObject full-screen chặn click xuyên xuống UI khác khi đang searching. Nếu null sẽ auto-tạo.")]
	public GameObject modalBlocker; //Field offset: 0x60
	internal bool _isSearching; //Field offset: 0x68
	internal bool _waitingInRoom; //Field offset: 0x69
	private Coroutine _statusCoroutine; //Field offset: 0x70
	private Coroutine _timeoutCoroutine; //Field offset: 0x78
	private float _searchElapsedSeconds; //Field offset: 0x80
	private float _lastClickTime; //Field offset: 0x84
	private bool _isTransitioning; //Field offset: 0x88
	private ChatService _subscribedCs; //Field offset: 0x90

	public private static MatchmakingManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public MatchmakingManager() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<ClearTransitioningAfter>d__33))]
	private IEnumerator ClearTransitioningAfter(float sec) { }

	private void EnsureModalBlocker() { }

	public static string ExtractRoomIdDisplay(string roomName) { }

	public void ForceResetState() { }

	[CompilerGenerated]
	public static MatchmakingManager get_Instance() { }

	private void HandleMatchmakingFailed(string reason) { }

	private void HandleMatchmakingFound(ChatMessageDTO msg) { }

	private void HandleMmRoomEntered(string roomId) { }

	private void HandleMmRoomEnterFailed(string reason) { }

	private void HideBackButtons() { }

	private static bool IsMmRoomProps(WsRoomService ws) { }

	private void LockStartButton(bool locked) { }

	[IteratorStateMachine(typeof(<MmJoinWatchdog>d__44))]
	private IEnumerator MmJoinWatchdog(string roomId) { }

	private void OnDestroy() { }

	[IteratorStateMachine(typeof(<SearchingStatusCoroutine>d__27))]
	private IEnumerator SearchingStatusCoroutine() { }

	[IteratorStateMachine(typeof(<SearchTimeoutCoroutine>d__31))]
	private IEnumerator SearchTimeoutCoroutine() { }

	[CompilerGenerated]
	private static void set_Instance(MatchmakingManager value) { }

	public void SetActiveButtonNeeded(bool cancel = false, bool BackQuangTruong = false, bool BackLobby = true) { }

	public void SetLobbyVisible(bool visible) { }

	private void ShowBackButtons() { }

	private void ShowModalBlocker(bool show) { }

	private void ShowPanel(bool show) { }

	private void Start() { }

	public void StartSearching() { }

	private void StartSearchingStatus() { }

	public void StopSearching() { }

	[IteratorStateMachine(typeof(<StopSearchingSafely>d__32))]
	private IEnumerator StopSearchingSafely() { }

	private void StopStatusCoroutine() { }

	private bool TrySubscribeWs() { }

	private void UnhookRoomEvents() { }

	private void UnsubscribeWs() { }

}

