namespace Unity.Properties;

public class IndexedCollectionPropertyBag : PropertyBag<TList>, IListPropertyBag<TList, TElement>, ICollectionPropertyBag<TList, TElement>, IPropertyBag<TList>, IPropertyBag, ICollectionPropertyBagAccept<TList>, IListPropertyBagAccept<TList>, IListPropertyAccept<TList>, IIndexedProperties<TList>, IConstructorWithCount<TList>, IConstructor, IIndexedCollectionPropertyBagEnumerator<TList>
{
	private class ListElementProperty : Property<TList, TElement>, IListElementProperty
	{
		internal int m_Index; //Field offset: 0x0
		internal bool m_IsReadOnly; //Field offset: 0x0

		public override int Index
		{
			 get { } //Length: 4
		}

		public virtual bool IsReadOnly
		{
			 get { } //Length: 5
		}

		public virtual string Name
		{
			 get { } //Length: 33
		}

		public ListElementProperty() { }

		public override int get_Index() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual TElement GetValue(ref TList container) { }

		public virtual void SetValue(ref TList container, TElement value) { }

	}

	private readonly ListElementProperty<TList, TElement> m_Property; //Field offset: 0x0

	public IndexedCollectionPropertyBag`2() { }

	public virtual PropertyCollection<TList> GetProperties() { }

	public virtual PropertyCollection<TList> GetProperties(ref TList container) { }

	protected override TList InstantiateWithCount(int count) { }

	public override bool TryGetProperty(ref TList container, int index, out IProperty<TList>& property) { }

	private override void Unity.Properties.ICollectionPropertyBagAccept<TList>.Accept(ICollectionPropertyBagVisitor visitor, ref TList container) { }

	private override TList Unity.Properties.IConstructorWithCount<TList>.InstantiateWithCount(int count) { }

	private override int Unity.Properties.IIndexedCollectionPropertyBagEnumerator<TList>.GetCount(ref TList container) { }

	private override IProperty<TList> Unity.Properties.IIndexedCollectionPropertyBagEnumerator<TList>.GetSharedProperty() { }

	private override IndexedCollectionSharedPropertyState Unity.Properties.IIndexedCollectionPropertyBagEnumerator<TList>.GetSharedPropertyState() { }

	private override void Unity.Properties.IIndexedCollectionPropertyBagEnumerator<TList>.SetSharedPropertyState(IndexedCollectionSharedPropertyState state) { }

	private override void Unity.Properties.IListPropertyAccept<TList>.Accept(IListPropertyVisitor visitor, Property<TContainer, TList> property, ref TContainer container, ref TList list) { }

	private override void Unity.Properties.IListPropertyBagAccept<TList>.Accept(IListPropertyBagVisitor visitor, ref TList list) { }

}

