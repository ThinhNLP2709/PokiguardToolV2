//Type is in global namespace

public class MatchNotificationToast : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Fade>d__15 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchNotificationToast <>4__this; //Field offset: 0x20
		public float from; //Field offset: 0x28
		public float to; //Field offset: 0x2C
		public float duration; //Field offset: 0x30
		private float <elapsed>5__2; //Field offset: 0x34

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
		public <Fade>d__15(int <>1__state) { }

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
	private sealed class <ProcessQueue>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public MatchNotificationToast <>4__this; //Field offset: 0x20

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
		public <ProcessQueue>d__14(int <>1__state) { }

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

	private const int MaxQueue = 4; //Field offset: 0x0
	[Header("Optional Inspector refs — auto-create nếu null")]
	[SerializeField]
	private CanvasGroup canvasGroup; //Field offset: 0x20
	[SerializeField]
	private Text messageText; //Field offset: 0x28
	[SerializeField]
	private Image background; //Field offset: 0x30
	[Header("Timing (seconds)")]
	[SerializeField]
	private float fadeInDuration; //Field offset: 0x38
	[SerializeField]
	private float holdDuration; //Field offset: 0x3C
	[SerializeField]
	private float fadeOutDuration; //Field offset: 0x40
	private readonly Queue<String> _queue; //Field offset: 0x48
	private bool _isShowing; //Field offset: 0x50
	private Coroutine _processRoutine; //Field offset: 0x58
	private string _lastQueued; //Field offset: 0x60

	public MatchNotificationToast() { }

	private void AutoBuildUI() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<Fade>d__15))]
	private IEnumerator Fade(float from, float to, float duration) { }

	private void OnDisable() { }

	[IteratorStateMachine(typeof(<ProcessQueue>d__14))]
	private IEnumerator ProcessQueue() { }

	public void Show(string message) { }

}

