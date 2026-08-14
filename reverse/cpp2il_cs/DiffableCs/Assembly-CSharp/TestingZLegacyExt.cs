//Type is in global namespace

public class TestingZLegacyExt : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<Single> <>9__20_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <cycleThroughExamples>b__20_0(float val) { }

	}

	internal sealed class NextFunc : MulticastDelegate
	{

		public NextFunc(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke() { }

	}

	internal enum TimingType
	{
		SteadyNormalTime = 0,
		IgnoreTimeScale = 1,
		HalfTimeScale = 2,
		VariableTimeScale = 3,
		Length = 4,
	}

	public AnimationCurve customAnimationCurve; //Field offset: 0x20
	public Transform pt1; //Field offset: 0x28
	public Transform pt2; //Field offset: 0x30
	public Transform pt3; //Field offset: 0x38
	public Transform pt4; //Field offset: 0x40
	public Transform pt5; //Field offset: 0x48
	private int exampleIter; //Field offset: 0x50
	private String[] exampleFunctions; //Field offset: 0x58
	public bool useEstimatedTime; //Field offset: 0x60
	private Transform ltLogo; //Field offset: 0x68
	private TimingType timingType; //Field offset: 0x70
	private int descrTimeScaleChangeId; //Field offset: 0x74
	private Vector3 origin; //Field offset: 0x78

	public TestingZLegacyExt() { }

	public void alphaExample() { }

	private void Awake() { }

	public void colorExample() { }

	public void customTweenExample() { }

	private void cycleThroughExamples() { }

	public void delayedCallExample() { }

	public void delayedCallExampleCallback() { }

	private void endlessCallback() { }

	public void loopPause() { }

	public void loopResume() { }

	public void loopTestClamp() { }

	public void loopTestPingPong() { }

	public void moveExample() { }

	public void moveLocalExample() { }

	public void moveOnACurveExample() { }

	private void OnGUI() { }

	private void pauseNow() { }

	public void punchTest() { }

	public void rotateAroundExample() { }

	public void rotateExample() { }

	public void rotateFinished(object hash) { }

	public void rotateOnUpdate(float val) { }

	public void scaleExample() { }

	private void Start() { }

	public void updateValue3Example() { }

	public void updateValue3ExampleCallback(Vector3 val) { }

	public void updateValue3ExampleUpdate(Vector3 val) { }

	public void updateValueExample() { }

	public void updateValueExampleCallback(float val, object hash) { }

}

