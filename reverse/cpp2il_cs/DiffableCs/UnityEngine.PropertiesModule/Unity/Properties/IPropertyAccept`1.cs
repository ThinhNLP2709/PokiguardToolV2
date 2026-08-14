namespace Unity.Properties;

public interface IPropertyAccept
{

	public void Accept(IPropertyVisitor visitor, ref TContainer container) { }

}

