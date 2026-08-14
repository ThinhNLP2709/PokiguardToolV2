//Type is in global namespace

public class SceneController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Int64, Boolean> <>9__3_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <LoadSceneByNameStart>b__3_1(long number) { }

	}

	[CompilerGenerated]
	private sealed class <LoadSceneAfterApi>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public SceneController <>4__this; //Field offset: 0x20
		public string listCardUserIdJson; //Field offset: 0x28
		public string sceneName; //Field offset: 0x30

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
		public <LoadSceneAfterApi>d__5(int <>1__state) { }

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

	public LoadRoom loadRoom; //Field offset: 0x20
	public Api api; //Field offset: 0x28
	public ApiLoadRoom apiLoadRoom; //Field offset: 0x30

	public SceneController() { }

	[CompilerGenerated]
	private long <LoadSceneByNameStart>b__3_0(Button card) { }

	public void ChangeSceneDauTruong(string sceneName) { }

	private long ExtractNumberFromName(string name) { }

	public void HideNewScene(string newSceneName) { }

	[IteratorStateMachine(typeof(<LoadSceneAfterApi>d__5))]
	private IEnumerator LoadSceneAfterApi(string sceneName, string listCardUserIdJson) { }

	public void LoadSceneByIndex(int sceneIndex) { }

	public void LoadSceneByName(string sceneName) { }

	public void LoadSceneByNameStart(string sceneName) { }

	public void QuitGame() { }

	public void ShowNewScene(string newSceneName) { }

	public void UnloadNewScene() { }

}

