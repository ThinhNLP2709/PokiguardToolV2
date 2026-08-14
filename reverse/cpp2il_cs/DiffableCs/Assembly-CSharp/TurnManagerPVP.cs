//Type is in global namespace

public class TurnManagerPVP : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <ClientDisplayTimerCoroutine>d__27 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public TurnManagerPVP <>4__this; //Field offset: 0x20

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
		public <ClientDisplayTimerCoroutine>d__27(int <>1__state) { }

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
	private static TurnManagerPVP <Instance>k__BackingField; //Field offset: 0x0
	private const float TimerNewTurnJumpSec = 1.5; //Field offset: 0x0
	private static readonly String[] SecStr; //Field offset: 0x8
	[Header("References")]
	[SerializeField]
	private ActivePVP active; //Field offset: 0x20
	[SerializeField]
	private BoardPVP board; //Field offset: 0x28
	[SerializeField]
	private Text countdownText; //Field offset: 0x30
	public YourTurnEffect yourTurnEffect; //Field offset: 0x38
	public GameObject LoadingPanel; //Field offset: 0x40
	[Header("Turn Settings")]
	[SerializeField]
	private float turnDuration; //Field offset: 0x48
	[SerializeField]
	[Tooltip("Legacy — không dùng ở WS (timer server-side). Giữ field để scene không mất serialized data.")]
	private float turnTransitionDelay; //Field offset: 0x4C
	private float syncedTurnTime; //Field offset: 0x50
	private Coroutine turnTimerCoroutine; //Field offset: 0x58
	private float _srvRemainingAtTick; //Field offset: 0x60
	private float _srvTickAt; //Field offset: 0x64
	private bool _srvClockFrozen; //Field offset: 0x68
	private int _lastShownSec; //Field offset: 0x6C

	public private static TurnManagerPVP Instance
	{
		[CompilerGenerated]
		 get { } //Length: 78
		[CompilerGenerated]
		private set { } //Length: 105
	}

	private static TurnManagerPVP() { }

	public TurnManagerPVP() { }

	[CompilerGenerated]
	private void <TriggerYourTurnEffect>b__25_0() { }

	[CompilerGenerated]
	private void <TriggerYourTurnEffect>b__25_1() { }

	[CompilerGenerated]
	private void <TriggerYourTurnEffect>b__25_2() { }

	private void Awake() { }

	private static String[] BuildSecStr() { }

	[IteratorStateMachine(typeof(<ClientDisplayTimerCoroutine>d__27))]
	private IEnumerator ClientDisplayTimerCoroutine() { }

	[CompilerGenerated]
	public static TurnManagerPVP get_Instance() { }

	private void HandleWsTimerTick(string currentPlayer, int remainingSec, int durationSec) { }

	private void HandleWsTurnEnd() { }

	private void OnDestroy() { }

	public void PauseTurn() { }

	internal void ResetTurnTimerDisplayCache() { }

	private void ResetWsClockAnchor(float remainingSec) { }

	public void ResumeTurn() { }

	[CompilerGenerated]
	private static void set_Instance(TurnManagerPVP value) { }

	private void Start() { }

	private void StopTurnTimer() { }

	private void TriggerYourTurnEffect(int actorNumber) { }

	private void UpdateTurnTimerUI(float time) { }

}

