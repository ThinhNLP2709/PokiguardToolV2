namespace UnityEngineInternal.Input;

internal struct NativeInputEvent
{
	public const int structSize = 20; //Field offset: 0x0
	public NativeInputEventType type; //Field offset: 0x0
	public ushort sizeInBytes; //Field offset: 0x4
	public ushort deviceId; //Field offset: 0x6
	public double time; //Field offset: 0x8
	public int eventId; //Field offset: 0x10

}

