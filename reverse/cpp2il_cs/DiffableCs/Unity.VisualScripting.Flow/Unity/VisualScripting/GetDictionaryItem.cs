namespace Unity.VisualScripting;

[TypeIcon(typeof(IDictionary))]
[UnitCategory("Collections/Dictionaries")]
[UnitOrder(0)]
[UnitShortTitle("Get Item")]
[UnitSurtitle("Dictionary")]
public sealed class GetDictionaryItem : Unit
{
	[CompilerGenerated]
	private ValueInput <dictionary>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <key>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <value>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueInput dictionary
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueInput key
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
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

	public GetDictionaryItem() { }

	protected virtual void Definition() { }

	private object Get(Flow flow) { }

	[CompilerGenerated]
	public ValueInput get_dictionary() { }

	[CompilerGenerated]
	public ValueInput get_key() { }

	[CompilerGenerated]
	public ValueOutput get_value() { }

	[CompilerGenerated]
	private void set_dictionary(ValueInput value) { }

	[CompilerGenerated]
	private void set_key(ValueInput value) { }

	[CompilerGenerated]
	private void set_value(ValueOutput value) { }

}

