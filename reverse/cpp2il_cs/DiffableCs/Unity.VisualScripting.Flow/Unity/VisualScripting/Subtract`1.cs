namespace Unity.VisualScripting;

[UnitOrder(102)]
public abstract class Subtract : Unit
{
	[CompilerGenerated]
	private ValueInput <minuend>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <subtrahend>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueOutput <difference>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	protected override T defaultMinuend
	{
		 get { } //Length: 3
	}

	[DoNotSerialize]
	protected override T defaultSubtrahend
	{
		 get { } //Length: 3
	}

	[DoNotSerialize]
	[PortLabel("A − B")]
	public private ValueOutput difference
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("A")]
	public private ValueInput minuend
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("B")]
	public private ValueInput subtrahend
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected Subtract`1() { }

	protected virtual void Definition() { }

	protected override T get_defaultMinuend() { }

	protected override T get_defaultSubtrahend() { }

	[CompilerGenerated]
	public ValueOutput get_difference() { }

	[CompilerGenerated]
	public ValueInput get_minuend() { }

	[CompilerGenerated]
	public ValueInput get_subtrahend() { }

	public abstract T Operation(T a, T b) { }

	public T Operation(Flow flow) { }

	[CompilerGenerated]
	private void set_difference(ValueOutput value) { }

	[CompilerGenerated]
	private void set_minuend(ValueInput value) { }

	[CompilerGenerated]
	private void set_subtrahend(ValueInput value) { }

}

