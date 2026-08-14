namespace UnityEngine.InputSystem;

[DefaultMember("Item")]
[InputControlLayout(stateType = typeof(GamepadState), isGenericTypeOfDevice = True)]
public class Gamepad : InputDevice, IDualMotorRumble, IHaptics
{
	[CompilerGenerated]
	private static Gamepad <current>k__BackingField; //Field offset: 0x0
	private static int s_GamepadCount; //Field offset: 0x8
	private static Gamepad[] s_Gamepads; //Field offset: 0x10
	[CompilerGenerated]
	private ButtonControl <buttonWest>k__BackingField; //Field offset: 0x190
	[CompilerGenerated]
	private ButtonControl <buttonNorth>k__BackingField; //Field offset: 0x198
	[CompilerGenerated]
	private ButtonControl <buttonSouth>k__BackingField; //Field offset: 0x1A0
	[CompilerGenerated]
	private ButtonControl <buttonEast>k__BackingField; //Field offset: 0x1A8
	[CompilerGenerated]
	private ButtonControl <leftStickButton>k__BackingField; //Field offset: 0x1B0
	[CompilerGenerated]
	private ButtonControl <rightStickButton>k__BackingField; //Field offset: 0x1B8
	[CompilerGenerated]
	private ButtonControl <startButton>k__BackingField; //Field offset: 0x1C0
	[CompilerGenerated]
	private ButtonControl <selectButton>k__BackingField; //Field offset: 0x1C8
	[CompilerGenerated]
	private DpadControl <dpad>k__BackingField; //Field offset: 0x1D0
	[CompilerGenerated]
	private ButtonControl <leftShoulder>k__BackingField; //Field offset: 0x1D8
	[CompilerGenerated]
	private ButtonControl <rightShoulder>k__BackingField; //Field offset: 0x1E0
	[CompilerGenerated]
	private StickControl <leftStick>k__BackingField; //Field offset: 0x1E8
	[CompilerGenerated]
	private StickControl <rightStick>k__BackingField; //Field offset: 0x1F0
	[CompilerGenerated]
	private ButtonControl <leftTrigger>k__BackingField; //Field offset: 0x1F8
	[CompilerGenerated]
	private ButtonControl <rightTrigger>k__BackingField; //Field offset: 0x200
	private DualMotorRumble m_Rumble; //Field offset: 0x208

	public ButtonControl aButton
	{
		 get { } //Length: 8
	}

	public static ReadOnlyArray<Gamepad> all
	{
		 get { } //Length: 109
	}

	public ButtonControl bButton
	{
		 get { } //Length: 8
	}

	public ButtonControl buttonEast
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl buttonNorth
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl buttonSouth
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl buttonWest
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl circleButton
	{
		 get { } //Length: 8
	}

	public ButtonControl crossButton
	{
		 get { } //Length: 8
	}

	public private static Gamepad current
	{
		[CompilerGenerated]
		 get { } //Length: 54
		[CompilerGenerated]
		private set { } //Length: 81
	}

	public DpadControl dpad
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl Item
	{
		 get { } //Length: 472
	}

	public ButtonControl leftShoulder
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public StickControl leftStick
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl leftStickButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl leftTrigger
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl rightShoulder
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public StickControl rightStick
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl rightStickButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl rightTrigger
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl selectButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl squareButton
	{
		 get { } //Length: 8
	}

	public ButtonControl startButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl triangleButton
	{
		 get { } //Length: 8
	}

	public ButtonControl xButton
	{
		 get { } //Length: 8
	}

	public ButtonControl yButton
	{
		 get { } //Length: 8
	}

	public Gamepad() { }

	protected virtual void FinishSetup() { }

	public ButtonControl get_aButton() { }

	public static ReadOnlyArray<Gamepad> get_all() { }

	public ButtonControl get_bButton() { }

	[CompilerGenerated]
	public ButtonControl get_buttonEast() { }

	[CompilerGenerated]
	public ButtonControl get_buttonNorth() { }

	[CompilerGenerated]
	public ButtonControl get_buttonSouth() { }

	[CompilerGenerated]
	public ButtonControl get_buttonWest() { }

	public ButtonControl get_circleButton() { }

	public ButtonControl get_crossButton() { }

	[CompilerGenerated]
	public static Gamepad get_current() { }

	[CompilerGenerated]
	public DpadControl get_dpad() { }

	public ButtonControl get_Item(GamepadButton button) { }

	[CompilerGenerated]
	public ButtonControl get_leftShoulder() { }

	[CompilerGenerated]
	public StickControl get_leftStick() { }

	[CompilerGenerated]
	public ButtonControl get_leftStickButton() { }

	[CompilerGenerated]
	public ButtonControl get_leftTrigger() { }

	[CompilerGenerated]
	public ButtonControl get_rightShoulder() { }

	[CompilerGenerated]
	public StickControl get_rightStick() { }

	[CompilerGenerated]
	public ButtonControl get_rightStickButton() { }

	[CompilerGenerated]
	public ButtonControl get_rightTrigger() { }

	[CompilerGenerated]
	public ButtonControl get_selectButton() { }

	public ButtonControl get_squareButton() { }

	[CompilerGenerated]
	public ButtonControl get_startButton() { }

	public ButtonControl get_triangleButton() { }

	public ButtonControl get_xButton() { }

	public ButtonControl get_yButton() { }

	public virtual void MakeCurrent() { }

	protected virtual void OnAdded() { }

	protected virtual void OnRemoved() { }

	public override void PauseHaptics() { }

	public override void ResetHaptics() { }

	public override void ResumeHaptics() { }

	[CompilerGenerated]
	protected void set_buttonEast(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_buttonNorth(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_buttonSouth(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_buttonWest(ButtonControl value) { }

	[CompilerGenerated]
	private static void set_current(Gamepad value) { }

	[CompilerGenerated]
	protected void set_dpad(DpadControl value) { }

	[CompilerGenerated]
	protected void set_leftShoulder(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_leftStick(StickControl value) { }

	[CompilerGenerated]
	protected void set_leftStickButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_leftTrigger(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_rightShoulder(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_rightStick(StickControl value) { }

	[CompilerGenerated]
	protected void set_rightStickButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_rightTrigger(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_selectButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_startButton(ButtonControl value) { }

	public override void SetMotorSpeeds(float lowFrequency, float highFrequency) { }

}

