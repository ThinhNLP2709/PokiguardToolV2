namespace UnityEngine.InputSystem.LowLevel;

internal struct QueryUserIdCommand : IInputDeviceCommandInfo
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <idBuffer>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	public const int kMaxIdLength = 256; //Field offset: 0x0
	internal const int kSize = 520; //Field offset: 0x0
	public InputDeviceCommand baseCommand; //Field offset: 0x0
	[FixedBuffer(typeof(byte), 512)]
	public <idBuffer>e__FixedBuffer idBuffer; //Field offset: 0x8

	public static FourCC Type
	{
		 get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 58
	}

	public static QueryUserIdCommand Create() { }

	public static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

	public string ReadId() { }

}

