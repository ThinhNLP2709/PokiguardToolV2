namespace Unity.VisualScripting;

[UnitCategory("Graphs/Graph Nodes")]
public abstract class SetGraph : Unit
{
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <target>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <graphInput>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueOutput <graphOutput>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ControlOutput <exit>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	[PortLabelHidden]
	public ControlInput enter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public ControlOutput exit
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Graph")]
	[PortLabelHidden]
	public ValueInput graphInput
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Graph")]
	[PortLabelHidden]
	public ValueOutput graphOutput
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	protected abstract bool isGameObject
	{
		 get { } //Length: 0
	}

	[DoNotSerialize]
	[NullMeansSelf]
	[PortLabelHidden]
	public ValueInput target
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	private Type targetType
	{
		private get { } //Length: 135
	}

	protected SetGraph`3() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	[CompilerGenerated]
	public ValueInput get_graphInput() { }

	[CompilerGenerated]
	public ValueOutput get_graphOutput() { }

	protected abstract bool get_isGameObject() { }

	[CompilerGenerated]
	public ValueInput get_target() { }

	private Type get_targetType() { }

	[CompilerGenerated]
	protected void set_enter(ControlInput value) { }

	[CompilerGenerated]
	protected void set_exit(ControlOutput value) { }

	[CompilerGenerated]
	protected void set_graphInput(ValueInput value) { }

	[CompilerGenerated]
	protected void set_graphOutput(ValueOutput value) { }

	[CompilerGenerated]
	protected void set_target(ValueInput value) { }

	private ControlOutput SetMacro(Flow flow) { }

}

