namespace Unity.VisualScripting;

[TypeIcon(typeof(CustomEvent))]
[UnitCategory("Events")]
[UnitOrder(1)]
[UnitShortTitle("Trigger")]
[UnitSurtitle("Custom Event")]
public sealed class TriggerCustomEvent : Unit
{
	[SerializeAs("argumentCount")]
	private int _argumentCount; //Field offset: 0x90
	[CompilerGenerated]
	private List<ValueInput> <arguments>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueInput <name>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueInput <target>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ControlOutput <exit>k__BackingField; //Field offset: 0xB8

	[DoNotSerialize]
	[Inspectable]
	[UnitHeaderInspectable("Arguments")]
	public int argumentCount
	{
		 get { } //Length: 7
		 set { } //Length: 38
	}

	[DoNotSerialize]
	public private List<ValueInput> arguments
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

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
	[PortLabelHidden]
	public private ValueInput name
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[NullMeansSelf]
	[PortLabelHidden]
	public private ValueInput target
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public TriggerCustomEvent() { }

	protected virtual void Definition() { }

	public int get_argumentCount() { }

	[CompilerGenerated]
	public List<ValueInput> get_arguments() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	[CompilerGenerated]
	public ValueInput get_name() { }

	[CompilerGenerated]
	public ValueInput get_target() { }

	public void set_argumentCount(int value) { }

	[CompilerGenerated]
	private void set_arguments(List<ValueInput> value) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exit(ControlOutput value) { }

	[CompilerGenerated]
	private void set_name(ValueInput value) { }

	[CompilerGenerated]
	private void set_target(ValueInput value) { }

	private ControlOutput Trigger(Flow flow) { }

}

