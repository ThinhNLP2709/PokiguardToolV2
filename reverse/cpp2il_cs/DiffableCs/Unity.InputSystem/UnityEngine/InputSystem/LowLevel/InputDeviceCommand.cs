namespace UnityEngine.InputSystem.LowLevel;

public struct InputDeviceCommand : IInputDeviceCommandInfo
{
	internal const int kBaseCommandSize = 8; //Field offset: 0x0
	public const int BaseCommandSize = 8; //Field offset: 0x0
	public const long GenericFailure = -1; //Field offset: 0x0
	public const long GenericSuccess = 1; //Field offset: 0x0
	public FourCC type; //Field offset: 0x0
	public int sizeInBytes; //Field offset: 0x4

	public Void* payloadPtr
	{
		 get { } //Length: 5
	}

	public int payloadSizeInBytes
	{
		 get { } //Length: 7
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 3
	}

	public InputDeviceCommand(FourCC type, int sizeInBytes = 8) { }

	public static NativeArray<Byte> AllocateNative(FourCC type, int payloadSize) { }

	public Void* get_payloadPtr() { }

	public int get_payloadSizeInBytes() { }

	public override FourCC get_typeStatic() { }

}

