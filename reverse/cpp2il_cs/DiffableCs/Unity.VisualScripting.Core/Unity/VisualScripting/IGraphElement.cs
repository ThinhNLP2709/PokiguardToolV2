namespace Unity.VisualScripting;

public interface IGraphElement : IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public int dependencyOrder
	{
		 get { } //Length: 0
	}

	public IEnumerable<ISerializationDependency> deserializationDependencies
	{
		 get { } //Length: 0
	}

	public IGraph graph
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Guid guid
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int get_dependencyOrder() { }

	public IEnumerable<ISerializationDependency> get_deserializationDependencies() { }

	public IGraph get_graph() { }

	public Guid get_guid() { }

	public bool HandleDependencies() { }

	public void Instantiate(GraphReference instance) { }

	public void set_graph(IGraph value) { }

	public void set_guid(Guid value) { }

	public void Uninstantiate(GraphReference instance) { }

}

