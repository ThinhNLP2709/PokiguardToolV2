namespace UnityEngine.InputSystem.LowLevel;

public struct IMECompositionEvent : IInputEventTypeInfo
{
	internal const int kIMECharBufferSize = 64; //Field offset: 0x0
	public const int Type = 1229800787; //Field offset: 0x0
	public InputEvent baseEvent; //Field offset: 0x0
	public IMECompositionString compositionString; //Field offset: 0x14

	public override FourCC typeStatic
	{
		 get { } //Length: 6
	}

	public static IMECompositionEvent Create(int deviceId, string compositionString, double time) { }

	public override FourCC get_typeStatic() { }

}

