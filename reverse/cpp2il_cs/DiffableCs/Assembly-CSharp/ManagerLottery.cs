//Type is in global namespace

public class ManagerLottery : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass47_0
	{
		public int number; //Field offset: 0x10
		public ManagerLottery <>4__this; //Field offset: 0x18

		public <>c__DisplayClass47_0() { }

		internal void <GenerateNumbers>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass54_0
	{
		public ManagerLottery <>4__this; //Field offset: 0x10
		public int number; //Field offset: 0x18
		public bool useFree; //Field offset: 0x1C

		public <>c__DisplayClass54_0() { }

		internal void <SelectNumberCoroutine>b__0(SelectNumberResponseDTO response) { }

		internal void <SelectNumberCoroutine>b__1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <ClaimPrizesCoroutine>d__56 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerLottery <>4__this; //Field offset: 0x20

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
		public <ClaimPrizesCoroutine>d__56(int <>1__state) { }

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
	private sealed class <ClientCountdownCoroutine>d__45 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerLottery <>4__this; //Field offset: 0x20

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
		public <ClientCountdownCoroutine>d__45(int <>1__state) { }

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
	private sealed class <LoadLotteryDataCoroutine>d__39 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerLottery <>4__this; //Field offset: 0x20

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
		public <LoadLotteryDataCoroutine>d__39(int <>1__state) { }

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
	private sealed class <SelectNumberCoroutine>d__54 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerLottery <>4__this; //Field offset: 0x20
		public int number; //Field offset: 0x28
		public bool useFree; //Field offset: 0x2C

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
		public <SelectNumberCoroutine>d__54(int <>1__state) { }

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

	public const string PANEL_KEY = "PanelSoxo"; //Field offset: 0x0
	[Header("Panels")]
	public GameObject panelSoxo; //Field offset: 0x20
	public GameObject panelNum; //Field offset: 0x28
	public GameObject panelConfirm; //Field offset: 0x30
	public GameObject panelResult; //Field offset: 0x38
	public GameObject panelBlocked; //Field offset: 0x40
	[Header("Number Generation")]
	public GameObject numberPrefab; //Field offset: 0x48
	[Header("Main UI")]
	public Text txtNotice; //Field offset: 0x50
	public Text txtInfo; //Field offset: 0x58
	public Text txtHeader; //Field offset: 0x60
	public Button btnClaim; //Field offset: 0x68
	public Button btnBack; //Field offset: 0x70
	[Header("Blocked Panel UI")]
	public Text txtBlockedMessage; //Field offset: 0x78
	public Button btnCloseBlocked; //Field offset: 0x80
	[Header("Giải Thưởng (History)")]
	public Text txtDatetime; //Field offset: 0x88
	public Transform giaiContainer; //Field offset: 0x90
	public Text top1Text; //Field offset: 0x98
	public Text top2Text; //Field offset: 0xA0
	public Text top3Text; //Field offset: 0xA8
	[Header("Panel Confirm")]
	public Text txtMessageConfirm; //Field offset: 0xB0
	public Button btnOK; //Field offset: 0xB8
	public Button btnCancel; //Field offset: 0xC0
	[Header("Panel Result")]
	public Transform listRewardResult; //Field offset: 0xC8
	public Button btnGetResult; //Field offset: 0xD0
	public GameObject wheelRW; //Field offset: 0xD8
	public GameObject goldRW; //Field offset: 0xE0
	private int userId; //Field offset: 0xE8
	private LotteryInfoDTO currentInfo; //Field offset: 0xF0
	private int selectedNumber; //Field offset: 0xF8
	private bool needGold; //Field offset: 0xFC
	private List<GameObject> numberObjects; //Field offset: 0x100
	private DateTime nextDrawTime; //Field offset: 0x108
	private bool isCountdownRunning; //Field offset: 0x110
	private Coroutine countdownCoroutine; //Field offset: 0x118
	private bool canSelectNumbers; //Field offset: 0x120

	public ManagerLottery() { }

	[CompilerGenerated]
	private void <ClaimPrizesCoroutine>b__56_0(EventClaimResponseDTO response) { }

	[CompilerGenerated]
	private void <ClaimPrizesCoroutine>b__56_1(string error) { }

	[CompilerGenerated]
	private void <LoadLotteryDataCoroutine>b__39_0(LotteryInfoDTO info) { }

	[CompilerGenerated]
	private void <LoadLotteryDataCoroutine>b__39_1(string error) { }

	[CompilerGenerated]
	private void <OnCloseBlockedPanel>b__43_0() { }

	[CompilerGenerated]
	private void <OnGetResultClicked>b__58_0() { }

	private void CalculateNextDrawTime() { }

	private void CheckCanSelectNumbers() { }

	[IteratorStateMachine(typeof(<ClaimPrizesCoroutine>d__56))]
	private IEnumerator ClaimPrizesCoroutine() { }

	[IteratorStateMachine(typeof(<ClientCountdownCoroutine>d__45))]
	private IEnumerator ClientCountdownCoroutine() { }

	private static Transform FindDeep(Transform root, string name) { }

	private void GenerateNumbers() { }

	public void LoadLotteryData() { }

	[IteratorStateMachine(typeof(<LoadLotteryDataCoroutine>d__39))]
	private IEnumerator LoadLotteryDataCoroutine() { }

	private void OnBackClicked() { }

	private void OnClaimClicked() { }

	private void OnCloseBlockedPanel() { }

	private void OnConfirmCancel() { }

	private void OnConfirmOK() { }

	private void OnDestroy() { }

	private void OnGetResultClicked() { }

	private void OnNumberClicked(int number) { }

	public void OpenPanel() { }

	private void ResolveInternalRefs() { }

	private void SelectNumber(int number, bool useFree) { }

	[IteratorStateMachine(typeof(<SelectNumberCoroutine>d__54))]
	private IEnumerator SelectNumberCoroutine(int number, bool useFree) { }

	private void ShowBlockedPanel() { }

	private void ShowConfirm(string message) { }

	private void ShowError(string message) { }

	private void ShowPrizeResult(List<RewardItemDTO> rewards) { }

	private void Start() { }

	private void StartClientCountdown() { }

	private void UpdateSelectedNumbers() { }

	private void UpdateUI() { }

}

