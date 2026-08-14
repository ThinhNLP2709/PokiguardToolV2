//Type is in global namespace

public class Board : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Comparison<KeyValuePair`2<String, Int32>> <>9__285_0; //Field offset: 0x8
		public static Func<StoneRewardInfo, Int32> <>9__288_0; //Field offset: 0x10
		public static Func<StoneRewardInfo, String> <>9__288_1; //Field offset: 0x18
		public static Func<StoneRewardInfo, Int32> <>9__315_0; //Field offset: 0x20
		public static Func<StoneRewardInfo, String> <>9__315_1; //Field offset: 0x28
		public static Func<GameObject, Boolean> <>9__331_0; //Field offset: 0x30
		public static Func<Vector2Int, Int32> <>9__333_0; //Field offset: 0x38
		public static Func<Vector2Int, Int32> <>9__333_1; //Field offset: 0x40
		public static Func<Int32, Int32> <>9__333_2; //Field offset: 0x48
		public static Func<Vector2Int, Int32> <>9__333_3; //Field offset: 0x50
		public static Func<Vector2Int, Int32> <>9__333_4; //Field offset: 0x58
		public static Func<Int32, Int32> <>9__333_5; //Field offset: 0x60
		public static Func<CardData, Boolean> <>9__336_0; //Field offset: 0x68

		private static <>c() { }

		public <>c() { }

		internal bool <CalculatePotentialVangDotDestruction>b__331_0(GameObject g) { }

		internal int <ComputeBossSwordLineMetrics>b__333_0(Vector2Int p) { }

		internal int <ComputeBossSwordLineMetrics>b__333_1(Vector2Int p) { }

		internal int <ComputeBossSwordLineMetrics>b__333_2(int v) { }

		internal int <ComputeBossSwordLineMetrics>b__333_3(Vector2Int p) { }

		internal int <ComputeBossSwordLineMetrics>b__333_4(Vector2Int p) { }

		internal int <ComputeBossSwordLineMetrics>b__333_5(int v) { }

		internal int <DisplayCoopReward>b__288_0(StoneRewardInfo s) { }

		internal string <DisplayCoopReward>b__288_1(StoneRewardInfo s) { }

		internal int <displayDestroy>b__285_0(KeyValuePair<String, Int32> a, KeyValuePair<String, Int32> b) { }

		internal int <DisplayRewardFromServer>b__315_0(StoneRewardInfo s) { }

		internal string <DisplayRewardFromServer>b__315_1(StoneRewardInfo s) { }

		internal bool <LoadSelectedCards>b__336_0(CardData c) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass204_0
	{
		public Transform shell; //Field offset: 0x0
		public Transform pf; //Field offset: 0x8

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass225_0
	{
		public GameObject go; //Field offset: 0x10

		public <>c__DisplayClass225_0() { }

		internal void <ConsumeDestructionPanelEntryCo>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass287_0
	{
		public Animator animator; //Field offset: 0x10
		public float t; //Field offset: 0x18
		public float timeout; //Field offset: 0x1C

		public <>c__DisplayClass287_0() { }

		internal bool <ShowGameResultIntegrated>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass288_0
	{
		public GameObject petReward; //Field offset: 0x10

		public <>c__DisplayClass288_0() { }

		internal void <DisplayCoopReward>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass316_0
	{
		public int level; //Field offset: 0x10
		public Board <>4__this; //Field offset: 0x18

		public <>c__DisplayClass316_0() { }

		internal bool <CreateLocalReward>b__0(StoneRewardInfo s) { }

	}

	[CompilerGenerated]
	private sealed class <AnimateDotsWaterfall>d__266 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20
		private float <maxDur>5__2; //Field offset: 0x28
		private float <maxColDelay>5__3; //Field offset: 0x2C

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
		public <AnimateDotsWaterfall>d__266(int <>1__state) { }

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
	private sealed class <AutoHideMega1Animation>d__312 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20

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
		public <AutoHideMega1Animation>d__312(int <>1__state) { }

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
	private sealed class <BossDeadlineCountdownCoroutine>d__233 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20
		private bool <timeoutToastShown>5__2; //Field offset: 0x28
		private WaitForSecondsRealtime <wait>5__3; //Field offset: 0x30

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
		public <BossDeadlineCountdownCoroutine>d__233(int <>1__state) { }

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
	private sealed class <CheckForStableBoardAfterFill>d__280 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20
		private float <checkInterval>5__2; //Field offset: 0x28
		private float <maxWaitTime>5__3; //Field offset: 0x2C
		private float <elapsedTime>5__4; //Field offset: 0x30
		private float <unstableNoCascadeTime>5__5; //Field offset: 0x34

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
		public <CheckForStableBoardAfterFill>d__280(int <>1__state) { }

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
	private sealed class <ConsumeDestructionPanelEntryCo>d__225 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20
		public string gemTagName; //Field offset: 0x28
		private <>c__DisplayClass225_0 <>8__1; //Field offset: 0x30
		private float <shrink>5__2; //Field offset: 0x38

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
		public <ConsumeDestructionPanelEntryCo>d__225(int <>1__state) { }

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
	private sealed class <DecreaseRowCo>d__264 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20
		private int <safety>5__2; //Field offset: 0x28

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
		public <DecreaseRowCo>d__264(int <>1__state) { }

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
	private sealed class <DestroyRandomDotsCo>d__273 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20
		public int count; //Field offset: 0x28

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
		public <DestroyRandomDotsCo>d__273(int <>1__state) { }

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
	private sealed class <DisplayCoopReward>d__288 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20
		public int gold; //Field offset: 0x28
		public int exp; //Field offset: 0x2C

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
		public <DisplayCoopReward>d__288(int <>1__state) { }

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
	private sealed class <DisplayRewardFromServer>d__315 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20
		public PetRewardResponse displayData; //Field offset: 0x28

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
		public <DisplayRewardFromServer>d__315(int <>1__state) { }

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
	private sealed class <FadeOut>d__325 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public CanvasGroup canvasGroup; //Field offset: 0x20
		public float duration; //Field offset: 0x28
		private float <elapsedTime>5__2; //Field offset: 0x2C

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
		public <FadeOut>d__325(int <>1__state) { }

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
	private sealed class <HandleNetworkError>d__247 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20

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
		public <HandleNetworkError>d__247(int <>1__state) { }

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
	private sealed class <HandleUIWs>d__226 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20
		public WsCombatBatch batch; //Field offset: 0x28
		public bool bossSide; //Field offset: 0x30
		public bool wasFullPower; //Field offset: 0x31
		private Dictionary<String, Int32> <byTag>5__2; //Field offset: 0x38
		private bool <hasTags>5__3; //Field offset: 0x40
		private float <waitFree>5__4; //Field offset: 0x44
		private bool <showPanel>5__5; //Field offset: 0x48
		private String[] <>7__wrap5; //Field offset: 0x50
		private int <>7__wrap6; //Field offset: 0x58

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
		public <HandleUIWs>d__226(int <>1__state) { }

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
	private sealed class <HideAllItemsEnd>d__329 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20
		private GameObject <root>5__2; //Field offset: 0x28
		private GameObject[2] <>7__wrap2; //Field offset: 0x30
		private int <>7__wrap3; //Field offset: 0x38
		private int <>7__wrap4; //Field offset: 0x3C
		private int <>7__wrap5; //Field offset: 0x40
		private int <>7__wrap6; //Field offset: 0x44
		private GameObject <item>5__8; //Field offset: 0x48

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
		public <HideAllItemsEnd>d__329(int <>1__state) { }

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
	private sealed class <LeaveMatchMidGameCoroutine>d__347 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20

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
		public <LeaveMatchMidGameCoroutine>d__347(int <>1__state) { }

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
	private sealed class <ResetBoardWhenNoMoves>d__355 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20

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
		public <ResetBoardWhenNoMoves>d__355(int <>1__state) { }

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
	private sealed class <ResumeAndSyncState>d__286 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20
		private MatchService <msvc>5__2; //Field offset: 0x28
		private float <wsTimeout>5__3; //Field offset: 0x30

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
		public <ResumeAndSyncState>d__286(int <>1__state) { }

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
	private sealed class <ShowGameResultIntegrated>d__287 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20
		public bool serverAuthoritative; //Field offset: 0x28
		public bool playerWon; //Field offset: 0x29
		private long <earlyEnemyPetId>5__2; //Field offset: 0x30
		private Coroutine <submitCo>5__3; //Field offset: 0x38

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
		public <ShowGameResultIntegrated>d__287(int <>1__state) { }

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
	private sealed class <UpdateTurnUI>d__240 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int currentTurnActor; //Field offset: 0x20
		public Board <>4__this; //Field offset: 0x28

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
		public <UpdateTurnUI>d__240(int <>1__state) { }

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
	private sealed class <WaitAndDestroyMatches>d__267 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Board <>4__this; //Field offset: 0x20

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
		public <WaitAndDestroyMatches>d__267(int <>1__state) { }

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

	internal class ApiResponse
	{
		public bool success; //Field offset: 0x0
		public string message; //Field offset: 0x0
		public T data; //Field offset: 0x0

		public ApiResponse`1() { }

	}

	internal class PetRewardRequest
	{
		public int petId; //Field offset: 0x10
		public bool victory; //Field offset: 0x14

		public PetRewardRequest() { }

	}

	internal class PetRewardResponse
	{
		public int petId; //Field offset: 0x10
		public int levelDisplay; //Field offset: 0x14
		public int requestAttack; //Field offset: 0x18
		public int expGain; //Field offset: 0x1C
		public Nullable<Int32> goldBonus; //Field offset: 0x20
		public List<StoneRewardInfo> stoneRewards; //Field offset: 0x28
		public bool receivedPet; //Field offset: 0x30
		public int newLevel; //Field offset: 0x34
		public int currentExp; //Field offset: 0x38
		public int expToNextLevel; //Field offset: 0x3C

		public PetRewardResponse() { }

	}

	internal class StoneRewardInfo
	{
		public string element; //Field offset: 0x10
		public int level; //Field offset: 0x18
		public int quantity; //Field offset: 0x1C

		public StoneRewardInfo() { }

	}

	private static readonly Color GRAY_TINT; //Field offset: 0x0
	private const float MinValidDotSpriteSize = 0.001; //Field offset: 0x0
	private const float REWARD_REVEAL_STAGGER = 0.12; //Field offset: 0x0
	private const float REWARD_REVEAL_DURATION = 0.35; //Field offset: 0x0
	public const long FUSION_CARD_ID = -777; //Field offset: 0x0
	private const float CASCADE_WATCHDOG_SECONDS = 12; //Field offset: 0x0
	internal const float AUTO_MOVE_COOLDOWN = 1.5; //Field offset: 0x0
	private const float MinSecondsBetweenCanvasForceRebuild = 0.5; //Field offset: 0x0
	private const string DotsPlayfieldChildName = "DotsPlayfield"; //Field offset: 0x0
	[CompilerGenerated]
	private static Board <Instance>k__BackingField; //Field offset: 0x10
	private static Font _multiplierFont; //Field offset: 0x18
	private static readonly String[] DestroyDisplayOrder; //Field offset: 0x20
	private static readonly Int32[][] SwapDirections; //Field offset: 0x28
	public GameObject bossTimeoutPanel; //Field offset: 0x20
	public Text bossTimeoutText; //Field offset: 0x28
	public Button bossTimeoutButton; //Field offset: 0x30
	public Text txtBossCountdown; //Field offset: 0x38
	internal DateTime bossEndTime; //Field offset: 0x40
	internal DateTime bossEndTimeUtc; //Field offset: 0x48
	internal bool useUtcCountdown; //Field offset: 0x50
	internal long serverClockOffsetMs; //Field offset: 0x58
	internal bool isBossTimeValid; //Field offset: 0x60
	internal bool isBossTimeout; //Field offset: 0x61
	internal Coroutine bossCountdownCoroutine; //Field offset: 0x68
	public GameObject[] dots; //Field offset: 0x70
	public GameState currentState; //Field offset: 0x78
	public GameObject destructionEntryPrefab; //Field offset: 0x80
	public int width; //Field offset: 0x88
	public int height; //Field offset: 0x8C
	public int offSet; //Field offset: 0x90
	[Header("Dot grid / DotsArea")]
	[SerializeField]
	[Tooltip("Vị trí ô từ slot transforms (index = row*width+col).")]
	private bool useSlotPositions; //Field offset: 0x94
	[SerializeField]
	private Transform slotsRoot; //Field offset: 0x98
	[SerializeField]
	private bool autoSyncSlotsFromRoot; //Field offset: 0xA0
	[SerializeField]
	private List<Transform> slots; //Field offset: 0xA8
	[SerializeField]
	private float dotYOffset; //Field offset: 0xB0
	[SerializeField]
	[Tooltip("Khi không dùng slot: căn lưới quanh tâm Board/DotsArea.")]
	private bool centerBoardOnTransform; //Field offset: 0xB4
	[SerializeField]
	private Vector2 cellSpacing; //Field offset: 0xB8
	[SerializeField]
	[Tooltip("Bật: chia đều ô theo rect DotsArea. Tắt: dùng cellSpacing / căn tâm — dot vẫn spawn dưới DotsPlayfield nếu bật Use Dots Playfield.")]
	private bool useEvenSpacingFromDotsArea; //Field offset: 0xC0
	[FormerlySerializedAs("dotGridPadding")]
	[SerializeField]
	private float dotsAreaPadding; //Field offset: 0xC4
	[SerializeField]
	private float dotsAreaExtraFrameGap; //Field offset: 0xC8
	[SerializeField]
	private bool insetGridFromSlicedImageBorder; //Field offset: 0xCC
	[SerializeField]
	private bool autoScaleDotsToFitGridCells; //Field offset: 0xCD
	[Range(0, 0.45)]
	[SerializeField]
	private float dotVisualFillPadding; //Field offset: 0xD0
	[SerializeField]
	[Tooltip("Tạo child DotsPlayfield dưới DotsArea (Board → DotsArea → DotsPlayfield → dot). Không phụ thuộc Use Even Spacing — khi tắt Even Spacing, playfield full stretch trong DotsArea.")]
	private bool useDotsPlayfieldUnderDotsArea; //Field offset: 0xD4
	[SerializeField]
	private bool clipDotsInsidePlayfield; //Field offset: 0xD5
	[FormerlySerializedAs("dotsRoot")]
	[Header("Dots hierarchy")]
	[SerializeField]
	[Tooltip("Tùy chọn: kéo object cha chứa dot. Để trống hoặc kéo nhầm chính Board: tự tạo child \"DotsArea\" dưới Board để spawn + ẩn/hiện an toàn.")]
	public Transform dotsParent; //Field offset: 0xD8
	private Transform runtimeDotsParent; //Field offset: 0xE0
	private Transform runtimeDotsPlayfield; //Field offset: 0xE8
	[SerializeField]
	private Sprite dotsAreaBackgroundSprite; //Field offset: 0xF0
	[SerializeField]
	private float spawnLiftY; //Field offset: 0xF8
	private Vector2 _cachedDotPrefabSpriteSize; //Field offset: 0xFC
	private bool _cachedDotPrefabSpriteSizeValid; //Field offset: 0x104
	private Vector3 _dotPrefabRootScale; //Field offset: 0x108
	private Vector2 _lastDotsShellRectSize; //Field offset: 0x114
	private float _lastCanvasForceUnscaledTime; //Field offset: 0x11C
	internal int destroyedCount; //Field offset: 0x120
	internal bool isDestroyingMatches; //Field offset: 0x124
	public bool hasDestroyedThisTurn; //Field offset: 0x125
	public bool playerMovedThisTurn; //Field offset: 0x126
	public bool hasMega1BuffThisTurn; //Field offset: 0x127
	public bool hasMega2BuffThisTurn; //Field offset: 0x128
	internal bool isMega2PanelOpen; //Field offset: 0x129
	[HideInInspector]
	public CardUI activeMega2CardUI; //Field offset: 0x130
	internal BackGroundTitle[2] allTiles; //Field offset: 0x138
	public GameObject[2] allDots; //Field offset: 0x140
	internal FindMatches findMaches; //Field offset: 0x148
	internal Dictionary<String, Int32> destroyedCountByTag; //Field offset: 0x150
	public Active active; //Field offset: 0x158
	internal Coroutine stableBoardCheckCoroutine; //Field offset: 0x160
	internal Coroutine cascadeCoroutine; //Field offset: 0x168
	internal bool isCascadeRunning; //Field offset: 0x170
	private bool cascadeRerunPending; //Field offset: 0x171
	private int cascadeRerunCount; //Field offset: 0x174
	private float cascadeStartedRealtime; //Field offset: 0x178
	private int stableHealAttempts; //Field offset: 0x17C
	public GameObject destructionCountPanel; //Field offset: 0x180
	internal Dictionary<String, Sprite> itemIcons; //Field offset: 0x188
	public Sprite[] pieces; //Field offset: 0x190
	public GameObject loading; //Field offset: 0x198
	public Api api; //Field offset: 0x1A0
	public NotifyWin notifyWin; //Field offset: 0x1A8
	public GameObject load; //Field offset: 0x1B0
	public bool enableAutoMove; //Field offset: 0x1B8
	public GameObject imgTurnE; //Field offset: 0x1C0
	public GameObject imgTurnP; //Field offset: 0x1C8
	internal bool isProcessingUI; //Field offset: 0x1D0
	internal bool isAutoMoveInProgress; //Field offset: 0x1D1
	public GameObject panelResult; //Field offset: 0x1D8
	public GameObject resultBackground; //Field offset: 0x1E0
	public GameObject rewards; //Field offset: 0x1E8
	public GameObject anmtRW; //Field offset: 0x1F0
	public GameObject listReward; //Field offset: 0x1F8
	public GameObject itemRewardStone; //Field offset: 0x200
	public GameObject itemRewardPet; //Field offset: 0x208
	public GameObject itemRewardCT; //Field offset: 0x210
	public GameObject itemRewardGold; //Field offset: 0x218
	public GameObject itemRewardEXP; //Field offset: 0x220
	[Header("Special Drop Prefabs (Coop Reward)")]
	public GameObject itemE1RW; //Field offset: 0x228
	public GameObject itemE2RW; //Field offset: 0x230
	public GameObject itemE3RW; //Field offset: 0x238
	public GameObject itemEItem1RW; //Field offset: 0x240
	public GameObject itemEItem2RW; //Field offset: 0x248
	public GameObject itemEItem3RW; //Field offset: 0x250
	public GameObject itemEItem4RW; //Field offset: 0x258
	public GameObject itemCrystalRW; //Field offset: 0x260
	public GameObject itemStoneCardRW; //Field offset: 0x268
	public Text txtResultTitle; //Field offset: 0x270
	public Button btnGet; //Field offset: 0x278
	public Sprite[] fireStones; //Field offset: 0x280
	public Sprite[] waterStones; //Field offset: 0x288
	public Sprite[] earthStones; //Field offset: 0x290
	public Sprite[] windStones; //Field offset: 0x298
	public Sprite[] electricStones; //Field offset: 0x2A0
	internal bool isGameOver; //Field offset: 0x2A8
	internal readonly HashSet<Int32> _leftActorNumbers; //Field offset: 0x2B0
	internal string enemyPetElement; //Field offset: 0x2B8
	internal int enemyPetId; //Field offset: 0x2C0
	internal int currentCount; //Field offset: 0x2C4
	internal int requestPass; //Field offset: 0x2C8
	internal float lastAutoMoveTime; //Field offset: 0x2CC
	internal bool isBossBattle; //Field offset: 0x2D0
	public GameObject cardPrefab; //Field offset: 0x2D8
	public Transform cardContainer; //Field offset: 0x2E0
	public int maxCardsInHand; //Field offset: 0x2E8
	public float cardSpacing; //Field offset: 0x2EC
	public float cardYPosition; //Field offset: 0x2F0
	public float cardAnimDuration; //Field offset: 0x2F4
	internal List<CardData> selectedCards; //Field offset: 0x2F8
	internal List<GameObject> cardsInHand; //Field offset: 0x300
	public CardData cardData; //Field offset: 0x308
	internal int HOTTURN; //Field offset: 0x310
	internal int SUBHOTTURN; //Field offset: 0x314
	public GameObject energyWarningPanel; //Field offset: 0x318
	public Text energyWarningText; //Field offset: 0x320
	public Button energyWarningButton; //Field offset: 0x328
	internal bool hasShownEnergyWarning; //Field offset: 0x330
	internal int lastCheckedEnergy; //Field offset: 0x334
	internal AudioSettingsManager audioSettingsManager; //Field offset: 0x338
	public Image boardBackground; //Field offset: 0x340
	internal bool isBoardReady; //Field offset: 0x348
	internal bool isUsingLegendCard; //Field offset: 0x349
	internal float legendDamageMultiplier; //Field offset: 0x34C
	internal bool isUsingMega; //Field offset: 0x350
	internal int currentDamageMultiplier; //Field offset: 0x354
	public GameObject imgPDef; //Field offset: 0x358
	public GameObject imgEDef; //Field offset: 0x360
	internal bool isResuming; //Field offset: 0x368
	internal Coroutine resumeSyncCoroutine; //Field offset: 0x370
	private RectTransform _cachedPlayfieldMaskOwner; //Field offset: 0x378
	private RectMask2D _cachedPlayfieldMask; //Field offset: 0x380
	private RectTransform _cachedDotsAreaFrameImageOwner; //Field offset: 0x388
	private Image _cachedDotsAreaFrameImage; //Field offset: 0x390
	private int _gridLayoutCacheFrame; //Field offset: 0x398
	private bool _gridLayoutCacheOk; //Field offset: 0x39C
	private RectTransform _gridLayoutCacheArea; //Field offset: 0x3A0
	private float _gridLayoutCacheCellW; //Field offset: 0x3A8
	private float _gridLayoutCacheCellH; //Field offset: 0x3AC
	private Rect _gridLayoutCacheRect; //Field offset: 0x3B0
	[Header("Tốc độ xử lý viên (HandleUI)")]
	[SerializeField]
	[Tooltip("Thời gian chờ mỗi loại viên thường (sau animation damage).")]
	private float handleUI_waitPerNormalGem; //Field offset: 0x3C0
	[SerializeField]
	[Tooltip("Thời gian chờ viên vàng (s).")]
	private float handleUI_waitPerVangGem; //Field offset: 0x3C4
	[SerializeField]
	[Tooltip("Khoảng nghỉ ngắn sau cập nhật slider, trước bước tiếp.")]
	private float handleUI_pauseAfterSliderNormal; //Field offset: 0x3C8
	[SerializeField]
	private float handleUI_pauseAfterSliderVang; //Field offset: 0x3CC
	[Header("Pet animation duration cho viên kiếm (vang Dot)")]
	[SerializeField]
	[Tooltip("Độ dài animation Attack bình thường (key=1). Chờ đủ trước khi reset animator.")]
	private float vangAttackAnimDuration; //Field offset: 0x3D0
	[SerializeField]
	[Tooltip("Độ dài animation AttackPower khi đủ nộ (key=2).")]
	private float vangAttackPowerAnimDuration; //Field offset: 0x3D4
	[SerializeField]
	private float destructionEntryPulseSeconds; //Field offset: 0x3D8
	[SerializeField]
	private float destructionEntryShrinkSeconds; //Field offset: 0x3DC
	private Coroutine _bossDeadlineCo; //Field offset: 0x3E0
	private readonly List<KeyValuePair`2<String, Int32>> _destroySortBuffer; //Field offset: 0x3E8
	private readonly List<GameObject> _destroyEntryPool; //Field offset: 0x3F0
	private bool _rewardPanelBuilt; //Field offset: 0x3F8
	private bool _weaponRewardShown; //Field offset: 0x3F9
	private bool _petShardRewardShown; //Field offset: 0x3FA
	private bool _lateRewardHooked; //Field offset: 0x3FB
	[SerializeField]
	private float mega1AnimDuration; //Field offset: 0x3FC
	private Coroutine _mega1AnimCoroutine; //Field offset: 0x400
	internal bool isMega1PanelOpen; //Field offset: 0x408
	private HashSet<Int32> _shownExitNoticeActors; //Field offset: 0x410

	internal float HandleUIPauseNormal
	{
		internal get { } //Length: 19
	}

	internal float HandleUIPauseVang
	{
		internal get { } //Length: 19
	}

	internal float HandleUIWaitNormal
	{
		internal get { } //Length: 19
	}

	internal float HandleUIWaitVang
	{
		internal get { } //Length: 19
	}

	public private static Board Instance
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 110
	}

	public bool IsBoardReady
	{
		 get { } //Length: 8
	}

	public GameObject ResolvedDotsArea
	{
		 get { } //Length: 7
	}

	internal float VangAttackAnimDuration
	{
		internal get { } //Length: 9
	}

	internal float VangAttackPowerAnimDuration
	{
		internal get { } //Length: 9
	}

	private static Board() { }

	public Board() { }

	[CompilerGenerated]
	internal static void <ReparentStrayDotsIntoPlayfield>g__ReparentIfDot|204_0(Transform t, ref <>c__DisplayClass204_0 unnamed_param_1) { }

	[CompilerGenerated]
	private void <ShowGameResultIntegrated>b__287_0() { }

	[CompilerGenerated]
	private void <ShowGameResultIntegrated>b__287_1() { }

	public void AddFusionSkillCard(CardData cardData) { }

	private void AlignDotsAreaToBoard(Transform dotsAreaTransform) { }

	[IteratorStateMachine(typeof(<AnimateDotsWaterfall>d__266))]
	private IEnumerator AnimateDotsWaterfall() { }

	private void AnimateRewardReveal(GameObject item) { }

	private void ApplyAvatarTintIfDisplayed(int actorNumber, Color tint, bool isLeft) { }

	public void ApplyCoopBoardVisualFinishAfterNetworkSync() { }

	private void ApplyDotsAreaBackgroundSprite() { }

	private void ApplyDotScaleToFitGridCells() { }

	private static void ApplyPlayfieldRect(RectTransform pfRt, Vector2 offsetMin, Vector2 offsetMax) { }

	private static Rect ApplySpriteBorderInsetToLocalRect(Rect r, Sprite s) { }

	[IteratorStateMachine(typeof(<AutoHideMega1Animation>d__312))]
	private IEnumerator AutoHideMega1Animation() { }

	internal void Awake() { }

	[IteratorStateMachine(typeof(<BossDeadlineCountdownCoroutine>d__233))]
	private IEnumerator BossDeadlineCountdownCoroutine() { }

	internal int CalculateExpByLevel(int level) { }

	public int CalculateIndirectVangDestruction(int x1, int y1, int x2, int y2) { }

	public int CalculatePotentialVangDotDestruction(GameObject movedDot, int targetX, int targetY) { }

	public int CalculateTotalMultiplierGain(int x1, int y1, int x2, int y2) { }

	internal int CalculateTotalStones(int turnCount) { }

	public int CalculateTrapPotential(int x, int y, string tag) { }

	public float CalculateVangPriorityScore(GameObject dot, int targetX, int targetY, int chainLength, bool isComplexChain, string tag, bool isTrap, int trapPotential, int multiplierValue, int totalMultiplierGain, int vangDestroyed, int vangWithMultiplier) { }

	public int CalculateVangWithMultiplier(int x1, int y1, int x2, int y2) { }

	public bool CanCreateMatchAtPosition(String[2] board, int x, int y, string tag) { }

	internal bool CheckBoardStable() { }

	public int CheckChain(int col, int row, GameObject dot, out bool isComplexChain) { }

	[IteratorStateMachine(typeof(<CheckForStableBoardAfterFill>d__280))]
	public IEnumerator CheckForStableBoardAfterFill() { }

	internal bool CheckMatchAt(int col, int row, string tag) { }

	public bool CheckMatchAtSimulated(String[2] board, int col, int row, string tag) { }

	public bool CheckValidMove(int x1, int y1, int x2, int y2, out int chainLength, out bool isComplexChain) { }

	public void ClearAllMega2Hints() { }

	private void ClearCards() { }

	private void ClearRoomRestoreFlags() { }

	public void CollectMatchesAt(int col, int row, string tag, HashSet<GameObject> matchedDots) { }

	public ValueTuple<Int32, Int32, Int32> ComputeBossSwordLineMetrics(GameObject movedDot, int targetX, int targetY) { }

	private bool ComputeEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r) { }

	[IteratorStateMachine(typeof(<ConsumeDestructionPanelEntryCo>d__225))]
	internal IEnumerator ConsumeDestructionPanelEntryCo(string gemTagName) { }

	public int CountPlayerVangOpportunities(String[2] board) { }

	private void CreateCard(CardData cardData, int index, int totalCards) { }

	private void CreateCardHT(CardData cardData) { }

	internal PetRewardResponse CreateLocalReward(int turnCount) { }

	internal void CreateMultiplierText(GameObject dot, int multiplier) { }

	[IteratorStateMachine(typeof(<DecreaseRowCo>d__264))]
	internal IEnumerator DecreaseRowCo() { }

	public void DestroyConfiguredDots(int blue, int green, int red, int white, int yellow, int purple, int maxCount) { }

	public void DestroyMatches() { }

	internal void DestroyMatchesAt(int column, int row) { }

	private static int DestroyOrderIndexOf(string tag) { }

	internal void DestroyOrphanDotsUnderDotsParent(bool immediate) { }

	public void DestroyRandomDots(int count) { }

	[IteratorStateMachine(typeof(<DestroyRandomDotsCo>d__273))]
	internal IEnumerator DestroyRandomDotsCo(int count) { }

	private void DisplayCardsOnBoard() { }

	[IteratorStateMachine(typeof(<DisplayCoopReward>d__288))]
	internal IEnumerator DisplayCoopReward(int gold, int exp) { }

	internal void displayDestroy() { }

	[IteratorStateMachine(typeof(<DisplayRewardFromServer>d__315))]
	internal IEnumerator DisplayRewardFromServer(PetRewardResponse displayData) { }

	public void EnsureBoardVisible() { }

	private void EnsureBossCountdownText() { }

	private void EnsureDotPrefabSpriteCache() { }

	private void EnsureDotsAreaLayoutAndBackground() { }

	private Transform EnsureDotsPlayfield(RectTransform shell) { }

	private Transform EnsureDotsPlayfieldForShell(Transform shell) { }

	public void EnsureFusionCards() { }

	private void EnsureRuntimeDotsParent() { }

	private Transform EnsureWorldDotsPlayfield(Transform shell) { }

	[IteratorStateMachine(typeof(<FadeOut>d__325))]
	internal IEnumerator FadeOut(CanvasGroup canvasGroup, float duration) { }

	private void FastReturnToRoom() { }

	private static Image FindRewardIcon(GameObject item) { }

	private CardUI FindWiredSkillCardUI() { }

	internal float get_HandleUIPauseNormal() { }

	internal float get_HandleUIPauseVang() { }

	internal float get_HandleUIWaitNormal() { }

	internal float get_HandleUIWaitVang() { }

	[CompilerGenerated]
	public static Board get_Instance() { }

	public bool get_IsBoardReady() { }

	public GameObject get_ResolvedDotsArea() { }

	internal float get_VangAttackAnimDuration() { }

	internal float get_VangAttackPowerAnimDuration() { }

	public Vector2 GetCellBaseWorldPosition(int col, int row) { }

	public Vector2 GetColyseusSpawnWorldPositionAboveBoard(int column) { }

	public int GetDotMultiplier(GameObject dot) { }

	public Vector2 GetDotRefillDropStartWorldPosition(int col, int row) { }

	private Image GetDotsAreaFrameImage(RectTransform areaRt) { }

	private Rect GetDotsAreaGridContentRectLocal(RectTransform areaRt) { }

	private Transform GetDotsAreaShellTransform() { }

	private Transform GetDotsParent() { }

	public Transform GetDotsParentTransform() { }

	public Vector2 GetDotSpawnWorldPosition(int col, int row) { }

	private GameObject GetDotsVisibilityRoot() { }

	public Vector2 GetDotTargetWorldPosition(int col, int row) { }

	private Vector3 GetGridOriginWorld() { }

	private static Font GetMultiplierFont() { }

	private RectMask2D GetPlayfieldMask(RectTransform pfRt) { }

	private float GetRewardRevealTotalSeconds(int itemCount) { }

	public Vector2 GetSpawnWorldPositionAboveCell(int column, int row) { }

	internal Sprite GetStoneSprite(string element, int level) { }

	public Vector2 GetWorldPositionForGrid(int column, int row) { }

	private void GoToMainScene() { }

	public void GrayOutPlayerAvatar(int actorNumber) { }

	private void HandleLateRewardPush(string matchId) { }

	[IteratorStateMachine(typeof(<HandleNetworkError>d__247))]
	public IEnumerator HandleNetworkError(string errorMessage) { }

	internal void HandleTurnEnd() { }

	private void HandleTurnStart(int entityIndex) { }

	[IteratorStateMachine(typeof(<HandleUIWs>d__226))]
	internal IEnumerator HandleUIWs(WsCombatBatch batch, bool bossSide, bool wasFullPower) { }

	private bool HasExplicitDotsParent() { }

	internal bool HasFullDotGridSpawned() { }

	public bool HasLeftMatch(int actorNumber) { }

	public bool HasValidMoves() { }

	public void HideAllItems() { }

	[IteratorStateMachine(typeof(<HideAllItemsEnd>d__329))]
	public IEnumerator HideAllItemsEnd() { }

	public void HideMega1Animation() { }

	private void HookLateRewardPush() { }

	public void InitializeCards() { }

	public void InitializeCardsClientOnly() { }

	private void InvalidateGridLayoutCache() { }

	public bool IsPlayerAllowedToMove() { }

	public bool IsTrapMove(int x1, int y1, int x2, int y2) { }

	private void LateUpdate() { }

	public void LeaveMatchAfterGameOver() { }

	public void LeaveMatchMidGame() { }

	[IteratorStateMachine(typeof(<LeaveMatchMidGameCoroutine>d__347))]
	private IEnumerator LeaveMatchMidGameCoroutine() { }

	internal void LoadAudioSettings() { }

	private void LoadCardsFromPlayerPrefs() { }

	public void LoadGroupBackground() { }

	public void LoadSelectedCards(List<CardData> cards) { }

	private static int LongestConsecutiveSpanOnAxis(List<Int32> sortedAsc) { }

	public bool MatchesAt(int column, int row, GameObject piece) { }

	public bool MatchesOnBoard() { }

	private void MergeDotsAreaDuplicatesIntoSingle() { }

	internal void OnApplicationQuit() { }

	public void OnCardDataReady(CardData data) { }

	internal void OnDestroy() { }

	private void OnEnable() { }

	internal void OnMouseDown() { }

	public void OnTurnStartNotify(int actorNumber) { }

	private void OnValidate() { }

	public void PrepareDotsAreaForCoopSync() { }

	public void RefillBoard() { }

	private void RefillBoardNonDeterministic() { }

	public void RefreshDotsAreaBackgroundVisible() { }

	private void RemoveFusionCard() { }

	private void ReparentStrayDotsIntoPlayfield() { }

	private void ReparentStrayDotsPlayfieldUnderDotsArea(Transform dotsArea) { }

	[IteratorStateMachine(typeof(<ResetBoardWhenNoMoves>d__355))]
	public IEnumerator ResetBoardWhenNoMoves() { }

	internal void ResetDestroyedCounts() { }

	public void ResetMoveCounters() { }

	private int ResolveAuthoritativeEnemyPetId() { }

	private GameObject ResolveDotsAreaRoot() { }

	public void RestorePlayerAvatar(int actorNumber) { }

	[IteratorStateMachine(typeof(<ResumeAndSyncState>d__286))]
	internal IEnumerator ResumeAndSyncState() { }

	public void ReturnToMenu() { }

	public void ReturnToMenuSafely() { }

	internal void ReturnToQuangTruong() { }

	public void ReturnToQuangTruongFromBoss() { }

	internal int RollStoneLevel(int turnCount) { }

	[CompilerGenerated]
	private static void set_Instance(Board value) { }

	public void SetBoardState(GameState state) { }

	private void SetDotsAreaBackgroundVisible(bool visible) { }

	private void ShowBtnGetWithAnim() { }

	[IteratorStateMachine(typeof(<ShowGameResultIntegrated>d__287))]
	public IEnumerator ShowGameResultIntegrated(bool playerWon, bool serverAuthoritative = false) { }

	public void ShowItems() { }

	public void ShowMega1Animation(bool autoHide = true) { }

	public void ShowMega2Animation(bool autoHide = true) { }

	public void ShowMega2ToggleHint(int col, int row, bool isOn) { }

	public void ShowPlayerExitNotice(string playerName, int actorNumber = 0) { }

	public String[2] SimulateBoardAfterDestruction(HashSet<Vector2Int> matchedPositions) { }

	public bool SimulateHasVangDotInCombo(GameObject movedDot, int targetX, int targetY) { }

	public void SimulateMatchesAfterMove(int x, int y, string tag, HashSet<Vector2Int> matchedPositions) { }

	public int SimulateVirtualCombo(GameObject movedDot, int targetX, int targetY, int maxDepth = 3) { }

	private void SnapAllDotsToGrid() { }

	private void SpawnPetShardReward(MatchRewardData reward) { }

	private void SpawnRewardItem(GameObject prefab, string text) { }

	private void SpawnWeaponReward(WeaponDropDTO drop) { }

	private void SpawnWeaponShardReward(int amount) { }

	private void Start() { }

	private void StartCascade(IEnumerator routine) { }

	internal void StopCascadePipeline() { }

	private bool TryCacheDotSpriteSize(Vector3 size) { }

	private bool TryGetEvenGridCellLayout(out RectTransform areaRt, out float cellW, out float cellH, out Rect r) { }

	private void UnhookLateRewardPush() { }

	public void UpdateCountdownDisplay(TimeSpan remaining) { }

	private void UpdateDotsPlayfieldLayout() { }

	[IteratorStateMachine(typeof(<UpdateTurnUI>d__240))]
	public IEnumerator UpdateTurnUI(int currentTurnActor) { }

	[IteratorStateMachine(typeof(<WaitAndDestroyMatches>d__267))]
	public IEnumerator WaitAndDestroyMatches() { }

	internal bool WouldCreateMatch(int x1, int y1, int x2, int y2) { }

}

