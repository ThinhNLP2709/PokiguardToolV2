namespace UnityEngine.InputSystem.DualShock.LowLevel;

internal struct DualSenseHIDBluetoothOutputReport : IInputDeviceCommandInfo
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <rawData>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	internal const int kSize = 86; //Field offset: 0x0
	public InputDeviceCommand baseCommand; //Field offset: 0x0
	public byte reportId; //Field offset: 0x8
	[FixedBuffer(typeof(byte), 74)]
	public <rawData>e__FixedBuffer rawData; //Field offset: 0x8
	public byte tag1; //Field offset: 0x9
	public byte tag2; //Field offset: 0xA
	public DualSenseHIDOutputReportPayload payload; //Field offset: 0xB
	public uint crc32; //Field offset: 0x52

	public static FourCC Type
	{
		 get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 58
	}

	public static DualSenseHIDBluetoothOutputReport Create(DualSenseHIDOutputReportPayload payload, byte outputSequenceId, int outputReportSize) { }

	public static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

}

