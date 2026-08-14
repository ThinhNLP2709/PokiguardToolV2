//Type is in global namespace

public class SlotMachine : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public BlurLevel level; //Field offset: 0x10

		public <>c__DisplayClass30_0() { }

		internal bool <GetBlurrySprite>b__0(BlurryResource r) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		public SlotType type; //Field offset: 0x10

		public <>c__DisplayClass31_0() { }

		internal bool <GetSlotByType>b__0(SlotResource r) { }

	}

	[CompilerGenerated]
	private sealed class <WaitAndSpinNext>d__28 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public SlotMachine <>4__this; //Field offset: 0x20
		public int nextIndex; //Field offset: 0x28

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
		public <WaitAndSpinNext>d__28(int <>1__state) { }

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

	public List<SlotColumn> columns; //Field offset: 0x20
	public List<UvAnimation> uvColumns; //Field offset: 0x28
	public HorizontalLayoutGroup slotLayout; //Field offset: 0x30
	public SpinBtn spinBtn; //Field offset: 0x38
	public List<SlotResource> resources; //Field offset: 0x40
	public List<BlurryResource> blurryResources; //Field offset: 0x48
	[SerializeField]
	private BlurLevel blurLevel; //Field offset: 0x50
	[Range(0.8, 1)]
	[SerializeField]
	private float shaderBlurAmount; //Field offset: 0x54
	[SerializeField]
	private Vector2 shaderSlotTiling; //Field offset: 0x58
	[Range(0, 10)]
	[SerializeField]
	private float spinSpeed; //Field offset: 0x60
	public Ease easeIn; //Field offset: 0x64
	[Range(0, 5)]
	public float speedIn; //Field offset: 0x68
	public float startYPosIn; //Field offset: 0x6C
	public float targetYPosIn; //Field offset: 0x70
	public Ease easeOut; //Field offset: 0x74
	[Range(0, 5)]
	public float speedOut; //Field offset: 0x78
	public float startYPosOut; //Field offset: 0x7C
	public float targetYPosOut; //Field offset: 0x80
	public Vector2 spinDuration; //Field offset: 0x84
	[SerializeField]
	private float delayAmongSlots; //Field offset: 0x8C
	[HideInInspector]
	public float randomSpinDuration; //Field offset: 0x90

	public SlotMachine() { }

	public Sprite GetBlurrySprite(BlurLevel level, int index) { }

	public SlotResource GetSlotByType(SlotType type) { }

	private void OnColumnSpinComplete(int index) { }

	private void OnDestroy() { }

	private void SpinColumn(int index) { }

	private void Start() { }

	public void StartSpin() { }

	public void StopSpin() { }

	public void StopSpinWithResult(List<SlotType> topRow) { }

	public void UVAnimationVisibility(int index, bool status) { }

	[IteratorStateMachine(typeof(<WaitAndSpinNext>d__28))]
	private IEnumerator WaitAndSpinNext(int nextIndex) { }

}

