namespace Unity.VisualScripting;

[DisplayName("Visual Scripting Unity Event")]
[UnitCategory("Events")]
[UnitOrder(2)]
[UnitTitle("UnityEvent")]
public sealed class BoltUnityEvent : MachineEventUnit<String>
{
	[CompilerGenerated]
	private ValueInput <name>k__BackingField; //Field offset: 0xA0

	protected virtual string hookName
	{
		 get { } //Length: 44
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

	public BoltUnityEvent() { }

	protected virtual void Definition() { }

	protected virtual string get_hookName() { }

	[CompilerGenerated]
	public ValueInput get_name() { }

	[CompilerGenerated]
	private void set_name(ValueInput value) { }

	protected virtual bool ShouldTrigger(Flow flow, string name) { }

}

