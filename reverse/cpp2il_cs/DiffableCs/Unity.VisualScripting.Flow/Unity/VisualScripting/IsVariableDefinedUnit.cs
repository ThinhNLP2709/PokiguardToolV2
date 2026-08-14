namespace Unity.VisualScripting;

[UnitShortTitle("Is Variable Defined")]
public abstract class IsVariableDefinedUnit : VariableUnit
{
	[CompilerGenerated]
	private ValueOutput <isDefined>k__BackingField; //Field offset: 0xA0

	[DoNotSerialize]
	[PortLabel("Defined")]
	[PortLabelHidden]
	public private ValueOutput isDefined
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected IsVariableDefinedUnit() { }

	protected IsVariableDefinedUnit(string defaultName) { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_isDefined() { }

	protected override bool IsDefined(Flow flow) { }

	[CompilerGenerated]
	private void set_isDefined(ValueOutput value) { }

}

