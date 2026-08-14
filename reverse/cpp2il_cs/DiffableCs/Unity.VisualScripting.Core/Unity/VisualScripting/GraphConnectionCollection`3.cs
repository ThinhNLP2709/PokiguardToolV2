namespace Unity.VisualScripting;

public class GraphConnectionCollection : ConnectionCollectionBase<TConnection, TSource, TDestination, GraphElementCollection`1<TConnection>>, IGraphElementCollection<TConnection>, IKeyedCollection<Guid, TConnection>, ICollection<TConnection>, IEnumerable<TConnection>, IEnumerable, INotifyCollectionChanged<TConnection>
{

	public override event Action CollectionChanged
	{
		 add { } //Length: 180
		 remove { } //Length: 180
	}

	public override event Action<TConnection> ItemAdded
	{
		 add { } //Length: 236
		 remove { } //Length: 236
	}

	public override event Action<TConnection> ItemRemoved
	{
		 add { } //Length: 236
		 remove { } //Length: 236
	}

	private override TConnection Unity.VisualScripting.IKeyedCollection<System.Guid,TConnection>.Item
	{
		private get { } //Length: 56
	}

	private override TConnection Unity.VisualScripting.IKeyedCollection<System.Guid,TConnection>.Item
	{
		private get { } //Length: 42
	}

	public GraphConnectionCollection`3(IGraph graph) { }

	public override void add_CollectionChanged(Action value) { }

	public override void add_ItemAdded(Action<TConnection> value) { }

	public override void add_ItemRemoved(Action<TConnection> value) { }

	protected virtual void AfterAdd(TConnection item) { }

	protected virtual void AfterRemove(TConnection item) { }

	protected virtual void BeforeAdd(TConnection item) { }

	protected virtual void BeforeRemove(TConnection item) { }

	public override bool Contains(Guid key) { }

	public override bool Remove(Guid key) { }

	public override void remove_CollectionChanged(Action value) { }

	public override void remove_ItemAdded(Action<TConnection> value) { }

	public override void remove_ItemRemoved(Action<TConnection> value) { }

	public override bool TryGetValue(Guid key, out TConnection value) { }

	private override TConnection Unity.VisualScripting.IKeyedCollection<System.Guid,TConnection>.get_Item(Guid key) { }

	private override TConnection Unity.VisualScripting.IKeyedCollection<System.Guid,TConnection>.get_Item(int index) { }

}

