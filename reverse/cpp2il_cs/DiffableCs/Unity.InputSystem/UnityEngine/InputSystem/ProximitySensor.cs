namespace UnityEngine.InputSystem;

[InputControlLayout(displayName = "Proximity")]
public class ProximitySensor : Sensor
{
	[CompilerGenerated]
	private static ProximitySensor <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private AxisControl <distance>k__BackingField; //Field offset: 0x190

	public private static ProximitySensor current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	[InputControl(displayName = "Distance", noisy = True)]
	public AxisControl distance
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ProximitySensor() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public static ProximitySensor get_current() { }

	[CompilerGenerated]
	public AxisControl get_distance() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnRemoved() { }

	[CompilerGenerated]
	private static void set_current(ProximitySensor value) { }

	[CompilerGenerated]
	protected void set_distance(AxisControl value) { }

}

