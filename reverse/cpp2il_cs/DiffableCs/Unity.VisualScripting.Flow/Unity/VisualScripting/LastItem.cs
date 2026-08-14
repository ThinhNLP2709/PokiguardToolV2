namespace Unity.VisualScripting;

[UnitCategory("Collections")]
public sealed class LastItem : Unit
{
	[CompilerGenerated]
	private ValueInput <collection>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueOutput <lastItem>k__BackingField; //Field offset: 0x98

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
	public private ValueOutput lastItem
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public LastItem() { }

	protected virtual void Definition() { }

	public object First(Flow flow) { }

	[CompilerGenerated]
	public ValueInput get_collection() { }

	[CompilerGenerated]
	public ValueOutput get_lastItem() { }

	[CompilerGenerated]
	private void set_collection(ValueInput value) { }

	[CompilerGenerated]
	private void set_lastItem(ValueOutput value) { }

}

