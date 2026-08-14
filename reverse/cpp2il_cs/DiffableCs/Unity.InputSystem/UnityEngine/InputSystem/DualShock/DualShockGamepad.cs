namespace UnityEngine.InputSystem.DualShock;

[InputControlLayout(displayName = "PlayStation Controller")]
public class DualShockGamepad : Gamepad, IDualShockHaptics, IDualMotorRumble, IHaptics
{
	[CompilerGenerated]
	private static DualShockGamepad <current>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private ButtonControl <touchpadButton>k__BackingField; //Field offset: 0x210
	[CompilerGenerated]
	private ButtonControl <optionsButton>k__BackingField; //Field offset: 0x218
	[CompilerGenerated]
	private ButtonControl <shareButton>k__BackingField; //Field offset: 0x220
	[CompilerGenerated]
	private ButtonControl <L1>k__BackingField; //Field offset: 0x228
	[CompilerGenerated]
	private ButtonControl <R1>k__BackingField; //Field offset: 0x230
	[CompilerGenerated]
	private ButtonControl <L2>k__BackingField; //Field offset: 0x238
	[CompilerGenerated]
	private ButtonControl <R2>k__BackingField; //Field offset: 0x240
	[CompilerGenerated]
	private ButtonControl <L3>k__BackingField; //Field offset: 0x248
	[CompilerGenerated]
	private ButtonControl <R3>k__BackingField; //Field offset: 0x250
	[CompilerGenerated]
	private HIDDeviceDescriptor <hidDescriptor>k__BackingField; //Field offset: 0x258

	public private static DualShockGamepad current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	internal HIDDeviceDescriptor hidDescriptor
	{
		[CompilerGenerated]
		internal get { } //Length: 36
		[CompilerGenerated]
		private set { } //Length: 46
	}

	[InputControl(name = "leftShoulder", displayName = "L1", shortDisplayName = "L1")]
	public ButtonControl L1
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(name = "leftTrigger", displayName = "L2", shortDisplayName = "L2")]
	public ButtonControl L2
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(name = "leftStickPress", displayName = "L3", shortDisplayName = "L3")]
	public ButtonControl L3
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(name = "start", displayName = "Options")]
	public ButtonControl optionsButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(name = "rightShoulder", displayName = "R1", shortDisplayName = "R1")]
	public ButtonControl R1
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(name = "rightTrigger", displayName = "R2", shortDisplayName = "R2")]
	public ButtonControl R2
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(name = "rightStickPress", displayName = "R3", shortDisplayName = "R3")]
	public ButtonControl R3
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(name = "select", displayName = "Share")]
	public ButtonControl shareButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(name = "buttonWest", displayName = "Square", shortDisplayName = "Square")]
	[InputControl(name = "buttonNorth", displayName = "Triangle", shortDisplayName = "Triangle")]
	[InputControl(name = "buttonEast", displayName = "Circle", shortDisplayName = "Circle")]
	[InputControl(name = "buttonSouth", displayName = "Cross", shortDisplayName = "Cross")]
	[InputControl]
	public ButtonControl touchpadButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public DualShockGamepad() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public static DualShockGamepad get_current() { }

	[CompilerGenerated]
	internal HIDDeviceDescriptor get_hidDescriptor() { }

	[CompilerGenerated]
	public ButtonControl get_L1() { }

	[CompilerGenerated]
	public ButtonControl get_L2() { }

	[CompilerGenerated]
	public ButtonControl get_L3() { }

	[CompilerGenerated]
	public ButtonControl get_optionsButton() { }

	[CompilerGenerated]
	public ButtonControl get_R1() { }

	[CompilerGenerated]
	public ButtonControl get_R2() { }

	[CompilerGenerated]
	public ButtonControl get_R3() { }

	[CompilerGenerated]
	public ButtonControl get_shareButton() { }

	[CompilerGenerated]
	public ButtonControl get_touchpadButton() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnRemoved() { }

	[CompilerGenerated]
	private static void set_current(DualShockGamepad value) { }

	[CompilerGenerated]
	private void set_hidDescriptor(HIDDeviceDescriptor value) { }

	[CompilerGenerated]
	protected void set_L1(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_L2(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_L3(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_optionsButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_R1(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_R2(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_R3(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_shareButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_touchpadButton(ButtonControl value) { }

	public override void SetLightBarColor(Color color) { }

}

