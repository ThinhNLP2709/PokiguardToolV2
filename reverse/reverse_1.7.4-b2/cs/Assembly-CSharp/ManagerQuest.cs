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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class ManagerQuest : MonoBehaviour // TypeDefIndex: 1339
{
	// Fields
	public const string PANEL_KEY = "PanelQuest"; // Metadata: 0x0068CECE
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
	private sealed class __c__DisplayClass61_0 // TypeDefIndex: 1340
	{
		// Fields
		public ManagerQuest __4__this; // 0x10
		public QuestData quest; // 0x18

		// Constructors
		public __c__DisplayClass61_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _SetupQuestItem_b__0(); // 0x00000001805BE360-0x00000001805BE490
	}

	[CompilerGenerated]
	private sealed class _CheckQuestStatusOnce_d__59 : IEnumerator<object> // TypeDefIndex: 1341
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuest __4__this; // 0x20
		public int userId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _CheckQuestStatusOnce_d__59(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805B5E90-0x00000001805B6030
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B6030-0x00000001805B6070
	}

	[CompilerGenerated]
	private sealed class _ClaimQuestCoroutine_d__76 : IEnumerator<object> // TypeDefIndex: 1342
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public long questId; // 0x28
		public ManagerQuest __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _ClaimQuestCoroutine_d__76(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805B6070-0x00000001805B61F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B61F0-0x00000001805B6230
	}

	[CompilerGenerated]
	private sealed class _LoadQuestsCoroutine_d__52 : IEnumerator<object> // TypeDefIndex: 1343
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuest __4__this; // 0x20
		public int userId; // 0x28
		public string questType; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001803003B0-0x00000001803003C0 

		// Constructors
		[DebuggerHidden]
		public _LoadQuestsCoroutine_d__52(int __1__state); // 0x0000000180300530-0x0000000180300560

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x0000000180314A30-0x0000000180314A40
		private bool MoveNext(); // 0x00000001805B9B20-0x00000001805B9CB0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001805B9CB0-0x00000001805B9CF0
	}

	// Constructors
	public ManagerQuest(); // 0x00000001805B1870-0x00000001805B1980

	// Methods
	private void OnDisable(); // 0x00000001805AE0D0-0x00000001805AE0F0
	private void Awake(); // 0x00000001805AC550-0x00000001805AC860
	private void SetupButtons(); // 0x00000001805AE9F0-0x00000001805AEC00
	public void OpenQuestPanel(); // 0x00000001805AE0F0-0x00000001805AE1C0
	public void CloseQuestPanel(); // 0x00000001805AD140-0x00000001805AD2A0
	public void LoadQuests(string questType); // 0x00000001805ADFB0-0x00000001805AE0B0
	private void HighlightSelectedTab(string questType); // 0x00000001805ADB30-0x00000001805ADF10
	private void ClearQuestList(); // 0x00000001805ACEB0-0x00000001805AD140
	[IteratorStateMachine(typeof(_LoadQuestsCoroutine_d__52))]
	private IEnumerator LoadQuestsCoroutine(int userId, string questType); // 0x00000001805ADF10-0x00000001805ADFB0
	private void CheckForCompletedQuests(List<QuestData> quests); // 0x00000001805AC9C0-0x00000001805ACBC0
	private void ShowQuestNotification(); // 0x00000001805AFB60-0x00000001805AFBF0
	private void HideQuestNotification(); // 0x00000001805ADAA0-0x00000001805ADB30
	private void StartQuestButtonShake(); // 0x00000001805B0950-0x00000001805B0B70
	private void StopQuestButtonShake(); // 0x00000001805B0D40-0x00000001805B0E20
	public void CheckQuestNotification(); // 0x00000001805ACBC0-0x00000001805ACC80
	[IteratorStateMachine(typeof(_CheckQuestStatusOnce_d__59))]
	private IEnumerator CheckQuestStatusOnce(int userId); // 0x00000001805ACC80-0x00000001805ACD00
	private void SpawnQuestItems(List<QuestData> quests); // 0x00000001805B0010-0x00000001805B01F0
	private void SetupQuestItem(GameObject questObj, QuestData quest); // 0x00000001805AEC00-0x00000001805AFB60
	private bool TryShowRewardChest(Transform imgRW, QuestData quest); // 0x00000001805B1050-0x00000001805B1200
	private void AttachQuestTooltip(GameObject questObj, QuestData quest); // 0x00000001805AC160-0x00000001805AC410
	private void AttachRewardTooltip(GameObject rewardObj, QuestRewardData reward); // 0x00000001805AC410-0x00000001805AC550
	private List<RewardDisplayHelper.Entry> BuildQuestEntries(List<QuestRewardData> rewards); // 0x00000001805AC860-0x00000001805AC9C0
	private RewardDisplayHelper.Entry ToRewardEntry(QuestRewardData r); // 0x00000001805B0E20-0x00000001805B1050
	private string StoneRewardLabel(QuestRewardData r); // 0x00000001805B0B70-0x00000001805B0D40
	private void AnimateClaimButton(GameObject btnObj); // 0x00000001805AC0A0-0x00000001805AC160
	private void SpawnRewardIcon(Transform container, QuestRewardData reward); // 0x00000001805B01F0-0x00000001805B0640
	private GameObject GetRewardPrefab(string rewardType); // 0x00000001805AD4F0-0x00000001805AD930
	private void SetStoneSprite(GameObject rewardObj, long idStone, string stoneType); // 0x00000001805AE330-0x00000001805AE9F0
	private int GetStoneLevelFromId(long idStone); // 0x00000001805ADA70-0x00000001805ADAA0
	private string GetStoneElementFromId(long idStone); // 0x00000001805AD930-0x00000001805ADA70
	private void SetPetOrAvatarSprite(GameObject rewardObj, string rewardType, long itemId); // 0x00000001805AE1C0-0x00000001805AE330
	private void ClaimQuest(QuestData quest); // 0x00000001805ACD90-0x00000001805ACEB0
	[IteratorStateMachine(typeof(_ClaimQuestCoroutine_d__76))]
	private IEnumerator ClaimQuestCoroutine(int userId, long questId); // 0x00000001805ACD00-0x00000001805ACD90
	private void ShowRewardPopup(ClaimQuestResponse response); // 0x00000001805AFBF0-0x00000001805B0010
	private void SpawnRewardInPopup(Transform container, QuestRewardData reward); // 0x00000001805B0640-0x00000001805B0950
	private void CloseRewardPopup(); // 0x00000001805AD2A0-0x00000001805AD330
	private void UpdateUserData(UserUpdateData userData); // 0x00000001805B15E0-0x00000001805B1870
	private string FormatVND(int value); // 0x00000001805AD470-0x00000001805AD4F0
	private UnityEngine.UI.Text FindTextComponent(Transform parent, string[] possibleNames); // 0x00000001805AD330-0x00000001805AD470
	private void OnDestroy(); // 0x00000001805AE0B0-0x00000001805AE0D0
	[CompilerGenerated]
	private void _SetupButtons_b__46_0(); // 0x00000001805B1560-0x00000001805B15A0
	[CompilerGenerated]
	private void _SetupButtons_b__46_1(); // 0x00000001805B15A0-0x00000001805B15E0
	[CompilerGenerated]
	private void _LoadQuestsCoroutine_b__52_0(QuestListResponse response); // 0x00000001805B1460-0x00000001805B14E0
	[CompilerGenerated]
	private void _LoadQuestsCoroutine_b__52_1(string error); // 0x00000001805B14E0-0x00000001805B1560
	[CompilerGenerated]
	private void _CheckQuestStatusOnce_b__59_0(QuestListResponse response); // 0x00000001805B1200-0x00000001805B1240
	[CompilerGenerated]
	private void _CheckQuestStatusOnce_b__59_1(string error); // 0x00000001805B1240-0x00000001805B12C0
	[CompilerGenerated]
	private void _ClaimQuestCoroutine_b__76_0(ClaimQuestResponse response); // 0x00000001805B12C0-0x00000001805B13E0
	[CompilerGenerated]
	private void _ClaimQuestCoroutine_b__76_1(string error); // 0x00000001805B13E0-0x00000001805B1460
}

