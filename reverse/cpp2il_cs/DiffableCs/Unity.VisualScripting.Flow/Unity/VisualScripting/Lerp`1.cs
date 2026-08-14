namespace Unity.VisualScripting;

[UnitOrder(501)]
public abstract class Lerp : Unit
{
	[CompilerGenerated]
	private ValueInput <a>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <b>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <t>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueOutput <interpolation>k__BackingField; //Field offset: 0x0

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
	protected override T defaultA
	{
		 get { } //Length: 4
	}

	[DoNotSerialize]
	protected override T defaultB
	{
		 get { } //Length: 4
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput interpolation
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueInput t
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected Lerp`1() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_a() { }

	[CompilerGenerated]
	public ValueInput get_b() { }

	protected override T get_defaultA() { }

	protected override T get_defaultB() { }

	[CompilerGenerated]
	public ValueOutput get_interpolation() { }

	[CompilerGenerated]
	public ValueInput get_t() { }

	private T Operation(Flow flow) { }

	public abstract T Operation(T a, T b, float t) { }

	[CompilerGenerated]
	private void set_a(ValueInput value) { }

	[CompilerGenerated]
	private void set_b(ValueInput value) { }

	[CompilerGenerated]
	private void set_interpolation(ValueOutput value) { }

	[CompilerGenerated]
	private void set_t(ValueInput value) { }

}

