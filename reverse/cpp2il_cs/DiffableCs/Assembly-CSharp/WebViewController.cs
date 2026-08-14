//Type is in global namespace

public class WebViewController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<String> <>9__11_0; //Field offset: 0x8
		public static Action<String> <>9__11_1; //Field offset: 0x10
		public static Action<String> <>9__11_2; //Field offset: 0x18
		public static Action<String> <>9__11_4; //Field offset: 0x20
		public static Action<String> <>9__11_5; //Field offset: 0x28
		public static Action<String> <>9__11_6; //Field offset: 0x30

		private static <>c() { }

		public <>c() { }

		internal void <LoadWebView>b__11_0(string msg) { }

		internal void <LoadWebView>b__11_1(string msg) { }

		internal void <LoadWebView>b__11_2(string msg) { }

		internal void <LoadWebView>b__11_4(string msg) { }

		internal void <LoadWebView>b__11_5(string msg) { }

		internal void <LoadWebView>b__11_6(string msg) { }

	}

	[CompilerGenerated]
	private sealed class <LoadWebView>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public WebViewController <>4__this; //Field offset: 0x20
		public string Url; //Field offset: 0x28
		private String[] <>7__wrap1; //Field offset: 0x30
		private int <>7__wrap2; //Field offset: 0x38
		private string <ext>5__4; //Field offset: 0x40
		private string <dst>5__5; //Field offset: 0x48
		private UnityWebRequest <unityWebRequest>5__6; //Field offset: 0x50

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
		public <LoadWebView>d__11(int <>1__state) { }

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

	public string Url; //Field offset: 0x20
	public int LeftMargin; //Field offset: 0x28
	public int RightMargin; //Field offset: 0x2C
	public int TopMargin; //Field offset: 0x30
	public int BottomMargin; //Field offset: 0x34
	[SerializeField]
	private WebViewObject webViewObject; //Field offset: 0x38
	private Coroutine _loadCoroutine; //Field offset: 0x40

	public WebViewController() { }

	[CompilerGenerated]
	private void <LoadWebView>b__11_3(string msg) { }

	public bool GetVisibility() { }

	[IteratorStateMachine(typeof(<LoadWebView>d__11))]
	private IEnumerator LoadWebView(string Url) { }

	private void OnDisable() { }

	public void SetVisibility(bool visibility) { }

	private void Start() { }

}

