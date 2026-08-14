//Type is in global namespace

public class BoardController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <SlideIn>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardController <>4__this; //Field offset: 0x20
		public GameObject board; //Field offset: 0x28
		private float <elapsed>5__2; //Field offset: 0x30
		private Vector3 <startPos>5__3; //Field offset: 0x34
		private Vector3 <endPos>5__4; //Field offset: 0x40
		private RectTransform <rectTransform>5__5; //Field offset: 0x50

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
		public <SlideIn>d__12(int <>1__state) { }

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
	private sealed class <SlideOut>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardController <>4__this; //Field offset: 0x20
		public GameObject board; //Field offset: 0x28
		private float <elapsed>5__2; //Field offset: 0x30
		private Vector3 <startPos>5__3; //Field offset: 0x34
		private Vector3 <endPos>5__4; //Field offset: 0x40
		private RectTransform <rectTransform>5__5; //Field offset: 0x50

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
		public <SlideOut>d__13(int <>1__state) { }

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

	public GameObject boardPet; //Field offset: 0x20
	public GameObject boardUpdate; //Field offset: 0x28
	public float slideDuration; //Field offset: 0x30
	public Vector3 hiddenPosition; //Field offset: 0x34
	public Vector3 visiblePosition; //Field offset: 0x40
	public GameObject btnDown; //Field offset: 0x50
	public GameObject boardCard; //Field offset: 0x58

	public BoardController() { }

	public void CloseBoard() { }

	public void CloseUpdateBoard() { }

	public void LoadBoard() { }

	public void LoadBoardCard() { }

	public void LoadBoardUpdate() { }

	[IteratorStateMachine(typeof(<SlideIn>d__12))]
	private IEnumerator SlideIn(GameObject board) { }

	[IteratorStateMachine(typeof(<SlideOut>d__13))]
	private IEnumerator SlideOut(GameObject board) { }

}

