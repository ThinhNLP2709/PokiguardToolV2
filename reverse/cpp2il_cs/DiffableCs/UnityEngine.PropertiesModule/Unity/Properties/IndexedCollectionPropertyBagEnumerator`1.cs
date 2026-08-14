namespace Unity.Properties;

internal struct IndexedCollectionPropertyBagEnumerator : IEnumerator<IProperty`1<TContainer>>, IEnumerator, IDisposable
{
	private readonly IIndexedCollectionPropertyBagEnumerator<TContainer> m_Impl; //Field offset: 0x0
	private readonly IndexedCollectionSharedPropertyState m_Previous; //Field offset: 0x0
	private TContainer m_Container; //Field offset: 0x0
	private int m_Position; //Field offset: 0x0

	public override IProperty<TContainer> Current
	{
		 get { } //Length: 88
	}

	private override object System.Collections.IEnumerator.Current
	{
		private get { } //Length: 123
	}

	internal IndexedCollectionPropertyBagEnumerator`1(IIndexedCollectionPropertyBagEnumerator<TContainer> impl, TContainer container) { }

	public override void Dispose() { }

	public override IProperty<TContainer> get_Current() { }

	public override bool MoveNext() { }

	public override void Reset() { }

	private override object System.Collections.IEnumerator.get_Current() { }

}

