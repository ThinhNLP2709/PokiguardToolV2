namespace Unity.Properties;

public interface IKeyedProperties
{

	public bool TryGetProperty(ref TContainer container, TKey key, out IProperty<TContainer>& property) { }

}

