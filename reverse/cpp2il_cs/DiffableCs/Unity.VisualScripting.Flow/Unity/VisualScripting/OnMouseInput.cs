namespace Unity.VisualScripting;

[UnitCategory("Events/Input")]
public sealed class OnMouseInput : MachineEventUnit<EmptyEventArgs>, IMouseEventUnit
{
	[CompilerGenerated]
	private ValueInput <button>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueInput <action>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	public private ValueInput action
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueInput button
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public OnMouseInput() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_action() { }

	[CompilerGenerated]
	public ValueInput get_button() { }

	protected virtual string get_hookName() { }

	[CompilerGenerated]
	private void set_action(ValueInput value) { }

	[CompilerGenerated]
	private void set_button(ValueInput value) { }

	protected virtual bool ShouldTrigger(Flow flow, EmptyEventArgs args) { }

}

