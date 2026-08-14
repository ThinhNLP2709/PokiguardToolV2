namespace Unity.Collections;

internal sealed class NativeRingQueueDebugView
{
	private UnsafeRingQueue<T>* Data; //Field offset: 0x0

	public T[] Items
	{
		 get { } //Length: 430
	}

	public NativeRingQueueDebugView`1(NativeRingQueue<T> data) { }

	public T[] get_Items() { }

}

