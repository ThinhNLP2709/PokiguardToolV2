//Type is in global namespace

public class PvpMatchStarter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <SnapshotWatchdog>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
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
		public <SnapshotWatchdog>d__18(int <>1__state) { }

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
	private sealed class <WsLoadMatchPvp>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PvpMatchStarter <>4__this; //Field offset: 0x20

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
		public <WsLoadMatchPvp>d__16(int <>1__state) { }

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
	private static PvpMatchStarter <Instance>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static bool <IsStarting>k__BackingField; //Field offset: 0x8
	private Coroutine _startCoroutine; //Field offset: 0x20
	private bool _subscribed; //Field offset: 0x28

	public private static PvpMatchStarter Instance
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

	public PvpMatchStarter() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void AutoInit() { }

	private void Awake() { }

	[CompilerGenerated]
	public static PvpMatchStarter get_Instance() { }

	[CompilerGenerated]
	public static bool get_IsStarting() { }

	private void HandleMatchStarting(string roomId, Dictionary<String, Object> properties) { }

	private void OnDestroy() { }

	private static void PrewarmRoomPetClips() { }

	[CompilerGenerated]
	private static void set_Instance(PvpMatchStarter value) { }

	[CompilerGenerated]
	private static void set_IsStarting(bool value) { }

	[IteratorStateMachine(typeof(<SnapshotWatchdog>d__18))]
	private IEnumerator SnapshotWatchdog() { }

	private void Subscribe() { }

	private void Unsubscribe() { }

	[IteratorStateMachine(typeof(<WsLoadMatchPvp>d__16))]
	private IEnumerator WsLoadMatchPvp() { }

}

