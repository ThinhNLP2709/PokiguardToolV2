namespace UnityEngine.InputSystem.XR.Haptics;

public struct SendHapticImpulseCommand : IInputDeviceCommandInfo
{
	private const int kSize = 20; //Field offset: 0x0
	private InputDeviceCommand baseCommand; //Field offset: 0x0
	private int channel; //Field offset: 0x8
	private float amplitude; //Field offset: 0xC
	private float duration; //Field offset: 0x10

	private static FourCC Type
	{
		private get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 58
	}

	public static SendHapticImpulseCommand Create(int motorChannel, float motorAmplitude, float motorDuration) { }

	private static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

}

