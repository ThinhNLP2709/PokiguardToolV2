//Type is in global namespace

public class Effect : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <FadeAndMoveUp>d__0 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GameObject target; //Field offset: 0x20
		private float <duration>5__2; //Field offset: 0x28
		private float <timeElapsed>5__3; //Field offset: 0x2C
		private CanvasGroup <canvasGroup>5__4; //Field offset: 0x30
		private RectTransform <rect>5__5; //Field offset: 0x38
		private Vector2 <startPos>5__6; //Field offset: 0x40

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
		public <FadeAndMoveUp>d__0(int <>1__state) { }

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
	private sealed class <FadeOut>d__1 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public GameObject item; //Field offset: 0x20
		private CanvasGroup <canvasGroup>5__2; //Field offset: 0x28
		private float <alpha>5__3; //Field offset: 0x30

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
		public <FadeOut>d__1(int <>1__state) { }

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


	public Effect() { }

	[IteratorStateMachine(typeof(<FadeAndMoveUp>d__0))]
	public IEnumerator FadeAndMoveUp(GameObject target) { }

	[IteratorStateMachine(typeof(<FadeOut>d__1))]
	public IEnumerator FadeOut(GameObject item) { }

}

