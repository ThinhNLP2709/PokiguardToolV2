namespace Unity.VisualScripting;

[UnitCategory("Logic")]
[UnitOrder(99)]
[UnitShortTitle("Comparison")]
[UnitTitle("Comparison")]
public sealed class Comparison : Unit
{
	[CompilerGenerated]
	private ValueInput <a>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <b>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private bool <numeric>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueOutput <aLessThanB>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueOutput <aLessThanOrEqualToB>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueOutput <aEqualToB>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ValueOutput <aNotEqualToB>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private ValueOutput <aGreaterThanOrEqualToB>k__BackingField; //Field offset: 0xC8
	[CompilerGenerated]
	private ValueOutput <aGreatherThanB>k__BackingField; //Field offset: 0xD0

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
	[PortLabel("A ≠ B")]
	public private ValueOutput aNotEqualToB
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

	[Inspectable]
	[Serialize]
	public bool numeric
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	public Comparison() { }

	[CompilerGenerated]
	private bool <Definition>b__36_0(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__36_1(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__36_10(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__36_11(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__36_2(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__36_3(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__36_4(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__36_5(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__36_6(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__36_7(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__36_8(Flow flow) { }

	[CompilerGenerated]
	private bool <Definition>b__36_9(Flow flow) { }

	protected virtual void Definition() { }

	private bool GenericEqual(object a, object b) { }

	private bool GenericGreater(object a, object b) { }

	private bool GenericGreaterOrEqual(object a, object b) { }

	private bool GenericLess(object a, object b) { }

	private bool GenericLessOrEqual(object a, object b) { }

	private bool GenericNotEqual(object a, object b) { }

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
	public ValueOutput get_aNotEqualToB() { }

	[CompilerGenerated]
	public ValueInput get_b() { }

	[CompilerGenerated]
	public bool get_numeric() { }

	private bool NumericEqual(float a, float b) { }

	private bool NumericGreater(float a, float b) { }

	private bool NumericGreaterOrEqual(float a, float b) { }

	private bool NumericLess(float a, float b) { }

	private bool NumericLessOrEqual(float a, float b) { }

	private bool NumericNotEqual(float a, float b) { }

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
	private void set_aNotEqualToB(ValueOutput value) { }

	[CompilerGenerated]
	private void set_b(ValueInput value) { }

	[CompilerGenerated]
	public void set_numeric(bool value) { }

}

