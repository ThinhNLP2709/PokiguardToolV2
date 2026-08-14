namespace Unity.VisualScripting;

[TypeIcon(typeof(Timer))]
[UnitCategory("Time")]
[UnitOrder(8)]
public sealed class Cooldown : Unit, IGraphElementWithData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphEventListener
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass43_0
	{
		public Cooldown <>4__this; //Field offset: 0x10
		public GraphReference reference; //Field offset: 0x18

		public <>c__DisplayClass43_0() { }

		internal void <StartListening>b__0(EmptyEventArgs args) { }

	}

	internal sealed class Data : IGraphElementData
	{
		public float remaining; //Field offset: 0x10
		public float duration; //Field offset: 0x14
		public bool unscaled; //Field offset: 0x18
		public Delegate update; //Field offset: 0x20
		public bool isListening; //Field offset: 0x28

		public bool isReady
		{
			 get { } //Length: 11
		}

		public Data() { }

		public bool get_isReady() { }

	}

	[CompilerGenerated]
	private ControlInput <enter>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private ControlInput <reset>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ValueInput <duration>k__BackingField; //Field offset: 0xA0
	[CompilerGenerated]
	private ValueInput <unscaledTime>k__BackingField; //Field offset: 0xA8
	[CompilerGenerated]
	private ControlOutput <exitReady>k__BackingField; //Field offset: 0xB0
	[CompilerGenerated]
	private ControlOutput <exitNotReady>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private ControlOutput <tick>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private ControlOutput <becameReady>k__BackingField; //Field offset: 0xC8
	[CompilerGenerated]
	private ValueOutput <remainingSeconds>k__BackingField; //Field offset: 0xD0
	[CompilerGenerated]
	private ValueOutput <remainingRatio>k__BackingField; //Field offset: 0xD8

	[DoNotSerialize]
	[PortLabel("Completed")]
	public private ControlOutput becameReady
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
	[PortLabelHidden]
	public private ControlInput enter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Not Ready")]
	public private ControlOutput exitNotReady
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	[DoNotSerialize]
	[PortLabel("Ready")]
	public private ControlOutput exitReady
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
	public private ControlInput reset
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
	[PortLabel("Unscaled")]
	public private ValueInput unscaledTime
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	public Cooldown() { }

	private void AssignMetrics(Flow flow, Data data) { }

	public override IGraphElementData CreateData() { }

	protected virtual void Definition() { }

	private ControlOutput Enter(Flow flow) { }

	[CompilerGenerated]
	public ControlOutput get_becameReady() { }

	[CompilerGenerated]
	public ValueInput get_duration() { }

	[CompilerGenerated]
	public ControlInput get_enter() { }

	[CompilerGenerated]
	public ControlOutput get_exitNotReady() { }

	[CompilerGenerated]
	public ControlOutput get_exitReady() { }

	[CompilerGenerated]
	public ValueOutput get_remainingRatio() { }

	[CompilerGenerated]
	public ValueOutput get_remainingSeconds() { }

	[CompilerGenerated]
	public ControlInput get_reset() { }

	[CompilerGenerated]
	public ControlOutput get_tick() { }

	[CompilerGenerated]
	public ValueInput get_unscaledTime() { }

	public override bool IsListening(GraphPointer pointer) { }

	private ControlOutput Reset(Flow flow) { }

	[CompilerGenerated]
	private void set_becameReady(ControlOutput value) { }

	[CompilerGenerated]
	private void set_duration(ValueInput value) { }

	[CompilerGenerated]
	private void set_enter(ControlInput value) { }

	[CompilerGenerated]
	private void set_exitNotReady(ControlOutput value) { }

	[CompilerGenerated]
	private void set_exitReady(ControlOutput value) { }

	[CompilerGenerated]
	private void set_remainingRatio(ValueOutput value) { }

	[CompilerGenerated]
	private void set_remainingSeconds(ValueOutput value) { }

	[CompilerGenerated]
	private void set_reset(ControlInput value) { }

	[CompilerGenerated]
	private void set_tick(ControlOutput value) { }

	[CompilerGenerated]
	private void set_unscaledTime(ValueInput value) { }

	public override void StartListening(GraphStack stack) { }

	public override void StopListening(GraphStack stack) { }

	private void TriggerUpdate(GraphReference reference) { }

	public void Update(Flow flow) { }

}

