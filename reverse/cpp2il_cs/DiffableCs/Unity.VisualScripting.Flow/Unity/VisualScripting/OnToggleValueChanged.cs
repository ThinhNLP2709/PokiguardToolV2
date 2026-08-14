namespace Unity.VisualScripting;

[TypeIcon(typeof(Toggle))]
[UnitCategory("Events/GUI")]
[UnitOrder(5)]
public sealed class OnToggleValueChanged : GameObjectEventUnit<Boolean>
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

	public OnToggleValueChanged() { }

	protected virtual void AssignArguments(Flow flow, bool value) { }

	protected virtual void Definition() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

	[CompilerGenerated]
	public ValueOutput get_value() { }

	[CompilerGenerated]
	private void set_value(ValueOutput value) { }

}

