//Type is in global namespace

public class CardPhotonSync : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <WsRunDotSkill>d__10 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public CardPhotonSync <>4__this; //Field offset: 0x20
		public CardUI cardUI; //Field offset: 0x28
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
		public <WsRunDotSkill>d__10(int <>1__state) { }

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
	private static CardPhotonSync <Instance>k__BackingField; //Field offset: 0x0
	private Board board; //Field offset: 0x20
	private Active active; //Field offset: 0x28

	public private static CardPhotonSync Instance
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public CardPhotonSync() { }

	private void Awake() { }

	[CompilerGenerated]
	public static CardPhotonSync get_Instance() { }

	private string LocalBlockReason(CardUI cardUI) { }

	public void RequestUseCard(CardUI cardUI) { }

	[CompilerGenerated]
	private static void set_Instance(CardPhotonSync value) { }

	private void Start() { }

	[IteratorStateMachine(typeof(<WsRunDotSkill>d__10))]
	private IEnumerator WsRunDotSkill(CardUI cardUI) { }

}

