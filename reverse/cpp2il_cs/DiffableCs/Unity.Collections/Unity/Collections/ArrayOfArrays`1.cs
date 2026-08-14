namespace Unity.Collections;

[DefaultMember("Item")]
internal struct ArrayOfArrays : IDisposable
{
	private AllocatorHandle m_backingAllocatorHandle; //Field offset: 0x0
	private int m_lengthInElements; //Field offset: 0x0
	private int m_capacityInElements; //Field offset: 0x0
	private int m_log2BlockSizeInElements; //Field offset: 0x0
	private int m_blocks; //Field offset: 0x0
	private IntPtr* m_block; //Field offset: 0x0

	private int BlockMask
	{
		private get { } //Length: 45
	}

	private int BlockSizeInBytes
	{
		private get { } //Length: 43
	}

	private int BlockSizeInElements
	{
		private get { } //Length: 11
	}

	public int Capacity
	{
		 get { } //Length: 4
	}

	public T Item
	{
		 get { } //Length: 169
	}

	public int Length
	{
		 get { } //Length: 4
	}

	public ArrayOfArrays`1(int capacityInElements, AllocatorHandle backingAllocatorHandle, int log2BlockSizeInElements = 12) { }

	private int BlockIndexOfElement(int elementIndex) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckBlockIndex(int blockIndex) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckBlockIsNotNull(int blockIndex) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckElementIndex(int elementIndex) { }

	public void Clear() { }

	public override void Dispose() { }

	private int get_BlockMask() { }

	private int get_BlockSizeInBytes() { }

	private int get_BlockSizeInElements() { }

	public int get_Capacity() { }

	public T get_Item(int elementIndex) { }

	public int get_Length() { }

	public void LockfreeAdd(T t) { }

	public void RemoveAtSwapBack(int elementIndex) { }

	public void Rewind() { }

	public void TrimExcess() { }

}

