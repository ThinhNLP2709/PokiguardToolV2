namespace UnityEngine.InputSystem;

[InputControlLayout(displayName = "Step Counter")]
public class StepCounter : Sensor
{
	[CompilerGenerated]
	private static StepCounter <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private IntegerControl <stepCounter>k__BackingField; //Field offset: 0x190

	public private static StepCounter current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	[InputControl(displayName = "Step Counter", noisy = True)]
	public IntegerControl stepCounter
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public StepCounter() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public static StepCounter get_current() { }

	[CompilerGenerated]
	public IntegerControl get_stepCounter() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnRemoved() { }

	[CompilerGenerated]
	private static void set_current(StepCounter value) { }

	[CompilerGenerated]
	protected void set_stepCounter(IntegerControl value) { }

}

