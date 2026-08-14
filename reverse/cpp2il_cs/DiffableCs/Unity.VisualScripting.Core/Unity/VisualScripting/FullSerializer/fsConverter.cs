namespace Unity.VisualScripting.FullSerializer;

public abstract class fsConverter : fsBaseConverter
{

	protected fsConverter() { }

	public abstract bool CanProcess(Type type) { }

}

