namespace UnityEngine.XR.WindowsMR.Input;

[InputControlLayout(displayName = "HoloLens Hand", commonUsages = new IL2CPP_TYPE_STRING[] {"LeftHand", "RightHand"}, hideInUI = True)]
public class HololensHand : XRController
{
	[CompilerGenerated]
	private Vector3Control <deviceVelocity>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	private ButtonControl <airTap>k__BackingField; //Field offset: 0x1B8
	[CompilerGenerated]
	private AxisControl <sourceLossRisk>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private Vector3Control <sourceLossMitigationDirection>k__BackingField; //Field offset: 0x1C8

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"triggerbutton"})]
	public ButtonControl airTap
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True, aliases = new IL2CPP_TYPE_STRING[] {"gripVelocity"})]
	public Vector3Control deviceVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public Vector3Control sourceLossMitigationDirection
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(noisy = True)]
	public AxisControl sourceLossRisk
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public HololensHand() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public ButtonControl get_airTap() { }

	[CompilerGenerated]
	public Vector3Control get_deviceVelocity() { }

	[CompilerGenerated]
	public Vector3Control get_sourceLossMitigationDirection() { }

	[CompilerGenerated]
	public AxisControl get_sourceLossRisk() { }

	[CompilerGenerated]
	protected void set_airTap(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_deviceVelocity(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_sourceLossMitigationDirection(Vector3Control value) { }

	[CompilerGenerated]
	protected void set_sourceLossRisk(AxisControl value) { }

}

