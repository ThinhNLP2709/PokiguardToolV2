namespace Unity.VisualScripting;

[UnitSurtitle("Graph")]
public sealed class IsGraphVariableDefined : IsVariableDefinedUnit, IGraphVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public IsGraphVariableDefined() { }

	public IsGraphVariableDefined(string defaultName) { }

	protected virtual VariableDeclarations GetDeclarations(Flow flow) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

