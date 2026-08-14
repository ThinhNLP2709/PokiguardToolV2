namespace Unity.VisualScripting;

[SpecialUnit]
public abstract class UnifiedVariableUnit : Unit, IUnifiedVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private VariableKind <kind>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <name>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueInput <object>k__BackingField; //Field offset: 0xA0

	[Inspectable]
	[Serialize]
	[UnitHeaderInspectable]
	public override VariableKind kind
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		 set { } //Length: 7
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

	[DoNotSerialize]
	[NullMeansSelf]
	[PortLabelHidden]
	public private ValueInput object
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected UnifiedVariableUnit() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public override VariableKind get_kind() { }

	[CompilerGenerated]
	public override ValueInput get_name() { }

	[CompilerGenerated]
	public ValueInput get_object() { }

	[CompilerGenerated]
	public void set_kind(VariableKind value) { }

	[CompilerGenerated]
	private void set_name(ValueInput value) { }

	[CompilerGenerated]
	private void set_object(ValueInput value) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

