//Type is in global namespace

public class ManagerNapTichLuy : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass51_0
	{
		public ManagerNapTichLuy <>4__this; //Field offset: 0x10
		public LifetimeMilestoneStatusData milestone; //Field offset: 0x18

		public <>c__DisplayClass51_0() { }

		internal void <UpdateLifetimeMilestoneGroup>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass52_0
	{
		public ManagerNapTichLuy <>4__this; //Field offset: 0x10
		public MilestoneStatusData milestone; //Field offset: 0x18

		public <>c__DisplayClass52_0() { }

		internal void <UpdateMilestoneGroup>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass55_0
	{
		public ManagerNapTichLuy <>4__this; //Field offset: 0x10
		public MilestoneRewardData rewardsToShow; //Field offset: 0x18

		public <>c__DisplayClass55_0() { }

		internal void <OnClickClaimMonthlyMilestone>b__0(ClaimMilestoneResponse response) { }

		internal void <OnClickClaimMonthlyMilestone>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass57_0
	{
		public ManagerNapTichLuy <>4__this; //Field offset: 0x10
		public MilestoneRewardData rewardsToShow; //Field offset: 0x18

		public <>c__DisplayClass57_0() { }

		internal void <OnClickClaimLifetimeMilestone>b__0(ClaimLifetimeMilestoneResponse response) { }

		internal void <OnClickClaimLifetimeMilestone>b__1(string error) { }

	}

	internal class MilestoneGroupUI
	{
		public Text txtCount; //Field offset: 0x10
		public GameObject point; //Field offset: 0x18
		public Button btnGive; //Field offset: 0x20
		public Transform rewardContainer; //Field offset: 0x28

		public MilestoneGroupUI() { }

	}

	private class RewardData
	{
		public string type; //Field offset: 0x10
		public int amount; //Field offset: 0x18
		public long id; //Field offset: 0x20

		public RewardData() { }

	}

	public const string PANEL_KEY = "PanelNapTichLuy"; //Field offset: 0x0
	[Header("Panel Reference")]
	public GameObject panelNapTichLuy; //Field offset: 0x20
	public Button btnBack; //Field offset: 0x28
	[Header("Texts")]
	public Text naptichluy; //Field offset: 0x30
	public Text napthang; //Field offset: 0x38
	[Header("Sliders")]
	public Slider SliderNap; //Field offset: 0x40
	public Slider SliderNapTong; //Field offset: 0x48
	[Header("Milestone Groups - Monthly")]
	public List<MilestoneGroupUI> Group; //Field offset: 0x50
	[Header("Milestone Groups - Lifetime")]
	public List<MilestoneGroupUI> GroupTong; //Field offset: 0x58
	[Header("Reward Prefabs")]
	public GameObject avtRW; //Field offset: 0x60
	public GameObject blueStarRW; //Field offset: 0x68
	public GameObject cardRW; //Field offset: 0x70
	public GameObject energyRW; //Field offset: 0x78
	public GameObject expRW; //Field offset: 0x80
	public GameObject goldRW; //Field offset: 0x88
	public GameObject petRW; //Field offset: 0x90
	public GameObject redStarRW; //Field offset: 0x98
	public GameObject rubyRW; //Field offset: 0xA0
	public GameObject stoneRW; //Field offset: 0xA8
	public GameObject wheelDayRW; //Field offset: 0xB0
	public GameObject wheelRW; //Field offset: 0xB8
	public GameObject whiteStarRW; //Field offset: 0xC0
	public GameObject allStoneRW; //Field offset: 0xC8
	[Header("New Item Prefabs")]
	public GameObject crystalRWPrefab; //Field offset: 0xD0
	public GameObject eItem1RWPrefab; //Field offset: 0xD8
	public GameObject eItem2RWPrefab; //Field offset: 0xE0
	public GameObject eItem3RWPrefab; //Field offset: 0xE8
	public GameObject eItem4RWPrefab; //Field offset: 0xF0
	[Header("Data")]
	private MonthlyMilestoneData monthlyMilestoneData; //Field offset: 0xF8
	private LifetimeMilestoneData lifetimeMilestoneData; //Field offset: 0x100
	private int userId; //Field offset: 0x108
	[Header("Result Panel")]
	public GameObject panelGiftBox; //Field offset: 0x110
	public Transform listRewardContainer; //Field offset: 0x118
	public Button btnGetClose; //Field offset: 0x120
	private Dictionary<String, GameObject> rewardPrefabs; //Field offset: 0x128

	public ManagerNapTichLuy() { }

	private void ApplyScrollIfNeeded(List<MilestoneGroupUI> slots) { }

	private void Awake() { }

	private void CloseGiftBoxPanel() { }

	private void ClosePanel() { }

	private void DisplayRewards(MilestoneRewardData rewards, MilestoneGroupUI groupUI) { }

	private void EnsureScrollable(RectTransform container, bool horizontal) { }

	private void EnsureSlotCapacity(List<MilestoneGroupUI> slots, int needed) { }

	private string FormatCurrency(long amount) { }

	private string FormatCurrencyExact(long amount) { }

	private string FormatRewardAmount(int amount) { }

	private void InitializeRewardPrefabs() { }

	private void LoadLifetimeMilestoneData() { }

	private void LoadMonthlyMilestoneData() { }

	private void OnClaimError(string error) { }

	private void OnClaimLifetimeSuccess(ClaimLifetimeMilestoneResponse response, MilestoneRewardData rewards) { }

	private void OnClaimMonthlySuccess(ClaimMilestoneResponse response, MilestoneRewardData rewards) { }

	private void OnClickClaimLifetimeMilestone(long milestoneId) { }

	private void OnClickClaimMonthlyMilestone(long milestoneId) { }

	private void OnLoadLifetimeDataError(string error) { }

	private void OnLoadLifetimeDataSuccess(LifetimeMilestoneData data) { }

	private void OnLoadMonthlyDataError(string error) { }

	private void OnLoadMonthlyDataSuccess(MonthlyMilestoneData data) { }

	public void OpenPanel() { }

	private static string PathTo(Transform root, Transform node) { }

	private static Transform ResolveChild(Transform root, string path) { }

	private void SetUnusedSlotsVisible(List<MilestoneGroupUI> slots, int usedCount) { }

	private void ShowRewardResultPanel(MilestoneRewardData rewards) { }

	private static Transform SlotAnchor(MilestoneGroupUI ui) { }

	private void Start() { }

	private static bool TryFindRowRoots(Transform anchorA, Transform anchorB, out Transform rootA, out Transform rootB) { }

	private void UnwrapScroll(RectTransform container, RectTransform wrapRT) { }

	private void UpdateLifetimeMilestoneGroup(MilestoneGroupUI groupUI, LifetimeMilestoneStatusData milestone) { }

	private void UpdateLifetimeUI(LifetimeMilestoneData data) { }

	private void UpdateMilestoneGroup(MilestoneGroupUI groupUI, MilestoneStatusData milestone, bool isMonthly) { }

	private void UpdateMonthlyUI(MonthlyMilestoneData data) { }

}

