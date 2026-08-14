//Type is in global namespace

public static class ValueChangeFx
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Int64, String> <>9__10_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal string <SetNumber>b__10_0(long v) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public Text target; //Field offset: 0x10
		public Func<Int64, String> formatter; //Field offset: 0x18
		public long to; //Field offset: 0x20
		public Color baseColor; //Field offset: 0x28
		public Vector3 baseScale; //Field offset: 0x38

		public <>c__DisplayClass15_0() { }

		internal void <PlayCountUp>b__0(float v) { }

		internal void <PlayCountUp>b__1() { }

		internal void <PlayCountUp>b__2(Color c) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public GameObject go; //Field offset: 0x10
		public Vector3 baseScale; //Field offset: 0x18

		public <>c__DisplayClass16_0() { }

		internal void <PlayPunch>b__0() { }

	}

	public static readonly Color GainColor; //Field offset: 0x0
	private const float CountDuration = 0.45; //Field offset: 0x0
	private const float PunchUpTime = 0.1; //Field offset: 0x0
	private const float PunchDownTime = 0.16; //Field offset: 0x0
	private const float PunchScale = 1.14; //Field offset: 0x0
	private const float FlashFadeTime = 0.45; //Field offset: 0x0
	private const int MAX_TRACKED = 512; //Field offset: 0x0
	public static readonly Color LossColor; //Field offset: 0x10
	private static readonly Dictionary<Int32, Int64> _lastValues; //Field offset: 0x20
	private static readonly Dictionary<Int32, Vector3> _baseScales; //Field offset: 0x28
	private static readonly Dictionary<Int32, Color> _baseColors; //Field offset: 0x30

	private static ValueChangeFx() { }

	private static void PlayCountUp(Text target, int key, long from, long to, Func<Int64, String> formatter) { }

	private static void PlayPunch(GameObject go, int key) { }

	private static void Register(Text target, int key) { }

	public static void ResetAll() { }

	public static void SetNumber(Text target, long value, Func<Int64, String> formatter, bool animate = true) { }

	public static void SetText(Text target, string value, bool animate = true) { }

}

