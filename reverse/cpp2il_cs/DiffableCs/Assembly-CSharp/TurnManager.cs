//Type is in global namespace

public class TurnManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <WsDisplayTimerCoroutine>d__20 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public TurnManager <>4__this; //Field offset: 0x20

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
		public <WsDisplayTimerCoroutine>d__20(int <>1__state) { }

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
	private static TurnManager <Instance>k__BackingField; //Field offset: 0x0
	private const float TimerNewTurnJumpSec = 1.5; //Field offset: 0x0
	private static readonly String[] SecStr; //Field offset: 0x8
	public GameObject LoadingPanel; //Field offset: 0x20
	[Header("References")]
	[SerializeField]
	private Active active; //Field offset: 0x28
	[SerializeField]
	private Board board; //Field offset: 0x30
	[SerializeField]
	private Text countdownText; //Field offset: 0x38
	public YourTurnEffect yourTurnEffect; //Field offset: 0x40
	[Header("Turn Settings")]
	[SerializeField]
	private float turnDuration; //Field offset: 0x48
	[SerializeField]
	[Tooltip("Legacy — server WS tự quyết nhịp chuyển lượt, giá trị này không còn được dùng.")]
	private float turnTransitionDelay; //Field offset: 0x4C
	private float syncedTurnTime; //Field offset: 0x50
	private Coroutine turnTimerCoroutine; //Field offset: 0x58
	private float pausedTurnTime; //Field offset: 0x60
	private bool _wsSubscribed; //Field offset: 0x64
	private float _srvRemainingAtTick; //Field offset: 0x68
	private float _srvTickAt; //Field offset: 0x6C
	private bool _srvClockFrozen; //Field offset: 0x70
	private bool hasGameStarted; //Field offset: 0x71
	private int _lastYourTurnFxTurn; //Field offset: 0x74
	private int _lastShownSec; //Field offset: 0x78

	public bool HasGameStarted
	{
		 get { } //Length: 5
	}

	public private static TurnManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 78
		[CompilerGenerated]
		private set { } //Length: 105
	}

	private static TurnManager() { }

	public TurnManager() { }

	[CompilerGenerated]
	private void <TriggerYourTurnEffect>b__33_0() { }

	[CompilerGenerated]
	private void <TriggerYourTurnEffect>b__33_1() { }

	[CompilerGenerated]
	private void <TriggerYourTurnEffect>b__33_2() { }

	private void Awake() { }

	private static String[] BuildSecStr() { }

	public bool get_HasGameStarted() { }

	[CompilerGenerated]
	public static TurnManager get_Instance() { }

	private void HandleWsTimerTick(string currentPlayer, int remainingSec, int durationSec) { }

	private void HandleWsTurnEnd() { }

	private void OnDestroy() { }

	public void PauseTurn() { }

	public void RequestEndTurnFromClient() { }

	internal void ResetTurnTimerDisplayCache() { }

	private void ResetWsClockAnchor(float remainingSec) { }

	public void ResumeTurn() { }

	[CompilerGenerated]
	private static void set_Instance(TurnManager value) { }

	private void Start() { }

	public void StartGameCoOp() { }

	public void StartGameWs() { }

	private void StopTurnTimer() { }

	private void TriggerYourTurnEffect(int actorNumber) { }

	private void TrySubscribeWs() { }

	private void UpdateTurnTimerUI(float time) { }

	[IteratorStateMachine(typeof(<WsDisplayTimerCoroutine>d__20))]
	private IEnumerator WsDisplayTimerCoroutine() { }

}

