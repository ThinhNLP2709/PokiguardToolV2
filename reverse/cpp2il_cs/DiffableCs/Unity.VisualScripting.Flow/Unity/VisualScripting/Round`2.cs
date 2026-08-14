namespace Unity.VisualScripting;

[UnitOrder(202)]
public abstract class Round : Unit
{
	internal enum Rounding
	{
		Floor = 0,
		Ceiling = 1,
		AwayFromZero = 2,
	}

	[CompilerGenerated]
	private Rounding<TInput, TOutput> <rounding>k__BackingField; //Field offset: 0x0
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

	[Inspectable]
	[Serialize]
	[UnitHeaderInspectable]
	public Rounding<TInput, TOutput> rounding
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		 set { } //Length: 7
	}

	protected Round`2() { }

	protected abstract TOutput AwayFromZero(TInput input) { }

	protected abstract TOutput Ceiling(TInput input) { }

	protected virtual void Definition() { }

	protected abstract TOutput Floor(TInput input) { }

	[CompilerGenerated]
	public ValueInput get_input() { }

	[CompilerGenerated]
	public ValueOutput get_output() { }

	[CompilerGenerated]
	public Rounding<TInput, TOutput> get_rounding() { }

	public TOutput Operation(Flow flow) { }

	[CompilerGenerated]
	private void set_input(ValueInput value) { }

	[CompilerGenerated]
	private void set_output(ValueOutput value) { }

	[CompilerGenerated]
	public void set_rounding(Rounding<TInput, TOutput> value) { }

}

