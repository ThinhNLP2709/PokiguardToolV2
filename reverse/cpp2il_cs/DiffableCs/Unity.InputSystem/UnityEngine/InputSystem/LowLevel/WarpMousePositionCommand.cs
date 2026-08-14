namespace UnityEngine.InputSystem.LowLevel;

internal struct WarpMousePositionCommand : IInputDeviceCommandInfo
{
	internal const int kSize = 16; //Field offset: 0x0
	public InputDeviceCommand baseCommand; //Field offset: 0x0
	public Vector2 warpPositionInPlayerDisplaySpace; //Field offset: 0x8

	public static FourCC Type
	{
		 get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 133
	}

	public static WarpMousePositionCommand Create(Vector2 position) { }

	public static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

}

