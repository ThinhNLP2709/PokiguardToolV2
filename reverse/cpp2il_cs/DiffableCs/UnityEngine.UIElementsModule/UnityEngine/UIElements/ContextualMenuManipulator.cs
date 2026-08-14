namespace UnityEngine.UIElements;

public class ContextualMenuManipulator : PointerManipulator
{
	private Action<ContextualMenuPopulateEvent> m_MenuBuilder; //Field offset: 0x28

	public ContextualMenuManipulator(Action<ContextualMenuPopulateEvent> menuBuilder) { }

	private void DoDisplayMenu(EventBase evt) { }

	private void OnContextualMenuEvent(ContextualMenuPopulateEvent evt) { }

	private void OnKeyUpEvent(KeyUpEvent evt) { }

	private void OnPointerDownEventOSX(IPointerEvent evt) { }

	private void OnPointerMoveEvent(PointerMoveEvent evt) { }

	private void OnPointerMoveEventOSX(PointerMoveEvent evt) { }

	private void OnPointerUpEvent(IPointerEvent evt) { }

	private void OnPointerUpEventOSX(IPointerEvent evt) { }

	private void ProcessPointerEvent(IPointerEvent evt) { }

	protected virtual void RegisterCallbacksOnTarget() { }

	protected virtual void UnregisterCallbacksFromTarget() { }

}

