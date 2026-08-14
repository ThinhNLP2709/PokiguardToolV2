namespace UnityEngine.InputSystem.LowLevel;

public struct InputEventBuffer : IEnumerable<InputEventPtr>, IEnumerable, IDisposable, ICloneable
{
	private struct Enumerator : IEnumerator<InputEventPtr>, IEnumerator, IDisposable
	{
		private readonly InputEvent* m_Buffer; //Field offset: 0x0
		private readonly int m_EventCount; //Field offset: 0x8
		private InputEvent* m_CurrentEvent; //Field offset: 0x10
		private int m_CurrentIndex; //Field offset: 0x18

		public override InputEventPtr Current
		{
			 get { } //Length: 5
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 69
		}

		public Enumerator(InputEventBuffer buffer) { }

		public override void Dispose() { }

		public override InputEventPtr get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	public const long BufferSizeUnknown = -1; //Field offset: 0x0
	private NativeArray<Byte> m_Buffer; //Field offset: 0x0
	private long m_SizeInBytes; //Field offset: 0x10
	private int m_EventCount; //Field offset: 0x18
	private bool m_WeOwnTheBuffer; //Field offset: 0x1C

	public InputEventPtr bufferPtr
	{
		 get { } //Length: 68
	}

	public long capacityInBytes
	{
		 get { } //Length: 61
	}

	public NativeArray<Byte> data
	{
		 get { } //Length: 10
	}

	public int eventCount
	{
		 get { } //Length: 4
	}

	public long sizeInBytes
	{
		 get { } //Length: 5
	}

	public InputEventBuffer(InputEvent* eventPtr, int eventCount, int sizeInBytes = -1, int capacityInBytes = -1) { }

	public InputEventBuffer(NativeArray<Byte> buffer, int eventCount, int sizeInBytes = -1, bool transferNativeArrayOwnership = false) { }

	internal void AdvanceToNextEvent(ref InputEvent* currentReadPos, ref InputEvent* currentWritePos, ref int numEventsRetainedInBuffer, ref int numRemainingEvents, bool leaveEventInBuffer) { }

	public InputEvent* AllocateEvent(int sizeInBytes, int capacityIncrementInBytes = 2048, Allocator allocator = 4) { }

	public void AppendEvent(InputEvent* eventPtr, int capacityIncrementInBytes = 2048, Allocator allocator = 4) { }

	public InputEventBuffer Clone() { }

	public bool Contains(InputEvent* eventPtr) { }

	public override void Dispose() { }

	public InputEventPtr get_bufferPtr() { }

	public long get_capacityInBytes() { }

	public NativeArray<Byte> get_data() { }

	public int get_eventCount() { }

	public long get_sizeInBytes() { }

	public override IEnumerator<InputEventPtr> GetEnumerator() { }

	public void Reset() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	private override object System.ICloneable.Clone() { }

}

