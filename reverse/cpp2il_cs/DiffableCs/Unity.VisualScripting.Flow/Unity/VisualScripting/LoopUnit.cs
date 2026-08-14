namespace Unity.VisualScripting;

public abstract class LoopUnit : Unit
{
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ControlOutput <exit>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ControlOutput <body>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	public private ControlOutput body
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
	public private ControlOutput exit
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected LoopUnit() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ControlOutput get_body() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	protected abstract ControlOutput Loop(Flow flow) { }

	protected abstract IEnumerator LoopCoroutine(Flow flow) { }

	[CompilerGenerated]
	private void set_body(ControlOutput value) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exit(ControlOutput value) { }

}

