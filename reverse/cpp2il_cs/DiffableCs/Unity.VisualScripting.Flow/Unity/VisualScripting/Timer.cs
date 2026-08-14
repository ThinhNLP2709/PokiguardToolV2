namespace Unity.VisualScripting;

[UnitCategory("Time")]
[UnitOrder(7)]
public sealed class Timer : Unit, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphEventListener
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass55_0
	{
		public Timer <>4__this; //Field offset: 0x10
		public GraphReference reference; //Field offset: 0x18

		public <>c__DisplayClass55_0() { }

		internal void <StartListening>b__0(EmptyEventArgs args) { }

	}

	internal sealed class Data : IGraphElementData
	{
		public float elapsed; //Field offset: 0x10
		public float duration; //Field offset: 0x14
		public bool active; //Field offset: 0x18
		public bool paused; //Field offset: 0x19
		public bool unscaled; //Field offset: 0x1A
		public Delegate update; //Field offset: 0x20
		public bool isListening; //Field offset: 0x28

		public Data() { }

	}

	[CompilerGenerated]
	private ControlInput <start>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ControlInput <pause>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ControlInput <resume>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ControlInput <toggle>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ValueInput <duration>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ValueInput <unscaledTime>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ControlOutput <started>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private ControlOutput <tick>k__BackingField; //Field offset: 0xC8
	[CompilerGenerated]
	private ControlOutput <completed>k__BackingField; //Field offset: 0xD0
	[CompilerGenerated]
	private ValueOutput <elapsedSeconds>k__BackingField; //Field offset: 0xD8
	[CompilerGenerated]
	private ValueOutput <elapsedRatio>k__BackingField; //Field offset: 0xE0
	[CompilerGenerated]
	private ValueOutput <remainingSeconds>k__BackingField; //Field offset: 0xE8
	[CompilerGenerated]
	private ValueOutput <remainingRatio>k__BackingField; //Field offset: 0xF0

	[DoNotSerialize]
	public private ControlOutput completed
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ValueInput duration
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Elapsed %")]
	public private ValueOutput elapsedRatio
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Elapsed")]
	public private ValueOutput elapsedSeconds
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ControlInput pause
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Remaining %")]
	public private ValueOutput remainingRatio
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Remaining")]
	public private ValueOutput remainingSeconds
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ControlInput resume
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ControlInput start
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ControlOutput started
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ControlOutput tick
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	public private ControlInput toggle
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

	public Timer() { }

	private void AssignMetrics(Flow flow, Data data) { }

	public override IGraphElementData CreateData() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public ControlOutput get_completed() { }

	[CompilerGenerated]
	public ValueInput get_duration() { }

	[CompilerGenerated]
	public ValueOutput get_elapsedRatio() { }

	[CompilerGenerated]
	public ValueOutput get_elapsedSeconds() { }

	[CompilerGenerated]
	public ControlInput get_pause() { }

	[CompilerGenerated]
	public ValueOutput get_remainingRatio() { }

	[CompilerGenerated]
	public ValueOutput get_remainingSeconds() { }

	[CompilerGenerated]
	public ControlInput get_resume() { }

	[CompilerGenerated]
	public ControlInput get_start() { }

	[CompilerGenerated]
	public ControlOutput get_started() { }

	[CompilerGenerated]
	public ControlOutput get_tick() { }

	[CompilerGenerated]
	public ControlInput get_toggle() { }

	[CompilerGenerated]
	public ValueInput get_unscaledTime() { }

	public override bool IsListening(GraphPointer pointer) { }

	private ControlOutput Pause(Flow flow) { }

	private ControlOutput Resume(Flow flow) { }

	[CompilerGenerated]
	private void set_completed(ControlOutput value) { }

	[CompilerGenerated]
	private void set_duration(ValueInput value) { }

	[CompilerGenerated]
	private void set_elapsedRatio(ValueOutput value) { }

	[CompilerGenerated]
	private void set_elapsedSeconds(ValueOutput value) { }

	[CompilerGenerated]
	private void set_pause(ControlInput value) { }

	[CompilerGenerated]
	private void set_remainingRatio(ValueOutput value) { }

	[CompilerGenerated]
	private void set_remainingSeconds(ValueOutput value) { }

	[CompilerGenerated]
	private void set_resume(ControlInput value) { }

	[CompilerGenerated]
	private void set_start(ControlInput value) { }

	[CompilerGenerated]
	private void set_started(ControlOutput value) { }

	[CompilerGenerated]
	private void set_tick(ControlOutput value) { }

	[CompilerGenerated]
	private void set_toggle(ControlInput value) { }

	[CompilerGenerated]
	private void set_unscaledTime(ValueInput value) { }

	private ControlOutput Start(Flow flow) { }

	public override void StartListening(GraphStack stack) { }

	public override void StopListening(GraphStack stack) { }

	private ControlOutput Toggle(Flow flow) { }

	private void TriggerUpdate(GraphReference reference) { }

	public void Update(Flow flow) { }

}

