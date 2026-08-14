namespace UnityEngine.InputSystem.XR.Haptics;

public struct GetCurrentHapticStateCommand : IInputDeviceCommandInfo
{
	private const int kSize = 16; //Field offset: 0x0
	private InputDeviceCommand baseCommand; //Field offset: 0x0
	public uint samplesQueued; //Field offset: 0x8
	public uint samplesAvailable; //Field offset: 0xC

	public HapticState currentState
	{
		 get { } //Length: 20
	}

	private static FourCC Type
	{
		private get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 58
	}

	public static GetCurrentHapticStateCommand Create() { }

	public HapticState get_currentState() { }

	private static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

}

