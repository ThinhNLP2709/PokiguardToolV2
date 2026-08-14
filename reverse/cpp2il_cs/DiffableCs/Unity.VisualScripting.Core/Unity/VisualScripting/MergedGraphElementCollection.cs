namespace Unity.VisualScripting;

public sealed class MergedGraphElementCollection : MergedKeyedCollection<Guid, IGraphElement>, INotifyCollectionChanged<IGraphElement>
{
	[CompilerGenerated]
	private Action<IGraphElement> ItemAdded; //Field offset: 0x20
	[CompilerGenerated]
	private Action<IGraphElement> ItemRemoved; //Field offset: 0x28
	[CompilerGenerated]
	private Action CollectionChanged; //Field offset: 0x30

	public override event Action CollectionChanged
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public override event Action<IGraphElement> ItemAdded
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public override event Action<IGraphElement> ItemRemoved
	{
		[CompilerGenerated]
		 add { } //Length: 172
		[CompilerGenerated]
		 remove { } //Length: 172
	}

	public MergedGraphElementCollection() { }

	[CompilerGenerated]
	private void <Include>b__9_0(TSubItem element) { }

	[CompilerGenerated]
	private void <Include>b__9_1(TSubItem element) { }

	[CompilerGenerated]
	private void <Include>b__9_2() { }

	[CompilerGenerated]
	public override void add_CollectionChanged(Action value) { }

	[CompilerGenerated]
	public override void add_ItemAdded(Action<IGraphElement> value) { }

	[CompilerGenerated]
	public override void add_ItemRemoved(Action<IGraphElement> value) { }

	public virtual void Include(IKeyedCollection<Guid, TSubItem> collection) { }

	[CompilerGenerated]
	public override void remove_CollectionChanged(Action value) { }

	[CompilerGenerated]
	public override void remove_ItemAdded(Action<IGraphElement> value) { }

	[CompilerGenerated]
	public override void remove_ItemRemoved(Action<IGraphElement> value) { }

}

