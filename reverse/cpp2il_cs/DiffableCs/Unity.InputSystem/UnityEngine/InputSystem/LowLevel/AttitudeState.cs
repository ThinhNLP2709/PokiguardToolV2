namespace UnityEngine.InputSystem.LowLevel;

internal struct AttitudeState : IInputStateTypeInfo
{
	[InputControl(displayName = "Attitude", processors = "CompensateRotation", noisy = True)]
	public Quaternion attitude; //Field offset: 0x0

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

