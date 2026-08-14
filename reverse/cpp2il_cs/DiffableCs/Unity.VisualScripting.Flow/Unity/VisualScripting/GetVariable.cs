namespace Unity.VisualScripting;

public sealed class GetVariable : UnifiedVariableUnit
{
	[CompilerGenerated]
	private ValueOutput <value>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueInput <fallback>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private bool <specifyFallback>k__BackingField; //Field offset: 0xB8

	[DoNotSerialize]
	public private ValueInput fallback
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[Inspectable]
	[InspectorLabel("Fallback")]
	[Serialize]
	public bool specifyFallback
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
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

	public GetVariable() { }

	protected virtual void Definition() { }

	private object Get(Flow flow) { }

	[CompilerGenerated]
	public ValueInput get_fallback() { }

	[CompilerGenerated]
	public bool get_specifyFallback() { }

	[CompilerGenerated]
	public ValueOutput get_value() { }

	private bool IsDefined(Flow flow) { }

	[CompilerGenerated]
	private void set_fallback(ValueInput value) { }

	[CompilerGenerated]
	public void set_specifyFallback(bool value) { }

	[CompilerGenerated]
	private void set_value(ValueOutput value) { }

}

