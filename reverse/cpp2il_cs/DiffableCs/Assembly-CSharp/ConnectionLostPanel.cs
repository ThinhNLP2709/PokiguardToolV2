//Type is in global namespace

[DisallowMultipleComponent]
public class ConnectionLostPanel : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <ForceHideAfter>d__40 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float delay; //Field offset: 0x20
		public ConnectionLostPanel <>4__this; //Field offset: 0x28

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
		public <ForceHideAfter>d__40(int <>1__state) { }

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
	private sealed class <ShowAfterDelay>d__33 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float delay; //Field offset: 0x20
		public ConnectionLostPanel <>4__this; //Field offset: 0x28

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
		public <ShowAfterDelay>d__33(int <>1__state) { }

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
	private sealed class <SpinSpinner>d__44 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ConnectionLostPanel <>4__this; //Field offset: 0x20

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
		public <SpinSpinner>d__44(int <>1__state) { }

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
	private static ConnectionLostPanel <Instance>k__BackingField; //Field offset: 0x0
	private const float WATCHDOG_INTERVAL_SEC = 0.5; //Field offset: 0x0
	private const float SHOW_DEBOUNCE_SEC = 3; //Field offset: 0x0
	private const float RESULT_SUPPRESS_SEC = 90; //Field offset: 0x0
	[Header("UI References (drag từ prefab hierarchy)")]
	[SerializeField]
	private GameObject card; //Field offset: 0x20
	[SerializeField]
	private Text bodyText; //Field offset: 0x28
	[SerializeField]
	private Image spinner; //Field offset: 0x30
	[SerializeField]
	private Button retryButton; //Field offset: 0x38
	[SerializeField]
	private float spinSpeed; //Field offset: 0x40
	private Coroutine _spinnerCoroutine; //Field offset: 0x48
	private int _attemptCount; //Field offset: 0x50
	private Canvas _rootCanvas; //Field offset: 0x58
	private GraphicRaycaster _rootRaycaster; //Field offset: 0x60
	private CanvasGroup _rootGroup; //Field offset: 0x68
	private ChatService _subscribedChat; //Field offset: 0x70
	private MatchService _subscribedMatch; //Field offset: 0x78
	private float _resultSuppressUntil; //Field offset: 0x80
	private Coroutine _pendingShowCoroutine; //Field offset: 0x88
	private Coroutine _forceHideCoroutine; //Field offset: 0x90
	private bool _hiding; //Field offset: 0x98
	private float _nextWatchdogAt; //Field offset: 0x9C

	private bool InResultPhase
	{
		private get { } //Length: 36
	}

	public private static ConnectionLostPanel Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public ConnectionLostPanel() { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	private static void AutoInit() { }

	private void Awake() { }

	private void FinishHide() { }

	[IteratorStateMachine(typeof(<ForceHideAfter>d__40))]
	private IEnumerator ForceHideAfter(float delay) { }

	private bool get_InResultPhase() { }

	[CompilerGenerated]
	public static ConnectionLostPanel get_Instance() { }

	private void HandleConnectionChanged(bool connected) { }

	private void HandleGameOver(string winner) { }

	private void HandleReconnecting(int attempt) { }

	public void Hide() { }

	private bool IsOverlayVisible() { }

	private static bool IsSuppressedScene(string sceneName) { }

	private void OnActiveSceneChanged(Scene from, Scene to) { }

	private void OnDestroy() { }

	private void OnRetryClicked() { }

	[CompilerGenerated]
	private static void set_Instance(ConnectionLostPanel value) { }

	private void SetOverlayVisible(bool visible) { }

	public void Show() { }

	[IteratorStateMachine(typeof(<ShowAfterDelay>d__33))]
	private IEnumerator ShowAfterDelay(float delay) { }

	[IteratorStateMachine(typeof(<SpinSpinner>d__44))]
	private IEnumerator SpinSpinner() { }

	private void TrySubscribe() { }

	private void Unsubscribe() { }

	private void Update() { }

}

