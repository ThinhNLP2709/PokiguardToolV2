namespace Unity.VisualScripting;

[UnitCategory("Math/Scalar")]
[UnitOrder(106)]
[UnitTitle("Root")]
public sealed class ScalarRoot : Unit
{
	[CompilerGenerated]
	private ValueInput <radicand>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <degree>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <root>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	[PortLabel("n")]
	public private ValueInput degree
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("x")]
	public private ValueInput radicand
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("ⁿ√x")]
	public private ValueOutput root
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public ScalarRoot() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_degree() { }

	[CompilerGenerated]
	public ValueInput get_radicand() { }

	[CompilerGenerated]
	public ValueOutput get_root() { }

	public float Root(Flow flow) { }

	[CompilerGenerated]
	private void set_degree(ValueInput value) { }

	[CompilerGenerated]
	private void set_radicand(ValueInput value) { }

	[CompilerGenerated]
	private void set_root(ValueOutput value) { }

}

