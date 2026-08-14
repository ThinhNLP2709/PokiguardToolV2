namespace Unity.VisualScripting;

[RenamedFrom("Bolt.Branch")]
[RenamedFrom("Unity.VisualScripting.Branch")]
[UnitCategory("Control")]
[UnitOrder(0)]
public sealed class If : Unit, IBranchUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
{
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <condition>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ControlOutput <ifTrue>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ControlOutput <ifFalse>k__BackingField; //Field offset: 0xA8

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
	[PortLabelHidden]
	public private override ControlInput enter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("False")]
	public private ControlOutput ifFalse
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("True")]
	public private ControlOutput ifTrue
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public If() { }

	protected virtual void Definition() { }

	public ControlOutput Enter(Flow flow) { }

	[CompilerGenerated]
	public ValueInput get_condition() { }

	[CompilerGenerated]
	public override ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_ifFalse() { }

	[CompilerGenerated]
	public ControlOutput get_ifTrue() { }

	[CompilerGenerated]
	private void set_condition(ValueInput value) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_ifFalse(ControlOutput value) { }

	[CompilerGenerated]
	private void set_ifTrue(ControlOutput value) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

