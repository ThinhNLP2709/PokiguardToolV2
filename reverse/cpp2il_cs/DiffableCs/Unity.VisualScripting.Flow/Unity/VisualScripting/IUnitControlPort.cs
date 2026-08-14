namespace Unity.VisualScripting;

public interface IUnitControlPort : IUnitPort, IGraphItem
{

	public bool couldBeEntered
	{
		 get { } //Length: 0
	}

	public bool isPredictable
	{
		 get { } //Length: 0
	}

	public bool get_couldBeEntered() { }

	public bool get_isPredictable() { }

}

