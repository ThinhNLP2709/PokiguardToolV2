namespace UnityEngine.InputSystem.Controls;

public class IntegerControl : InputControl<Int32>
{

	public IntegerControl() { }

	protected virtual FourCC CalculateOptimizedControlDataType() { }

	public virtual int ReadUnprocessedValueFromState(Void* statePtr) { }

	public virtual void WriteValueIntoState(int value, Void* statePtr) { }

}

