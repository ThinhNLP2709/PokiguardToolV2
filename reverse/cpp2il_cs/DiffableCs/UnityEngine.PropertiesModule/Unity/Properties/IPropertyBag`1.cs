namespace Unity.Properties;

public interface IPropertyBag : IPropertyBag
{

	public void Accept(IPropertyBagVisitor visitor, ref TContainer container) { }

	public PropertyCollection<TContainer> GetProperties(ref TContainer container) { }

	public PropertyCollection<TContainer> GetProperties() { }

}

