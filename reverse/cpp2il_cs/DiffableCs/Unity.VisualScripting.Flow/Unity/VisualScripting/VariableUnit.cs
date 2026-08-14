namespace Unity.VisualScripting;

[Obsolete("Use the new unified variable nodes instead.")]
[SpecialUnit]
public abstract class VariableUnit : Unit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private readonly string <defaultName>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <name>k__BackingField; //Field offset: 0x98

	[DoNotSerialize]
	public string defaultName
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private override ValueInput name
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected VariableUnit() { }

	protected VariableUnit(string defaultName) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public string get_defaultName() { }

	[CompilerGenerated]
	public override ValueInput get_name() { }

	protected abstract VariableDeclarations GetDeclarations(Flow flow) { }

	[CompilerGenerated]
	private void set_name(ValueInput value) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

