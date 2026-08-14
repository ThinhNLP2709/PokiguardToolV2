namespace UnityEngine.InputSystem.LowLevel;

[DefaultMember("Item")]
public class InputStateHistory : InputStateHistory, IReadOnlyList<Record<TValue>>, IEnumerable<Record<TValue>>, IEnumerable, IReadOnlyCollection<Record<TValue>>
{
	private struct Enumerator : IEnumerator<Record<TValue>>, IEnumerator, IDisposable
	{
		private readonly InputStateHistory<TValue> m_History; //Field offset: 0x0
		private int m_Index; //Field offset: 0x0

		public override Record<TValue> Current
		{
			 get { } //Length: 109
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 190
		}

		public Enumerator(InputStateHistory<TValue> history) { }

		public override void Dispose() { }

		public override Record<TValue> get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	internal struct Record : IEquatable<Record<TValue>>
	{
		private readonly InputStateHistory<TValue> m_Owner; //Field offset: 0x0
		private readonly int m_IndexPlusOne; //Field offset: 0x0
		private uint m_Version; //Field offset: 0x0

		public InputControl<TValue> control
		{
			 get { } //Length: 580
		}

		internal RecordHeader* header
		{
			internal get { } //Length: 70
		}

		public int index
		{
			 get { } //Length: 123
		}

		public Record<TValue> next
		{
			 get { } //Length: 313
		}

		public InputStateHistory<TValue> owner
		{
			 get { } //Length: 4
		}

		public Record<TValue> previous
		{
			 get { } //Length: 309
		}

		internal int recordIndex
		{
			internal get { } //Length: 6
		}

		public double time
		{
			 get { } //Length: 155
		}

		public bool valid
		{
			 get { } //Length: 138
		}

		internal Record(InputStateHistory<TValue> owner, int index) { }

		internal Record(InputStateHistory<TValue> owner, int index, RecordHeader* header) { }

		private void CheckValid() { }

		public void CopyFrom(Record<TValue> record) { }

		public virtual bool Equals(object obj) { }

		public override bool Equals(Record<TValue> other) { }

		public InputControl<TValue> get_control() { }

		internal RecordHeader* get_header() { }

		public int get_index() { }

		public Record<TValue> get_next() { }

		public InputStateHistory<TValue> get_owner() { }

		public Record<TValue> get_previous() { }

		internal int get_recordIndex() { }

		public double get_time() { }

		public bool get_valid() { }

		public virtual int GetHashCode() { }

		public Void* GetUnsafeExtraMemoryPtr() { }

		internal Void* GetUnsafeExtraMemoryPtrUnchecked() { }

		public Void* GetUnsafeMemoryPtr() { }

		internal Void* GetUnsafeMemoryPtrUnchecked() { }

		public TValue ReadValue() { }

		public virtual string ToString() { }

	}


	public override Record<TValue> Item
	{
		 get { } //Length: 297
		 set { } //Length: 369
	}

	public InputStateHistory`1(Nullable<Int32> maxStateSizeInBytes = null) { }

	public InputStateHistory`1(InputControl<TValue> control) { }

	public InputStateHistory`1(string path) { }

	public Record<TValue> AddRecord(Record<TValue> record) { }

	protected virtual void Finalize() { }

	public override Record<TValue> get_Item(int index) { }

	public override IEnumerator<Record<TValue>> GetEnumerator() { }

	public Record<TValue> RecordStateChange(InputControl<TValue> control, TValue value, double time = -1) { }

	public void set_Item(int index, Record<TValue> value) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

