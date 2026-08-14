//Type is in global namespace

public class KickToastView : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <CoPlay>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public KickToastView <>4__this; //Field offset: 0x20
		public float duration; //Field offset: 0x28
		private float <t>5__2; //Field offset: 0x2C

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
		public <CoPlay>d__5(int <>1__state) { }

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

	private const float FADE = 0.2; //Field offset: 0x0
	[SerializeField]
	private CanvasGroup canvasGroup; //Field offset: 0x20
	[SerializeField]
	private Text label; //Field offset: 0x28

	public KickToastView() { }

	[IteratorStateMachine(typeof(<CoPlay>d__5))]
	private IEnumerator CoPlay(float duration) { }

	public void Play(string message, float duration) { }

	public void SetRefs(CanvasGroup group, Text labelComp) { }

}

