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

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class ManagerQuest : MonoBehaviour // TypeDefIndex: 1730
{
	// Fields
	public const string PANEL_KEY = "PanelQuest"; // Metadata: 0x005F152F
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
	private sealed class __c__DisplayClass61_0 // TypeDefIndex: 1731
	{
		// Fields
		public ManagerQuest __4__this; // 0x10
		public QuestData quest; // 0x18

		// Constructors
		public __c__DisplayClass61_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SetupQuestItem_b__0(); // 0x00000001808CAD20-0x00000001808CAF00
	}

	[CompilerGenerated]
	private sealed class _CheckQuestStatusOnce_d__59 : IEnumerator<object> // TypeDefIndex: 1732
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808CAF00-0x00000001808CB130
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808CB130-0x00000001808CB170
	}

	[CompilerGenerated]
	private sealed class _ClaimQuestCoroutine_d__76 : IEnumerator<object> // TypeDefIndex: 1733
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808CB170-0x00000001808CB490
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808CB490-0x00000001808CB4D0
	}

	[CompilerGenerated]
	private sealed class _LoadQuestsCoroutine_d__52 : IEnumerator<object> // TypeDefIndex: 1734
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
		void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
		private bool MoveNext(); // 0x00000001808CB4D0-0x00000001808CB6F0
		[DebuggerHidden]
		void IEnumerator.Reset(); // 0x00000001808CB6F0-0x00000001808CB730
	}

	// Constructors
	public ManagerQuest(); // 0x00000001808CA6D0-0x00000001808CA8B0

	// Methods
	private void OnDisable(); // 0x00000001808C17F0-0x00000001808C1810
	private void Awake(); // 0x00000001808C1810-0x00000001808C2160
	private void SetupButtons(); // 0x00000001808C2160-0x00000001808C2560
	public void OpenQuestPanel(); // 0x00000001808C2560-0x00000001808C27D0
	public void CloseQuestPanel(); // 0x00000001808C27D0-0x00000001808C2A40
	public void LoadQuests(string questType); // 0x00000001808C2A40-0x00000001808C2C20
	private void HighlightSelectedTab(string questType); // 0x00000001808C2C20-0x00000001808C35B0
	private void ClearQuestList(); // 0x00000001808C35B0-0x00000001808C39A0
	[IteratorStateMachine(typeof(_LoadQuestsCoroutine_d__52))]
	private IEnumerator LoadQuestsCoroutine(int userId, string questType); // 0x00000001808C39A0-0x00000001808C3AB0
	private void CheckForCompletedQuests(List<QuestData> quests); // 0x00000001808C3AB0-0x00000001808C3E80
	private void ShowQuestNotification(); // 0x00000001808C3E80-0x00000001808C3FD0
	private void HideQuestNotification(); // 0x00000001808C3FD0-0x00000001808C4120
	private void StartQuestButtonShake(); // 0x00000001808C4120-0x00000001808C44A0
	private void StopQuestButtonShake(); // 0x00000001808C44A0-0x00000001808C4680
	public void CheckQuestNotification(); // 0x00000001808C4680-0x00000001808C4770
	[IteratorStateMachine(typeof(_CheckQuestStatusOnce_d__59))]
	private IEnumerator CheckQuestStatusOnce(int userId); // 0x00000001808C4770-0x00000001808C4820
	private void SpawnQuestItems(List<QuestData> quests); // 0x00000001808C4820-0x00000001808C4B60
	private void SetupQuestItem(GameObject questObj, QuestData quest); // 0x00000001808C4B60-0x00000001808C60E0
	private bool TryShowRewardChest(Transform imgRW, QuestData quest); // 0x00000001808C60E0-0x00000001808C6420
	private void AttachQuestTooltip(GameObject questObj, QuestData quest); // 0x00000001808C6420-0x00000001808C67A0
	private void AttachRewardTooltip(GameObject rewardObj, QuestRewardData reward); // 0x00000001808C67A0-0x00000001808C69C0
	private List<RewardDisplayHelper.Entry> BuildQuestEntries(List<QuestRewardData> rewards); // 0x00000001808C69C0-0x00000001808C6B70
	private RewardDisplayHelper.Entry ToRewardEntry(QuestRewardData r); // 0x00000001808C6B70-0x00000001808C6E90
	private string StoneRewardLabel(QuestRewardData r); // 0x00000001808C6E90-0x00000001808C7110
	private void AnimateClaimButton(GameObject btnObj); // 0x00000001808C7110-0x00000001808C72B0
	private void SpawnRewardIcon(Transform container, QuestRewardData reward); // 0x00000001808C72B0-0x00000001808C7890
	private GameObject GetRewardPrefab(string rewardType); // 0x00000001808C7890-0x00000001808C7F60
	private void SetStoneSprite(GameObject rewardObj, long idStone, string stoneType); // 0x00000001808C7F60-0x00000001808C8AA0
	private int GetStoneLevelFromId(long idStone); // 0x00000001808C8AA0-0x00000001808C8AD0
	private string GetStoneElementFromId(long idStone); // 0x00000001808C8AD0-0x00000001808C8C80
	private void SetPetOrAvatarSprite(GameObject rewardObj, string rewardType, long itemId); // 0x00000001808C8C80-0x00000001808C8FA0
	private void ClaimQuest(QuestData quest); // 0x00000001808C8FA0-0x00000001808C9170
	[IteratorStateMachine(typeof(_ClaimQuestCoroutine_d__76))]
	private IEnumerator ClaimQuestCoroutine(int userId, long questId); // 0x00000001808C9170-0x00000001808C9230
	private void ShowRewardPopup(ClaimQuestResponse response); // 0x00000001808C9230-0x00000001808C9800
	private void SpawnRewardInPopup(Transform container, QuestRewardData reward); // 0x00000001808C9800-0x00000001808C9DA0
	private void CloseRewardPopup(); // 0x00000001808C9DA0-0x00000001808C9F00
	private void UpdateUserData(UserUpdateData userData); // 0x00000001808C9F00-0x00000001808CA310
	private string FormatVND(int value); // 0x00000001808CA310-0x00000001808CA420
	private UnityEngine.UI.Text FindTextComponent(Transform parent, string[] possibleNames); // 0x00000001808CA420-0x00000001808CA6B0
	private void OnDestroy(); // 0x00000001808CA6B0-0x00000001808CA6D0
	[CompilerGenerated]
	private void _SetupButtons_b__46_0(); // 0x00000001808CA8B0-0x00000001808CA900
	[CompilerGenerated]
	private void _SetupButtons_b__46_1(); // 0x00000001808CA900-0x00000001808CA950
	[CompilerGenerated]
	private void _LoadQuestsCoroutine_b__52_0(QuestListResponse response); // 0x00000001808CA950-0x00000001808CAA20
	[CompilerGenerated]
	private void _LoadQuestsCoroutine_b__52_1(string error); // 0x00000001808CAA20-0x00000001808CAAB0
	[CompilerGenerated]
	private void _CheckQuestStatusOnce_b__59_0(QuestListResponse response); // 0x00000001808CAAB0-0x00000001808CAAF0
	[CompilerGenerated]
	private void _CheckQuestStatusOnce_b__59_1(string error); // 0x00000001808CAAF0-0x00000001808CAB80
	[CompilerGenerated]
	private void _ClaimQuestCoroutine_b__76_0(ClaimQuestResponse response); // 0x00000001808CAB80-0x00000001808CAC90
	[CompilerGenerated]
	private void _ClaimQuestCoroutine_b__76_1(string error); // 0x00000001808CAC90-0x00000001808CAD20
}

