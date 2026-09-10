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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerNapTichLuy : MonoBehaviour // TypeDefIndex: 947
{
	// Fields
	public const string PANEL_KEY = "PanelNapTichLuy"; // Metadata: 0x0068BFB9
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
	private const string NAP_SLOT_NAME = "btnNapNgay"; // Metadata: 0x0068BFC9
	private const string NAP_LABEL = "N\u1EA0P"; // Metadata: 0x0068BFD4
	private Button btnNap; // 0x130

	// Nested types
	[Serializable]
	public class MilestoneGroupUI // TypeDefIndex: 948
	{
		// Fields
		public UnityEngine.UI.Text txtCount; // 0x10
		public GameObject point; // 0x18
		public Button btnGive; // 0x20
		public Transform rewardContainer; // 0x28
		public GameObject chest; // 0x30

		// Constructors
		public MilestoneGroupUI(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	private class RewardData // TypeDefIndex: 949
	{
		// Fields
		public string type; // 0x10
		public int amount; // 0x18
		public long id; // 0x20

		// Constructors
		public RewardData(); // 0x00000001802E9CB0-0x00000001802E9CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass61_0 // TypeDefIndex: 950
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public LifetimeMilestoneStatusData milestone; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass61_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _UpdateLifetimeMilestoneGroup_b__0(); // 0x00000001804F8AE0-0x00000001804F8B20
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass62_0 // TypeDefIndex: 951
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public MilestoneStatusData milestone; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass62_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _UpdateMilestoneGroup_b__0(); // 0x00000001804F8B20-0x00000001804F8B60
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass67_0 // TypeDefIndex: 952
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public MilestoneRewardData rewardsToShow; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass67_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnClickClaimMonthlyMilestone_b__0(ClaimMilestoneResponse response); // 0x00000001804F8B60-0x00000001804F8BA0
		internal void _OnClickClaimMonthlyMilestone_b__1(string error); // 0x00000001804F8BA0-0x00000001804F8BC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass69_0 // TypeDefIndex: 953
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public MilestoneRewardData rewardsToShow; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass69_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _OnClickClaimLifetimeMilestone_b__0(ClaimLifetimeMilestoneResponse response); // 0x00000001804F8BC0-0x00000001804F8C00
		internal void _OnClickClaimLifetimeMilestone_b__1(string error); // 0x00000001804F8BA0-0x00000001804F8BC0
	}

	// Constructors
	public ManagerNapTichLuy(); // 0x00000001804D3860-0x00000001804D3910

	// Methods
	private void Awake(); // 0x00000001804CA560-0x00000001804CA760
	private void Start(); // 0x00000001804D1FA0-0x00000001804D21D0
	private void ShowRewardResultPanel(MilestoneRewardData rewards); // 0x00000001804D04C0-0x00000001804D1ED0
	private void CloseGiftBoxPanel(); // 0x00000001804CA760-0x00000001804CA7E0
	private void InitializeRewardPrefabs(); // 0x00000001804CDAE0-0x00000001804CDF40
	private void SetupNapButton(); // 0x00000001804CFD40-0x00000001804D04C0
	private Button FindClaimButtonSample(); // 0x00000001804CD670-0x00000001804CD8C0
	private void SetNapButtonLabel(GameObject button); // 0x00000001804CFA20-0x00000001804CFB90
	private void OpenRecharge(); // 0x00000001804CF1A0-0x00000001804CF230
	private void OnEnable(); // 0x00000001804CEC50-0x00000001804CECC0
	private void OnDisable(); // 0x00000001804CEBE0-0x00000001804CEC50
	private void OnRechargeOk(int safiaAdded, int newBalance); // 0x00000001804CEE20-0x00000001804CEE60
	public void OpenPanel(); // 0x00000001804CF090-0x00000001804CF1A0
	private void ClosePanel(); // 0x00000001804CA7E0-0x00000001804CA940
	private void LoadMonthlyMilestoneData(); // 0x00000001804CE080-0x00000001804CE1C0
	private void OnLoadMonthlyDataSuccess(MonthlyMilestoneData data); // 0x00000001804CEDE0-0x00000001804CEE20
	private void OnLoadMonthlyDataError(string error); // 0x00000001804CED70-0x00000001804CEDE0
	private void UpdateMonthlyUI(MonthlyMilestoneData data); // 0x00000001804D34D0-0x00000001804D3860
	private void LoadLifetimeMilestoneData(); // 0x00000001804CDF40-0x00000001804CE080
	private void OnLoadLifetimeDataSuccess(LifetimeMilestoneData data); // 0x00000001804CED30-0x00000001804CED70
	private void OnLoadLifetimeDataError(string error); // 0x00000001804CECC0-0x00000001804CED30
	private void UpdateLifetimeUI(LifetimeMilestoneData data); // 0x00000001804D2DA0-0x00000001804D3060
	private void ApplyScrollIfNeeded(List<MilestoneGroupUI> slots); // 0x00000001804C99B0-0x00000001804C9BA0
	private void UpdateLifetimeMilestoneGroup(MilestoneGroupUI groupUI, LifetimeMilestoneStatusData milestone, int rank, int total); // 0x00000001804D2690-0x00000001804D2DA0
	private void UpdateMilestoneGroup(MilestoneGroupUI groupUI, MilestoneStatusData milestone, bool isMonthly, int rank, int total); // 0x00000001804D3060-0x00000001804D34D0
	private static GameObject ResolveChest(MilestoneGroupUI groupUI); // 0x00000001804CF850-0x00000001804CF980
	private void DisplayRewards(MilestoneRewardData rewards, MilestoneGroupUI groupUI, int rank, int total, bool claimed); // 0x00000001804CA940-0x00000001804CC4E0
	private PokyTooltipTarget AttachMilestoneTooltip(GameObject host, MilestoneGroupUI groupUI, MilestoneRewardData rewards); // 0x00000001804CA000-0x00000001804CA560
	private string FormatRewardAmount(int amount); // 0x00000001804CDA10-0x00000001804CDAE0
	private void OnClickClaimMonthlyMilestone(long milestoneId, MilestoneGroupUI groupUI); // 0x00000001804CE8D0-0x00000001804CEBE0
	private void OnClaimMonthlySuccess(ClaimMilestoneResponse response, MilestoneRewardData rewards, MilestoneGroupUI groupUI); // 0x00000001804CE320-0x00000001804CE410
	private void OnClickClaimLifetimeMilestone(long milestoneId, MilestoneGroupUI groupUI); // 0x00000001804CE410-0x00000001804CE8D0
	private void OnClaimLifetimeSuccess(ClaimLifetimeMilestoneResponse response, MilestoneRewardData rewards, MilestoneGroupUI groupUI); // 0x00000001804CE230-0x00000001804CE320
	private void OpenChestFx(MilestoneGroupUI groupUI); // 0x00000001804CEE60-0x00000001804CF090
	private static int TierOfChest(GameObject chest); // 0x00000001804D21D0-0x00000001804D2330
	private void OnClaimError(string error); // 0x00000001804CE1C0-0x00000001804CE230
	private string FormatCurrency(long amount); // 0x00000001804CD930-0x00000001804CDA10
	private string FormatCurrencyExact(long amount); // 0x00000001804CD8C0-0x00000001804CD930
	private void EnsureSlotCapacity(List<MilestoneGroupUI> slots, int needed); // 0x00000001804CCD60-0x00000001804CD670
	private void SetUnusedSlotsVisible(List<MilestoneGroupUI> slots, int usedCount); // 0x00000001804CFB90-0x00000001804CFD40
	private void EnsureScrollable(RectTransform container, bool horizontal); // 0x00000001804CC4E0-0x00000001804CCD60
	private void UnwrapScroll(RectTransform container, RectTransform wrapRT); // 0x00000001804D2540-0x00000001804D2690
	private static Transform SlotAnchor(MilestoneGroupUI ui); // 0x00000001804D1ED0-0x00000001804D1FA0
	private static bool TryFindRowRoots(Transform anchorA, Transform anchorB, out Transform rootA, out Transform rootB); // 0x00000001804D2330-0x00000001804D2540
	private static string PathTo(Transform root, Transform node); // 0x00000001804CF6C0-0x00000001804CF850
	private static Transform ResolveChild(Transform root, string path); // 0x00000001804CF980-0x00000001804CFA20
	private static List<KeyValuePair<long, int>> ParseShards(string json); // 0x00000001804CF230-0x00000001804CF6C0
	private static void AddShardRewards(List<RewardData> rewardList, string shardsJson); // 0x00000001804C9800-0x00000001804C99B0
	private static void ApplyShardVisual(GameObject obj, RewardData reward); // 0x00000001804C9BA0-0x00000001804CA000
}

