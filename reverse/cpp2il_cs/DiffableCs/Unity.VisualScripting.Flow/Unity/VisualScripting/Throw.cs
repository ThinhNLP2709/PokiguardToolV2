namespace Unity.VisualScripting;

[UnitCategory("Control")]
[UnitOrder(16)]
public sealed class Throw : Unit
{
	[CompilerGenerated]
	private bool <custom>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueInput <message>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueInput <exception>k__BackingField; //Field offset: 0xA8

	[Inspectable]
	[InspectorToggleLeft]
	[Serialize]
	[UnitHeaderInspectable("Custom")]
	public bool custom
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
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
	public private ValueInput exception
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueInput message
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public Throw() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public bool get_custom() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ValueInput get_exception() { }

	[CompilerGenerated]
	public ValueInput get_message() { }

	[CompilerGenerated]
	public void set_custom(bool value) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exception(ValueInput value) { }

	[CompilerGenerated]
	private void set_message(ValueInput value) { }

	private ControlOutput ThrowCustom(Flow flow) { }

	private ControlOutput ThrowMessage(Flow flow) { }

}

