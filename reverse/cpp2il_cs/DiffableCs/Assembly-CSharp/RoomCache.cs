//Type is in global namespace

public static class RoomCache
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public bool done; //Field offset: 0x10
		public bool success; //Field offset: 0x11
		public RoomBootstrapData responseData; //Field offset: 0x18
		public string errMsg; //Field offset: 0x20

		public <>c__DisplayClass19_0() { }

		internal void <LoadViaWs>b__0(RoomBootstrapData data) { }

		internal void <LoadViaWs>b__1(string reason) { }

	}

	[CompilerGenerated]
	private sealed class <Load>d__17 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action<String> onError; //Field offset: 0x20
		public bool force; //Field offset: 0x28
		public int petId; //Field offset: 0x2C
		public string mode; //Field offset: 0x30
		public Action onSuccess; //Field offset: 0x38
		private string <safeMode>5__2; //Field offset: 0x40
		private UnityWebRequest <req>5__3; //Field offset: 0x48

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
		public <Load>d__17(int <>1__state) { }

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
	private sealed class <LoadViaWs>d__19 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public int petId; //Field offset: 0x20
		public string mode; //Field offset: 0x28
		public Action<String> onError; //Field offset: 0x30
		private <>c__DisplayClass19_0 <>8__1; //Field offset: 0x38
		public Action onSuccess; //Field offset: 0x40
		private Action<RoomBootstrapData> <onResp>5__2; //Field offset: 0x48
		private Action<String> <onFail>5__3; //Field offset: 0x50
		private float <deadline>5__4; //Field offset: 0x58

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
		public <LoadViaWs>d__19(int <>1__state) { }

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
	private static RoomBootstrapData <Data>k__BackingField; //Field offset: 0x0
	private const float TTL_SECONDS = 300; //Field offset: 0x0
	private const int REQUEST_TIMEOUT_SECONDS = 2; //Field offset: 0x0
	private const float NEG_CACHE_SECONDS = 60; //Field offset: 0x0
	private static float _lastFetch; //Field offset: 0x8
	private static int _cachedPetId; //Field offset: 0xC
	private static string _cachedMode; //Field offset: 0x10
	private static float _lastFailTime; //Field offset: 0x18

	public private static RoomBootstrapData Data
	{
		[CompilerGenerated]
		 get { } //Length: 78
		[CompilerGenerated]
		private set { } //Length: 105
	}

	public static bool UseWsBootstrap
	{
		 get { } //Length: 63
		 set { } //Length: 66
	}

	private static RoomCache() { }

	public static void Clear() { }

	private static string Esc(string s) { }

	[CompilerGenerated]
	public static RoomBootstrapData get_Data() { }

	public static bool get_UseWsBootstrap() { }

	public static void Invalidate() { }

	public static bool IsFresh(int petId, string mode) { }

	[IteratorStateMachine(typeof(<Load>d__17))]
	public static IEnumerator Load(int petId, string mode, Action onSuccess = null, Action<String> onError = null, bool force = false) { }

	[IteratorStateMachine(typeof(<LoadViaWs>d__19))]
	private static IEnumerator LoadViaWs(int petId, string mode, Action onSuccess, Action<String> onError) { }

	[CompilerGenerated]
	private static void set_Data(RoomBootstrapData value) { }

	public static void set_UseWsBootstrap(bool value) { }

}

