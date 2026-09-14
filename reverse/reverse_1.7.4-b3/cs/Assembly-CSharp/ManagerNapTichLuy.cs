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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerNapTichLuy : MonoBehaviour // TypeDefIndex: 1316
{
	// Fields
	public const string PANEL_KEY = "PanelNapTichLuy"; // Metadata: 0x005EF9AA
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
	private const string NAP_SLOT_NAME = "btnNapNgay"; // Metadata: 0x005EF9BA
	private const string NAP_LABEL = "DONATE"; // Metadata: 0x005EF9C5
	private Button btnNap; // 0x130

	// Nested types
	[Serializable]
	public class MilestoneGroupUI // TypeDefIndex: 1317
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

	private class RewardData // TypeDefIndex: 1318
	{
		// Fields
		public string type; // 0x10
		public int amount; // 0x18
		public long id; // 0x20

		// Constructors
		public RewardData(); // 0x000000018028A320-0x000000018028A330
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass61_0 // TypeDefIndex: 1319
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public LifetimeMilestoneStatusData milestone; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass61_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UpdateLifetimeMilestoneGroup_b__0(); // 0x0000000180758650-0x0000000180758690
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass62_0 // TypeDefIndex: 1320
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public MilestoneStatusData milestone; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass62_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _UpdateMilestoneGroup_b__0(); // 0x0000000180758690-0x00000001807586D0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass67_0 // TypeDefIndex: 1321
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public MilestoneRewardData rewardsToShow; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass67_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickClaimMonthlyMilestone_b__0(ClaimMilestoneResponse response); // 0x00000001807586D0-0x0000000180758850
		internal void _OnClickClaimMonthlyMilestone_b__1(string error); // 0x0000000180758850-0x0000000180758870
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass69_0 // TypeDefIndex: 1322
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public MilestoneRewardData rewardsToShow; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass69_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _OnClickClaimLifetimeMilestone_b__0(ClaimLifetimeMilestoneResponse response); // 0x0000000180758870-0x00000001807589F0
		internal void _OnClickClaimLifetimeMilestone_b__1(string error); // 0x0000000180758850-0x0000000180758870
	}

	// Constructors
	public ManagerNapTichLuy(); // 0x0000000180758410-0x0000000180758590

	// Methods
	private void Awake(); // 0x0000000180748AB0-0x0000000180748F90
	private void Start(); // 0x0000000180748F90-0x00000001807494A0
	private void ShowRewardResultPanel(MilestoneRewardData rewards); // 0x00000001807494A0-0x000000018074B0C0
	private void CloseGiftBoxPanel(); // 0x000000018074B0C0-0x000000018074B210
	private void InitializeRewardPrefabs(); // 0x000000018074B210-0x000000018074BA00
	private void SetupNapButton(); // 0x000000018074BA00-0x000000018074C720
	private Button FindClaimButtonSample(); // 0x000000018074C720-0x000000018074CB10
	private void SetNapButtonLabel(GameObject button); // 0x000000018074CB10-0x000000018074CDD0
	private void OpenRecharge(); // 0x000000018074CDD0-0x000000018074CEE0
	private void OnEnable(); // 0x000000018074CEE0-0x000000018074CF60
	private void OnDisable(); // 0x000000018074CF60-0x000000018074CFE0
	private void OnRechargeOk(int safiaAdded, int newBalance); // 0x000000018074CFE0-0x000000018074D080
	public void OpenPanel(); // 0x000000018074D080-0x000000018074D280
	private void ClosePanel(); // 0x000000018074D280-0x000000018074D4F0
	private void LoadMonthlyMilestoneData(); // 0x000000018074D4F0-0x000000018074D720
	private void OnLoadMonthlyDataSuccess(MonthlyMilestoneData data); // 0x000000018074D720-0x000000018074D780
	private void OnLoadMonthlyDataError(string error); // 0x000000018074D780-0x000000018074D800
	private void UpdateMonthlyUI(MonthlyMilestoneData data); // 0x000000018074D800-0x000000018074DDA0
	private void LoadLifetimeMilestoneData(); // 0x000000018074DDA0-0x000000018074DFD0
	private void OnLoadLifetimeDataSuccess(LifetimeMilestoneData data); // 0x000000018074DFD0-0x000000018074E030
	private void OnLoadLifetimeDataError(string error); // 0x000000018074E030-0x000000018074E0B0
	private void UpdateLifetimeUI(LifetimeMilestoneData data); // 0x000000018074E0B0-0x000000018074E480
	private void ApplyScrollIfNeeded(List<MilestoneGroupUI> slots); // 0x000000018074E480-0x000000018074E990
	private void UpdateLifetimeMilestoneGroup(MilestoneGroupUI groupUI, LifetimeMilestoneStatusData milestone, int rank, int total); // 0x000000018074E990-0x000000018074F510
	private void UpdateMilestoneGroup(MilestoneGroupUI groupUI, MilestoneStatusData milestone, bool isMonthly, int rank, int total); // 0x000000018074F510-0x000000018074FD60
	private static GameObject ResolveChest(MilestoneGroupUI groupUI); // 0x000000018074FD60-0x00000001807500D0
	private void DisplayRewards(MilestoneRewardData rewards, MilestoneGroupUI groupUI, int rank, int total, bool claimed); // 0x00000001807500D0-0x0000000180752010
	private PokyTooltipTarget AttachMilestoneTooltip(GameObject host, MilestoneGroupUI groupUI, MilestoneRewardData rewards); // 0x0000000180752010-0x0000000180752870
	private string FormatRewardAmount(int amount); // 0x0000000180752870-0x00000001807529E0
	private void OnClickClaimMonthlyMilestone(long milestoneId, MilestoneGroupUI groupUI); // 0x00000001807529E0-0x0000000180752F50
	private void OnClaimMonthlySuccess(ClaimMilestoneResponse response, MilestoneRewardData rewards, MilestoneGroupUI groupUI); // 0x0000000180752F50-0x00000001807530D0
	private void OnClickClaimLifetimeMilestone(long milestoneId, MilestoneGroupUI groupUI); // 0x00000001807530D0-0x0000000180753870
	private void OnClaimLifetimeSuccess(ClaimLifetimeMilestoneResponse response, MilestoneRewardData rewards, MilestoneGroupUI groupUI); // 0x0000000180753870-0x00000001807539F0
	private void OpenChestFx(MilestoneGroupUI groupUI); // 0x00000001807539F0-0x0000000180753BC0
	private static int TierOfChest(GameObject chest); // 0x0000000180753BC0-0x0000000180753EA0
	private void OnClaimError(string error); // 0x0000000180753EA0-0x0000000180753F20
	private string FormatCurrency(long amount); // 0x0000000180753F20-0x0000000180754090
	private string FormatCurrencyExact(long amount); // 0x0000000180754090-0x00000001807541A0
	private void EnsureSlotCapacity(List<MilestoneGroupUI> slots, int needed); // 0x00000001807541A0-0x0000000180754FE0
	private void SetUnusedSlotsVisible(List<MilestoneGroupUI> slots, int usedCount); // 0x0000000180754FE0-0x0000000180755380
	private void EnsureScrollable(RectTransform container, bool horizontal); // 0x0000000180755380-0x0000000180756230
	private void UnwrapScroll(RectTransform container, RectTransform wrapRT); // 0x0000000180756230-0x0000000180756560
	private static Transform SlotAnchor(MilestoneGroupUI ui); // 0x0000000180756560-0x00000001807567C0
	private static bool TryFindRowRoots(Transform anchorA, Transform anchorB, out Transform rootA, out Transform rootB); // 0x00000001807567C0-0x0000000180756CD0
	private static string PathTo(Transform root, Transform node); // 0x0000000180756CD0-0x0000000180757120
	private static Transform ResolveChild(Transform root, string path); // 0x0000000180757120-0x0000000180757240
	private static List<KeyValuePair<long, int>> ParseShards(string json); // 0x0000000180757240-0x0000000180757730
	private static void AddShardRewards(List<RewardData> rewardList, string shardsJson); // 0x0000000180757730-0x00000001807579E0
	private static void ApplyShardVisual(GameObject obj, RewardData reward); // 0x00000001807579E0-0x0000000180758410
}

