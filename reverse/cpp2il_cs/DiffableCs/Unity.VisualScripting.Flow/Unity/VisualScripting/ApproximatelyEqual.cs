namespace Unity.VisualScripting;

[Obsolete("Use the Equal node with Numeric enabled instead.")]
[UnitCategory("Logic")]
[UnitOrder(7)]
[UnitShortTitle("Equal")]
[UnitSubtitle("(Approximately)")]
public sealed class ApproximatelyEqual : Unit
{
	[CompilerGenerated]
	private ValueInput <a>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <b>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <equal>k__BackingField; //Field offset: 0xA0

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
	[PortLabel("A ≈ B")]
	public private ValueOutput equal
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public ApproximatelyEqual() { }

	public bool Comparison(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_a() { }

	[CompilerGenerated]
	public ValueInput get_b() { }

	[CompilerGenerated]
	public ValueOutput get_equal() { }

	[CompilerGenerated]
	private void set_a(ValueInput value) { }

	[CompilerGenerated]
	private void set_b(ValueInput value) { }

	[CompilerGenerated]
	private void set_equal(ValueOutput value) { }

}

