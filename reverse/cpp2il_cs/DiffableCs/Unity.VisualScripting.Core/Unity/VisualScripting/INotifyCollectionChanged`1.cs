namespace Unity.VisualScripting;

public interface INotifyCollectionChanged
{

	public event Action CollectionChanged
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event Action<T> ItemAdded
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event Action<T> ItemRemoved
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	[CompilerGenerated]
	public void add_CollectionChanged(Action value) { }

	[CompilerGenerated]
	public void add_ItemAdded(Action<T> value) { }

	[CompilerGenerated]
	public void add_ItemRemoved(Action<T> value) { }

	[CompilerGenerated]
	public void remove_CollectionChanged(Action value) { }

	[CompilerGenerated]
	public void remove_ItemAdded(Action<T> value) { }

	[CompilerGenerated]
	public void remove_ItemRemoved(Action<T> value) { }

}

