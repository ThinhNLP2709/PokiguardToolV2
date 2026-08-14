namespace Unity.VisualScripting;

[UnitCategory("Collections")]
public sealed class CountItems : Unit
{
	[CompilerGenerated]
	private ValueInput <collection>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueOutput <count>k__BackingField; //Field offset: 0x98

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueInput collection
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput count
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public CountItems() { }

	public int Count(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_collection() { }

	[CompilerGenerated]
	public ValueOutput get_count() { }

	[CompilerGenerated]
	private void set_collection(ValueInput value) { }

	[CompilerGenerated]
	private void set_count(ValueOutput value) { }

}

