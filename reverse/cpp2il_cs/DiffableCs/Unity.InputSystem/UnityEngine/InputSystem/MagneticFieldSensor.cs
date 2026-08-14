namespace UnityEngine.InputSystem;

[InputControlLayout(displayName = "Magnetic Field")]
public class MagneticFieldSensor : Sensor
{
	[CompilerGenerated]
	private static MagneticFieldSensor <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private Vector3Control <magneticField>k__BackingField; //Field offset: 0x190

	public private static MagneticFieldSensor current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	[InputControl(displayName = "Magnetic Field", noisy = True)]
	public Vector3Control magneticField
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public MagneticFieldSensor() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public static MagneticFieldSensor get_current() { }

	[CompilerGenerated]
	public Vector3Control get_magneticField() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnRemoved() { }

	[CompilerGenerated]
	private static void set_current(MagneticFieldSensor value) { }

	[CompilerGenerated]
	protected void set_magneticField(Vector3Control value) { }

}

