namespace Unity.Properties;

public interface IPropertyVisitor
{

	public void Visit(Property<TContainer, TValue> property, ref TContainer container) { }

}

