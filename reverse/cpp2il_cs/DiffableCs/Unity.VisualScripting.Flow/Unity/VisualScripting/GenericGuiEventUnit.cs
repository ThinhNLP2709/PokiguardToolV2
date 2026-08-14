namespace Unity.VisualScripting;

public abstract class GenericGuiEventUnit : GameObjectEventUnit<BaseEventData>
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

	protected GenericGuiEventUnit() { }

	protected virtual void AssignArguments(Flow flow, BaseEventData data) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_data() { }

	[CompilerGenerated]
	private void set_data(ValueOutput value) { }

}

