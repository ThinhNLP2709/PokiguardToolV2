namespace UnityEngine.InputSystem.EnhancedTouch;

[AddComponentMenu("Input/Debug/Touch Simulation")]
[ExecuteInEditMode]
[HelpURL("https://docs.unity3d.com/Packages/com.unity.inputsystem@1.17/manual/Touch.html#touch-simulation")]
public class TouchSimulation : MonoBehaviour, IInputStateChangeMonitor
{
	internal static TouchSimulation s_Instance; //Field offset: 0x0
	[CompilerGenerated]
	private Touchscreen <simulatedTouchscreen>k__BackingField; //Field offset: 0x20
	private int m_NumPointers; //Field offset: 0x28
	private Pointer[] m_Pointers; //Field offset: 0x30
	private Vector2[] m_CurrentPositions; //Field offset: 0x38
	private Int32[] m_CurrentDisplayIndices; //Field offset: 0x40
	private ButtonControl[] m_Touches; //Field offset: 0x48
	private Int32[] m_TouchIds; //Field offset: 0x50
	private int m_LastTouchId; //Field offset: 0x58
	private Action<InputDevice, InputDeviceChange> m_OnDeviceChange; //Field offset: 0x60
	private Action<InputEventPtr, InputDevice> m_OnEvent; //Field offset: 0x68

	public static TouchSimulation instance
	{
		 get { } //Length: 54
	}

	public private Touchscreen simulatedTouchscreen
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		private set { } //Length: 13
	}

	public TouchSimulation() { }

	protected void AddPointer(Pointer pointer) { }

	public static void Destroy() { }

	public static void Disable() { }

	public static void Enable() { }

	public static TouchSimulation get_instance() { }

	[CompilerGenerated]
	public Touchscreen get_simulatedTouchscreen() { }

	protected void InstallStateChangeMonitors(int startIndex = 0) { }

	private void OnDeviceChange(InputDevice device, InputDeviceChange change) { }

	protected void OnDisable() { }

	protected void OnEnable() { }

	private void OnEvent(InputEventPtr eventPtr, InputDevice device) { }

	protected void OnSourceControlChangedValue(InputControl control, double time, InputEventPtr eventPtr, long sourceDeviceAndButtonIndex) { }

	protected void RemovePointer(Pointer pointer) { }

	[CompilerGenerated]
	private void set_simulatedTouchscreen(Touchscreen value) { }

	protected void UninstallStateChangeMonitors(int startIndex = 0) { }

	private override void UnityEngine.InputSystem.LowLevel.IInputStateChangeMonitor.NotifyControlStateChanged(InputControl control, double time, InputEventPtr eventPtr, long monitorIndex) { }

	private override void UnityEngine.InputSystem.LowLevel.IInputStateChangeMonitor.NotifyTimerExpired(InputControl control, double time, long monitorIndex, int timerIndex) { }

	private void UpdateTouch(int touchIndex, int pointerIndex, TouchPhase phase, InputEventPtr eventPtr = null) { }

}

