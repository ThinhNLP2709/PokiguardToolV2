namespace Unity.Properties;

public interface IDictionaryPropertyBagAccept
{

	public void Accept(IDictionaryPropertyBagVisitor visitor, ref TContainer container) { }

}

