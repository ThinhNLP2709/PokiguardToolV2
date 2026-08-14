namespace Unity.Collections.LowLevel.Unsafe;

internal sealed class UnsafePtrListDebugView
{
	private UnsafePtrList<T> Data; //Field offset: 0x0

	public T*[] Items
	{
		 get { } //Length: 177
	}

	public UnsafePtrListDebugView`1(UnsafePtrList<T> data) { }

	public T*[] get_Items() { }

}

