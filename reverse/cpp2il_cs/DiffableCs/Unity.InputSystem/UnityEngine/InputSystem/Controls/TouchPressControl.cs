namespace UnityEngine.InputSystem.Controls;

[InputControlLayout(hideInUI = True)]
public class TouchPressControl : ButtonControl
{

	public TouchPressControl() { }

	protected virtual void FinishSetup() { }

	public virtual float ReadUnprocessedValueFromState(Void* statePtr) { }

	public virtual void WriteValueIntoState(float value, Void* statePtr) { }

}

