namespace UnityEngine.InputSystem.DualShock.LowLevel;

internal struct DualSenseHIDOutputReportPayload
{
	public byte enableFlags1; //Field offset: 0x0
	public byte enableFlags2; //Field offset: 0x1
	public byte highFrequencyMotorSpeed; //Field offset: 0x2
	public byte lowFrequencyMotorSpeed; //Field offset: 0x3
	public byte redColor; //Field offset: 0x2C
	public byte greenColor; //Field offset: 0x2D
	public byte blueColor; //Field offset: 0x2E

}

