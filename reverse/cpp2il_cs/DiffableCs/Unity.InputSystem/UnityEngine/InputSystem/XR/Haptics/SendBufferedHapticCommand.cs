namespace UnityEngine.InputSystem.XR.Haptics;

public struct SendBufferedHapticCommand : IInputDeviceCommandInfo
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <buffer>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	private const int kMaxHapticBufferSize = 1024; //Field offset: 0x0
	private const int kSize = 1040; //Field offset: 0x0
	private InputDeviceCommand baseCommand; //Field offset: 0x0
	private int channel; //Field offset: 0x8
	private int bufferSize; //Field offset: 0xC
	[FixedBuffer(typeof(byte), 1024)]
	private <buffer>e__FixedBuffer buffer; //Field offset: 0x10

	private static FourCC Type
	{
		private get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 58
	}

	public static SendBufferedHapticCommand Create(Byte[] rumbleBuffer) { }

	private static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

}

