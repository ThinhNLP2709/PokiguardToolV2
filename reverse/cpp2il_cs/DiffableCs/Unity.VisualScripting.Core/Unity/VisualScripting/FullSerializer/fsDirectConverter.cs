namespace Unity.VisualScripting.FullSerializer;

public abstract class fsDirectConverter : fsBaseConverter
{

	public abstract Type ModelType
	{
		 get { } //Length: 0
	}

	protected fsDirectConverter() { }

	public abstract Type get_ModelType() { }

}

