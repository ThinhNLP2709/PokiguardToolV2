namespace Unity.Properties;

public interface ISetPropertyBagAccept
{

	public void Accept(ISetPropertyBagVisitor visitor, ref TContainer container) { }

}

