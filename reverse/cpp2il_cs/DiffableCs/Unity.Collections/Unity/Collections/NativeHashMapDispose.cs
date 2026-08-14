namespace Unity.Collections;

[GenerateTestsForBurstCompatibility]
[NativeContainer]
internal struct NativeHashMapDispose
{
	[NativeDisableUnsafePtrRestriction]
	internal UnsafeHashMap<Int32, Int32>* m_HashMapData; //Field offset: 0x0
	internal AllocatorHandle m_Allocator; //Field offset: 0x8

	internal void Dispose() { }

}

