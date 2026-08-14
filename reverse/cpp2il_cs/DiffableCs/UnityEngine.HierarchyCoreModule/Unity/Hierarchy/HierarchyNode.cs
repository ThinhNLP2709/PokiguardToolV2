namespace Unity.Hierarchy;

[IsReadOnly]
[NativeHeader("Modules/HierarchyCore/Public/HierarchyNode.h")]
public struct HierarchyNode : IEquatable<HierarchyNode>
{
	private static readonly HierarchyNode s_Null; //Field offset: 0x0
	private readonly int m_Id; //Field offset: 0x0
	private readonly int m_Version; //Field offset: 0x4

	public int Id
	{
		 get { } //Length: 3
	}

	[IsReadOnly]
	public static HierarchyNode Null
	{
		 get { } //Length: 51
	}

	public int Version
	{
		 get { } //Length: 4
	}

	public HierarchyNode() { }

	[ExcludeFromDocs]
	public override bool Equals(HierarchyNode other) { }

	[ExcludeFromDocs]
	public virtual bool Equals(object obj) { }

	public int get_Id() { }

	public static HierarchyNode get_Null() { }

	public int get_Version() { }

	[ExcludeFromDocs]
	public virtual int GetHashCode() { }

	[ExcludeFromDocs]
	public static bool op_Equality(in HierarchyNode lhs, in HierarchyNode rhs) { }

	[ExcludeFromDocs]
	public static bool op_Inequality(in HierarchyNode lhs, in HierarchyNode rhs) { }

	[ExcludeFromDocs]
	public virtual string ToString() { }

}

