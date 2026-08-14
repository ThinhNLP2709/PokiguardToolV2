namespace Unity.VisualScripting;

[TypeIcon(typeof(CharacterController))]
[UnitCategory("Events/Physics")]
public sealed class OnControllerColliderHit : GameObjectEventUnit<ControllerColliderHit>
{
	[CompilerGenerated]
	private ValueOutput <collider>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueOutput <controller>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueOutput <moveDirection>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ValueOutput <moveLength>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private ValueOutput <normal>k__BackingField; //Field offset: 0xC8
	[CompilerGenerated]
	private ValueOutput <point>k__BackingField; //Field offset: 0xD0
	[CompilerGenerated]
	private ValueOutput <data>k__BackingField; //Field offset: 0xD8

	[DoNotSerialize]
	public private ValueOutput collider
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput controller
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput data
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

	[DoNotSerialize]
	public private ValueOutput moveDirection
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput moveLength
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput normal
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput point
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public OnControllerColliderHit() { }

	protected virtual void AssignArguments(Flow flow, ControllerColliderHit hitData) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_collider() { }

	[CompilerGenerated]
	public ValueOutput get_controller() { }

	[CompilerGenerated]
	public ValueOutput get_data() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

	[CompilerGenerated]
	public ValueOutput get_moveDirection() { }

	[CompilerGenerated]
	public ValueOutput get_moveLength() { }

	[CompilerGenerated]
	public ValueOutput get_normal() { }

	[CompilerGenerated]
	public ValueOutput get_point() { }

	[CompilerGenerated]
	private void set_collider(ValueOutput value) { }

	[CompilerGenerated]
	private void set_controller(ValueOutput value) { }

	[CompilerGenerated]
	private void set_data(ValueOutput value) { }

	[CompilerGenerated]
	private void set_moveDirection(ValueOutput value) { }

	[CompilerGenerated]
	private void set_moveLength(ValueOutput value) { }

	[CompilerGenerated]
	private void set_normal(ValueOutput value) { }

	[CompilerGenerated]
	private void set_point(ValueOutput value) { }

}

