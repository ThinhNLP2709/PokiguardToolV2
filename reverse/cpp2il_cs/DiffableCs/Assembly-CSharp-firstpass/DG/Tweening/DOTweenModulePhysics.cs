namespace DG.Tweening;

[Extension]
public static class DOTweenModulePhysics
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass0_0
	{
		public Rigidbody target; //Field offset: 0x10

		public <>c__DisplayClass0_0() { }

		internal Vector3 <DOMove>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public Rigidbody target; //Field offset: 0x10

		public <>c__DisplayClass1_0() { }

		internal Vector3 <DOMoveX>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public Transform trans; //Field offset: 0x10
		public Rigidbody target; //Field offset: 0x18

		public <>c__DisplayClass10_0() { }

		internal Vector3 <DOLocalPath>b__0() { }

		internal void <DOLocalPath>b__1(Vector3 x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public Rigidbody target; //Field offset: 0x10

		public <>c__DisplayClass2_0() { }

		internal Vector3 <DOMoveY>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public Rigidbody target; //Field offset: 0x10

		public <>c__DisplayClass3_0() { }

		internal Vector3 <DOMoveZ>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public Rigidbody target; //Field offset: 0x10

		public <>c__DisplayClass4_0() { }

		internal Quaternion <DORotate>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public Rigidbody target; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal Quaternion <DOLookAt>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public Rigidbody target; //Field offset: 0x10
		public float startPosY; //Field offset: 0x18
		public bool offsetYSet; //Field offset: 0x1C
		public float offsetY; //Field offset: 0x20
		public Sequence s; //Field offset: 0x28
		public Vector3 endValue; //Field offset: 0x30
		public Tween yTween; //Field offset: 0x40

		public <>c__DisplayClass6_0() { }

		internal Vector3 <DOJump>b__0() { }

		internal void <DOJump>b__1() { }

		internal Vector3 <DOJump>b__2() { }

		internal Vector3 <DOJump>b__3() { }

		internal void <DOJump>b__4() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public Rigidbody target; //Field offset: 0x10

		public <>c__DisplayClass7_0() { }

		internal Vector3 <DOPath>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public Transform trans; //Field offset: 0x10
		public Rigidbody target; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal Vector3 <DOLocalPath>b__0() { }

		internal void <DOLocalPath>b__1(Vector3 x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public Rigidbody target; //Field offset: 0x10

		public <>c__DisplayClass9_0() { }

		internal Vector3 <DOPath>b__0() { }

	}


	[Extension]
	public static Sequence DOJump(Rigidbody target, Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping = false) { }

	[Extension]
	public static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(Rigidbody target, Vector3[] path, float duration, PathType pathType = 0, PathMode pathMode = 1, int resolution = 10, Nullable<Color> gizmoColor = null) { }

	[Extension]
	internal static TweenerCore<Vector3, Path, PathOptions> DOLocalPath(Rigidbody target, Path path, float duration, PathMode pathMode = 1) { }

	[Extension]
	public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DOLookAt(Rigidbody target, Vector3 towards, float duration, AxisConstraint axisConstraint = 0, Nullable<Vector3> up = null) { }

	[Extension]
	public static TweenerCore<Vector3, Vector3, VectorOptions> DOMove(Rigidbody target, Vector3 endValue, float duration, bool snapping = false) { }

	[Extension]
	public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveX(Rigidbody target, float endValue, float duration, bool snapping = false) { }

	[Extension]
	public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveY(Rigidbody target, float endValue, float duration, bool snapping = false) { }

	[Extension]
	public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveZ(Rigidbody target, float endValue, float duration, bool snapping = false) { }

	[Extension]
	public static TweenerCore<Vector3, Path, PathOptions> DOPath(Rigidbody target, Vector3[] path, float duration, PathType pathType = 0, PathMode pathMode = 1, int resolution = 10, Nullable<Color> gizmoColor = null) { }

	[Extension]
	internal static TweenerCore<Vector3, Path, PathOptions> DOPath(Rigidbody target, Path path, float duration, PathMode pathMode = 1) { }

	[Extension]
	public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DORotate(Rigidbody target, Vector3 endValue, float duration, RotateMode mode = 0) { }

}

