namespace UnityEngine.InputSystem.LowLevel;

public struct InputEvent
{
	private const uint kHandledMask = 2147483648; //Field offset: 0x0
	private const uint kIdMask = 2147483647; //Field offset: 0x0
	internal const int kBaseEventSize = 20; //Field offset: 0x0
	public const int InvalidEventId = 0; //Field offset: 0x0
	internal const int kAlignment = 4; //Field offset: 0x0
	private NativeInputEvent m_Event; //Field offset: 0x0

	public int deviceId
	{
		 get { } //Length: 5
		 set { } //Length: 5
	}

	public int eventId
	{
		 get { } //Length: 8
		 set { } //Length: 14
	}

	public bool handled
	{
		 get { } //Length: 7
		 set { } //Length: 28
	}

	internal double internalTime
	{
		internal get { } //Length: 6
		internal set { } //Length: 6
	}

	public uint sizeInBytes
	{
		 get { } //Length: 5
		 set { } //Length: 166
	}

	public double time
	{
		 get { } //Length: 67
		 set { } //Length: 80
	}

	public FourCC type
	{
		 get { } //Length: 3
		 set { } //Length: 3
	}

	public InputEvent(FourCC type, int sizeInBytes, int deviceId, double time = -1) { }

	public static bool Equals(InputEvent* first, InputEvent* second) { }

	public int get_deviceId() { }

	public int get_eventId() { }

	public bool get_handled() { }

	internal double get_internalTime() { }

	public uint get_sizeInBytes() { }

	public double get_time() { }

	public FourCC get_type() { }

	internal static InputEvent* GetNextInMemory(InputEvent* currentPtr) { }

	internal static InputEvent* GetNextInMemoryChecked(InputEvent* currentPtr, ref InputEventBuffer buffer) { }

	public void set_deviceId(int value) { }

	public void set_eventId(int value) { }

	public void set_handled(bool value) { }

	internal void set_internalTime(double value) { }

	public void set_sizeInBytes(uint value) { }

	public void set_time(double value) { }

	public void set_type(FourCC value) { }

	public virtual string ToString() { }

}

