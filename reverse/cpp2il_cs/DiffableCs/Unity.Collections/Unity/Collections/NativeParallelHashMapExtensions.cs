namespace Unity.Collections;

[Extension]
[GenerateTestsForBurstCompatibility]
public static class NativeParallelHashMapExtensions
{

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static ValueTuple<NativeArray`1<TKey>, Int32> GetUniqueKeyArray(UnsafeParallelMultiHashMap<TKey, TValue> container, AllocatorHandle allocator) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static ValueTuple<NativeArray`1<TKey>, Int32> GetUniqueKeyArray(NativeParallelMultiHashMap<TKey, TValue> container, AllocatorHandle allocator) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static UnsafeParallelHashMapBucketData GetUnsafeBucketData(NativeParallelHashMap<TKey, TValue> container) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static UnsafeParallelHashMapBucketData GetUnsafeBucketData(NativeParallelMultiHashMap<TKey, TValue> container) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static void Remove(NativeParallelMultiHashMap<TKey, TValue> container, TKey key, TValue value) { }

	[Extension]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static int Unique(NativeArray<T> array) { }

}

