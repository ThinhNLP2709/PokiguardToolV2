namespace UnityEngine.InputSystem.LowLevel;

internal struct DualMotorRumbleCommand : IInputDeviceCommandInfo
{
	internal const int kSize = 16; //Field offset: 0x0
	public InputDeviceCommand baseCommand; //Field offset: 0x0
	public float lowFrequencyMotorSpeed; //Field offset: 0x8
	public float highFrequencyMotorSpeed; //Field offset: 0xC

	public static FourCC Type
	{
		 get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 58
	}

	public static DualMotorRumbleCommand Create(float lowFrequency, float highFrequency) { }

	public static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

}

