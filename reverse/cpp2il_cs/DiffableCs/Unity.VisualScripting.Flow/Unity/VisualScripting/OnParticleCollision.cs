namespace Unity.VisualScripting;

[UnitCategory("Events/Physics")]
public sealed class OnParticleCollision : GameObjectEventUnit<GameObject>
{
	[CompilerGenerated]
	private ValueOutput <other>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueOutput <collisionEvents>k__BackingField; //Field offset: 0xB0

	[DoNotSerialize]
	public private ValueOutput collisionEvents
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
	public private ValueOutput other
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public OnParticleCollision() { }

	protected virtual void AssignArguments(Flow flow, GameObject other) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_collisionEvents() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

	[CompilerGenerated]
	public ValueOutput get_other() { }

	[CompilerGenerated]
	private void set_collisionEvents(ValueOutput value) { }

	[CompilerGenerated]
	private void set_other(ValueOutput value) { }

}

