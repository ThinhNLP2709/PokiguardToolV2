namespace Unity.VisualScripting;

[UnitSurtitle("Object")]
public sealed class SetObjectVariable : SetVariableUnit, IObjectVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private ValueInput <source>k__BackingField; //Field offset: 0xC0

	[DoNotSerialize]
	[NullMeansSelf]
	[PortLabelHidden]
	public private ValueInput source
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public SetObjectVariable() { }

	public SetObjectVariable(string name) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_source() { }

	protected virtual VariableDeclarations GetDeclarations(Flow flow) { }

	[CompilerGenerated]
	private void set_source(ValueInput value) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

