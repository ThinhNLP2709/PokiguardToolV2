namespace UnityEngine.InputSystem.XInput.LowLevel;

internal struct XInputControllerWindowsState : IInputStateTypeInfo
{
	internal enum Button
	{
		DPadUp = 0,
		DPadDown = 1,
		DPadLeft = 2,
		DPadRight = 3,
		Start = 4,
		Select = 5,
		LeftThumbstickPress = 6,
		RightThumbstickPress = 7,
		LeftShoulder = 8,
		RightShoulder = 9,
		A = 12,
		B = 13,
		X = 14,
		Y = 15,
	}

	[InputControl(name = "dpad", layout = "Dpad", sizeInBits = 4, bit = 0)]
	[InputControl(name = "dpad/up", bit = 0)]
	[InputControl(name = "dpad/down", bit = 1)]
	[InputControl(name = "dpad/left", bit = 2)]
	[InputControl(name = "dpad/right", bit = 3)]
	[InputControl(name = "start", bit = 4, displayName = "Start")]
	[InputControl(name = "select", bit = 5, displayName = "Select")]
	[InputControl(name = "leftStickPress", bit = 6)]
	[InputControl(name = "rightStickPress", bit = 7)]
	[InputControl(name = "leftShoulder", bit = 8)]
	[InputControl(name = "rightShoulder", bit = 9)]
	[InputControl(name = "buttonSouth", bit = 12, displayName = "A")]
	[InputControl(name = "buttonEast", bit = 13, displayName = "B")]
	[InputControl(name = "buttonWest", bit = 14, displayName = "X")]
	[InputControl(name = "buttonNorth", bit = 15, displayName = "Y")]
	public ushort buttons; //Field offset: 0x0
	[InputControl(name = "leftTrigger", format = "BYTE")]
	public byte leftTrigger; //Field offset: 0x2
	[InputControl(name = "rightTrigger", format = "BYTE")]
	public byte rightTrigger; //Field offset: 0x3
	[InputControl(name = "leftStick", layout = "Stick", format = "VC2S")]
	[InputControl(name = "leftStick/x", offset = 0, format = "SHRT", parameters = "clamp=false,invert=false,normalize=false")]
	[InputControl(name = "leftStick/left", offset = 0, format = "SHRT")]
	[InputControl(name = "leftStick/right", offset = 0, format = "SHRT")]
	[InputControl(name = "leftStick/y", offset = 2, format = "SHRT", parameters = "clamp=false,invert=false,normalize=false")]
	[InputControl(name = "leftStick/up", offset = 2, format = "SHRT")]
	[InputControl(name = "leftStick/down", offset = 2, format = "SHRT")]
	public short leftStickX; //Field offset: 0x4
	public short leftStickY; //Field offset: 0x6
	[InputControl(name = "rightStick", layout = "Stick", format = "VC2S")]
	[InputControl(name = "rightStick/x", offset = 0, format = "SHRT", parameters = "clamp=false,invert=false,normalize=false")]
	[InputControl(name = "rightStick/left", offset = 0, format = "SHRT")]
	[InputControl(name = "rightStick/right", offset = 0, format = "SHRT")]
	[InputControl(name = "rightStick/y", offset = 2, format = "SHRT", parameters = "clamp=false,invert=false,normalize=false")]
	[InputControl(name = "rightStick/up", offset = 2, format = "SHRT")]
	[InputControl(name = "rightStick/down", offset = 2, format = "SHRT")]
	public short rightStickX; //Field offset: 0x8
	public short rightStickY; //Field offset: 0xA

	public override FourCC format
	{
		 get { } //Length: 58
	}

	public override FourCC get_format() { }

	public XInputControllerWindowsState WithButton(Button button) { }

}

