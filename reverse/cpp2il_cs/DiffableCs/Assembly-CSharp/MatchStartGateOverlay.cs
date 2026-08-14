//Type is in global namespace

public class MatchStartGateOverlay : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <WatchRoutine>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchStartGateOverlay <>4__this; //Field offset: 0x20
		private WaitForSecondsRealtime <wait>5__2; //Field offset: 0x28
		private int <dotPhase>5__3; //Field offset: 0x30

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
		public <WatchRoutine>d__20(int <>1__state) { }

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

	private const float FailsafeSec = 35; //Field offset: 0x0
	private const float MinShowSec = 2; //Field offset: 0x0
	private const float NoClockFallbackSec = 6; //Field offset: 0x0
	private static MatchStartGateOverlay _instance; //Field offset: 0x0
	private Text _titleText; //Field offset: 0x20
	private Text _readyText; //Field offset: 0x28
	private float _shownAtUnscaled; //Field offset: 0x30
	private bool _closing; //Field offset: 0x34

	public static bool IsShowing
	{
		 get { } //Length: 102
	}

	public MatchStartGateOverlay() { }

	private void Awake() { }

	private void BuildUI() { }

	private void Close() { }

	private static Text CreateText(Transform parent, string name, string content, Font font, int size, Color color, Vector2 anchoredPos) { }

	public static bool get_IsShowing() { }

	private void HandleGameOver(string winner) { }

	private void HandleGateClosed() { }

	private void HandleReadyState(int ready, int total) { }

	public static void HideNow() { }

	private void OnDestroy() { }

	private void SetReadyLabel(string text) { }

	public static void Show(string subtitle = null) { }

	private void Start() { }

	[IteratorStateMachine(typeof(<WatchRoutine>d__20))]
	private IEnumerator WatchRoutine() { }

}

