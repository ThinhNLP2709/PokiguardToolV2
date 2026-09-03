/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class ManagerQuest : MonoBehaviour // TypeDefIndex: 1125
{
	// Fields
	public const string PANEL_KEY = "PanelQuest"; // Metadata: 0x0064D373
	[Header("Quest Panels")]
	public GameObject panelQuest; // 0x20
	public GameObject panelQuestList; // 0x28
	public GameObject panelRewardPopup; // 0x30
	[Header("Quest Buttons")]
	public Button btnQuest; // 0x38
	public Button btnBack; // 0x40
	public Button btnQuestDaily; // 0x48
	public Button btnBigQuest; // 0x50
	[Header("Quest Prefab")]
	public GameObject questPrefab; // 0x58
	public Transform listPanel; // 0x60
	[Header("Reward Prefabs")]
	public GameObject petRW; // 0x68
	public GameObject avtRW; // 0x70
	public GameObject cardRW; // 0x78
	public GameObject stoneRW; // 0x80
	public GameObject goldRW; // 0x88
	public GameObject energyRW; // 0x90
	public GameObject redStarRW; // 0x98
	public GameObject whiteStarRW; // 0xA0
	public GameObject blueStarRW; // 0xA8
	public GameObject expRW; // 0xB0
	public GameObject eItem1RW; // 0xB8
	public GameObject eItem2RW; // 0xC0
	public GameObject eItem3RW; // 0xC8
	public GameObject eItem4RW; // 0xD0
	public GameObject rubyRW; // 0xD8
	[Header("Reward Popup")]
	public Transform listRewardPopup; // 0xE0
	public Button btnConfirmReward; // 0xE8
	[Header("Tab Highlight Settings")]
	public Color normalTabColor; // 0xF0
	public Color selectedTabColor; // 0x100
	public float tabScaleNormal; // 0x110
	public float tabScaleSelected; // 0x114
	[Header("Quest Notification")]
	public GameObject questNotificationIcon; // 0x118
	public float shakeIntensity; // 0x120
	public float shakeDuration; // 0x124
	[Header("Quest Completed Color")]
	public Color completedQuestColor; // 0x128
	public Color normalQuestColor; // 0x138
	private string currentQuestType; // 0x148
	private bool isClaimingQuest; // 0x150
	private QuestData currentClaimingQuest; // 0x158
	private List<QuestData> currentQuests; // 0x160
	private Sequence shakeSequence; // 0x168
	private bool isLoadingQuests; // 0x170
	private bool isCheckingNotification; // 0x171
	public static ManagerQuest Instance; // 0x00

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass61_0 // TypeDefIndex: 1126
	{
		// Fields
		public ManagerQuest __4__this; // 0x10
		public QuestData quest; // 0x18

		// Constructors
		public __c__DisplayClass61_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _SetupQuestItem_b__0(); // 0x00000001804C3070-0x00000001804C31A0
	}

	[CompilerGenerated]
	private sealed class _CheckQuestStatusOnce_d__59 : IEnumerator<object> // TypeDefIndex: 1127
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuest __4__this; // 0x20
		public int userId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _CheckQuestStatusOnce_d__59(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804BA370-0x00000001804BA510
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BA510-0x00000001804BA550
	}

	[CompilerGenerated]
	private sealed class _ClaimQuestCoroutine_d__76 : IEnumerator<object> // TypeDefIndex: 1128
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public long questId; // 0x28
		public ManagerQuest __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _ClaimQuestCoroutine_d__76(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804BA550-0x00000001804BA6D0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BA6D0-0x00000001804BA710
	}

	[CompilerGenerated]
	private sealed class _LoadQuestsCoroutine_d__52 : IEnumerator<object> // TypeDefIndex: 1129
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuest __4__this; // 0x20
		public int userId; // 0x28
		public string questType; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 

		// Constructors
		[DebuggerHidden]
		public _LoadQuestsCoroutine_d__52(int __1__state); // 0x00000001802F9040-0x00000001802F9070

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
		private bool MoveNext(); // 0x00000001804BDA50-0x00000001804BDBE0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001804BDBE0-0x00000001804BDC20
	}

	// Constructors
	public ManagerQuest(); // 0x00000001804B54E0-0x00000001804B55F0

	// Methods
	private void OnDisable(); // 0x00000001804B1AF0-0x00000001804B1B10
	private void Awake(); // 0x00000001804AFF70-0x00000001804B0280
	private void SetupButtons(); // 0x00000001804B2410-0x00000001804B2620
	public void OpenQuestPanel(); // 0x00000001804B1B10-0x00000001804B1BE0
	public void CloseQuestPanel(); // 0x00000001804B0B60-0x00000001804B0CC0
	public void LoadQuests(string questType); // 0x00000001804B19D0-0x00000001804B1AD0
	private void HighlightSelectedTab(string questType); // 0x00000001804B1550-0x00000001804B1930
	private void ClearQuestList(); // 0x00000001804B08D0-0x00000001804B0B60
	[IteratorStateMachine(typeof(_LoadQuestsCoroutine_d__52))]
	private IEnumerator LoadQuestsCoroutine(int userId, string questType); // 0x00000001804B1930-0x00000001804B19D0
	private void CheckForCompletedQuests(List<QuestData> quests); // 0x00000001804B03E0-0x00000001804B05E0
	private void ShowQuestNotification(); // 0x00000001804B3580-0x00000001804B3610
	private void HideQuestNotification(); // 0x00000001804B14C0-0x00000001804B1550
	private void StartQuestButtonShake(); // 0x00000001804B4370-0x00000001804B4590
	private void StopQuestButtonShake(); // 0x00000001804B49D0-0x00000001804B4AB0
	public void CheckQuestNotification(); // 0x00000001804B05E0-0x00000001804B06A0
	[IteratorStateMachine(typeof(_CheckQuestStatusOnce_d__59))]
	private IEnumerator CheckQuestStatusOnce(int userId); // 0x00000001804B06A0-0x00000001804B0720
	private void SpawnQuestItems(List<QuestData> quests); // 0x00000001804B3A30-0x00000001804B3C10
	private void SetupQuestItem(GameObject questObj, QuestData quest); // 0x00000001804B2620-0x00000001804B3580
	private bool TryShowRewardChest(Transform imgRW, QuestData quest); // 0x00000001804B4CC0-0x00000001804B4E70
	private void AttachQuestTooltip(GameObject questObj, QuestData quest); // 0x00000001804AFB80-0x00000001804AFE30
	private void AttachRewardTooltip(GameObject rewardObj, QuestRewardData reward); // 0x00000001804AFE30-0x00000001804AFF70
	private List<RewardDisplayHelper.Entry> BuildQuestEntries(List<QuestRewardData> rewards); // 0x00000001804B0280-0x00000001804B03E0
	private RewardDisplayHelper.Entry ToRewardEntry(QuestRewardData r); // 0x00000001804B4AB0-0x00000001804B4CC0
	private string StoneRewardLabel(QuestRewardData r); // 0x00000001804B4590-0x00000001804B49D0
	private void AnimateClaimButton(GameObject btnObj); // 0x00000001804AFAC0-0x00000001804AFB80
	private void SpawnRewardIcon(Transform container, QuestRewardData reward); // 0x00000001804B3C10-0x00000001804B4060
	private GameObject GetRewardPrefab(string rewardType); // 0x00000001804B0F10-0x00000001804B1350
	private void SetStoneSprite(GameObject rewardObj, long idStone, string stoneType); // 0x00000001804B1D50-0x00000001804B2410
	private int GetStoneLevelFromId(long idStone); // 0x00000001804B1490-0x00000001804B14C0
	private string GetStoneElementFromId(long idStone); // 0x00000001804B1350-0x00000001804B1490
	private void SetPetOrAvatarSprite(GameObject rewardObj, string rewardType, long itemId); // 0x00000001804B1BE0-0x00000001804B1D50
	private void ClaimQuest(QuestData quest); // 0x00000001804B07B0-0x00000001804B08D0
	[IteratorStateMachine(typeof(_ClaimQuestCoroutine_d__76))]
	private IEnumerator ClaimQuestCoroutine(int userId, long questId); // 0x00000001804B0720-0x00000001804B07B0
	private void ShowRewardPopup(ClaimQuestResponse response); // 0x00000001804B3610-0x00000001804B3A30
	private void SpawnRewardInPopup(Transform container, QuestRewardData reward); // 0x00000001804B4060-0x00000001804B4370
	private void CloseRewardPopup(); // 0x00000001804B0CC0-0x00000001804B0D50
	private void UpdateUserData(UserUpdateData userData); // 0x00000001804B5250-0x00000001804B54E0
	private string FormatVND(int value); // 0x00000001804B0E90-0x00000001804B0F10
	private UnityEngine.UI.Text FindTextComponent(Transform parent, string[] possibleNames); // 0x00000001804B0D50-0x00000001804B0E90
	private void OnDestroy(); // 0x00000001804B1AD0-0x00000001804B1AF0
	[CompilerGenerated]
	private void _SetupButtons_b__46_0(); // 0x00000001804B51D0-0x00000001804B5210
	[CompilerGenerated]
	private void _SetupButtons_b__46_1(); // 0x00000001804B5210-0x00000001804B5250
	[CompilerGenerated]
	private void _LoadQuestsCoroutine_b__52_0(QuestListResponse response); // 0x00000001804B50D0-0x00000001804B5150
	[CompilerGenerated]
	private void _LoadQuestsCoroutine_b__52_1(string error); // 0x00000001804B5150-0x00000001804B51D0
	[CompilerGenerated]
	private void _CheckQuestStatusOnce_b__59_0(QuestListResponse response); // 0x00000001804B4E70-0x00000001804B4EB0
	[CompilerGenerated]
	private void _CheckQuestStatusOnce_b__59_1(string error); // 0x00000001804B4EB0-0x00000001804B4F30
	[CompilerGenerated]
	private void _ClaimQuestCoroutine_b__76_0(ClaimQuestResponse response); // 0x00000001804B4F30-0x00000001804B5050
	[CompilerGenerated]
	private void _ClaimQuestCoroutine_b__76_1(string error); // 0x00000001804B5050-0x00000001804B50D0
}

