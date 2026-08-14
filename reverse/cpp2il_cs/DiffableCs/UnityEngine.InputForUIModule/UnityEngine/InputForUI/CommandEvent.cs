namespace UnityEngine.InputForUI;

[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
internal struct CommandEvent : IEventProperties
{
	internal enum Command
	{
		Invalid = 0,
		Cut = 1,
		Copy = 2,
		Paste = 3,
		SelectAll = 4,
		DeselectAll = 5,
		InvertSelection = 6,
		Duplicate = 7,
		Rename = 8,
		Delete = 9,
		SoftDelete = 10,
		Find = 11,
		SelectChildren = 12,
		SelectPrefabRoot = 13,
		UndoRedoPerformed = 14,
		OnLostFocus = 15,
		NewKeyboardFocus = 16,
		ModifierKeysChanged = 17,
		EyeDropperUpdate = 18,
		EyeDropperClicked = 19,
		EyeDropperCancelled = 20,
		ColorPickerChanged = 21,
		FrameSelected = 22,
		FrameSelectedWithLock = 23,
	}

	internal enum Type
	{
		Validate = 1,
		Execute = 2,
	}

	public Type type; //Field offset: 0x0
	public Command command; //Field offset: 0x4
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private DiscreteTime <timestamp>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventSource <eventSource>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private uint <playerId>k__BackingField; //Field offset: 0x14
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventModifiers <eventModifiers>k__BackingField; //Field offset: 0x18

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

