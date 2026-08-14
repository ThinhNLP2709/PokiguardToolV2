namespace Unity.Properties;

public interface ICollectionPropertyBagVisitor
{

	public void Visit(ICollectionPropertyBag<TCollection, TElement> properties, ref TCollection container) { }

}

