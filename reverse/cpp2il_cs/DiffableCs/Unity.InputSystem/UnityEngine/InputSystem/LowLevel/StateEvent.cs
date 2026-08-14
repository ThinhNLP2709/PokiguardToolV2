namespace UnityEngine.InputSystem.LowLevel;

public struct StateEvent : IInputEventTypeInfo
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <stateData>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	public const int Type = 1398030676; //Field offset: 0x0
	internal const int kStateDataSizeToSubtract = 1; //Field offset: 0x0
	public InputEvent baseEvent; //Field offset: 0x0
	public FourCC stateFormat; //Field offset: 0x14
	[FixedBuffer(typeof(byte), 1)]
	internal <stateData>e__FixedBuffer stateData; //Field offset: 0x18

	public Void* state
	{
		 get { } //Length: 5
	}

	public uint stateSizeInBytes
	{
		 get { } //Length: 19
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 6
	}

	public static StateEvent* From(InputEventPtr ptr) { }

	public static NativeArray<Byte> From(InputDevice device, out InputEventPtr eventPtr, Allocator allocator = 2) { }

	private static NativeArray<Byte> From(InputDevice device, out InputEventPtr eventPtr, Allocator allocator, bool useDefaultState) { }

	public static NativeArray<Byte> FromDefaultStateFor(InputDevice device, out InputEventPtr eventPtr, Allocator allocator = 2) { }

	internal static StateEvent* FromUnchecked(InputEventPtr ptr) { }

	public Void* get_state() { }

	public uint get_stateSizeInBytes() { }

	public override FourCC get_typeStatic() { }

	public static int GetEventSizeWithPayload() { }

	public TState GetState() { }

	public static TState GetState(InputEventPtr ptr) { }

	public InputEventPtr ToEventPtr() { }

}

