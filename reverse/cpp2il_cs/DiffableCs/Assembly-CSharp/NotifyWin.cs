//Type is in global namespace

public class NotifyWin : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <LoadImageFromUrl>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string url; //Field offset: 0x20
		public RawImage rawImage; //Field offset: 0x28
		private UnityWebRequest <request>5__2; //Field offset: 0x30

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
		public <LoadImageFromUrl>d__14(int <>1__state) { }

		private void <>m__Finally1() { }

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
	private sealed class <winGame>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public NotifyWin <>4__this; //Field offset: 0x20
		public int useId; //Field offset: 0x28
		public GameObject listAward; //Field offset: 0x30
		private Enumerator<ResponseDataAward> <>7__wrap1; //Field offset: 0x38

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
		public <winGame>d__13(int <>1__state) { }

		private void <>m__Finally1() { }

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

	public GameObject openThongBao; //Field offset: 0x20
	public GameObject tbPrefab; //Field offset: 0x28
	public GameObject listA; //Field offset: 0x30
	public GameObject itemA; //Field offset: 0x38
	public GameObject nameA; //Field offset: 0x40
	public GameObject imgA; //Field offset: 0x48
	public GameObject imgB; //Field offset: 0x50
	public Api api; //Field offset: 0x58
	public GameObject offBoardParent; //Field offset: 0x60
	public GameObject resultBaner; //Field offset: 0x68
	public GameObject enemyPet; //Field offset: 0x70

	public NotifyWin() { }

	public void endBoard(int userId) { }

	[IteratorStateMachine(typeof(<LoadImageFromUrl>d__14))]
	private IEnumerator LoadImageFromUrl(string url, RawImage rawImage) { }

	private void Start() { }

	[IteratorStateMachine(typeof(<winGame>d__13))]
	public IEnumerator winGame(int useId, GameObject listAward) { }

}

