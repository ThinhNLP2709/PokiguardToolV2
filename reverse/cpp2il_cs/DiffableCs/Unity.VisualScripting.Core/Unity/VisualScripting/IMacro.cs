namespace Unity.VisualScripting;

public interface IMacro : IGraphRoot, IGraphParent, ISerializationDependency, ISerializationCallbackReceiver, IAotStubbable
{

	public IGraph graph
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IGraph get_graph() { }

	public void set_graph(IGraph value) { }

}

