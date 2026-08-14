namespace Unity.VisualScripting;

public interface IGraphParent
{

	public IGraph childGraph
	{
		 get { } //Length: 0
	}

	public bool isSerializationRoot
	{
		 get { } //Length: 0
	}

	public object serializedObject
	{
		 get { } //Length: 0
	}

	public IGraph DefaultGraph() { }

	public IGraph get_childGraph() { }

	public bool get_isSerializationRoot() { }

	public object get_serializedObject() { }

}

