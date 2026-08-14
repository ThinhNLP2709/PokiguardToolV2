namespace Unity.Collections.LowLevel.Unsafe;

internal sealed class UnsafeHashSetDebuggerTypeProxy
{
	private HashMapHelper<T> Data; //Field offset: 0x0

	public List<T> Items
	{
		 get { } //Length: 536
	}

	public UnsafeHashSetDebuggerTypeProxy`1(UnsafeHashSet<T> data) { }

	public List<T> get_Items() { }

}

