//Type is in global namespace

public class ManagerTop : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__58_0; //Field offset: 0x8
		public static Action <>9__60_0; //Field offset: 0x10
		public static Action<String> <>9__68_1; //Field offset: 0x18
		public static Action<String> <>9__83_1; //Field offset: 0x20
		public static Action<String> <>9__89_1; //Field offset: 0x28

		private static <>c() { }

		public <>c() { }

		internal void <FetchUserDetail>b__68_1(string error) { }

		internal void <LoadRankingRewardTable>b__58_0(string error) { }

		internal void <LoadTop30Ranking>b__83_1(string error) { }

		internal void <LoadUserDetailById>b__89_1(string error) { }

		internal void <OnCloseRankingClicked>b__60_0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass46_0
	{
		public UserDetailData userDetail; //Field offset: 0x10
		public bool success; //Field offset: 0x18
		public ManagerTop <>4__this; //Field offset: 0x20
		public string username; //Field offset: 0x28

		public <>c__DisplayClass46_0() { }

		internal void <SearchUserByName>b__0(UserDetailData data) { }

		internal void <SearchUserByName>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass57_0
	{
		public List<TopRankingData> rankings; //Field offset: 0x10
		public bool dataLoaded; //Field offset: 0x18

		public <>c__DisplayClass57_0() { }

		internal void <LoadDataThenOpenPanel>b__0(List<TopRankingData> data) { }

		internal void <LoadDataThenOpenPanel>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass66_0
	{
		public Transform userT; //Field offset: 0x10
		public ManagerTop <>4__this; //Field offset: 0x18
		public TopRankingData ranking; //Field offset: 0x20
		public Action <>9__1; //Field offset: 0x28

		public <>c__DisplayClass66_0() { }

		internal void <SetupRankingItem>b__0() { }

		internal void <SetupRankingItem>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass73_0
	{
		public Text textComponent; //Field offset: 0x10

		public <>c__DisplayClass73_0() { }

		internal void <AnimateNumberText>b__0(float val) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass83_0
	{
		public List<TopRankingData> top30Rankings; //Field offset: 0x10
		public bool success; //Field offset: 0x18

		public <>c__DisplayClass83_0() { }

		internal void <LoadTop30Ranking>b__0(List<TopRankingData> data) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass84_0
	{
		public long userId; //Field offset: 0x10
		public ManagerTop <>4__this; //Field offset: 0x18

		public <>c__DisplayClass84_0() { }

		internal void <DisplayTop30Panel>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass89_0
	{
		public UserDetailData userDetail; //Field offset: 0x10
		public bool success; //Field offset: 0x18

		public <>c__DisplayClass89_0() { }

		internal void <LoadUserDetailById>b__0(UserDetailData data) { }

	}

	[CompilerGenerated]
	private sealed class <DelayedAnimatePetItem>d__75 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerTop <>4__this; //Field offset: 0x20
		public GameObject item; //Field offset: 0x28
		public int index; //Field offset: 0x30

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
		public <DelayedAnimatePetItem>d__75(int <>1__state) { }

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
	private sealed class <FetchUserDetail>d__68 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int userId; //Field offset: 0x20
		public ManagerTop <>4__this; //Field offset: 0x28

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
		public <FetchUserDetail>d__68(int <>1__state) { }

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
	private sealed class <HideSearchErrorAfterDelay>d__48 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float delay; //Field offset: 0x20
		public ManagerTop <>4__this; //Field offset: 0x28

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
		public <HideSearchErrorAfterDelay>d__48(int <>1__state) { }

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
	private sealed class <LoadDataThenOpenPanel>d__57 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerTop <>4__this; //Field offset: 0x20
		private <>c__DisplayClass57_0 <>8__1; //Field offset: 0x28

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
		public <LoadDataThenOpenPanel>d__57(int <>1__state) { }

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
	private sealed class <LoadTop30Ranking>d__83 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerTop <>4__this; //Field offset: 0x20
		private <>c__DisplayClass83_0 <>8__1; //Field offset: 0x28

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
		public <LoadTop30Ranking>d__83(int <>1__state) { }

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
	private sealed class <LoadUserDetailById>d__89 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public long userId; //Field offset: 0x20
		public ManagerTop <>4__this; //Field offset: 0x28
		private <>c__DisplayClass89_0 <>8__1; //Field offset: 0x30

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
		public <LoadUserDetailById>d__89(int <>1__state) { }

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
	private sealed class <SearchUserByName>d__46 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerTop <>4__this; //Field offset: 0x20
		public string username; //Field offset: 0x28
		private <>c__DisplayClass46_0 <>8__1; //Field offset: 0x30

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
		public <SearchUserByName>d__46(int <>1__state) { }

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

	public const string PANEL_KEY = "PanelXepHang"; //Field offset: 0x0
	[Header("=== TOP 30 PANEL ===")]
	public Button btnReward; //Field offset: 0x20
	public GameObject panelListTop30; //Field offset: 0x28
	public Button btnBackTop30; //Field offset: 0x30
	public Transform listPanelTop30; //Field offset: 0x38
	public GameObject btnUserTopPrefab; //Field offset: 0x40
	[Header("=== SEARCH FEATURE ===")]
	public InputField inputSearchUsername; //Field offset: 0x48
	public Button btnSearch; //Field offset: 0x50
	public GameObject searchErrorPanel; //Field offset: 0x58
	public Text searchErrorText; //Field offset: 0x60
	[Header("UI References")]
	public Button btnTop; //Field offset: 0x68
	public GameObject PanelXepHang; //Field offset: 0x70
	public Button btnBack; //Field offset: 0x78
	[Header("Ranking Items - Có sẵn 9 userT")]
	public Transform[] userTItems; //Field offset: 0x80
	[Header("User Detail Panel")]
	public GameObject panelDetailTop; //Field offset: 0x88
	public Button btnCloseDetail; //Field offset: 0x90
	public Image imgUserDetail; //Field offset: 0x98
	public Text txtUserNameDetail; //Field offset: 0xA0
	public Text txtTotalCombatPowerDetail; //Field offset: 0xA8
	public Image imgUserLevelDetail; //Field offset: 0xB0
	public Animator anmtCurrentPet; //Field offset: 0xB8
	public Text txtUserTop; //Field offset: 0xC0
	[Header("Current Pet Stats")]
	public Text txtAttack; //Field offset: 0xC8
	public Text txtHP; //Field offset: 0xD0
	public Text txtMana; //Field offset: 0xD8
	[Header("Pet List")]
	public Transform petListContent; //Field offset: 0xE0
	public GameObject petItemPrefab; //Field offset: 0xE8
	[Header("Stone List")]
	public Transform stoneListContent; //Field offset: 0xF0
	public GameObject stoneItemPrefab; //Field offset: 0xF8
	[Header("Stone Images - 5 Hệ, mỗi hệ 7 Level")]
	[Tooltip("Hệ Lửa - 7 level")]
	public Sprite[] stoneFire; //Field offset: 0x100
	[Tooltip("Hệ Nước - 7 level")]
	public Sprite[] stoneWater; //Field offset: 0x108
	[Tooltip("Hệ Gió - 7 level")]
	public Sprite[] stoneWind; //Field offset: 0x110
	[Tooltip("Hệ Đất - 7 level")]
	public Sprite[] stoneEarth; //Field offset: 0x118
	[Tooltip("Hệ Sét - 7 level")]
	public Sprite[] stoneThunder; //Field offset: 0x120
	[Header("Animation Settings")]
	public float panelAnimDuration; //Field offset: 0x128
	public float itemAnimDelay; //Field offset: 0x12C
	public LeanTweenType easeType; //Field offset: 0x130
	private List<TopRankingData> currentRankings; //Field offset: 0x138
	private Dictionary<Int32, Sprite> stoneDictionary; //Field offset: 0x140
	private CanvasGroup panelXepHangCanvasGroup; //Field offset: 0x148
	private CanvasGroup panelDetailCanvasGroup; //Field offset: 0x150
	private GameObject _rewardRowTemplate; //Field offset: 0x158
	private Transform _rewardRowsParent; //Field offset: 0x160
	[Header("Loading")]
	public GameObject loadingIndicator; //Field offset: 0x168

	public ManagerTop() { }

	[CompilerGenerated]
	private void <FetchUserDetail>b__68_0(UserDetailData userDetail) { }

	[CompilerGenerated]
	private void <OnCloseDetailClicked>b__61_0() { }

	[CompilerGenerated]
	private void <OnCloseRankingClicked>b__60_1() { }

	[CompilerGenerated]
	private void <OnCloseTop30PanelClicked>b__90_0() { }

	[CompilerGenerated]
	private void <OnTopButtonClicked>b__55_0() { }

	private void AnimateClosePanel(GameObject panel, CanvasGroup canvasGroup) { }

	private void AnimateImage(GameObject imgObj, float delay) { }

	private void AnimateNumberText(Text textComponent, int fromValue, int toValue, float delay, float duration) { }

	private void AnimateOpenPanel(GameObject panel, CanvasGroup canvasGroup) { }

	private void AnimatePanelClose(GameObject panel, Action onComplete) { }

	private void AnimatePanelOpen(GameObject panel) { }

	private void AnimatePetItem(GameObject item, int index) { }

	private void AnimateRankingItem(GameObject item, int index) { }

	private void AnimateStoneItem(GameObject item, int index) { }

	private void AnimateText(GameObject textObj, float delay) { }

	private void AnimateTop30Item(GameObject item, int index) { }

	private static void ApplyRowWeaponBadge(Transform row, string avatarNodeName, int imageId, string rarity, long userId) { }

	private void Awake() { }

	private void BuildRewardTable(List<RankingRewardTier> tiers) { }

	private int CountValidSprites(Sprite[] sprites) { }

	[IteratorStateMachine(typeof(<DelayedAnimatePetItem>d__75))]
	private IEnumerator DelayedAnimatePetItem(GameObject item, int index) { }

	private void DisplayPetList(List<UserPetInfo> pets) { }

	private void DisplayRankings(List<TopRankingData> rankings) { }

	private void DisplayStoneList(List<StoneInfo> stones) { }

	private void DisplayTop30Panel(List<TopRankingData> rankings) { }

	private void DisplayUserDetail(UserDetailData userDetail) { }

	[IteratorStateMachine(typeof(<FetchUserDetail>d__68))]
	private IEnumerator FetchUserDetail(int userId) { }

	private Sprite GetStoneSprite(long stoneId) { }

	private void HideLoadingIndicator() { }

	[IteratorStateMachine(typeof(<HideSearchErrorAfterDelay>d__48))]
	private IEnumerator HideSearchErrorAfterDelay(float delay) { }

	private void InitializeStoneDictionary() { }

	[IteratorStateMachine(typeof(<LoadDataThenOpenPanel>d__57))]
	private IEnumerator LoadDataThenOpenPanel() { }

	private void LoadRankingRewardTable() { }

	[IteratorStateMachine(typeof(<LoadTop30Ranking>d__83))]
	private IEnumerator LoadTop30Ranking() { }

	[IteratorStateMachine(typeof(<LoadUserDetailById>d__89))]
	private IEnumerator LoadUserDetailById(long userId) { }

	private void OnCloseDetailClicked() { }

	private void OnCloseRankingClicked() { }

	private void OnCloseTop30PanelClicked() { }

	private void OnDestroy() { }

	private void OnRewardButtonClicked() { }

	private void OnSearchButtonClicked() { }

	private void OnTop30ItemClicked(long userId) { }

	private void OnTopButtonClicked() { }

	private void OnUserItemClicked(long userId) { }

	public void OpenRanking() { }

	[IteratorStateMachine(typeof(<SearchUserByName>d__46))]
	private IEnumerator SearchUserByName(string username) { }

	private void SetupCanvasGroups() { }

	private void SetupImgLevel(int level, Image imgLv) { }

	private void SetupPetItem(GameObject item, UserPetInfo pet) { }

	private void SetupRankingItem(Transform userT, TopRankingData ranking) { }

	private void SetupStoneItem(GameObject item, StoneInfo stone) { }

	private void SetupTop30Item(GameObject item, TopRankingData ranking) { }

	private void ShowLoadingIndicator() { }

	private void ShowSearchError(string message) { }

	private bool TrySetupPetAnimation(Animator petAnimator, string petID) { }

}

