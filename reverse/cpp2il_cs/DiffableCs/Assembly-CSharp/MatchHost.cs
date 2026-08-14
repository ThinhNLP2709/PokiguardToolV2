//Type is in global namespace

public static class MatchHost
{
	[CompilerGenerated]
	private sealed class <EnsureRigReady>d__33 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchKind kind; //Field offset: 0x20
		private AsyncOperationHandle<GameObject> <handle>5__2; //Field offset: 0x28

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
		public <EnsureRigReady>d__33(int <>1__state) { }

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
	private sealed class <Enter>d__37 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchKind kind; //Field offset: 0x20
		private string <address>5__2; //Field offset: 0x28
		private float <t0>5__3; //Field offset: 0x30
		private AsyncOperationHandle<GameObject> <handle>5__4; //Field offset: 0x38

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
		public <Enter>d__37(int <>1__state) { }

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
	private sealed class <Exit>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private MatchKind <kind>5__2; //Field offset: 0x20

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
		public <Exit>d__38(int <>1__state) { }

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
	private sealed class <WatchdogGuard>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private float <start>5__2; //Field offset: 0x20

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
		public <WatchdogGuard>d__40(int <>1__state) { }

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

	private const string RIG_ADDRESS_COOP = "Assets/Prefabs/Match/MatchRig.prefab"; //Field offset: 0x0
	private const string RIG_ADDRESS_PVP = "Assets/Prefabs/Match/MatchRigPvp.prefab"; //Field offset: 0x0
	private const float BUILD_WATCHDOG_SEC = 30; //Field offset: 0x0
	[CompilerGenerated]
	private static MatchState <State>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private static Nullable<MatchKind> <CurrentKind>k__BackingField; //Field offset: 0x4
	[CompilerGenerated]
	private static GameObject <CurrentRig>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private static Camera <RigCamera>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private static Action<MatchKind> OnEnter; //Field offset: 0x20
	[CompilerGenerated]
	private static Action<MatchKind> OnExit; //Field offset: 0x28
	private static readonly Dictionary<String, AsyncOperationHandle`1<GameObject>> _rigHandles; //Field offset: 0x30

	public static event Action<MatchKind> OnEnter
	{
		[CompilerGenerated]
		 add { } //Length: 261
		[CompilerGenerated]
		 remove { } //Length: 261
	}

	public static event Action<MatchKind> OnExit
	{
		[CompilerGenerated]
		 add { } //Length: 261
		[CompilerGenerated]
		 remove { } //Length: 261
	}

	public private static Nullable<MatchKind> CurrentKind
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 85
	}

	public private static GameObject CurrentRig
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 110
	}

	public static bool IsBusy
	{
		 get { } //Length: 302
	}

	public static bool IsInMatch
	{
		 get { } //Length: 371
	}

	public private static Camera RigCamera
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 110
	}

	public private static MatchState State
	{
		[CompilerGenerated]
		 get { } //Length: 77
		[CompilerGenerated]
		private set { } //Length: 82
	}

	private static MatchHost() { }

	[CompilerGenerated]
	public static void add_OnEnter(Action<MatchKind> value) { }

	[CompilerGenerated]
	public static void add_OnExit(Action<MatchKind> value) { }

	private static string AddressOf(MatchKind kind) { }

	private static void DropRigHandle(string address) { }

	[IteratorStateMachine(typeof(<EnsureRigReady>d__33))]
	public static IEnumerator EnsureRigReady(MatchKind kind) { }

	[IteratorStateMachine(typeof(<Enter>d__37))]
	public static IEnumerator Enter(MatchKind kind) { }

	[IteratorStateMachine(typeof(<Exit>d__38))]
	public static IEnumerator Exit() { }

	public static void ForceReset() { }

	[CompilerGenerated]
	public static Nullable<MatchKind> get_CurrentKind() { }

	[CompilerGenerated]
	public static GameObject get_CurrentRig() { }

	public static bool get_IsBusy() { }

	public static bool get_IsInMatch() { }

	[CompilerGenerated]
	public static Camera get_RigCamera() { }

	[CompilerGenerated]
	public static MatchState get_State() { }

	public static bool IsRigReady(MatchKind kind) { }

	public static void Prewarm(MatchKind kind) { }

	[CompilerGenerated]
	public static void remove_OnEnter(Action<MatchKind> value) { }

	[CompilerGenerated]
	public static void remove_OnExit(Action<MatchKind> value) { }

	[CompilerGenerated]
	private static void set_CurrentKind(Nullable<MatchKind> value) { }

	[CompilerGenerated]
	private static void set_CurrentRig(GameObject value) { }

	[CompilerGenerated]
	private static void set_RigCamera(Camera value) { }

	[CompilerGenerated]
	private static void set_State(MatchState value) { }

	private static AsyncOperationHandle<GameObject> StartRigLoad(string address) { }

	public static bool SupportsPrefab(MatchKind kind) { }

	[IteratorStateMachine(typeof(<WatchdogGuard>d__40))]
	public static IEnumerator WatchdogGuard() { }

}

