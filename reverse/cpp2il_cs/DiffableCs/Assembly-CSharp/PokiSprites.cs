//Type is in global namespace

public static class PokiSprites
{
	[CompilerGenerated]
	private sealed class <ApplyWhenReady>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string resourcePath; //Field offset: 0x20
		public Image target; //Field offset: 0x28

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
		public <ApplyWhenReady>d__12(int <>1__state) { }

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
	private sealed class <LoadRoutine>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string resourcePath; //Field offset: 0x20
		private String[] <>7__wrap1; //Field offset: 0x28
		private int <>7__wrap2; //Field offset: 0x30
		private string <address>5__4; //Field offset: 0x38
		private AsyncOperationHandle<IList`1<IResourceLocation>> <locHandle>5__5; //Field offset: 0x40
		private AsyncOperationHandle<Sprite> <h>5__6; //Field offset: 0x58

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
		public <LoadRoutine>d__20(int <>1__state) { }

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
	private sealed class <WarmAsync>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public bool force; //Field offset: 0x20
		private AsyncOperationHandle<IList`1<IResourceLocation>> <locHandle>5__2; //Field offset: 0x28
		private int <loaded>5__3; //Field offset: 0x40
		private IEnumerator<IResourceLocation> <>7__wrap3; //Field offset: 0x48
		private IResourceLocation <loc>5__5; //Field offset: 0x50
		private string <key>5__6; //Field offset: 0x58
		private AsyncOperationHandle<Sprite> <h>5__7; //Field offset: 0x60

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
		public <WarmAsync>d__13(int <>1__state) { }

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

	private class Runner : MonoBehaviour
	{
		private static Runner _instance; //Field offset: 0x0

		public Runner() { }

		public static void Run(IEnumerator routine) { }

	}

	public const string LABEL = "sprites"; //Field offset: 0x0
	public const string REMOTE_ROOT = "Assets/RemoteContent/"; //Field offset: 0x0
	private static readonly String[] OTA_PREFIXES; //Field offset: 0x0
	private static readonly Dictionary<String, Sprite> _remote; //Field offset: 0x8
	private static readonly HashSet<String> _missing; //Field offset: 0x10
	private static readonly HashSet<String> _inFlight; //Field offset: 0x18
	private static bool _warmed; //Field offset: 0x20
	private static bool _warming; //Field offset: 0x21

	public static int RemoteCount
	{
		 get { } //Length: 112
	}

	private static PokiSprites() { }

	private static String[] AddressCandidates(string resourcePath) { }

	public static void Apply(Image target, string resourcePath, Sprite fallback = null) { }

	[IteratorStateMachine(typeof(<ApplyWhenReady>d__12))]
	private static IEnumerator ApplyWhenReady(Image target, string resourcePath) { }

	public static int get_RemoteCount() { }

	public static void Invalidate() { }

	private static bool IsOtaPath(string resourcePath) { }

	public static Sprite Load(string resourcePath) { }

	[IteratorStateMachine(typeof(<LoadRoutine>d__20))]
	private static IEnumerator LoadRoutine(string resourcePath) { }

	private static string ResourceKeyOf(string address) { }

	private static void StartLoad(string resourcePath) { }

	[IteratorStateMachine(typeof(<WarmAsync>d__13))]
	public static IEnumerator WarmAsync(bool force = false) { }

	public static void WarmInBackground() { }

}

