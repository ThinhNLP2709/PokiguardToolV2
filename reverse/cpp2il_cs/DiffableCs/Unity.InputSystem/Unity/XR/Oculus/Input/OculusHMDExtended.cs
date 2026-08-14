namespace Unity.XR.Oculus.Input;

[InputControlLayout(displayName = "Oculus Headset (w/ on-headset controls)", hideInUI = True)]
public class OculusHMDExtended : OculusHMD
{
	[CompilerGenerated]
	private ButtonControl <back>k__BackingField; //Field offset: 0x248
	[CompilerGenerated]
	private Vector2Control <touchpad>k__BackingField; //Field offset: 0x250

	[InputControl]
	public ButtonControl back
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

	public OculusHMDExtended() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public ButtonControl get_back() { }

	[CompilerGenerated]
	public Vector2Control get_touchpad() { }

	[CompilerGenerated]
	protected void set_back(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_touchpad(Vector2Control value) { }

}

