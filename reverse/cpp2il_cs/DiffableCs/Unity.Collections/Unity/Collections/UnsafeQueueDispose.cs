namespace Unity.Collections;

[GenerateTestsForBurstCompatibility]
internal struct UnsafeQueueDispose
{
	[NativeDisableUnsafePtrRestriction]
	internal UnsafeQueueData* m_Buffer; //Field offset: 0x0
	[NativeDisableUnsafePtrRestriction]
	internal UnsafeQueueBlockPoolData* m_QueuePool; //Field offset: 0x8
	internal AllocatorHandle m_AllocatorLabel; //Field offset: 0x10

	public void Dispose() { }

}

