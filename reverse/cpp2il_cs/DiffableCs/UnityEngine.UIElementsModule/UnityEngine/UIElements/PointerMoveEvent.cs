namespace UnityEngine.UIElements;

[EventCategory(EventCategory::PointerMove (2))]
public sealed class PointerMoveEvent : PointerEventBase<PointerMoveEvent>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0

		private static <>c() { }

		public <>c() { }

		internal PointerMoveEvent <.cctor>b__0_0() { }

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private bool <isHandledByDraggable>k__BackingField; //Field offset: 0x100

	internal bool isHandledByDraggable
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	internal bool isPointerDown
	{
		internal get { } //Length: 94
	}

	internal bool isPointerUp
	{
		internal get { } //Length: 96
	}

	private static PointerMoveEvent() { }

	public PointerMoveEvent() { }

	[CompilerGenerated]
	internal bool get_isHandledByDraggable() { }

	internal bool get_isPointerDown() { }

	internal bool get_isPointerUp() { }

	protected virtual void Init() { }

	private void LocalInit() { }

	protected private virtual void PreDispatch(IPanel panel) { }

	[CompilerGenerated]
	internal void set_isHandledByDraggable(bool value) { }

}

