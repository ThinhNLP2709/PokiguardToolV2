namespace UnityEngine.InputSystem;

[InputControlLayout(displayName = "Light")]
public class LightSensor : Sensor
{
	[CompilerGenerated]
	private static LightSensor <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private AxisControl <lightLevel>k__BackingField; //Field offset: 0x190

	public private static LightSensor current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	[InputControl(displayName = "Light Level", noisy = True)]
	public AxisControl lightLevel
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public LightSensor() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public static LightSensor get_current() { }

	[CompilerGenerated]
	public AxisControl get_lightLevel() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnRemoved() { }

	[CompilerGenerated]
	private static void set_current(LightSensor value) { }

	[CompilerGenerated]
	protected void set_lightLevel(AxisControl value) { }

}

