namespace Unity.VisualScripting;

public interface IGraphNester : IGraphParent
{

	public IGraphNest nest
	{
		 get { } //Length: 0
	}

	public IGraphNest get_nest() { }

	public void InstantiateNest() { }

	public void UninstantiateNest() { }

}

