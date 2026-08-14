namespace UnityEngine.InputSystem.Controls;

[InputControlLayout(hideInUI = True)]
public class TouchPhaseControl : InputControl<TouchPhase>
{

	public TouchPhaseControl() { }

	public virtual TouchPhase ReadUnprocessedValueFromState(Void* statePtr) { }

	public virtual void WriteValueIntoState(TouchPhase value, Void* statePtr) { }

}

