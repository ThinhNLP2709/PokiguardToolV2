namespace Unity.VisualScripting;

public class WatchedList : Collection<T>, INotifyCollectionChanged<T>
{
	[CompilerGenerated]
	private Action<T> ItemAdded; //Field offset: 0x0
	[CompilerGenerated]
	private Action<T> ItemRemoved; //Field offset: 0x0
	[CompilerGenerated]
	private Action CollectionChanged; //Field offset: 0x0

	public override event Action CollectionChanged
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public override event Action<T> ItemAdded
	{
		[CompilerGenerated]
		 add { } //Length: 192
		[CompilerGenerated]
		 remove { } //Length: 192
	}

	public override event Action<T> ItemRemoved
	{
		[CompilerGenerated]
		 add { } //Length: 192
		[CompilerGenerated]
		 remove { } //Length: 192
	}

	public WatchedList`1() { }

	[CompilerGenerated]
	public override void add_CollectionChanged(Action value) { }

	[CompilerGenerated]
	public override void add_ItemAdded(Action<T> value) { }

	[CompilerGenerated]
	public override void add_ItemRemoved(Action<T> value) { }

	protected virtual void ClearItems() { }

	protected virtual void InsertItem(int index, T item) { }

	[CompilerGenerated]
	public override void remove_CollectionChanged(Action value) { }

	[CompilerGenerated]
	public override void remove_ItemAdded(Action<T> value) { }

	[CompilerGenerated]
	public override void remove_ItemRemoved(Action<T> value) { }

	protected virtual void RemoveItem(int index) { }

}

