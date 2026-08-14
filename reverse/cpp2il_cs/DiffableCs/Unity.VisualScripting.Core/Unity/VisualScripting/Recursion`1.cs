namespace Unity.VisualScripting;

public class Recursion : IPoolable, IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<T> <>9; //Field offset: 0x0
		public static Func<Recursion`1<T>> <>9__13_0; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal Recursion<T> <New>b__13_0() { }

	}

	private readonly Stack<T> traversedOrder; //Field offset: 0x0
	private readonly Dictionary<T, Int32> traversedCount; //Field offset: 0x0
	private bool disposed; //Field offset: 0x0
	protected int maxDepth; //Field offset: 0x0

	protected Recursion`1() { }

	public override void Dispose() { }

	public void Enter(T o) { }

	public void Exit(T o) { }

	protected override void Free() { }

	public static Recursion<T> New() { }

	public static Recursion<T> New(int maxDepth) { }

	public bool TryEnter(T o) { }

	private override void Unity.VisualScripting.IPoolable.Free() { }

	private override void Unity.VisualScripting.IPoolable.New() { }

}

