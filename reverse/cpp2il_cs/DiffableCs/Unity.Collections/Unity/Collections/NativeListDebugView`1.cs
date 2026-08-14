namespace Unity.Collections;

internal sealed class NativeListDebugView
{
	private UnsafeList<T>* Data; //Field offset: 0x0

	public T[] Items
	{
		 get { } //Length: 228
	}

	public NativeListDebugView`1(NativeList<T> array) { }

	public T[] get_Items() { }

}

