namespace Unity.VisualScripting;

public interface IUnitValuePort : IUnitPort, IGraphItem
{

	public Type type
	{
		 get { } //Length: 0
	}

	public Type get_type() { }

}

