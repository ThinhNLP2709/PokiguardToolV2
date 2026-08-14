namespace Unity.Collections.LowLevel.Unsafe;

[GenerateTestsForBurstCompatibility]
internal struct UnsafeParallelHashMapData
{
	private const int kFirstFreeTLSOffset = 64; //Field offset: 0x0
	internal const int IntsPerCacheLine = 16; //Field offset: 0x0
	internal Byte* values; //Field offset: 0x0
	internal Byte* keys; //Field offset: 0x8
	internal Byte* next; //Field offset: 0x10
	internal Byte* buckets; //Field offset: 0x18
	internal int keyCapacity; //Field offset: 0x20
	internal int bucketCapacityMask; //Field offset: 0x24
	internal int allocatedIndexLength; //Field offset: 0x28

	internal Int32* firstFreeTLS
	{
		internal get { } //Length: 5
	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	internal static void AllocateHashMap(int length, int bucketLength, AllocatorHandle label, out UnsafeParallelHashMapData* outBuf) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	internal static int CalculateDataSize(int length, int bucketLength, out int keyOffset, out int nextOffset, out int bucketOffset) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckHashMapReallocateDoesNotShrink(UnsafeParallelHashMapData* data, int newCapacity) { }

	internal static void DeallocateHashMap(UnsafeParallelHashMapData* data, AllocatorHandle allocator) { }

	internal Int32* get_firstFreeTLS() { }

	internal UnsafeParallelHashMapBucketData GetBucketData() { }

	internal static int GetBucketSize(int capacity) { }

	internal static int GetCount(UnsafeParallelHashMapData* data) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal static void GetKeyArray(UnsafeParallelHashMapData* data, NativeArray<TKey> result) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	internal static void GetKeyValueArrays(UnsafeParallelHashMapData* data, NativeKeyValueArrays<TKey, TValue> result) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal static void GetValueArray(UnsafeParallelHashMapData* data, NativeArray<TValue> result) { }

	internal static int GrowCapacity(int capacity) { }

	internal static bool IsEmpty(UnsafeParallelHashMapData* data) { }

	internal static bool MoveNext(UnsafeParallelHashMapData* data, ref int bucketIndex, ref int nextIndex, out int index) { }

	internal static bool MoveNextSearch(UnsafeParallelHashMapData* data, ref int bucketIndex, ref int nextIndex, out int index) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	internal static void ReallocateHashMap(UnsafeParallelHashMapData* data, int newCapacity, int newBucketCapacity, AllocatorHandle label) { }

}

