namespace EasyUI.PickerWheelUI;

public class PickerWheel : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass44_0
	{
		public float currentAngle; //Field offset: 0x10
		public PickerWheel <>4__this; //Field offset: 0x18
		public float prevAngle; //Field offset: 0x20
		public bool isIndicatorOnTheLine; //Field offset: 0x24
		public WheelPiece piece; //Field offset: 0x28

		public <>c__DisplayClass44_0() { }

		internal void <Spin>b__0() { }

		internal void <Spin>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass45_0
	{
		public PickerWheel <>4__this; //Field offset: 0x10
		public float prevAngle; //Field offset: 0x18
		public bool isIndicatorOnTheLine; //Field offset: 0x1C
		public WheelPiece piece; //Field offset: 0x20

		public <>c__DisplayClass45_0() { }

		internal void <SpinToIndex>b__0() { }

		internal void <SpinToIndex>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <SetupWheelCoroutine>d__35 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PickerWheel <>4__this; //Field offset: 0x20

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
		public <SetupWheelCoroutine>d__35(int <>1__state) { }

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

	[Header("References :")]
	[SerializeField]
	private GameObject linePrefab; //Field offset: 0x20
	[SerializeField]
	private Transform linesParent; //Field offset: 0x28
	[SerializeField]
	[Space]
	private Transform PickerWheelTransform; //Field offset: 0x30
	[SerializeField]
	private Transform wheelCircle; //Field offset: 0x38
	[SerializeField]
	private GameObject wheelPiecePrefab; //Field offset: 0x40
	[SerializeField]
	private Transform wheelPiecesParent; //Field offset: 0x48
	private GameObject wheelPiecePrefabInstance; //Field offset: 0x50
	[Header("Sounds :")]
	[SerializeField]
	[Space]
	private AudioSource audioSource; //Field offset: 0x58
	[SerializeField]
	private AudioClip tickAudioClip; //Field offset: 0x60
	[Range(0, 1)]
	[SerializeField]
	private float volume; //Field offset: 0x68
	[Range(-3, 3)]
	[SerializeField]
	private float pitch; //Field offset: 0x6C
	[Header("Picker wheel settings :")]
	[Range(1, 20)]
	[Space]
	public int spinDuration; //Field offset: 0x70
	[Range(0.2, 2)]
	[SerializeField]
	private float wheelSize; //Field offset: 0x74
	[Header("Picker wheel pieces :")]
	[Space]
	public WheelPiece[] wheelPieces; //Field offset: 0x78
	private UnityAction onSpinStartEvent; //Field offset: 0x80
	private UnityAction<WheelPiece> onSpinEndEvent; //Field offset: 0x88
	private UnityAction onTickEvent; //Field offset: 0x90
	private bool _isSpinning; //Field offset: 0x98
	private Vector2 pieceMinSize; //Field offset: 0x9C
	private Vector2 pieceMaxSize; //Field offset: 0xA4
	private int piecesMin; //Field offset: 0xAC
	private int piecesMax; //Field offset: 0xB0
	private float pieceAngle; //Field offset: 0xB4
	private float halfPieceAngle; //Field offset: 0xB8
	private float halfPieceAngleWithPaddings; //Field offset: 0xBC
	private double accumulatedWeight; //Field offset: 0xC0
	private Random rand; //Field offset: 0xC8
	private List<Int32> nonZeroChancesIndices; //Field offset: 0xD0
	private bool isGenerated; //Field offset: 0xD8
	private bool needsRegenerate; //Field offset: 0xD9

	public bool IsSpinning
	{
		 get { } //Length: 8
	}

	public PickerWheel() { }

	private void CalculateWeightsAndIndices() { }

	private void ClearWheel() { }

	private void DrawPiece(int index) { }

	public static string FormatVND(long amount) { }

	private void Generate() { }

	public bool get_IsSpinning() { }

	private int GetRandomPieceIndex() { }

	private GameObject InstantiatePiece() { }

	private void LateUpdate() { }

	public void OnSpinEnd(UnityAction<WheelPiece> action) { }

	public void OnSpinStart(UnityAction action) { }

	public void OnTick(UnityAction action) { }

	private void OnValidate() { }

	public void RecalculateWeights() { }

	public void ResetWheelRotation(float duration = 0.5, Action onComplete = null) { }

	private void SetupAudio() { }

	public void SetupWheel() { }

	[IteratorStateMachine(typeof(<SetupWheelCoroutine>d__35))]
	private IEnumerator SetupWheelCoroutine() { }

	private void SetupWheelImmediate() { }

	public void Spin() { }

	public void SpinToIndex(int targetIndex) { }

	private void Start() { }

}

