namespace Unity.Properties;

internal interface IIndexedCollectionPropertyBagEnumerator
{

	public int GetCount(ref TContainer container) { }

	public IProperty<TContainer> GetSharedProperty() { }

	public IndexedCollectionSharedPropertyState GetSharedPropertyState() { }

	public void SetSharedPropertyState(IndexedCollectionSharedPropertyState state) { }

}

