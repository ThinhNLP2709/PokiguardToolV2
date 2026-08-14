namespace UnityEngine.UIElements.Layout;

[DefaultMember("Item")]
internal struct LayoutList : IDisposable
{
	private struct Data
	{
		public int Capacity; //Field offset: 0x0
		public int Count; //Field offset: 0x0
		public T* Values; //Field offset: 0x0

	}

	private readonly Allocator m_Allocator; //Field offset: 0x0
	private Data<T>* m_Data; //Field offset: 0x0

	public int Count
	{
		 get { } //Length: 26
	}

	public bool IsCreated
	{
		 get { } //Length: 9
	}

	public T Item
	{
		 get { } //Length: 110
	}

	public LayoutList`1() { }

	public LayoutList`1(int initialCapacity, Allocator allocator) { }

	public override void Dispose() { }

	private void EnsureCapacity(int capacity) { }

	public int get_Count() { }

	public bool get_IsCreated() { }

	public T get_Item(int index) { }

	private void IncreaseCapacity() { }

	public void Insert(int index, T value) { }

	public void RemoveAt(int index) { }

	private static Void* ResizeArray(Void* fromPtr, long fromCount, long toCount, long size, int align, Allocator allocator) { }

	private void ResizeCapacity(int capacity) { }

}

