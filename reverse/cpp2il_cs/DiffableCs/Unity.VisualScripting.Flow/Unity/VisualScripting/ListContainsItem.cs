namespace Unity.VisualScripting;

[TypeIcon(typeof(IList))]
[UnitCategory("Collections/Lists")]
[UnitShortTitle("Contains Item")]
[UnitSurtitle("List")]
public sealed class ListContainsItem : Unit
{
	[CompilerGenerated]
	private ValueInput <list>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <item>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <contains>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput contains
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueInput item
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

	public ListContainsItem() { }

	public bool Contains(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_contains() { }

	[CompilerGenerated]
	public ValueInput get_item() { }

	[CompilerGenerated]
	public ValueInput get_list() { }

	[CompilerGenerated]
	private void set_contains(ValueOutput value) { }

	[CompilerGenerated]
	private void set_item(ValueInput value) { }

	[CompilerGenerated]
	private void set_list(ValueInput value) { }

}

