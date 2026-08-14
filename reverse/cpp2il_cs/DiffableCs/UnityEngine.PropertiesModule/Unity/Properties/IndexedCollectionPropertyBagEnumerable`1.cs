namespace Unity.Properties;

[IsReadOnly]
internal struct IndexedCollectionPropertyBagEnumerable
{
	private readonly IIndexedCollectionPropertyBagEnumerator<TContainer> m_Impl; //Field offset: 0x0
	private readonly TContainer m_Container; //Field offset: 0x0

	public IndexedCollectionPropertyBagEnumerable`1(IIndexedCollectionPropertyBagEnumerator<TContainer> impl, TContainer container) { }

	public IndexedCollectionPropertyBagEnumerator<TContainer> GetEnumerator() { }

}

