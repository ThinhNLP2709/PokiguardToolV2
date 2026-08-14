namespace Unity.Properties;

public interface ICollectionPropertyBagAccept
{

	public void Accept(ICollectionPropertyBagVisitor visitor, ref TContainer container) { }

}

