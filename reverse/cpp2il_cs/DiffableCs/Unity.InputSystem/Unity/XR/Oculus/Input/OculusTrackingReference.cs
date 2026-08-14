namespace Unity.XR.Oculus.Input;

public class OculusTrackingReference : TrackedDevice
{
	[CompilerGenerated]
	private IntegerControl <trackingState>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	private ButtonControl <isTracked>k__BackingField; //Field offset: 0x1B8

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"trackingReferenceIsTracked"})]
	public ButtonControl isTracked
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(aliases = new IL2CPP_TYPE_STRING[] {"trackingReferenceTrackingState"})]
	public IntegerControl trackingState
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public OculusTrackingReference() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public ButtonControl get_isTracked() { }

	[CompilerGenerated]
	public IntegerControl get_trackingState() { }

	[CompilerGenerated]
	protected void set_isTracked(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_trackingState(IntegerControl value) { }

}

