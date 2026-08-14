namespace UnityEngine.InputSystem.LowLevel;

public struct DeltaStateEvent : IInputEventTypeInfo
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <stateData>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	public const int Type = 1145852993; //Field offset: 0x0
	public InputEvent baseEvent; //Field offset: 0x0
	public FourCC stateFormat; //Field offset: 0x14
	public uint stateOffset; //Field offset: 0x18
	[FixedBuffer(typeof(byte), 1)]
	internal <stateData>e__FixedBuffer stateData; //Field offset: 0x1C

	public Void* deltaState
	{
		 get { } //Length: 5
	}

	public uint deltaStateSizeInBytes
	{
		 get { } //Length: 8
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 6
	}

	public static DeltaStateEvent* From(InputEventPtr ptr) { }

	public static NativeArray<Byte> From(InputControl control, out InputEventPtr eventPtr, Allocator allocator = 2) { }

	internal static DeltaStateEvent* FromUnchecked(InputEventPtr ptr) { }

	public Void* get_deltaState() { }

	public uint get_deltaStateSizeInBytes() { }

	public override FourCC get_typeStatic() { }

	public InputEventPtr ToEventPtr() { }

}

