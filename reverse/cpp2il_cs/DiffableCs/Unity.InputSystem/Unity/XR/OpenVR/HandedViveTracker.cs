namespace Unity.XR.OpenVR;

[InputControlLayout(displayName = "Handed Vive Tracker", commonUsages = new IL2CPP_TYPE_STRING[] {"LeftHand", "RightHand"}, hideInUI = True)]
public class HandedViveTracker : ViveTracker
{
	[CompilerGenerated]
	private AxisControl <grip>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private ButtonControl <gripPressed>k__BackingField; //Field offset: 0x1C8
	[CompilerGenerated]
	private ButtonControl <primary>k__BackingField; //Field offset: 0x1D0
	[CompilerGenerated]
	private ButtonControl <trackpadPressed>k__BackingField; //Field offset: 0x1D8
	[CompilerGenerated]
	private ButtonControl <triggerPressed>k__BackingField; //Field offset: 0x1E0

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

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"JoystickOrPadPressed"})]
	public ButtonControl trackpadPressed
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

	public HandedViveTracker() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public AxisControl get_grip() { }

	[CompilerGenerated]
	public ButtonControl get_gripPressed() { }

	[CompilerGenerated]
	public ButtonControl get_primary() { }

	[CompilerGenerated]
	public ButtonControl get_trackpadPressed() { }

	[CompilerGenerated]
	public ButtonControl get_triggerPressed() { }

	[CompilerGenerated]
	protected void set_grip(AxisControl value) { }

	[CompilerGenerated]
	protected void set_gripPressed(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_primary(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_trackpadPressed(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_triggerPressed(ButtonControl value) { }

}

