namespace Unity.Collections;

internal sealed class NativeParallelHashMapDebuggerTypeProxy
{
	private UnsafeParallelHashMap<TKey, TValue> m_Target; //Field offset: 0x0

	public List<Pair`2<TKey, TValue>> Items
	{
		 get { } //Length: 1026
	}

	public NativeParallelHashMapDebuggerTypeProxy`2(NativeParallelHashMap<TKey, TValue> target) { }

	internal NativeParallelHashMapDebuggerTypeProxy`2(ReadOnly<TKey, TValue> target) { }

	public List<Pair`2<TKey, TValue>> get_Items() { }

}

