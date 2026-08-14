namespace Unity.VisualScripting;

[UnitOrder(103)]
public abstract class Multiply : Unit
{
	[CompilerGenerated]
	private ValueInput <a>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <b>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueOutput <product>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	public private ValueInput a
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueInput b
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	protected override T defaultB
	{
		 get { } //Length: 3
	}

	[DoNotSerialize]
	[PortLabel("A × B")]
	public private ValueOutput product
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected Multiply`1() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_a() { }

	[CompilerGenerated]
	public ValueInput get_b() { }

	protected override T get_defaultB() { }

	[CompilerGenerated]
	public ValueOutput get_product() { }

	private T Operation(Flow flow) { }

	public abstract T Operation(T a, T b) { }

	[CompilerGenerated]
	private void set_a(ValueInput value) { }

	[CompilerGenerated]
	private void set_b(ValueInput value) { }

	[CompilerGenerated]
	private void set_product(ValueOutput value) { }

}

