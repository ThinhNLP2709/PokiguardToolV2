namespace UnityEngine.Rendering;

[DebuggerDisplay("Size = {size} Capacity = {capacity}")]
[DefaultMember("Item")]
public class DynamicArray
{
	internal struct Iterator
	{
		private readonly DynamicArray<T> owner; //Field offset: 0x0
		private int index; //Field offset: 0x0

		public T Current
		{
			 get { } //Length: 78
		}

		public Iterator(DynamicArray<T> setOwner) { }

		public T get_Current() { }

		public bool MoveNext() { }

		public void Reset() { }

	}

	internal struct RangeEnumerable
	{
		internal struct RangeIterator
		{
			private readonly DynamicArray<T> owner; //Field offset: 0x0
			private int index; //Field offset: 0x0
			private int first; //Field offset: 0x0
			private int last; //Field offset: 0x0

			public T Current
			{
				 get { } //Length: 78
			}

			public RangeIterator(DynamicArray<T> setOwner, int first, int numItems) { }

			public T get_Current() { }

			public bool MoveNext() { }

			public void Reset() { }

		}

		public RangeIterator<T> iterator; //Field offset: 0x0

		public RangeIterator<T> GetEnumerator() { }

	}

	internal sealed class SortComparer : MulticastDelegate
	{

		public SortComparer(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(T x, T y, AsyncCallback callback, object object) { }

		public override int EndInvoke(IAsyncResult result) { }

		public override int Invoke(T x, T y) { }

	}

	protected T[] m_Array; //Field offset: 0x0
	[CompilerGenerated]
	private int <size>k__BackingField; //Field offset: 0x0

	public int capacity
	{
		 get { } //Length: 26
	}

	public T Item
	{
		 get { } //Length: 49
	}

	public int size
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public DynamicArray`1() { }

	public DynamicArray`1(int size) { }

	public DynamicArray`1(int capacity, bool resize) { }

	public DynamicArray`1(DynamicArray<T> deepCopy) { }

	public int Add(in T value) { }

	public void AddRange(DynamicArray<T> array) { }

	protected private void BumpVersion() { }

	public void Clear() { }

	public bool Contains(T item) { }

	public int FindIndex(int startIndex, int count, Predicate<T> match) { }

	public int get_capacity() { }

	public T get_Item(int index) { }

	[CompilerGenerated]
	public int get_size() { }

	public Iterator<T> GetEnumerator() { }

	public int IndexOf(T item, int index, int count) { }

	public int IndexOf(T item, int index) { }

	public int IndexOf(T item) { }

	public void Insert(int index, T item) { }

	[Obsolete("This is deprecated because it returns an incorrect value. It may returns an array with elements beyond the size. Please use Span/ReadOnly if you want safe raw access to the DynamicArray memory.", False)]
	public static T[] op_Implicit(DynamicArray<T> array) { }

	public static ReadOnlySpan<T> op_Implicit(DynamicArray<T> array) { }

	public static Span<T> op_Implicit(DynamicArray<T> array) { }

	public bool Remove(T item) { }

	public void RemoveAt(int index) { }

	public void RemoveRange(int index, int count) { }

	public void Reserve(int newCapacity, bool keepContent = false) { }

	public void Resize(int newSize, bool keepContent = false) { }

	public void ResizeAndClear(int newSize) { }

	[CompilerGenerated]
	protected void set_size(int value) { }

	public RangeEnumerable<T> SubRange(int first, int numItems) { }

}

