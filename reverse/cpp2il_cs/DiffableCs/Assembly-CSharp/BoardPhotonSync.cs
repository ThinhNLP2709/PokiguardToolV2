//Type is in global namespace

public class BoardPhotonSync : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <WsBootstrapMatch>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BoardPhotonSync <>4__this; //Field offset: 0x20
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
		public <WsBootstrapMatch>d__9(int <>1__state) { }

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

	[SerializeField]
	internal Board board; //Field offset: 0x20
	private Active active; //Field offset: 0x28
	[CompilerGenerated]
	private bool <isPendingServerResponse>k__BackingField; //Field offset: 0x30
	private int _masterDragTurnPauseDepth; //Field offset: 0x34

	internal bool IsDragTurnPauseActive
	{
		internal get { } //Length: 8
	}

	public private bool isPendingServerResponse
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public BoardPhotonSync() { }

	private void Awake() { }

	internal bool get_IsDragTurnPauseActive() { }

	[CompilerGenerated]
	public bool get_isPendingServerResponse() { }

	internal bool IsBoardFullyStable() { }

	private void MasterApplyDragTurnPause() { }

	private void MasterApplyDragTurnResume() { }

	public void RequestPauseTurnTimerForDrag(int actorNumber) { }

	public void RequestResumeTurnTimerAfterDrag(int actorNumber) { }

	public void RequestSwap(int fromCol, int fromRow, int toCol, int toRow, GameObject movedDot = null, GameObject targetDot = null) { }

	internal void ResetMasterDragTurnPauseTracking() { }

	[CompilerGenerated]
	private void set_isPendingServerResponse(bool value) { }

	private void Start() { }

	private bool WsBoardHasDots() { }

	[IteratorStateMachine(typeof(<WsBootstrapMatch>d__9))]
	private IEnumerator WsBootstrapMatch() { }

}

