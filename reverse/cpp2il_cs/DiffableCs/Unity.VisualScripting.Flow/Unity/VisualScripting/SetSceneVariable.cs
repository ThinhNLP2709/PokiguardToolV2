namespace Unity.VisualScripting;

[UnitSurtitle("Scene")]
public sealed class SetSceneVariable : SetVariableUnit, ISceneVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public SetSceneVariable() { }

	public SetSceneVariable(string defaultName) { }

	protected virtual VariableDeclarations GetDeclarations(Flow flow) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

