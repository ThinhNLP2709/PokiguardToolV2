namespace UnityEngine.InputSystem.LowLevel;

internal struct LinearAccelerationState : IInputStateTypeInfo
{
	[InputControl(displayName = "Acceleration", processors = "CompensateDirection", noisy = True)]
	public Vector3 acceleration; //Field offset: 0x0

	public override FourCC format
	{
		 get { } //Length: 55
	}

	public static FourCC kFormat
	{
		 get { } //Length: 55
	}

	public override FourCC get_format() { }

	public static FourCC get_kFormat() { }

}

