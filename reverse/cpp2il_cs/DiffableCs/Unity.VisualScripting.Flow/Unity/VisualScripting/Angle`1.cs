namespace Unity.VisualScripting;

[UnitOrder(403)]
public abstract class Angle : Unit
{
	[CompilerGenerated]
	private ValueInput <a>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <b>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueOutput <angle>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	public private ValueInput a
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput angle
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

	protected Angle`1() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_a() { }

	[CompilerGenerated]
	public ValueOutput get_angle() { }

	[CompilerGenerated]
	public ValueInput get_b() { }

	private float Operation(Flow flow) { }

	public abstract float Operation(T a, T b) { }

	[CompilerGenerated]
	private void set_a(ValueInput value) { }

	[CompilerGenerated]
	private void set_angle(ValueOutput value) { }

	[CompilerGenerated]
	private void set_b(ValueInput value) { }

}

