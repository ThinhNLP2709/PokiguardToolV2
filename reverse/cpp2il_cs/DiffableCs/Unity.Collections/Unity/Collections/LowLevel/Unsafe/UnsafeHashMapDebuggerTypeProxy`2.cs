namespace Unity.Collections.LowLevel.Unsafe;

internal sealed class UnsafeHashMapDebuggerTypeProxy
{
	private HashMapHelper<TKey> Data; //Field offset: 0x0

	public List<Pair`2<TKey, TValue>> Items
	{
		 get { } //Length: 1026
	}

	public UnsafeHashMapDebuggerTypeProxy`2(UnsafeHashMap<TKey, TValue> target) { }

	public UnsafeHashMapDebuggerTypeProxy`2(ReadOnly<TKey, TValue> target) { }

	public List<Pair`2<TKey, TValue>> get_Items() { }

}

