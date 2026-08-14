namespace Unity.VisualScripting;

[UnitCategory("Events/Physics")]
public abstract class TriggerEventUnit : GameObjectEventUnit<Collider>
{
	[CompilerGenerated]
	private ValueOutput <collider>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	public private ValueOutput collider
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected TriggerEventUnit() { }

	protected virtual void AssignArguments(Flow flow, Collider other) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_collider() { }

	[CompilerGenerated]
	private void set_collider(ValueOutput value) { }

}

