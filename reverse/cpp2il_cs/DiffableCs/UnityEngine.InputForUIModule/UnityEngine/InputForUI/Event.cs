namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal struct Event : IEventProperties
{
	private interface IMapFn
	{

		public TOutputType Map(ref TEventType ev) { }

	}

	private struct MapAsEventModifiers : IMapFn<EventModifiers>
	{

		public override EventModifiers Map(ref TEventType ev) { }

	}

	private struct MapAsEventSource : IMapFn<EventSource>
	{

		public override EventSource Map(ref TEventType ev) { }

	}

	private struct MapAsObject : IMapFn<IEventProperties>
	{

		public override IEventProperties Map(ref TEventType ev) { }

	}

	internal enum Type
	{
		Invalid = 0,
		KeyEvent = 1,
		PointerEvent = 2,
		TextInputEvent = 3,
		IMECompositionEvent = 4,
		CommandEvent = 5,
		NavigationEvent = 6,
	}

	public static Type[] TypesWithState; //Field offset: 0x0
	private Type _type; //Field offset: 0x0
	private object _managedEvent; //Field offset: 0x8
	private KeyEvent _keyEvent; //Field offset: 0x10
	private PointerEvent _pointerEvent; //Field offset: 0x10
	private TextInputEvent _textInputEvent; //Field offset: 0x10
	private CommandEvent _commandEvent; //Field offset: 0x10
	private NavigationEvent _navigationEvent; //Field offset: 0x10

	public CommandEvent asCommandEvent
	{
		 get { } //Length: 120
	}

	public IMECompositionEvent asIMECompositionEvent
	{
		 get { } //Length: 179
	}

	public KeyEvent asKeyEvent
	{
		 get { } //Length: 159
	}

	public NavigationEvent asNavigationEvent
	{
		 get { } //Length: 135
	}

	private IEventProperties asObject
	{
		private get { } //Length: 90
	}

	public PointerEvent asPointerEvent
	{
		 get { } //Length: 168
	}

	public TextInputEvent asTextInputEvent
	{
		 get { } //Length: 120
	}

	public override EventModifiers eventModifiers
	{
		 get { } //Length: 90
	}

	public override EventSource eventSource
	{
		 get { } //Length: 90
	}

	public Type type
	{
		 get { } //Length: 3
	}

	private static Event() { }

	internal static int CompareType(Event a, Event b) { }

	private void Ensure(Type t) { }

	public static Event From(TextInputEvent textInputEvent) { }

	public static Event From(NavigationEvent navigationEvent) { }

	public static Event From(KeyEvent keyEvent) { }

	public static Event From(PointerEvent pointerEvent) { }

	public static Event From(CommandEvent commandEvent) { }

	public static Event From(IMECompositionEvent imeCompositionEvent) { }

	public CommandEvent get_asCommandEvent() { }

	public IMECompositionEvent get_asIMECompositionEvent() { }

	public KeyEvent get_asKeyEvent() { }

	public NavigationEvent get_asNavigationEvent() { }

	private IEventProperties get_asObject() { }

	public PointerEvent get_asPointerEvent() { }

	public TextInputEvent get_asTextInputEvent() { }

	public override EventModifiers get_eventModifiers() { }

	public override EventSource get_eventSource() { }

	public Type get_type() { }

	private TOutputType Map() { }

	private TOutputType Map(TMapType fn) { }

	public virtual string ToString() { }

}

