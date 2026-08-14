namespace Unity.VisualScripting;

[UnitSurtitle("Application")]
public sealed class IsApplicationVariableDefined : IsVariableDefinedUnit, IApplicationVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{

	public IsApplicationVariableDefined() { }

	public IsApplicationVariableDefined(string defaultName) { }

	protected virtual VariableDeclarations GetDeclarations(Flow flow) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

