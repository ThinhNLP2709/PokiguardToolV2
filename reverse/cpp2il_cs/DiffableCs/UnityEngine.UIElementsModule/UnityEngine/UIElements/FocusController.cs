namespace UnityEngine.UIElements;

public class FocusController
{
	private struct FocusedElement
	{
		public VisualElement m_SubTreeRoot; //Field offset: 0x0
		public VisualElement m_FocusedElement; //Field offset: 0x8

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private readonly IFocusRing <focusRing>k__BackingField; //Field offset: 0x10
	private TextElement m_SelectedTextElement; //Field offset: 0x18
	private List<FocusedElement> m_FocusedElements; //Field offset: 0x20
	private Focusable m_LastFocusedElement; //Field offset: 0x28
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal Focusable m_LastPendingFocusedElement; //Field offset: 0x30
	private int m_PendingFocusCount; //Field offset: 0x38
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private int <imguiKeyboardControl>k__BackingField; //Field offset: 0x3C

	public Focusable focusedElement
	{
		 get { } //Length: 91
	}

	private IFocusRing focusRing
	{
		[CompilerGenerated]
		private get { } //Length: 5
	}

	internal int imguiKeyboardControl
	{
		[CompilerGenerated]
		internal get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal TextElement selectedTextElement
	{
		internal set { } //Length: 123
	}

	public FocusController(IFocusRing focusRing) { }

	private void AboutToGrabFocus(Focusable focusable, Focusable willTakeFocusFrom, FocusChangeDirection direction, DispatchMode dispatchMode) { }

	private void AboutToReleaseFocus(Focusable focusable, Focusable willGiveFocusTo, FocusChangeDirection direction, DispatchMode dispatchMode) { }

	internal void Blur(Focusable focusable, bool bIsFocusDelegated = false, DispatchMode dispatchMode = 1) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void BlurLastFocusedElement() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal void DoFocusChange(Focusable f) { }

	internal Focusable FocusNextInDirection(Focusable currentFocusable, FocusChangeDirection direction) { }

	public Focusable get_focusedElement() { }

	[CompilerGenerated]
	private IFocusRing get_focusRing() { }

	[CompilerGenerated]
	internal int get_imguiKeyboardControl() { }

	internal bool GetFocusableParentForPointerEvent(Focusable target, out Focusable effectiveTarget) { }

	private static void GetFocusTargets(Focusable f, List<FocusedElement> outTargets) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal Focusable GetLeafFocusedElement() { }

	internal Focusable GetRetargetedFocusedElement(VisualElement retargetAgainst) { }

	private void GrabFocus(Focusable focusable, Focusable willTakeFocusFrom, FocusChangeDirection direction, bool bIsFocusDelegated, DispatchMode dispatchMode) { }

	public void IgnoreEvent(EventBase evt) { }

	internal bool IsFocused(Focusable f) { }

	private bool IsLocalElement(Focusable f) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEditor.UIBuilderModule"})]
	internal bool IsPendingFocus(Focusable f) { }

	internal void ProcessPendingFocusChange(Focusable f) { }

	internal void ReevaluateFocus() { }

	private void ReleaseFocus(Focusable focusable, Focusable willGiveFocusTo, FocusChangeDirection direction, DispatchMode dispatchMode) { }

	[CompilerGenerated]
	internal void set_imguiKeyboardControl(int value) { }

	internal void set_selectedTextElement(TextElement value) { }

	internal void SetFocusToLastFocusedElement() { }

	internal void SwitchFocus(Focusable newFocusedElement, bool bIsFocusDelegated = false, DispatchMode dispatchMode = 1) { }

	internal void SwitchFocus(Focusable newFocusedElement, FocusChangeDirection direction, bool bIsFocusDelegated = false, DispatchMode dispatchMode = 1) { }

	internal void SwitchFocusOnEvent(Focusable currentFocusable, EventBase e) { }

	internal void SyncIMGUIFocus(int imguiKeyboardControlID, Focusable imguiContainerHavingKeyboardControl, bool forceSwitch) { }

}

