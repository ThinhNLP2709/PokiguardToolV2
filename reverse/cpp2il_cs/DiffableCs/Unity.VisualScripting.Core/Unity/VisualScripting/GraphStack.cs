namespace Unity.VisualScripting;

public sealed class GraphStack : GraphPointer, IPoolable, IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<GraphStack> <>9__2_0; //Field offset: 0x8
		public static Func<GraphStack> <>9__3_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal GraphStack <New>b__2_0() { }

		internal GraphStack <New>b__3_0() { }

	}


	private GraphStack() { }

	public virtual GraphReference AsReference() { }

	internal void ClearReference() { }

	public GraphStack Clone() { }

	public override void Dispose() { }

	public void EnterParentElement(IGraphParentElement parentElement) { }

	public void ExitParentElement() { }

	private void InitializeNoAlloc(IGraphRoot root, List<IGraphParentElement> parentElements, bool ensureValid) { }

	internal static GraphStack New(IGraphRoot root, List<IGraphParentElement> parentElements) { }

	internal static GraphStack New(GraphPointer model) { }

	public GraphReference ToReference() { }

	public bool TryEnterParentElement(IGraphParentElement parentElement) { }

	public bool TryEnterParentElementUnsafe(IGraphParentElement parentElement) { }

	private override void Unity.VisualScripting.IPoolable.Free() { }

	private override void Unity.VisualScripting.IPoolable.New() { }

}

