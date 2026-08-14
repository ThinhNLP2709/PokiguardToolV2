namespace UnityEngine.InputSystem.LowLevel;

public struct QueryKeyNameCommand : IInputDeviceCommandInfo
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <nameBuffer>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	internal const int kMaxNameLength = 256; //Field offset: 0x0
	internal const int kSize = 268; //Field offset: 0x0
	public InputDeviceCommand baseCommand; //Field offset: 0x0
	public int scanOrKeyCode; //Field offset: 0x8
	[FixedBuffer(typeof(byte), 256)]
	public <nameBuffer>e__FixedBuffer nameBuffer; //Field offset: 0xC

	public static FourCC Type
	{
		 get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 58
	}

	public static QueryKeyNameCommand Create(Key key) { }

	public static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

	public string ReadKeyName() { }

}

