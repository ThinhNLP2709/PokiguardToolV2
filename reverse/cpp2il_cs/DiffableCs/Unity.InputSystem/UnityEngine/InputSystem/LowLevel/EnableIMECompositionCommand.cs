namespace UnityEngine.InputSystem.LowLevel;

public struct EnableIMECompositionCommand : IInputDeviceCommandInfo
{
	internal const int kSize = 12; //Field offset: 0x0
	public InputDeviceCommand baseCommand; //Field offset: 0x0
	private byte m_ImeEnabled; //Field offset: 0x8

	public bool imeEnabled
	{
		 get { } //Length: 8
	}

	public static FourCC Type
	{
		 get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 58
	}

	public static EnableIMECompositionCommand Create(bool enabled) { }

	public bool get_imeEnabled() { }

	public static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

}

