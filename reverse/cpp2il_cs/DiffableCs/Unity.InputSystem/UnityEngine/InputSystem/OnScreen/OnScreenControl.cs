namespace UnityEngine.InputSystem.OnScreen;

public abstract class OnScreenControl : MonoBehaviour
{
	private struct OnScreenDeviceInfo
	{
		public InputEventPtr eventPtr; //Field offset: 0x0
		public NativeArray<Byte> buffer; //Field offset: 0x8
		public InputDevice device; //Field offset: 0x18
		public OnScreenControl firstControl; //Field offset: 0x20

		public OnScreenDeviceInfo AddControl(OnScreenControl control) { }

		public void Destroy() { }

		public OnScreenDeviceInfo RemoveControl(OnScreenControl control) { }

	}

	private static int s_nbActiveInstances; //Field offset: 0x0
	private static InlinedArray<OnScreenDeviceInfo> s_OnScreenDevices; //Field offset: 0x8
	private InputControl m_Control; //Field offset: 0x20
	private OnScreenControl m_NextControlOnDevice; //Field offset: 0x28
	private InputEventPtr m_InputEventPtr; //Field offset: 0x30

	public InputControl control
	{
		 get { } //Length: 5
	}

	public string controlPath
	{
		 get { } //Length: 20
		 set { } //Length: 63
	}

	protected abstract string controlPathInternal
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	internal static bool HasAnyActive
	{
		internal get { } //Length: 57
	}

	protected OnScreenControl() { }

	public InputControl get_control() { }

	public string get_controlPath() { }

	protected abstract string get_controlPathInternal() { }

	internal static bool get_HasAnyActive() { }

	internal string GetWarningMessage() { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

	protected void SendValueToControl(TValue value) { }

	protected void SentDefaultValueToControl() { }

	public void set_controlPath(string value) { }

	protected abstract void set_controlPathInternal(string value) { }

	private void SetupInputControl() { }

}

