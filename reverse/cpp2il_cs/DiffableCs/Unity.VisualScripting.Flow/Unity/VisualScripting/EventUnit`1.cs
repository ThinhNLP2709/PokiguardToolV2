namespace Unity.VisualScripting;

[SerializationVersion("A", new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {})]
[SpecialUnit]
public abstract class EventUnit : Unit, IEventUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphEventListener, IGraphElementWithData, IGraphEventHandler<TArgs>
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public EventUnit<TArgs> <>4__this; //Field offset: 0x0
		public GraphReference reference; //Field offset: 0x0

		public <>c__DisplayClass14_0() { }

		internal void <StartListening>b__0(TArgs args) { }

	}

	internal class Data : IGraphElementData
	{
		public EventHook hook; //Field offset: 0x0
		public Delegate handler; //Field offset: 0x0
		public bool isListening; //Field offset: 0x0
		public HashSet<Flow> activeCoroutines; //Field offset: 0x0

		public Data() { }

	}

	[CompilerGenerated]
	private bool <coroutine>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ControlOutput <trigger>k__BackingField; //Field offset: 0x0

	[Inspectable]
	[InspectorExpandTooltip]
	[Serialize]
	public override bool coroutine
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 7
	}

	[DoNotSerialize]
	protected abstract bool register
	{
		 get { } //Length: 0
	}

	[DoNotSerialize]
	[PortLabelHidden]
	public private ControlOutput trigger
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	protected EventUnit`1() { }

	protected override void AssignArguments(Flow flow, TArgs args) { }

	protected static bool CompareNames(Flow flow, ValueInput namePort, string calledName) { }

	public override IGraphElementData CreateData() { }

	protected virtual void Definition() { }

	[CompilerGenerated]
	public override bool get_coroutine() { }

	protected abstract bool get_register() { }

	[CompilerGenerated]
	public ControlOutput get_trigger() { }

	public override EventHook GetHook(GraphReference reference) { }

	override void InternalTrigger(GraphReference reference, TArgs args) { }

	public override bool IsListening(GraphPointer pointer) { }

	private void Run(Flow flow) { }

	[CompilerGenerated]
	public void set_coroutine(bool value) { }

	[CompilerGenerated]
	private void set_trigger(ControlOutput value) { }

	protected override bool ShouldTrigger(Flow flow, TArgs args) { }

	public override void StartListening(GraphStack stack) { }

	private static void StopAllCoroutines(HashSet<Flow> activeCoroutines) { }

	public override void StopListening(GraphStack stack) { }

	public override void Trigger(GraphReference reference, TArgs args) { }

	public virtual void Uninstantiate(GraphReference instance) { }

	private override FlowGraph Unity.VisualScripting.IUnit.get_graph() { }

}

