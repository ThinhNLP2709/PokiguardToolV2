namespace DG.Tweening;

[Extension]
public static class DOTweenModulePhysics2D
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass0_0
	{
		public Rigidbody2D target; //Field offset: 0x10

		public <>c__DisplayClass0_0() { }

		internal Vector2 <DOMove>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public Rigidbody2D target; //Field offset: 0x10

		public <>c__DisplayClass1_0() { }

		internal Vector2 <DOMoveX>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public Rigidbody2D target; //Field offset: 0x10

		public <>c__DisplayClass2_0() { }

		internal Vector2 <DOMoveY>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public Rigidbody2D target; //Field offset: 0x10

		public <>c__DisplayClass3_0() { }

		internal float <DORotate>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public Rigidbody2D target; //Field offset: 0x10
		public float startPosY; //Field offset: 0x18
		public bool offsetYSet; //Field offset: 0x1C
		public float offsetY; //Field offset: 0x20
		public Sequence s; //Field offset: 0x28
		public Vector2 endValue; //Field offset: 0x30
		public Tween yTween; //Field offset: 0x38

		public <>c__DisplayClass4_0() { }

		internal Vector2 <DOJump>b__0() { }

		internal void <DOJump>b__1(Vector2 x) { }

		internal void <DOJump>b__2() { }

		internal Vector2 <DOJump>b__3() { }

		internal void <DOJump>b__4(Vector2 x) { }

		internal void <DOJump>b__5() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public Rigidbody2D target; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal Vector3 <DOPath>b__0() { }

		internal void <DOPath>b__1(Vector3 x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public Transform trans; //Field offset: 0x10
		public Rigidbody2D target; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal Vector3 <DOLocalPath>b__0() { }

		internal void <DOLocalPath>b__1(Vector3 x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public Rigidbody2D target; //Field offset: 0x10

		public <>c__DisplayClass7_0() { }

		internal Vector3 <DOPath>b__0() { }

		internal void <DOPath>b__1(Vector3 x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public Transform trans; //Field offset: 0x10
		public Rigidbody2D target; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal Vector3 <DOLocalPath>b__0() { }

		internal void <DOLocalPath>b__1(Vector3 x) { }

	}


	[Extension]
	public static Sequence DOJump(Rigidbody2D target, Vector2 endValue, float jumpPower, int numJumps, float duration, bool snapping = false) { }

	[Extension]
	public static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(Rigidbody2D target, Vector2[] path, float duration, PathType pathType = 0, PathMode pathMode = 1, int resolution = 10, Nullable<Color> gizmoColor = null) { }

	[Extension]
	internal static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(Rigidbody2D target, Path path, float duration, PathMode pathMode = 1) { }

	[Extension]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOMove(Rigidbody2D target, Vector2 endValue, float duration, bool snapping = false) { }

	[Extension]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOMoveX(Rigidbody2D target, float endValue, float duration, bool snapping = false) { }

	[Extension]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOMoveY(Rigidbody2D target, float endValue, float duration, bool snapping = false) { }

	[Extension]
	public static TweenerCore<Vector3, Path, PathOptions> DOPath(Rigidbody2D target, Vector2[] path, float duration, PathType pathType = 0, PathMode pathMode = 1, int resolution = 10, Nullable<Color> gizmoColor = null) { }

	[Extension]
	internal static TweenerCore<Vector3, Path, PathOptions> DOPath(Rigidbody2D target, Path path, float duration, PathMode pathMode = 1) { }

	[Extension]
	public static TweenerCore<Single, Single, FloatOptions> DORotate(Rigidbody2D target, float endValue, float duration) { }

}

