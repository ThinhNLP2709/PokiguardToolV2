namespace UnityEngine.InputSystem.LowLevel;

public struct TextEvent : IInputEventTypeInfo
{
	public const int Type = 1413830740; //Field offset: 0x0
	public InputEvent baseEvent; //Field offset: 0x0
	public int character; //Field offset: 0x14

	public override FourCC typeStatic
	{
		 get { } //Length: 6
	}

	public static TextEvent Create(int deviceId, char character, double time = -1) { }

	public static TextEvent Create(int deviceId, int character, double time = -1) { }

	public static TextEvent* From(InputEventPtr eventPtr) { }

	public override FourCC get_typeStatic() { }

}

