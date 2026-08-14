namespace UnityEngine.InputSystem.Switch.LowLevel;

internal struct SwitchProControllerHIDInputState : IInputStateTypeInfo
{
	internal enum Button
	{
		Up = 0,
		Right = 1,
		Down = 2,
		Left = 3,
		West = 4,
		North = 5,
		South = 6,
		East = 7,
		L = 8,
		R = 9,
		StickL = 10,
		StickR = 11,
		ZL = 12,
		ZR = 13,
		Plus = 14,
		Minus = 15,
		Capture = 16,
		Home = 17,
		X = 5,
		B = 6,
		Y = 4,
		A = 7,
	}

	public static FourCC Format; //Field offset: 0x0
	[InputControl(name = "leftStick", layout = "Stick", format = "VC2B")]
	[InputControl(name = "leftStick/x", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5")]
	[InputControl(name = "leftStick/left", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.15,clampMax=0.5,invert")]
	[InputControl(name = "leftStick/right", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=0.85")]
	[InputControl(name = "leftStick/y", offset = 1, format = "BYTE", parameters = "invert,normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5")]
	[InputControl(name = "leftStick/up", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.15,clampMax=0.5,invert")]
	[InputControl(name = "leftStick/down", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=0.85,invert=false")]
	public byte leftStickX; //Field offset: 0x0
	public byte leftStickY; //Field offset: 0x1
	[InputControl(name = "rightStick", layout = "Stick", format = "VC2B")]
	[InputControl(name = "rightStick/x", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5")]
	[InputControl(name = "rightStick/left", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0,clampMax=0.5,invert")]
	[InputControl(name = "rightStick/right", offset = 0, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=1")]
	[InputControl(name = "rightStick/y", offset = 1, format = "BYTE", parameters = "invert,normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5")]
	[InputControl(name = "rightStick/up", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.15,clampMax=0.5,invert")]
	[InputControl(name = "rightStick/down", offset = 1, format = "BYTE", parameters = "normalize,normalizeMin=0.15,normalizeMax=0.85,normalizeZero=0.5,clamp=1,clampMin=0.5,clampMax=0.85,invert=false")]
	public byte rightStickX; //Field offset: 0x2
	public byte rightStickY; //Field offset: 0x3
	[InputControl(name = "dpad", format = "BIT", bit = 0, sizeInBits = 4)]
	[InputControl(name = "rightTrigger", displayName = "ZR", shortDisplayName = "ZR", format = "BIT", bit = 13)]
	[InputControl(name = "leftTrigger", displayName = "ZL", shortDisplayName = "ZL", format = "BIT", bit = 12)]
	[InputControl(name = "rightStickPress", displayName = "Right Stick", bit = 11)]
	[InputControl(name = "leftStickPress", displayName = "Left Stick", bit = 10)]
	[InputControl(name = "rightShoulder", displayName = "R", shortDisplayName = "R", bit = 9)]
	[InputControl(name = "leftShoulder", displayName = "L", shortDisplayName = "L", bit = 8)]
	[InputControl(name = "start", displayName = "Plus", bit = 14, usage = "Menu")]
	[InputControl(name = "buttonEast", displayName = "A", shortDisplayName = "A", bit = 7, usages = new IL2CPP_TYPE_STRING[] {"PrimaryAction", "Submit"})]
	[InputControl(name = "buttonNorth", displayName = "X", shortDisplayName = "X", bit = 5)]
	[InputControl(name = "buttonWest", displayName = "Y", shortDisplayName = "Y", bit = 4, usage = "SecondaryAction")]
	[InputControl(name = "dpad/left", bit = 3)]
	[InputControl(name = "dpad/down", bit = 2)]
	[InputControl(name = "dpad/right", bit = 1)]
	[InputControl(name = "dpad/up", bit = 0)]
	[InputControl(name = "buttonSouth", displayName = "B", shortDisplayName = "B", bit = 6, usages = new IL2CPP_TYPE_STRING[] {"Back", "Cancel"})]
	[InputControl(name = "select", displayName = "Minus", bit = 15)]
	public ushort buttons1; //Field offset: 0x4
	[InputControl(name = "capture", layout = "Button", displayName = "Capture", bit = 0)]
	[InputControl(name = "home", layout = "Button", displayName = "Home", bit = 1)]
	public byte buttons2; //Field offset: 0x6

	public override FourCC format
	{
		 get { } //Length: 77
	}

	private static SwitchProControllerHIDInputState() { }

	public override FourCC get_format() { }

	public void Press(Button button) { }

	public void Release(Button button) { }

	public void Set(Button button, bool state) { }

	public SwitchProControllerHIDInputState WithButton(Button button, bool value = true) { }

}

