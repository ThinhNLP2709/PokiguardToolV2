namespace Unity.VisualScripting;

[UnitCategory("Events/Navigation")]
public sealed class OnDestinationReached : MachineEventUnit<EmptyEventArgs>
{
	[CompilerGenerated]
	private ValueInput <threshold>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueInput <requireSuccess>k__BackingField; //Field offset: 0xA8

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	[DoNotSerialize]
	public private ValueInput requireSuccess
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueInput threshold
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public OnDestinationReached() { }

	protected virtual void Definition() { }

	protected virtual string get_hookName() { }

	[CompilerGenerated]
	public ValueInput get_requireSuccess() { }

	[CompilerGenerated]
	public ValueInput get_threshold() { }

	[CompilerGenerated]
	private void set_requireSuccess(ValueInput value) { }

	[CompilerGenerated]
	private void set_threshold(ValueInput value) { }

	protected virtual bool ShouldTrigger(Flow flow, EmptyEventArgs args) { }

}

