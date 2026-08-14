namespace Unity.Collections;

[DebuggerTypeProxy(typeof(NativeParallelHashSetDebuggerTypeProxy`1))]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
public struct NativeParallelHashSet : INativeDisposable, IDisposable, IEnumerable<T>, IEnumerable
{
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		internal UnsafeParallelHashMapDataEnumerator m_Enumerator; //Field offset: 0x0

		public override T Current
		{
			 get { } //Length: 235
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 253
		}

		public override void Dispose() { }

		public override T get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[NativeContainerIsAtomicWriteOnly]
	internal struct ParallelWriter
	{
		internal ParallelWriter<T, Boolean> m_Data; //Field offset: 0x0

		public int Capacity
		{
			[IsReadOnly]
			 get { } //Length: 112
		}

		public bool Add(T item) { }

		internal bool Add(T item, int threadIndexOverride) { }

		[IsReadOnly]
		public int get_Capacity() { }

	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct ReadOnly : IEnumerable<T>, IEnumerable
	{
		internal UnsafeParallelHashMap<T, Boolean> m_Data; //Field offset: 0x0

		public int Capacity
		{
			[IsReadOnly]
			 get { } //Length: 112
		}

		public bool IsCreated
		{
			[IsReadOnly]
			 get { } //Length: 112
		}

		public bool IsEmpty
		{
			[IsReadOnly]
			 get { } //Length: 206
		}

		internal ReadOnly(ref NativeParallelHashSet<T>& data) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckRead() { }

		[IsReadOnly]
		public bool Contains(T item) { }

		[IsReadOnly]
		public int Count() { }

		[IsReadOnly]
		public int get_Capacity() { }

		[IsReadOnly]
		public bool get_IsCreated() { }

		[IsReadOnly]
		public bool get_IsEmpty() { }

		[IsReadOnly]
		public Enumerator<T> GetEnumerator() { }

		private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[IsReadOnly]
		public NativeArray<T> ToNativeArray(AllocatorHandle allocator) { }

	}

	internal NativeParallelHashMap<T, Boolean> m_Data; //Field offset: 0x0

	public int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 112
		 set { } //Length: 126
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 112
	}

	public bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 112
	}

	public NativeParallelHashSet`1(int capacity, AllocatorHandle allocator) { }

	public bool Add(T item) { }

	public ParallelWriter<T> AsParallelWriter() { }

	public ReadOnly<T> AsReadOnly() { }

	public void Clear() { }

	public bool Contains(T item) { }

	public int Count() { }

	public override void Dispose() { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	[IsReadOnly]
	public int get_Capacity() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public bool get_IsEmpty() { }

	public Enumerator<T> GetEnumerator() { }

	public bool Remove(T item) { }

	public void set_Capacity(int value) { }

	private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public NativeArray<T> ToNativeArray(AllocatorHandle allocator) { }

}

