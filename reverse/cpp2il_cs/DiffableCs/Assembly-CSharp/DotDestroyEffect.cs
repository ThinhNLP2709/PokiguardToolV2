//Type is in global namespace

public class DotDestroyEffect : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <DelayThenComplete>d__3 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public DotDestroyEffect <>4__this; //Field offset: 0x20
		public Action onComplete; //Field offset: 0x28

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
		public <DelayThenComplete>d__3(int <>1__state) { }

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

	[Header("Delay Settings")]
	[Tooltip("Thời gian chờ trước khi destroy (giây)")]
	public float duration; //Field offset: 0x20
	private bool isDestroying; //Field offset: 0x24

	public DotDestroyEffect() { }

	[IteratorStateMachine(typeof(<DelayThenComplete>d__3))]
	private IEnumerator DelayThenComplete(Action onComplete) { }

	public void PlayDestroyEffect(Action onComplete = null) { }

	public static void PlayEffect(GameObject dotObject, Action onComplete = null) { }

}

