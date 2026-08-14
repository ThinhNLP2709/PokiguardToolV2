namespace Unity.VisualScripting;

[UnitCategory("Events/Physics 2D")]
public abstract class CollisionEvent2DUnit : GameObjectEventUnit<Collision2D>
{
	[CompilerGenerated]
	private ValueOutput <collider>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueOutput <contacts>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueOutput <relativeVelocity>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ValueOutput <enabled>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private ValueOutput <data>k__BackingField; //Field offset: 0xC8

	[DoNotSerialize]
	public private ValueOutput collider
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput contacts
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

	[DoNotSerialize]
	public private ValueOutput enabled
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueOutput relativeVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected CollisionEvent2DUnit() { }

	protected virtual void AssignArguments(Flow flow, Collision2D collisionData) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_collider() { }

	[CompilerGenerated]
	public ValueOutput get_contacts() { }

	[CompilerGenerated]
	public ValueOutput get_data() { }

	[CompilerGenerated]
	public ValueOutput get_enabled() { }

	[CompilerGenerated]
	public ValueOutput get_relativeVelocity() { }

	[CompilerGenerated]
	private void set_collider(ValueOutput value) { }

	[CompilerGenerated]
	private void set_contacts(ValueOutput value) { }

	[CompilerGenerated]
	private void set_data(ValueOutput value) { }

	[CompilerGenerated]
	private void set_enabled(ValueOutput value) { }

	[CompilerGenerated]
	private void set_relativeVelocity(ValueOutput value) { }

}

