namespace Unity.Collections;

[DefaultMember("Item")]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(FixedBytes32Align8)})]
internal struct FixedList : INativeList<T>, IIndexable<T>
{
	[SerializeField]
	internal U data; //Field offset: 0x0

	internal Byte* buffer
	{
		[IsReadOnly]
		internal get { } //Length: 105
	}

	internal Byte* Buffer
	{
		[IsReadOnly]
		internal get { } //Length: 186
	}

	public override int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 96
		 set { } //Length: 3
	}

	[CreateProperty]
	private IEnumerable<T> Elements
	{
		private get { } //Length: 112
	}

	public override bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 114
	}

	public override T Item
	{
		[IsReadOnly]
		 get { } //Length: 343
		 set { } //Length: 350
	}

	internal ushort length
	{
		[IsReadOnly]
		internal get { } //Length: 64
		internal set { } //Length: 76
	}

	[CreateProperty]
	public override int Length
	{
		[IsReadOnly]
		 get { } //Length: 112
		 set { } //Length: 127
	}

	internal int LengthInBytes
	{
		[IsReadOnly]
		internal get { } //Length: 183
	}

	public void Add(in T item) { }

	public void AddNoResize(in T item) { }

	public void AddRange(Void* ptr, int length) { }

	public void AddRangeNoResize(Void* ptr, int length) { }

	public void AddReplicate(in T value, int count) { }

	public override void Clear() { }

	public override T ElementAt(int index) { }

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

	[IsReadOnly]
	internal int get_LengthInBytes() { }

	public virtual int GetHashCode() { }

	public void Insert(int index, in T item) { }

	public void InsertRange(int index, int count) { }

	public void InsertRangeWithBeginEnd(int begin, int end) { }

	public void RemoveAt(int index) { }

	public void RemoveAtSwapBack(int index) { }

	public void RemoveRange(int index, int count) { }

	public void RemoveRangeSwapBack(int index, int count) { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, T value) { }

	internal void set_length(ushort value) { }

	public override void set_Length(int value) { }

	[ExcludeFromBurstCompatTesting("Returns managed array")]
	public T[] ToArray() { }

	public NativeArray<T> ToNativeArray(AllocatorHandle allocator) { }

}

