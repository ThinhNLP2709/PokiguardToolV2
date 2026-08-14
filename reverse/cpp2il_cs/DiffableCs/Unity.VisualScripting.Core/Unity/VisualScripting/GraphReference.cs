namespace Unity.VisualScripting;

public sealed class GraphReference : GraphPointer
{
	[CompilerGenerated]
	private sealed class <GetBreadcrumbs>d__22 : IEnumerable<GraphReference>, IEnumerable, IEnumerator<GraphReference>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private GraphReference <>2__current; //Field offset: 0x18
		private int <>l__initialThreadId; //Field offset: 0x20
		public GraphReference <>4__this; //Field offset: 0x28
		private int <depth>5__2; //Field offset: 0x30

		private override GraphReference System.Collections.Generic.IEnumerator<Unity.VisualScripting.GraphReference>.Current
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
		public <GetBreadcrumbs>d__22(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override IEnumerator<GraphReference> System.Collections.Generic.IEnumerable<Unity.VisualScripting.GraphReference>.GetEnumerator() { }

		[DebuggerHidden]
		private override GraphReference System.Collections.Generic.IEnumerator<Unity.VisualScripting.GraphReference>.get_Current() { }

		[DebuggerHidden]
		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	private static readonly Dictionary<Int32, List`1<GraphReference>> internPool; //Field offset: 0x0
	[DoNotSerialize]
	private int hashCode; //Field offset: 0x48

	private static GraphReference() { }

	private GraphReference() { }

	public virtual GraphReference AsReference() { }

	public GraphReference ChildReference(IGraphParentElement parentElement, bool ensureValid, Nullable<Int32> maxRecursionDepth = null) { }

	internal static void ClearIntern(GraphPointer pointer) { }

	public GraphReference Clone() { }

	public virtual void CopyFrom(GraphPointer other) { }

	public void CreateGraphData() { }

	public virtual bool Equals(object obj) { }

	public void FreeGraphData() { }

	public static void FreeInvalidInterns() { }

	[IteratorStateMachine(typeof(<GetBreadcrumbs>d__22))]
	public IEnumerable<GraphReference> GetBreadcrumbs() { }

	public virtual int GetHashCode() { }

	private void Hash() { }

	public static GraphReference Intern(GraphPointer pointer) { }

	private static GraphReference New(GraphPointer model) { }

	public static GraphReference New(object rootObject, IEnumerable<Guid> parentElementGuids, bool ensureValid) { }

	public static GraphReference New(IGraphRoot root, IEnumerable<IGraphParentElement> parentElements, bool ensureValid) { }

	public static GraphReference New(IGraphRoot root, bool ensureValid) { }

	public static bool op_Equality(GraphReference x, GraphReference y) { }

	public static bool op_Inequality(GraphReference x, GraphReference y) { }

	public GraphReference ParentReference(bool ensureValid) { }

	internal void Release() { }

	public GraphReference Revalidate(bool ensureValid) { }

	public GraphStack ToStackPooled() { }

}

