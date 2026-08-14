namespace Unity.VisualScripting;

public interface IMachine : IGraphRoot, IGraphParent, IGraphNester, IAotStubbable
{

	public IGraphData graphData
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public GameObject threadSafeGameObject
	{
		 get { } //Length: 0
	}

	public IGraphData get_graphData() { }

	public GameObject get_threadSafeGameObject() { }

	public void set_graphData(IGraphData value) { }

}

