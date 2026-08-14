namespace UnityEngine.InputSystem.XR.Haptics;

public struct GetHapticCapabilitiesCommand : IInputDeviceCommandInfo
{
	private const int kSize = 28; //Field offset: 0x0
	private InputDeviceCommand baseCommand; //Field offset: 0x0
	public uint numChannels; //Field offset: 0x8
	public bool supportsImpulse; //Field offset: 0xC
	public bool supportsBuffer; //Field offset: 0xD
	public uint frequencyHz; //Field offset: 0x10
	public uint maxBufferSize; //Field offset: 0x14
	public uint optimalBufferSize; //Field offset: 0x18

	public HapticCapabilities capabilities
	{
		 get { } //Length: 47
	}

	private static FourCC Type
	{
		private get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 58
	}

	public static GetHapticCapabilitiesCommand Create() { }

	public HapticCapabilities get_capabilities() { }

	private static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

}

