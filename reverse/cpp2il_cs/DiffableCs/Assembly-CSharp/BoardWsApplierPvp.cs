//Type is in global namespace

[DisallowMultipleComponent]
public class BoardWsApplierPvp : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass48_0
	{
		public GameObject captured; //Field offset: 0x10

		public <>c__DisplayClass48_0() { }

		internal void <ApplyDestroySequenced>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass56_0
	{
		public bool done; //Field offset: 0x10

		public <>c__DisplayClass56_0() { }

		internal void <RunWithTimeout>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <ApplyCardUse>d__69 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchOpDTO op; //Field offset: 0x20
		public BoardWsApplierPvp <>4__this; //Field offset: 0x28

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
		public <ApplyCardUse>d__69(int <>1__state) { }

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
	private sealed class <ApplyDestroySequenced>d__48 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchOpDTO op; //Field offset: 0x20
		public BoardWsApplierPvp <>4__this; //Field offset: 0x28
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
		public <ApplyDestroySequenced>d__48(int <>1__state) { }

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
	private sealed class <ApplyOp>d__43 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchOpDTO op; //Field offset: 0x20
		public BoardWsApplierPvp <>4__this; //Field offset: 0x28
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
		public <ApplyOp>d__43(int <>1__state) { }

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
	private sealed class <ApplyOpsSequential>d__41 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public List<MatchOpDTO> ops; //Field offset: 0x20
		public BoardWsApplierPvp <>4__this; //Field offset: 0x28
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
		public <ApplyOpsSequential>d__41(int <>1__state) { }

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
	private sealed class <ApplyOpsThenRender>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplierPvp <>4__this; //Field offset: 0x20
		public WsCombatBatch combat; //Field offset: 0x28
		public List<MatchOpDTO> ops; //Field offset: 0x30

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
		public <ApplyOpsThenRender>d__38(int <>1__state) { }

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
	private sealed class <BootstrapMatch>d__19 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplierPvp <>4__this; //Field offset: 0x20
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
		public <BootstrapMatch>d__19(int <>1__state) { }

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
	private sealed class <ClearMega2HintsAfter>d__68 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float sec; //Field offset: 0x20
		public BoardWsApplierPvp <>4__this; //Field offset: 0x28

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
		public <ClearMega2HintsAfter>d__68(int <>1__state) { }

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
	private sealed class <DrainBatchQueue>d__36 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplierPvp <>4__this; //Field offset: 0x20

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
		public <DrainBatchQueue>d__36(int <>1__state) { }

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
	private sealed class <EnsureFusionCardsWhenReady>d__59 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplierPvp <>4__this; //Field offset: 0x20
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
		public <EnsureFusionCardsWhenReady>d__59(int <>1__state) { }

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
	private sealed class <LoadBoardFromSnapshot>d__23 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplierPvp <>4__this; //Field offset: 0x20
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
		public <LoadBoardFromSnapshot>d__23(int <>1__state) { }

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
	private sealed class <PlayFusionResultFx>d__55 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplierPvp <>4__this; //Field offset: 0x20
		public bool isLocal; //Field offset: 0x28
		public int actor; //Field offset: 0x2C
		public bool success; //Field offset: 0x30
		public bool actorIsSelfSide; //Field offset: 0x31
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
		public <PlayFusionResultFx>d__55(int <>1__state) { }

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
	private sealed class <ResyncMatch>d__22 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplierPvp <>4__this; //Field offset: 0x20
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
		public <ResyncMatch>d__22(int <>1__state) { }

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
	private sealed class <RunThenFlag>d__57 : IEnumerator<Object>, IEnumerator, IDisposable
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
		public <RunThenFlag>d__57(int <>1__state) { }

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
	private sealed class <RunWithTimeout>d__56 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplierPvp <>4__this; //Field offset: 0x20
		public IEnumerator inner; //Field offset: 0x28
		public float timeoutSec; //Field offset: 0x30
		private <>c__DisplayClass56_0 <>8__1; //Field offset: 0x38
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
		public <RunWithTimeout>d__56(int <>1__state) { }

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
	private sealed class <WaitForFallToSettle>d__32 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardWsApplierPvp <>4__this; //Field offset: 0x20

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
		public <WaitForFallToSettle>d__32(int <>1__state) { }

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

	private static bool _tagFallbackWarnedPvp; //Field offset: 0x0
	private const float LocalShownTtlSec = 20; //Field offset: 0x0
	private static int _localShownCardId; //Field offset: 0x4
	private static float _localShownAt; //Field offset: 0x8
	private BoardPVP board; //Field offset: 0x20
	private ActivePVP active; //Field offset: 0x28
	private bool _subscribed; //Field offset: 0x30
	private string _bootstrappedMatchId; //Field offset: 0x38
	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"ops", "combat", "fx"})]
	private readonly Queue<ValueTuple`3<List`1<MatchOpDTO>, WsCombatBatch, IEnumerator>> _pendingBatches; //Field offset: 0x40
	private bool _renderRunning; //Field offset: 0x48
	private bool _boardHiddenForCard; //Field offset: 0x49
	private float _lastFallStartedAt; //Field offset: 0x4C
	private bool _suppressBarRefresh; //Field offset: 0x50
	private bool _pendingCritAtSelf; //Field offset: 0x51
	private bool _pendingCritAtEnemy; //Field offset: 0x52
	private readonly HashSet<String> _offlineToastShown; //Field offset: 0x58

	private bool WsPvpActive
	{
		private get { } //Length: 371
	}

	private static BoardWsApplierPvp() { }

	public BoardWsApplierPvp() { }

	[IteratorStateMachine(typeof(<ApplyCardUse>d__69))]
	private IEnumerator ApplyCardUse(MatchOpDTO op) { }

	[IteratorStateMachine(typeof(<ApplyDestroySequenced>d__48))]
	private IEnumerator ApplyDestroySequenced(MatchOpDTO op, float speed) { }

	private void ApplyFall(MatchOpDTO op) { }

	private void ApplyFallOrSpawn(MatchOpDTO op) { }

	private void ApplyHighlight(MatchOpDTO op) { }

	[IteratorStateMachine(typeof(<ApplyOp>d__43))]
	private IEnumerator ApplyOp(MatchOpDTO op, float speed, int destroyRound) { }

	[IteratorStateMachine(typeof(<ApplyOpsSequential>d__41))]
	private IEnumerator ApplyOpsSequential(List<MatchOpDTO> ops) { }

	[IteratorStateMachine(typeof(<ApplyOpsThenRender>d__38))]
	private IEnumerator ApplyOpsThenRender(List<MatchOpDTO> ops, WsCombatBatch combat) { }

	private void ApplyShieldExpire(MatchOpDTO op) { }

	private void ApplySpawn(MatchOpDTO op) { }

	private void ApplyStatChange(MatchOpDTO op) { }

	private void ApplyStatus(MatchOpDTO op) { }

	private void ApplySwap(MatchOpDTO op) { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<BootstrapMatch>d__19))]
	private IEnumerator BootstrapMatch(Dictionary<String, Object> payload) { }

	private void ClearAllDots() { }

	[IteratorStateMachine(typeof(<ClearMega2HintsAfter>d__68))]
	private IEnumerator ClearMega2HintsAfter(float sec) { }

	private void ClearPredictionFlag(GameObject go) { }

	private static bool ConsumeLocalSkillCardShown(int cardId) { }

	private static bool DetectFullPowerSpend(List<MatchOpDTO> ops, string actorUsername) { }

	[IteratorStateMachine(typeof(<DrainBatchQueue>d__36))]
	private IEnumerator DrainBatchQueue() { }

	private void EnqueueFxOnly(IEnumerator fx) { }

	[IteratorStateMachine(typeof(<EnsureFusionCardsWhenReady>d__59))]
	private IEnumerator EnsureFusionCardsWhenReady() { }

	private void EnsureRefs() { }

	private CardUIPVP FindCardUIByCardId(int cardId) { }

	private GameObject FindDotPrefabByTag(string tag) { }

	private CardUIPVP FindFusionCardUI() { }

	private void FlushPendingCritLabels() { }

	private bool get_WsPvpActive() { }

	private void HandleAfkWarn(string username, int idleCount, int threshold) { }

	private void HandleEnergyDeltaWarn(ChatMessageDTO m) { }

	private void HandleFusionResolved(ChatMessageDTO m) { }

	private void HandleGameOver(string winner) { }

	private void HandleMatchReject(string reason) { }

	private void HandleMatchResync(ChatMessageDTO m) { }

	private void HandleMatchStart(ChatMessageDTO m) { }

	private void HandleOpsApplied(List<MatchOpDTO> ops) { }

	private void HandlePlayerLeft(string username, bool isPermanent, string reason) { }

	private void HandlePlayerRejoin(string username) { }

	private void HandleSkillCast(ChatMessageDTO m) { }

	private void HandleTurnEnd() { }

	private bool InBounds(int col, int row) { }

	private bool IsRendererBusy() { }

	private static bool IsSkillCardOp(MatchOpDTO op) { }

	[IteratorStateMachine(typeof(<LoadBoardFromSnapshot>d__23))]
	private IEnumerator LoadBoardFromSnapshot(Dictionary<String, Object> payload) { }

	private void MarkCrit(bool atSelf) { }

	internal static void NotifyLocalSkillCardShown(int cardId) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	[IteratorStateMachine(typeof(<PlayFusionResultFx>d__55))]
	private IEnumerator PlayFusionResultFx(bool success, bool isLocal, bool actorIsSelfSide, string petName, int ghostPetId, int actor) { }

	private static bool ReadBoolPvp(Dictionary<String, Object> d, string key) { }

	private static double ReadDouble(Dictionary<String, Object> d, string key, double fb = 0) { }

	private static int ReadInt(Dictionary<String, Object> d, string key, int fb = 0) { }

	private static bool ReadPayloadBoolPvp(Dictionary<String, Object> p, string key) { }

	private static int ReadPayloadIntPvp(Dictionary<String, Object> p, string key, int fb = 0) { }

	private void RegisterBusyProbe() { }

	private void ResetDotToActualPosition(int col, int row) { }

	public static void ResetStaticState() { }

	private void ResetStatusFxForMatch() { }

	private static int ResolveActorNumber(string username) { }

	[IteratorStateMachine(typeof(<ResyncMatch>d__22))]
	private IEnumerator ResyncMatch(Dictionary<String, Object> payload) { }

	[IteratorStateMachine(typeof(<RunThenFlag>d__57))]
	private static IEnumerator RunThenFlag(IEnumerator inner, Action onDone) { }

	[IteratorStateMachine(typeof(<RunWithTimeout>d__56))]
	private IEnumerator RunWithTimeout(IEnumerator inner, float timeoutSec) { }

	public void SendMoveToWs(int fromCol, int fromRow, int toCol, int toRow) { }

	private static void ShowToast(string message) { }

	private void SpawnDotByTag(int col, int row, string tag, int multiplier, bool fallFromAbove = false) { }

	private void Start() { }

	private void TrySubscribe() { }

	private void Unsubscribe() { }

	private void UpdateDotPos(GameObject go, int col, int row) { }

	private int VerifyBoardAgainstServer(BoardCellDTO[][] serverBoard) { }

	[IteratorStateMachine(typeof(<WaitForFallToSettle>d__32))]
	private IEnumerator WaitForFallToSettle() { }

}

