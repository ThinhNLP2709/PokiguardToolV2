namespace Unity.VisualScripting;

[UnitOrder(302)]
public abstract class Maximum : MultiInputUnit<T>
{
	[CompilerGenerated]
	private ValueOutput <maximum>k__BackingField; //Field offset: 0x0

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput maximum
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected Maximum`1() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_maximum() { }

	public abstract T Operation(T a, T b) { }

	public abstract T Operation(IEnumerable<T> values) { }

	public T Operation(Flow flow) { }

	[CompilerGenerated]
	private void set_maximum(ValueOutput value) { }

}

