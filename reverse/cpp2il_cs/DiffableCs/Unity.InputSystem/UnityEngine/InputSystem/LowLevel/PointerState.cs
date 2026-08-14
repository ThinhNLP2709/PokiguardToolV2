namespace UnityEngine.InputSystem.LowLevel;

internal struct PointerState : IInputStateTypeInfo
{
	private uint pointerId; //Field offset: 0x0
	[InputControl(layout = "Vector2", displayName = "Position", usage = "Point", dontReset = True)]
	public Vector2 position; //Field offset: 0x4
	[InputControl(layout = "Delta", displayName = "Delta", usage = "Secondary2DMotion")]
	public Vector2 delta; //Field offset: 0xC
	[InputControl(layout = "Analog", displayName = "Pressure", usage = "Pressure", defaultState = 1)]
	public float pressure; //Field offset: 0x14
	[InputControl(layout = "Vector2", displayName = "Radius", usage = "Radius")]
	public Vector2 radius; //Field offset: 0x18
	[InputControl(name = "press", displayName = "Press", layout = "Button", format = "BIT", bit = 0)]
	public ushort buttons; //Field offset: 0x20
	[InputControl(name = "displayIndex", layout = "Integer", displayName = "Display Index")]
	public ushort displayIndex; //Field offset: 0x22

	public override FourCC format
	{
		 get { } //Length: 58
	}

	public static FourCC kFormat
	{
		 get { } //Length: 58
	}

	public override FourCC get_format() { }

	public static FourCC get_kFormat() { }

}

