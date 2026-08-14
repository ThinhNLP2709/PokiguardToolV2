namespace UnityEngine.InputSystem.LowLevel;

public struct SetSamplingFrequencyCommand : IInputDeviceCommandInfo
{
	internal const int kSize = 12; //Field offset: 0x0
	public InputDeviceCommand baseCommand; //Field offset: 0x0
	public float frequency; //Field offset: 0x8

	public static FourCC Type
	{
		 get { } //Length: 55
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 55
	}

	public static SetSamplingFrequencyCommand Create(float frequency) { }

	public static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

}

