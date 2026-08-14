namespace Unity.XR.OpenVR;

[InputControlLayout(displayName = "Windows MR Controller (OpenVR)", commonUsages = new IL2CPP_TYPE_STRING[] {"LeftHand", "RightHand"}, hideInUI = True)]
public class OpenVRControllerWMR : XRController
{
	[CompilerGenerated]
	private Vector3Control <deviceVelocity>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	private Vector3Control <deviceAngularVelocity>k__BackingField; //Field offset: 0x1B8
	[CompilerGenerated]
	private ButtonControl <touchpadClick>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private ButtonControl <touchpadTouch>k__BackingField; //Field offset: 0x1C8
	[CompilerGenerated]
	private ButtonControl <gripPressed>k__BackingField; //Field offset: 0x1D0
	[CompilerGenerated]
	private ButtonControl <triggerPressed>k__BackingField; //Field offset: 0x1D8
	[CompilerGenerated]
	private ButtonControl <menu>k__BackingField; //Field offset: 0x1E0
	[CompilerGenerated]
	private AxisControl <trigger>k__BackingField; //Field offset: 0x1E8
	[CompilerGenerated]
	private AxisControl <grip>k__BackingField; //Field offset: 0x1F0
	[CompilerGenerated]
	private Vector2Control <touchpad>k__BackingField; //Field offset: 0x1F8
	[CompilerGenerated]
	private Vector2Control <joystick>k__BackingField; //Field offset: 0x200

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

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"primary2DAxis"})]
	public Vector2Control joystick
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"primary"})]
	public ButtonControl menu
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"secondary2DAxis"})]
	public Vector2Control touchpad
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"primary2DAxisClick", "joystickOrPadPressed"})]
	public ButtonControl touchpadClick
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"primary2DAxisTouch", "joystickOrPadTouched"})]
	public ButtonControl touchpadTouch
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

	public OpenVRControllerWMR() { }

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
	public Vector2Control get_joystick() { }

	[CompilerGenerated]
	public ButtonControl get_menu() { }

	[CompilerGenerated]
	public Vector2Control get_touchpad() { }

	[CompilerGenerated]
	public ButtonControl get_touchpadClick() { }

	[CompilerGenerated]
	public ButtonControl get_touchpadTouch() { }

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
	protected void set_joystick(Vector2Control value) { }

	[CompilerGenerated]
	protected void set_menu(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_touchpad(Vector2Control value) { }

	[CompilerGenerated]
	protected void set_touchpadClick(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_touchpadTouch(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_trigger(AxisControl value) { }

	[CompilerGenerated]
	protected void set_triggerPressed(ButtonControl value) { }

}

