namespace UnityEngine.Rendering;

[DefaultMember("Item")]
public class ObservableList : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
	private IList<T> m_List; //Field offset: 0x0
	[CompilerGenerated]
	private ListChangedEventHandler<T> ItemAdded; //Field offset: 0x0
	[CompilerGenerated]
	private ListChangedEventHandler<T> ItemRemoved; //Field offset: 0x0

	public event ListChangedEventHandler<T> ItemAdded
	{
		[CompilerGenerated]
		 add { } //Length: 192
		[CompilerGenerated]
		 remove { } //Length: 192
	}

	public event ListChangedEventHandler<T> ItemRemoved
	{
		[CompilerGenerated]
		 add { } //Length: 192
		[CompilerGenerated]
		 remove { } //Length: 192
	}

	public override int Count
	{
		 get { } //Length: 70
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 3
	}

	public override T Item
	{
		 get { } //Length: 84
		 set { } //Length: 270
	}

	public ObservableList`1() { }

	public ObservableList`1(int capacity) { }

	public ObservableList`1(IEnumerable<T> collection) { }

	public override void Add(T item) { }

	public void Add(T[] items) { }

	[CompilerGenerated]
	public void add_ItemAdded(ListChangedEventHandler<T> value) { }

	[CompilerGenerated]
	public void add_ItemRemoved(ListChangedEventHandler<T> value) { }

	public override void Clear() { }

	public override bool Contains(T item) { }

	public override void CopyTo(T[] array, int arrayIndex) { }

	public override int get_Count() { }

	public override bool get_IsReadOnly() { }

	public override T get_Item(int index) { }

	public override IEnumerator<T> GetEnumerator() { }

	public override int IndexOf(T item) { }

	public override void Insert(int index, T item) { }

	private void OnEvent(ListChangedEventHandler<T> e, int index, T item) { }

	public override bool Remove(T item) { }

	public int Remove(T[] items) { }

	[CompilerGenerated]
	public void remove_ItemAdded(ListChangedEventHandler<T> value) { }

	[CompilerGenerated]
	public void remove_ItemRemoved(ListChangedEventHandler<T> value) { }

	public override void RemoveAt(int index) { }

	public override void set_Item(int index, T value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

