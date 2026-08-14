namespace UnityEngine.Accessibility;

public interface IAccessibilityNotificationDispatcher
{

	public void SendScreenChanged(AccessibilityNode nodeToFocus = null) { }

}

