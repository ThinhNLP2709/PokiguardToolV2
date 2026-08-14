namespace Unity.XR.GoogleVr;

[InputControlLayout(displayName = "Daydream Controller", commonUsages = new IL2CPP_TYPE_STRING[] {"LeftHand", "RightHand"}, hideInUI = True)]
public class DaydreamController : XRController
{
	[CompilerGenerated]
	private Vector2Control <touchpad>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	private ButtonControl <volumeUp>k__BackingField; //Field offset: 0x1B8
	[CompilerGenerated]
	private ButtonControl <recentered>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private ButtonControl <volumeDown>k__BackingField; //Field offset: 0x1C8
	[CompilerGenerated]
	private ButtonControl <recentering>k__BackingField; //Field offset: 0x1D0
	[CompilerGenerated]
	private ButtonControl <app>k__BackingField; //Field offset: 0x1D8
	[CompilerGenerated]
	private ButtonControl <home>k__BackingField; //Field offset: 0x1E0
	[CompilerGenerated]
	private ButtonControl <touchpadClicked>k__BackingField; //Field offset: 0x1E8
	[CompilerGenerated]
	private ButtonControl <touchpadTouched>k__BackingField; //Field offset: 0x1F0
	[CompilerGenerated]
	private Vector3Control <deviceVelocity>k__BackingField; //Field offset: 0x1F8
	[CompilerGenerated]
	private Vector3Control <deviceAcceleration>k__BackingField; //Field offset: 0x200

	[InputControl]
	public ButtonControl app
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
	public Vector3Control deviceVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl]
	public ButtonControl home
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl]
	public ButtonControl recentered
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl]
	public ButtonControl recentering
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
	public ButtonControl volumeDown
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl]
	public ButtonControl volumeUp
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public DaydreamController() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public ButtonControl get_app() { }

	[CompilerGenerated]
	public Vector3Control get_deviceAcceleration() { }

	[CompilerGenerated]
	public Vector3Control get_deviceVelocity() { }

	[CompilerGenerated]
	public ButtonControl get_home() { }

	[CompilerGenerated]
	public ButtonControl get_recentered() { }

	[CompilerGenerated]
	public ButtonControl get_recentering() { }

	[CompilerGenerated]
	public Vector2Control get_touchpad() { }

	[CompilerGenerated]
	public ButtonControl get_touchpadClicked() { }

	[CompilerGenerated]
	public ButtonControl get_touchpadTouched() { }

	[CompilerGenerated]
	public ButtonControl get_volumeDown() { }

	[CompilerGenerated]
	public ButtonControl get_volumeUp() { }

	[CompilerGenerated]
	protected void set_app(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_deviceAcceleration(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_deviceVelocity(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_home(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_recentered(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_recentering(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_touchpad(Vector2Control value) { }

	[CompilerGenerated]
	protected void set_touchpadClicked(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_touchpadTouched(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_volumeDown(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_volumeUp(ButtonControl value) { }

}

