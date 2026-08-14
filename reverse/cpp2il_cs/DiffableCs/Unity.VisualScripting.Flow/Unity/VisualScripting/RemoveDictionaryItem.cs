namespace Unity.VisualScripting;

[UnitCategory("Collections/Dictionaries")]
[UnitOrder(3)]
[UnitShortTitle("Remove Item")]
[UnitSurtitle("Dictionary")]
public sealed class RemoveDictionaryItem : Unit
{
	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ValueInput <dictionaryInput>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueOutput <dictionaryOutput>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueInput <key>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ControlOutput <exit>k__BackingField; //Field offset: 0xB0

	[DoNotSerialize]
	[PortLabel("Dictionary")]
	[PortLabelHidden]
	public private ValueInput dictionaryInput
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Dictionary")]
	[PortLabelHidden]
	public private ValueOutput dictionaryOutput
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

	public RemoveDictionaryItem() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueInput get_dictionaryInput() { }

	[CompilerGenerated]
	public ValueOutput get_dictionaryOutput() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exit() { }

	[CompilerGenerated]
	public ValueInput get_key() { }

	public ControlOutput Remove(Flow flow) { }

	[CompilerGenerated]
	private void set_dictionaryInput(ValueInput value) { }

	[CompilerGenerated]
	private void set_dictionaryOutput(ValueOutput value) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exit(ControlOutput value) { }

	[CompilerGenerated]
	private void set_key(ValueInput value) { }

}

