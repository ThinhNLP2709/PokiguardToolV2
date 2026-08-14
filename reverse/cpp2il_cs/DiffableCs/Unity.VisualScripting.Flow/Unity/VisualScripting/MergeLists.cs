namespace Unity.VisualScripting;

[UnitCategory("Collections/Lists")]
[UnitOrder(7)]
public sealed class MergeLists : MultiInputUnit<IEnumerable>
{
	[CompilerGenerated]
	private ValueOutput <list>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput list
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public MergeLists() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_list() { }

	public IList Merge(Flow flow) { }

	[CompilerGenerated]
	private void set_list(ValueOutput value) { }

}

