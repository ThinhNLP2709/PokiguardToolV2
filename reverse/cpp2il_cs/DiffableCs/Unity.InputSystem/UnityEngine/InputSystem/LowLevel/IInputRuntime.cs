namespace UnityEngine.InputSystem.LowLevel;

internal interface IInputRuntime
{

	public double currentTime
	{
		 get { } //Length: 0
	}

	public double currentTimeForFixedUpdate
	{
		 get { } //Length: 0
	}

	public double currentTimeOffsetToRealtimeSinceStartup
	{
		 get { } //Length: 0
	}

	public bool isPlayerFocused
	{
		 get { } //Length: 0
	}

	public bool normalizeScrollWheelDelta
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Action<InputUpdateType> onBeforeUpdate
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Action<Int32, String> onDeviceDiscovered
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Action<Boolean> onPlayerFocusChanged
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Func<InputUpdateType, Boolean> onShouldRunUpdate
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public Action onShutdown
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public InputUpdateDelegate onUpdate
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public float pollingFrequency
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public bool runInBackground
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public ScreenOrientation screenOrientation
	{
		 get { } //Length: 0
	}

	public Vector2 screenSize
	{
		 get { } //Length: 0
	}

	public float scrollWheelDeltaPerTick
	{
		 get { } //Length: 0
	}

	public float unscaledGameTime
	{
		 get { } //Length: 0
	}

	public int AllocateDeviceId() { }

	public long DeviceCommand(int deviceId, InputDeviceCommand* commandPtr) { }

	public double get_currentTime() { }

	public double get_currentTimeForFixedUpdate() { }

	public double get_currentTimeOffsetToRealtimeSinceStartup() { }

	public bool get_isPlayerFocused() { }

	public bool get_normalizeScrollWheelDelta() { }

	public Action<InputUpdateType> get_onBeforeUpdate() { }

	public Action<Int32, String> get_onDeviceDiscovered() { }

	public Action<Boolean> get_onPlayerFocusChanged() { }

	public Func<InputUpdateType, Boolean> get_onShouldRunUpdate() { }

	public Action get_onShutdown() { }

	public InputUpdateDelegate get_onUpdate() { }

	public float get_pollingFrequency() { }

	public bool get_runInBackground() { }

	public ScreenOrientation get_screenOrientation() { }

	public Vector2 get_screenSize() { }

	public float get_scrollWheelDeltaPerTick() { }

	public float get_unscaledGameTime() { }

	public void QueueEvent(InputEvent* ptr) { }

	public void set_normalizeScrollWheelDelta(bool value) { }

	public void set_onBeforeUpdate(Action<InputUpdateType> value) { }

	public void set_onDeviceDiscovered(Action<Int32, String> value) { }

	public void set_onPlayerFocusChanged(Action<Boolean> value) { }

	public void set_onShouldRunUpdate(Func<InputUpdateType, Boolean> value) { }

	public void set_onShutdown(Action value) { }

	public void set_onUpdate(InputUpdateDelegate value) { }

	public void set_pollingFrequency(float value) { }

	public void set_runInBackground(bool value) { }

	public void Update(InputUpdateType type) { }

}

