namespace UnityEngine.InputSystem.LowLevel;

internal struct InputEventStream
{
	private InputEventBuffer m_NativeBuffer; //Field offset: 0x0
	private InputEvent* m_CurrentNativeEventReadPtr; //Field offset: 0x20
	private InputEvent* m_CurrentNativeEventWritePtr; //Field offset: 0x28
	private int m_RemainingNativeEventCount; //Field offset: 0x30
	private readonly int m_MaxAppendedEvents; //Field offset: 0x34
	private InputEventBuffer m_AppendBuffer; //Field offset: 0x38
	private InputEvent* m_CurrentAppendEventReadPtr; //Field offset: 0x58
	private InputEvent* m_CurrentAppendEventWritePtr; //Field offset: 0x60
	private int m_RemainingAppendEventCount; //Field offset: 0x68
	private int m_NumEventsRetainedInBuffer; //Field offset: 0x6C
	private bool m_IsOpen; //Field offset: 0x70

	public InputEvent* currentEventPtr
	{
		 get { } //Length: 25
	}

	public bool isOpen
	{
		 get { } //Length: 5
	}

	public uint numBytesRetainedInBuffer
	{
		 get { } //Length: 85
	}

	public int numEventsRetainedInBuffer
	{
		 get { } //Length: 4
	}

	public int remainingEventCount
	{
		 get { } //Length: 7
	}

	public InputEventStream(ref InputEventBuffer eventBuffer, int maxAppendedEvents) { }

	public InputEvent* Advance(bool leaveEventInBuffer) { }

	public void CleanUpAfterException() { }

	public void Close(ref InputEventBuffer eventBuffer) { }

	public InputEvent* get_currentEventPtr() { }

	public bool get_isOpen() { }

	public uint get_numBytesRetainedInBuffer() { }

	public int get_numEventsRetainedInBuffer() { }

	public int get_remainingEventCount() { }

	public InputEvent* Peek() { }

	public void Write(InputEvent* eventPtr) { }

}

