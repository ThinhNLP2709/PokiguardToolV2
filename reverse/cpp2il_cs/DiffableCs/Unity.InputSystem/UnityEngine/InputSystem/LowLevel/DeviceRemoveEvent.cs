namespace UnityEngine.InputSystem.LowLevel;

public struct DeviceRemoveEvent : IInputEventTypeInfo
{
	public const int Type = 1146242381; //Field offset: 0x0
	public InputEvent baseEvent; //Field offset: 0x0

	public override FourCC typeStatic
	{
		 get { } //Length: 6
	}

	public static DeviceRemoveEvent Create(int deviceId, double time = -1) { }

	public override FourCC get_typeStatic() { }

	public InputEventPtr ToEventPtr() { }

}

