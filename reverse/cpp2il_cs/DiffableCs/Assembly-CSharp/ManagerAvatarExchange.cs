//Type is in global namespace

public class ManagerAvatarExchange : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__14_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <LoadExchangeListCoroutine>b__14_1(string error) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public ManagerAvatarExchange <>4__this; //Field offset: 0x10
		public AvatarExchangeItemDTO avatarData; //Field offset: 0x18

		public <>c__DisplayClass16_0() { }

		internal void <SetupGavt>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <ExchangeAvatarCoroutine>d__21 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerAvatarExchange <>4__this; //Field offset: 0x20
		public AvatarExchangeItemDTO avatarData; //Field offset: 0x28

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
		public <ExchangeAvatarCoroutine>d__21(int <>1__state) { }

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
	private sealed class <LoadExchangeListCoroutine>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerAvatarExchange <>4__this; //Field offset: 0x20

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
		public <LoadExchangeListCoroutine>d__14(int <>1__state) { }

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

	[Header("Panels")]
	public GameObject panelAvt; //Field offset: 0x20
	public GameObject panelResult; //Field offset: 0x28
	[Header("Avatar Groups - Theo hierarchy")]
	public GameObject Gavt; //Field offset: 0x30
	public GameObject Gavt1; //Field offset: 0x38
	public GameObject Gavt2; //Field offset: 0x40
	public GameObject Gavt3; //Field offset: 0x48
	[Header("Panel Result UI")]
	public Transform listRewardResult; //Field offset: 0x50
	public Button btnGetResult; //Field offset: 0x58
	public GameObject avatarRewardPrefab; //Field offset: 0x60
	private int userId; //Field offset: 0x68
	private List<AvatarExchangeItemDTO> exchangeList; //Field offset: 0x70
	private List<GameObject> gavtSlots; //Field offset: 0x78

	public ManagerAvatarExchange() { }

	[CompilerGenerated]
	private void <ExchangeAvatarCoroutine>b__21_0(EventClaimResponseDTO response) { }

	[CompilerGenerated]
	private void <ExchangeAvatarCoroutine>b__21_1(string error) { }

	[CompilerGenerated]
	private void <LoadExchangeListCoroutine>b__14_0(AvatarExchangeInfoDTO info) { }

	[CompilerGenerated]
	private void <OnGetResultClicked>b__27_0() { }

	private void Awake() { }

	private void DisplayAvatars() { }

	[IteratorStateMachine(typeof(<ExchangeAvatarCoroutine>d__21))]
	private IEnumerator ExchangeAvatarCoroutine(AvatarExchangeItemDTO avatarData) { }

	public void LoadExchangeList() { }

	[IteratorStateMachine(typeof(<LoadExchangeListCoroutine>d__14))]
	private IEnumerator LoadExchangeListCoroutine() { }

	private void OnExchangeClicked(AvatarExchangeItemDTO avatarData) { }

	private void OnGetResultClicked() { }

	public void OpenPanel() { }

	private void SetupAvatarImage(GameObject avtObj, AvatarExchangeItemDTO avatarData) { }

	private void SetupAvatarReward(GameObject rewardObj, long avatarId) { }

	private void SetupE3Display(GameObject e3Obj, int current, int required) { }

	private void SetupGavt(GameObject gavtObj, AvatarExchangeItemDTO avatarData) { }

	private void SetupItemDisplay(GameObject itemObj, long itemId, int current, int required) { }

	private void ShowErrorMessage(string error) { }

	private void ShowExchangeSuccess(List<RewardItemDTO> rewards) { }

	private void ShowInsufficientMessage(AvatarExchangeItemDTO avatarData) { }

	private void ShowMessage(string message) { }

}

