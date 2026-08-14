//Type is in global namespace

public class ContentUpdateWatcher : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public List<String> pending; //Field offset: 0x10
		public bool applied; //Field offset: 0x18

		public <>c__DisplayClass19_0() { }

		internal void <RunCheck>b__0(List<String> list) { }

		internal void <RunCheck>b__1(bool ok) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public bool exists; //Field offset: 0x10
		public long size; //Field offset: 0x18

		public <>c__DisplayClass23_0() { }

		internal void <DownloadInBackground>b__0(bool v) { }

		internal void <DownloadInBackground>b__1(long v) { }

	}

	[CompilerGenerated]
	private sealed class <ApplyCatalogs>d__21 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public List<String> catalogs; //Field offset: 0x20
		public Action<Boolean> done; //Field offset: 0x28
		private AsyncOperationHandle<List`1<IResourceLocator>> <h>5__2; //Field offset: 0x30

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
		public <ApplyCatalogs>d__21(int <>1__state) { }

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
	private sealed class <CheckCatalogs>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action<List`1<String>> done; //Field offset: 0x20
		private AsyncOperationHandle<List`1<String>> <h>5__2; //Field offset: 0x28

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
		public <CheckCatalogs>d__20(int <>1__state) { }

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
	private sealed class <CleanCache>d__22 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private AsyncOperationHandle<Boolean> <h>5__2; //Field offset: 0x20

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
		public <CleanCache>d__22(int <>1__state) { }

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
	private sealed class <DownloadInBackground>d__23 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ContentUpdateWatcher <>4__this; //Field offset: 0x20
		private <>c__DisplayClass23_0 <>8__1; //Field offset: 0x28
		private String[] <>7__wrap1; //Field offset: 0x30
		private int <>7__wrap2; //Field offset: 0x38
		private string <label>5__4; //Field offset: 0x40
		private AsyncOperationHandle <h>5__5; //Field offset: 0x48

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
		public <DownloadInBackground>d__23(int <>1__state) { }

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
	private sealed class <DownloadSize>d__25 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string label; //Field offset: 0x20
		public Action<Int64> done; //Field offset: 0x28
		private AsyncOperationHandle<Int64> <h>5__2; //Field offset: 0x30

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
		public <DownloadSize>d__25(int <>1__state) { }

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
	private sealed class <LabelExists>d__24 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string label; //Field offset: 0x20
		public Action<Boolean> done; //Field offset: 0x28
		private AsyncOperationHandle<IList`1<IResourceLocation>> <h>5__2; //Field offset: 0x30

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
		public <LabelExists>d__24(int <>1__state) { }

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
	private sealed class <RunCheck>d__19 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ContentUpdateWatcher <>4__this; //Field offset: 0x20
		private <>c__DisplayClass19_0 <>8__1; //Field offset: 0x28

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
		public <RunCheck>d__19(int <>1__state) { }

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
	private sealed class <WatchLoop>d__17 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ContentUpdateWatcher <>4__this; //Field offset: 0x20
		private WaitForSecondsRealtime <tick>5__2; //Field offset: 0x28

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
		public <WatchLoop>d__17(int <>1__state) { }

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

	private const float CHECK_INTERVAL_SECONDS = 600; //Field offset: 0x0
	private const float FIRST_CHECK_DELAY = 20; //Field offset: 0x0
	private const float TICK_SECONDS = 2; //Field offset: 0x0
	private const string HUB_SCENE = "QuangTruong"; //Field offset: 0x0
	private static readonly String[] BACKGROUND_LABELS; //Field offset: 0x0
	private static ContentUpdateWatcher _instance; //Field offset: 0x8
	private static bool _checkRequested; //Field offset: 0x10
	[CompilerGenerated]
	private static bool <IsDownloadingInBackground>k__BackingField; //Field offset: 0x11
	private bool _busy; //Field offset: 0x20
	private float _nextCheckAt; //Field offset: 0x24
	private bool _wasInMatch; //Field offset: 0x28

	public private static bool IsDownloadingInBackground
	{
		[CompilerGenerated]
		 get { } //Length: 79
		[CompilerGenerated]
		private set { } //Length: 84
	}

	private static ContentUpdateWatcher() { }

	public ContentUpdateWatcher() { }

	[IteratorStateMachine(typeof(<ApplyCatalogs>d__21))]
	private IEnumerator ApplyCatalogs(List<String> catalogs, Action<Boolean> done) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::AfterSceneLoad (0))]
	private static void Bootstrap() { }

	[IteratorStateMachine(typeof(<CheckCatalogs>d__20))]
	private IEnumerator CheckCatalogs(Action<List`1<String>> done) { }

	[IteratorStateMachine(typeof(<CleanCache>d__22))]
	private IEnumerator CleanCache() { }

	[IteratorStateMachine(typeof(<DownloadInBackground>d__23))]
	private IEnumerator DownloadInBackground() { }

	[IteratorStateMachine(typeof(<DownloadSize>d__25))]
	private IEnumerator DownloadSize(string label, Action<Int64> done) { }

	[CompilerGenerated]
	public static bool get_IsDownloadingInBackground() { }

	private bool IsSafeMoment() { }

	private static bool IsWifi() { }

	[IteratorStateMachine(typeof(<LabelExists>d__24))]
	private IEnumerator LabelExists(string label, Action<Boolean> done) { }

	public static void RequestCheckNow() { }

	[IteratorStateMachine(typeof(<RunCheck>d__19))]
	private IEnumerator RunCheck() { }

	[CompilerGenerated]
	private static void set_IsDownloadingInBackground(bool value) { }

	private void Start() { }

	[IteratorStateMachine(typeof(<WatchLoop>d__17))]
	private IEnumerator WatchLoop() { }

}

