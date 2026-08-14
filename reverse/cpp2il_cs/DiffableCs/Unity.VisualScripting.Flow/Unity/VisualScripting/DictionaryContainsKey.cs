namespace Unity.VisualScripting;

[TypeIcon(typeof(IDictionary))]
[UnitCategory("Collections/Dictionaries")]
[UnitShortTitle("Contains Key")]
[UnitSurtitle("Dictionary")]
public sealed class DictionaryContainsKey : Unit
{
	[CompilerGenerated]
	private ValueInput <dictionary>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <key>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <contains>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput contains
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

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
	[PortLabelHidden]
	public private ValueInput key
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public DictionaryContainsKey() { }

	private bool Contains(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_contains() { }

	[CompilerGenerated]
	public ValueInput get_dictionary() { }

	[CompilerGenerated]
	public ValueInput get_key() { }

	[CompilerGenerated]
	private void set_contains(ValueOutput value) { }

	[CompilerGenerated]
	private void set_dictionary(ValueInput value) { }

	[CompilerGenerated]
	private void set_key(ValueInput value) { }

}

