namespace Unity.VisualScripting;

[SpecialUnit]
public abstract class NesterUnit : Unit, INesterUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphNesterElement, IGraphParentElement, IGraphParent, IGraphNester
{
	[CompilerGenerated]
	private GraphNest<TGraph, TMacro> <nest>k__BackingField; //Field offset: 0x0

	public virtual bool canDefine
	{
		 get { } //Length: 52
	}

	[DoNotSerialize]
	public virtual IEnumerable<ISerializationDependency> deserializationDependencies
	{
		 get { } //Length: 45
	}

	[Serialize]
	public private GraphNest<TGraph, TMacro> nest
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	private override IGraphNest Unity.VisualScripting.IGraphNester.nest
	{
		private get { } //Length: 8
	}

	[DoNotSerialize]
	private override IGraph Unity.VisualScripting.IGraphParent.childGraph
	{
		private get { } //Length: 45
	}

	[DoNotSerialize]
	private override bool Unity.VisualScripting.IGraphParent.isSerializationRoot
	{
		private get { } //Length: 33
	}

	[DoNotSerialize]
	private override object Unity.VisualScripting.IGraphParent.serializedObject
	{
		private get { } //Length: 30
	}

	protected NesterUnit`2() { }

	protected NesterUnit`2(TMacro macro) { }

	protected void CopyFrom(NesterUnit<TGraph, TMacro> source) { }

	public abstract TGraph DefaultGraph() { }

	public virtual bool get_canDefine() { }

	public virtual IEnumerable<ISerializationDependency> get_deserializationDependencies() { }

	[CompilerGenerated]
	public GraphNest<TGraph, TMacro> get_nest() { }

	public virtual IEnumerable<Object> GetAotStubs(HashSet<Object> visited) { }

	[CompilerGenerated]
	private void set_nest(GraphNest<TGraph, TMacro> value) { }

	private override IGraphNest Unity.VisualScripting.IGraphNester.get_nest() { }

	private override void Unity.VisualScripting.IGraphNester.InstantiateNest() { }

	private override void Unity.VisualScripting.IGraphNester.UninstantiateNest() { }

	private override IGraph Unity.VisualScripting.IGraphParent.DefaultGraph() { }

	private override IGraph Unity.VisualScripting.IGraphParent.get_childGraph() { }

	private override bool Unity.VisualScripting.IGraphParent.get_isSerializationRoot() { }

	private override object Unity.VisualScripting.IGraphParent.get_serializedObject() { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

