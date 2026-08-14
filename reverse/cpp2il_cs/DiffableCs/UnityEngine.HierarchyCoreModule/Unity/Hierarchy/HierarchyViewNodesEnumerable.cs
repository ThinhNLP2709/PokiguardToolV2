namespace Unity.Hierarchy;

[IsReadOnly]
public struct HierarchyViewNodesEnumerable
{
	internal struct Enumerator
	{
		private readonly HierarchyFlattened m_HierarchyFlattened; //Field offset: 0x0
		private readonly Predicate m_Predicate; //Field offset: 0x8
		private readonly HierarchyNodeFlags m_Flags; //Field offset: 0x10
		private readonly HierarchyFlattenedNode* m_NodesPtr; //Field offset: 0x18
		private readonly int m_NodesCount; //Field offset: 0x20
		private readonly int m_Version; //Field offset: 0x24
		private int m_Index; //Field offset: 0x28

		[IsReadOnly]
		public HierarchyNode Current
		{
			 get { } //Length: 34
		}

		internal Enumerator(HierarchyViewNodesEnumerable enumerable) { }

		public HierarchyNode get_Current() { }

		public bool MoveNext() { }

		private void ThrowIfVersionChanged() { }

	}

	public sealed class Predicate : MulticastDelegate
	{

		public Predicate(object object, IntPtr method) { }

		public override bool Invoke(in HierarchyNode node, HierarchyNodeFlags flags) { }

	}

	private readonly HierarchyViewModel m_HierarchyViewModel; //Field offset: 0x0
	private readonly Predicate m_Predicate; //Field offset: 0x8
	private readonly HierarchyNodeFlags m_Flags; //Field offset: 0x10

	internal HierarchyViewNodesEnumerable(HierarchyViewModel viewModel, HierarchyNodeFlags flags, Predicate predicate) { }

	public Enumerator GetEnumerator() { }

}

