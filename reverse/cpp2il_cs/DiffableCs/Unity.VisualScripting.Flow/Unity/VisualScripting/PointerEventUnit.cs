namespace Unity.VisualScripting;

public abstract class PointerEventUnit : GameObjectEventUnit<PointerEventData>
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

	protected PointerEventUnit() { }

	protected virtual void AssignArguments(Flow flow, PointerEventData data) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_data() { }

	[CompilerGenerated]
	private void set_data(ValueOutput value) { }

}

