namespace Unity.VisualScripting;

[RenamedFrom("Bolt.CreateDitionary")]
[TypeIcon(typeof(IDictionary))]
[UnitCategory("Collections/Dictionaries")]
[UnitOrder(-1)]
public sealed class CreateDictionary : Unit
{
	[CompilerGenerated]
	private ValueOutput <dictionary>k__BackingField; //Field offset: 0x90

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput dictionary
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public CreateDictionary() { }

	public IDictionary Create(Flow flow) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_dictionary() { }

	[CompilerGenerated]
	private void set_dictionary(ValueOutput value) { }

}

