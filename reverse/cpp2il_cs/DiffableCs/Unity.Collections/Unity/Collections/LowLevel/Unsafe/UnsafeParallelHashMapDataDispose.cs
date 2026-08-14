namespace Unity.Collections.LowLevel.Unsafe;

[GenerateTestsForBurstCompatibility]
[NativeContainer]
internal struct UnsafeParallelHashMapDataDispose
{
	[NativeDisableUnsafePtrRestriction]
	internal UnsafeParallelHashMapData* m_Buffer; //Field offset: 0x0
	internal AllocatorHandle m_AllocatorLabel; //Field offset: 0x8

	public void Dispose() { }

}

