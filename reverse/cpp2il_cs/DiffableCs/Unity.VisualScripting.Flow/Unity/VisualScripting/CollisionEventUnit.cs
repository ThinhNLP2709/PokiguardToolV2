namespace Unity.VisualScripting;

[UnitCategory("Events/Physics")]
public abstract class CollisionEventUnit : GameObjectEventUnit<Collision>
{
	[CompilerGenerated]
	private ValueOutput <collider>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueOutput <contacts>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueOutput <impulse>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ValueOutput <relativeVelocity>k__BackingField; //Field offset: 0xC0
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
	public private ValueOutput impulse
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

	protected CollisionEventUnit() { }

	protected virtual void AssignArguments(Flow flow, Collision collision) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_collider() { }

	[CompilerGenerated]
	public ValueOutput get_contacts() { }

	[CompilerGenerated]
	public ValueOutput get_data() { }

	[CompilerGenerated]
	public ValueOutput get_impulse() { }

	[CompilerGenerated]
	public ValueOutput get_relativeVelocity() { }

	[CompilerGenerated]
	private void set_collider(ValueOutput value) { }

	[CompilerGenerated]
	private void set_contacts(ValueOutput value) { }

	[CompilerGenerated]
	private void set_data(ValueOutput value) { }

	[CompilerGenerated]
	private void set_impulse(ValueOutput value) { }

	[CompilerGenerated]
	private void set_relativeVelocity(ValueOutput value) { }

}

