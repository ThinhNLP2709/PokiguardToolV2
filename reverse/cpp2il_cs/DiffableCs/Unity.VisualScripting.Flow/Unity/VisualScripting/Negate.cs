namespace Unity.VisualScripting;

[UnitCategory("Logic")]
[UnitOrder(3)]
public sealed class Negate : Unit
{
	[CompilerGenerated]
	private ValueInput <input>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueOutput <output>k__BackingField; //Field offset: 0x98

	[DoNotSerialize]
	[PortLabel("X")]
	public private ValueInput input
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("~X")]
	public private ValueOutput output
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public Negate() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_input() { }

	[CompilerGenerated]
	public ValueOutput get_output() { }

	public bool Operation(Flow flow) { }

	[CompilerGenerated]
	private void set_input(ValueInput value) { }

	[CompilerGenerated]
	private void set_output(ValueOutput value) { }

}

