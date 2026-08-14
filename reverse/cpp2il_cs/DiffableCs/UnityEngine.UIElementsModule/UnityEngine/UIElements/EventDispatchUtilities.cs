namespace UnityEngine.UIElements;

internal static class EventDispatchUtilities
{

	public static void DefaultDispatch(EventBase evt, BaseVisualElementPanel panel) { }

	private static bool Disabled(EventBase evt, VisualElement target) { }

	public static void DispatchToAssignedTarget(EventBase evt, BaseVisualElementPanel panel) { }

	public static void DispatchToCachedElementUnderPointerOrPanelRoot(EventBase evt, BaseVisualElementPanel panel, int pointerId, Vector2 position) { }

	private static bool DispatchToCapturingElement(EventBase evt, BaseVisualElementPanel panel, int pointerId, Vector2 position) { }

	public static void DispatchToCapturingElementOrElementUnderPointer(EventBase evt, BaseVisualElementPanel panel, int pointerId, Vector2 position) { }

	public static void DispatchToElementUnderPointerOrPanelRoot(EventBase evt, BaseVisualElementPanel panel, int pointerId, Vector2 position) { }

	public static void DispatchToFocusedElementOrPanelRoot(EventBase evt, BaseVisualElementPanel panel) { }

	internal static void DispatchToPanelRoot(EventBase evt, BaseVisualElementPanel panel) { }

	private static void HandleEvent_BubbleUpAllDefaultActions(EventBase evt, BaseVisualElementPanel panel, VisualElement element, bool disabled, bool isCapturingTarget) { }

	private static void HandleEvent_BubbleUpCallbacks(EventBase evt, BaseVisualElementPanel panel, VisualElement element) { }

	private static void HandleEvent_BubbleUpHandleEvent(EventBase evt, BaseVisualElementPanel panel, VisualElement element, bool disabled) { }

	private static void HandleEvent_DefaultAction(EventBase evt, BaseVisualElementPanel panel, VisualElement element, bool disabled) { }

	private static void HandleEvent_DefaultActionAtTarget(EventBase evt, BaseVisualElementPanel panel, VisualElement element, bool disabled) { }

	private static void HandleEvent_TrickleDownCallbacks(EventBase evt, BaseVisualElementPanel panel, VisualElement element) { }

	private static void HandleEvent_TrickleDownHandleEvent(EventBase evt, BaseVisualElementPanel panel, VisualElement element, bool disabled) { }

	private static void HandleEventAcrossPropagationPath(EventBase evt, BaseVisualElementPanel panel, VisualElement target, bool isCapturingTarget) { }

	private static void HandleEventAcrossPropagationPathWithCompatibilityEvent(EventBase evt, EventBase compatibilityEvt, BaseVisualElementPanel panel, VisualElement target, bool isCapturingTarget) { }

	public static void HandleEventAtTargetAndDefaultPhase(EventBase evt, BaseVisualElementPanel panel, VisualElement target) { }

	private static void PropagateEvent(EventBase evt, BaseVisualElementPanel panel, VisualElement target, bool isCapturingTarget) { }

	private static void PropagateToRemainingIMGUIContainerRecursive(EventBase evt, VisualElement root) { }

	internal static void PropagateToRemainingIMGUIContainers(EventBase evt, VisualElement root) { }

}

