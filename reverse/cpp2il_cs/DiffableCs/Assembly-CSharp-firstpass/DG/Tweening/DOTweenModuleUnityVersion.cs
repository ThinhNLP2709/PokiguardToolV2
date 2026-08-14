namespace DG.Tweening;

[Extension]
public static class DOTweenModuleUnityVersion
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public Material target; //Field offset: 0x10
		public int propertyID; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal Vector2 <DOOffset>b__0() { }

		internal void <DOOffset>b__1(Vector2 x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public Material target; //Field offset: 0x10
		public int propertyID; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal Vector2 <DOTiling>b__0() { }

		internal void <DOTiling>b__1(Vector2 x) { }

	}

	[CompilerGenerated]
	private struct <AsyncWaitForCompletion>d__10 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public Tween t; //Field offset: 0x20
		private YieldAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <AsyncWaitForElapsedLoops>d__13 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public Tween t; //Field offset: 0x20
		public int elapsedLoops; //Field offset: 0x28
		private YieldAwaiter <>u__1; //Field offset: 0x2C

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <AsyncWaitForKill>d__12 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public Tween t; //Field offset: 0x20
		private YieldAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <AsyncWaitForPosition>d__14 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public Tween t; //Field offset: 0x20
		public float position; //Field offset: 0x28
		private YieldAwaiter <>u__1; //Field offset: 0x2C

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <AsyncWaitForRewind>d__11 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public Tween t; //Field offset: 0x20
		private YieldAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <AsyncWaitForStart>d__15 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public Tween t; //Field offset: 0x20
		private YieldAwaiter <>u__1; //Field offset: 0x28

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}


	[AsyncStateMachine(typeof(<AsyncWaitForCompletion>d__10))]
	[Extension]
	public static Task AsyncWaitForCompletion(Tween t) { }

	[AsyncStateMachine(typeof(<AsyncWaitForElapsedLoops>d__13))]
	[Extension]
	public static Task AsyncWaitForElapsedLoops(Tween t, int elapsedLoops) { }

	[AsyncStateMachine(typeof(<AsyncWaitForKill>d__12))]
	[Extension]
	public static Task AsyncWaitForKill(Tween t) { }

	[AsyncStateMachine(typeof(<AsyncWaitForPosition>d__14))]
	[Extension]
	public static Task AsyncWaitForPosition(Tween t, float position) { }

	[AsyncStateMachine(typeof(<AsyncWaitForRewind>d__11))]
	[Extension]
	public static Task AsyncWaitForRewind(Tween t) { }

	[AsyncStateMachine(typeof(<AsyncWaitForStart>d__15))]
	[Extension]
	public static Task AsyncWaitForStart(Tween t) { }

	[Extension]
	public static Sequence DOGradientColor(Material target, Gradient gradient, float duration) { }

	[Extension]
	public static Sequence DOGradientColor(Material target, Gradient gradient, string property, float duration) { }

	[Extension]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOOffset(Material target, Vector2 endValue, int propertyID, float duration) { }

	[Extension]
	public static TweenerCore<Vector2, Vector2, VectorOptions> DOTiling(Material target, Vector2 endValue, int propertyID, float duration) { }

	[Extension]
	public static CustomYieldInstruction WaitForCompletion(Tween t, bool returnCustomYieldInstruction) { }

	[Extension]
	public static CustomYieldInstruction WaitForElapsedLoops(Tween t, int elapsedLoops, bool returnCustomYieldInstruction) { }

	[Extension]
	public static CustomYieldInstruction WaitForKill(Tween t, bool returnCustomYieldInstruction) { }

	[Extension]
	public static CustomYieldInstruction WaitForPosition(Tween t, float position, bool returnCustomYieldInstruction) { }

	[Extension]
	public static CustomYieldInstruction WaitForRewind(Tween t, bool returnCustomYieldInstruction) { }

	[Extension]
	public static CustomYieldInstruction WaitForStart(Tween t, bool returnCustomYieldInstruction) { }

}

