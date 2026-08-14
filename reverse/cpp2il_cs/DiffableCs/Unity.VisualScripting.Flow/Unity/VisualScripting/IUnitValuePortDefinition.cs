namespace Unity.VisualScripting;

public interface IUnitValuePortDefinition : IUnitPortDefinition
{

	public Type type
	{
		 get { } //Length: 0
	}

	public Type get_type() { }

}

