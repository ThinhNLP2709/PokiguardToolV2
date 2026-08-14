namespace UnityEngine.InputSystem;

[InputControlLayout(stateType = typeof(GravityState), displayName = "Gravity")]
public class GravitySensor : Sensor
{
	[CompilerGenerated]
	private static GravitySensor <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private Vector3Control <gravity>k__BackingField; //Field offset: 0x190

	public private static GravitySensor current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public Vector3Control gravity
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public GravitySensor() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public static GravitySensor get_current() { }

	[CompilerGenerated]
	public Vector3Control get_gravity() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnRemoved() { }

	[CompilerGenerated]
	private static void set_current(GravitySensor value) { }

	[CompilerGenerated]
	protected void set_gravity(Vector3Control value) { }

}

