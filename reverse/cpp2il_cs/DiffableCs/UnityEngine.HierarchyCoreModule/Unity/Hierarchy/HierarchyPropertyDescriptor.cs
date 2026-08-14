namespace Unity.Hierarchy;

[NativeHeader("Modules/HierarchyCore/Public/HierarchyPropertyDescriptor.h")]
public struct HierarchyPropertyDescriptor
{
	private int m_Size; //Field offset: 0x0
	private HierarchyPropertyStorageType m_Type; //Field offset: 0x4

	public int Size
	{
		 set { } //Length: 3
	}

	public HierarchyPropertyStorageType Type
	{
		 set { } //Length: 4
	}

	public void set_Size(int value) { }

	public void set_Type(HierarchyPropertyStorageType value) { }

}

