namespace Unity.Properties;

public interface IListPropertyBagAccept
{

	public void Accept(IListPropertyBagVisitor visitor, ref TContainer container) { }

}

