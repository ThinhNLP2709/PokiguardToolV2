namespace Unity.VisualScripting;

[Obsolete("Use the Comparison node instead.")]
[UnitCategory("Logic")]
[UnitOrder(4)]
[UnitShortTitle("Comparison")]
[UnitSurtitle("Equality")]
[UnitTitle("Equality Comparison")]
public sealed class EqualityComparison : Unit
{
	[CompilerGenerated]
	private ValueInput <a>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <b>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <equal>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueOutput <notEqual>k__BackingField; //Field offset: 0xA8

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
	[PortLabel("A = B")]
	public private ValueOutput equal
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("A ≠ B")]
	public private ValueOutput notEqual
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public EqualityComparison() { }

	protected virtual void Definition() { }

	private bool Equal(Flow flow) { }

	[CompilerGenerated]
	public ValueInput get_a() { }

	[CompilerGenerated]
	public ValueInput get_b() { }

	[CompilerGenerated]
	public ValueOutput get_equal() { }

	[CompilerGenerated]
	public ValueOutput get_notEqual() { }

	private bool NotEqual(Flow flow) { }

	[CompilerGenerated]
	private void set_a(ValueInput value) { }

	[CompilerGenerated]
	private void set_b(ValueInput value) { }

	[CompilerGenerated]
	private void set_equal(ValueOutput value) { }

	[CompilerGenerated]
	private void set_notEqual(ValueOutput value) { }

}

