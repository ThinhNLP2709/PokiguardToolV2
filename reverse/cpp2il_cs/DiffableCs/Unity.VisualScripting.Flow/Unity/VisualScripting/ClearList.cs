namespace Unity.VisualScripting;

[TypeIcon(typeof(RemoveListItem))]
[UnitCategory("Collections/Lists")]
[UnitOrder(6)]
[UnitShortTitle("Clear")]
[UnitSurtitle("List")]
public sealed class ClearList : Unit
{
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <listInput>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <listOutput>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ControlOutput <exit>k__BackingField; //Field offset: 0xA8

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
	[PortLabel("List")]
	[PortLabelHidden]
	public private ValueInput listInput
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("List")]
	[PortLabelHidden]
	public private ValueOutput listOutput
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public ClearList() { }

	public ControlOutput Clear(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	[CompilerGenerated]
	public ValueInput get_listInput() { }

	[CompilerGenerated]
	public ValueOutput get_listOutput() { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exit(ControlOutput value) { }

	[CompilerGenerated]
	private void set_listInput(ValueInput value) { }

	[CompilerGenerated]
	private void set_listOutput(ValueOutput value) { }

}

