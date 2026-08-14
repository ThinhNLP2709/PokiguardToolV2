namespace Unity.Hierarchy;

[IsReadOnly]
[NativeHeader("Modules/HierarchyCore/Public/HierarchyNodeType.h")]
public struct HierarchyNodeType : IEquatable<HierarchyNodeType>
{
	private static readonly HierarchyNodeType s_Null; //Field offset: 0x0
	private readonly int m_Id; //Field offset: 0x0

	public int Id
	{
		 get { } //Length: 3
	}

	[IsReadOnly]
	public static HierarchyNodeType Null
	{
		 get { } //Length: 51
	}

	[ExcludeFromDocs]
	public override bool Equals(HierarchyNodeType other) { }

	[ExcludeFromDocs]
	public virtual bool Equals(object obj) { }

	public int get_Id() { }

	public static HierarchyNodeType get_Null() { }

	[ExcludeFromDocs]
	public virtual int GetHashCode() { }

	[ExcludeFromDocs]
	public static bool op_Equality(in HierarchyNodeType lhs, in HierarchyNodeType rhs) { }

	[ExcludeFromDocs]
	public virtual string ToString() { }

}

