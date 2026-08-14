namespace Unity.VisualScripting;

[UnitShortTitle("Set Variable")]
public sealed class SetVariable : UnifiedVariableUnit
{
	[CompilerGenerated]
	private ControlInput <assign>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueInput <input>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ControlOutput <assigned>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ValueOutput <output>k__BackingField; //Field offset: 0xC0

	[DoNotSerialize]
	[PortLabelHidden]
	public ControlInput assign
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public ControlOutput assigned
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("New Value")]
	[PortLabelHidden]
	public private ValueInput input
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Value")]
	[PortLabelHidden]
	public private ValueOutput output
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public SetVariable() { }

	private ControlOutput Assign(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ControlInput get_assign() { }

	[CompilerGenerated]
	public ControlOutput get_assigned() { }

	[CompilerGenerated]
	public ValueInput get_input() { }

	[CompilerGenerated]
	public ValueOutput get_output() { }

	[CompilerGenerated]
	public void set_assign(ControlInput value) { }

	[CompilerGenerated]
	public void set_assigned(ControlOutput value) { }

	[CompilerGenerated]
	private void set_input(ValueInput value) { }

	[CompilerGenerated]
	private void set_output(ValueOutput value) { }

}

