namespace UnityEngine.InputSystem.LowLevel;

public struct QueryDimensionsCommand : IInputDeviceCommandInfo
{
	internal const int kSize = 16; //Field offset: 0x0
	public InputDeviceCommand baseCommand; //Field offset: 0x0
	public Vector2 outDimensions; //Field offset: 0x8

	public static FourCC Type
	{
		 get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 58
	}

	public static QueryDimensionsCommand Create() { }

	public static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

}

