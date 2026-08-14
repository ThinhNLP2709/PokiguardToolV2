namespace Unity.VisualScripting;

[TypeIcon(typeof(Add`1))]
[UnitOrder(303)]
public abstract class Sum : MultiInputUnit<T>
{
	[CompilerGenerated]
	private ValueOutput <sum>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput sum
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected Sum`1() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_sum() { }

	public abstract T Operation(T a, T b) { }

	public abstract T Operation(IEnumerable<T> values) { }

	public T Operation(Flow flow) { }

	[CompilerGenerated]
	private void set_sum(ValueOutput value) { }

}

