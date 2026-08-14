namespace Unity.VisualScripting;

[DefaultMember("Item")]
public class NonNullableList : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
{
	private readonly List<T> list; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 46
	}

	public override bool IsFixedSize
	{
		 get { } //Length: 73
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 3
	}

	public override bool IsSynchronized
	{
		 get { } //Length: 73
	}

	public override T Item
	{
		 get { } //Length: 194
		 set { } //Length: 401
	}

	public override object SyncRoot
	{
		 get { } //Length: 73
	}

	private override object System.Collections.IList.Item
	{
		private get { } //Length: 84
		private set { } //Length: 106
	}

	public NonNullableList`1() { }

	public NonNullableList`1(int capacity) { }

	public NonNullableList`1(IEnumerable<T> collection) { }

	public override void Add(T item) { }

	public override int Add(object value) { }

	public void AddRange(IEnumerable<T> collection) { }

	public override void Clear() { }

	public override bool Contains(T item) { }

	public override bool Contains(object value) { }

	public override void CopyTo(Array array, int index) { }

	public override void CopyTo(T[] array, int arrayIndex) { }

	public override int get_Count() { }

	public override bool get_IsFixedSize() { }

	public override bool get_IsReadOnly() { }

	public override bool get_IsSynchronized() { }

	public override T get_Item(int index) { }

	public override object get_SyncRoot() { }

	public override IEnumerator<T> GetEnumerator() { }

	public override int IndexOf(T item) { }

	public override int IndexOf(object value) { }

	public override void Insert(int index, T item) { }

	public override void Insert(int index, object value) { }

	public override void Remove(object value) { }

	public override bool Remove(T item) { }

	public override void RemoveAt(int index) { }

	public override void set_Item(int index, T value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	private override object System.Collections.IList.get_Item(int index) { }

	private override void System.Collections.IList.set_Item(int index, object value) { }

}

