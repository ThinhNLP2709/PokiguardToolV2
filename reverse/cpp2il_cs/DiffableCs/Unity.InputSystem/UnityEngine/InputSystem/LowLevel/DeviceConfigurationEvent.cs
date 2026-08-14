namespace UnityEngine.InputSystem.LowLevel;

public struct DeviceConfigurationEvent : IInputEventTypeInfo
{
	public const int Type = 1145259591; //Field offset: 0x0
	public InputEvent baseEvent; //Field offset: 0x0

	public override FourCC typeStatic
	{
		 get { } //Length: 6
	}

	public static DeviceConfigurationEvent Create(int deviceId, double time) { }

	public override FourCC get_typeStatic() { }

	public InputEventPtr ToEventPtr() { }

}

