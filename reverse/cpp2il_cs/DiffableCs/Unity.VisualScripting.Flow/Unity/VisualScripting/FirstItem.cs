namespace Unity.VisualScripting;

[UnitCategory("Collections")]
public sealed class FirstItem : Unit
{
	[CompilerGenerated]
	private ValueInput <collection>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueOutput <firstItem>k__BackingField; //Field offset: 0x98

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
	public private ValueOutput firstItem
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public FirstItem() { }

	protected virtual void Definition() { }

	public object First(Flow flow) { }

	[CompilerGenerated]
	public ValueInput get_collection() { }

	[CompilerGenerated]
	public ValueOutput get_firstItem() { }

	[CompilerGenerated]
	private void set_collection(ValueInput value) { }

	[CompilerGenerated]
	private void set_firstItem(ValueOutput value) { }

}

