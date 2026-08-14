namespace UnityEngine.InputSystem.LowLevel;

public interface IInputStateChangeMonitor
{

	public void NotifyControlStateChanged(InputControl control, double time, InputEventPtr eventPtr, long monitorIndex) { }

	public void NotifyTimerExpired(InputControl control, double time, long monitorIndex, int timerIndex) { }

}

