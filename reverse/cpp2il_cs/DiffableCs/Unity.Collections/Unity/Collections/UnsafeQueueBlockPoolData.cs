namespace Unity.Collections;

[GenerateTestsForBurstCompatibility]
internal struct UnsafeQueueBlockPoolData
{
	internal const int m_BlockSize = 16384; //Field offset: 0x0
	internal IntPtr m_FirstBlock; //Field offset: 0x0
	internal int m_NumBlocks; //Field offset: 0x8
	internal int m_MaxBlocks; //Field offset: 0xC
	internal int m_AllocLock; //Field offset: 0x10

	public UnsafeQueueBlockHeader* AllocateBlock() { }

	public void FreeBlock(UnsafeQueueBlockHeader* block) { }

}

