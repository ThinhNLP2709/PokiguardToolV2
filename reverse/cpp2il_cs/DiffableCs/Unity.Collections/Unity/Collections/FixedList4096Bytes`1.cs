namespace Unity.Collections;

[DebuggerTypeProxy(typeof(FixedList4096BytesDebugView`1))]
[DefaultMember("Item")]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
public struct FixedList4096Bytes : INativeList<T>, IIndexable<T>, IEnumerable<T>, IEnumerable, IEquatable<FixedList32Bytes`1<T>>, IComparable<FixedList32Bytes`1<T>>, IEquatable<FixedList64Bytes`1<T>>, IComparable<FixedList64Bytes`1<T>>, IEquatable<FixedList128Bytes`1<T>>, IComparable<FixedList128Bytes`1<T>>, IEquatable<FixedList512Bytes`1<T>>, IComparable<FixedList512Bytes`1<T>>, IEquatable<FixedList4096Bytes`1<T>>, IComparable<FixedList4096Bytes`1<T>>
{
	internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		private FixedList4096Bytes<T> m_List; //Field offset: 0x0
		private int m_Index; //Field offset: 0x0

		public override T Current
		{
			 get { } //Length: 71
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 163
		}

		public Enumerator(ref FixedList4096Bytes<T>& list) { }

		public override void Dispose() { }

		public override T get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[SerializeField]
	internal FixedBytes4096Align8 data; //Field offset: 0x0

	internal Byte* buffer
	{
		[IsReadOnly]
		internal get { } //Length: 57
	}

	internal Byte* Buffer
	{
		[IsReadOnly]
		internal get { } //Length: 119
	}

	public override int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 122
		 set { } //Length: 3
	}

	[CreateProperty]
	private IEnumerable<T> Elements
	{
		private get { } //Length: 54
	}

	public override bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 72
	}

	public override T Item
	{
		[IsReadOnly]
		 get { } //Length: 125
		 set { } //Length: 125
	}

	internal ushort length
	{
		[IsReadOnly]
		internal get { } //Length: 4
		internal set { } //Length: 4
	}

	[CreateProperty]
	public override int Length
	{
		[IsReadOnly]
		 get { } //Length: 36
		 set { } //Length: 47
	}

	internal int LengthInBytes
	{
		internal get { } //Length: 100
	}

	public FixedList4096Bytes`1(in FixedList64Bytes<T>& other) { }

	public FixedList4096Bytes`1(in FixedList512Bytes<T>& other) { }

	public FixedList4096Bytes`1(in FixedList32Bytes<T>& other) { }

	public FixedList4096Bytes`1(in FixedList128Bytes<T>& other) { }

	public void Add(in T item) { }

	public void AddNoResize(in T item) { }

	public void AddRange(Void* ptr, int length) { }

	public void AddRangeNoResize(Void* ptr, int length) { }

	public void AddReplicate(in T value, int count) { }

	public override void Clear() { }

	public override int CompareTo(FixedList32Bytes<T> other) { }

	public override int CompareTo(FixedList64Bytes<T> other) { }

	public override int CompareTo(FixedList128Bytes<T> other) { }

	public override int CompareTo(FixedList4096Bytes<T> other) { }

	public override int CompareTo(FixedList512Bytes<T> other) { }

	public override T ElementAt(int index) { }

	public override bool Equals(FixedList512Bytes<T> other) { }

	public override bool Equals(FixedList128Bytes<T> other) { }

	public override bool Equals(FixedList4096Bytes<T> other) { }

	public override bool Equals(FixedList64Bytes<T> other) { }

	[ExcludeFromBurstCompatTesting("Takes managed object")]
	public virtual bool Equals(object obj) { }

	public override bool Equals(FixedList32Bytes<T> other) { }

	[IsReadOnly]
	internal Byte* get_buffer() { }

	[IsReadOnly]
	internal Byte* get_Buffer() { }

	[IsReadOnly]
	public override int get_Capacity() { }

	private IEnumerable<T> get_Elements() { }

	[IsReadOnly]
	public override bool get_IsEmpty() { }

	[IsReadOnly]
	public override T get_Item(int index) { }

	[IsReadOnly]
	internal ushort get_length() { }

	[IsReadOnly]
	public override int get_Length() { }

	internal int get_LengthInBytes() { }

	public Enumerator<T> GetEnumerator() { }

	public virtual int GetHashCode() { }

	internal int Initialize(in FixedList512Bytes<T>& other) { }

	internal int Initialize(in FixedList128Bytes<T>& other) { }

	internal int Initialize(in FixedList32Bytes<T>& other) { }

	internal int Initialize(in FixedList64Bytes<T>& other) { }

	public void Insert(int index, in T item) { }

	public void InsertRange(int index, int count) { }

	public void InsertRangeWithBeginEnd(int begin, int end) { }

	public static bool op_Equality(in FixedList4096Bytes<T>& a, in FixedList64Bytes<T>& b) { }

	public static bool op_Equality(in FixedList4096Bytes<T>& a, in FixedList128Bytes<T>& b) { }

	public static bool op_Equality(in FixedList4096Bytes<T>& a, in FixedList4096Bytes<T>& b) { }

	public static bool op_Equality(in FixedList4096Bytes<T>& a, in FixedList32Bytes<T>& b) { }

	public static bool op_Equality(in FixedList4096Bytes<T>& a, in FixedList512Bytes<T>& b) { }

	public static FixedList4096Bytes<T> op_Implicit(in FixedList128Bytes<T>& other) { }

	public static FixedList4096Bytes<T> op_Implicit(in FixedList64Bytes<T>& other) { }

	public static FixedList4096Bytes<T> op_Implicit(in FixedList32Bytes<T>& other) { }

	public static FixedList4096Bytes<T> op_Implicit(in FixedList512Bytes<T>& other) { }

	public static bool op_Inequality(in FixedList4096Bytes<T>& a, in FixedList4096Bytes<T>& b) { }

	public static bool op_Inequality(in FixedList4096Bytes<T>& a, in FixedList32Bytes<T>& b) { }

	public static bool op_Inequality(in FixedList4096Bytes<T>& a, in FixedList512Bytes<T>& b) { }

	public static bool op_Inequality(in FixedList4096Bytes<T>& a, in FixedList128Bytes<T>& b) { }

	public static bool op_Inequality(in FixedList4096Bytes<T>& a, in FixedList64Bytes<T>& b) { }

	public void RemoveAt(int index) { }

	public void RemoveAtSwapBack(int index) { }

	public void RemoveRange(int index, int count) { }

	public void RemoveRangeSwapBack(int index, int count) { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, T value) { }

	internal void set_length(ushort value) { }

	public override void set_Length(int value) { }

	private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	[ExcludeFromBurstCompatTesting("Returns managed array")]
	public T[] ToArray() { }

	public NativeArray<T> ToNativeArray(AllocatorHandle allocator) { }

}

