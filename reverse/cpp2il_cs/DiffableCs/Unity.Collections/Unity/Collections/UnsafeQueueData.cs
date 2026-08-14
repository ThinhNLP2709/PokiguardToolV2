namespace Unity.Collections;

[GenerateTestsForBurstCompatibility]
internal struct UnsafeQueueData
{
	public IntPtr m_FirstBlock; //Field offset: 0x0
	public IntPtr m_LastBlock; //Field offset: 0x8
	public int m_MaxItems; //Field offset: 0x10
	public int m_CurrentRead; //Field offset: 0x14
	public Byte* m_CurrentWriteBlockTLS; //Field offset: 0x18

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static void AllocateQueue(AllocatorHandle label, out UnsafeQueueData* outBuf) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static UnsafeQueueBlockHeader* AllocateWriteBlockMT(UnsafeQueueData* data, UnsafeQueueBlockPoolData* pool, int threadIndex) { }

	public static void DeallocateQueue(UnsafeQueueData* data, UnsafeQueueBlockPoolData* pool, AllocatorHandle allocation) { }

	internal UnsafeQueueBlockHeader* GetCurrentWriteBlockTLS(int threadIndex) { }

	internal void SetCurrentWriteBlockTLS(int threadIndex, UnsafeQueueBlockHeader* currentWriteBlock) { }

}

