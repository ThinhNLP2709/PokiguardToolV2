//Type is in global namespace

public class GiftCodePanelController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <CloseAfterDelay>d__21 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float delay; //Field offset: 0x20
		public GiftCodePanelController <>4__this; //Field offset: 0x28

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
		public <CloseAfterDelay>d__21(int <>1__state) { }

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
	private sealed class <RedeemGiftCode>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GiftCodePanelController <>4__this; //Field offset: 0x20
		public string code; //Field offset: 0x28

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
		public <RedeemGiftCode>d__18(int <>1__state) { }

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

	public const string PANEL_KEY = "PanelGiftCode"; //Field offset: 0x0
	[Header("UI References")]
	public GameObject giftCodePanel; //Field offset: 0x20
	public Button openButton; //Field offset: 0x28
	[SerializeField]
	private Button closeButton; //Field offset: 0x30
	[SerializeField]
	private InputField codeInputField; //Field offset: 0x38
	[SerializeField]
	private Button redeemButton; //Field offset: 0x40
	[SerializeField]
	private Text messageText; //Field offset: 0x48
	[Header("Animation Settings")]
	[SerializeField]
	private float animationDuration; //Field offset: 0x50
	[SerializeField]
	private LeanTweenType easeType; //Field offset: 0x54
	private CanvasGroup canvasGroup; //Field offset: 0x58
	private bool isAnimating; //Field offset: 0x60
	private bool isProcessing; //Field offset: 0x61
	[Header("Panel Notice")]
	public GameObject panelNotice; //Field offset: 0x68
	public Text txtNoticeMessage; //Field offset: 0x70

	public GiftCodePanelController() { }

	[CompilerGenerated]
	private void <ClosePanel>b__16_0() { }

	[CompilerGenerated]
	private void <OpenPanel>b__15_0() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<CloseAfterDelay>d__21))]
	private IEnumerator CloseAfterDelay(float delay) { }

	public void ClosePanel() { }

	private void OnDestroy() { }

	private void OnRedeemClicked() { }

	private void OnRedeemError(string error) { }

	private void OnRedeemSuccess(string response) { }

	public void OpenPanel() { }

	[IteratorStateMachine(typeof(<RedeemGiftCode>d__18))]
	private IEnumerator RedeemGiftCode(string code) { }

	private void ShowMessage(string message, Color color) { }

}

