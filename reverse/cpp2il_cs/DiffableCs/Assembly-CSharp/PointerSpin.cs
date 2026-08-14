//Type is in global namespace

public class PointerSpin : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <CheckWheelCount>d__24 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PointerSpin <>4__this; //Field offset: 0x20

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
		public <CheckWheelCount>d__24(int <>1__state) { }

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
	private sealed class <ShowAnimationThenPanelThenUpdateStar>d__38 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PointerSpin <>4__this; //Field offset: 0x20

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
		public <ShowAnimationThenPanelThenUpdateStar>d__38(int <>1__state) { }

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
	private sealed class <SpinPointerToAngle>d__35 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PointerSpin <>4__this; //Field offset: 0x20
		public float serverAngle; //Field offset: 0x28

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
		public <SpinPointerToAngle>d__35(int <>1__state) { }

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
	private sealed class <SpinWheelAPI>d__32 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PointerSpin <>4__this; //Field offset: 0x20

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
		public <SpinWheelAPI>d__32(int <>1__state) { }

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

	[Header("Pointer Settings")]
	public Transform pointerTransform; //Field offset: 0x20
	public float spinDuration; //Field offset: 0x28
	public AnimationCurve spinCurve; //Field offset: 0x30
	[Header("UI Elements")]
	public Button spinButton; //Field offset: 0x38
	public Text resultText; //Field offset: 0x40
	public Text titleText; //Field offset: 0x48
	public Text countdownText; //Field offset: 0x50
	public Text yourWheel; //Field offset: 0x58
	[Header("Result Panel")]
	public GameObject panelResult; //Field offset: 0x60
	public Button btnOke; //Field offset: 0x68
	public Animator animatorRW; //Field offset: 0x70
	public string animationName; //Field offset: 0x78
	[Header("Visual Effects")]
	public ParticleSystem spinParticles; //Field offset: 0x80
	public ParticleSystem winParticles; //Field offset: 0x88
	[Header("Star Update Settings")]
	public float starUpdateDelay; //Field offset: 0x90
	private bool isSpinning; //Field offset: 0x94
	private float targetAngle; //Field offset: 0x98
	private float startAngle; //Field offset: 0x9C
	private float spinStartTime; //Field offset: 0xA0
	private int currentWheelCount; //Field offset: 0xA4
	private int userId; //Field offset: 0xA8
	private SpinWheelResponse spinResult; //Field offset: 0xB0

	public PointerSpin() { }

	[CompilerGenerated]
	private void <CheckWheelCount>b__24_0(SpinWheelResponse response) { }

	[IteratorStateMachine(typeof(<CheckWheelCount>d__24))]
	private IEnumerator CheckWheelCount() { }

	private void ClosePanelResult() { }

	private void OnDestroy() { }

	private void OnEnable() { }

	private void OnError(string error) { }

	private void OnSpinButtonClicked() { }

	private void OnSpinComplete() { }

	private void OnSpinError(string error) { }

	private void OnSpinSuccess(SpinWheelResponse response) { }

	private void PlayStarAddEffect() { }

	[IteratorStateMachine(typeof(<ShowAnimationThenPanelThenUpdateStar>d__38))]
	private IEnumerator ShowAnimationThenPanelThenUpdateStar() { }

	private void ShowNoWheelPanel() { }

	[IteratorStateMachine(typeof(<SpinPointerToAngle>d__35))]
	private IEnumerator SpinPointerToAngle(float serverAngle) { }

	[IteratorStateMachine(typeof(<SpinWheelAPI>d__32))]
	private IEnumerator SpinWheelAPI() { }

	private void Start() { }

	private void StartSpin() { }

	private void Update() { }

	private void UpdateResultTextWithOutline(string prize) { }

	private void UpdateStarWithEffect() { }

	private void UpdateUI() { }

	private void UpdateWheelUI() { }

	private void UpdateYourWheelUI() { }

}

