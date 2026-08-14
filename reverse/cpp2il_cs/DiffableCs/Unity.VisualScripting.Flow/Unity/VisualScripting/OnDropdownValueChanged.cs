namespace Unity.VisualScripting;

[TypeIcon(typeof(Dropdown))]
[UnitCategory("Events/GUI")]
[UnitOrder(4)]
public sealed class OnDropdownValueChanged : GameObjectEventUnit<Int32>
{
	[CompilerGenerated]
	private ValueOutput <index>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueOutput <text>k__BackingField; //Field offset: 0xB0

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	[DoNotSerialize]
	public private ValueOutput index
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public virtual Type MessageListenerType
	{
		 get { } //Length: 77
	}

	[DoNotSerialize]
	public private ValueOutput text
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public OnDropdownValueChanged() { }

	protected virtual void AssignArguments(Flow flow, int index) { }

	protected virtual void Definition() { }

	protected virtual string get_hookName() { }

	[CompilerGenerated]
	public ValueOutput get_index() { }

	public virtual Type get_MessageListenerType() { }

	[CompilerGenerated]
	public ValueOutput get_text() { }

	[CompilerGenerated]
	private void set_index(ValueOutput value) { }

	[CompilerGenerated]
	private void set_text(ValueOutput value) { }

}

