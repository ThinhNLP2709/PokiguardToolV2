namespace Poki.Assets.Script.Boss.xephang;

public class ManagerXepHangBoss : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public Text target; //Field offset: 0x10
		public int value; //Field offset: 0x18

		public <>c__DisplayClass35_0() { }

		internal void <AnimateNumber>b__0(float v) { }

		internal void <AnimateNumber>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <RefreshUserInfoSilently>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerXepHangBoss <>4__this; //Field offset: 0x20

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
		public <RefreshUserInfoSilently>d__38(int <>1__state) { }

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
	private sealed class <UpdateStatusLabelLoop>d__27 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerXepHangBoss <>4__this; //Field offset: 0x20
		private long <clockOffsetMs>5__2; //Field offset: 0x28

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
		public <UpdateStatusLabelLoop>d__27(int <>1__state) { }

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

	[Header("UI References")]
	public GameObject panelXepHang; //Field offset: 0x20
	public Button btnClose; //Field offset: 0x28
	public Button btnNhanQua; //Field offset: 0x30
	[Header("Top Players Panel")]
	public Transform panelTop; //Field offset: 0x38
	public GameObject topItemPrefab; //Field offset: 0x40
	[Header("Your Result Panel")]
	public GameObject panelYourResult; //Field offset: 0x48
	public Image imgPet; //Field offset: 0x50
	public Image imgBoss; //Field offset: 0x58
	public Text txtName; //Field offset: 0x60
	public Text txtDame; //Field offset: 0x68
	public Text txtYourTop; //Field offset: 0x70
	[Header("Boss Info")]
	public Text txtBossName; //Field offset: 0x78
	[Header("Notice Panel")]
	public GameObject panelNotice; //Field offset: 0x80
	public Button btnGet; //Field offset: 0x88
	public Text txtMessage; //Field offset: 0x90
	private BossRankingResponseDTO currentRanking; //Field offset: 0x98
	private int currentUserId; //Field offset: 0xA0
	private long currentBossScheduleId; //Field offset: 0xA8
	private bool _loading; //Field offset: 0xB0
	private string _bossNameBase; //Field offset: 0xB8
	private Coroutine _statusCo; //Field offset: 0xC0

	public ManagerXepHangBoss() { }

	private void AnimateNumber(Text target, int value) { }

	private void ClaimReward() { }

	private void CloseNotice() { }

	public void ClosePanel() { }

	private void DisplayCurrentPlayer(BossRankingPlayerDTO currentPlayer) { }

	private void DisplayTopPlayers(List<BossRankingPlayerDTO> topPlayers) { }

	private static string FormatDuration(long ms) { }

	private void HideAllPanels() { }

	private void HideCurrentPlayer() { }

	private void HideTopPlayers() { }

	private void LoadBossAvatar(Image imgBoss, long bossId) { }

	private void LoadPetAvatar(Image imgPet, long petId) { }

	private void LoadRankingData() { }

	private static long NowMs() { }

	private void OnClaimError(string error) { }

	private void OnDisable() { }

	private void OnError(string error) { }

	private void OnRankingReceived(BossRankingResponseDTO ranking) { }

	private void OnRefreshError(string error) { }

	private void OnRewardClaimed(ClaimRewardResponseDTO response) { }

	private void OnUserInfoRefreshed(UserDTO user) { }

	public void OpenPanel() { }

	[IteratorStateMachine(typeof(<RefreshUserInfoSilently>d__38))]
	private IEnumerator RefreshUserInfoSilently() { }

	private void SetupTopItemManually(GameObject itemObj, BossRankingPlayerDTO player) { }

	private void ShowNotice(string message) { }

	private void Start() { }

	[IteratorStateMachine(typeof(<UpdateStatusLabelLoop>d__27))]
	private IEnumerator UpdateStatusLabelLoop() { }

}

