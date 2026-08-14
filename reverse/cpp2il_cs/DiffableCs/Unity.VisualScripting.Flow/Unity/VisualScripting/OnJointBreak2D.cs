namespace Unity.VisualScripting;

[UnitCategory("Events/Physics 2D")]
public sealed class OnJointBreak2D : GameObjectEventUnit<Joint2D>
{
	[CompilerGenerated]
	private ValueOutput <breakForce>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueOutput <breakTorque>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueOutput <connectedBody>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ValueOutput <reactionForce>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private ValueOutput <reactionTorque>k__BackingField; //Field offset: 0xC8
	[CompilerGenerated]
	private ValueOutput <joint>k__BackingField; //Field offset: 0xD0

	[DoNotSerialize]
	public private ValueOutput breakForce
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput breakTorque
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput connectedBody
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
	public private ValueOutput joint
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	[DoNotSerialize]
	public private ValueOutput reactionForce
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput reactionTorque
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public OnJointBreak2D() { }

	protected virtual void AssignArguments(Flow flow, Joint2D joint) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_breakForce() { }

	[CompilerGenerated]
	public ValueOutput get_breakTorque() { }

	[CompilerGenerated]
	public ValueOutput get_connectedBody() { }

	protected virtual string get_hookName() { }

	[CompilerGenerated]
	public ValueOutput get_joint() { }

	public virtual Type get_MessageListenerType() { }

	[CompilerGenerated]
	public ValueOutput get_reactionForce() { }

	[CompilerGenerated]
	public ValueOutput get_reactionTorque() { }

	[CompilerGenerated]
	private void set_breakForce(ValueOutput value) { }

	[CompilerGenerated]
	private void set_breakTorque(ValueOutput value) { }

	[CompilerGenerated]
	private void set_connectedBody(ValueOutput value) { }

	[CompilerGenerated]
	private void set_joint(ValueOutput value) { }

	[CompilerGenerated]
	private void set_reactionForce(ValueOutput value) { }

	[CompilerGenerated]
	private void set_reactionTorque(ValueOutput value) { }

}

