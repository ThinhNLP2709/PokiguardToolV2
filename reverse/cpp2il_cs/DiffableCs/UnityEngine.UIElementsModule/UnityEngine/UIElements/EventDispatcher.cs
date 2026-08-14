namespace UnityEngine.UIElements;

public sealed class EventDispatcher
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal Queue<EventRecord> <.cctor>b__35_0() { }

	}

	private struct DispatchContext
	{
		public uint m_GateCount; //Field offset: 0x0
		public Queue<EventRecord> m_Queue; //Field offset: 0x8

	}

	private struct EventRecord
	{
		public EventBase m_Event; //Field offset: 0x0
		public BaseVisualElementPanel m_Panel; //Field offset: 0x8

	}

	private static readonly ObjectPool<Queue`1<EventRecord>> k_EventQueuePool; //Field offset: 0x0
	internal const int k_MaxGateDepth = 500; //Field offset: 0x0
	internal const int k_NumberOfEventsWithStackInfo = 10; //Field offset: 0x0
	internal const int k_NumberOfEventsWithEventInfo = 100; //Field offset: 0x0
	internal ClickDetector m_ClickDetector; //Field offset: 0x10
	private Queue<EventRecord> m_Queue; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly PointerDispatchState <pointerState>k__BackingField; //Field offset: 0x20
	private uint m_GateCount; //Field offset: 0x28
	private uint m_GateDepth; //Field offset: 0x2C
	private int m_DispatchStackFrame; //Field offset: 0x30
	private EventBase m_CurrentEvent; //Field offset: 0x38
	private Stack<DispatchContext> m_DispatchContexts; //Field offset: 0x40
	private bool m_Immediate; //Field offset: 0x48
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <processingEvents>k__BackingField; //Field offset: 0x49

	private bool dispatchImmediately
	{
		private get { } //Length: 21
	}

	internal PointerDispatchState pointerState
	{
		[CompilerGenerated]
		internal get { } //Length: 5
	}

	private bool processingEvents
	{
		[CompilerGenerated]
		private set { } //Length: 4
	}

	private static EventDispatcher() { }

	[Obsolete("Please use EventDispatcher.CreateDefault().")]
	internal EventDispatcher() { }

	internal void CloseGate() { }

	internal static EventDispatcher CreateDefault() { }

	internal void Dispatch(EventBase evt, BaseVisualElementPanel panel, DispatchMode dispatchMode) { }

	private bool get_dispatchImmediately() { }

	[CompilerGenerated]
	internal PointerDispatchState get_pointerState() { }

	private bool HandleRecursiveState(EventBase evt) { }

	internal void OpenGate() { }

	private void ProcessEvent(EventBase evt, BaseVisualElementPanel panel) { }

	private void ProcessEventQueue() { }

	[CompilerGenerated]
	private void set_processingEvents(bool value) { }

}

