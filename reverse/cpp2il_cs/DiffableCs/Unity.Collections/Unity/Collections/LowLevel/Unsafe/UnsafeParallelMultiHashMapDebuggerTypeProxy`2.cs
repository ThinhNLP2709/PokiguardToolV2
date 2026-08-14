namespace Unity.Collections.LowLevel.Unsafe;

internal sealed class UnsafeParallelMultiHashMapDebuggerTypeProxy
{
	private UnsafeParallelMultiHashMap<TKey, TValue> m_Target; //Field offset: 0x0

	public List<ListPair`2<TKey, List`1<TValue>>> Items
	{
		 get { } //Length: 1416
	}

	public UnsafeParallelMultiHashMapDebuggerTypeProxy`2(UnsafeParallelMultiHashMap<TKey, TValue> target) { }

	public List<ListPair`2<TKey, List`1<TValue>>> get_Items() { }

	public static ValueTuple<NativeArray`1<TKey>, Int32> GetUniqueKeyArray(ref UnsafeParallelMultiHashMap<TKey, TValue>& hashMap, AllocatorHandle allocator) { }

}

