namespace Unity.Collections.LowLevel.Unsafe;

[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
[DebuggerTypeProxy(typeof(UnsafePtrListDebugView`1))]
[DefaultMember("Item")]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
public struct UnsafePtrList : INativeDisposable, IDisposable, IEnumerable<IntPtr>, IEnumerable
{
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal struct ParallelReader
	{
		[NativeDisableUnsafePtrRestriction]
		public readonly T** Ptr; //Field offset: 0x0
		public readonly int Length; //Field offset: 0x0

		internal ParallelReader(T** ptr, int length) { }

		public bool Contains(Void* ptr) { }

		public int IndexOf(Void* ptr) { }

	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal struct ParallelWriter
	{
		[NativeDisableUnsafePtrRestriction]
		public readonly T** Ptr; //Field offset: 0x0
		[NativeDisableUnsafePtrRestriction]
		public UnsafeList<IntPtr>* ListData; //Field offset: 0x0

		internal ParallelWriter(T** ptr, UnsafeList<IntPtr>* listData) { }

		public void AddNoResize(T* value) { }

		public void AddRangeNoResize(T** ptr, int count) { }

		public void AddRangeNoResize(UnsafePtrList<T> list) { }

	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal struct ReadOnly
	{
		[NativeDisableUnsafePtrRestriction]
		public readonly T** Ptr; //Field offset: 0x0
		public readonly int Length; //Field offset: 0x0

		public bool IsCreated
		{
			[IsReadOnly]
			 get { } //Length: 8
		}

		public bool IsEmpty
		{
			[IsReadOnly]
			 get { } //Length: 138
		}

		internal ReadOnly(T** ptr, int length) { }

		public bool Contains(Void* ptr) { }

		[IsReadOnly]
		public bool get_IsCreated() { }

		[IsReadOnly]
		public bool get_IsEmpty() { }

		public int IndexOf(Void* ptr) { }

	}

	[NativeDisableUnsafePtrRestriction]
	public readonly T** Ptr; //Field offset: 0x0
	public readonly int m_length; //Field offset: 0x0
	public readonly int m_capacity; //Field offset: 0x0
	public readonly AllocatorHandle Allocator; //Field offset: 0x0
	private readonly int padding; //Field offset: 0x0

	public int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 192
		 set { } //Length: 165
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 8
	}

	public bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 208
	}

	public T* Item
	{
		 get { } //Length: 11
		 set { } //Length: 11
	}

	public int Length
	{
		[IsReadOnly]
		 get { } //Length: 187
		 set { } //Length: 165
	}

	public UnsafePtrList`1(T** ptr, int length) { }

	public UnsafePtrList`1(int initialCapacity, AllocatorHandle allocator, NativeArrayOptions options = 0) { }

	public void Add(in IntPtr value) { }

	public void Add(Void* value) { }

	public void AddNoResize(Void* value) { }

	public void AddRange(UnsafePtrList<T> list) { }

	public void AddRange(Void* ptr, int length) { }

	public void AddRangeNoResize(Void** ptr, int count) { }

	public void AddRangeNoResize(UnsafePtrList<T> list) { }

	public ParallelReader<T> AsParallelReader() { }

	public ParallelWriter<T> AsParallelWriter() { }

	public ReadOnly<T> AsReadOnly() { }

	public void Clear() { }

	public bool Contains(Void* ptr) { }

	public static UnsafePtrList<T>* Create(T** ptr, int length) { }

	public static UnsafePtrList<T>* Create(int initialCapacity, AllocatorHandle allocator, NativeArrayOptions options = 0) { }

	public static void Destroy(UnsafePtrList<T>* listData) { }

	public override void Dispose() { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	public T* ElementAt(int index) { }

	[IsReadOnly]
	public int get_Capacity() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public bool get_IsEmpty() { }

	public T* get_Item(int index) { }

	[IsReadOnly]
	public int get_Length() { }

	public int IndexOf(Void* ptr) { }

	public void InsertRangeWithBeginEnd(int begin, int end) { }

	public void RemoveAt(int index) { }

	public void RemoveAtSwapBack(int index) { }

	public void RemoveRange(int index, int count) { }

	public void RemoveRangeSwapBack(int index, int count) { }

	public void Resize(int length, NativeArrayOptions options = 0) { }

	public void set_Capacity(int value) { }

	public void set_Item(int index, T* value) { }

	public void set_Length(int value) { }

	public void SetCapacity(int capacity) { }

	private override IEnumerator<IntPtr> System.Collections.Generic.IEnumerable<System.IntPtr>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public void TrimExcess() { }

}

