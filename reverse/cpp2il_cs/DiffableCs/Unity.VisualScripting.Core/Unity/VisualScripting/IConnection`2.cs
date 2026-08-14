namespace Unity.VisualScripting;

public interface IConnection
{

	public TDestination destination
	{
		 get { } //Length: 0
	}

	public TSource source
	{
		 get { } //Length: 0
	}

	public TDestination get_destination() { }

	public TSource get_source() { }

}

