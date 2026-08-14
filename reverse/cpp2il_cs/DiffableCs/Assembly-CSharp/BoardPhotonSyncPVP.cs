//Type is in global namespace

public class BoardPhotonSyncPVP : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <WsBootstrapMatchPvp>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardPhotonSyncPVP <>4__this; //Field offset: 0x20
		private float <start>5__2; //Field offset: 0x28
		private MatchService <ms>5__3; //Field offset: 0x30

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
		public <WsBootstrapMatchPvp>d__10(int <>1__state) { }

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

	internal static BoardPhotonSyncPVP Instance; //Field offset: 0x0
	[SerializeField]
	internal BoardPVP board; //Field offset: 0x20
	private ActivePVP active; //Field offset: 0x28
	[CompilerGenerated]
	private bool <isPendingServerResponse>k__BackingField; //Field offset: 0x30

	public private bool isPendingServerResponse
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public BoardPhotonSyncPVP() { }

	private void Awake() { }

	[CompilerGenerated]
	public bool get_isPendingServerResponse() { }

	private void OnDestroy() { }

	public void RequestPauseTurnTimerForDrag(int actorNumber) { }

	public void RequestResumeTurnTimerAfterDrag(int actorNumber) { }

	public void RequestSwap(int fromCol, int fromRow, int toCol, int toRow, GameObject movedDot = null, GameObject targetDot = null) { }

	[CompilerGenerated]
	private void set_isPendingServerResponse(bool value) { }

	private void Start() { }

	private bool WsBoardHasDots() { }

	[IteratorStateMachine(typeof(<WsBootstrapMatchPvp>d__10))]
	private IEnumerator WsBootstrapMatchPvp() { }

}

