namespace Unity.VisualScripting;

[UnitCategory("Events")]
[UnitOrder(0)]
public sealed class CustomEvent : GameObjectEventUnit<CustomEventArgs>
{
	[SerializeAs("argumentCount")]
	private int _argumentCount; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueInput <name>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private readonly List<ValueOutput> <argumentPorts>k__BackingField; //Field offset: 0xB8

	[DoNotSerialize]
	[Inspectable]
	[UnitHeaderInspectable("Arguments")]
	public int argumentCount
	{
		 get { } //Length: 7
		 set { } //Length: 38
	}

	[DoNotSerialize]
	public List<ValueOutput> argumentPorts
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 3
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueInput name
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public CustomEvent() { }

	protected virtual void AssignArguments(Flow flow, CustomEventArgs args) { }

	protected virtual void Definition() { }

	public int get_argumentCount() { }

	[CompilerGenerated]
	public List<ValueOutput> get_argumentPorts() { }

	protected virtual string get_hookName() { }

	public virtual Type get_MessageListenerType() { }

	[CompilerGenerated]
	public ValueInput get_name() { }

	public void set_argumentCount(int value) { }

	[CompilerGenerated]
	private void set_name(ValueInput value) { }

	protected virtual bool ShouldTrigger(Flow flow, CustomEventArgs args) { }

	public static void Trigger(GameObject target, string name, Object[] args) { }

}

