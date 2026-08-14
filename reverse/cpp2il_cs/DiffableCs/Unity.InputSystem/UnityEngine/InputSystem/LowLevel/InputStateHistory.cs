namespace UnityEngine.InputSystem.LowLevel;

[DefaultMember("Item")]
public class InputStateHistory : IDisposable, IEnumerable<Record>, IEnumerable, IInputStateChangeMonitor
{
	private struct Enumerator : IEnumerator<Record>, IEnumerator, IDisposable
	{
		private readonly InputStateHistory m_History; //Field offset: 0x0
		private int m_Index; //Field offset: 0x8

		public override Record Current
		{
			 get { } //Length: 314
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 84
		}

		public Enumerator(InputStateHistory history) { }

		public override void Dispose() { }

		public override Record get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	internal struct Record : IEquatable<Record>
	{
		private readonly InputStateHistory m_Owner; //Field offset: 0x0
		private readonly int m_IndexPlusOne; //Field offset: 0x8
		private uint m_Version; //Field offset: 0xC

		public InputControl control
		{
			 get { } //Length: 261
		}

		internal RecordHeader* header
		{
			internal get { } //Length: 37
		}

		public int index
		{
			 get { } //Length: 62
		}

		public Record next
		{
			 get { } //Length: 230
		}

		public InputStateHistory owner
		{
			 get { } //Length: 4
		}

		public Record previous
		{
			 get { } //Length: 245
		}

		internal int recordIndex
		{
			internal get { } //Length: 6
		}

		public double time
		{
			 get { } //Length: 57
		}

		public bool valid
		{
			 get { } //Length: 70
		}

		internal uint version
		{
			internal get { } //Length: 4
		}

		internal Record(InputStateHistory owner, int index, RecordHeader* header) { }

		internal void CheckValid() { }

		public void CopyFrom(Record record) { }

		public override bool Equals(Record other) { }

		public virtual bool Equals(object obj) { }

		public InputControl get_control() { }

		internal RecordHeader* get_header() { }

		public int get_index() { }

		public Record get_next() { }

		public InputStateHistory get_owner() { }

		public Record get_previous() { }

		internal int get_recordIndex() { }

		public double get_time() { }

		public bool get_valid() { }

		internal uint get_version() { }

		public virtual int GetHashCode() { }

		public Void* GetUnsafeExtraMemoryPtr() { }

		internal Void* GetUnsafeExtraMemoryPtrUnchecked() { }

		public Void* GetUnsafeMemoryPtr() { }

		internal Void* GetUnsafeMemoryPtrUnchecked() { }

		public TValue ReadValue() { }

		public object ReadValueAsObject() { }

		public virtual string ToString() { }

	}

	private struct RecordHeader
	{
		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <m_StateWithControlIndex>e__FixedBuffer
		{
			public byte FixedElementField; //Field offset: 0x0

		}

		[CompilerGenerated]
		[UnsafeValueType]
		internal struct <m_StateWithoutControlIndex>e__FixedBuffer
		{
			public byte FixedElementField; //Field offset: 0x0

		}

		public const int kSizeWithControlIndex = 16; //Field offset: 0x0
		public const int kSizeWithoutControlIndex = 12; //Field offset: 0x0
		public double time; //Field offset: 0x0
		public uint version; //Field offset: 0x8
		public int controlIndex; //Field offset: 0xC
		[FixedBuffer(typeof(byte), 1)]
		private <m_StateWithoutControlIndex>e__FixedBuffer m_StateWithoutControlIndex; //Field offset: 0xC
		[FixedBuffer(typeof(byte), 1)]
		private <m_StateWithControlIndex>e__FixedBuffer m_StateWithControlIndex; //Field offset: 0x10

		public Byte* statePtrWithControlIndex
		{
			 get { } //Length: 5
		}

		public Byte* statePtrWithoutControlIndex
		{
			 get { } //Length: 5
		}

		public Byte* get_statePtrWithControlIndex() { }

		public Byte* get_statePtrWithoutControlIndex() { }

	}

	private const int kDefaultHistorySize = 128; //Field offset: 0x0
	[CompilerGenerated]
	private Action<Record> <onRecordAdded>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private Func<InputControl, Double, InputEventPtr, Boolean> <onShouldRecordStateChange>k__BackingField; //Field offset: 0x18
	internal InputControl[] m_Controls; //Field offset: 0x20
	internal int m_ControlCount; //Field offset: 0x28
	private NativeArray<Byte> m_RecordBuffer; //Field offset: 0x30
	private int m_StateSizeInBytes; //Field offset: 0x40
	private int m_RecordCount; //Field offset: 0x44
	private int m_HistoryDepth; //Field offset: 0x48
	private int m_ExtraMemoryPerRecord; //Field offset: 0x4C
	internal int m_HeadIndex; //Field offset: 0x50
	internal uint m_CurrentVersion; //Field offset: 0x54
	private Nullable<InputUpdateType> m_UpdateMask; //Field offset: 0x58
	internal readonly bool m_AddNewControls; //Field offset: 0x60

	internal int bytesPerRecord
	{
		internal get { } //Length: 59
	}

	public ReadOnlyArray<InputControl> controls
	{
		 get { } //Length: 95
	}

	public override int Count
	{
		 get { } //Length: 4
	}

	public int extraMemoryPerRecord
	{
		 get { } //Length: 4
		 set { } //Length: 215
	}

	public int historyDepth
	{
		 get { } //Length: 4
		 set { } //Length: 215
	}

	public Record Item
	{
		 get { } //Length: 280
		 set { } //Length: 339
	}

	public Action<Record> onRecordAdded
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public Func<InputControl, Double, InputEventPtr, Boolean> onShouldRecordStateChange
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 13
	}

	public InputUpdateType updateMask
	{
		 get { } //Length: 146
		 set { } //Length: 185
	}

	public uint version
	{
		 get { } //Length: 4
	}

	public InputStateHistory(IEnumerable<InputControl> controls) { }

	public InputStateHistory(InputControl control) { }

	public InputStateHistory(string path) { }

	public InputStateHistory(int maxStateSizeInBytes) { }

	public Record AddRecord(Record record) { }

	private void Allocate() { }

	protected private RecordHeader* AllocateRecord(out int index) { }

	public void Clear() { }

	protected void Destroy() { }

	public override void Dispose() { }

	protected virtual void Finalize() { }

	internal int get_bytesPerRecord() { }

	public ReadOnlyArray<InputControl> get_controls() { }

	public override int get_Count() { }

	public int get_extraMemoryPerRecord() { }

	public int get_historyDepth() { }

	public Record get_Item(int index) { }

	[CompilerGenerated]
	public Action<Record> get_onRecordAdded() { }

	[CompilerGenerated]
	public Func<InputControl, Double, InputEventPtr, Boolean> get_onShouldRecordStateChange() { }

	public InputUpdateType get_updateMask() { }

	public uint get_version() { }

	public override IEnumerator<Record> GetEnumerator() { }

	protected private RecordHeader* GetRecord(int index) { }

	internal RecordHeader* GetRecordUnchecked(int index) { }

	protected TValue ReadValue(RecordHeader* data) { }

	protected object ReadValueAsObject(RecordHeader* data) { }

	protected private int RecordIndexToUserIndex(int index) { }

	public Record RecordStateChange(InputControl control, InputEventPtr eventPtr) { }

	public Record RecordStateChange(InputControl control, Void* statePtr, double time) { }

	public void set_extraMemoryPerRecord(int value) { }

	public void set_historyDepth(int value) { }

	public void set_Item(int index, Record value) { }

	[CompilerGenerated]
	public void set_onRecordAdded(Action<Record> value) { }

	[CompilerGenerated]
	public void set_onShouldRecordStateChange(Func<InputControl, Double, InputEventPtr, Boolean> value) { }

	public void set_updateMask(InputUpdateType value) { }

	public void StartRecording() { }

	public void StopRecording() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	private override void UnityEngine.InputSystem.LowLevel.IInputStateChangeMonitor.NotifyControlStateChanged(InputControl control, double time, InputEventPtr eventPtr, long monitorIndex) { }

	private override void UnityEngine.InputSystem.LowLevel.IInputStateChangeMonitor.NotifyTimerExpired(InputControl control, double time, long monitorIndex, int timerIndex) { }

	protected private int UserIndexToRecordIndex(int index) { }

}

