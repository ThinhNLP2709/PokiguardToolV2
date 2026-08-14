//Type is in global namespace

public class delayAndRender : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <DelayedRendering>d__3 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public delayAndRender <>4__this; //Field offset: 0x20

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
		public <DelayedRendering>d__3(int <>1__state) { }

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

	public GameObject offBoardParent; //Field offset: 0x20
	public GameObject onListDot; //Field offset: 0x28

	public delayAndRender() { }

	public void CheckForStableBoardAfterFill() { }

	[IteratorStateMachine(typeof(<DelayedRendering>d__3))]
	private IEnumerator DelayedRendering() { }

}

