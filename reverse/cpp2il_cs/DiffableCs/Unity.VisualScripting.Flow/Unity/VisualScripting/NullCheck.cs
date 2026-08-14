namespace Unity.VisualScripting;

[TypeIcon(typeof(Null))]
[UnitCategory("Nulls")]
public sealed class NullCheck : Unit
{
	[CompilerGenerated]
	private ValueInput <input>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ControlOutput <ifNotNull>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ControlOutput <ifNull>k__BackingField; //Field offset: 0xA8

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
	[PortLabel("Not Null")]
	public private ControlOutput ifNotNull
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Null")]
	public private ControlOutput ifNull
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueInput input
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public NullCheck() { }

	protected virtual void Definition() { }

	public ControlOutput Enter(Flow flow) { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_ifNotNull() { }

	[CompilerGenerated]
	public ControlOutput get_ifNull() { }

	[CompilerGenerated]
	public ValueInput get_input() { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_ifNotNull(ControlOutput value) { }

	[CompilerGenerated]
	private void set_ifNull(ControlOutput value) { }

	[CompilerGenerated]
	private void set_input(ValueInput value) { }

}

