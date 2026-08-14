namespace UnityEngine.InputSystem;

[InputControlLayout(displayName = "Ambient Temperature")]
public class AmbientTemperatureSensor : Sensor
{
	[CompilerGenerated]
	private static AmbientTemperatureSensor <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private AxisControl <ambientTemperature>k__BackingField; //Field offset: 0x190

	[InputControl(displayName = "Ambient Temperature", noisy = True)]
	public AxisControl ambientTemperature
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public private static AmbientTemperatureSensor current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public AmbientTemperatureSensor() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public AxisControl get_ambientTemperature() { }

	[CompilerGenerated]
	public static AmbientTemperatureSensor get_current() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnRemoved() { }

	[CompilerGenerated]
	protected void set_ambientTemperature(AxisControl value) { }

	[CompilerGenerated]
	private static void set_current(AmbientTemperatureSensor value) { }

}

