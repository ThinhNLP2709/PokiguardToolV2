namespace Unity.Properties;

public interface IPropertyBagVisitor
{

	public void Visit(IPropertyBag<TContainer> properties, ref TContainer container) { }

}

