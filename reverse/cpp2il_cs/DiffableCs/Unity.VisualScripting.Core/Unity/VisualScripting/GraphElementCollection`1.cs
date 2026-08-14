namespace Unity.VisualScripting;

public sealed class GraphElementCollection : GuidCollection<TElement>, IGraphElementCollection<TElement>, IKeyedCollection<Guid, TElement>, ICollection<TElement>, IEnumerable<TElement>, IEnumerable, INotifyCollectionChanged<TElement>, IProxyableNotifyCollectionChanged<TElement>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c<TElement> <>9; //Field offset: 0x0
		public static Comparison<TElement> <>9__23_0; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal int <ClearItems>b__23_0(TElement a, TElement b) { }

	}

	[CompilerGenerated]
	private readonly IGraph <graph>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private Action<TElement> ItemAdded; //Field offset: 0x0
	[CompilerGenerated]
	private Action<TElement> ItemRemoved; //Field offset: 0x0
	[CompilerGenerated]
	private Action CollectionChanged; //Field offset: 0x0
	[CompilerGenerated]
	private bool <ProxyCollectionChange>k__BackingField; //Field offset: 0x0

	public override event Action CollectionChanged
	{
		[CompilerGenerated]
		 add { } //Length: 158
		[CompilerGenerated]
		 remove { } //Length: 158
	}

	public override event Action<TElement> ItemAdded
	{
		[CompilerGenerated]
		 add { } //Length: 192
		[CompilerGenerated]
		 remove { } //Length: 192
	}

	public override event Action<TElement> ItemRemoved
	{
		[CompilerGenerated]
		 add { } //Length: 192
		[CompilerGenerated]
		 remove { } //Length: 192
	}

	public IGraph graph
	{
		[CompilerGenerated]
		 get { } //Length: 5
	}

	public override bool ProxyCollectionChange
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public GraphElementCollection`1(IGraph graph) { }

	[CompilerGenerated]
	public override void add_CollectionChanged(Action value) { }

	[CompilerGenerated]
	public override void add_ItemAdded(Action<TElement> value) { }

	[CompilerGenerated]
	public override void add_ItemRemoved(Action<TElement> value) { }

	public override void AfterAdd(TElement element) { }

	public override void AfterRemove(TElement element) { }

	public override void BeforeAdd(TElement element) { }

	public override void BeforeRemove(TElement element) { }

	protected virtual void ClearItems() { }

	[CompilerGenerated]
	public IGraph get_graph() { }

	[CompilerGenerated]
	public override bool get_ProxyCollectionChange() { }

	public NoAllocEnumerator<TElement> GetEnumerator() { }

	protected virtual void InsertItem(int index, TElement element) { }

	[CompilerGenerated]
	public override void remove_CollectionChanged(Action value) { }

	[CompilerGenerated]
	public override void remove_ItemAdded(Action<TElement> value) { }

	[CompilerGenerated]
	public override void remove_ItemRemoved(Action<TElement> value) { }

	protected virtual void RemoveItem(int index) { }

	[CompilerGenerated]
	public override void set_ProxyCollectionChange(bool value) { }

	protected virtual void SetItem(int index, TElement item) { }

	private override bool Unity.VisualScripting.IKeyedCollection<System.Guid,TElement>.Contains(Guid key) { }

	private override TElement Unity.VisualScripting.IKeyedCollection<System.Guid,TElement>.get_Item(Guid key) { }

	private override bool Unity.VisualScripting.IKeyedCollection<System.Guid,TElement>.Remove(Guid key) { }

}

