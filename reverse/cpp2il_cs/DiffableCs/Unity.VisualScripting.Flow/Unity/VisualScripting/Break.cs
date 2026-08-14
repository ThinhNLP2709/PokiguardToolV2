namespace Unity.VisualScripting;

[UnitCategory("Control")]
[UnitOrder(13)]
[UnitTitle("Break Loop")]
public class Break : Unit
{
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x90

	[DoNotSerialize]
	[PortLabelHidden]
	public private ControlInput enter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public Break() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	public ControlOutput Operation(Flow flow) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

}

