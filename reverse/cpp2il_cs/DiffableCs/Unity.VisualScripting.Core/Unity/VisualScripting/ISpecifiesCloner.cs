namespace Unity.VisualScripting;

public interface ISpecifiesCloner
{

	public ICloner cloner
	{
		 get { } //Length: 0
	}

	public ICloner get_cloner() { }

}

