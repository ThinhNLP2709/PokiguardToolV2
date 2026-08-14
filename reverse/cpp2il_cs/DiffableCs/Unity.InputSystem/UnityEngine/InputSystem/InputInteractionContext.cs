namespace UnityEngine.InputSystem;

public struct InputInteractionContext
{
	[Flags]
	public enum Flags
	{
		TimerHasExpired = 2,
	}

	internal InputActionState m_State; //Field offset: 0x0
	internal Flags m_Flags; //Field offset: 0x8
	internal TriggerState m_TriggerState; //Field offset: 0xC

	public InputAction action
	{
		 get { } //Length: 36
	}

	internal int bindingIndex
	{
		internal get { } //Length: 5
	}

	public InputControl control
	{
		 get { } //Length: 36
	}

	internal int controlIndex
	{
		internal get { } //Length: 11
	}

	internal int interactionIndex
	{
		internal get { } //Length: 11
	}

	public bool isStarted
	{
		 get { } //Length: 8
	}

	public bool isWaiting
	{
		 get { } //Length: 8
	}

	internal int mapIndex
	{
		internal get { } //Length: 5
	}

	public InputActionPhase phase
	{
		 get { } //Length: 5
	}

	public double startTime
	{
		 get { } //Length: 6
	}

	public double time
	{
		 get { } //Length: 6
	}

	public internal bool timerHasExpired
	{
		 get { } //Length: 8
		internal set { } //Length: 25
	}

	public void Canceled() { }

	public float ComputeMagnitude() { }

	public bool ControlIsActuated(float threshold = 0) { }

	public InputAction get_action() { }

	internal int get_bindingIndex() { }

	public InputControl get_control() { }

	internal int get_controlIndex() { }

	internal int get_interactionIndex() { }

	public bool get_isStarted() { }

	public bool get_isWaiting() { }

	internal int get_mapIndex() { }

	public InputActionPhase get_phase() { }

	public double get_startTime() { }

	public double get_time() { }

	public bool get_timerHasExpired() { }

	public void Performed() { }

	public void PerformedAndStayPerformed() { }

	public void PerformedAndStayStarted() { }

	public TValue ReadValue() { }

	internal void set_timerHasExpired(bool value) { }

	public void SetTimeout(float seconds) { }

	public void SetTotalTimeoutCompletionTime(float seconds) { }

	public void Started() { }

	public void Waiting() { }

}

