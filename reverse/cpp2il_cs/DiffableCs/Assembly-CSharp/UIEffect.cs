//Type is in global namespace

public class UIEffect : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <DisplayAndFade>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public UIEffect <>4__this; //Field offset: 0x20
		private Vector3 <startPos>5__2; //Field offset: 0x28
		private Vector3 <targetPos>5__3; //Field offset: 0x34
		private Color <startColor>5__4; //Field offset: 0x40
		private Color <targetColor>5__5; //Field offset: 0x50
		private float <elapsedTime>5__6; //Field offset: 0x60

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
		public <DisplayAndFade>d__5(int <>1__state) { }

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

	public Text uiText; //Field offset: 0x20
	public float displayDuration; //Field offset: 0x28
	public float fadeDuration; //Field offset: 0x2C
	public float moveUpDistance; //Field offset: 0x30

	public UIEffect() { }

	[IteratorStateMachine(typeof(<DisplayAndFade>d__5))]
	private IEnumerator DisplayAndFade() { }

	public void ShowWithEffect(string text) { }

}

