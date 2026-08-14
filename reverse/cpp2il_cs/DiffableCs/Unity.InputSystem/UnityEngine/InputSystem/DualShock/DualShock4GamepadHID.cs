namespace UnityEngine.InputSystem.DualShock;

[InputControlLayout(stateType = typeof(DualShock4HIDInputReport), hideInUI = True, isNoisy = True)]
public class DualShock4GamepadHID : DualShockGamepad, IEventPreProcessor, IInputStateCallbackReceiver
{
	public struct DualShock4HIDGenericInputReport
	{
		public byte leftStickX; //Field offset: 0x0
		public byte leftStickY; //Field offset: 0x1
		public byte rightStickX; //Field offset: 0x2
		public byte rightStickY; //Field offset: 0x3
		public byte buttons0; //Field offset: 0x4
		public byte buttons1; //Field offset: 0x5
		public byte buttons2; //Field offset: 0x6
		public byte leftTrigger; //Field offset: 0x7
		public byte rightTrigger; //Field offset: 0x8

		public static FourCC Format
		{
			 get { } //Length: 58
		}

		public static FourCC get_Format() { }

		public DualShock4HIDInputReport ToHIDInputReport() { }

	}

	internal const byte JitterMaskLow = 120; //Field offset: 0x0
	internal const byte JitterMaskHigh = 135; //Field offset: 0x0
	[CompilerGenerated]
	private ButtonControl <leftTriggerButton>k__BackingField; //Field offset: 0x288
	[CompilerGenerated]
	private ButtonControl <rightTriggerButton>k__BackingField; //Field offset: 0x290
	[CompilerGenerated]
	private ButtonControl <playStationButton>k__BackingField; //Field offset: 0x298
	private Nullable<Single> m_LowFrequencyMotorSpeed; //Field offset: 0x2A0
	private Nullable<Single> m_HighFrequenceyMotorSpeed; //Field offset: 0x2A8
	private Nullable<Color> m_LightBarColor; //Field offset: 0x2B0

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

	public DualShock4GamepadHID() { }

	protected virtual void FinishSetup() { }

	[CompilerGenerated]
	public ButtonControl get_leftTriggerButton() { }

	[CompilerGenerated]
	public ButtonControl get_playStationButton() { }

	[CompilerGenerated]
	public ButtonControl get_rightTriggerButton() { }

	public override bool GetStateOffsetForEvent(InputControl control, InputEventPtr eventPtr, ref uint offset) { }

	public override void OnNextUpdate() { }

	public override void OnStateEvent(InputEventPtr eventPtr) { }

	public virtual void PauseHaptics() { }

	public virtual void ResetHaptics() { }

	public virtual void ResumeHaptics() { }

	[CompilerGenerated]
	protected void set_leftTriggerButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_playStationButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_rightTriggerButton(ButtonControl value) { }

	public virtual void SetLightBarColor(Color color) { }

	public virtual void SetMotorSpeeds(float lowFrequency, float highFrequency) { }

	public bool SetMotorSpeedsAndLightBarColor(float lowFrequency, float highFrequency, Color color) { }

	private override bool UnityEngine.InputSystem.LowLevel.IEventPreProcessor.PreProcessEvent(InputEventPtr eventPtr) { }

}

