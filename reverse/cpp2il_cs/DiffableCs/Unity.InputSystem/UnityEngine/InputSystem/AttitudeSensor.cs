namespace UnityEngine.InputSystem;

[InputControlLayout(stateType = typeof(AttitudeState), displayName = "Attitude")]
public class AttitudeSensor : Sensor
{
	[CompilerGenerated]
	private static AttitudeSensor <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private QuaternionControl <attitude>k__BackingField; //Field offset: 0x190

	public QuaternionControl attitude
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public private static AttitudeSensor current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public AttitudeSensor() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public QuaternionControl get_attitude() { }

	[CompilerGenerated]
	public static AttitudeSensor get_current() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnRemoved() { }

	[CompilerGenerated]
	protected void set_attitude(QuaternionControl value) { }

	[CompilerGenerated]
	private static void set_current(AttitudeSensor value) { }

}

