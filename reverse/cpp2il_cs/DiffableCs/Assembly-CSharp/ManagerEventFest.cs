//Type is in global namespace

public class ManagerEventFest : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__62_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <LoadState>b__62_1(string err) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass71_0
	{
		public ManagerEventFest <>4__this; //Field offset: 0x10
		public EventFestMilestoneDTO captured; //Field offset: 0x18

		public <>c__DisplayClass71_0() { }

		internal void <BindSlot>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass85_0
	{
		public ManagerEventFest <>4__this; //Field offset: 0x10
		public int index; //Field offset: 0x18

		public <>c__DisplayClass85_0() { }

		internal void <FlipCoroutine>b__0(EventFestStateDTO state) { }

		internal void <FlipCoroutine>b__1(string err) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass85_1
	{
		public EventFestStateDTO state; //Field offset: 0x10
		public <>c__DisplayClass85_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass85_1() { }

		internal void <FlipCoroutine>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass86_0
	{
		public Image img; //Field offset: 0x10
		public ManagerEventFest <>4__this; //Field offset: 0x18
		public string type; //Field offset: 0x20
		public Text txt; //Field offset: 0x28
		public int amount; //Field offset: 0x30
		public Action onDone; //Field offset: 0x38

		public <>c__DisplayClass86_0() { }

		internal void <RevealCard>b__0() { }

		internal void <RevealCard>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass88_0
	{
		public int idx; //Field offset: 0x10
		public ManagerEventFest <>4__this; //Field offset: 0x18

		public <>c__DisplayClass88_0() { }

		internal void <BuildFlipPopup>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass90_0
	{
		public int idx; //Field offset: 0x10
		public ManagerEventFest <>4__this; //Field offset: 0x18

		public <>c__DisplayClass90_0() { }

		internal void <WireRefs>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <ClaimCoroutine>d__64 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerEventFest <>4__this; //Field offset: 0x20
		public long milestoneId; //Field offset: 0x28

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
		public <ClaimCoroutine>d__64(int <>1__state) { }

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
	private sealed class <FlipCoroutine>d__85 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerEventFest <>4__this; //Field offset: 0x20
		public int index; //Field offset: 0x28

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
		public <FlipCoroutine>d__85(int <>1__state) { }

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
	private sealed class <LoadState>d__62 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerEventFest <>4__this; //Field offset: 0x20

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
		public <LoadState>d__62(int <>1__state) { }

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

	public const string PANEL_KEY = "PanelEventFest"; //Field offset: 0x0
	private static readonly Color COL_OVERLAY; //Field offset: 0x0
	private static readonly Color COL_BOX; //Field offset: 0x10
	private static readonly Color COL_BANNER; //Field offset: 0x20
	private static readonly Color COL_SAND; //Field offset: 0x30
	private static readonly Color COL_CORAL; //Field offset: 0x40
	private static readonly Color COL_CARD; //Field offset: 0x50
	private static readonly Color COL_CARD_DONE; //Field offset: 0x60
	private static readonly Color COL_SLOT; //Field offset: 0x70
	private static readonly Color COL_SLOT_DONE; //Field offset: 0x80
	private static readonly Color COL_BTN_CLAIM; //Field offset: 0x90
	private static readonly Color COL_BTN_LOCK; //Field offset: 0xA0
	private static readonly Color COL_BTN_DONE; //Field offset: 0xB0
	private static readonly Color COL_BAR_FILL; //Field offset: 0xC0
	[Header("Font (de trong = dung mac dinh)")]
	public Font customFont; //Field offset: 0x20
	[Header("Icon qua — SET 1 CHO DUY NHAT, tu load vao moc thuong + ruong + popup.\nDe trong = tu tim Resources/Image/EventFest/{TEN_LOAI_QUA}.png")]
	public Sprite icGold; //Field offset: 0x28
	public Sprite icEnergy; //Field offset: 0x30
	public Sprite icRuby; //Field offset: 0x38
	public Sprite icCrystal; //Field offset: 0x40
	public Sprite icItem1; //Field offset: 0x48
	public Sprite icItem2; //Field offset: 0x50
	public Sprite icItem3; //Field offset: 0x58
	public Sprite icItem4; //Field offset: 0x60
	public Sprite icStoneCard; //Field offset: 0x68
	public Sprite icStarWhite; //Field offset: 0x70
	public Sprite icStarBlue; //Field offset: 0x78
	public Sprite icStarRed; //Field offset: 0x80
	[Header("Loi Mega 1..9 (phan tu 0 = M_CORE1 ... phan tu 8 = M_CORE9)")]
	public Sprite[] icMCore; //Field offset: 0x88
	private EventFestStateDTO _state; //Field offset: 0x90
	private bool _isLoading; //Field offset: 0x98
	private bool _isClaiming; //Field offset: 0x99
	private bool _openedOnce; //Field offset: 0x9A
	[SerializeField]
	private GameObject _panel; //Field offset: 0xA0
	[SerializeField]
	private Text _txtTitle; //Field offset: 0xA8
	[SerializeField]
	private Text _txtDesc; //Field offset: 0xB0
	[SerializeField]
	private Text _txtTimer; //Field offset: 0xB8
	[SerializeField]
	private Text _txtPoints; //Field offset: 0xC0
	[SerializeField]
	private Text _txtProgress; //Field offset: 0xC8
	[SerializeField]
	private Text _txtDailyPoints; //Field offset: 0xD0
	[SerializeField]
	private Image _barFill; //Field offset: 0xD8
	[SerializeField]
	private Transform _missionRow; //Field offset: 0xE0
	[SerializeField]
	private Transform _trackContent; //Field offset: 0xE8
	[SerializeField]
	private GameObject _rewardPopup; //Field offset: 0xF0
	[SerializeField]
	private Image _popupIcon; //Field offset: 0xF8
	[SerializeField]
	private Text _popupMsg; //Field offset: 0x100
	[SerializeField]
	private Button _btnMiniGame; //Field offset: 0x108
	[SerializeField]
	private Text _txtMiniGameBtn; //Field offset: 0x110
	[SerializeField]
	private GameObject _flipPopup; //Field offset: 0x118
	[SerializeField]
	private Text _txtFlipsLeft; //Field offset: 0x120
	[SerializeField]
	private Text _txtFlipHint; //Field offset: 0x128
	private readonly List<GameObject> _flipCards; //Field offset: 0x130
	private readonly Boolean[] _flipCardUsed; //Field offset: 0x138
	private readonly Sprite[] _chestOrigSprites; //Field offset: 0x140
	private bool _chestSpritesCaptured; //Field offset: 0x148
	private bool _flipping; //Field offset: 0x149
	private readonly List<GameObject> _slotPool; //Field offset: 0x150

	private static ManagerEventFest() { }

	public ManagerEventFest() { }

	[CompilerGenerated]
	private void <ClaimCoroutine>b__64_0(EventFestStateDTO state) { }

	[CompilerGenerated]
	private void <ClaimCoroutine>b__64_1(string err) { }

	[CompilerGenerated]
	private void <ClosePanel>b__61_0() { }

	[CompilerGenerated]
	private void <CloseRewardPopup>b__73_0() { }

	[CompilerGenerated]
	private void <LoadState>b__62_0(EventFestStateDTO state) { }

	private GameObject AddText(Transform parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0, float padR = 0, float padT = 0, float padB = 0) { }

	private GameObject AddText(GameObject parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0, float padR = 0, float padT = 0, float padB = 0) { }

	private void ApplyState(EventFestStateDTO s) { }

	private static void Band(GameObject go, float xMin, float xMax, float yMin, float yMax, float padL = 0, float padR = 0, float padT = 0, float padB = 0) { }

	private void BindSlot(GameObject slot, EventFestMilestoneDTO m) { }

	private void BuildBanner(Transform p) { }

	private void BuildCloseButton(Transform p) { }

	private void BuildFlipPopup(Transform p) { }

	private GameObject BuildMilestoneSlot(int index) { }

	private void BuildMissionSection(Transform p) { }

	private void BuildPointsSection(Transform p) { }

	private void BuildRewardPopup(Transform p) { }

	private void BuildTrackSection(Transform p) { }

	[ContextMenu("Tao UI")]
	public void BuildUI() { }

	[IteratorStateMachine(typeof(<ClaimCoroutine>d__64))]
	private IEnumerator ClaimCoroutine(long milestoneId) { }

	private void CloseFlipPopup() { }

	public void ClosePanel() { }

	private void CloseRewardPopup() { }

	private static string FlipCardLabel(string type, int amount) { }

	[IteratorStateMachine(typeof(<FlipCoroutine>d__85))]
	private IEnumerator FlipCoroutine(int index) { }

	private Sprite GetRewardSprite(string type) { }

	[IteratorStateMachine(typeof(<LoadState>d__62))]
	private IEnumerator LoadState() { }

	private static GameObject NewGO(string name, Transform parent) { }

	private void OnClickChest(int index) { }

	private void OnClickClaim(EventFestMilestoneDTO m) { }

	public void OpenFlipPopup() { }

	public void OpenPanel() { }

	public void PrebuildSlots(int count) { }

	private void RefreshHubResources() { }

	private void RefreshMiniGame() { }

	private void RefreshMissions() { }

	private void RefreshProgressBar() { }

	private void RefreshTrack() { }

	private void RevealCard(GameObject card, string type, int amount, Action onDone) { }

	private static Color RewardColor(string type) { }

	private static string RewardLabel(EventFestMilestoneDTO m) { }

	private void ShowRewardPopup(EventFestStateDTO s) { }

	private void Start() { }

	private static void Stretch(GameObject go, float l = 0, float r = 0, float t = 0, float b = 0) { }

	private static GameObject Stretch(GameObject go) { }

	private void WireRefs() { }

}

