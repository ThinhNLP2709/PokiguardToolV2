//Type is in global namespace

public class SlotColumn : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <WaitToEndSpin>d__16 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float duration; //Field offset: 0x20
		public SlotColumn <>4__this; //Field offset: 0x28

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
		public <WaitToEndSpin>d__16(int <>1__state) { }

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

	internal sealed class SlotEvents : MulticastDelegate
	{

		public SlotEvents(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(int index, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(int index) { }

	}

	[CompilerGenerated]
	private static SlotEvents OnSpinComplete; //Field offset: 0x0
	[SerializeField]
	private List<SlotData> slots; //Field offset: 0x20
	private SlotMachine _parent; //Field offset: 0x28
	private int _index; //Field offset: 0x30
	private RectTransform _rt; //Field offset: 0x38
	private bool _isComplete; //Field offset: 0x40
	private Nullable<SlotType> _targetType; //Field offset: 0x44

	public static event SlotEvents OnSpinComplete
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public SlotColumn() { }

	[CompilerGenerated]
	private void <DoStopAnimation>b__15_0() { }

	[CompilerGenerated]
	private void <StartSpin>b__12_0() { }

	[CompilerGenerated]
	public static void add_OnSpinComplete(SlotEvents value) { }

	private void DoStopAnimation() { }

	public SlotData GetBottomSlot() { }

	public SlotData GetTopSlot() { }

	public void Initialize(SlotMachine parent, int index) { }

	[CompilerGenerated]
	public static void remove_OnSpinComplete(SlotEvents value) { }

	public void SetRandom() { }

	public void SetTargetAndStop(SlotType targetType) { }

	public void SetVisibility(bool status) { }

	public void StartSpin() { }

	public void StopSpin() { }

	[IteratorStateMachine(typeof(<WaitToEndSpin>d__16))]
	private IEnumerator WaitToEndSpin(float duration) { }

}

