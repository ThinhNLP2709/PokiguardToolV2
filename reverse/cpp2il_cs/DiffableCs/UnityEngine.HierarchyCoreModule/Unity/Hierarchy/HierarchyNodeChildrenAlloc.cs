namespace Unity.Hierarchy;

internal struct HierarchyNodeChildrenAlloc
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <Reserved>e__FixedBuffer
	{
		public int FixedElementField; //Field offset: 0x0

	}

	public HierarchyNode* Ptr; //Field offset: 0x0
	public int Size; //Field offset: 0x8
	public int Capacity; //Field offset: 0xC
	public int RemovedCount; //Field offset: 0x10
	[FixedBuffer(typeof(int), 3)]
	public <Reserved>e__FixedBuffer Reserved; //Field offset: 0x14

}

