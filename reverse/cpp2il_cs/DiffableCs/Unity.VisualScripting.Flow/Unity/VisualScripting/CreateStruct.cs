namespace Unity.VisualScripting;

[SpecialUnit]
public sealed class CreateStruct : Unit
{
	[CompilerGenerated]
	private Type <type>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ControlOutput <exit>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueOutput <output>k__BackingField; //Field offset: 0xA8

	public virtual bool canDefine
	{
		 get { } //Length: 52
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
	public private ValueOutput output
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[Serialize]
	public internal Type type
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 19
	}

	[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
	public CreateStruct() { }

	public CreateStruct(Type type) { }

	private object Create(Flow flow) { }

	protected virtual void Definition() { }

	private ControlOutput Enter(Flow flow) { }

	public virtual bool get_canDefine() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	[CompilerGenerated]
	public ValueOutput get_output() { }

	[CompilerGenerated]
	public Type get_type() { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exit(ControlOutput value) { }

	[CompilerGenerated]
	private void set_output(ValueOutput value) { }

	[CompilerGenerated]
	internal void set_type(Type value) { }

}

