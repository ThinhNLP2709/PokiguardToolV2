namespace TMPro.Examples;

public class TextConsoleSimulator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <RevealCharacters>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public TMP_Text textComponent; //Field offset: 0x20
		public TextConsoleSimulator <>4__this; //Field offset: 0x28
		private TMP_TextInfo <textInfo>5__2; //Field offset: 0x30
		private int <totalVisibleCharacters>5__3; //Field offset: 0x38
		private int <visibleCount>5__4; //Field offset: 0x3C

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
		public <RevealCharacters>d__7(int <>1__state) { }

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
	private sealed class <RevealWords>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public TMP_Text textComponent; //Field offset: 0x20
		private int <totalWordCount>5__2; //Field offset: 0x28
		private int <totalVisibleCharacters>5__3; //Field offset: 0x2C
		private int <counter>5__4; //Field offset: 0x30
		private int <visibleCount>5__5; //Field offset: 0x34

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
		public <RevealWords>d__8(int <>1__state) { }

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

	private TMP_Text m_TextComponent; //Field offset: 0x20
	private bool hasTextChanged; //Field offset: 0x28

	public TextConsoleSimulator() { }

	private void Awake() { }

	private void ON_TEXT_CHANGED(object obj) { }

	private void OnDisable() { }

	private void OnEnable() { }

	[IteratorStateMachine(typeof(<RevealCharacters>d__7))]
	private IEnumerator RevealCharacters(TMP_Text textComponent) { }

	[IteratorStateMachine(typeof(<RevealWords>d__8))]
	private IEnumerator RevealWords(TMP_Text textComponent) { }

	private void Start() { }

}

