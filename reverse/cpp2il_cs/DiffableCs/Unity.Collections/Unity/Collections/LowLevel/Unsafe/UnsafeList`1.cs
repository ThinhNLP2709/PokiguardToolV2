namespace Unity.Collections.LowLevel.Unsafe;

[DebuggerDisplay("Length = {Length}, Capacity = {Capacity}, IsCreated = {IsCreated}, IsEmpty = {IsEmpty}")]
[DebuggerTypeProxy(typeof(UnsafeListTDebugView`1))]
[DefaultMember("Item")]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
public struct UnsafeList : INativeDisposable, IDisposable, INativeList<T>, IIndexable<T>, IEnumerable<T>, IEnumerable
{
	internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		internal T* m_Ptr; //Field offset: 0x0
		internal int m_Length; //Field offset: 0x0
		internal int m_Index; //Field offset: 0x0

		public override T Current
		{
			 get { } //Length: 95
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 202
		}

		public override void Dispose() { }

		public override T get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal struct ParallelReader
	{
		[NativeDisableUnsafePtrRestriction]
		public readonly T* Ptr; //Field offset: 0x0
		public readonly int Length; //Field offset: 0x0

		internal ParallelReader(T* ptr, int length) { }

	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal struct ParallelWriter
	{
		[NativeDisableUnsafePtrRestriction]
		public UnsafeList<T>* ListData; //Field offset: 0x0

		public Void* Ptr
		{
			[IsReadOnly]
			 get { } //Length: 25
		}

		internal ParallelWriter(UnsafeList<T>* listData) { }

		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void AddNoResize(T value) { }

		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void AddRangeNoResize(Void* ptr, int count) { }

		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		public void AddRangeNoResize(UnsafeList<T> list) { }

		[IsReadOnly]
		public Void* get_Ptr() { }

	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal struct ReadOnly : IEnumerable<T>, IEnumerable
	{
		[NativeDisableUnsafePtrRestriction]
		public readonly T* Ptr; //Field offset: 0x0
		public readonly int Length; //Field offset: 0x0

		public bool IsCreated
		{
			[IsReadOnly]
			 get { } //Length: 8
		}

		public bool IsEmpty
		{
			[IsReadOnly]
			 get { } //Length: 54
		}

		internal ReadOnly(T* ptr, int length) { }

		[IsReadOnly]
		public bool get_IsCreated() { }

		[IsReadOnly]
		public bool get_IsEmpty() { }

		public Enumerator<T> GetEnumerator() { }

		private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	}

	[NativeDisableUnsafePtrRestriction]
	public T* Ptr; //Field offset: 0x0
	public int m_length; //Field offset: 0x0
	public int m_capacity; //Field offset: 0x0
	public AllocatorHandle Allocator; //Field offset: 0x0
	private readonly int padding; //Field offset: 0x0

	public override int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 4
		 set { } //Length: 107
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 8
	}

	public override bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 54
	}

	public override T Item
	{
		 get { } //Length: 94
		 set { } //Length: 91
	}

	public override int Length
	{
		[IsReadOnly]
		 get { } //Length: 4
		 set { } //Length: 125
	}

	public UnsafeList`1(T* ptr, int length) { }

	public UnsafeList`1(int initialCapacity, AllocatorHandle allocator, NativeArrayOptions options = 0) { }

	public void Add(in T value) { }

	public void AddNoResize(T value) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public void AddRange(UnsafeList<T> list) { }

	public void AddRange(Void* ptr, int count) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public void AddRangeNoResize(UnsafeList<T> list) { }

	public void AddRangeNoResize(Void* ptr, int count) { }

	public void AddReplicate(in T value, int count) { }

	public ParallelReader<T> AsParallelReader() { }

	public ParallelWriter<T> AsParallelWriter() { }

	public ReadOnly<T> AsReadOnly() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckBeginEnd(int begin, int end) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckBeginEndNoLength(int begin, int end) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckIndexCount(int index, int count) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckNoResizeHasEnoughCapacity(int length) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckNoResizeHasEnoughCapacity(int length, int index) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	internal static void CheckNull(Void* listData) { }

	public override void Clear() { }

	public void CopyFrom(in UnsafeList<T>& other) { }

	public void CopyFrom(in NativeArray<T>& other) { }

	public static UnsafeList<T>* Create(int initialCapacity, AllocatorHandle allocator, NativeArrayOptions options = 0) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
	internal static UnsafeList<T>* Create(int initialCapacity, ref U allocator, NativeArrayOptions options) { }

	public static void Destroy(UnsafeList<T>* listData) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
	internal static void Destroy(UnsafeList<T>* listData, ref U allocator) { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
	internal void Dispose(ref U allocator) { }

	public override void Dispose() { }

	public override T ElementAt(int index) { }

	[IsReadOnly]
	public override int get_Capacity() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public override bool get_IsEmpty() { }

	public override T get_Item(int index) { }

	[IsReadOnly]
	public override int get_Length() { }

	public Enumerator<T> GetEnumerator() { }

	public void InsertRange(int index, int count) { }

	public void InsertRangeWithBeginEnd(int begin, int end) { }

	public void RemoveAt(int index) { }

	public void RemoveAtSwapBack(int index) { }

	public void RemoveRange(int index, int count) { }

	public void RemoveRangeSwapBack(int index, int count) { }

	public void Resize(int length, NativeArrayOptions options = 0) { }

	private void ResizeExact(ref U allocator, int newCapacity) { }

	private void ResizeExact(int capacity) { }

	public override void set_Capacity(int value) { }

	public override void set_Item(int index, T value) { }

	public override void set_Length(int value) { }

	public void SetCapacity(int capacity) { }

	private void SetCapacity(ref U allocator, int capacity) { }

	private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public void TrimExcess() { }

}

