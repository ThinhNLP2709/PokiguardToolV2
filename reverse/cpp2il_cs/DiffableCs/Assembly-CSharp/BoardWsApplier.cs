//Type is in global namespace

[DisallowMultipleComponent]
public class BoardWsApplier : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass55_0
	{
		public GameObject captured; //Field offset: 0x10

		public <>c__DisplayClass55_0() { }

		internal void <ApplyDestroySequenced>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass65_0
	{
		public SpriteRenderer host; //Field offset: 0x10
		public Color baseColor; //Field offset: 0x18
		public GameObject go; //Field offset: 0x28
		public Action<Single> <>9__2; //Field offset: 0x30
		public Action <>9__3; //Field offset: 0x38

		public <>c__DisplayClass65_0() { }

		internal void <PlayEnemyEvolveFlash>b__0(float t) { }

		internal void <PlayEnemyEvolveFlash>b__1() { }

		internal void <PlayEnemyEvolveFlash>b__2(float t) { }

		internal void <PlayEnemyEvolveFlash>b__3() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass66_0
	{
		public GameObject go; //Field offset: 0x10
		public Vector3 baseScale; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x28

		public <>c__DisplayClass66_0() { }

		internal void <PlayEnemyPowerUpPunch>b__0() { }

		internal void <PlayEnemyPowerUpPunch>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass69_0
	{
		public bool done; //Field offset: 0x10

		public <>c__DisplayClass69_0() { }

		internal void <RunWithTimeout>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <ApplyCardUse>d__76 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchOpDTO op; //Field offset: 0x20
		public BoardWsApplier <>4__this; //Field offset: 0x28

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
		public <ApplyCardUse>d__76(int <>1__state) { }

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
	private sealed class <ApplyDestroySequenced>d__55 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchOpDTO op; //Field offset: 0x20
		public BoardWsApplier <>4__this; //Field offset: 0x28
		public float speed; //Field offset: 0x30
		private List<GameObject> <targets>5__2; //Field offset: 0x38
		private WaitForSeconds <stagger>5__3; //Field offset: 0x40
		private int <i>5__4; //Field offset: 0x48

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
		public <ApplyDestroySequenced>d__55(int <>1__state) { }

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
	private sealed class <ApplyOp>d__51 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchOpDTO op; //Field offset: 0x20
		public BoardWsApplier <>4__this; //Field offset: 0x28
		public float speed; //Field offset: 0x30

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
		public <ApplyOp>d__51(int <>1__state) { }

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
	private sealed class <ApplyOpsInner>d__49 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public List<MatchOpDTO> ops; //Field offset: 0x20
		public BoardWsApplier <>4__this; //Field offset: 0x28
		private float <phaseStart>5__2; //Field offset: 0x30
		private int <destroyRound>5__3; //Field offset: 0x34
		private int <i>5__4; //Field offset: 0x38
		private MatchOpDTO <op>5__5; //Field offset: 0x40
		private float <speed>5__6; //Field offset: 0x48

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
		public <ApplyOpsInner>d__49(int <>1__state) { }

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
	private sealed class <ApplyOpsSequential>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WsCombatBatch combat; //Field offset: 0x20
		public List<MatchOpDTO> ops; //Field offset: 0x28
		public BoardWsApplier <>4__this; //Field offset: 0x30
		private bool <wasFullPower>5__2; //Field offset: 0x38
		private bool <bossBatch>5__3; //Field offset: 0x39

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
		public <ApplyOpsSequential>d__40(int <>1__state) { }

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
	private sealed class <ApplyVfx>d__64 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchOpDTO op; //Field offset: 0x20
		public BoardWsApplier <>4__this; //Field offset: 0x28
		public float speed; //Field offset: 0x30

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
		public <ApplyVfx>d__64(int <>1__state) { }

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
	private sealed class <BootstrapMatch>d__15 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplier <>4__this; //Field offset: 0x20
		public Dictionary<String, Object> payload; //Field offset: 0x28
		private float <wait>5__2; //Field offset: 0x30

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
		public <BootstrapMatch>d__15(int <>1__state) { }

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
	private sealed class <ClearMega2HintsAfter>d__46 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float sec; //Field offset: 0x20
		public BoardWsApplier <>4__this; //Field offset: 0x28

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
		public <ClearMega2HintsAfter>d__46(int <>1__state) { }

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
	private sealed class <DrainBatchQueue>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplier <>4__this; //Field offset: 0x20

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
		public <DrainBatchQueue>d__38(int <>1__state) { }

		private void <>m__Finally1() { }

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
	private sealed class <EnsureFusionCardsWhenReady>d__73 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplier <>4__this; //Field offset: 0x20
		private float <deadline>5__2; //Field offset: 0x28

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
		public <EnsureFusionCardsWhenReady>d__73(int <>1__state) { }

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
	private sealed class <LoadBoardFromSnapshot>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplier <>4__this; //Field offset: 0x20
		public Dictionary<String, Object> payload; //Field offset: 0x28

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
		public <LoadBoardFromSnapshot>d__20(int <>1__state) { }

		private void <>m__Finally1() { }

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
	private sealed class <LoadBoardFromSnapshotCore>d__21 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplier <>4__this; //Field offset: 0x20
		public Dictionary<String, Object> payload; //Field offset: 0x28
		private float <waitStart>5__2; //Field offset: 0x30

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
		public <LoadBoardFromSnapshotCore>d__21(int <>1__state) { }

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
	private sealed class <PlayFusionResultFx>d__68 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplier <>4__this; //Field offset: 0x20
		public bool isLocal; //Field offset: 0x28
		public int actorNum; //Field offset: 0x2C
		public bool success; //Field offset: 0x30
		public int ghostPetId; //Field offset: 0x34
		private bool <hidBoard>5__2; //Field offset: 0x38

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
		public <PlayFusionResultFx>d__68(int <>1__state) { }

		private void <>m__Finally1() { }

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
	private sealed class <ResyncMatch>d__17 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplier <>4__this; //Field offset: 0x20
		public Dictionary<String, Object> payload; //Field offset: 0x28

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
		public <ResyncMatch>d__17(int <>1__state) { }

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
	private sealed class <RunThenFlag>d__70 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public IEnumerator inner; //Field offset: 0x20
		public Action onDone; //Field offset: 0x28

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
		public <RunThenFlag>d__70(int <>1__state) { }

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
	private sealed class <RunWithTimeout>d__69 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplier <>4__this; //Field offset: 0x20
		public IEnumerator inner; //Field offset: 0x28
		public float timeoutSec; //Field offset: 0x30
		private <>c__DisplayClass69_0 <>8__1; //Field offset: 0x38
		private float <deadline>5__2; //Field offset: 0x40

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
		public <RunWithTimeout>d__69(int <>1__state) { }

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
	private sealed class <WaitForFallToSettle>d__34 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplier <>4__this; //Field offset: 0x20

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
		public <WaitForFallToSettle>d__34(int <>1__state) { }

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

	private static bool _tagFallbackWarned; //Field offset: 0x0
	private const float LocalShownTtlSec = 20; //Field offset: 0x0
	private const float CastVfxDedupeSec = 3; //Field offset: 0x0
	private static int _localShownCardId; //Field offset: 0x4
	private static float _localShownAt; //Field offset: 0x8
	private Board board; //Field offset: 0x20
	private bool _subscribed; //Field offset: 0x28
	private string _bootstrappedMatchId; //Field offset: 0x30
	private bool _boardBuildRunning; //Field offset: 0x38
	private Transform _cachedDotsParent; //Field offset: 0x40
	private Board _cachedDotsParentOwner; //Field offset: 0x48
	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"ops", "combat", "fx"})]
	private readonly Queue<ValueTuple`3<List`1<MatchOpDTO>, WsCombatBatch, IEnumerator>> _pendingBatches; //Field offset: 0x50
	private bool _renderRunning; //Field offset: 0x58
	private bool _boardHiddenForCard; //Field offset: 0x59
	private float _lastFallStartedAt; //Field offset: 0x5C
	private bool _suppressBarRefresh; //Field offset: 0x60
	private float _lastCastVfxAt; //Field offset: 0x64
	private readonly HashSet<String> _offlineToastShown; //Field offset: 0x68
	private bool _pendingCritAtSelf; //Field offset: 0x70
	private bool _pendingCritAtEnemy; //Field offset: 0x71

	private static BoardWsApplier() { }

	public BoardWsApplier() { }

	private void ApplyBossHp(MatchOpDTO op) { }

	[IteratorStateMachine(typeof(<ApplyCardUse>d__76))]
	private IEnumerator ApplyCardUse(MatchOpDTO op) { }

	[IteratorStateMachine(typeof(<ApplyDestroySequenced>d__55))]
	private IEnumerator ApplyDestroySequenced(MatchOpDTO op, float speed) { }

	private void ApplyFall(MatchOpDTO op) { }

	private void ApplyFallOrSpawn(MatchOpDTO op) { }

	private void ApplyHighlight(MatchOpDTO op) { }

	[IteratorStateMachine(typeof(<ApplyOp>d__51))]
	private IEnumerator ApplyOp(MatchOpDTO op, float speed, int destroyRound) { }

	[IteratorStateMachine(typeof(<ApplyOpsInner>d__49))]
	private IEnumerator ApplyOpsInner(List<MatchOpDTO> ops) { }

	[IteratorStateMachine(typeof(<ApplyOpsSequential>d__40))]
	private IEnumerator ApplyOpsSequential(List<MatchOpDTO> ops, WsCombatBatch combat) { }

	private void ApplyShieldExpire(MatchOpDTO op) { }

	private void ApplySpawn(MatchOpDTO op) { }

	private void ApplyStatChange(MatchOpDTO op) { }

	private void ApplyStatus(MatchOpDTO op) { }

	private void ApplySwap(MatchOpDTO op) { }

	[IteratorStateMachine(typeof(<ApplyVfx>d__64))]
	private IEnumerator ApplyVfx(MatchOpDTO op, float speed) { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<BootstrapMatch>d__15))]
	private IEnumerator BootstrapMatch(Dictionary<String, Object> payload) { }

	private void ClearAllDots() { }

	[IteratorStateMachine(typeof(<ClearMega2HintsAfter>d__46))]
	private IEnumerator ClearMega2HintsAfter(float sec) { }

	private void ClearPredictionFlag(GameObject go) { }

	private static bool ConsumeLocalSkillCardShown(int cardId) { }

	private static bool DetectFullPowerSpend(List<MatchOpDTO> ops, string actorUsername) { }

	[IteratorStateMachine(typeof(<DrainBatchQueue>d__38))]
	private IEnumerator DrainBatchQueue() { }

	private void EnqueueFxOnly(IEnumerator fx) { }

	private void EnsureBoardRef() { }

	[IteratorStateMachine(typeof(<EnsureFusionCardsWhenReady>d__73))]
	private IEnumerator EnsureFusionCardsWhenReady() { }

	private CardUI FindCardUIByCardId(int cardId) { }

	private GameObject FindDotPrefabByTag(string tag) { }

	private CardUI FindFusionCardUI() { }

	private void FlushPendingCritLabels() { }

	private Transform GetCachedDotsParent() { }

	private void HandleAfkWarn(string username, int idleCount, int threshold) { }

	private void HandleBossAction(ChatMessageDTO m) { }

	private void HandleEnergyDeltaWarn(ChatMessageDTO m) { }

	private void HandleFusionResolved(ChatMessageDTO m) { }

	private void HandleGameOver(string winner) { }

	private void HandleMatchReject(string reason) { }

	private void HandleMatchResync(ChatMessageDTO m) { }

	private void HandleMatchStart(ChatMessageDTO m) { }

	private void HandleOpsApplied(List<MatchOpDTO> ops) { }

	private void HandlePlayerLeft(string username, bool isPermanent, string reason) { }

	private void HandlePlayerRejoin(string username) { }

	private void HandleQteEvent(ChatMessageDTO m) { }

	private void HandleSkillCast(ChatMessageDTO m) { }

	private void HandleSkillHint(ChatMessageDTO m) { }

	private void HandleTurnEnd() { }

	private bool InBounds(int col, int row) { }

	private bool IsRendererBusy() { }

	private static bool IsSkillCardOp(MatchOpDTO op) { }

	[IteratorStateMachine(typeof(<LoadBoardFromSnapshot>d__20))]
	private IEnumerator LoadBoardFromSnapshot(Dictionary<String, Object> payload) { }

	[IteratorStateMachine(typeof(<LoadBoardFromSnapshotCore>d__21))]
	private IEnumerator LoadBoardFromSnapshotCore(Dictionary<String, Object> payload) { }

	private void MarkCrit(bool atSelf) { }

	internal static void NotifyLocalSkillCardShown(int cardId) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void PlayEnemyEvolveFlash() { }

	private void PlayEnemyPowerUpPunch() { }

	[IteratorStateMachine(typeof(<PlayFusionResultFx>d__68))]
	private IEnumerator PlayFusionResultFx(bool success, bool isLocal, string actor, string petName, int ghostPetId, int actorNum) { }

	private static bool ReadBool(Dictionary<String, Object> d, string key, bool fb = false) { }

	private static double ReadDouble(Dictionary<String, Object> d, string key, double fb = 0) { }

	private static int ReadInt(Dictionary<String, Object> d, string key, int fb = 0) { }

	private static bool ReadPayloadBool(Dictionary<String, Object> p, string key) { }

	private static int ReadPayloadInt(Dictionary<String, Object> p, string key, int fb = 0) { }

	private void RegisterBusyProbe() { }

	private void ResetDotToActualPosition(int col, int row) { }

	private void ResetStatusFxForMatch() { }

	private int ResolveActorByUsername(string username) { }

	private int ResolveActorNumberFromUsername(string username) { }

	[IteratorStateMachine(typeof(<ResyncMatch>d__17))]
	private IEnumerator ResyncMatch(Dictionary<String, Object> payload) { }

	[IteratorStateMachine(typeof(<RunThenFlag>d__70))]
	private static IEnumerator RunThenFlag(IEnumerator inner, Action onDone) { }

	[IteratorStateMachine(typeof(<RunWithTimeout>d__69))]
	private IEnumerator RunWithTimeout(IEnumerator inner, float timeoutSec) { }

	private void SpawnDotByTag(int col, int row, string tag, int multiplier, bool fallFromAbove = false) { }

	private void Start() { }

	private void TrySubscribe() { }

	private void UnlockFusionCard() { }

	private void Unsubscribe() { }

	private void UpdateDotPos(GameObject go, int col, int row) { }

	private int VerifyBoardAgainstServer(BoardCellDTO[][] serverBoard) { }

	[IteratorStateMachine(typeof(<WaitForFallToSettle>d__34))]
	private IEnumerator WaitForFallToSettle() { }

	private static void WarnTagManagerOnce(string tag) { }

}

