//Type is in global namespace

public static class PetResources
{
	[CompilerGenerated]
	private sealed class <CollectClipsAsync>d__27 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Int32[] expected; //Field offset: 0x20
		public string petPath; //Field offset: 0x28
		private string <fullPath>5__2; //Field offset: 0x30
		private Dictionary<String, AnimationClip> <bucket>5__3; //Field offset: 0x38
		private bool <overBudget>5__4; //Field offset: 0x40
		private AsyncOperationHandle<IList`1<IResourceLocation>> <locationsHandle>5__5; //Field offset: 0x48
		private IEnumerator<IResourceLocation> <>7__wrap5; //Field offset: 0x60
		private IResourceLocation <loc>5__7; //Field offset: 0x68
		private AsyncOperationHandle<AnimationClip> <handle>5__8; //Field offset: 0x70

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
		public <CollectClipsAsync>d__27(int <>1__state) { }

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
	private sealed class <LoadAllAsync>d__26 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string petPath; //Field offset: 0x20
		public Action<AnimationClip[]> onComplete; //Field offset: 0x28
		private Int32[] <counter>5__2; //Field offset: 0x30

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
		public <LoadAllAsync>d__26(int <>1__state) { }

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
	private sealed class <WarmRoutine>d__25 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private AsyncOperationHandle<IResourceLocator> <initHandle>5__2; //Field offset: 0x20
		private AsyncOperationHandle<IList`1<IResourceLocation>> <locationsHandle>5__3; //Field offset: 0x38

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
		public <WarmRoutine>d__25(int <>1__state) { }

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

	private class CoroutineRunner : MonoBehaviour
	{

		public CoroutineRunner() { }

	}

	private static IList<IResourceLocation> _cachedPetClipLocations; //Field offset: 0x0
	private const int MAX_ATTEMPTS_PER_PATH = 6; //Field offset: 0x0
	private static readonly Dictionary<String, AnimationClip[]> _clipCache; //Field offset: 0x8
	private static readonly HashSet<String> _rescannedEmptyPaths; //Field offset: 0x10
	private static readonly Dictionary<String, Dictionary`2<String, AnimationClip>> _loadedByKey; //Field offset: 0x18
	private static readonly Dictionary<String, Int32> _attempts; //Field offset: 0x20
	private static readonly HashSet<String> _cacheCleared; //Field offset: 0x28
	private static CoroutineRunner _runner; //Field offset: 0x30
	private static bool _warmStarted; //Field offset: 0x38

	private static CoroutineRunner Runner
	{
		private get { } //Length: 391
	}

	private static PetResources() { }

	private static void ClearBrokenBundleCacheOnce(string petPath, object key) { }

	[IteratorStateMachine(typeof(<CollectClipsAsync>d__27))]
	private static IEnumerator CollectClipsAsync(string petPath, Int32[] expected) { }

	private static int CollectClipsSync(string petPath) { }

	private static bool ExceededBudget(string petPath) { }

	private static CoroutineRunner get_Runner() { }

	private static AnimationClip[] Harvest(string petPath, int expected, out bool complete) { }

	public static void InvalidateCatalogCaches() { }

	public static T Load(string path) { }

	public static AnimationClip[] LoadAll(string petPath) { }

	[IteratorStateMachine(typeof(<LoadAllAsync>d__26))]
	public static IEnumerator LoadAllAsync(string petPath, Action<AnimationClip[]> onComplete) { }

	public static void LoadAllAsyncSafe(string petPath, Action<AnimationClip[]> onComplete) { }

	private static Dictionary<String, AnimationClip> LoadedBucket(string petPath) { }

	public static void Prewarm(string petPath) { }

	public static void ResetAttempts() { }

	public static bool TryGetCachedClips(string petPath, out AnimationClip[] clips) { }

	public static void WarmAddressables() { }

	[IteratorStateMachine(typeof(<WarmRoutine>d__25))]
	private static IEnumerator WarmRoutine() { }

}

