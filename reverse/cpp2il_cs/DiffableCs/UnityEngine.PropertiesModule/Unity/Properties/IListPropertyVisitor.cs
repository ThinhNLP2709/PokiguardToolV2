namespace Unity.Properties;

public interface IListPropertyVisitor
{

	public void Visit(Property<TContainer, TList> property, ref TContainer container, ref TList list) { }

}

