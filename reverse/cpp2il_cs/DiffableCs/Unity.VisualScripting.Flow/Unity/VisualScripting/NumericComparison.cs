namespace Unity.VisualScripting;

[Obsolete("Use the Comparison node with Numeric enabled instead.")]
[UnitCategory("Logic")]
[UnitOrder(99)]
[UnitShortTitle("Comparison")]
[UnitSurtitle("Numeric")]
[UnitTitle("Numeric Comparison")]
public sealed class NumericComparison : Unit
{
	[CompilerGenerated]
	private ValueInput <a>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <b>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <aLessThanB>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueOutput <aLessThanOrEqualToB>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueOutput <aEqualToB>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueOutput <aGreaterThanOrEqualToB>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ValueOutput <aGreatherThanB>k__BackingField; //Field offset: 0xC0

	[DoNotSerialize]
	public private ValueInput a
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("A = B")]
	public private ValueOutput aEqualToB
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("A ≥ B")]
	public private ValueOutput aGreaterThanOrEqualToB
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("A > B")]
	public private ValueOutput aGreatherThanB
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("A < B")]
	public private ValueOutput aLessThanB
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("A ≤ B")]
	public private ValueOutput aLessThanOrEqualToB
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

	public NumericComparison() { }

	protected virtual void Definition() { }

	private bool Equal(Flow flow) { }

	[CompilerGenerated]
	public ValueInput get_a() { }

	[CompilerGenerated]
	public ValueOutput get_aEqualToB() { }

	[CompilerGenerated]
	public ValueOutput get_aGreaterThanOrEqualToB() { }

	[CompilerGenerated]
	public ValueOutput get_aGreatherThanB() { }

	[CompilerGenerated]
	public ValueOutput get_aLessThanB() { }

	[CompilerGenerated]
	public ValueOutput get_aLessThanOrEqualToB() { }

	[CompilerGenerated]
	public ValueInput get_b() { }

	private bool Greater(Flow flow) { }

	private bool GreaterOrEqual(Flow flow) { }

	private bool Less(Flow flow) { }

	private bool LessOrEqual(Flow flow) { }

	[CompilerGenerated]
	private void set_a(ValueInput value) { }

	[CompilerGenerated]
	private void set_aEqualToB(ValueOutput value) { }

	[CompilerGenerated]
	private void set_aGreaterThanOrEqualToB(ValueOutput value) { }

	[CompilerGenerated]
	private void set_aGreatherThanB(ValueOutput value) { }

	[CompilerGenerated]
	private void set_aLessThanB(ValueOutput value) { }

	[CompilerGenerated]
	private void set_aLessThanOrEqualToB(ValueOutput value) { }

	[CompilerGenerated]
	private void set_b(ValueInput value) { }

}

