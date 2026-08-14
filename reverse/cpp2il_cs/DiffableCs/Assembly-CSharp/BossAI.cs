//Type is in global namespace

public class BossAI : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__23_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <InitializeBossTime>b__23_1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public bool success; //Field offset: 0x10
		public Action <>9__0; //Field offset: 0x18

		public <>c__DisplayClass14_0() { }

		internal void <SubmitBossDamage>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_1
	{
		public int retry; //Field offset: 0x10

		public <>c__DisplayClass14_1() { }

		internal void <SubmitBossDamage>b__1(string err) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public long bossScheduleId; //Field offset: 0x10
		public BossAI <>4__this; //Field offset: 0x18
		public bool success; //Field offset: 0x20
		public Predicate<WorldBossDTO> <>9__2; //Field offset: 0x28

		public <>c__DisplayClass23_0() { }

		internal void <InitializeBossTime>b__0(List<WorldBossDTO> bossList) { }

		internal bool <InitializeBossTime>b__2(WorldBossDTO b) { }

	}

	[CompilerGenerated]
	private sealed class <AutoReturnFromBossTimeout>d__19 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BossAI <>4__this; //Field offset: 0x20
		public float delay; //Field offset: 0x28

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
		public <AutoReturnFromBossTimeout>d__19(int <>1__state) { }

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
	private sealed class <BossCountdownCoroutine>d__26 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BossAI <>4__this; //Field offset: 0x20

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
		public <BossCountdownCoroutine>d__26(int <>1__state) { }

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
	private sealed class <InitializeBossTime>d__23 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BossAI <>4__this; //Field offset: 0x20
		private <>c__DisplayClass23_0 <>8__1; //Field offset: 0x28

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
		public <InitializeBossTime>d__23(int <>1__state) { }

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
	private sealed class <SaveDamageAndShowTimeout>d__28 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BossAI <>4__this; //Field offset: 0x20

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
		public <SaveDamageAndShowTimeout>d__28(int <>1__state) { }

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
	private sealed class <SubmitBossDamage>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BossAI <>4__this; //Field offset: 0x20
		public bool playerWon; //Field offset: 0x28
		public int turnCount; //Field offset: 0x2C
		private <>c__DisplayClass14_0 <>8__1; //Field offset: 0x30
		private <>c__DisplayClass14_1 <>8__2; //Field offset: 0x38
		private long <bossScheduleId>5__2; //Field offset: 0x40
		private int <totalDamage>5__3; //Field offset: 0x48
		private int <maxRetries>5__4; //Field offset: 0x4C

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
		public <SubmitBossDamage>d__14(int <>1__state) { }

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
	private sealed class <TrySaveCheckpointDamage>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
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
		public <TrySaveCheckpointDamage>d__12(int <>1__state) { }

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
	private static BossAI <Instance>k__BackingField; //Field offset: 0x0
	internal Board board; //Field offset: 0x20
	internal Active active; //Field offset: 0x28
	private int _lastSavedDamage; //Field offset: 0x30
	private bool _autoReturning; //Field offset: 0x34

	internal static BossAI Instance
	{
		[CompilerGenerated]
		internal get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public static int LastSavedDamage
	{
		 get { } //Length: 67
	}

	public BossAI() { }

	[CompilerGenerated]
	private void <OnBossTimeoutConfirm>b__21_0() { }

	[IteratorStateMachine(typeof(<AutoReturnFromBossTimeout>d__19))]
	private IEnumerator AutoReturnFromBossTimeout(float delay) { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<BossCountdownCoroutine>d__26))]
	private IEnumerator BossCountdownCoroutine() { }

	internal int CountBossSetupPotential(String[2] boards) { }

	private void FreezeBoardOnTimeout() { }

	[CompilerGenerated]
	internal static BossAI get_Instance() { }

	public static int get_LastSavedDamage() { }

	internal static DateTime GetEffectiveBossEndTime(Board b) { }

	internal static DateTime GetServerAdjustedNow(Board b) { }

	[IteratorStateMachine(typeof(<InitializeBossTime>d__23))]
	internal IEnumerator InitializeBossTime() { }

	public bool IsBossTurn() { }

	private void OnBossTimeoutConfirm() { }

	public void ResetCheckpoint() { }

	private void ReturnFromBossTimeout() { }

	[IteratorStateMachine(typeof(<SaveDamageAndShowTimeout>d__28))]
	private IEnumerator SaveDamageAndShowTimeout() { }

	[CompilerGenerated]
	private static void set_Instance(BossAI value) { }

	private void ShowBossTimeoutPopup() { }

	private void Start() { }

	private void StartBossCountdown() { }

	internal void StopBossCountdown() { }

	[IteratorStateMachine(typeof(<SubmitBossDamage>d__14))]
	public IEnumerator SubmitBossDamage(bool playerWon, int turnCount) { }

	[IteratorStateMachine(typeof(<TrySaveCheckpointDamage>d__12))]
	private IEnumerator TrySaveCheckpointDamage() { }

}

