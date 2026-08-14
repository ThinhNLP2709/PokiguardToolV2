namespace UnityEngine.InputSystem.Switch;

[InputControlLayout(stateType = typeof(SwitchProControllerHIDInputState), displayName = "Switch Pro Controller")]
public class SwitchProControllerHID : Gamepad, IInputStateCallbackReceiver, IEventPreProcessor
{
	private struct SwitchFullInputReport
	{
		public const int kSize = 25; //Field offset: 0x0
		public const byte ExpectedReportId = 48; //Field offset: 0x0
		public byte reportId; //Field offset: 0x0
		public byte buttons0; //Field offset: 0x3
		public byte buttons1; //Field offset: 0x4
		public byte buttons2; //Field offset: 0x5
		public byte left0; //Field offset: 0x6
		public byte left1; //Field offset: 0x7
		public byte left2; //Field offset: 0x8
		public byte right0; //Field offset: 0x9
		public byte right1; //Field offset: 0xA
		public byte right2; //Field offset: 0xB

		public SwitchProControllerHIDInputState ToHIDInputReport() { }

	}

	private struct SwitchHIDGenericInputReport
	{
		public byte reportId; //Field offset: 0x0

		public static FourCC Format
		{
			 get { } //Length: 58
		}

		public static FourCC get_Format() { }

	}

	private struct SwitchInputOnlyReport
	{
		public const int kSize = 7; //Field offset: 0x0
		public byte buttons0; //Field offset: 0x0
		public byte buttons1; //Field offset: 0x1
		public byte hat; //Field offset: 0x2
		public byte leftX; //Field offset: 0x3
		public byte leftY; //Field offset: 0x4
		public byte rightX; //Field offset: 0x5
		public byte rightY; //Field offset: 0x6

		public SwitchProControllerHIDInputState ToHIDInputReport() { }

	}

	public struct SwitchMagicOutputHIDBluetooth : IInputDeviceCommandInfo
	{
		public const int kSize = 57; //Field offset: 0x0
		public InputDeviceCommand baseCommand; //Field offset: 0x0
		public SwitchMagicOutputReport report; //Field offset: 0x8

		public static FourCC Type
		{
			 get { } //Length: 58
		}

		public override FourCC typeStatic
		{
			 get { } //Length: 58
		}

		public static SwitchMagicOutputHIDBluetooth Create(CommandIdType type) { }

		public static FourCC get_Type() { }

		public override FourCC get_typeStatic() { }

	}

	public struct SwitchMagicOutputHIDUSB : IInputDeviceCommandInfo
	{
		public const int kSize = 72; //Field offset: 0x0
		public InputDeviceCommand baseCommand; //Field offset: 0x0
		public SwitchMagicOutputReport report; //Field offset: 0x8

		public static FourCC Type
		{
			 get { } //Length: 58
		}

		public override FourCC typeStatic
		{
			 get { } //Length: 58
		}

		public static SwitchMagicOutputHIDUSB Create(CommandIdType type) { }

		public static FourCC get_Type() { }

		public override FourCC get_typeStatic() { }

	}

	public struct SwitchMagicOutputReport
	{
		internal enum CommandIdType
		{
			Status = 1,
			Handshake = 2,
			Highspeed = 3,
			ForceUSB = 4,
		}

		public enum ReportType
		{
			Magic = 128,
		}

		public const int kSize = 49; //Field offset: 0x0
		public const byte ExpectedReplyInputReportId = 129; //Field offset: 0x0
		public byte reportType; //Field offset: 0x0
		public byte commandId; //Field offset: 0x1

	}

	private struct SwitchSimpleInputReport
	{
		public const int kSize = 12; //Field offset: 0x0
		public const byte ExpectedReportId = 63; //Field offset: 0x0
		public byte reportId; //Field offset: 0x0
		public byte buttons0; //Field offset: 0x1
		public byte buttons1; //Field offset: 0x2
		public byte hat; //Field offset: 0x3
		public ushort leftX; //Field offset: 0x4
		public ushort leftY; //Field offset: 0x6
		public ushort rightX; //Field offset: 0x8
		public ushort rightY; //Field offset: 0xA

		public SwitchProControllerHIDInputState ToHIDInputReport() { }

	}

	private static readonly CommandIdType[] s_HandshakeSequence; //Field offset: 0x0
	internal const byte JitterMaskLow = 120; //Field offset: 0x0
	internal const byte JitterMaskHigh = 135; //Field offset: 0x0
	[CompilerGenerated]
	private ButtonControl <captureButton>k__BackingField; //Field offset: 0x210
	[CompilerGenerated]
	private ButtonControl <homeButton>k__BackingField; //Field offset: 0x218
	private int m_HandshakeStepIndex; //Field offset: 0x220
	private double m_HandshakeTimer; //Field offset: 0x228

	[InputControl(name = "capture", displayName = "Capture")]
	public ButtonControl captureButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	[InputControl(name = "home", displayName = "Home")]
	public ButtonControl homeButton
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	private static SwitchProControllerHID() { }

	public SwitchProControllerHID() { }

	[CompilerGenerated]
	public ButtonControl get_captureButton() { }

	[CompilerGenerated]
	public ButtonControl get_homeButton() { }

	public override bool GetStateOffsetForEvent(InputControl control, InputEventPtr eventPtr, ref uint offset) { }

	private void HandshakeRestart() { }

	private void HandshakeTick() { }

	protected virtual void OnAdded() { }

	public override void OnNextUpdate() { }

	public override void OnStateEvent(InputEventPtr eventPtr) { }

	public override bool PreProcessEvent(InputEventPtr eventPtr) { }

	[CompilerGenerated]
	protected void set_captureButton(ButtonControl value) { }

	[CompilerGenerated]
	protected void set_homeButton(ButtonControl value) { }

}

