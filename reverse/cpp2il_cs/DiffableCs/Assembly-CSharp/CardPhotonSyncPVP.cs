//Type is in global namespace

public class CardPhotonSyncPVP : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <WsRunDotSkillPvp>d__12 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public CardPhotonSyncPVP <>4__this; //Field offset: 0x20
		public CardUIPVP cardUI; //Field offset: 0x28
		private int <localActor>5__2; //Field offset: 0x30
		private bool <hidBoard>5__3; //Field offset: 0x34

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
		public <WsRunDotSkillPvp>d__12(int <>1__state) { }

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
	private static CardPhotonSyncPVP <Instance>k__BackingField; //Field offset: 0x0
	private BoardPVP board; //Field offset: 0x20
	private ActivePVP active; //Field offset: 0x28
	private float _lastFusionSentAt; //Field offset: 0x30

	public private static CardPhotonSyncPVP Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public CardPhotonSyncPVP() { }

	private void Awake() { }

	[CompilerGenerated]
	public static CardPhotonSyncPVP get_Instance() { }

	private string LocalBlockReasonPvp(CardUIPVP cardUI) { }

	private void OnDestroy() { }

	public void RequestUseCard(CardUIPVP cardUI) { }

	[CompilerGenerated]
	private static void set_Instance(CardPhotonSyncPVP value) { }

	private void Start() { }

	[IteratorStateMachine(typeof(<WsRunDotSkillPvp>d__12))]
	private IEnumerator WsRunDotSkillPvp(CardUIPVP cardUI) { }

}

