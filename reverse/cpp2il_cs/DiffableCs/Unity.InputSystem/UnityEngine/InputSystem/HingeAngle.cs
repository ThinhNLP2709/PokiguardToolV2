namespace UnityEngine.InputSystem;

[InputControlLayout(displayName = "Hinge Angle")]
public class HingeAngle : Sensor
{
	[CompilerGenerated]
	private static HingeAngle <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private AxisControl <angle>k__BackingField; //Field offset: 0x190

	public AxisControl angle
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public private static HingeAngle current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public HingeAngle() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public AxisControl get_angle() { }

	[CompilerGenerated]
	public static HingeAngle get_current() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnRemoved() { }

	[CompilerGenerated]
	protected void set_angle(AxisControl value) { }

	[CompilerGenerated]
	private static void set_current(HingeAngle value) { }

}

