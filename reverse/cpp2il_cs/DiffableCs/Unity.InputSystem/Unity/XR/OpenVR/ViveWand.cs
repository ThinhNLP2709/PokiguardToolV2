namespace Unity.XR.OpenVR;

[InputControlLayout(displayName = "Vive Wand", commonUsages = new IL2CPP_TYPE_STRING[] {"LeftHand", "RightHand"}, hideInUI = True)]
public class ViveWand : XRControllerWithRumble
{
	[CompilerGenerated]
	private AxisControl <grip>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	private ButtonControl <gripPressed>k__BackingField; //Field offset: 0x1B8
	[CompilerGenerated]
	private ButtonControl <primary>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private ButtonControl <trackpadPressed>k__BackingField; //Field offset: 0x1C8
	[CompilerGenerated]
	private ButtonControl <trackpadTouched>k__BackingField; //Field offset: 0x1D0
	[CompilerGenerated]
	private Vector2Control <trackpad>k__BackingField; //Field offset: 0x1D8
	[CompilerGenerated]
	private AxisControl <trigger>k__BackingField; //Field offset: 0x1E0
	[CompilerGenerated]
	private ButtonControl <triggerPressed>k__BackingField; //Field offset: 0x1E8
	[CompilerGenerated]
	private Vector3Control <deviceVelocity>k__BackingField; //Field offset: 0x1F0
	[CompilerGenerated]
	private Vector3Control <deviceAngularVelocity>k__BackingField; //Field offset: 0x1F8

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

	[InputControl]
	public ButtonControl primary
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"Primary2DAxis"})]
	public Vector2Control trackpad
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"primary2DAxisClick", "joystickOrPadPressed"})]
	public ButtonControl trackpadPressed
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"primary2DAxisTouch", "joystickOrPadTouched"})]
	public ButtonControl trackpadTouched
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

	public ViveWand() { }

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
	public ButtonControl get_primary() { }

	[CompilerGenerated]
	public Vector2Control get_trackpad() { }

	[CompilerGenerated]
	public ButtonControl get_trackpadPressed() { }

	[CompilerGenerated]
	public ButtonControl get_trackpadTouched() { }

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
	protected void set_primary(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_trackpad(Vector2Control value) { }

	[CompilerGenerated]
	protected void set_trackpadPressed(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_trackpadTouched(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_trigger(AxisControl value) { }

	[CompilerGenerated]
	protected void set_triggerPressed(ButtonControl value) { }

}

