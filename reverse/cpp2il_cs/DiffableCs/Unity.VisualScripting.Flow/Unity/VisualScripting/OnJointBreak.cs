namespace Unity.VisualScripting;

[UnitCategory("Events/Physics")]
public sealed class OnJointBreak : GameObjectEventUnit<Single>
{
	[CompilerGenerated]
	private ValueOutput <breakForce>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	public private ValueOutput breakForce
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

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	public OnJointBreak() { }

	protected virtual void AssignArguments(Flow flow, float breakForce) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_breakForce() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

	[CompilerGenerated]
	private void set_breakForce(ValueOutput value) { }

}

