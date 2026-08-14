namespace UnityEngine.UIElements;

public abstract class EventBase : IDisposable
{
	[Flags]
	public enum EventPropagation
	{
		None = 0,
		Bubbles = 1,
		TricklesDown = 2,
		SkipDisabledElements = 4,
		BubblesOrTricklesDown = 3,
	}

	[Flags]
	private enum LifeCycleStatus
	{
		None = 0,
		PropagationStopped = 1,
		ImmediatePropagationStopped = 2,
		Dispatching = 4,
		Pooled = 8,
		IMGUIEventIsValid = 16,
		PropagateToIMGUI = 32,
		Dispatched = 64,
		Processed = 128,
		ProcessedByFocusController = 256,
	}

	private static long s_LastTypeId; //Field offset: 0x0
	private static ulong s_NextEventId; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly int <eventCategories>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private long <timestamp>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private ulong <eventId>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private ulong <triggerEventId>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventPropagation <propagation>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private LifeCycleStatus <lifeCycleStatus>k__BackingField; //Field offset: 0x34
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private VisualElement <elementTarget>k__BackingField; //Field offset: 0x38
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private PropagationPhase <propagationPhase>k__BackingField; //Field offset: 0x40
	private IEventHandler m_CurrentTarget; //Field offset: 0x48
	private Event m_ImguiEvent; //Field offset: 0x50
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Vector2 <originalMousePosition>k__BackingField; //Field offset: 0x58

	public bool bubbles
	{
		 get { } //Length: 10
		 set { } //Length: 25
	}

	internal bool bubblesOrTricklesDown
	{
		internal get { } //Length: 8
	}

	public internal override IEventHandler currentTarget
	{
		 get { } //Length: 7
		internal set { } //Length: 309
	}

	public internal bool dispatch
	{
		 get { } //Length: 10
		internal set { } //Length: 24
	}

	private bool dispatched
	{
		private get { } //Length: 10
		private set { } //Length: 25
	}

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal VisualElement elementTarget
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	internal int eventCategories
	{
		[CompilerGenerated]
		internal get { } //Length: 4
	}

	internal ulong eventId
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 5
	}

	public override long eventTypeId
	{
		 get { } //Length: 8
	}

	public Event imguiEvent
	{
		 get { } //Length: 16
		 set { } //Length: 199
	}

	private bool imguiEventIsValid
	{
		private get { } //Length: 10
		private set { } //Length: 25
	}

	public private bool isImmediatePropagationStopped
	{
		 get { } //Length: 10
		private set { } //Length: 25
	}

	public private bool isPropagationStopped
	{
		 get { } //Length: 10
		private set { } //Length: 25
	}

	private LifeCycleStatus lifeCycleStatus
	{
		[CompilerGenerated]
		private get { } //Length: 4
		[CompilerGenerated]
		private set { } //Length: 4
	}

	public private Vector2 originalMousePosition
	{
		[CompilerGenerated]
		 get { } //Length: 19
		[CompilerGenerated]
		private set { } //Length: 5
	}

	protected bool pooled
	{
		 get { } //Length: 10
		 set { } //Length: 25
	}

	internal bool processed
	{
		internal get { } //Length: 13
		private set { } //Length: 27
	}

	internal bool processedByFocusController
	{
		internal get { } //Length: 13
		internal set { } //Length: 27
	}

	internal bool propagateToIMGUI
	{
		internal get { } //Length: 10
		internal set { } //Length: 25
	}

	internal EventPropagation propagation
	{
		[CompilerGenerated]
		internal get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal PropagationPhase propagationPhase
	{
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal bool skipDisabledElements
	{
		internal get { } //Length: 10
		internal set { } //Length: 25
	}

	public IEventHandler target
	{
		 get { } //Length: 5
		 set { } //Length: 131
	}

	public private long timestamp
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 5
	}

	public bool tricklesDown
	{
		 get { } //Length: 10
		 set { } //Length: 25
	}

	private ulong triggerEventId
	{
		[CompilerGenerated]
		private set { } //Length: 5
	}

	internal EventBase(EventCategory category) { }

	internal abstract void Acquire() { }

	internal override void Dispatch(BaseVisualElementPanel panel) { }

	public abstract void Dispose() { }

	public bool get_bubbles() { }

	internal bool get_bubblesOrTricklesDown() { }

	public override IEventHandler get_currentTarget() { }

	public bool get_dispatch() { }

	private bool get_dispatched() { }

	[CompilerGenerated]
	internal VisualElement get_elementTarget() { }

	[CompilerGenerated]
	internal int get_eventCategories() { }

	[CompilerGenerated]
	internal ulong get_eventId() { }

	public override long get_eventTypeId() { }

	public Event get_imguiEvent() { }

	private bool get_imguiEventIsValid() { }

	public bool get_isImmediatePropagationStopped() { }

	public bool get_isPropagationStopped() { }

	[CompilerGenerated]
	private LifeCycleStatus get_lifeCycleStatus() { }

	[CompilerGenerated]
	public Vector2 get_originalMousePosition() { }

	protected bool get_pooled() { }

	internal bool get_processed() { }

	internal bool get_processedByFocusController() { }

	internal bool get_propagateToIMGUI() { }

	[CompilerGenerated]
	internal EventPropagation get_propagation() { }

	internal bool get_skipDisabledElements() { }

	public IEventHandler get_target() { }

	[CompilerGenerated]
	public long get_timestamp() { }

	public bool get_tricklesDown() { }

	protected override void Init() { }

	private void LocalInit() { }

	internal void MarkReceivedByDispatcher() { }

	protected private override void PostDispatch(IPanel panel) { }

	[Obsolete("Override PostDispatch(IPanel panel) instead.")]
	protected override void PostDispatch() { }

	protected private override void PreDispatch(IPanel panel) { }

	[Obsolete("Override PreDispatch(IPanel panel) instead.")]
	protected override void PreDispatch() { }

	protected static long RegisterEventType() { }

	protected void set_bubbles(bool value) { }

	internal override void set_currentTarget(IEventHandler value) { }

	internal void set_dispatch(bool value) { }

	private void set_dispatched(bool value) { }

	[CompilerGenerated]
	internal void set_elementTarget(VisualElement value) { }

	[CompilerGenerated]
	private void set_eventId(ulong value) { }

	protected void set_imguiEvent(Event value) { }

	private void set_imguiEventIsValid(bool value) { }

	private void set_isImmediatePropagationStopped(bool value) { }

	private void set_isPropagationStopped(bool value) { }

	[CompilerGenerated]
	private void set_lifeCycleStatus(LifeCycleStatus value) { }

	[CompilerGenerated]
	private void set_originalMousePosition(Vector2 value) { }

	protected void set_pooled(bool value) { }

	private void set_processed(bool value) { }

	internal void set_processedByFocusController(bool value) { }

	internal void set_propagateToIMGUI(bool value) { }

	[CompilerGenerated]
	internal void set_propagation(EventPropagation value) { }

	[CompilerGenerated]
	internal void set_propagationPhase(PropagationPhase value) { }

	internal void set_skipDisabledElements(bool value) { }

	public void set_target(IEventHandler value) { }

	[CompilerGenerated]
	private void set_timestamp(long value) { }

	protected void set_tricklesDown(bool value) { }

	[CompilerGenerated]
	private void set_triggerEventId(ulong value) { }

	internal void SetTriggerEventId(ulong id) { }

	public void StopImmediatePropagation() { }

	public void StopPropagation() { }

}

