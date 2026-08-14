namespace Unity.VisualScripting;

[TypeIcon(typeof(IList))]
[UnitCategory("Collections/Lists")]
[UnitOrder(1)]
[UnitShortTitle("Set Item")]
[UnitSurtitle("List")]
public sealed class SetListItem : Unit
{
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <list>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueInput <index>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueInput <item>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ControlOutput <exit>k__BackingField; //Field offset: 0xB0

	[DoNotSerialize]
	[PortLabelHidden]
	public private ControlInput enter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ControlOutput exit
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueInput index
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
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

	public SetListItem() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	[CompilerGenerated]
	public ValueInput get_index() { }

	[CompilerGenerated]
	public ValueInput get_item() { }

	[CompilerGenerated]
	public ValueInput get_list() { }

	public ControlOutput Set(Flow flow) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exit(ControlOutput value) { }

	[CompilerGenerated]
	private void set_index(ValueInput value) { }

	[CompilerGenerated]
	private void set_item(ValueInput value) { }

	[CompilerGenerated]
	private void set_list(ValueInput value) { }

}

