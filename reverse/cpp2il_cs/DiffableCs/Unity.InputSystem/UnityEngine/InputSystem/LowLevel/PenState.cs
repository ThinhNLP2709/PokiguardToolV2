namespace UnityEngine.InputSystem.LowLevel;

public struct PenState : IInputStateTypeInfo
{
	[InputControl(usage = "Point", dontReset = True)]
	public Vector2 position; //Field offset: 0x0
	[InputControl(usage = "Secondary2DMotion", layout = "Delta")]
	public Vector2 delta; //Field offset: 0x8
	[InputControl(layout = "Vector2", displayName = "Tilt", usage = "Tilt")]
	public Vector2 tilt; //Field offset: 0x10
	[InputControl(layout = "Analog", usage = "Pressure", defaultState = 0)]
	public float pressure; //Field offset: 0x18
	[InputControl(layout = "Axis", displayName = "Twist", usage = "Twist")]
	public float twist; //Field offset: 0x1C
	[InputControl(name = "tip", displayName = "Tip", layout = "Button", bit = 0, usage = "PrimaryAction")]
	[InputControl(name = "press", useStateFrom = "tip", synthetic = True, usages = new IL2CPP_TYPE_STRING[] {})]
	[InputControl(name = "eraser", displayName = "Eraser", layout = "Button", bit = 1)]
	[InputControl(name = "inRange", displayName = "In Range?", layout = "Button", bit = 4, synthetic = True)]
	[InputControl(name = "barrel1", displayName = "Barrel Button #1", layout = "Button", bit = 2, alias = "barrelFirst", usage = "SecondaryAction")]
	[InputControl(name = "barrel2", displayName = "Barrel Button #2", layout = "Button", bit = 3, alias = "barrelSecond")]
	[InputControl(name = "barrel3", displayName = "Barrel Button #3", layout = "Button", bit = 5, alias = "barrelThird")]
	[InputControl(name = "barrel4", displayName = "Barrel Button #4", layout = "Button", bit = 6, alias = "barrelFourth")]
	[InputControl(name = "radius", layout = "Vector2", format = "VEC2", sizeInBits = 64, usage = "Radius", offset = 4294967294)]
	[InputControl(name = "pointerId", layout = "Digital", format = "UINT", sizeInBits = 32, offset = 4294967294)]
	public ushort buttons; //Field offset: 0x20
	[InputControl(name = "displayIndex", displayName = "Display Index", layout = "Integer")]
	private ushort displayIndex; //Field offset: 0x22

	public override FourCC format
	{
		 get { } //Length: 58
	}

	public static FourCC Format
	{
		 get { } //Length: 58
	}

	public override FourCC get_format() { }

	public static FourCC get_Format() { }

	public PenState WithButton(PenButton button, bool state = true) { }

}

