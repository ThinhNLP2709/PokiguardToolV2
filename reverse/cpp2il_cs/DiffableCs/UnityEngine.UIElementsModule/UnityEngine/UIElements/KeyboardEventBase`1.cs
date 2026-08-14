namespace UnityEngine.UIElements;

[EventCategory(EventCategory::Keyboard (6))]
public abstract class KeyboardEventBase : EventBase<T>, IKeyboardEvent
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private EventModifiers <modifiers>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private char <character>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private KeyCode <keyCode>k__BackingField; //Field offset: 0x0

	public override bool actionKey
	{
		 get { } //Length: 132
	}

	public override bool altKey
	{
		 get { } //Length: 10
	}

	public override char character
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 5
	}

	public override bool commandKey
	{
		 get { } //Length: 10
	}

	public override bool ctrlKey
	{
		 get { } //Length: 10
	}

	internal bool functionKey
	{
		internal get { } //Length: 10
	}

	public override KeyCode keyCode
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public override EventModifiers modifiers
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public override bool shiftKey
	{
		 get { } //Length: 10
	}

	protected KeyboardEventBase`1() { }

	internal virtual void Dispatch(BaseVisualElementPanel panel) { }

	public override bool get_actionKey() { }

	public override bool get_altKey() { }

	[CompilerGenerated]
	public override char get_character() { }

	public override bool get_commandKey() { }

	public override bool get_ctrlKey() { }

	internal bool get_functionKey() { }

	[CompilerGenerated]
	public override KeyCode get_keyCode() { }

	[CompilerGenerated]
	public override EventModifiers get_modifiers() { }

	public override bool get_shiftKey() { }

	public static T GetPooled(char c, KeyCode keyCode, EventModifiers modifiers) { }

	public static T GetPooled(Event systemEvent) { }

	protected virtual void Init() { }

	private void LocalInit() { }

	[CompilerGenerated]
	protected void set_character(char value) { }

	[CompilerGenerated]
	protected void set_keyCode(KeyCode value) { }

	[CompilerGenerated]
	protected void set_modifiers(EventModifiers value) { }

}

