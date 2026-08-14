namespace UnityEngine.InputSystem.LowLevel;

public struct GamepadState : IInputStateTypeInfo
{
	internal const string ButtonSouthShortDisplayName = "A"; //Field offset: 0x0
	internal const string ButtonNorthShortDisplayName = "Y"; //Field offset: 0x0
	internal const string ButtonWestShortDisplayName = "X"; //Field offset: 0x0
	internal const string ButtonEastShortDisplayName = "B"; //Field offset: 0x0
	[InputControl(name = "dpad", layout = "Dpad", usage = "Hatswitch", displayName = "D-Pad", format = "BIT", sizeInBits = 4, bit = 0)]
	[InputControl(name = "buttonSouth", layout = "Button", bit = 6, usages = new IL2CPP_TYPE_STRING[] {"PrimaryAction", "Submit"}, aliases = new IL2CPP_TYPE_STRING[] {"a", "cross"}, displayName = "Button South", shortDisplayName = "A")]
	[InputControl(name = "buttonWest", layout = "Button", bit = 7, usage = "SecondaryAction", aliases = new IL2CPP_TYPE_STRING[] {"x", "square"}, displayName = "Button West", shortDisplayName = "X")]
	[InputControl(name = "buttonNorth", layout = "Button", bit = 4, aliases = new IL2CPP_TYPE_STRING[] {"y", "triangle"}, displayName = "Button North", shortDisplayName = "Y")]
	[InputControl(name = "buttonEast", layout = "Button", bit = 5, usages = new IL2CPP_TYPE_STRING[] {"Back", "Cancel"}, aliases = new IL2CPP_TYPE_STRING[] {"b", "circle"}, displayName = "Button East", shortDisplayName = "B")]
	[InputControl(name = "leftStickPress", layout = "Button", bit = 8, displayName = "Left Stick Press")]
	[InputControl(name = "rightStickPress", layout = "Button", bit = 9, displayName = "Right Stick Press")]
	[InputControl(name = "leftShoulder", layout = "Button", bit = 10, displayName = "Left Shoulder", shortDisplayName = "LB")]
	[InputControl(name = "rightShoulder", layout = "Button", bit = 11, displayName = "Right Shoulder", shortDisplayName = "RB")]
	[InputControl(name = "start", layout = "Button", bit = 12, usage = "Menu", displayName = "Start")]
	[InputControl(name = "select", layout = "Button", bit = 13, displayName = "Select")]
	public uint buttons; //Field offset: 0x0
	[InputControl(layout = "Stick", usage = "Primary2DMotion", processors = "stickDeadzone", displayName = "Left Stick", shortDisplayName = "LS")]
	public Vector2 leftStick; //Field offset: 0x4
	[InputControl(layout = "Stick", usage = "Secondary2DMotion", processors = "stickDeadzone", displayName = "Right Stick", shortDisplayName = "RS")]
	public Vector2 rightStick; //Field offset: 0xC
	[InputControl(layout = "Button", format = "FLT", usage = "SecondaryTrigger", displayName = "Left Trigger", shortDisplayName = "LT")]
	public float leftTrigger; //Field offset: 0x14
	[InputControl(layout = "Button", format = "FLT", usage = "SecondaryTrigger", displayName = "Right Trigger", shortDisplayName = "RT")]
	public float rightTrigger; //Field offset: 0x18

	public override FourCC format
	{
		 get { } //Length: 58
	}

	public static FourCC Format
	{
		 get { } //Length: 58
	}

	public GamepadState(GamepadButton[] buttons) { }

	public override FourCC get_format() { }

	public static FourCC get_Format() { }

	public GamepadState WithButton(GamepadButton button, bool value = true) { }

}

