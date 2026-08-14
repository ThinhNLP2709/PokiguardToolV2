namespace Unity.VisualScripting;

[UnitOrder(304)]
public abstract class Average : MultiInputUnit<T>
{
	[CompilerGenerated]
	private ValueOutput <average>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput average
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected Average`1() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_average() { }

	public abstract T Operation(T a, T b) { }

	public abstract T Operation(IEnumerable<T> values) { }

	public T Operation(Flow flow) { }

	[CompilerGenerated]
	private void set_average(ValueOutput value) { }

}

