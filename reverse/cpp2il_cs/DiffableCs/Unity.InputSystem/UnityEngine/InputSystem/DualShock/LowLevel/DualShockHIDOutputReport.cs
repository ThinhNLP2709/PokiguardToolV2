namespace UnityEngine.InputSystem.DualShock.LowLevel;

internal struct DualShockHIDOutputReport : IInputDeviceCommandInfo
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <unknown1>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <unknown2>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	[Flags]
	internal enum Flags
	{
		Rumble = 1,
		Color = 2,
	}

	internal const int kSize = 40; //Field offset: 0x0
	internal const int kReportId = 5; //Field offset: 0x0
	public InputDeviceCommand baseCommand; //Field offset: 0x0
	public byte reportId; //Field offset: 0x8
	public byte flags; //Field offset: 0x9
	[FixedBuffer(typeof(byte), 2)]
	public <unknown1>e__FixedBuffer unknown1; //Field offset: 0xA
	public byte highFrequencyMotorSpeed; //Field offset: 0xC
	public byte lowFrequencyMotorSpeed; //Field offset: 0xD
	public byte redColor; //Field offset: 0xE
	public byte greenColor; //Field offset: 0xF
	public byte blueColor; //Field offset: 0x10
	[FixedBuffer(typeof(byte), 23)]
	public <unknown2>e__FixedBuffer unknown2; //Field offset: 0x11

	public static FourCC Type
	{
		 get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 58
	}

	public static DualShockHIDOutputReport Create(int outputReportSize) { }

	public static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

	public void SetColor(Color color) { }

	public void SetMotorSpeeds(float lowFreq, float highFreq) { }

}

