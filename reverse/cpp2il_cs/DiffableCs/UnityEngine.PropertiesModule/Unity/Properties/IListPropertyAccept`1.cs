namespace Unity.Properties;

public interface IListPropertyAccept
{

	public void Accept(IListPropertyVisitor visitor, Property<TContainer, TList> property, ref TContainer container, ref TList list) { }

}

