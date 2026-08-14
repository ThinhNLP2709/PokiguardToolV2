namespace Unity.VisualScripting;

[UnitCategory("Events/Input")]
public sealed class OnKeyboardInput : MachineEventUnit<EmptyEventArgs>
{
	[CompilerGenerated]
	private ValueInput <key>k__BackingField; //Field offset: 0xA0
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

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	[DoNotSerialize]
	public private ValueInput key
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public OnKeyboardInput() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_action() { }

	protected virtual string get_hookName() { }

	[CompilerGenerated]
	public ValueInput get_key() { }

	[CompilerGenerated]
	private void set_action(ValueInput value) { }

	[CompilerGenerated]
	private void set_key(ValueInput value) { }

	protected virtual bool ShouldTrigger(Flow flow, EmptyEventArgs args) { }

}

