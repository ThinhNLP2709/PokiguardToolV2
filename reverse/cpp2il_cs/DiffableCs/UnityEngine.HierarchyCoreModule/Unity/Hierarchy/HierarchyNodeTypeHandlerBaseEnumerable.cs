namespace Unity.Hierarchy;

[IsReadOnly]
public struct HierarchyNodeTypeHandlerBaseEnumerable
{
	internal struct Enumerator : IDisposable
	{
		private readonly IMemoryOwner<IntPtr> m_Handlers; //Field offset: 0x0
		private readonly int m_Count; //Field offset: 0x8
		private int m_Index; //Field offset: 0xC

		public HierarchyNodeTypeHandlerBase Current
		{
			 get { } //Length: 296
		}

		internal Enumerator(Hierarchy hierarchy) { }

		public override void Dispose() { }

		public HierarchyNodeTypeHandlerBase get_Current() { }

		public bool MoveNext() { }

	}

	private readonly Hierarchy m_Hierarchy; //Field offset: 0x0

	internal HierarchyNodeTypeHandlerBaseEnumerable(Hierarchy hierarchy) { }

	public Enumerator GetEnumerator() { }

}

