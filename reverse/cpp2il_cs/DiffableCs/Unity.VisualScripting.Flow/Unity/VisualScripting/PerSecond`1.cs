namespace Unity.VisualScripting;

[UnitOrder(601)]
public abstract class PerSecond : Unit
{
	[CompilerGenerated]
	private ValueInput <input>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueOutput <output>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueInput input
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput output
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected PerSecond`1() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_input() { }

	[CompilerGenerated]
	public ValueOutput get_output() { }

	public abstract T Operation(T input) { }

	public T Operation(Flow flow) { }

	[CompilerGenerated]
	private void set_input(ValueInput value) { }

	[CompilerGenerated]
	private void set_output(ValueOutput value) { }

}

