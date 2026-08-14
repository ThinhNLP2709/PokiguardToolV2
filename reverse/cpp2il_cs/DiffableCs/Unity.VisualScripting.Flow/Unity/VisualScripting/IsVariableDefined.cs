namespace Unity.VisualScripting;

[UnitTitle("Has Variable")]
public sealed class IsVariableDefined : UnifiedVariableUnit
{
	[CompilerGenerated]
	private ValueOutput <isVariableDefined>k__BackingField; //Field offset: 0xA8

	[DoNotSerialize]
	[PortKey("isDefined")]
	[PortLabel("Defined")]
	[PortLabelHidden]
	public private ValueOutput isVariableDefined
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public IsVariableDefined() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ValueOutput get_isVariableDefined() { }

	private bool IsDefined(Flow flow) { }

	[CompilerGenerated]
	private void set_isVariableDefined(ValueOutput value) { }

}

