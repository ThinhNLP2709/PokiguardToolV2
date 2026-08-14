namespace Unity.XR.OpenVR;

[InputControlLayout(displayName = "Oculus Touch Controller (OpenVR)", commonUsages = new IL2CPP_TYPE_STRING[] {"LeftHand", "RightHand"}, hideInUI = True)]
public class OpenVROculusTouchController : XRControllerWithRumble
{
	[CompilerGenerated]
	private Vector2Control <thumbstick>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	private AxisControl <trigger>k__BackingField; //Field offset: 0x1B8
	[CompilerGenerated]
	private AxisControl <grip>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private ButtonControl <primaryButton>k__BackingField; //Field offset: 0x1C8
	[CompilerGenerated]
	private ButtonControl <secondaryButton>k__BackingField; //Field offset: 0x1D0
	[CompilerGenerated]
	private ButtonControl <gripPressed>k__BackingField; //Field offset: 0x1D8
	[CompilerGenerated]
	private ButtonControl <triggerPressed>k__BackingField; //Field offset: 0x1E0
	[CompilerGenerated]
	private ButtonControl <thumbstickClicked>k__BackingField; //Field offset: 0x1E8
	[CompilerGenerated]
	private ButtonControl <thumbstickTouched>k__BackingField; //Field offset: 0x1F0
	[CompilerGenerated]
	private Vector3Control <deviceVelocity>k__BackingField; //Field offset: 0x1F8
	[CompilerGenerated]
	private Vector3Control <deviceAngularVelocity>k__BackingField; //Field offset: 0x200

	[InputControl(noisy = True)]
	public Vector3Control deviceAngularVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control deviceVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl]
	public AxisControl grip
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl]
	public ButtonControl gripPressed
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"Alternate"})]
	public ButtonControl primaryButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"Primary"})]
	public ButtonControl secondaryButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl]
	public Vector2Control thumbstick
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"primary2DAxisClicked"})]
	public ButtonControl thumbstickClicked
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"primary2DAxisTouch"})]
	public ButtonControl thumbstickTouched
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

	public OpenVROculusTouchController() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public Vector3Control get_deviceAngularVelocity() { }

	[CompilerGenerated]
	public Vector3Control get_deviceVelocity() { }

	[CompilerGenerated]
	public AxisControl get_grip() { }

	[CompilerGenerated]
	public ButtonControl get_gripPressed() { }

	[CompilerGenerated]
	public ButtonControl get_primaryButton() { }

	[CompilerGenerated]
	public ButtonControl get_secondaryButton() { }

	[CompilerGenerated]
	public Vector2Control get_thumbstick() { }

	[CompilerGenerated]
	public ButtonControl get_thumbstickClicked() { }

	[CompilerGenerated]
	public ButtonControl get_thumbstickTouched() { }

	[CompilerGenerated]
	public AxisControl get_trigger() { }

	[CompilerGenerated]
	public ButtonControl get_triggerPressed() { }

	[CompilerGenerated]
	protected void set_deviceAngularVelocity(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_deviceVelocity(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_grip(AxisControl value) { }

	[CompilerGenerated]
	protected void set_gripPressed(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_primaryButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_secondaryButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_thumbstick(Vector2Control value) { }

	[CompilerGenerated]
	protected void set_thumbstickClicked(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_thumbstickTouched(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_trigger(AxisControl value) { }

	[CompilerGenerated]
	protected void set_triggerPressed(ButtonControl value) { }

}

