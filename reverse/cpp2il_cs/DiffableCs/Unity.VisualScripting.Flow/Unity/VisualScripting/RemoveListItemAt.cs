namespace Unity.VisualScripting;

[TypeIcon(typeof(RemoveListItem))]
[UnitCategory("Collections/Lists")]
[UnitOrder(5)]
[UnitShortTitle("Remove Item At Index")]
[UnitSurtitle("List")]
public sealed class RemoveListItemAt : Unit
{
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <listInput>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <listOutput>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueInput <index>k__BackingField; //Field offset: 0xA8
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
	[PortLabelHidden]
	public private ValueInput listInput
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput listOutput
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public RemoveListItemAt() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	[CompilerGenerated]
	public ValueInput get_index() { }

	[CompilerGenerated]
	public ValueInput get_listInput() { }

	[CompilerGenerated]
	public ValueOutput get_listOutput() { }

	public ControlOutput RemoveAt(Flow flow) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exit(ControlOutput value) { }

	[CompilerGenerated]
	private void set_index(ValueInput value) { }

	[CompilerGenerated]
	private void set_listInput(ValueInput value) { }

	[CompilerGenerated]
	private void set_listOutput(ValueOutput value) { }

}

