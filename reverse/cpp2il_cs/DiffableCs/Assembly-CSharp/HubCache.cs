//Type is in global namespace

public static class HubCache
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public bool done; //Field offset: 0x10
		public bool success; //Field offset: 0x11
		public HubBootstrapData responseData; //Field offset: 0x18
		public string errMsg; //Field offset: 0x20

		public <>c__DisplayClass18_0() { }

		internal void <LoadViaWs>b__0(HubBootstrapData data) { }

		internal void <LoadViaWs>b__1(string reason) { }

	}

	[CompilerGenerated]
	private sealed class <Load>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action<String> onError; //Field offset: 0x20
		public bool force; //Field offset: 0x28
		public Action onSuccess; //Field offset: 0x30
		private UnityWebRequest <req>5__2; //Field offset: 0x38

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
		public <Load>d__16(int <>1__state) { }

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
	private sealed class <LoadViaWs>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private <>c__DisplayClass18_0 <>8__1; //Field offset: 0x20
		public Action<String> onError; //Field offset: 0x28
		public Action onSuccess; //Field offset: 0x30
		private Action<HubBootstrapData> <onResp>5__2; //Field offset: 0x38
		private Action<String> <onFail>5__3; //Field offset: 0x40
		private float <deadline>5__4; //Field offset: 0x48

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
		public <LoadViaWs>d__18(int <>1__state) { }

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
	private static HubBootstrapData <Data>k__BackingField; //Field offset: 0x0
	private const float TTL_SECONDS = 60; //Field offset: 0x0
	private const int REQUEST_TIMEOUT_SECONDS = 2; //Field offset: 0x0
	private const float NEG_CACHE_SECONDS = 60; //Field offset: 0x0
	private static float _lastFetch; //Field offset: 0x8
	private static float _lastFailTime; //Field offset: 0xC

	public private static HubBootstrapData Data
	{
		[CompilerGenerated]
		 get { } //Length: 78
		[CompilerGenerated]
		private set { } //Length: 105
	}

	public static bool IsFresh
	{
		 get { } //Length: 211
	}

	public static bool UseWsBootstrap
	{
		 get { } //Length: 63
		 set { } //Length: 66
	}

	private static HubCache() { }

	public static void Clear() { }

	private static string Esc(string s) { }

	[CompilerGenerated]
	public static HubBootstrapData get_Data() { }

	public static bool get_IsFresh() { }

	public static bool get_UseWsBootstrap() { }

	public static void Invalidate() { }

	[IteratorStateMachine(typeof(<Load>d__16))]
	public static IEnumerator Load(Action onSuccess = null, Action<String> onError = null, bool force = false) { }

	[IteratorStateMachine(typeof(<LoadViaWs>d__18))]
	private static IEnumerator LoadViaWs(Action onSuccess, Action<String> onError) { }

	[CompilerGenerated]
	private static void set_Data(HubBootstrapData value) { }

	public static void set_UseWsBootstrap(bool value) { }

}

