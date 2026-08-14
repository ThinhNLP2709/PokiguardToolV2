namespace Unity.Collections;

internal sealed class NativeHashMapDebuggerTypeProxy
{
	private HashMapHelper<TKey>* Data; //Field offset: 0x0

	public List<Pair`2<TKey, TValue>> Items
	{
		 get { } //Length: 1049
	}

	public NativeHashMapDebuggerTypeProxy`2(NativeHashMap<TKey, TValue> target) { }

	public NativeHashMapDebuggerTypeProxy`2(ReadOnly<TKey, TValue> target) { }

	public List<Pair`2<TKey, TValue>> get_Items() { }

}

