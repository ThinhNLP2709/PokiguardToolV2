namespace Unity.VisualScripting;

public abstract class GraphElement : IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private Guid <guid>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private TGraph <graph>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	public override int dependencyOrder
	{
		 get { } //Length: 3
	}

	public override IEnumerable<ISerializationDependency> deserializationDependencies
	{
		 get { } //Length: 48
	}

	[DoNotSerialize]
	public TGraph graph
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	[Serialize]
	public override Guid guid
	{
		[CompilerGenerated]
		 get { } //Length: 11
		[CompilerGenerated]
		 set { } //Length: 8
	}

	[DoNotSerialize]
	private override IGraph Unity.VisualScripting.IGraphElement.graph
	{
		private get { } //Length: 5
		private set { } //Length: 238
	}

	[DoNotSerialize]
	private override IGraph Unity.VisualScripting.IGraphItem.graph
	{
		private get { } //Length: 5
	}

	protected GraphElement`1() { }

	public override void AfterAdd() { }

	public override void AfterRemove() { }

	public override void BeforeAdd() { }

	public override void BeforeRemove() { }

	protected void CopyFrom(GraphElement<TGraph> source) { }

	public override void Dispose() { }

	public override int get_dependencyOrder() { }

	public override IEnumerable<ISerializationDependency> get_deserializationDependencies() { }

	[CompilerGenerated]
	public TGraph get_graph() { }

	[CompilerGenerated]
	public override Guid get_guid() { }

	public override AnalyticsIdentifier GetAnalyticsIdentifier() { }

	public override IEnumerable<Object> GetAotStubs(HashSet<Object> visited) { }

	public override bool HandleDependencies() { }

	public override void Instantiate(GraphReference instance) { }

	protected void InstantiateNest() { }

	public override void Prewarm() { }

	[CompilerGenerated]
	public void set_graph(TGraph value) { }

	[CompilerGenerated]
	public override void set_guid(Guid value) { }

	public virtual string ToString() { }

	public override void Uninstantiate(GraphReference instance) { }

	protected void UninstantiateNest() { }

	private override IGraph Unity.VisualScripting.IGraphElement.get_graph() { }

	private override void Unity.VisualScripting.IGraphElement.set_graph(IGraph value) { }

	private override IGraph Unity.VisualScripting.IGraphItem.get_graph() { }

}

