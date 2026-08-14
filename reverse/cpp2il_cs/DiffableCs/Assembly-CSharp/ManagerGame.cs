//Type is in global namespace

public class ManagerGame : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <LoadSceneAfterDelay>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public ManagerGame <>4__this; //Field offset: 0x20

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
		public <LoadSceneAfterDelay>d__5(int <>1__state) { }

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

	public static ManagerGame Instance; //Field offset: 0x0
	public static Stack<String> sceneHistory; //Field offset: 0x8
	public GameObject LoadingPanel; //Field offset: 0x20

	private static ManagerGame() { }

	public ManagerGame() { }

	private void Awake() { }

	public void BackScene() { }

	public void HideLoading() { }

	public void LoadScene(string nameScene) { }

	[IteratorStateMachine(typeof(<LoadSceneAfterDelay>d__5))]
	private IEnumerator LoadSceneAfterDelay() { }

	private void OnError(string error) { }

	public void RefreshCurrentUserInfo() { }

	public void ShowLoading() { }

	private void Start() { }

}

