namespace Unity.XR.Oculus.Input;

[InputControlLayout(displayName = "Oculus Remote", hideInUI = True)]
public class OculusRemote : InputDevice
{
	[CompilerGenerated]
	private ButtonControl <back>k__BackingField; //Field offset: 0x190
	[CompilerGenerated]
	private ButtonControl <start>k__BackingField; //Field offset: 0x198
	[CompilerGenerated]
	private Vector2Control <touchpad>k__BackingField; //Field offset: 0x1A0

	[InputControl]
	public ButtonControl back
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl]
	public ButtonControl start
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

	public OculusRemote() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public ButtonControl get_back() { }

	[CompilerGenerated]
	public ButtonControl get_start() { }

	[CompilerGenerated]
	public Vector2Control get_touchpad() { }

	[CompilerGenerated]
	protected void set_back(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_start(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_touchpad(Vector2Control value) { }

}

