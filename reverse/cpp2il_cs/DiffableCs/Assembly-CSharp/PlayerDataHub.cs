//Type is in global namespace

public class PlayerDataHub : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <DebouncedFlush>d__28 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PlayerDataHub <>4__this; //Field offset: 0x20
		public string reason; //Field offset: 0x28

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
		public <DebouncedFlush>d__28(int <>1__state) { }

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
	private sealed class <PostMatchRoutine>d__29 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PlayerDataHub <>4__this; //Field offset: 0x20
		public string reason; //Field offset: 0x28
		private float <deadline>5__2; //Field offset: 0x30

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
		public <PostMatchRoutine>d__29(int <>1__state) { }

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
	private static PlayerDataHub <Instance>k__BackingField; //Field offset: 0x0
	private const float DEBOUNCE_SECONDS = 0.35; //Field offset: 0x0
	private const float COMMIT_WAIT_TIMEOUT = 4; //Field offset: 0x0
	private const float SCOPE_COOLDOWN_SECONDS = 1; //Field offset: 0x0
	private const PlayerDataScope COMMIT_DEPENDENT = 3; //Field offset: 0x0
	private PlayerDataScope _dirty; //Field offset: 0x20
	private bool _flushScheduled; //Field offset: 0x24
	private bool _rewardCommitted; //Field offset: 0x25
	private bool _awaitingCommit; //Field offset: 0x26
	private Coroutine _postMatchRoutine; //Field offset: 0x28
	private float _lastDispatchUser; //Field offset: 0x30
	private float _lastDispatchChinhPhuc; //Field offset: 0x34
	private float _lastDispatchEnergy; //Field offset: 0x38
	[CompilerGenerated]
	private Action<PlayerDataScope> OnPlayerDataRefreshed; //Field offset: 0x40

	public event Action<PlayerDataScope> OnPlayerDataRefreshed
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public private static PlayerDataHub Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public PlayerDataHub() { }

	[CompilerGenerated]
	public void add_OnPlayerDataRefreshed(Action<PlayerDataScope> value) { }

	private void Awake() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void Bootstrap() { }

	[IteratorStateMachine(typeof(<DebouncedFlush>d__28))]
	private IEnumerator DebouncedFlush(string reason) { }

	public static PlayerDataHub EnsureInstance() { }

	private void FlushNow(string reason, PlayerDataScope allowed = 15) { }

	public void ForceRefresh(PlayerDataScope scopes, string reason) { }

	[CompilerGenerated]
	public static PlayerDataHub get_Instance() { }

	public void MarkStale(PlayerDataScope scopes, string reason) { }

	public void NotifyRewardCommitted(string matchId) { }

	private void OnDestroy() { }

	[IteratorStateMachine(typeof(<PostMatchRoutine>d__29))]
	private IEnumerator PostMatchRoutine(string reason) { }

	public void RefreshAfterMatch(string reason) { }

	public void RefreshStale(string reason) { }

	[CompilerGenerated]
	public void remove_OnPlayerDataRefreshed(Action<PlayerDataScope> value) { }

	private void RescheduleFlush(string reason) { }

	[CompilerGenerated]
	private static void set_Instance(PlayerDataHub value) { }

}

