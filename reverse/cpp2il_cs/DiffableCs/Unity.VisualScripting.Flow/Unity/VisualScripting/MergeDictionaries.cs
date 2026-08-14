namespace Unity.VisualScripting;

[UnitCategory("Collections/Dictionaries")]
[UnitOrder(5)]
public sealed class MergeDictionaries : MultiInputUnit<IDictionary>
{
	[CompilerGenerated]
	private ValueOutput <dictionary>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput dictionary
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public MergeDictionaries() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_dictionary() { }

	public IDictionary Merge(Flow flow) { }

	[CompilerGenerated]
	private void set_dictionary(ValueOutput value) { }

}

