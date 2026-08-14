namespace UnityEngine.InputSystem.LowLevel;

internal struct ActionEvent : IInputEventTypeInfo
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <m_ValueData>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	public InputEvent baseEvent; //Field offset: 0x0
	private ushort m_ControlIndex; //Field offset: 0x14
	private ushort m_BindingIndex; //Field offset: 0x16
	private ushort m_InteractionIndex; //Field offset: 0x18
	private byte m_StateIndex; //Field offset: 0x1A
	private byte m_Phase; //Field offset: 0x1B
	private double m_StartTime; //Field offset: 0x1C
	[FixedBuffer(typeof(byte), 1)]
	public <m_ValueData>e__FixedBuffer m_ValueData; //Field offset: 0x24

	public int bindingIndex
	{
		 get { } //Length: 5
		 set { } //Length: 103
	}

	public int controlIndex
	{
		 get { } //Length: 5
		 set { } //Length: 103
	}

	public int interactionIndex
	{
		 get { } //Length: 22
		 set { } //Length: 119
	}

	public InputActionPhase phase
	{
		 get { } //Length: 5
		 set { } //Length: 4
	}

	public double startTime
	{
		 get { } //Length: 6
		 set { } //Length: 6
	}

	public int stateIndex
	{
		 get { } //Length: 5
		 set { } //Length: 102
	}

	public static FourCC Type
	{
		 get { } //Length: 58
	}

	public override FourCC typeStatic
	{
		 get { } //Length: 58
	}

	public Byte* valueData
	{
		 get { } //Length: 5
	}

	public int valueSizeInBytes
	{
		 get { } //Length: 8
	}

	public static ActionEvent* From(InputEventPtr ptr) { }

	public int get_bindingIndex() { }

	public int get_controlIndex() { }

	public int get_interactionIndex() { }

	public InputActionPhase get_phase() { }

	public double get_startTime() { }

	public int get_stateIndex() { }

	public static FourCC get_Type() { }

	public override FourCC get_typeStatic() { }

	public Byte* get_valueData() { }

	public int get_valueSizeInBytes() { }

	public static int GetEventSizeWithValueSize(int valueSizeInBytes) { }

	public void set_bindingIndex(int value) { }

	public void set_controlIndex(int value) { }

	public void set_interactionIndex(int value) { }

	public void set_phase(InputActionPhase value) { }

	public void set_startTime(double value) { }

	public void set_stateIndex(int value) { }

	public InputEventPtr ToEventPtr() { }

}

