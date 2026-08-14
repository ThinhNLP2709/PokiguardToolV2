namespace Unity.VisualScripting;

[Obsolete("Use Wait For Seconds or Timer instead.")]
[UnitCategory("Events/Time")]
public sealed class OnTimerElapsed : MachineEventUnit<EmptyEventArgs>
{
	internal class Data : Data<EmptyEventArgs>
	{
		public float time; //Field offset: 0x40
		public bool triggered; //Field offset: 0x44

		public Data() { }

	}

	[CompilerGenerated]
	private ValueInput <seconds>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueInput <unscaledTime>k__BackingField; //Field offset: 0xA8

	protected virtual string hookName
	{
		 get { } //Length: 44
	}

	[DoNotSerialize]
	[PortLabel("Delay")]
	public private ValueInput seconds
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Unscaled")]
	public private ValueInput unscaledTime
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public OnTimerElapsed() { }

	public virtual IGraphElementData CreateData() { }

	protected virtual void Definition() { }

	protected virtual string get_hookName() { }

	[CompilerGenerated]
	public ValueInput get_seconds() { }

	[CompilerGenerated]
	public ValueInput get_unscaledTime() { }

	[CompilerGenerated]
	private void set_seconds(ValueInput value) { }

	[CompilerGenerated]
	private void set_unscaledTime(ValueInput value) { }

	protected virtual bool ShouldTrigger(Flow flow, EmptyEventArgs args) { }

	public virtual void StartListening(GraphStack stack) { }

}

