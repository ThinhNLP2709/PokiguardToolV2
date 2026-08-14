namespace Unity.VisualScripting;

[TypeIcon(typeof(IDictionary))]
[UnitCategory("Collections/Dictionaries")]
[UnitOrder(1)]
[UnitShortTitle("Set Item")]
[UnitSurtitle("Dictionary")]
public sealed class SetDictionaryItem : Unit
{
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <dictionary>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueInput <key>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueInput <value>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ControlOutput <exit>k__BackingField; //Field offset: 0xB0

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
	public private ControlInput enter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ControlOutput exit
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
	public private ValueInput value
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public SetDictionaryItem() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_dictionary() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	[CompilerGenerated]
	public ValueInput get_key() { }

	[CompilerGenerated]
	public ValueInput get_value() { }

	public ControlOutput Set(Flow flow) { }

	[CompilerGenerated]
	private void set_dictionary(ValueInput value) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exit(ControlOutput value) { }

	[CompilerGenerated]
	private void set_key(ValueInput value) { }

	[CompilerGenerated]
	private void set_value(ValueInput value) { }

}

