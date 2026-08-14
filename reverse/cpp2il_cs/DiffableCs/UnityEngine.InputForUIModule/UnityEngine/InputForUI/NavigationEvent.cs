namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal struct NavigationEvent : IEventProperties
{
	internal enum Direction
	{
		None = 0,
		Left = 1,
		Up = 2,
		Right = 3,
		Down = 4,
		Next = 5,
		Previous = 6,
	}

	internal enum Type
	{
		Move = 1,
		Submit = 2,
		Cancel = 3,
	}

	public Type type; //Field offset: 0x0
	public Direction direction; //Field offset: 0x4
	public bool shouldBeUsed; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private DiscreteTime <timestamp>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventSource <eventSource>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private uint <playerId>k__BackingField; //Field offset: 0x1C
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventModifiers <eventModifiers>k__BackingField; //Field offset: 0x20

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

	public uint playerId
	{
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public DiscreteTime timestamp
	{
		[CompilerGenerated]
		 set { } //Length: 5
	}

	internal static Direction DetermineMoveDirection(Vector2 vec, float deadZone = 0.6) { }

	[CompilerGenerated]
	[IsReadOnly]
	public override EventModifiers get_eventModifiers() { }

	[CompilerGenerated]
	[IsReadOnly]
	public override EventSource get_eventSource() { }

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

