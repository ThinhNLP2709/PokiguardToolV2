namespace Unity.XR.Oculus.Input;

[InputControlLayout(displayName = "GearVR Controller", commonUsages = new IL2CPP_TYPE_STRING[] {"LeftHand", "RightHand"}, hideInUI = True)]
public class GearVRTrackedController : XRController
{
	[CompilerGenerated]
	private Vector2Control <touchpad>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	private AxisControl <trigger>k__BackingField; //Field offset: 0x1B8
	[CompilerGenerated]
	private ButtonControl <back>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private ButtonControl <triggerPressed>k__BackingField; //Field offset: 0x1C8
	[CompilerGenerated]
	private ButtonControl <touchpadClicked>k__BackingField; //Field offset: 0x1D0
	[CompilerGenerated]
	private ButtonControl <touchpadTouched>k__BackingField; //Field offset: 0x1D8
	[CompilerGenerated]
	private Vector3Control <deviceAngularVelocity>k__BackingField; //Field offset: 0x1E0
	[CompilerGenerated]
	private Vector3Control <deviceAcceleration>k__BackingField; //Field offset: 0x1E8
	[CompilerGenerated]
	private Vector3Control <deviceAngularAcceleration>k__BackingField; //Field offset: 0x1F0

	[InputControl]
	public ButtonControl back
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control deviceAcceleration
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control deviceAngularAcceleration
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control deviceAngularVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl]
	public Vector2Control touchpad
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl]
	public ButtonControl touchpadClicked
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl]
	public ButtonControl touchpadTouched
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl]
	public AxisControl trigger
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl]
	public ButtonControl triggerPressed
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public GearVRTrackedController() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public ButtonControl get_back() { }

	[CompilerGenerated]
	public Vector3Control get_deviceAcceleration() { }

	[CompilerGenerated]
	public Vector3Control get_deviceAngularAcceleration() { }

	[CompilerGenerated]
	public Vector3Control get_deviceAngularVelocity() { }

	[CompilerGenerated]
	public Vector2Control get_touchpad() { }

	[CompilerGenerated]
	public ButtonControl get_touchpadClicked() { }

	[CompilerGenerated]
	public ButtonControl get_touchpadTouched() { }

	[CompilerGenerated]
	public AxisControl get_trigger() { }

	[CompilerGenerated]
	public ButtonControl get_triggerPressed() { }

	[CompilerGenerated]
	protected void set_back(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_deviceAcceleration(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_deviceAngularAcceleration(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_deviceAngularVelocity(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_touchpad(Vector2Control value) { }

	[CompilerGenerated]
	protected void set_touchpadClicked(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_touchpadTouched(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_trigger(AxisControl value) { }

	[CompilerGenerated]
	protected void set_triggerPressed(ButtonControl value) { }

}

