namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitOrder(105)]
[UnitTitle("Exponentiate")]
public sealed class ScalarExponentiate : Unit
{
	[CompilerGenerated]
	private ValueInput <base>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <exponent>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <power>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	[PortLabel("x")]
	public private ValueInput base
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("n")]
	public private ValueInput exponent
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("xⁿ")]
	public private ValueOutput power
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public ScalarExponentiate() { }

	protected virtual void Definition() { }

	public float Exponentiate(Flow flow) { }

	[CompilerGenerated]
	public ValueInput get_base() { }

	[CompilerGenerated]
	public ValueInput get_exponent() { }

	[CompilerGenerated]
	public ValueOutput get_power() { }

	[CompilerGenerated]
	private void set_base(ValueInput value) { }

	[CompilerGenerated]
	private void set_exponent(ValueInput value) { }

	[CompilerGenerated]
	private void set_power(ValueOutput value) { }

}

