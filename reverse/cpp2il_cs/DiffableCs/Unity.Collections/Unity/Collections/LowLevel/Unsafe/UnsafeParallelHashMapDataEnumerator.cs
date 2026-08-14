namespace Unity.Collections.LowLevel.Unsafe;

internal struct UnsafeParallelHashMapDataEnumerator
{
	[NativeDisableUnsafePtrRestriction]
	internal UnsafeParallelHashMapData* m_Buffer; //Field offset: 0x0
	internal int m_Index; //Field offset: 0x8
	internal int m_BucketIndex; //Field offset: 0xC
	internal int m_NextIndex; //Field offset: 0x10

	internal UnsafeParallelHashMapDataEnumerator(UnsafeParallelHashMapData* data) { }

	internal KeyValue<TKey, TValue> GetCurrent() { }

	internal TKey GetCurrentKey() { }

	internal bool MoveNext() { }

	internal void Reset() { }

}

