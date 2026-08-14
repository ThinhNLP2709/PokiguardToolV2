namespace UnityEngine.InputSystem.LowLevel;

public struct MouseState : IInputStateTypeInfo
{
	[InputControl(usage = "Point", dontReset = True)]
	public Vector2 position; //Field offset: 0x0
	[InputControl(usage = "Secondary2DMotion", layout = "Delta")]
	public Vector2 delta; //Field offset: 0x8
	[InputControl(displayName = "Scroll", layout = "Delta")]
	[InputControl(name = "scroll/x", aliases = new IL2CPP_TYPE_STRING[] {"horizontal"}, usage = "ScrollHorizontal", displayName = "Left/Right")]
	[InputControl(name = "scroll/y", aliases = new IL2CPP_TYPE_STRING[] {"vertical"}, usage = "ScrollVertical", displayName = "Up/Down", shortDisplayName = "Wheel")]
	public Vector2 scroll; //Field offset: 0x10
	[InputControl(name = "press", useStateFrom = "leftButton", synthetic = True, usages = new IL2CPP_TYPE_STRING[] {})]
	[InputControl(name = "leftButton", layout = "Button", bit = 0, usage = "PrimaryAction", displayName = "Left Button", shortDisplayName = "LMB")]
	[InputControl(name = "rightButton", layout = "Button", bit = 1, usage = "SecondaryAction", displayName = "Right Button", shortDisplayName = "RMB")]
	[InputControl(name = "middleButton", layout = "Button", bit = 2, displayName = "Middle Button", shortDisplayName = "MMB")]
	[InputControl(name = "forwardButton", layout = "Button", bit = 3, usage = "Forward", displayName = "Forward")]
	[InputControl(name = "backButton", layout = "Button", bit = 4, usage = "Back", displayName = "Back")]
	[InputControl(name = "pressure", layout = "Axis", usage = "Pressure", offset = 4294967294, format = "FLT", sizeInBits = 32)]
	[InputControl(name = "radius", layout = "Vector2", usage = "Radius", offset = 4294967294, format = "VEC2", sizeInBits = 64)]
	[InputControl(name = "pointerId", layout = "Digital", format = "BIT", sizeInBits = 1, offset = 4294967294)]
	public ushort buttons; //Field offset: 0x18
	[InputControl(name = "displayIndex", layout = "Integer", displayName = "Display Index")]
	public ushort displayIndex; //Field offset: 0x1A
	[InputControl(name = "clickCount", layout = "Integer", displayName = "Click Count", synthetic = True)]
	public ushort clickCount; //Field offset: 0x1C

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

	public MouseState WithButton(MouseButton button, bool state = true) { }

}

