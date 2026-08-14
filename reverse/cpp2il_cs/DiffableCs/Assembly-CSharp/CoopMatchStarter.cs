//Type is in global namespace

public class CoopMatchStarter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public bool failed; //Field offset: 0x10
		public string failReason; //Field offset: 0x18

		public <>c__DisplayClass26_0() { }

		internal void <TryRejoinLobby>b__0(string r) { }

	}

	[CompilerGenerated]
	private sealed class <SnapshotWatchdog>d__22 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private float <rigDeadline>5__2; //Field offset: 0x20
		private int <attempt>5__3; //Field offset: 0x24
		private float <deadline>5__4; //Field offset: 0x28

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
		public <SnapshotWatchdog>d__22(int <>1__state) { }

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
	private sealed class <TryRejoinLobby>d__26 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public CoopMatchStarter <>4__this; //Field offset: 0x20
		private <>c__DisplayClass26_0 <>8__1; //Field offset: 0x28
		private WsRoomService <ws>5__2; //Field offset: 0x30
		private string <roomId>5__3; //Field offset: 0x38
		private Action<String> <onFail>5__4; //Field offset: 0x40
		private float <start>5__5; //Field offset: 0x48

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
		public <TryRejoinLobby>d__26(int <>1__state) { }

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
	private sealed class <WsLoadMatchThenVoiceJoin>d__21 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public CoopMatchStarter <>4__this; //Field offset: 0x20

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
		public <WsLoadMatchThenVoiceJoin>d__21(int <>1__state) { }

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
	private static CoopMatchStarter <Instance>k__BackingField; //Field offset: 0x0
	private const float REJOIN_GRACE_SEC = 60; //Field offset: 0x0
	private const float REJOIN_SETTLE_DELAY = 1; //Field offset: 0x0
	[CompilerGenerated]
	private static bool <IsStarting>k__BackingField; //Field offset: 0x8
	private string _rejoinRoomId; //Field offset: 0x20
	private float _rejoinDeadline; //Field offset: 0x28
	private Coroutine _rejoinCoroutine; //Field offset: 0x30
	private Coroutine _startCoroutine; //Field offset: 0x38
	private bool _subscribed; //Field offset: 0x40

	public private static CoopMatchStarter Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public private static bool IsStarting
	{
		[CompilerGenerated]
		 get { } //Length: 55
		[CompilerGenerated]
		private set { } //Length: 60
	}

	public CoopMatchStarter() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void AutoInit() { }

	private void Awake() { }

	[CompilerGenerated]
	public static CoopMatchStarter get_Instance() { }

	[CompilerGenerated]
	public static bool get_IsStarting() { }

	private void HandleConnectionChanged(bool connected) { }

	private void HandleMatchStarting(string roomId, Dictionary<String, Object> properties) { }

	private void HandleRejoinFailedUI(string reason) { }

	private void HandleRoomEntered(string roomId) { }

	private void HandleRoomLeft(string oldRoomId) { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private static void set_Instance(CoopMatchStarter value) { }

	[CompilerGenerated]
	private static void set_IsStarting(bool value) { }

	private static void ShowToast(string message) { }

	[IteratorStateMachine(typeof(<SnapshotWatchdog>d__22))]
	private IEnumerator SnapshotWatchdog() { }

	private void Subscribe() { }

	[IteratorStateMachine(typeof(<TryRejoinLobby>d__26))]
	private IEnumerator TryRejoinLobby() { }

	private void Unsubscribe() { }

	[IteratorStateMachine(typeof(<WsLoadMatchThenVoiceJoin>d__21))]
	private IEnumerator WsLoadMatchThenVoiceJoin(string roomId) { }

}

