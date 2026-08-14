namespace Unity.VisualScripting;

[UnitOrder(105)]
public abstract class Modulo : Unit
{
	[CompilerGenerated]
	private ValueInput <dividend>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <divisor>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueOutput <remainder>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	protected override T defaultDividend
	{
		 get { } //Length: 3
	}

	[DoNotSerialize]
	protected override T defaultDivisor
	{
		 get { } //Length: 3
	}

	[DoNotSerialize]
	[PortLabel("A")]
	public private ValueInput dividend
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("B")]
	public private ValueInput divisor
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("A % B")]
	public private ValueOutput remainder
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected Modulo`1() { }

	protected virtual void Definition() { }

	protected override T get_defaultDividend() { }

	protected override T get_defaultDivisor() { }

	[CompilerGenerated]
	public ValueInput get_dividend() { }

	[CompilerGenerated]
	public ValueInput get_divisor() { }

	[CompilerGenerated]
	public ValueOutput get_remainder() { }

	public abstract T Operation(T divident, T divisor) { }

	public T Operation(Flow flow) { }

	[CompilerGenerated]
	private void set_dividend(ValueInput value) { }

	[CompilerGenerated]
	private void set_divisor(ValueInput value) { }

	[CompilerGenerated]
	private void set_remainder(ValueOutput value) { }

}

