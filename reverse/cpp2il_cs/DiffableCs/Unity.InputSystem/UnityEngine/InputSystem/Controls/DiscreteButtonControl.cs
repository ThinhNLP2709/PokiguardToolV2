namespace UnityEngine.InputSystem.Controls;

public class DiscreteButtonControl : ButtonControl
{
	internal enum WriteMode
	{
		WriteDisabled = 0,
		WriteNullAndMaxValue = 1,
	}

	public int minValue; //Field offset: 0x148
	public int maxValue; //Field offset: 0x14C
	public int wrapAtValue; //Field offset: 0x150
	public int nullValue; //Field offset: 0x154
	public WriteMode writeMode; //Field offset: 0x158

	public DiscreteButtonControl() { }

	protected virtual void FinishSetup() { }

	public virtual float ReadUnprocessedValueFromState(Void* statePtr) { }

	public virtual void WriteValueIntoState(float value, Void* statePtr) { }

}

