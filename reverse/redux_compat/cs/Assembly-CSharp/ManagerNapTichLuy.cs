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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerNapTichLuy : MonoBehaviour // TypeDefIndex: 757
{
	// Fields
	public const string PANEL_KEY = "PanelNapTichLuy"; // Metadata: 0x0064C8F9
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

	// Nested types
	[Serializable]
	public class MilestoneGroupUI // TypeDefIndex: 758
	{
		// Fields
		public UnityEngine.UI.Text txtCount; // 0x10
		public GameObject point; // 0x18
		public Button btnGive; // 0x20
		public Transform rewardContainer; // 0x28
		public GameObject chest; // 0x30

		// Constructors
		public MilestoneGroupUI(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	private class RewardData // TypeDefIndex: 759
	{
		// Fields
		public string type; // 0x10
		public int amount; // 0x18
		public long id; // 0x20

		// Constructors
		public RewardData(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 760
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public LifetimeMilestoneStatusData milestone; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass52_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _UpdateLifetimeMilestoneGroup_b__0(); // 0x000000018040B360-0x000000018040B3A0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass53_0 // TypeDefIndex: 761
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public MilestoneStatusData milestone; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass53_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _UpdateMilestoneGroup_b__0(); // 0x000000018040B3A0-0x000000018040B3E0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass58_0 // TypeDefIndex: 762
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public MilestoneRewardData rewardsToShow; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass58_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnClickClaimMonthlyMilestone_b__0(ClaimMilestoneResponse response); // 0x000000018040B3E0-0x000000018040B4E0
		internal void _OnClickClaimMonthlyMilestone_b__1(string error); // 0x000000018040B4E0-0x000000018040B560
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass60_0 // TypeDefIndex: 763
	{
		// Fields
		public ManagerNapTichLuy __4__this; // 0x10
		public MilestoneRewardData rewardsToShow; // 0x18
		public MilestoneGroupUI groupUI; // 0x20

		// Constructors
		public __c__DisplayClass60_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _OnClickClaimLifetimeMilestone_b__0(ClaimLifetimeMilestoneResponse response); // 0x000000018040B560-0x000000018040B660
		internal void _OnClickClaimLifetimeMilestone_b__1(string error); // 0x000000018040B4E0-0x000000018040B560
	}

	// Constructors
	public ManagerNapTichLuy(); // 0x00000001803FAB70-0x00000001803FAC20

	// Methods
	private void Awake(); // 0x00000001803F2530-0x00000001803F2730
	private void Start(); // 0x00000001803F9200-0x00000001803F94E0
	private void ShowRewardResultPanel(MilestoneRewardData rewards); // 0x00000001803F77E0-0x00000001803F9130
	private void CloseGiftBoxPanel(); // 0x00000001803F2730-0x00000001803F27B0
	private void InitializeRewardPrefabs(); // 0x00000001803F58A0-0x00000001803F5D00
	private void HideLegacyNapNgayButton(); // 0x00000001803F57D0-0x00000001803F58A0
	public void OpenPanel(); // 0x00000001803F6D30-0x00000001803F6E40
	private void ClosePanel(); // 0x00000001803F27B0-0x00000001803F2910
	private void LoadMonthlyMilestoneData(); // 0x00000001803F5E40-0x00000001803F5F80
	private void OnLoadMonthlyDataSuccess(MonthlyMilestoneData data); // 0x00000001803F6AC0-0x00000001803F6B00
	private void OnLoadMonthlyDataError(string error); // 0x00000001803F6A50-0x00000001803F6AC0
	private void UpdateMonthlyUI(MonthlyMilestoneData data); // 0x00000001803FA7E0-0x00000001803FAB70
	private void LoadLifetimeMilestoneData(); // 0x00000001803F5D00-0x00000001803F5E40
	private void OnLoadLifetimeDataSuccess(LifetimeMilestoneData data); // 0x00000001803F6A10-0x00000001803F6A50
	private void OnLoadLifetimeDataError(string error); // 0x00000001803F69A0-0x00000001803F6A10
	private void UpdateLifetimeUI(LifetimeMilestoneData data); // 0x00000001803FA0B0-0x00000001803FA370
	private void ApplyScrollIfNeeded(List<MilestoneGroupUI> slots); // 0x00000001803F1A90-0x00000001803F1C80
	private void UpdateLifetimeMilestoneGroup(MilestoneGroupUI groupUI, LifetimeMilestoneStatusData milestone, int rank, int total); // 0x00000001803F99A0-0x00000001803FA0B0
	private void UpdateMilestoneGroup(MilestoneGroupUI groupUI, MilestoneStatusData milestone, bool isMonthly, int rank, int total); // 0x00000001803FA370-0x00000001803FA7E0
	private static GameObject ResolveChest(MilestoneGroupUI groupUI); // 0x00000001803F7460-0x00000001803F7590
	private void DisplayRewards(MilestoneRewardData rewards, MilestoneGroupUI groupUI, int rank, int total, bool claimed); // 0x00000001803F2910-0x00000001803F4420
	private PokyTooltipTarget AttachMilestoneTooltip(GameObject host, MilestoneGroupUI groupUI, MilestoneRewardData rewards); // 0x00000001803F20E0-0x00000001803F2530
	private string FormatRewardAmount(int amount); // 0x00000001803F5700-0x00000001803F57D0
	private void OnClickClaimMonthlyMilestone(long milestoneId, MilestoneGroupUI groupUI); // 0x00000001803F6690-0x00000001803F69A0
	private void OnClaimMonthlySuccess(ClaimMilestoneResponse response, MilestoneRewardData rewards, MilestoneGroupUI groupUI); // 0x00000001803F60E0-0x00000001803F61D0
	private void OnClickClaimLifetimeMilestone(long milestoneId, MilestoneGroupUI groupUI); // 0x00000001803F61D0-0x00000001803F6690
	private void OnClaimLifetimeSuccess(ClaimLifetimeMilestoneResponse response, MilestoneRewardData rewards, MilestoneGroupUI groupUI); // 0x00000001803F5FF0-0x00000001803F60E0
	private void OpenChestFx(MilestoneGroupUI groupUI); // 0x00000001803F6B00-0x00000001803F6D30
	private static int TierOfChest(GameObject chest); // 0x00000001803F94E0-0x00000001803F9640
	private void OnClaimError(string error); // 0x00000001803F5F80-0x00000001803F5FF0
	private string FormatCurrency(long amount); // 0x00000001803F5620-0x00000001803F5700
	private string FormatCurrencyExact(long amount); // 0x00000001803F55B0-0x00000001803F5620
	private void EnsureSlotCapacity(List<MilestoneGroupUI> slots, int needed); // 0x00000001803F4CA0-0x00000001803F55B0
	private void SetUnusedSlotsVisible(List<MilestoneGroupUI> slots, int usedCount); // 0x00000001803F7630-0x00000001803F77E0
	private void EnsureScrollable(RectTransform container, bool horizontal); // 0x00000001803F4420-0x00000001803F4CA0
	private void UnwrapScroll(RectTransform container, RectTransform wrapRT); // 0x00000001803F9850-0x00000001803F99A0
	private static Transform SlotAnchor(MilestoneGroupUI ui); // 0x00000001803F9130-0x00000001803F9200
	private static bool TryFindRowRoots(Transform anchorA, Transform anchorB, out Transform rootA, out Transform rootB); // 0x00000001803F9640-0x00000001803F9850
	private static string PathTo(Transform root, Transform node); // 0x00000001803F72D0-0x00000001803F7460
	private static Transform ResolveChild(Transform root, string path); // 0x00000001803F7590-0x00000001803F7630
	private static List<KeyValuePair<long, int>> ParseShards(string json); // 0x00000001803F6E40-0x00000001803F72D0
	private static void AddShardRewards(List<RewardData> rewardList, string shardsJson); // 0x00000001803F18E0-0x00000001803F1A90
	private static void ApplyShardVisual(GameObject obj, RewardData reward); // 0x00000001803F1C80-0x00000001803F20E0
}

