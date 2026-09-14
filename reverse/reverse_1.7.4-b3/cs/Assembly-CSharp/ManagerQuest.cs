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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class ManagerQuest : MonoBehaviour // TypeDefIndex: 1728
{
	// Fields
	public const string PANEL_KEY = "PanelQuest"; // Metadata: 0x005F0162
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
	private sealed class __c__DisplayClass61_0 // TypeDefIndex: 1729
	{
		// Fields
		public ManagerQuest __4__this; // 0x10
		public QuestData quest; // 0x18

		// Constructors
		public __c__DisplayClass61_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupQuestItem_b__0(); // 0x00000001808C8290-0x00000001808C8450
	}

	[CompilerGenerated]
	private sealed class _CheckQuestStatusOnce_d__59 : IEnumerator<object> // TypeDefIndex: 1730
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuest __4__this; // 0x20
		public int userId; // 0x28

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _CheckQuestStatusOnce_d__59(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001808C8450-0x00000001808C8660
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808C8660-0x00000001808C86A0
	}

	[CompilerGenerated]
	private sealed class _ClaimQuestCoroutine_d__76 : IEnumerator<object> // TypeDefIndex: 1731
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public int userId; // 0x20
		public long questId; // 0x28
		public ManagerQuest __4__this; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _ClaimQuestCoroutine_d__76(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001808C86A0-0x00000001808C8990
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808C8990-0x00000001808C89D0
	}

	[CompilerGenerated]
	private sealed class _LoadQuestsCoroutine_d__52 : IEnumerator<object> // TypeDefIndex: 1732
	{
		// Fields
		private int __1__state; // 0x10
		private object __2__current; // 0x18
		public ManagerQuest __4__this; // 0x20
		public int userId; // 0x28
		public string questType; // 0x30

		// Properties
		object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
		object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 

		// Constructors
		[DebuggerHidden]
		public _LoadQuestsCoroutine_d__52(int __1__state); // 0x000000018028E160-0x000000018028E170

		// Methods
		[DebuggerHidden]
		void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
		private bool MoveNext(); // 0x00000001808C89D0-0x00000001808C8BD0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808C8BD0-0x00000001808C8C10
	}

	// Constructors
	public ManagerQuest(); // 0x00000001808C7C70-0x00000001808C7E50

	// Methods
	private void OnDisable(); // 0x00000001808BEDB0-0x00000001808BEDD0
	private void Awake(); // 0x00000001808BEDD0-0x00000001808BF720
	private void SetupButtons(); // 0x00000001808BF720-0x00000001808BFB20
	public void OpenQuestPanel(); // 0x00000001808BFB20-0x00000001808BFD90
	public void CloseQuestPanel(); // 0x00000001808BFD90-0x00000001808C0000
	public void LoadQuests(string questType); // 0x00000001808C0000-0x00000001808C01E0
	private void HighlightSelectedTab(string questType); // 0x00000001808C01E0-0x00000001808C0B70
	private void ClearQuestList(); // 0x00000001808C0B70-0x00000001808C0F60
	[IteratorStateMachine(typeof(_LoadQuestsCoroutine_d__52))]
	private IEnumerator LoadQuestsCoroutine(int userId, string questType); // 0x00000001808C0F60-0x00000001808C1070
	private void CheckForCompletedQuests(List<QuestData> quests); // 0x00000001808C1070-0x00000001808C1440
	private void ShowQuestNotification(); // 0x00000001808C1440-0x00000001808C1590
	private void HideQuestNotification(); // 0x00000001808C1590-0x00000001808C16E0
	private void StartQuestButtonShake(); // 0x00000001808C16E0-0x00000001808C1A60
	private void StopQuestButtonShake(); // 0x00000001808C1A60-0x00000001808C1C40
	public void CheckQuestNotification(); // 0x00000001808C1C40-0x00000001808C1D30
	[IteratorStateMachine(typeof(_CheckQuestStatusOnce_d__59))]
	private IEnumerator CheckQuestStatusOnce(int userId); // 0x00000001808C1D30-0x00000001808C1DE0
	private void SpawnQuestItems(List<QuestData> quests); // 0x00000001808C1DE0-0x00000001808C2120
	private void SetupQuestItem(GameObject questObj, QuestData quest); // 0x00000001808C2120-0x00000001808C36A0
	private bool TryShowRewardChest(Transform imgRW, QuestData quest); // 0x00000001808C36A0-0x00000001808C39E0
	private void AttachQuestTooltip(GameObject questObj, QuestData quest); // 0x00000001808C39E0-0x00000001808C3D60
	private void AttachRewardTooltip(GameObject rewardObj, QuestRewardData reward); // 0x00000001808C3D60-0x00000001808C3F80
	private List<RewardDisplayHelper.Entry> BuildQuestEntries(List<QuestRewardData> rewards); // 0x00000001808C3F80-0x00000001808C4130
	private RewardDisplayHelper.Entry ToRewardEntry(QuestRewardData r); // 0x00000001808C4130-0x00000001808C4450
	private string StoneRewardLabel(QuestRewardData r); // 0x00000001808C4450-0x00000001808C46D0
	private void AnimateClaimButton(GameObject btnObj); // 0x00000001808C46D0-0x00000001808C4870
	private void SpawnRewardIcon(Transform container, QuestRewardData reward); // 0x00000001808C4870-0x00000001808C4E50
	private GameObject GetRewardPrefab(string rewardType); // 0x00000001808C4E50-0x00000001808C5520
	private void SetStoneSprite(GameObject rewardObj, long idStone, string stoneType); // 0x00000001808C5520-0x00000001808C6060
	private int GetStoneLevelFromId(long idStone); // 0x00000001808C6060-0x00000001808C6090
	private string GetStoneElementFromId(long idStone); // 0x00000001808C6090-0x00000001808C6240
	private void SetPetOrAvatarSprite(GameObject rewardObj, string rewardType, long itemId); // 0x00000001808C6240-0x00000001808C6560
	private void ClaimQuest(QuestData quest); // 0x00000001808C6560-0x00000001808C6710
	[IteratorStateMachine(typeof(_ClaimQuestCoroutine_d__76))]
	private IEnumerator ClaimQuestCoroutine(int userId, long questId); // 0x00000001808C6710-0x00000001808C67D0
	private void ShowRewardPopup(ClaimQuestResponse response); // 0x00000001808C67D0-0x00000001808C6DA0
	private void SpawnRewardInPopup(Transform container, QuestRewardData reward); // 0x00000001808C6DA0-0x00000001808C7340
	private void CloseRewardPopup(); // 0x00000001808C7340-0x00000001808C74A0
	private void UpdateUserData(UserUpdateData userData); // 0x00000001808C74A0-0x00000001808C78B0
	private string FormatVND(int value); // 0x00000001808C78B0-0x00000001808C79C0
	private UnityEngine.UI.Text FindTextComponent(Transform parent, string[] possibleNames); // 0x00000001808C79C0-0x00000001808C7C50
	private void OnDestroy(); // 0x00000001808C7C50-0x00000001808C7C70
	[CompilerGenerated]
	private void _SetupButtons_b__46_0(); // 0x00000001808C7E50-0x00000001808C7EA0
	[CompilerGenerated]
	private void _SetupButtons_b__46_1(); // 0x00000001808C7EA0-0x00000001808C7EF0
	[CompilerGenerated]
	private void _LoadQuestsCoroutine_b__52_0(QuestListResponse response); // 0x00000001808C7EF0-0x00000001808C7FC0
	[CompilerGenerated]
	private void _LoadQuestsCoroutine_b__52_1(string error); // 0x00000001808C7FC0-0x00000001808C8050
	[CompilerGenerated]
	private void _CheckQuestStatusOnce_b__59_0(QuestListResponse response); // 0x00000001808C8050-0x00000001808C8090
	[CompilerGenerated]
	private void _CheckQuestStatusOnce_b__59_1(string error); // 0x00000001808C8090-0x00000001808C8120
	[CompilerGenerated]
	private void _ClaimQuestCoroutine_b__76_0(ClaimQuestResponse response); // 0x00000001808C8120-0x00000001808C8200
	[CompilerGenerated]
	private void _ClaimQuestCoroutine_b__76_1(string error); // 0x00000001808C8200-0x00000001808C8290
}

