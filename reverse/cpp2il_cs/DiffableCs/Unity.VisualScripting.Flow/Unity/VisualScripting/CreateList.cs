namespace Unity.VisualScripting;

[TypeIcon(typeof(IList))]
[UnitCategory("Collections/Lists")]
[UnitOrder(-1)]
public sealed class CreateList : MultiInputUnit<Object>
{
	[CompilerGenerated]
	private ValueOutput <list>k__BackingField; //Field offset: 0xA0

	[Inspectable]
	[InspectorLabel("Elements")]
	[UnitHeaderInspectable("Elements")]
	public virtual int inputCount
	{
		 get { } //Length: 61
		 set { } //Length: 70
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput list
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	protected virtual int minInputCount
	{
		 get { } //Length: 3
	}

	public CreateList() { }

	public IList Create(Flow flow) { }

	protected virtual void Definition() { }

	public virtual int get_inputCount() { }

	[CompilerGenerated]
	public ValueOutput get_list() { }

	protected virtual int get_minInputCount() { }

	public virtual void set_inputCount(int value) { }

	[CompilerGenerated]
	private void set_list(ValueOutput value) { }

}

