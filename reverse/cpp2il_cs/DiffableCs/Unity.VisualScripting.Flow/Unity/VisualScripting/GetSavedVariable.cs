namespace Unity.VisualScripting;

[UnitSurtitle("Save")]
public sealed class GetSavedVariable : GetVariableUnit, ISavedVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public GetSavedVariable() { }

	public GetSavedVariable(string defaultName) { }

	protected virtual VariableDeclarations GetDeclarations(Flow flow) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

