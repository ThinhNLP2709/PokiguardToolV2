//Type is in global namespace

public class ManagerOnlineGift : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public OnlineGiftMilestoneData milestone; //Field offset: 0x10
		public ManagerOnlineGift <>4__this; //Field offset: 0x18

		public <>c__DisplayClass32_0() { }

		internal void <BuildRows>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass36_0
	{
		public ManagerOnlineGift <>4__this; //Field offset: 0x10
		public OnlineGiftMilestoneData milestone; //Field offset: 0x18

		public <>c__DisplayClass36_0() { }

		internal void <OnClickClaim>b__0(OnlineGiftMilestoneData claimed) { }

	}

	private class RowUI
	{
		public OnlineGiftMilestoneData milestone; //Field offset: 0x10
		public GameObject root; //Field offset: 0x18
		public Button btn; //Field offset: 0x20
		public Text btnTxt; //Field offset: 0x28
		public GameObject point; //Field offset: 0x30
		public GameObject tick; //Field offset: 0x38
		public Image btnImg; //Field offset: 0x40

		public RowUI() { }

	}

	public const string PANEL_KEY = "PanelOnlineGift"; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<OnlineGiftData> OnStatusUpdated; //Field offset: 0x0
	private const float RewardCell = 66; //Field offset: 0x0
	private const float RowH = 78; //Field offset: 0x0
	private const float BoxH = 500; //Field offset: 0x0
	private const float BoxW = 823.92; //Field offset: 0x0
	private static readonly Color GoldText; //Field offset: 0x8
	private static readonly Color LabelText; //Field offset: 0x18
	private static readonly Color WarnText; //Field offset: 0x28
	[Header("Refs (builder tự gán — fallback bind theo tên node)")]
	public GameObject panelRoot; //Field offset: 0x20
	public Text txtTitle; //Field offset: 0x28
	public Text txtToday; //Field offset: 0x30
	public Text txtNotice; //Field offset: 0x38
	public Transform content; //Field offset: 0x40
	public GameObject rowTemplate; //Field offset: 0x48
	public Button btnClose; //Field offset: 0x50
	public Font customFont; //Field offset: 0x58
	[Header("Result Panel (mượn PanelGiftBox của hub lúc runtime)")]
	public GameObject panelGiftBox; //Field offset: 0x60
	public Transform listRewardContainer; //Field offset: 0x68
	public Button btnGetClose; //Field offset: 0x70
	private int userId; //Field offset: 0x78
	private OnlineGiftData _data; //Field offset: 0x80
	private float _fetchAtRealtime; //Field offset: 0x88
	private float _nextUiTick; //Field offset: 0x8C
	private float _nextAutoRefetchAt; //Field offset: 0x90
	private bool _loading; //Field offset: 0x94
	private float _noticeHideAt; //Field offset: 0x98
	private readonly List<RowUI> _rows; //Field offset: 0xA0

	public static event Action<OnlineGiftData> OnStatusUpdated
	{
		[CompilerGenerated]
		 add { } //Length: 257
		[CompilerGenerated]
		 remove { } //Length: 257
	}

	private static ManagerOnlineGift() { }

	public ManagerOnlineGift() { }

	[CompilerGenerated]
	private void <LoadStatus>b__30_0(string err) { }

	[CompilerGenerated]
	public static void add_OnStatusUpdated(Action<OnlineGiftData> value) { }

	private static void AddOutline(GameObject textGo) { }

	private GameObject AddText(GameObject parent, string name, string text, int size, FontStyle style, Color color, TextAnchor align, float xMin, float xMax, float yMin, float yMax, float padL = 0, float padR = 0, float padT = 0, float padB = 0) { }

	private void ApplyRowState(RowUI row) { }

	private void Awake() { }

	private static void Band(GameObject go, float xMin, float xMax, float yMin, float yMax, float padL = 0, float padR = 0, float padT = 0, float padB = 0) { }

	private void BindFromHierarchy() { }

	private void BuildRows() { }

	private GameObject BuildRowTemplate(Transform parent) { }

	[ContextMenu("Tao UI")]
	public void BuildUI() { }

	private void CloseGiftBoxPanel() { }

	public void ClosePanel() { }

	private int CurrentDisplaySeconds() { }

	private static string ExtractServerMessage(string error) { }

	public static string FormatClock(int seconds) { }

	public static string FormatDurationLabel(int seconds) { }

	private void LoadStatus() { }

	private static GameObject NewGO(string name, Transform parent) { }

	private void OnClaimError(string error) { }

	private void OnClaimSuccess(OnlineGiftMilestoneData claimed, OnlineGiftMilestoneData requested) { }

	private void OnClickClaim(OnlineGiftMilestoneData milestone) { }

	private void OnStatusLoaded(OnlineGiftData data) { }

	public void OpenPanel() { }

	[CompilerGenerated]
	public static void remove_OnStatusUpdated(Action<OnlineGiftData> value) { }

	private void ShowNotice(string message) { }

	private void ShowRewardResultPanel(OnlineGiftRewardData reward) { }

	private static Sprite Sp(string resPath, string subName = null) { }

	private void Start() { }

	private static void Stretch(GameObject go) { }

	private void Update() { }

}

