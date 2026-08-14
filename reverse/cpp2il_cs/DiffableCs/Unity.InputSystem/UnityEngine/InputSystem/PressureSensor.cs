namespace UnityEngine.InputSystem;

[InputControlLayout(displayName = "Pressure")]
public class PressureSensor : Sensor
{
	[CompilerGenerated]
	private static PressureSensor <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private AxisControl <atmosphericPressure>k__BackingField; //Field offset: 0x190

	[InputControl(displayName = "Atmospheric Pressure", noisy = True)]
	public AxisControl atmosphericPressure
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public private static PressureSensor current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public PressureSensor() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public AxisControl get_atmosphericPressure() { }

	[CompilerGenerated]
	public static PressureSensor get_current() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnRemoved() { }

	[CompilerGenerated]
	protected void set_atmosphericPressure(AxisControl value) { }

	[CompilerGenerated]
	private static void set_current(PressureSensor value) { }

}

