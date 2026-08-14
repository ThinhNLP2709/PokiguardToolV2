namespace UnityEngine.InputSystem;

[Extension]
public static class InputExtensions
{

	[Extension]
	public static bool IsActive(TouchPhase phase) { }

	[Extension]
	public static bool IsEndedOrCanceled(TouchPhase phase) { }

	[Extension]
	public static bool IsInProgress(InputActionPhase phase) { }

	[Extension]
	public static bool IsModifierKey(Key key) { }

	[Extension]
	public static bool IsTextInputKey(Key key) { }

}

