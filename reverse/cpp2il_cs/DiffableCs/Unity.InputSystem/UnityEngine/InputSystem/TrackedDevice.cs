namespace UnityEngine.InputSystem;

[InputControlLayout(displayName = "Tracked Device", isGenericTypeOfDevice = True)]
public class TrackedDevice : InputDevice
{
	[CompilerGenerated]
	private IntegerControl <trackingState>k__BackingField; //Field offset: 0x190
	[CompilerGenerated]
	private ButtonControl <isTracked>k__BackingField; //Field offset: 0x198
	[CompilerGenerated]
	private Vector3Control <devicePosition>k__BackingField; //Field offset: 0x1A0
	[CompilerGenerated]
	private QuaternionControl <deviceRotation>k__BackingField; //Field offset: 0x1A8

	[InputControl(noisy = True, dontReset = True)]
	public Vector3Control devicePosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True, dontReset = True)]
	public QuaternionControl deviceRotation
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(synthetic = True)]
	public ButtonControl isTracked
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(synthetic = True)]
	public IntegerControl trackingState
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public TrackedDevice() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public Vector3Control get_devicePosition() { }

	[CompilerGenerated]
	public QuaternionControl get_deviceRotation() { }

	[CompilerGenerated]
	public ButtonControl get_isTracked() { }

	[CompilerGenerated]
	public IntegerControl get_trackingState() { }

	[CompilerGenerated]
	protected void set_devicePosition(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_deviceRotation(QuaternionControl value) { }

	[CompilerGenerated]
	protected void set_isTracked(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_trackingState(IntegerControl value) { }

}

