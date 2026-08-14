//Type is in global namespace

public class ManagerEvent : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<GameObject> <>9__52_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <OnSoxoClicked>b__52_0(GameObject panel) { }

	}

	[CompilerGenerated]
	private sealed class <CheckClaimStatusCoroutine>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerEvent <>4__this; //Field offset: 0x20

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
		public <CheckClaimStatusCoroutine>d__38(int <>1__state) { }

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
	private sealed class <ClaimRewardCoroutine>d__41 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerEvent <>4__this; //Field offset: 0x20

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
		public <ClaimRewardCoroutine>d__41(int <>1__state) { }

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

	public const string PANEL_KEY = "PanelEvent"; //Field offset: 0x0
	[Header("Panels")]
	public GameObject panelEvent; //Field offset: 0x20
	public GameObject panelResult; //Field offset: 0x28
	public GameObject panelPet; //Field offset: 0x30
	public GameObject panelAvt; //Field offset: 0x38
	[Header("Event UI")]
	public Button btnClaim; //Field offset: 0x40
	public Text txtInfo; //Field offset: 0x48
	[Header("Result UI")]
	public Transform listReward; //Field offset: 0x50
	public Button btnGet; //Field offset: 0x58
	public Text txtTitle; //Field offset: 0x60
	[Header("Navigation Buttons - PanelEvent")]
	public Button btnBackEvent; //Field offset: 0x68
	public Button btnPet; //Field offset: 0x70
	public Button btnAvt; //Field offset: 0x78
	public Button btnSoxo; //Field offset: 0x80
	[Header("Navigation Buttons - Sub Panels")]
	public Button btnBackPet; //Field offset: 0x88
	public Button btnBackAvt; //Field offset: 0x90
	[Header("Reward Prefabs")]
	public GameObject petRW; //Field offset: 0x98
	public GameObject avtRW; //Field offset: 0xA0
	public GameObject cardRW; //Field offset: 0xA8
	public GameObject stoneRW; //Field offset: 0xB0
	public GameObject goldRW; //Field offset: 0xB8
	public GameObject energyRW; //Field offset: 0xC0
	public GameObject redStarRW; //Field offset: 0xC8
	public GameObject whiteStarRW; //Field offset: 0xD0
	public GameObject blueStarRW; //Field offset: 0xD8
	public GameObject expRW; //Field offset: 0xE0
	public GameObject wheelRW; //Field offset: 0xE8
	public GameObject wheelDayRW; //Field offset: 0xF0
	public GameObject rubyRW; //Field offset: 0xF8
	public GameObject crystalRW; //Field offset: 0x100
	public GameObject eItem1RW; //Field offset: 0x108
	public GameObject eItem2RW; //Field offset: 0x110
	public GameObject eItem3RW; //Field offset: 0x118
	public GameObject eItem4RW; //Field offset: 0x120
	private int userId; //Field offset: 0x128
	private bool isClaiming; //Field offset: 0x12C

	public ManagerEvent() { }

	[CompilerGenerated]
	private void <CheckClaimStatusCoroutine>b__38_0(EventClaimResponseDTO response) { }

	[CompilerGenerated]
	private void <CheckClaimStatusCoroutine>b__38_1(string error) { }

	[CompilerGenerated]
	private void <ClaimRewardCoroutine>b__41_0(EventClaimResponseDTO response) { }

	[CompilerGenerated]
	private void <ClaimRewardCoroutine>b__41_1(string error) { }

	[CompilerGenerated]
	private void <OnGetRewardClicked>b__46_0() { }

	private void Awake() { }

	public void CheckClaimStatus() { }

	[IteratorStateMachine(typeof(<CheckClaimStatusCoroutine>d__38))]
	private IEnumerator CheckClaimStatusCoroutine() { }

	[IteratorStateMachine(typeof(<ClaimRewardCoroutine>d__41))]
	private IEnumerator ClaimRewardCoroutine() { }

	private string GetIconPath(string rewardType, long rewardId) { }

	private GameObject GetRewardPrefab(string rewardType) { }

	private void OnAvtClicked() { }

	private void OnBackAvtClicked() { }

	private void OnBackEventClicked() { }

	private void OnBackPetClicked() { }

	private void OnClaimClicked() { }

	private void OnGetRewardClicked() { }

	private void OnPetClicked() { }

	private void OnSoxoClicked() { }

	public void OpenEventPanel() { }

	private void SetupRewardUI(GameObject rewardObj, RewardItemDTO reward) { }

	private void ShowRewardResult(List<RewardItemDTO> rewards) { }

	private void UpdateClaimButton(bool canClaim, string message) { }

}

