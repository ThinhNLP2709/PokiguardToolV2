namespace UnityEngine.InputSystem;

[InputControlLayout(stateType = typeof(JoystickState), isGenericTypeOfDevice = True)]
public class Joystick : InputDevice
{
	[CompilerGenerated]
	private static Joystick <current>k__BackingField; //Field offset: 0x0
	private static int s_JoystickCount; //Field offset: 0x8
	private static Joystick[] s_Joysticks; //Field offset: 0x10
	[CompilerGenerated]
	private ButtonControl <trigger>k__BackingField; //Field offset: 0x190
	[CompilerGenerated]
	private StickControl <stick>k__BackingField; //Field offset: 0x198
	[CompilerGenerated]
	private AxisControl <twist>k__BackingField; //Field offset: 0x1A0
	[CompilerGenerated]
	private Vector2Control <hatswitch>k__BackingField; //Field offset: 0x1A8

	public static ReadOnlyArray<Joystick> all
	{
		 get { } //Length: 109
	}

	public private static Joystick current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public Vector2Control hatswitch
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public StickControl stick
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl trigger
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public AxisControl twist
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public Joystick() { }

	protected virtual void FinishSetup() { }

	public static ReadOnlyArray<Joystick> get_all() { }

	[CompilerGenerated]
	public static Joystick get_current() { }

	[CompilerGenerated]
	public Vector2Control get_hatswitch() { }

	[CompilerGenerated]
	public StickControl get_stick() { }

	[CompilerGenerated]
	public ButtonControl get_trigger() { }

	[CompilerGenerated]
	public AxisControl get_twist() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnAdded() { }

	protected virtual void OnRemoved() { }

	[CompilerGenerated]
	private static void set_current(Joystick value) { }

	[CompilerGenerated]
	protected void set_hatswitch(Vector2Control value) { }

	[CompilerGenerated]
	protected void set_stick(StickControl value) { }

	[CompilerGenerated]
	protected void set_trigger(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_twist(AxisControl value) { }

}

