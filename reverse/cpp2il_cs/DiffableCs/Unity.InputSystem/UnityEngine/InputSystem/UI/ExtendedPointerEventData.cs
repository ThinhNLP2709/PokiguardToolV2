namespace UnityEngine.InputSystem.UI;

public class ExtendedPointerEventData : PointerEventData
{
	[CompilerGenerated]
	private InputControl <control>k__BackingField; //Field offset: 0x180
	[CompilerGenerated]
	private InputDevice <device>k__BackingField; //Field offset: 0x188
	[CompilerGenerated]
	private int <touchId>k__BackingField; //Field offset: 0x190
	[CompilerGenerated]
	private UIPointerType <pointerType>k__BackingField; //Field offset: 0x194
	[CompilerGenerated]
	private int <uiToolkitPointerId>k__BackingField; //Field offset: 0x198
	[CompilerGenerated]
	private Vector3 <trackedDevicePosition>k__BackingField; //Field offset: 0x19C
	[CompilerGenerated]
	private Quaternion <trackedDeviceOrientation>k__BackingField; //Field offset: 0x1A8

	public InputControl control
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public InputDevice device
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public UIPointerType pointerType
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		 set { } //Length: 7
	}

	public int touchId
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		 set { } //Length: 7
	}

	public Quaternion trackedDeviceOrientation
	{
		[CompilerGenerated]
		 get { } //Length: 14
		[CompilerGenerated]
		 set { } //Length: 11
	}

	public Vector3 trackedDevicePosition
	{
		[CompilerGenerated]
		 get { } //Length: 25
		[CompilerGenerated]
		 set { } //Length: 22
	}

	public int uiToolkitPointerId
	{
		[CompilerGenerated]
		 get { } //Length: 7
		[CompilerGenerated]
		 set { } //Length: 7
	}

	public ExtendedPointerEventData(EventSystem eventSystem) { }

	[CompilerGenerated]
	public InputControl get_control() { }

	[CompilerGenerated]
	public InputDevice get_device() { }

	[CompilerGenerated]
	public UIPointerType get_pointerType() { }

	[CompilerGenerated]
	public int get_touchId() { }

	[CompilerGenerated]
	public Quaternion get_trackedDeviceOrientation() { }

	[CompilerGenerated]
	public Vector3 get_trackedDevicePosition() { }

	[CompilerGenerated]
	public int get_uiToolkitPointerId() { }

	private static int GetPenPointerId(Pen pen) { }

	private static int GetTouchPointerId(TouchControl touchControl) { }

	internal static int MakePointerIdForTouch(int deviceId, int touchId) { }

	internal void ReadDeviceState() { }

	[CompilerGenerated]
	public void set_control(InputControl value) { }

	[CompilerGenerated]
	public void set_device(InputDevice value) { }

	[CompilerGenerated]
	public void set_pointerType(UIPointerType value) { }

	[CompilerGenerated]
	public void set_touchId(int value) { }

	[CompilerGenerated]
	public void set_trackedDeviceOrientation(Quaternion value) { }

	[CompilerGenerated]
	public void set_trackedDevicePosition(Vector3 value) { }

	[CompilerGenerated]
	public void set_uiToolkitPointerId(int value) { }

	public virtual string ToString() { }

	internal static int TouchIdFromPointerId(int pointerId) { }

}

