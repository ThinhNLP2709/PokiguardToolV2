namespace Unity.VisualScripting;

[UnitOrder(301)]
public abstract class Minimum : MultiInputUnit<T>
{
	[CompilerGenerated]
	private ValueOutput <minimum>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput minimum
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected Minimum`1() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_minimum() { }

	public abstract T Operation(T a, T b) { }

	public abstract T Operation(IEnumerable<T> values) { }

	public T Operation(Flow flow) { }

	[CompilerGenerated]
	private void set_minimum(ValueOutput value) { }

}

