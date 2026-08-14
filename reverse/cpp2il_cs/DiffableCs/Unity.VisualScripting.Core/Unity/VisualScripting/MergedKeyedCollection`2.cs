namespace Unity.VisualScripting;

[DefaultMember("Item")]
public class MergedKeyedCollection : IMergedCollection<TItem>, ICollection<TItem>, IEnumerable<TItem>, IEnumerable
{
	internal struct Enumerator : IEnumerator<TItem>, IEnumerator, IDisposable
	{
		private Enumerator<Type, IKeyedCollection<TKey, TItem>> collectionsEnumerator; //Field offset: 0x0
		private TItem currentItem; //Field offset: 0x0
		private IKeyedCollection<TKey, TItem> currentCollection; //Field offset: 0x0
		private int indexInCurrentCollection; //Field offset: 0x0
		private bool exceeded; //Field offset: 0x0

		public override TItem Current
		{
			 get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 99
		}

		public Enumerator(MergedKeyedCollection<TKey, TItem> merged) { }

		public override void Dispose() { }

		public override TItem get_Current() { }

		public override bool MoveNext() { }

		private override object System.Collections.IEnumerator.get_Current() { }

		private override void System.Collections.IEnumerator.Reset() { }

	}

	protected readonly Dictionary<Type, IKeyedCollection`2<TKey, TItem>> collections; //Field offset: 0x0
	protected readonly Dictionary<Type, IKeyedCollection`2<TKey, TItem>> collectionsLookup; //Field offset: 0x0

	public override int Count
	{
		 get { } //Length: 488
	}

	public override bool IsReadOnly
	{
		 get { } //Length: 3
	}

	public TItem Item
	{
		 get { } //Length: 627
	}

	public MergedKeyedCollection`2() { }

	public override void Add(TItem item) { }

	public override void Clear() { }

	public bool Contains(TKey key) { }

	public override bool Contains(TItem item) { }

	public override void CopyTo(TItem[] array, int arrayIndex) { }

	public IKeyedCollection<TKey, TSubItem> ForType() { }

	public override int get_Count() { }

	public override bool get_IsReadOnly() { }

	public TItem get_Item(TKey key) { }

	protected IKeyedCollection<TKey, TItem> GetCollectionForItem(TItem item) { }

	protected IKeyedCollection<TKey, TItem> GetCollectionForKey(TKey key, bool throwOnFail = true) { }

	protected IKeyedCollection<TKey, TItem> GetCollectionForType(Type type, bool throwOnFail = true) { }

	public Enumerator<TKey, TItem> GetEnumerator() { }

	public override void Include(IKeyedCollection<TKey, TSubItem> collection) { }

	public override bool Includes(Type elementType) { }

	public override bool Includes() { }

	public override bool Remove(TItem item) { }

	public bool Remove(TKey key) { }

	private override IEnumerator<TItem> System.Collections.Generic.IEnumerable<TItem>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public bool TryGetValue(TKey key, out TItem value) { }

}

