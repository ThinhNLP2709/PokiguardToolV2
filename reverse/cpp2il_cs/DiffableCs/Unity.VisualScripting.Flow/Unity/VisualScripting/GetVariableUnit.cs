namespace Unity.VisualScripting;

[UnitShortTitle("Get Variable")]
public abstract class GetVariableUnit : VariableUnit
{
	[CompilerGenerated]
	private ValueOutput <value>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	[PortLabelHidden]
	public private ValueOutput value
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected GetVariableUnit() { }

	protected GetVariableUnit(string defaultName) { }

	protected virtual void Definition() { }

	protected override object Get(Flow flow) { }

	[CompilerGenerated]
	public ValueOutput get_value() { }

	protected override bool IsDefined(Flow flow) { }

	[CompilerGenerated]
	private void set_value(ValueOutput value) { }

}

