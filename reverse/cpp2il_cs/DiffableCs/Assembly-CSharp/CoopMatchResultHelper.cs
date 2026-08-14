//Type is in global namespace

public class CoopMatchResultHelper : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public bool success; //Field offset: 0x10
		public CoopMatchResultHelper <>4__this; //Field offset: 0x18

		public <>c__DisplayClass21_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_1
	{
		public bool callbackReceived; //Field offset: 0x10
		public <>c__DisplayClass21_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass21_1() { }

		internal void <SubmitMatchResult>b__0(string response) { }

		internal void <SubmitMatchResult>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <PostRawJson>d__23 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string url; //Field offset: 0x20
		public string jsonBody; //Field offset: 0x28
		public Action<String> onSuccess; //Field offset: 0x30
		public Action<String> onError; //Field offset: 0x38
		private UnityWebRequest <request>5__2; //Field offset: 0x40

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
		public <PostRawJson>d__23(int <>1__state) { }

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
	private sealed class <SubmitMatchResult>d__21 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public CoopMatchResultHelper <>4__this; //Field offset: 0x20
		public long petId; //Field offset: 0x28
		public string mode; //Field offset: 0x30
		public bool playerWon; //Field offset: 0x38
		public int turnCount; //Field offset: 0x3C
		public long enemyUserId; //Field offset: 0x40
		private <>c__DisplayClass21_0 <>8__1; //Field offset: 0x48
		private <>c__DisplayClass21_1 <>8__2; //Field offset: 0x50
		private string <currentMatchId>5__2; //Field offset: 0x58
		private string <requestBody>5__3; //Field offset: 0x60
		private string <url>5__4; //Field offset: 0x68
		private int <retryCount>5__5; //Field offset: 0x70
		private float <waited>5__6; //Field offset: 0x74
		private float <reqWaited>5__7; //Field offset: 0x78

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
		public <SubmitMatchResult>d__21(int <>1__state) { }

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

	private class MatchResponse
	{
		public bool success; //Field offset: 0x10
		public string message; //Field offset: 0x18
		public MatchRewardData data; //Field offset: 0x20

		public MatchResponse() { }

	}

	internal class MatchRewardData
	{
		public string mode; //Field offset: 0x10
		public int gold; //Field offset: 0x18
		public int exp; //Field offset: 0x1C
		public int requestAttack; //Field offset: 0x20
		public bool hackDetected; //Field offset: 0x24
		public int goldBonus; //Field offset: 0x28
		public bool receivedPet; //Field offset: 0x2C
		public long receivedPetId; //Field offset: 0x30
		public bool duplicatePet; //Field offset: 0x38
		public int compensationGold; //Field offset: 0x3C
		public int compensationCrystal; //Field offset: 0x40
		public int petProgressCount; //Field offset: 0x44
		public int petProgressTarget; //Field offset: 0x48
		public int newLevel; //Field offset: 0x4C
		public int currentExp; //Field offset: 0x50
		public int expToNextLevel; //Field offset: 0x54
		public int e1Drop; //Field offset: 0x58
		public int e2Drop; //Field offset: 0x5C
		public int e3Drop; //Field offset: 0x60
		public int eItem1Drop; //Field offset: 0x64
		public int eItem2Drop; //Field offset: 0x68
		public int eItem3Drop; //Field offset: 0x6C
		public int eItem4Drop; //Field offset: 0x70
		public int crystalDrop; //Field offset: 0x74
		public int stoneCardDrop; //Field offset: 0x78
		public List<StoneRewardInfo> stoneRewards; //Field offset: 0x80
		public long itemAvtDrop; //Field offset: 0x88
		public int itemAvtDropAmount; //Field offset: 0x90
		public WeaponDropDTO weaponDrop; //Field offset: 0x98
		public int weaponShardDrop; //Field offset: 0xA0
		public int petShardDrop; //Field offset: 0xA4
		public long petShardPetId; //Field offset: 0xA8
		public string petShardPetName; //Field offset: 0xB0
		public int petShardTotal; //Field offset: 0xB8
		public int rankBefore; //Field offset: 0xBC
		public int rankChange; //Field offset: 0xC0
		public int newRank; //Field offset: 0xC4
		public int enemyRankChange; //Field offset: 0xC8
		public int enemyNewRank; //Field offset: 0xCC
		public int winStreak; //Field offset: 0xD0
		public int rankPosition; //Field offset: 0xD4
		public int winRate; //Field offset: 0xD8
		public int pvpWins; //Field offset: 0xDC
		public int pvpLosses; //Field offset: 0xE0

		public MatchRewardData() { }

	}

	public static CoopMatchResultHelper Instance; //Field offset: 0x0
	private const int MAX_RETRIES = 3; //Field offset: 0x0
	private const float RETRY_DELAY = 2; //Field offset: 0x0
	public bool lastSubmitSuccess; //Field offset: 0x20
	public MatchRewardData lastReward; //Field offset: 0x28
	private string _lastRewardMatchId; //Field offset: 0x30
	[CompilerGenerated]
	private Action<String> OnRewardPushed; //Field offset: 0x38
	private string _matchIdForPendingRestSubmit; //Field offset: 0x40
	private bool _wsSubscribed; //Field offset: 0x48

	public event Action<String> OnRewardPushed
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public int lastRewardExp
	{
		 get { } //Length: 18
	}

	public int lastRewardGold
	{
		 get { } //Length: 18
	}

	public CoopMatchResultHelper() { }

	[CompilerGenerated]
	public void add_OnRewardPushed(Action<String> value) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::BeforeSceneLoad (1))]
	private static void AutoInitialize() { }

	private void Awake() { }

	private string Esc(string s) { }

	public int get_lastRewardExp() { }

	public int get_lastRewardGold() { }

	private void HandleWsMatchResultPush(ChatMessageDTO msg) { }

	private void OnDestroy() { }

	private void ParseResponse(string response) { }

	[IteratorStateMachine(typeof(<PostRawJson>d__23))]
	private IEnumerator PostRawJson(string url, string jsonBody, Action<String> onSuccess, Action<String> onError) { }

	[CompilerGenerated]
	public void remove_OnRewardPushed(Action<String> value) { }

	private static string ResolveCurrentSubmitMatchId() { }

	[IteratorStateMachine(typeof(<SubmitMatchResult>d__21))]
	public IEnumerator SubmitMatchResult(bool playerWon, int turnCount, string mode = "coop", long enemyUserId = 0, long petId = 0) { }

	private void TrySubscribeWs() { }

}

