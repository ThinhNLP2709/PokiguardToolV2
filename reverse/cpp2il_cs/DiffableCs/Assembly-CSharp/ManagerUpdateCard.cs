//Type is in global namespace

public class ManagerUpdateCard : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass33_0
	{
		public CardDTO captured; //Field offset: 0x10
		public ManagerUpdateCard <>4__this; //Field offset: 0x18

		public <>c__DisplayClass33_0() { }

		internal void <RenderCardList>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass41_0
	{
		public CardUpgradeResponseDTO response; //Field offset: 0x10
		public bool apiDone; //Field offset: 0x18
		public string errorMsg; //Field offset: 0x20

		public <>c__DisplayClass41_0() { }

		internal void <UpgradeCardAPI>b__0(CardUpgradeResponseDTO res) { }

		internal void <UpgradeCardAPI>b__1(string err) { }

	}

	[CompilerGenerated]
	private sealed class <AnimateTextFlyUp>d__52 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Text textComponent; //Field offset: 0x20
		public float moveDistance; //Field offset: 0x28
		public float duration; //Field offset: 0x2C
		private Vector3 <startPos>5__2; //Field offset: 0x30
		private Vector3 <targetPos>5__3; //Field offset: 0x3C
		private float <elapsed>5__4; //Field offset: 0x48
		private Color <originalColor>5__5; //Field offset: 0x4C

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
		public <AnimateTextFlyUp>d__52(int <>1__state) { }

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
	private sealed class <HideResultAfterDelay>d__51 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float delay; //Field offset: 0x20
		public ManagerUpdateCard <>4__this; //Field offset: 0x28

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
		public <HideResultAfterDelay>d__51(int <>1__state) { }

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
	private sealed class <LoadAllData>d__31 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int userId; //Field offset: 0x20
		public ManagerUpdateCard <>4__this; //Field offset: 0x28
		private IEnumerator <cardsRequest>5__2; //Field offset: 0x30

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
		public <LoadAllData>d__31(int <>1__state) { }

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
	private sealed class <ReloadDataAfterUpgrade>d__46 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerUpdateCard <>4__this; //Field offset: 0x20
		private IEnumerator <cardsRequest>5__2; //Field offset: 0x28

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
		public <ReloadDataAfterUpgrade>d__46(int <>1__state) { }

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
	private sealed class <UpgradeCardAPI>d__41 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public CardUpgradeRequestDTO request; //Field offset: 0x20
		private <>c__DisplayClass41_0 <>8__1; //Field offset: 0x28
		public ManagerUpdateCard <>4__this; //Field offset: 0x30

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
		public <UpgradeCardAPI>d__41(int <>1__state) { }

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
	private sealed class <WaitForAnimationThenShowResult>d__43 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerUpdateCard <>4__this; //Field offset: 0x20
		public CardUpgradeResponseDTO response; //Field offset: 0x28

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
		public <WaitForAnimationThenShowResult>d__43(int <>1__state) { }

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

	internal class CardDTO
	{
		public long id; //Field offset: 0x10
		public long cardId; //Field offset: 0x18
		public string name; //Field offset: 0x20
		public string description; //Field offset: 0x28
		public string elementTypeCard; //Field offset: 0x30
		public int value; //Field offset: 0x38
		public int count; //Field offset: 0x3C
		public int level; //Field offset: 0x40
		public long conditionUse; //Field offset: 0x48
		public int conditionStone; //Field offset: 0x50
		public int currentStone; //Field offset: 0x54
		public double upgradeRate; //Field offset: 0x58
		public int upgradeCost; //Field offset: 0x60

		public CardDTO() { }

	}

	internal class CardUpgradeRequestDTO
	{
		public long userId; //Field offset: 0x10
		public long userCardId; //Field offset: 0x18
		public bool useGold; //Field offset: 0x20

		public CardUpgradeRequestDTO() { }

	}

	internal class CardUpgradeResponseDTO
	{
		public bool success; //Field offset: 0x10
		public string message; //Field offset: 0x18
		public int newLevel; //Field offset: 0x20
		public bool upgraded; //Field offset: 0x24

		public CardUpgradeResponseDTO() { }

	}

	internal class UserDTO
	{
		public int id; //Field offset: 0x10
		public int gold; //Field offset: 0x14

		public UserDTO() { }

	}

	public const string PANEL_KEY = "PanelUpdateCard"; //Field offset: 0x0
	[Header("Panel References")]
	public GameObject panelUpdateCard; //Field offset: 0x20
	[Header("PanelCard - Danh sách card")]
	public Transform panelCardContainer; //Field offset: 0x28
	public GameObject btnCardPrefab; //Field offset: 0x30
	[Header("PanelUpdate - Slot đá điều kiện")]
	public Transform updateSlotsContainer; //Field offset: 0x38
	[Header("Set - Thông tin card được chọn")]
	public Image stoneMain; //Field offset: 0x40
	public Text txtPercent; //Field offset: 0x48
	public Text txtResultUpdate; //Field offset: 0x50
	public Text txtLv; //Field offset: 0x58
	public Text txtDame; //Field offset: 0x60
	public Text goldnl; //Field offset: 0x68
	[Header("Action")]
	public Button btnUpdate; //Field offset: 0x70
	public Toggle toggleB; //Field offset: 0x78
	public Text messagetxt; //Field offset: 0x80
	public GameObject anmtUpdateCard; //Field offset: 0x88
	public Button btnBack; //Field offset: 0x90
	private List<CardDTO> userCards; //Field offset: 0x98
	private CardDTO selectedCard; //Field offset: 0xA0
	private UserDTO currentUser; //Field offset: 0xA8
	private bool isProcessingUpgrade; //Field offset: 0xB0
	private Color originalResultColor; //Field offset: 0xB4

	public ManagerUpdateCard() { }

	[CompilerGenerated]
	private void <LoadAllData>b__31_0(UserDTO user) { }

	[CompilerGenerated]
	private void <ReloadDataAfterUpgrade>b__46_0(UserDTO user) { }

	[CompilerGenerated]
	private void <ReloadDataAfterUpgrade>b__46_1(List<CardDTO> cards) { }

	[CompilerGenerated]
	private bool <ReloadDataAfterUpgrade>b__46_2(CardDTO c) { }

	[IteratorStateMachine(typeof(<AnimateTextFlyUp>d__52))]
	private IEnumerator AnimateTextFlyUp(Text textComponent, float duration = 1, float moveDistance = 80) { }

	private int CalculateDame(CardDTO card) { }

	public void ClosePanel() { }

	public static string FormatVND(long amount) { }

	private void HandleUpgradeResult(CardUpgradeResponseDTO response) { }

	private void HideMessage() { }

	[IteratorStateMachine(typeof(<HideResultAfterDelay>d__51))]
	private IEnumerator HideResultAfterDelay(float delay) { }

	[IteratorStateMachine(typeof(<LoadAllData>d__31))]
	private IEnumerator LoadAllData(int userId) { }

	private Sprite LoadCardSprite(long cardId) { }

	private void LoadData() { }

	private void OnCardsReceived(List<CardDTO> cards) { }

	private void OnError(string error) { }

	private void OnToggleBChanged(bool isOn) { }

	private void OnUpgradeButtonClicked() { }

	private void OnUpgradeError(string error) { }

	private void OnUpgradeSuccess(CardUpgradeResponseDTO response) { }

	public void OpenPanel() { }

	[IteratorStateMachine(typeof(<ReloadDataAfterUpgrade>d__46))]
	private IEnumerator ReloadDataAfterUpgrade() { }

	private void RenderCardList() { }

	private void SelectCard(CardDTO card) { }

	private void SetSetPanelVisible(bool visible) { }

	private void SetupButtons() { }

	private void SetupInitialStates() { }

	private void ShowMessage(string msg) { }

	private void ShowResult(string msg, Color color) { }

	private void Start() { }

	private void UpdateStoneSlotUI(CardDTO card) { }

	[IteratorStateMachine(typeof(<UpgradeCardAPI>d__41))]
	private IEnumerator UpgradeCardAPI(CardUpgradeRequestDTO request) { }

	[IteratorStateMachine(typeof(<WaitForAnimationThenShowResult>d__43))]
	private IEnumerator WaitForAnimationThenShowResult(CardUpgradeResponseDTO response) { }

}

