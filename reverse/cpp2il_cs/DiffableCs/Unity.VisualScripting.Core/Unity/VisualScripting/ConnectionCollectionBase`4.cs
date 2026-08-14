namespace Unity.VisualScripting;

[DefaultMember("Item")]
public class ConnectionCollectionBase : IConnectionCollection<TConnection, TSource, TDestination>, ICollection<TConnection>, IEnumerable<TConnection>, IEnumerable
{
	private readonly Dictionary<TDestination, List`1<TConnection>> byDestination; //Field offset: 0x0
	private readonly Dictionary<TSource, List`1<TConnection>> bySource; //Field offset: 0x0
	protected readonly TCollection collection; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 177
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 3
	}

	public override IEnumerable<TConnection> Item
	{
		 get { } //Length: 364
	}

	public override IEnumerable<TConnection> Item
	{
		 get { } //Length: 364
	}

	public ConnectionCollectionBase`4(TCollection collection) { }

	public override void Add(TConnection item) { }

	private void AddToDictionaries(TConnection item) { }

	protected override void AfterAdd(TConnection item) { }

	protected override void AfterRemove(TConnection item) { }

	protected override void BeforeAdd(TConnection item) { }

	protected override void BeforeRemove(TConnection item) { }

	public override void Clear() { }

	public override bool Contains(TConnection item) { }

	public override void CopyTo(TConnection[] array, int arrayIndex) { }

	public override int get_Count() { }

	public override bool get_IsReadOnly() { }

	public override IEnumerable<TConnection> get_Item(TSource source) { }

	public override IEnumerable<TConnection> get_Item(TDestination destination) { }

	public override IEnumerator<TConnection> GetEnumerator() { }

	public override bool Remove(TConnection item) { }

	private void RemoveFromDictionaries(TConnection item) { }

	public TConnection SingleOrDefaultWithDestination(TDestination destination) { }

	public TConnection SingleOrDefaultWithSource(TSource source) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public override IEnumerable<TConnection> WithDestination(TDestination destination) { }

	public List<TConnection> WithDestinationNoAlloc(TDestination destination) { }

	public override IEnumerable<TConnection> WithSource(TSource source) { }

	public List<TConnection> WithSourceNoAlloc(TSource source) { }

}

