namespace Unity.Collections.LowLevel.Unsafe;

public struct UntypedUnsafeParallelHashMap
{
	[NativeDisableUnsafePtrRestriction]
	private UnsafeParallelHashMapData* m_Buffer; //Field offset: 0x0
	private AllocatorHandle m_AllocatorLabel; //Field offset: 0x8

}

