namespace UnityEngine.InputSystem.Controls;

public class DoubleControl : InputControl<Double>
{

	public DoubleControl() { }

	public virtual double ReadUnprocessedValueFromState(Void* statePtr) { }

	public virtual void WriteValueIntoState(double value, Void* statePtr) { }

}

