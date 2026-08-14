namespace UnityEngine.InputSystem.LowLevel;

public struct InputStateBlock
{
	public const uint InvalidOffset = 4294967295; //Field offset: 0x0
	internal const int kFormatPose = 1349481317; //Field offset: 0x0
	internal const int kFormatQuaternion = 1364541780; //Field offset: 0x0
	internal const int kFormatVector3 = 1447379763; //Field offset: 0x0
	internal const int kFormatVector2 = 1447379762; //Field offset: 0x0
	internal const int kFormatDouble = 1145195552; //Field offset: 0x0
	internal const int kFormatFloat = 1179407392; //Field offset: 0x0
	internal const int kFormatULong = 1431064135; //Field offset: 0x0
	internal const int kFormatSByte = 1396857172; //Field offset: 0x0
	internal const int kFormatByte = 1113150533; //Field offset: 0x0
	internal const int kFormatUShort = 1431521364; //Field offset: 0x0
	internal const int kFormatShort = 1397248596; //Field offset: 0x0
	internal const int kFormatLong = 1280198432; //Field offset: 0x0
	internal const int kFormatUInt = 1430867540; //Field offset: 0x0
	internal const int kFormatBit = 1112101920; //Field offset: 0x0
	internal const int kFormatSBit = 1396853076; //Field offset: 0x0
	public static readonly FourCC FormatInvalid; //Field offset: 0x0
	public const uint AutomaticOffset = 4294967294; //Field offset: 0x0
	internal const int kFormatInvalid = 0; //Field offset: 0x0
	internal const int kFormatInt = 1229870112; //Field offset: 0x0
	public static readonly FourCC FormatBit; //Field offset: 0x4
	public static readonly FourCC FormatSBit; //Field offset: 0x8
	public static readonly FourCC FormatInt; //Field offset: 0xC
	public static readonly FourCC FormatUInt; //Field offset: 0x10
	public static readonly FourCC FormatShort; //Field offset: 0x14
	public static readonly FourCC FormatUShort; //Field offset: 0x18
	public static readonly FourCC FormatByte; //Field offset: 0x1C
	public static readonly FourCC FormatSByte; //Field offset: 0x20
	public static readonly FourCC FormatLong; //Field offset: 0x24
	public static readonly FourCC FormatULong; //Field offset: 0x28
	public static readonly FourCC FormatFloat; //Field offset: 0x2C
	public static readonly FourCC FormatDouble; //Field offset: 0x30
	public static readonly FourCC FormatVector2; //Field offset: 0x34
	public static readonly FourCC FormatVector3; //Field offset: 0x38
	public static readonly FourCC FormatQuaternion; //Field offset: 0x3C
	public static readonly FourCC FormatVector2Short; //Field offset: 0x40
	public static readonly FourCC FormatVector3Short; //Field offset: 0x44
	public static readonly FourCC FormatVector2Byte; //Field offset: 0x48
	public static readonly FourCC FormatVector3Byte; //Field offset: 0x4C
	public static readonly FourCC FormatPose; //Field offset: 0x50
	[CompilerGenerated]
	private FourCC <format>k__BackingField; //Field offset: 0x0
	internal uint m_ByteOffset; //Field offset: 0x4
	[CompilerGenerated]
	private uint <bitOffset>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private uint <sizeInBits>k__BackingField; //Field offset: 0xC

	internal uint alignedSizeInBytes
	{
		internal get { } //Length: 73
	}

	public uint bitOffset
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	public uint byteOffset
	{
		 get { } //Length: 4
		 set { } //Length: 4
	}

	internal uint effectiveBitOffset
	{
		internal get { } //Length: 73
	}

	internal uint effectiveByteOffset
	{
		internal get { } //Length: 73
	}

	public FourCC format
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 3
		[CompilerGenerated]
		 set { } //Length: 3
	}

	public uint sizeInBits
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	private static InputStateBlock() { }

	public void CopyToFrom(Void* toStatePtr, Void* fromStatePtr) { }

	internal PrimitiveValue FloatToPrimitiveValue(float value) { }

	internal uint get_alignedSizeInBytes() { }

	[CompilerGenerated]
	[IsReadOnly]
	public uint get_bitOffset() { }

	public uint get_byteOffset() { }

	internal uint get_effectiveBitOffset() { }

	internal uint get_effectiveByteOffset() { }

	[CompilerGenerated]
	[IsReadOnly]
	public FourCC get_format() { }

	[CompilerGenerated]
	[IsReadOnly]
	public uint get_sizeInBits() { }

	public static FourCC GetPrimitiveFormatFromType(Type type) { }

	public static int GetSizeOfPrimitiveFormatInBits(FourCC type) { }

	public double ReadDouble(Void* statePtr) { }

	public float ReadFloat(Void* statePtr) { }

	public int ReadInt(Void* statePtr) { }

	[CompilerGenerated]
	public void set_bitOffset(uint value) { }

	public void set_byteOffset(uint value) { }

	[CompilerGenerated]
	public void set_format(FourCC value) { }

	[CompilerGenerated]
	public void set_sizeInBits(uint value) { }

	public void Write(Void* statePtr, PrimitiveValue value) { }

	public void WriteDouble(Void* statePtr, double value) { }

	public void WriteFloat(Void* statePtr, float value) { }

	public void WriteInt(Void* statePtr, int value) { }

}

