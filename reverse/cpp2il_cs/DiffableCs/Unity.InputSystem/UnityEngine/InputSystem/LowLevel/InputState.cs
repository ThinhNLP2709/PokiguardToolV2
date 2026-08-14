namespace UnityEngine.InputSystem.LowLevel;

[Extension]
public static class InputState
{
	private class StateChangeMonitorDelegate : IInputStateChangeMonitor
	{
		public Action<InputControl, Double, InputEventPtr, Int64> valueChangeCallback; //Field offset: 0x10
		public Action<InputControl, Double, Int64, Int32> timerExpiredCallback; //Field offset: 0x18

		public StateChangeMonitorDelegate() { }

		public override void NotifyControlStateChanged(InputControl control, double time, InputEventPtr eventPtr, long monitorIndex) { }

		public override void NotifyTimerExpired(InputControl control, double time, long monitorIndex, int timerIndex) { }

	}


	public static event Action<InputDevice, InputEventPtr> onChange
	{
		 add { } //Length: 105
		 remove { } //Length: 105
	}

	public static double currentTime
	{
		 get { } //Length: 112
	}

	public static InputUpdateType currentUpdateType
	{
		 get { } //Length: 54
	}

	public static uint updateCount
	{
		 get { } //Length: 53
	}

	public static void add_onChange(Action<InputDevice, InputEventPtr> value) { }

	public static void AddChangeMonitor(InputControl control, IInputStateChangeMonitor monitor, long monitorIndex = -1, uint groupIndex = 0) { }

	public static IInputStateChangeMonitor AddChangeMonitor(InputControl control, Action<InputControl, Double, InputEventPtr, Int64> valueChangeCallback, int monitorIndex = -1, Action<InputControl, Double, Int64, Int32> timerExpiredCallback = null) { }

	public static void AddChangeMonitorTimeout(InputControl control, IInputStateChangeMonitor monitor, double time, long monitorIndex = -1, int timerIndex = -1) { }

	public static void Change(InputDevice device, InputEventPtr eventPtr, InputUpdateType updateType = 0) { }

	public static void Change(InputControl control, TState state, InputUpdateType updateType = 0, InputEventPtr eventPtr = null) { }

	public static void Change(InputControl control, ref TState state, InputUpdateType updateType = 0, InputEventPtr eventPtr = null) { }

	public static double get_currentTime() { }

	public static InputUpdateType get_currentUpdateType() { }

	public static uint get_updateCount() { }

	[Extension]
	public static bool IsIntegerFormat(FourCC format) { }

	public static void remove_onChange(Action<InputDevice, InputEventPtr> value) { }

	public static void RemoveChangeMonitor(InputControl control, IInputStateChangeMonitor monitor, long monitorIndex = -1) { }

	public static void RemoveChangeMonitorTimeout(IInputStateChangeMonitor monitor, long monitorIndex = -1, int timerIndex = -1) { }

}

