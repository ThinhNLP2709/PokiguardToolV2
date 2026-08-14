namespace Unity.VisualScripting;

[UnitSurtitle("Graph")]
public sealed class GetGraphVariable : GetVariableUnit, IGraphVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public GetGraphVariable() { }

	public GetGraphVariable(string defaultName) { }

	protected virtual VariableDeclarations GetDeclarations(Flow flow) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

