//Type is in global namespace

public class MatchService : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <AckStuckGuard>d__246 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchService <>4__this; //Field offset: 0x20
		public long srvSeq; //Field offset: 0x28

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
		public <AckStuckGuard>d__246(int <>1__state) { }

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
	private sealed class <FetchFeatureFlags>d__275 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private UnityWebRequest <req>5__2; //Field offset: 0x20

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
		public <FetchFeatureFlags>d__275(int <>1__state) { }

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
	private sealed class <FlushGameOverWhenPresentationDone>d__374 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchService <>4__this; //Field offset: 0x20
		private float <waited>5__2; //Field offset: 0x28

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
		public <FlushGameOverWhenPresentationDone>d__374(int <>1__state) { }

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
	private sealed class <ResyncAfterReconnect>d__286 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchService <>4__this; //Field offset: 0x20

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
		public <ResyncAfterReconnect>d__286(int <>1__state) { }

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

	internal struct QteWindow
	{
		public int durationMs; //Field offset: 0x0
		public int perfectStartMs; //Field offset: 0x4
		public int perfectEndMs; //Field offset: 0x8
		public int goodStart1Ms; //Field offset: 0xC
		public int goodEnd1Ms; //Field offset: 0x10
		public int goodStart2Ms; //Field offset: 0x14
		public int goodEnd2Ms; //Field offset: 0x18

		public bool Valid
		{
			 get { } //Length: 18
		}

		public bool get_Valid() { }

	}

	internal class ServerPlayerStats
	{
		public int HP; //Field offset: 0x10
		public int MaxHP; //Field offset: 0x14
		public int Mana; //Field offset: 0x18
		public int MaxMana; //Field offset: 0x1C
		public int Power; //Field offset: 0x20
		public int MaxPower; //Field offset: 0x24
		public int Shield; //Field offset: 0x28

		public ServerPlayerStats() { }

	}

	[CompilerGenerated]
	private static MatchService <Instance>k__BackingField; //Field offset: 0x0
	private const float GameOverRenderWaitMaxSec = 30; //Field offset: 0x0
	private const float AckStuckGuardMarginSec = 1.5; //Field offset: 0x0
	private const float AckStuckGuardFallbackSec = 9; //Field offset: 0x0
	[CompilerGenerated]
	private static int <PrepHpBonusPct>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private static int <PrepManaBonus>k__BackingField; //Field offset: 0xC
	[CompilerGenerated]
	private static int <PrepPowerMax>k__BackingField; //Field offset: 0x10
	private static readonly JsonSerializer _payloadSerializer; //Field offset: 0x18
	[CompilerGenerated]
	private static string <LastEndedMatchId>k__BackingField; //Field offset: 0x20
	private static readonly JsonSerializer SnapshotSerializer; //Field offset: 0x28
	[CompilerGenerated]
	private string <CurrentMatchId>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private string <CurrentMatchType>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private int <BoardWidth>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private int <BoardHeight>k__BackingField; //Field offset: 0x34
	[CompilerGenerated]
	private string <CurrentTurnPlayer>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	private int <TurnNumber>k__BackingField; //Field offset: 0x40
	[CompilerGenerated]
	private int <TurnDurationSec>k__BackingField; //Field offset: 0x44
	[CompilerGenerated]
	private int <BossHp>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private int <BossHpMax>k__BackingField; //Field offset: 0x4C
	[CompilerGenerated]
	private int <ServerBossPetId>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	private bool <FusionEnabled>k__BackingField; //Field offset: 0x54
	[CompilerGenerated]
	private int <FusionManaCost>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private int <FusionStatPercent>k__BackingField; //Field offset: 0x5C
	[CompilerGenerated]
	private bool <LocalFusionUsed>k__BackingField; //Field offset: 0x60
	[CompilerGenerated]
	private int <LocalFusionLastAttemptTurn>k__BackingField; //Field offset: 0x64
	[CompilerGenerated]
	private long <LocalFusionSelectedUserPetId>k__BackingField; //Field offset: 0x68
	[CompilerGenerated]
	private long <LocalFusionSelectedPetId>k__BackingField; //Field offset: 0x70
	[CompilerGenerated]
	private CardData <LocalFusionSkillCard>k__BackingField; //Field offset: 0x78
	[CompilerGenerated]
	private string <LocalFusionDropReason>k__BackingField; //Field offset: 0x80
	[CompilerGenerated]
	private int <ServerBossDisplayPetId>k__BackingField; //Field offset: 0x88
	[CompilerGenerated]
	private int <ServerBossFinalPetId>k__BackingField; //Field offset: 0x8C
	[CompilerGenerated]
	private bool <ServerBossEvolved>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private int <BossMana>k__BackingField; //Field offset: 0x94
	[CompilerGenerated]
	private int <BossManaMax>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private int <BossPower>k__BackingField; //Field offset: 0x9C
	[CompilerGenerated]
	private int <BossPowerMax>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private int <BossShield>k__BackingField; //Field offset: 0xA4
	[CompilerGenerated]
	private Dictionary<String, MatchPlayerSnapshotDTO> <Players>k__BackingField; //Field offset: 0xA8
	private long _localSeqNum; //Field offset: 0xB0
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchStart; //Field offset: 0xB8
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnMatchResync; //Field offset: 0xC0
	[CompilerGenerated]
	private Action<List`1<MatchOpDTO>> OnOpsApplied; //Field offset: 0xC8
	[CompilerGenerated]
	private Action<String> OnMatchReject; //Field offset: 0xD0
	[CompilerGenerated]
	private Action OnTurnEnd; //Field offset: 0xD8
	[CompilerGenerated]
	private Action<String> OnGameOver; //Field offset: 0xE0
	[CompilerGenerated]
	private Action<String, Boolean, String> OnPlayerLeft; //Field offset: 0xE8
	[CompilerGenerated]
	private Action<String> OnPlayerRejoin; //Field offset: 0xF0
	[CompilerGenerated]
	private Action<String, Int32, Int32> OnAfkWarn; //Field offset: 0xF8
	[CompilerGenerated]
	private Action<String, Int32, Int32> OnTimerTick; //Field offset: 0x100
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFusionList; //Field offset: 0x108
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnFusionResolved; //Field offset: 0x110
	[CompilerGenerated]
	private int <TurnTimeRemainingSec>k__BackingField; //Field offset: 0x118
	[CompilerGenerated]
	private bool <HasBossDeadline>k__BackingField; //Field offset: 0x11C
	private int _bossDeadlineAnchorSec; //Field offset: 0x120
	private float _bossDeadlineAnchorAt; //Field offset: 0x124
	[CompilerGenerated]
	private bool <HasServerClock>k__BackingField; //Field offset: 0x128
	[CompilerGenerated]
	private bool <ClockPaused>k__BackingField; //Field offset: 0x129
	[CompilerGenerated]
	private string <ClockPauseReason>k__BackingField; //Field offset: 0x130
	private float _clockRemainAtAnchorSec; //Field offset: 0x138
	private float _clockAnchorUnscaled; //Field offset: 0x13C
	private bool _startGateSeen; //Field offset: 0x140
	[CompilerGenerated]
	private Action OnStartGateClosed; //Field offset: 0x148
	[CompilerGenerated]
	private Action<Int32, Int32> OnReadyStateChanged; //Field offset: 0x150
	private float _localFxHoldUntilUnscaled; //Field offset: 0x158
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnSkillCast; //Field offset: 0x160
	[CompilerGenerated]
	private Action<ChatMessageDTO> OnBossAction; //Field offset: 0x168
	[CompilerGenerated]
	private WsCombatBatch <PendingCombat>k__BackingField; //Field offset: 0x170
	private int _inFlightBatches; //Field offset: 0x178
	private readonly HashSet<Int64> _ackedSeqs; //Field offset: 0x180
	[CompilerGenerated]
	private int <ServerAckDeadlineSec>k__BackingField; //Field offset: 0x188
	private Func<Boolean> _rendererBusyProbe; //Field offset: 0x190
	[CompilerGenerated]
	private int <ServerBossHp>k__BackingField; //Field offset: 0x198
	[CompilerGenerated]
	private Dictionary<String, ServerPlayerStats> <ServerStats>k__BackingField; //Field offset: 0x1A0
	[CompilerGenerated]
	private Action OnServerStateChanged; //Field offset: 0x1A8
	private bool _wsCfgSubscribed; //Field offset: 0x1B0
	private bool _subscribed; //Field offset: 0x1B1
	private bool _matchOver; //Field offset: 0x1B2
	private Coroutine _resyncCoroutine; //Field offset: 0x1B8
	[CompilerGenerated]
	private int <LastMoveFromCol>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private int <LastMoveFromRow>k__BackingField; //Field offset: 0x1C4
	[CompilerGenerated]
	private int <LastMoveToCol>k__BackingField; //Field offset: 0x1C8
	[CompilerGenerated]
	private int <LastMoveToRow>k__BackingField; //Field offset: 0x1CC
	[CompilerGenerated]
	private long <LastMoveSeqNum>k__BackingField; //Field offset: 0x1D0
	private int _shadowDamageSnapshot; //Field offset: 0x1D8
	private long _shadowLastReportedSeq; //Field offset: 0x1E0
	[CompilerGenerated]
	private List<String> <ServerQteArrows>k__BackingField; //Field offset: 0x1E8
	[CompilerGenerated]
	private int <ServerQteDurationMs>k__BackingField; //Field offset: 0x1F0
	[CompilerGenerated]
	private QteWindow <ServerQteWindow>k__BackingField; //Field offset: 0x1F4
	[CompilerGenerated]
	private Action OnQteChallengeReady; //Field offset: 0x210
	[CompilerGenerated]
	private Nullable<Int32> <LastRejectCardId>k__BackingField; //Field offset: 0x218
	private string _deferredWinner; //Field offset: 0x220
	private bool _hasDeferredGameOver; //Field offset: 0x228
	private Coroutine _gameOverFlushCo; //Field offset: 0x230

	public event Action<String, Int32, Int32> OnAfkWarn
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnBossAction
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnFusionList
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnFusionResolved
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnGameOver
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnMatchReject
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchResync
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<ChatMessageDTO> OnMatchStart
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<List`1<MatchOpDTO>> OnOpsApplied
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String, Boolean, String> OnPlayerLeft
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action<String> OnPlayerRejoin
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action OnQteChallengeReady
	{
		[CompilerGenerated]
		 add { } //Length: 162
		[CompilerGenerated]
		 remove { } //Length: 162
	}

	public event Action<Int32, Int32> OnReadyStateChanged
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action OnServerStateChanged
	{
		[CompilerGenerated]
		 add { } //Length: 162
		[CompilerGenerated]
		 remove { } //Length: 162
	}

	public event Action<ChatMessageDTO> OnSkillCast
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action OnStartGateClosed
	{
		[CompilerGenerated]
		 add { } //Length: 162
		[CompilerGenerated]
		 remove { } //Length: 162
	}

	public event Action<String, Int32, Int32> OnTimerTick
	{
		[CompilerGenerated]
		 add { } //Length: 186
		[CompilerGenerated]
		 remove { } //Length: 186
	}

	public event Action OnTurnEnd
	{
		[CompilerGenerated]
		 add { } //Length: 162
		[CompilerGenerated]
		 remove { } //Length: 162
	}

	private float AckStuckGuardSec
	{
		private get { } //Length: 50
	}

	public private int BoardHeight
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private int BoardWidth
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public int BossDeadlineRemainingSec
	{
		 get { } //Length: 151
	}

	public private int BossHp
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private int BossHpMax
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private int BossMana
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private int BossManaMax
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private int BossPower
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private int BossPowerMax
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private int BossShield
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private bool ClockPaused
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private string ClockPauseReason
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public private string CurrentMatchId
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private string CurrentMatchType
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private string CurrentTurnPlayer
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private bool FusionEnabled
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private int FusionManaCost
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private int FusionStatPercent
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private bool HasBossDeadline
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private bool HasServerClock
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private static MatchService Instance
	{
		[CompilerGenerated]
		 get { } //Length: 78
		[CompilerGenerated]
		private set { } //Length: 105
	}

	private bool IsLocalFxHold
	{
		private get { } //Length: 36
	}

	public bool IsPresentationBusy
	{
		 get { } //Length: 56
	}

	public bool IsRenderingCombat
	{
		 get { } //Length: 11
	}

	public bool IsStartGatePaused
	{
		 get { } //Length: 90
	}

	public private static string LastEndedMatchId
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 110
	}

	public private int LastMoveFromCol
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private int LastMoveFromRow
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private long LastMoveSeqNum
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private int LastMoveToCol
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private int LastMoveToRow
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private Nullable<Int32> LastRejectCardId
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private string LocalFusionDropReason
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public private int LocalFusionLastAttemptTurn
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public bool LocalFusionLockedThisTurn
	{
		 get { } //Length: 19
	}

	public private long LocalFusionSelectedPetId
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 5
	}

	public private long LocalFusionSelectedUserPetId
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 5
	}

	public private CardData LocalFusionSkillCard
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public private bool LocalFusionUsed
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private WsCombatBatch PendingCombat
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public private Dictionary<String, MatchPlayerSnapshotDTO> Players
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public private static int PrepHpBonusPct
	{
		[CompilerGenerated]
		 get { } //Length: 78
		[CompilerGenerated]
		private set { } //Length: 83
	}

	public private static int PrepManaBonus
	{
		[CompilerGenerated]
		 get { } //Length: 78
		[CompilerGenerated]
		private set { } //Length: 83
	}

	public private static int PrepPowerMax
	{
		[CompilerGenerated]
		 get { } //Length: 78
		[CompilerGenerated]
		private set { } //Length: 83
	}

	public private int ServerAckDeadlineSec
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private int ServerBossDisplayPetId
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private bool ServerBossEvolved
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private int ServerBossFinalPetId
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private int ServerBossHp
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private int ServerBossPetId
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private List<String> ServerQteArrows
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public private int ServerQteDurationMs
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public private QteWindow ServerQteWindow
	{
		[CompilerGenerated]
		 get { } //Length: 36
		[CompilerGenerated]
		private set { } //Length: 33
	}

	public private Dictionary<String, ServerPlayerStats> ServerStats
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public float ServerTurnRemainingSec
	{
		 get { } //Length: 141
	}

	public private int TurnDurationSec
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private int TurnNumber
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private int TurnTimeRemainingSec
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		private set { } //Length: 7
	}

	public static bool UsePvpWs
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public static bool UseWsGameplay
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	private static MatchService() { }

	public MatchService() { }

	[IteratorStateMachine(typeof(<AckStuckGuard>d__246))]
	private IEnumerator AckStuckGuard(long srvSeq) { }

	[CompilerGenerated]
	public void add_OnAfkWarn(Action<String, Int32, Int32> value) { }

	[CompilerGenerated]
	public void add_OnBossAction(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnFusionList(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnFusionResolved(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnGameOver(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnMatchReject(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnMatchResync(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnMatchStart(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnOpsApplied(Action<List`1<MatchOpDTO>> value) { }

	[CompilerGenerated]
	public void add_OnPlayerLeft(Action<String, Boolean, String> value) { }

	[CompilerGenerated]
	public void add_OnPlayerRejoin(Action<String> value) { }

	[CompilerGenerated]
	public void add_OnQteChallengeReady(Action value) { }

	[CompilerGenerated]
	public void add_OnReadyStateChanged(Action<Int32, Int32> value) { }

	[CompilerGenerated]
	public void add_OnServerStateChanged(Action value) { }

	[CompilerGenerated]
	public void add_OnSkillCast(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void add_OnStartGateClosed(Action value) { }

	[CompilerGenerated]
	public void add_OnTimerTick(Action<String, Int32, Int32> value) { }

	[CompilerGenerated]
	public void add_OnTurnEnd(Action value) { }

	private void ApplyMatchInitFromMessage(ChatMessageDTO m) { }

	public static void ApplyPrepStatFrame(Nullable<Int32> hpBonusPct, Nullable<Int32> manaBonus, Nullable<Int32> powerMax) { }

	public static void ApplyPrepStatFrame(MatchPrepDataDTO prep) { }

	public static void ApplyPvpWsFlag(bool serverFlag) { }

	public void ApplyServerBossHp(int newHp) { }

	public static void ApplyServerFlag(bool serverFlag) { }

	public void ApplyServerStat(string username, string stat, int newValue) { }

	private void ApplyStateDelta(Dictionary<String, Object> payload) { }

	private void ApplyTimingFields(Dictionary<String, Object> p) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void AutoInit() { }

	private void Awake() { }

	private void BeginAnimAck(long srvSeq, bool hasWork) { }

	public void BeginLocalFxHold(float sec) { }

	public void ClearCurrentMatch() { }

	private void ClearLocalFxHold() { }

	public WsCombatBatch ConsumePendingCombat() { }

	[IteratorStateMachine(typeof(<FetchFeatureFlags>d__275))]
	private IEnumerator FetchFeatureFlags() { }

	private void FlushDeferredGameOver(bool force = false) { }

	[IteratorStateMachine(typeof(<FlushGameOverWhenPresentationDone>d__374))]
	private IEnumerator FlushGameOverWhenPresentationDone() { }

	private void FlushShadowReportForLastMove() { }

	private float get_AckStuckGuardSec() { }

	[CompilerGenerated]
	public int get_BoardHeight() { }

	[CompilerGenerated]
	public int get_BoardWidth() { }

	public int get_BossDeadlineRemainingSec() { }

	[CompilerGenerated]
	public int get_BossHp() { }

	[CompilerGenerated]
	public int get_BossHpMax() { }

	[CompilerGenerated]
	public int get_BossMana() { }

	[CompilerGenerated]
	public int get_BossManaMax() { }

	[CompilerGenerated]
	public int get_BossPower() { }

	[CompilerGenerated]
	public int get_BossPowerMax() { }

	[CompilerGenerated]
	public int get_BossShield() { }

	[CompilerGenerated]
	public bool get_ClockPaused() { }

	[CompilerGenerated]
	public string get_ClockPauseReason() { }

	[CompilerGenerated]
	public string get_CurrentMatchId() { }

	[CompilerGenerated]
	public string get_CurrentMatchType() { }

	[CompilerGenerated]
	public string get_CurrentTurnPlayer() { }

	[CompilerGenerated]
	public bool get_FusionEnabled() { }

	[CompilerGenerated]
	public int get_FusionManaCost() { }

	[CompilerGenerated]
	public int get_FusionStatPercent() { }

	[CompilerGenerated]
	public bool get_HasBossDeadline() { }

	[CompilerGenerated]
	public bool get_HasServerClock() { }

	[CompilerGenerated]
	public static MatchService get_Instance() { }

	private bool get_IsLocalFxHold() { }

	public bool get_IsPresentationBusy() { }

	public bool get_IsRenderingCombat() { }

	public bool get_IsStartGatePaused() { }

	[CompilerGenerated]
	public static string get_LastEndedMatchId() { }

	[CompilerGenerated]
	public int get_LastMoveFromCol() { }

	[CompilerGenerated]
	public int get_LastMoveFromRow() { }

	[CompilerGenerated]
	public long get_LastMoveSeqNum() { }

	[CompilerGenerated]
	public int get_LastMoveToCol() { }

	[CompilerGenerated]
	public int get_LastMoveToRow() { }

	[CompilerGenerated]
	public Nullable<Int32> get_LastRejectCardId() { }

	[CompilerGenerated]
	public string get_LocalFusionDropReason() { }

	[CompilerGenerated]
	public int get_LocalFusionLastAttemptTurn() { }

	public bool get_LocalFusionLockedThisTurn() { }

	[CompilerGenerated]
	public long get_LocalFusionSelectedPetId() { }

	[CompilerGenerated]
	public long get_LocalFusionSelectedUserPetId() { }

	[CompilerGenerated]
	public CardData get_LocalFusionSkillCard() { }

	[CompilerGenerated]
	public bool get_LocalFusionUsed() { }

	[CompilerGenerated]
	public WsCombatBatch get_PendingCombat() { }

	[CompilerGenerated]
	public Dictionary<String, MatchPlayerSnapshotDTO> get_Players() { }

	[CompilerGenerated]
	public static int get_PrepHpBonusPct() { }

	[CompilerGenerated]
	public static int get_PrepManaBonus() { }

	[CompilerGenerated]
	public static int get_PrepPowerMax() { }

	[CompilerGenerated]
	public int get_ServerAckDeadlineSec() { }

	[CompilerGenerated]
	public int get_ServerBossDisplayPetId() { }

	[CompilerGenerated]
	public bool get_ServerBossEvolved() { }

	[CompilerGenerated]
	public int get_ServerBossFinalPetId() { }

	[CompilerGenerated]
	public int get_ServerBossHp() { }

	[CompilerGenerated]
	public int get_ServerBossPetId() { }

	[CompilerGenerated]
	public List<String> get_ServerQteArrows() { }

	[CompilerGenerated]
	public int get_ServerQteDurationMs() { }

	[CompilerGenerated]
	public QteWindow get_ServerQteWindow() { }

	[CompilerGenerated]
	public Dictionary<String, ServerPlayerStats> get_ServerStats() { }

	public float get_ServerTurnRemainingSec() { }

	[CompilerGenerated]
	public int get_TurnDurationSec() { }

	[CompilerGenerated]
	public int get_TurnNumber() { }

	[CompilerGenerated]
	public int get_TurnTimeRemainingSec() { }

	public static bool get_UsePvpWs() { }

	public static bool get_UseWsGameplay() { }

	private void HandleBossAction(ChatMessageDTO m) { }

	private void HandleConnectionChanged(bool connected) { }

	private void HandleFusionListRes(ChatMessageDTO m) { }

	private void HandleFusionRes(ChatMessageDTO m) { }

	private void HandleMatchAfkWarn(ChatMessageDTO m) { }

	private void HandleMatchCardUseRes(ChatMessageDTO m) { }

	private void HandleMatchGameOver(ChatMessageDTO m) { }

	private void HandleMatchMoveRes(ChatMessageDTO m) { }

	private void HandleMatchPlayerLeft(ChatMessageDTO m) { }

	private void HandleMatchPlayerRejoin(ChatMessageDTO m) { }

	private void HandleMatchReadyState(ChatMessageDTO m) { }

	private void HandleMatchReject(ChatMessageDTO m) { }

	private void HandleMatchResync(ChatMessageDTO m) { }

	private void HandleMatchSkillUseRes(ChatMessageDTO m) { }

	private void HandleMatchStart(ChatMessageDTO m) { }

	private void HandleMatchTimerTick(ChatMessageDTO m) { }

	private void HandleMatchTurnEnd(ChatMessageDTO m) { }

	private void HandleQteChallenge(ChatMessageDTO m) { }

	private void HandleResEnvelope(ChatMessageDTO m, string kind) { }

	private void HandleSkillCast(ChatMessageDTO m) { }

	private void HandleWsConfig(ChatMessageDTO m) { }

	public bool IsLocalTurn() { }

	public void NotifyBossEvolved() { }

	public void NotifyBossEvolved(int petId) { }

	public void NotifyRenderComplete(long srvSeq) { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnEnable() { }

	private WsCombatBatch ParseCombatBatch(ChatMessageDTO m) { }

	private static CardData ParseFusionSkillCard(Dictionary<String, Object> p, string key) { }

	private static CardData ParseFusionSkillCardFromMap(Dictionary<String, Object> p, string username) { }

	private List<MatchOpDTO> ParseOps(Dictionary<String, Object> payload) { }

	private void ParsePlayersSnapshot(Dictionary<String, Object> payload) { }

	public static int PrepMaxHp(int baseHp) { }

	public static int PrepMaxMana(int baseMana) { }

	private static bool ReadBool(Dictionary<String, Object> p, string key, bool fb = false) { }

	private static int ReadInt(Dictionary<String, Object> p, string key, int fb = 0) { }

	private static long ReadLong(Dictionary<String, Object> p, string key, long fb = 0) { }

	private static Nullable<Int32> ReadOptionalInt(Dictionary<String, Object> p, string key) { }

	private static string ReadString(Dictionary<String, Object> p, string key, string fb = null) { }

	public void RegisterRendererBusyProbe(Func<Boolean> probe) { }

	[CompilerGenerated]
	public void remove_OnAfkWarn(Action<String, Int32, Int32> value) { }

	[CompilerGenerated]
	public void remove_OnBossAction(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnFusionList(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnFusionResolved(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnGameOver(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnMatchReject(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnMatchResync(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnMatchStart(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnOpsApplied(Action<List`1<MatchOpDTO>> value) { }

	[CompilerGenerated]
	public void remove_OnPlayerLeft(Action<String, Boolean, String> value) { }

	[CompilerGenerated]
	public void remove_OnPlayerRejoin(Action<String> value) { }

	[CompilerGenerated]
	public void remove_OnQteChallengeReady(Action value) { }

	[CompilerGenerated]
	public void remove_OnReadyStateChanged(Action<Int32, Int32> value) { }

	[CompilerGenerated]
	public void remove_OnServerStateChanged(Action value) { }

	[CompilerGenerated]
	public void remove_OnSkillCast(Action<ChatMessageDTO> value) { }

	[CompilerGenerated]
	public void remove_OnStartGateClosed(Action value) { }

	[CompilerGenerated]
	public void remove_OnTimerTick(Action<String, Int32, Int32> value) { }

	[CompilerGenerated]
	public void remove_OnTurnEnd(Action value) { }

	public void RequestQteChallenge(int skillCardId) { }

	public void RequestResync() { }

	public static void ResetPrepStatFrame() { }

	public int ResolveBossDisplayPetId(int fallbackPetId = 0) { }

	[IteratorStateMachine(typeof(<ResyncAfterReconnect>d__286))]
	private IEnumerator ResyncAfterReconnect() { }

	private void SendAnimAck(long srvSeq) { }

	public void SendCardUse(int cardId, Nullable<Int32> cardTarget = null) { }

	public void SendClientReady() { }

	public void SendDragPause() { }

	public void SendDragResume() { }

	public void SendFusionList() { }

	public void SendFusionUse(long fusionUserPetId) { }

	public void SendMove(int fromCol, int fromRow, int toCol, int toRow) { }

	public void SendSkillUse(int skillCardId, int correctDotCount = 0, string timingResult = "BAD", int dotsToDestroy = 0, List<Int32> selectedRows = null, List<List`1<Int32>> selectedDots = null, List<String> qtePresses = null, Nullable<Int32> qteElapsedMs = null) { }

	[CompilerGenerated]
	private void set_BoardHeight(int value) { }

	[CompilerGenerated]
	private void set_BoardWidth(int value) { }

	[CompilerGenerated]
	private void set_BossHp(int value) { }

	[CompilerGenerated]
	private void set_BossHpMax(int value) { }

	[CompilerGenerated]
	private void set_BossMana(int value) { }

	[CompilerGenerated]
	private void set_BossManaMax(int value) { }

	[CompilerGenerated]
	private void set_BossPower(int value) { }

	[CompilerGenerated]
	private void set_BossPowerMax(int value) { }

	[CompilerGenerated]
	private void set_BossShield(int value) { }

	[CompilerGenerated]
	private void set_ClockPaused(bool value) { }

	[CompilerGenerated]
	private void set_ClockPauseReason(string value) { }

	[CompilerGenerated]
	private void set_CurrentMatchId(string value) { }

	[CompilerGenerated]
	private void set_CurrentMatchType(string value) { }

	[CompilerGenerated]
	private void set_CurrentTurnPlayer(string value) { }

	[CompilerGenerated]
	private void set_FusionEnabled(bool value) { }

	[CompilerGenerated]
	private void set_FusionManaCost(int value) { }

	[CompilerGenerated]
	private void set_FusionStatPercent(int value) { }

	[CompilerGenerated]
	private void set_HasBossDeadline(bool value) { }

	[CompilerGenerated]
	private void set_HasServerClock(bool value) { }

	[CompilerGenerated]
	private static void set_Instance(MatchService value) { }

	[CompilerGenerated]
	private static void set_LastEndedMatchId(string value) { }

	[CompilerGenerated]
	private void set_LastMoveFromCol(int value) { }

	[CompilerGenerated]
	private void set_LastMoveFromRow(int value) { }

	[CompilerGenerated]
	private void set_LastMoveSeqNum(long value) { }

	[CompilerGenerated]
	private void set_LastMoveToCol(int value) { }

	[CompilerGenerated]
	private void set_LastMoveToRow(int value) { }

	[CompilerGenerated]
	private void set_LastRejectCardId(Nullable<Int32> value) { }

	[CompilerGenerated]
	private void set_LocalFusionDropReason(string value) { }

	[CompilerGenerated]
	private void set_LocalFusionLastAttemptTurn(int value) { }

	[CompilerGenerated]
	private void set_LocalFusionSelectedPetId(long value) { }

	[CompilerGenerated]
	private void set_LocalFusionSelectedUserPetId(long value) { }

	[CompilerGenerated]
	private void set_LocalFusionSkillCard(CardData value) { }

	[CompilerGenerated]
	private void set_LocalFusionUsed(bool value) { }

	[CompilerGenerated]
	private void set_PendingCombat(WsCombatBatch value) { }

	[CompilerGenerated]
	private void set_Players(Dictionary<String, MatchPlayerSnapshotDTO> value) { }

	[CompilerGenerated]
	private static void set_PrepHpBonusPct(int value) { }

	[CompilerGenerated]
	private static void set_PrepManaBonus(int value) { }

	[CompilerGenerated]
	private static void set_PrepPowerMax(int value) { }

	[CompilerGenerated]
	private void set_ServerAckDeadlineSec(int value) { }

	[CompilerGenerated]
	private void set_ServerBossDisplayPetId(int value) { }

	[CompilerGenerated]
	private void set_ServerBossEvolved(bool value) { }

	[CompilerGenerated]
	private void set_ServerBossFinalPetId(int value) { }

	[CompilerGenerated]
	private void set_ServerBossHp(int value) { }

	[CompilerGenerated]
	private void set_ServerBossPetId(int value) { }

	[CompilerGenerated]
	private void set_ServerQteArrows(List<String> value) { }

	[CompilerGenerated]
	private void set_ServerQteDurationMs(int value) { }

	[CompilerGenerated]
	private void set_ServerQteWindow(QteWindow value) { }

	[CompilerGenerated]
	private void set_ServerStats(Dictionary<String, ServerPlayerStats> value) { }

	[CompilerGenerated]
	private void set_TurnDurationSec(int value) { }

	[CompilerGenerated]
	private void set_TurnNumber(int value) { }

	[CompilerGenerated]
	private void set_TurnTimeRemainingSec(int value) { }

	public static void set_UsePvpWs(bool value) { }

	public static void set_UseWsGameplay(bool value) { }

	private void Start() { }

	public bool TryGetFusionGhost(int actorNumber, out int fusionPetId) { }

	private void TrySubscribeChat() { }

	private void TrySubscribeWsConfig() { }

	public void UnregisterRendererBusyProbe(Func<Boolean> probe) { }

	private void UnsubscribeChat() { }

}

