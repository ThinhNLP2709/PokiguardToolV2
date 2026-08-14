namespace Unity.VisualScripting;

[TypeIcon(typeof(IList))]
[UnitCategory("Collections/Lists")]
[UnitOrder(0)]
[UnitShortTitle("Get Item")]
[UnitSurtitle("List")]
public sealed class GetListItem : Unit
{
	[CompilerGenerated]
	private ValueInput <list>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <index>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <item>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	public private ValueInput index
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput item
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueInput list
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public GetListItem() { }

	protected virtual void Definition() { }

	public object Get(Flow flow) { }

	[CompilerGenerated]
	public ValueInput get_index() { }

	[CompilerGenerated]
	public ValueOutput get_item() { }

	[CompilerGenerated]
	public ValueInput get_list() { }

	[CompilerGenerated]
	private void set_index(ValueInput value) { }

	[CompilerGenerated]
	private void set_item(ValueOutput value) { }

	[CompilerGenerated]
	private void set_list(ValueInput value) { }

}

