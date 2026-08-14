namespace UnityEngine.InputSystem;

[InputControlLayout(stateType = typeof(LinearAccelerationState), displayName = "Linear Acceleration")]
public class LinearAccelerationSensor : Sensor
{
	[CompilerGenerated]
	private static LinearAccelerationSensor <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private Vector3Control <acceleration>k__BackingField; //Field offset: 0x190

	public Vector3Control acceleration
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public private static LinearAccelerationSensor current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public LinearAccelerationSensor() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public Vector3Control get_acceleration() { }

	[CompilerGenerated]
	public static LinearAccelerationSensor get_current() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnRemoved() { }

	[CompilerGenerated]
	protected void set_acceleration(Vector3Control value) { }

	[CompilerGenerated]
	private static void set_current(LinearAccelerationSensor value) { }

}

