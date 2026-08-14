namespace Unity.VisualScripting;

[UnitSurtitle("Scene")]
public sealed class GetSceneVariable : GetVariableUnit, ISceneVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public GetSceneVariable() { }

	public GetSceneVariable(string defaultName) { }

	protected virtual VariableDeclarations GetDeclarations(Flow flow) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

