namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal struct PointerEvent : IEventProperties
{
	[Flags]
	internal enum Button
	{
		None = 0,
		Primary = 1,
		FingerInTouch = 1,
		PenTipInTouch = 1,
		PenEraserInTouch = 2,
		PenBarrelButton = 4,
		MouseLeft = 1,
		MouseRight = 2,
		MouseMiddle = 4,
		MouseForward = 8,
		MouseBack = 16,
	}

	internal struct ButtonsState
	{
		private uint _state; //Field offset: 0x0

		public bool Get(Button button) { }

		public void Reset() { }

		public void Set(Button button, bool pressed) { }

		public virtual string ToString() { }

	}

	internal enum Type
	{
		PointerMoved = 1,
		Scroll = 2,
		ButtonPressed = 3,
		ButtonReleased = 4,
		State = 5,
		TouchCanceled = 6,
	}

	public Type type; //Field offset: 0x0
	public int pointerIndex; //Field offset: 0x4
	public Vector2 position; //Field offset: 0x8
	public Vector2 deltaPosition; //Field offset: 0x10
	public Vector2 scroll; //Field offset: 0x18
	public int displayIndex; //Field offset: 0x20
	public Vector2 tilt; //Field offset: 0x24
	public float twist; //Field offset: 0x2C
	public float pressure; //Field offset: 0x30
	public bool isInverted; //Field offset: 0x34
	public Button button; //Field offset: 0x38
	public ButtonsState buttonsState; //Field offset: 0x3C
	public int clickCount; //Field offset: 0x40
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private DiscreteTime <timestamp>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventSource <eventSource>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private uint <playerId>k__BackingField; //Field offset: 0x54
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventModifiers <eventModifiers>k__BackingField; //Field offset: 0x58

	public float altitude
	{
		 get { } //Length: 75
	}

	public float azimuth
	{
		 get { } //Length: 212
	}

	public override EventModifiers eventModifiers
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public override EventSource eventSource
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public bool isPrimaryPointer
	{
		 get { } //Length: 8
	}

	public uint playerId
	{
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public override DiscreteTime timestamp
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 5
	}

	internal static Button ButtonFromButtonIndex(int index) { }

	public float get_altitude() { }

	public float get_azimuth() { }

	[CompilerGenerated]
	[IsReadOnly]
	public override EventModifiers get_eventModifiers() { }

	[CompilerGenerated]
	[IsReadOnly]
	public override EventSource get_eventSource() { }

	public bool get_isPrimaryPointer() { }

	[CompilerGenerated]
	[IsReadOnly]
	public override DiscreteTime get_timestamp() { }

	[CompilerGenerated]
	public void set_eventModifiers(EventModifiers value) { }

	[CompilerGenerated]
	public void set_eventSource(EventSource value) { }

	[CompilerGenerated]
	public void set_playerId(uint value) { }

	[CompilerGenerated]
	public void set_timestamp(DiscreteTime value) { }

	public virtual string ToString() { }

}

