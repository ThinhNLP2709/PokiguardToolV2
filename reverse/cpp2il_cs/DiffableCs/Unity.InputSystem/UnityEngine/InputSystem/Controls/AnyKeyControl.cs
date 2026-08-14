namespace UnityEngine.InputSystem.Controls;

[InputControlLayout(hideInUI = True)]
public class AnyKeyControl : ButtonControl
{

	public AnyKeyControl() { }

	public virtual float ReadUnprocessedValueFromState(Void* statePtr) { }

}

