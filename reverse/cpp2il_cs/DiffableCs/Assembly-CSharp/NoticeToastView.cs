//Type is in global namespace

public class NoticeToastView : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <CoPlay>d__6 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public NoticeToastView <>4__this; //Field offset: 0x20
		public float duration; //Field offset: 0x28
		private Vector2 <basePos>5__2; //Field offset: 0x2C
		private float <t>5__3; //Field offset: 0x34

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
		public <CoPlay>d__6(int <>1__state) { }

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

	private const float FADE = 0.22; //Field offset: 0x0
	private const float SLIDE = 26; //Field offset: 0x0
	[SerializeField]
	private CanvasGroup canvasGroup; //Field offset: 0x20
	[SerializeField]
	private RectTransform panel; //Field offset: 0x28
	[SerializeField]
	private Text txtMessage; //Field offset: 0x30

	public NoticeToastView() { }

	public void BuildHierarchy() { }

	[IteratorStateMachine(typeof(<CoPlay>d__6))]
	private IEnumerator CoPlay(float duration) { }

	private static GameObject FindOrCreate(Transform parent, string name) { }

	public void Play(string message, float duration) { }

}

