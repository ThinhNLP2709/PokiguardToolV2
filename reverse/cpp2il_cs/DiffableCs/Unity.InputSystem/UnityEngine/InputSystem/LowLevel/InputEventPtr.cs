namespace UnityEngine.InputSystem.LowLevel;

public struct InputEventPtr : IEquatable<InputEventPtr>
{
	private readonly InputEvent* m_EventPtr; //Field offset: 0x0

	public InputEvent* data
	{
		 get { } //Length: 4
	}

	public int deviceId
	{
		 get { } //Length: 17
		 set { } //Length: 104
	}

	public bool handled
	{
		 get { } //Length: 19
		 set { } //Length: 127
	}

	public int id
	{
		 get { } //Length: 20
		 set { } //Length: 113
	}

	internal double internalTime
	{
		internal get { } //Length: 19
		internal set { } //Length: 105
	}

	public uint sizeInBytes
	{
		 get { } //Length: 17
	}

	internal FourCC stateFormat
	{
		internal get { } //Length: 193
	}

	internal uint stateOffset
	{
		internal get { } //Length: 203
	}

	internal uint stateSizeInBytes
	{
		internal get { } //Length: 252
	}

	public double time
	{
		 get { } //Length: 88
		 set { } //Length: 158
	}

	public FourCC type
	{
		 get { } //Length: 15
	}

	public bool valid
	{
		 get { } //Length: 8
	}

	public InputEventPtr(InputEvent* eventPtr) { }

	public virtual bool Equals(object obj) { }

	public override bool Equals(InputEventPtr other) { }

	public static InputEventPtr From(InputEvent* eventPtr) { }

	public static InputEvent* FromInputEventPtr(InputEventPtr eventPtr) { }

	public InputEvent* get_data() { }

	public int get_deviceId() { }

	public bool get_handled() { }

	public int get_id() { }

	internal double get_internalTime() { }

	public uint get_sizeInBytes() { }

	internal FourCC get_stateFormat() { }

	internal uint get_stateOffset() { }

	internal uint get_stateSizeInBytes() { }

	public double get_time() { }

	public FourCC get_type() { }

	public bool get_valid() { }

	public virtual int GetHashCode() { }

	public bool IsA() { }

	public InputEventPtr Next() { }

	public static bool op_Equality(InputEventPtr left, InputEventPtr right) { }

	public static InputEvent* op_Implicit(InputEventPtr eventPtr) { }

	public static InputEventPtr op_Implicit(InputEvent* eventPtr) { }

	public static bool op_Inequality(InputEventPtr left, InputEventPtr right) { }

	public void set_deviceId(int value) { }

	public void set_handled(bool value) { }

	public void set_id(int value) { }

	internal void set_internalTime(double value) { }

	public void set_time(double value) { }

	public InputEvent* ToPointer() { }

	public virtual string ToString() { }

}

