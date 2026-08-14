namespace Unity.Properties;

public interface INamedProperties
{

	public bool TryGetProperty(ref TContainer container, string name, out IProperty<TContainer>& property) { }

}

