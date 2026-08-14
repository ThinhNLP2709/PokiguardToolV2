namespace Unity.Collections.LowLevel.Unsafe;

[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
internal struct UnsafeParallelHashMapBase
{
	private const int SentinelRefilling = -2; //Field offset: 0x0
	private const int SentinelSwapInProgress = -3; //Field offset: 0x0

	internal static void AddAtomicMulti(UnsafeParallelHashMapData* data, TKey key, TValue item, int threadIndex) { }

	internal static int AllocEntry(UnsafeParallelHashMapData* data, int threadIndex) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckIndexOutOfBounds(UnsafeParallelHashMapData* data, int idx) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void CheckOutOfCapacity(int idx, int keyCapacity) { }

	internal static void Clear(UnsafeParallelHashMapData* data) { }

	internal static void FreeEntry(UnsafeParallelHashMapData* data, int idx, int threadIndex) { }

	internal static int Remove(UnsafeParallelHashMapData* data, TKey key, bool isMultiHashMap) { }

	internal static void Remove(UnsafeParallelHashMapData* data, NativeParallelMultiHashMapIterator<TKey> it) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal static void RemoveKeyValue(UnsafeParallelHashMapData* data, TKey key, TValueEQ value) { }

	internal static bool SetValue(UnsafeParallelHashMapData* data, ref NativeParallelMultiHashMapIterator<TKey>& it, ref TValue item) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void ThrowFull() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private static void ThrowInvalidIterator() { }

	internal static bool TryAdd(UnsafeParallelHashMapData* data, TKey key, TValue item, bool isMultiHashMap, AllocatorHandle allocation) { }

	internal static bool TryAddAtomic(UnsafeParallelHashMapData* data, TKey key, TValue item, int threadIndex) { }

	internal static bool TryGetFirstValueAtomic(UnsafeParallelHashMapData* data, TKey key, out TValue item, out NativeParallelMultiHashMapIterator<TKey>& it) { }

	internal static bool TryGetNextValueAtomic(UnsafeParallelHashMapData* data, out TValue item, ref NativeParallelMultiHashMapIterator<TKey>& it) { }

}

