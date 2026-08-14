//Type is in global namespace

public class ImageLoader : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <LoadImageFromURL>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string url; //Field offset: 0x20
		public ImageLoader <>4__this; //Field offset: 0x28
		private UnityWebRequest <www>5__2; //Field offset: 0x30

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
		public <LoadImageFromURL>d__10(int <>1__state) { }

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
	private sealed class <LoadImageFromURL>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string url; //Field offset: 0x20
		public RawImage r; //Field offset: 0x28
		public ImageLoader <>4__this; //Field offset: 0x30
		private UnityWebRequest <www>5__2; //Field offset: 0x38

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
		public <LoadImageFromURL>d__9(int <>1__state) { }

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

	public RawImage rawImage; //Field offset: 0x20
	public float jumpHeight; //Field offset: 0x28
	public float jumpSpeed; //Field offset: 0x2C
	private Vector3 initialPosition; //Field offset: 0x30
	private bool isImageLoaded; //Field offset: 0x3C

	public ImageLoader() { }

	[IteratorStateMachine(typeof(<LoadImageFromURL>d__9))]
	public IEnumerator LoadImageFromURL(string url, RawImage r) { }

	[IteratorStateMachine(typeof(<LoadImageFromURL>d__10))]
	public IEnumerator LoadImageFromURL(string url) { }

	public RawImage LoadingImage(string url, RawImage r) { }

	private void Start() { }

	public void StartLoadingImage(string url) { }

	private void Update() { }

}

