namespace Unity.VisualScripting;

[UnitCategory("Events/Physics 2D")]
public abstract class TriggerEvent2DUnit : GameObjectEventUnit<Collider2D>
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

	protected TriggerEvent2DUnit() { }

	protected virtual void AssignArguments(Flow flow, Collider2D other) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_collider() { }

	[CompilerGenerated]
	private void set_collider(ValueOutput value) { }

}

