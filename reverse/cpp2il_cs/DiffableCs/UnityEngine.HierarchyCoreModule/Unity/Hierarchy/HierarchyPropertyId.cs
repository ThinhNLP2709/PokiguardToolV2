namespace Unity.Hierarchy;

[IsReadOnly]
[NativeHeader("Modules/HierarchyCore/Public/HierarchyPropertyId.h")]
internal struct HierarchyPropertyId : IEquatable<HierarchyPropertyId>
{
	private static readonly HierarchyPropertyId s_Null; //Field offset: 0x0
	private readonly int m_Id; //Field offset: 0x0

	public int Id
	{
		 get { } //Length: 3
	}

	[IsReadOnly]
	public static HierarchyPropertyId Null
	{
		 get { } //Length: 51
	}

	public HierarchyPropertyId() { }

	public override bool Equals(HierarchyPropertyId other) { }

	public virtual bool Equals(object obj) { }

	public int get_Id() { }

	public static HierarchyPropertyId get_Null() { }

	public virtual int GetHashCode() { }

	public static bool op_Equality(in HierarchyPropertyId lhs, in HierarchyPropertyId rhs) { }

	public virtual string ToString() { }

}

