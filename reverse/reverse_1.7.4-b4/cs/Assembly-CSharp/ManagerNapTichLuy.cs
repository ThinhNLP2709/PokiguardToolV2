/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ManagerNapTichLuy : MonoBehaviour // TypeDefIndex: 1318
{
	// Fields
	public const string PANEL_KEY = "PanelNapTichLuy"; // Metadata: 0x005F0D77
	[Header("Panel Reference")]
	public GameObject panelNapTichLuy; // 0x20
	public Button btnBack; // 0x28
	[Header("Texts")]
	public UnityEngine.UI.Text naptichluy; // 0x30
	public UnityEngine.UI.Text napthang; // 0x38
	[Header("Sliders")]
	public Slider SliderNap; // 0x40
	public Slider SliderNapTong; // 0x48
	[Header("Milestone Groups - Monthly")]
	public List<MilestoneGroupUI> Group; // 0x50
	[Header("Milestone Groups - Lifetime")]
	public List<MilestoneGroupUI> GroupTong; // 0x58
	[Header("Reward Prefabs")]
	public GameObject avtRW; // 0x60
	public GameObject blueStarRW; // 0x68
	public GameObject cardRW; // 0x70
	public GameObject energyRW; // 0x78
	public GameObject expRW; // 0x80
	public GameObject goldRW; // 0x88
	public GameObject petRW; // 0x90
	public GameObject redStarRW; // 0x98
	public GameObject rubyRW; // 0xA0
	public GameObject stoneRW; // 0xA8
	public GameObject wheelDayRW; // 0xB0
	public GameObject wheelRW; // 0xB8
	public GameObject whiteStarRW; // 0xC0
	public GameObject allStoneRW; // 0xC8
	[Header("New Item Prefabs")]
	public GameObject crystalRWPrefab; // 0xD0
	public GameObject eItem1RWPrefab; // 0xD8
	public GameObject eItem2RWPrefab; // 0xE0
	public GameObject eItem3RWPrefab; // 0xE8
	public GameObject eItem4RWPrefab; // 0xF0
	[Header("Data")]
	private MonthlyMilestoneData monthlyMilestoneData; // 0xF8
	private LifetimeMilestoneData lifetimeMilestoneData; // 0x100
	private int userId; // 0x108
	[Header("Result Panel")]
	public GameObject panelGiftBox; // 0x110
	public Transform listRewardContainer; // 0x118
	public Button btnGetClose; // 0x120
	private Dictionary<string, GameObject> rewardPrefabs; // 0x128
	private const string NAP_SLOT_NAME = "btnNapNgay"; // Metadata: 0x005F0D87
	private const string NAP_LABEL = "DONATE"; // Metadata: 0x005F0D92
	private Button btnNap; // 0x130

	// Nested types
	[Serializable]
	public class MilestoneGroupUI // TypeDefIndex: 1319
	{
		// Fields
		public UnityEngine.UI.Text txtCount; // 0x10
		public GameObject point; // 0x18
		public Button btnGive; // 0x20
		public Transform rewardContainer; // 0x28
		public GameObject chest; // 0x30

		// Constructors
		public MilestoneGroupUI(); // 0x000000018028A320-0x000000018028A330
	}

	private class RewardData // TypeDefIndex: 1320
	{
		// Fields
		public string type; // 0x10
		public int amount; // 0x18
		public long id; // 0x20

		// Constructors
		public RewardData(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass61_0 // TypeDefIndex: 1321
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public LifetimeMilestoneStatusData milestone; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass61_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UpdateLifetimeMilestoneGroup_b__0(); // 0x000000018075A4C0-0x000000018075A500
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass62_0 // TypeDefIndex: 1322
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public MilestoneStatusData milestone; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass62_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UpdateMilestoneGroup_b__0(); // 0x000000018075A500-0x000000018075A540
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass67_0 // TypeDefIndex: 1323
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public MilestoneRewardData rewardsToShow; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass67_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickClaimMonthlyMilestone_b__0(ClaimMilestoneResponse response); // 0x000000018075A540-0x000000018075A6F0
		internal void _OnClickClaimMonthlyMilestone_b__1(string error); // 0x000000018075A6F0-0x000000018075A710
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass69_0 // TypeDefIndex: 1324
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public MilestoneRewardData rewardsToShow; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass69_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickClaimLifetimeMilestone_b__0(ClaimLifetimeMilestoneResponse response); // 0x000000018075A710-0x000000018075A8C0
		internal void _OnClickClaimLifetimeMilestone_b__1(string error); // 0x000000018075A6F0-0x000000018075A710
	}

	// Constructors
	public ManagerNapTichLuy(); // 0x000000018075A280-0x000000018075A400

	// Methods
	private void Awake(); // 0x000000018074A860-0x000000018074AD40
	private void Start(); // 0x000000018074AD40-0x000000018074B250
	private void ShowRewardResultPanel(MilestoneRewardData rewards); // 0x000000018074B250-0x000000018074CE70
	private void CloseGiftBoxPanel(); // 0x000000018074CE70-0x000000018074CFC0
	private void InitializeRewardPrefabs(); // 0x000000018074CFC0-0x000000018074D7B0
	private void SetupNapButton(); // 0x000000018074D7B0-0x000000018074E4D0
	private Button FindClaimButtonSample(); // 0x000000018074E4D0-0x000000018074E8C0
	private void SetNapButtonLabel(GameObject button); // 0x000000018074E8C0-0x000000018074EB80
	private void OpenRecharge(); // 0x000000018074EB80-0x000000018074EC90
	private void OnEnable(); // 0x000000018074EC90-0x000000018074ED10
	private void OnDisable(); // 0x000000018074ED10-0x000000018074ED90
	private void OnRechargeOk(int safiaAdded, int newBalance); // 0x000000018074ED90-0x000000018074EE30
	public void OpenPanel(); // 0x000000018074EE30-0x000000018074F030
	private void ClosePanel(); // 0x000000018074F030-0x000000018074F2A0
	private void LoadMonthlyMilestoneData(); // 0x000000018074F2A0-0x000000018074F4F0
	private void OnLoadMonthlyDataSuccess(MonthlyMilestoneData data); // 0x000000018074F4F0-0x000000018074F550
	private void OnLoadMonthlyDataError(string error); // 0x000000018074F550-0x000000018074F5D0
	private void UpdateMonthlyUI(MonthlyMilestoneData data); // 0x000000018074F5D0-0x000000018074FB70
	private void LoadLifetimeMilestoneData(); // 0x000000018074FB70-0x000000018074FDC0
	private void OnLoadLifetimeDataSuccess(LifetimeMilestoneData data); // 0x000000018074FDC0-0x000000018074FE20
	private void OnLoadLifetimeDataError(string error); // 0x000000018074FE20-0x000000018074FEA0
	private void UpdateLifetimeUI(LifetimeMilestoneData data); // 0x000000018074FEA0-0x0000000180750270
	private void ApplyScrollIfNeeded(List<MilestoneGroupUI> slots); // 0x0000000180750270-0x0000000180750780
	private void UpdateLifetimeMilestoneGroup(MilestoneGroupUI groupUI, LifetimeMilestoneStatusData milestone, int rank, int total); // 0x0000000180750780-0x0000000180751300
	private void UpdateMilestoneGroup(MilestoneGroupUI groupUI, MilestoneStatusData milestone, bool isMonthly, int rank, int total); // 0x0000000180751300-0x0000000180751B50
	private static GameObject ResolveChest(MilestoneGroupUI groupUI); // 0x0000000180751B50-0x0000000180751EC0
	private void DisplayRewards(MilestoneRewardData rewards, MilestoneGroupUI groupUI, int rank, int total, bool claimed); // 0x0000000180751EC0-0x0000000180753E00
	private PokyTooltipTarget AttachMilestoneTooltip(GameObject host, MilestoneGroupUI groupUI, MilestoneRewardData rewards); // 0x0000000180753E00-0x0000000180754660
	private string FormatRewardAmount(int amount); // 0x0000000180754660-0x00000001807547D0
	private void OnClickClaimMonthlyMilestone(long milestoneId, MilestoneGroupUI groupUI); // 0x00000001807547D0-0x0000000180754D60
	private void OnClaimMonthlySuccess(ClaimMilestoneResponse response, MilestoneRewardData rewards, MilestoneGroupUI groupUI); // 0x0000000180754D60-0x0000000180754F00
	private void OnClickClaimLifetimeMilestone(long milestoneId, MilestoneGroupUI groupUI); // 0x0000000180754F00-0x00000001807556C0
	private void OnClaimLifetimeSuccess(ClaimLifetimeMilestoneResponse response, MilestoneRewardData rewards, MilestoneGroupUI groupUI); // 0x00000001807556C0-0x0000000180755860
	private void OpenChestFx(MilestoneGroupUI groupUI); // 0x0000000180755860-0x0000000180755A30
	private static int TierOfChest(GameObject chest); // 0x0000000180755A30-0x0000000180755D10
	private void OnClaimError(string error); // 0x0000000180755D10-0x0000000180755D90
	private string FormatCurrency(long amount); // 0x0000000180755D90-0x0000000180755F00
	private string FormatCurrencyExact(long amount); // 0x0000000180755F00-0x0000000180756010
	private void EnsureSlotCapacity(List<MilestoneGroupUI> slots, int needed); // 0x0000000180756010-0x0000000180756E50
	private void SetUnusedSlotsVisible(List<MilestoneGroupUI> slots, int usedCount); // 0x0000000180756E50-0x00000001807571F0
	private void EnsureScrollable(RectTransform container, bool horizontal); // 0x00000001807571F0-0x00000001807580A0
	private void UnwrapScroll(RectTransform container, RectTransform wrapRT); // 0x00000001807580A0-0x00000001807583D0
	private static Transform SlotAnchor(MilestoneGroupUI ui); // 0x00000001807583D0-0x0000000180758630
	private static bool TryFindRowRoots(Transform anchorA, Transform anchorB, out Transform rootA, out Transform rootB); // 0x0000000180758630-0x0000000180758B40
	private static string PathTo(Transform root, Transform node); // 0x0000000180758B40-0x0000000180758F90
	private static Transform ResolveChild(Transform root, string path); // 0x0000000180758F90-0x00000001807590B0
	private static List<KeyValuePair<long, int>> ParseShards(string json); // 0x00000001807590B0-0x00000001807595A0
	private static void AddShardRewards(List<RewardData> rewardList, string shardsJson); // 0x00000001807595A0-0x0000000180759850
	private static void ApplyShardVisual(GameObject obj, RewardData reward); // 0x0000000180759850-0x000000018075A280
}

