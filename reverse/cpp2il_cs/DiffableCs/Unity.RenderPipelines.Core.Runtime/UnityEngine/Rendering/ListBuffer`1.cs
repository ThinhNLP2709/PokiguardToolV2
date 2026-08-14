namespace UnityEngine.Rendering;

[DefaultMember("Item")]
public struct ListBuffer
{
	private T* m_BufferPtr; //Field offset: 0x0
	private int m_Capacity; //Field offset: 0x0
	private Int32* m_CountPtr; //Field offset: 0x0

	internal T* BufferPtr
	{
		internal get { } //Length: 4
	}

	public int Capacity
	{
		 get { } //Length: 4
	}

	public int Count
	{
		 get { } //Length: 7
	}

	public T Item
	{
		 get { } //Length: 386
	}

	public ListBuffer`1(T* bufferPtr, Int32* countPtr, int capacity) { }

	public void CopyTo(T* dstBuffer, int startDstIndex, int copyCount) { }

	internal T* get_BufferPtr() { }

	public int get_Capacity() { }

	public int get_Count() { }

	public T get_Item(in int index) { }

	public T GetUnchecked(in int index) { }

	public bool TryAdd(in T value) { }

	public bool TryCopyFrom(T* srcPtr, int count) { }

	public bool TryCopyTo(ListBuffer<T> other) { }

}

