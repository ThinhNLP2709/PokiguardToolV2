namespace UnityEngine.InputSystem.DualShock;

[InputControlLayout(stateType = typeof(DualShock3HIDInputReport), hideInUI = True, displayName = "PS3 Controller")]
public class DualShock3GamepadHID : DualShockGamepad
{
	[CompilerGenerated]
	private ButtonControl <leftTriggerButton>k__BackingField; //Field offset: 0x288
	[CompilerGenerated]
	private ButtonControl <rightTriggerButton>k__BackingField; //Field offset: 0x290
	[CompilerGenerated]
	private ButtonControl <playStationButton>k__BackingField; //Field offset: 0x298

	public ButtonControl leftTriggerButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl playStationButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public ButtonControl rightTriggerButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public DualShock3GamepadHID() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public ButtonControl get_leftTriggerButton() { }

	[CompilerGenerated]
	public ButtonControl get_playStationButton() { }

	[CompilerGenerated]
	public ButtonControl get_rightTriggerButton() { }

	[CompilerGenerated]
	protected void set_leftTriggerButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_playStationButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_rightTriggerButton(ButtonControl value) { }

}

