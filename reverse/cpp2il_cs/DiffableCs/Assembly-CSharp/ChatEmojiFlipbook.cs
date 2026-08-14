//Type is in global namespace

[RequireComponent(typeof(Image))]
public class ChatEmojiFlipbook : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <Play>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ChatEmojiFlipbook <>4__this; //Field offset: 0x20
		private WaitForSecondsRealtime <wait>5__2; //Field offset: 0x28

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
		public <Play>d__10(int <>1__state) { }

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

	private Image _image; //Field offset: 0x20
	private Sprite[] _frames; //Field offset: 0x28
	private float _interval; //Field offset: 0x30
	private int _index; //Field offset: 0x34
	private Coroutine _routine; //Field offset: 0x38

	public ChatEmojiFlipbook() { }

	private void OnDisable() { }

	private void OnEnable() { }

	[IteratorStateMachine(typeof(<Play>d__10))]
	private IEnumerator Play() { }

	private void RestartIfNeeded() { }

	public bool SetEmoji(string emojiId) { }

	public void SetFrames(Sprite[] frames, float fps) { }

}

