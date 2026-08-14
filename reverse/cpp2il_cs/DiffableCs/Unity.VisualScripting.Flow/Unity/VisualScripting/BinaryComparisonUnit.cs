namespace Unity.VisualScripting;

[UnitCategory("Logic")]
public abstract class BinaryComparisonUnit : Unit
{
	[CompilerGenerated]
	private ValueInput <a>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <b>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <comparison>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private bool <numeric>k__BackingField; //Field offset: 0xA8

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
	public private override ValueOutput comparison
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[Inspectable]
	[InspectorToggleLeft]
	[Serialize]
	public bool numeric
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	protected override string outputKey
	{
		 get { } //Length: 44
	}

	protected BinaryComparisonUnit() { }

	protected virtual void Definition() { }

	private bool GenericComparison(Flow flow) { }

	protected abstract bool GenericComparison(object a, object b) { }

	[CompilerGenerated]
	public ValueInput get_a() { }

	[CompilerGenerated]
	public ValueInput get_b() { }

	[CompilerGenerated]
	public override ValueOutput get_comparison() { }

	[CompilerGenerated]
	public bool get_numeric() { }

	protected override string get_outputKey() { }

	private bool NumericComparison(Flow flow) { }

	protected abstract bool NumericComparison(float a, float b) { }

	[CompilerGenerated]
	private void set_a(ValueInput value) { }

	[CompilerGenerated]
	private void set_b(ValueInput value) { }

	[CompilerGenerated]
	private void set_comparison(ValueOutput value) { }

	[CompilerGenerated]
	public void set_numeric(bool value) { }

}

