namespace UnityEngine.InputSystem.LowLevel;

public struct DeviceResetEvent : IInputEventTypeInfo
{
	public const int Type = 1146245972; //Field offset: 0x0
	public InputEvent baseEvent; //Field offset: 0x0
	public bool hardReset; //Field offset: 0x8

	public override FourCC typeStatic
	{
		 get { } //Length: 6
	}

	public static DeviceResetEvent Create(int deviceId, bool hardReset = false, double time = -1) { }

	public override FourCC get_typeStatic() { }

}

