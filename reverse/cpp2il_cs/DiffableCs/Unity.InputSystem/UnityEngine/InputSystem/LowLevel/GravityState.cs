namespace UnityEngine.InputSystem.LowLevel;

internal struct GravityState : IInputStateTypeInfo
{
	[InputControl(displayName = "Gravity", processors = "CompensateDirection", noisy = True)]
	public Vector3 gravity; //Field offset: 0x0

	public override FourCC format
	{
		 get { } //Length: 58
	}

	public static FourCC kFormat
	{
		 get { } //Length: 58
	}

	public override FourCC get_format() { }

	public static FourCC get_kFormat() { }

}

