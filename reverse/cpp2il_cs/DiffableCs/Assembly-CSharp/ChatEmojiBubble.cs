//Type is in global namespace

public class ChatEmojiBubble : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <PlayRoutine>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ChatEmojiBubble <>4__this; //Field offset: 0x20
		private float <t>5__2; //Field offset: 0x28

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
		public <PlayRoutine>d__7(int <>1__state) { }

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

	private const float PopInSec = 0.22; //Field offset: 0x0
	private const float HoldSec = 2; //Field offset: 0x0
	private const float FadeOutSec = 0.3; //Field offset: 0x0
	private const float BubbleSize = 58; //Field offset: 0x0
	private CanvasGroup _group; //Field offset: 0x20

	public ChatEmojiBubble() { }

	private void Build(Sprite[] frames, string emojiId) { }

	[IteratorStateMachine(typeof(<PlayRoutine>d__7))]
	private IEnumerator PlayRoutine() { }

	public static bool ShowOnActor(int actorNumber, string emojiId) { }

}

