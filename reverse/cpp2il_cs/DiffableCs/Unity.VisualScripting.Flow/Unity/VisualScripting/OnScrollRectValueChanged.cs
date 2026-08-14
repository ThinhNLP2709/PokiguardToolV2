namespace Unity.VisualScripting;

[TypeIcon(typeof(ScrollRect))]
[UnitCategory("Events/GUI")]
[UnitOrder(7)]
public sealed class OnScrollRectValueChanged : GameObjectEventUnit<Vector2>
{
	[CompilerGenerated]
	private ValueOutput <value>k__BackingField; //Field offset: 0xA8

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput value
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public OnScrollRectValueChanged() { }

	protected virtual void AssignArguments(Flow flow, Vector2 value) { }

	protected virtual void Definition() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

	[CompilerGenerated]
	public ValueOutput get_value() { }

	[CompilerGenerated]
	private void set_value(ValueOutput value) { }

}

