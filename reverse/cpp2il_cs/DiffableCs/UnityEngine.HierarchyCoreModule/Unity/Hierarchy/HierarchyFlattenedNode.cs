namespace Unity.Hierarchy;

[IsReadOnly]
[NativeHeader("Modules/HierarchyCore/Public/HierarchyFlattenedNode.h")]
public struct HierarchyFlattenedNode : IEquatable<HierarchyFlattenedNode>
{
	private static readonly HierarchyFlattenedNode s_Null; //Field offset: 0x0
	private readonly HierarchyNode m_Node; //Field offset: 0x0
	private readonly HierarchyNodeType m_Type; //Field offset: 0x8
	private readonly int m_ParentOffset; //Field offset: 0xC
	private readonly int m_NextSiblingOffset; //Field offset: 0x10
	private readonly int m_ChildrenCount; //Field offset: 0x14
	private readonly int m_Depth; //Field offset: 0x18

	public int ChildrenCount
	{
		 get { } //Length: 4
	}

	public int NextSiblingOffset
	{
		 get { } //Length: 4
	}

	public HierarchyNode Node
	{
		 get { } //Length: 4
	}

	[IsReadOnly]
	public static HierarchyFlattenedNode Null
	{
		 get { } //Length: 51
	}

	[ExcludeFromDocs]
	public override bool Equals(HierarchyFlattenedNode other) { }

	[ExcludeFromDocs]
	public virtual bool Equals(object obj) { }

	public int get_ChildrenCount() { }

	public int get_NextSiblingOffset() { }

	public HierarchyNode get_Node() { }

	public static HierarchyFlattenedNode get_Null() { }

	[ExcludeFromDocs]
	public virtual int GetHashCode() { }

	internal static HierarchyNode GetNodeByRef(in HierarchyFlattenedNode hierarchyFlattenedNode) { }

	[ExcludeFromDocs]
	public static bool op_Equality(in HierarchyFlattenedNode lhs, in HierarchyFlattenedNode rhs) { }

	[ExcludeFromDocs]
	public virtual string ToString() { }

}

