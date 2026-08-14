namespace UnityEngine.InputSystem.LowLevel;

public interface IInputStateCallbackReceiver
{

	public bool GetStateOffsetForEvent(InputControl control, InputEventPtr eventPtr, ref uint offset) { }

	public void OnNextUpdate() { }

	public void OnStateEvent(InputEventPtr eventPtr) { }

}

