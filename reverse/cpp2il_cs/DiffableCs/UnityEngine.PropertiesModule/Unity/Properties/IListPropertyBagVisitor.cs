namespace Unity.Properties;

public interface IListPropertyBagVisitor
{

	public void Visit(IListPropertyBag<TList, TElement> properties, ref TList container) { }

}

