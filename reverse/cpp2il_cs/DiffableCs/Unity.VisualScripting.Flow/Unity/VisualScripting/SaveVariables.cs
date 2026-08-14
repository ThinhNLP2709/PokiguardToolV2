namespace Unity.VisualScripting;

[UnitCategory("Variables")]
public sealed class SaveVariables : Unit
{
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ControlOutput <exit>k__BackingField; //Field offset: 0x98

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

	public SaveVariables() { }

	protected virtual void Definition() { }

	private ControlOutput Enter(Flow arg) { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exit(ControlOutput value) { }

}

