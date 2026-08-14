namespace Unity.VisualScripting;

[TypeIcon(typeof(Multiply`1))]
[UnitOrder(405)]
public abstract class CrossProduct : Unit
{
	[CompilerGenerated]
	private ValueInput <a>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueInput <b>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ValueOutput <crossProduct>k__BackingField; //Field offset: 0x0

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
	[PortLabel("A × B")]
	public private ValueOutput crossProduct
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected CrossProduct`1() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_a() { }

	[CompilerGenerated]
	public ValueInput get_b() { }

	[CompilerGenerated]
	public ValueOutput get_crossProduct() { }

	private T Operation(Flow flow) { }

	public abstract T Operation(T a, T b) { }

	[CompilerGenerated]
	private void set_a(ValueInput value) { }

	[CompilerGenerated]
	private void set_b(ValueInput value) { }

	[CompilerGenerated]
	private void set_crossProduct(ValueOutput value) { }

}

