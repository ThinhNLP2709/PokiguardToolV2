namespace UnityEngine.InputSystem.XR;

[InputControlLayout(stateType = typeof(PoseState))]
[Preserve]
public class PoseControl : InputControl<PoseState>
{
	[CompilerGenerated]
	private ButtonControl <isTracked>k__BackingField; //Field offset: 0x178
	[CompilerGenerated]
	private IntegerControl <trackingState>k__BackingField; //Field offset: 0x180
	[CompilerGenerated]
	private Vector3Control <position>k__BackingField; //Field offset: 0x188
	[CompilerGenerated]
	private QuaternionControl <rotation>k__BackingField; //Field offset: 0x190
	[CompilerGenerated]
	private Vector3Control <velocity>k__BackingField; //Field offset: 0x198
	[CompilerGenerated]
	private Vector3Control <angularVelocity>k__BackingField; //Field offset: 0x1A0

	public Vector3Control angularVelocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl isTracked
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public Vector3Control position
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public QuaternionControl rotation
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public IntegerControl trackingState
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public Vector3Control velocity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public PoseControl() { }

	protected virtual FourCC CalculateOptimizedControlDataType() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public Vector3Control get_angularVelocity() { }

	[CompilerGenerated]
	public ButtonControl get_isTracked() { }

	[CompilerGenerated]
	public Vector3Control get_position() { }

	[CompilerGenerated]
	public QuaternionControl get_rotation() { }

	[CompilerGenerated]
	public IntegerControl get_trackingState() { }

	[CompilerGenerated]
	public Vector3Control get_velocity() { }

	public virtual PoseState ReadUnprocessedValueFromState(Void* statePtr) { }

	[CompilerGenerated]
	public void set_angularVelocity(Vector3Control value) { }

	[CompilerGenerated]
	public void set_isTracked(ButtonControl value) { }

	[CompilerGenerated]
	public void set_position(Vector3Control value) { }

	[CompilerGenerated]
	public void set_rotation(QuaternionControl value) { }

	[CompilerGenerated]
	public void set_trackingState(IntegerControl value) { }

	[CompilerGenerated]
	public void set_velocity(Vector3Control value) { }

	public virtual void WriteValueIntoState(PoseState value, Void* statePtr) { }

}

