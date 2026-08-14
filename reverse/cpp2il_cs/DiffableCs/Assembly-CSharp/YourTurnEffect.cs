//Type is in global namespace

public class YourTurnEffect : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <PlayEffect>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public YourTurnEffect <>4__this; //Field offset: 0x20
		private float <timer>5__2; //Field offset: 0x28

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
		public <PlayEffect>d__7(int <>1__state) { }

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

	[Header("Effect Settings")]
	[SerializeField]
	private float fadeInDuration; //Field offset: 0x20
	[SerializeField]
	private float fadeOutDuration; //Field offset: 0x24
	[SerializeField]
	private float peakDuration; //Field offset: 0x28
	[SerializeField]
	private float scaleAmount; //Field offset: 0x2C
	private CanvasGroup canvasGroup; //Field offset: 0x30
	private RectTransform rectTransform; //Field offset: 0x38

	public YourTurnEffect() { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<PlayEffect>d__7))]
	public IEnumerator PlayEffect() { }

}

