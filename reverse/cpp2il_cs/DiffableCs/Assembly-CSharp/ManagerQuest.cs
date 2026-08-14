//Type is in global namespace

public class ManagerQuest : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass60_0
	{
		public ManagerQuest <>4__this; //Field offset: 0x10
		public QuestData quest; //Field offset: 0x18

		public <>c__DisplayClass60_0() { }

		internal void <SetupQuestItem>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <CheckQuestStatusOnce>d__58 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerQuest <>4__this; //Field offset: 0x20
		public int userId; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <CheckQuestStatusOnce>d__58(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <ClaimQuestCoroutine>d__69 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int userId; //Field offset: 0x20
		public long questId; //Field offset: 0x28
		public ManagerQuest <>4__this; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <ClaimQuestCoroutine>d__69(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <LoadQuestsCoroutine>d__51 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerQuest <>4__this; //Field offset: 0x20
		public int userId; //Field offset: 0x28
		public string questType; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 5
		}

		[DebuggerHidden]
		public <LoadQuestsCoroutine>d__51(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	public const string PANEL_KEY = "PanelQuest"; //Field offset: 0x0
	public static ManagerQuest Instance; //Field offset: 0x0
	[Header("Quest Panels")]
	public GameObject panelQuest; //Field offset: 0x20
	public GameObject panelQuestList; //Field offset: 0x28
	public GameObject panelRewardPopup; //Field offset: 0x30
	[Header("Quest Buttons")]
	public Button btnQuest; //Field offset: 0x38
	public Button btnBack; //Field offset: 0x40
	public Button btnQuestDaily; //Field offset: 0x48
	public Button btnBigQuest; //Field offset: 0x50
	[Header("Quest Prefab")]
	public GameObject questPrefab; //Field offset: 0x58
	public Transform listPanel; //Field offset: 0x60
	[Header("Reward Prefabs")]
	public GameObject petRW; //Field offset: 0x68
	public GameObject avtRW; //Field offset: 0x70
	public GameObject cardRW; //Field offset: 0x78
	public GameObject stoneRW; //Field offset: 0x80
	public GameObject goldRW; //Field offset: 0x88
	public GameObject energyRW; //Field offset: 0x90
	public GameObject redStarRW; //Field offset: 0x98
	public GameObject whiteStarRW; //Field offset: 0xA0
	public GameObject blueStarRW; //Field offset: 0xA8
	public GameObject expRW; //Field offset: 0xB0
	public GameObject eItem1RW; //Field offset: 0xB8
	public GameObject eItem2RW; //Field offset: 0xC0
	public GameObject eItem3RW; //Field offset: 0xC8
	public GameObject eItem4RW; //Field offset: 0xD0
	public GameObject rubyRW; //Field offset: 0xD8
	[Header("Reward Popup")]
	public Transform listRewardPopup; //Field offset: 0xE0
	public Button btnConfirmReward; //Field offset: 0xE8
	[Header("Tab Highlight Settings")]
	public Color normalTabColor; //Field offset: 0xF0
	public Color selectedTabColor; //Field offset: 0x100
	public float tabScaleNormal; //Field offset: 0x110
	public float tabScaleSelected; //Field offset: 0x114
	[Header("Quest Notification")]
	public GameObject questNotificationIcon; //Field offset: 0x118
	public float shakeIntensity; //Field offset: 0x120
	public float shakeDuration; //Field offset: 0x124
	[Header("Quest Completed Color")]
	public Color completedQuestColor; //Field offset: 0x128
	public Color normalQuestColor; //Field offset: 0x138
	private string currentQuestType; //Field offset: 0x148
	private bool isClaimingQuest; //Field offset: 0x150
	private QuestData currentClaimingQuest; //Field offset: 0x158
	private List<QuestData> currentQuests; //Field offset: 0x160
	private Sequence shakeSequence; //Field offset: 0x168
	private bool isLoadingQuests; //Field offset: 0x170
	private bool isCheckingNotification; //Field offset: 0x171

	public ManagerQuest() { }

	[CompilerGenerated]
	private void <CheckQuestStatusOnce>b__58_0(QuestListResponse response) { }

	[CompilerGenerated]
	private void <CheckQuestStatusOnce>b__58_1(string error) { }

	[CompilerGenerated]
	private void <ClaimQuestCoroutine>b__69_0(ClaimQuestResponse response) { }

	[CompilerGenerated]
	private void <ClaimQuestCoroutine>b__69_1(string error) { }

	[CompilerGenerated]
	private void <LoadQuestsCoroutine>b__51_0(QuestListResponse response) { }

	[CompilerGenerated]
	private void <LoadQuestsCoroutine>b__51_1(string error) { }

	[CompilerGenerated]
	private void <SetupButtons>b__45_0() { }

	[CompilerGenerated]
	private void <SetupButtons>b__45_1() { }

	private void AnimateClaimButton(GameObject btnObj) { }

	private void Awake() { }

	private void CheckForCompletedQuests(List<QuestData> quests) { }

	public void CheckQuestNotification() { }

	[IteratorStateMachine(typeof(<CheckQuestStatusOnce>d__58))]
	private IEnumerator CheckQuestStatusOnce(int userId) { }

	private void ClaimQuest(QuestData quest) { }

	[IteratorStateMachine(typeof(<ClaimQuestCoroutine>d__69))]
	private IEnumerator ClaimQuestCoroutine(int userId, long questId) { }

	private void ClearQuestList() { }

	public void CloseQuestPanel() { }

	private void CloseRewardPopup() { }

	private Text FindTextComponent(Transform parent, String[] possibleNames) { }

	private string FormatVND(int value) { }

	private GameObject GetRewardPrefab(string rewardType) { }

	private string GetStoneElementFromId(long idStone) { }

	private int GetStoneLevelFromId(long idStone) { }

	private void HideQuestNotification() { }

	private void HighlightSelectedTab(string questType) { }

	public void LoadQuests(string questType) { }

	[IteratorStateMachine(typeof(<LoadQuestsCoroutine>d__51))]
	private IEnumerator LoadQuestsCoroutine(int userId, string questType) { }

	private void OnDestroy() { }

	public void OpenQuestPanel() { }

	private void SetPetOrAvatarSprite(GameObject rewardObj, string rewardType, long itemId) { }

	private void SetStoneSprite(GameObject rewardObj, long idStone, string stoneType) { }

	private void SetupButtons() { }

	private void SetupQuestItem(GameObject questObj, QuestData quest) { }

	private void ShowQuestNotification() { }

	private void ShowRewardPopup(ClaimQuestResponse response) { }

	private void SpawnQuestItems(List<QuestData> quests) { }

	private void SpawnRewardIcon(Transform container, QuestRewardData reward) { }

	private void SpawnRewardInPopup(Transform container, QuestRewardData reward) { }

	private void StartQuestButtonShake() { }

	private void StopQuestButtonShake() { }

	private void UpdateUserData(UserUpdateData userData) { }

}

