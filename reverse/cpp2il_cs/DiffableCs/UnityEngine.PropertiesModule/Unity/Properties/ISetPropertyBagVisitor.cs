namespace Unity.Properties;

public interface ISetPropertyBagVisitor
{

	public void Visit(ISetPropertyBag<TSet, TValue> properties, ref TSet container) { }

}

