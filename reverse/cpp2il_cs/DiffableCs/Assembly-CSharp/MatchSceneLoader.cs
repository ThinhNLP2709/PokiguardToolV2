//Type is in global namespace

public static class MatchSceneLoader
{
	[CompilerGenerated]
	private sealed class <AbortToHub>d__13 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string matchSceneName; //Field offset: 0x20
		public string reason; //Field offset: 0x28

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
		public <AbortToHub>d__13(int <>1__state) { }

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
	private sealed class <LoadMatchAdditive>d__11 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string matchSceneName; //Field offset: 0x20
		private AsyncOperationHandle<SceneInstance> <handle>5__2; //Field offset: 0x28

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
		public <LoadMatchAdditive>d__11(int <>1__state) { }

		private void <>m__Finally1() { }

		private void <>m__Finally2() { }

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
	private sealed class <PrefabExitRoutine>d__15 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string matchSceneName; //Field offset: 0x20

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
		public <PrefabExitRoutine>d__15(int <>1__state) { }

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
	private sealed class <UnloadMatch>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string matchSceneName; //Field offset: 0x20
		private AsyncOperationHandle<SceneInstance> <unloadHandle>5__2; //Field offset: 0x28
		private AsyncOperation <op>5__3; //Field offset: 0x40

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
		public <UnloadMatch>d__14(int <>1__state) { }

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

		public static Runner Instance
		{
			 get { } //Length: 288
		}

		public Runner() { }

		public static Runner get_Instance() { }

	}

	public const string HUB_SCENE = "QuangTruong"; //Field offset: 0x0
	private static bool _isLoading; //Field offset: 0x0
	private static bool _isUnloading; //Field offset: 0x1
	private static readonly Dictionary<String, AsyncOperationHandle`1<SceneInstance>> _sceneHandles; //Field offset: 0x8
	private static readonly List<Canvas> _disabledCanvases; //Field offset: 0x10
	private static readonly List<Renderer> _disabledRenderers; //Field offset: 0x18
	private static readonly List<Camera> _disabledCameras; //Field offset: 0x20
	private static readonly List<Camera> _disabledCameraComponents; //Field offset: 0x28
	private static readonly List<AudioListener> _disabledAudioListeners; //Field offset: 0x30
	private static readonly List<GraphicRaycaster> _disabledRaycasters; //Field offset: 0x38
	private static readonly List<Animator> _disabledAnimators; //Field offset: 0x40
	private static bool _hubInteractionDisabled; //Field offset: 0x48
	private static bool _eventHookInstalled; //Field offset: 0x49
	private static readonly String[] HUB_ROOTS_KEEP_RENDER; //Field offset: 0x50

	public static bool IsBusy
	{
		 get { } //Length: 445
	}

	private static MatchSceneLoader() { }

	[IteratorStateMachine(typeof(<AbortToHub>d__13))]
	private static IEnumerator AbortToHub(string matchSceneName, string reason) { }

	private static void DisableHubInteraction() { }

	private static void EnableHubInteraction() { }

	private static void EnsureEventHook() { }

	public static void ForceReset() { }

	public static bool get_IsBusy() { }

	public static bool IsMatchAdditiveLoaded(string matchSceneName) { }

	private static bool IsRenderKeptHubRoot(string rootName) { }

	private static MatchKind KindOf(string matchSceneName) { }

	[IteratorStateMachine(typeof(<LoadMatchAdditive>d__11))]
	public static IEnumerator LoadMatchAdditive(string matchSceneName) { }

	private static void NotifyRoomRefreshOnReturn(string matchSceneName) { }

	private static void NotifyServerMatchLeaveIfNeeded() { }

	private static void OnAnySceneUnloaded(Scene unloadedScene) { }

	[IteratorStateMachine(typeof(<PrefabExitRoutine>d__15))]
	private static IEnumerator PrefabExitRoutine(string matchSceneName) { }

	public static string SceneAddressOf(string matchSceneName) { }

	public static void StartLoad(string matchSceneName) { }

	public static void StartUnload(string matchSceneName) { }

	[IteratorStateMachine(typeof(<UnloadMatch>d__14))]
	public static IEnumerator UnloadMatch(string matchSceneName) { }

	private static bool UsePrefabForEnter(string matchSceneName) { }

	private static bool UsePrefabForExit(string matchSceneName) { }

}

