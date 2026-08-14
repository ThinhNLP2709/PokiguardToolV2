namespace DG.Tweening;

public static class DOVirtual
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass0_0
	{
		public float val; //Field offset: 0x10
		public TweenCallback<Single> onVirtualUpdate; //Field offset: 0x18

		public <>c__DisplayClass0_0() { }

		internal float <Float>b__0() { }

		internal void <Float>b__1(float x) { }

		internal void <Float>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public int val; //Field offset: 0x10
		public TweenCallback<Int32> onVirtualUpdate; //Field offset: 0x18

		public <>c__DisplayClass1_0() { }

		internal int <Int>b__0() { }

		internal void <Int>b__1(int x) { }

		internal void <Int>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public Vector2 val; //Field offset: 0x10
		public TweenCallback<Vector2> onVirtualUpdate; //Field offset: 0x18

		public <>c__DisplayClass2_0() { }

		internal Vector2 <Vector2>b__0() { }

		internal void <Vector2>b__1(Vector2 x) { }

		internal void <Vector2>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public Vector3 val; //Field offset: 0x10
		public TweenCallback<Vector3> onVirtualUpdate; //Field offset: 0x20

		public <>c__DisplayClass3_0() { }

		internal Vector3 <Vector3>b__0() { }

		internal void <Vector3>b__1(Vector3 x) { }

		internal void <Vector3>b__2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public Color val; //Field offset: 0x10
		public TweenCallback<Color> onVirtualUpdate; //Field offset: 0x20

		public <>c__DisplayClass4_0() { }

		internal Color <Color>b__0() { }

		internal void <Color>b__1(Color x) { }

		internal void <Color>b__2() { }

	}


	public static Tweener Color(Color from, Color to, float duration, TweenCallback<Color> onVirtualUpdate) { }

	public static Tween DelayedCall(float delay, TweenCallback callback, bool ignoreTimeScale = true) { }

	public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType) { }

	public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType, float overshoot) { }

	public static float EasedValue(float from, float to, float lifetimePercentage, Ease easeType, float amplitude, float period) { }

	public static float EasedValue(float from, float to, float lifetimePercentage, AnimationCurve easeCurve) { }

	public static Vector3 EasedValue(Vector3 from, Vector3 to, float lifetimePercentage, Ease easeType) { }

	public static Vector3 EasedValue(Vector3 from, Vector3 to, float lifetimePercentage, Ease easeType, float overshoot) { }

	public static Vector3 EasedValue(Vector3 from, Vector3 to, float lifetimePercentage, Ease easeType, float amplitude, float period) { }

	public static Vector3 EasedValue(Vector3 from, Vector3 to, float lifetimePercentage, AnimationCurve easeCurve) { }

	public static Tweener Float(float from, float to, float duration, TweenCallback<Single> onVirtualUpdate) { }

	public static Tweener Int(int from, int to, float duration, TweenCallback<Int32> onVirtualUpdate) { }

	public static Tweener Vector2(Vector2 from, Vector2 to, float duration, TweenCallback<Vector2> onVirtualUpdate) { }

	public static Tweener Vector3(Vector3 from, Vector3 to, float duration, TweenCallback<Vector3> onVirtualUpdate) { }

}

