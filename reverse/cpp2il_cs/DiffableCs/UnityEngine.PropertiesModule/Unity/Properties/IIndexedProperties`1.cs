namespace Unity.Properties;

public interface IIndexedProperties
{

	public bool TryGetProperty(ref TContainer container, int index, out IProperty<TContainer>& property) { }

}

