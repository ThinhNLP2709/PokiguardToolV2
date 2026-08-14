namespace Unity.VisualScripting;

[UnitCategory("Events/GUI")]
[UnitOrder(21)]
public sealed class OnMove : GameObjectEventUnit<AxisEventData>
{
	[CompilerGenerated]
	private ValueOutput <data>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	[PortLabelHidden]
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

	public OnMove() { }

	protected virtual void AssignArguments(Flow flow, AxisEventData data) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_data() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

	[CompilerGenerated]
	private void set_data(ValueOutput value) { }

}

