namespace UnityEngine.InputSystem.LowLevel;

internal struct QuerySamplingFrequencyCommand : IInputDeviceCommandInfo
{
	internal const int kSize = 12; //Field offset: 0x0
	public InputDeviceCommand baseCommand; //Field offset: 0x0
	public float frequency; //Field offset: 0x8

	public static FourCC Type
	{
		 get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 58
	}

	public static QuerySamplingFrequencyCommand Create() { }

	public static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

}

