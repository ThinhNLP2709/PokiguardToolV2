namespace Unity.VisualScripting;

[TypeIcon(typeof(ISelectUnit))]
[UnitCategory("Control")]
[UnitOrder(6)]
[UnitTitle("Select")]
public sealed class SelectUnit : Unit, ISelectUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private ValueInput <condition>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <ifTrue>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueInput <ifFalse>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueOutput <selection>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueInput condition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("False")]
	public private ValueInput ifFalse
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("True")]
	public private ValueInput ifTrue
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private override ValueOutput selection
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public SelectUnit() { }

	public object Branch(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_condition() { }

	[CompilerGenerated]
	public ValueInput get_ifFalse() { }

	[CompilerGenerated]
	public ValueInput get_ifTrue() { }

	[CompilerGenerated]
	public override ValueOutput get_selection() { }

	[CompilerGenerated]
	private void set_condition(ValueInput value) { }

	[CompilerGenerated]
	private void set_ifFalse(ValueInput value) { }

	[CompilerGenerated]
	private void set_ifTrue(ValueInput value) { }

	[CompilerGenerated]
	private void set_selection(ValueOutput value) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

