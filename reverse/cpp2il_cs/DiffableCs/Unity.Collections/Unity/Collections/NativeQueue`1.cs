namespace Unity.Collections;

[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
[NativeContainer]
public struct NativeQueue : INativeDisposable, IDisposable
{
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		internal Enumerator<T> m_Enumerator; //Field offset: 0x0

		public override T Current
		{
			 get { } //Length: 55
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 128
		}

		public override void Dispose() { }

		public override T get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[NativeContainer]
	[NativeContainerIsAtomicWriteOnly]
	internal struct ParallelWriter
	{
		internal ParallelWriter<T> unsafeWriter; //Field offset: 0x0

		public void Enqueue(T value) { }

		internal void Enqueue(T value, int threadIndexOverride) { }

	}

	[DefaultMember("Item")]
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct ReadOnly : IEnumerable<T>, IEnumerable
	{
		private ReadOnly<T> m_ReadOnly; //Field offset: 0x0

		public int Count
		{
			[IsReadOnly]
			 get { } //Length: 104
		}

		public bool IsCreated
		{
			[IsReadOnly]
			 get { } //Length: 40
		}

		public T Item
		{
			[IsReadOnly]
			 get { } //Length: 213
		}

		internal ReadOnly(ref NativeQueue<T>& data) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckRead() { }

		[IsReadOnly]
		public int get_Count() { }

		[IsReadOnly]
		public bool get_IsCreated() { }

		[IsReadOnly]
		public T get_Item(int index) { }

		[IsReadOnly]
		public Enumerator<T> GetEnumerator() { }

		[IsReadOnly]
		public bool IsEmpty() { }

		private override IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	}

	[NativeDisableUnsafePtrRestriction]
	private UnsafeQueue<T>* m_Queue; //Field offset: 0x0

	public int Count
	{
		[IsReadOnly]
		 get { } //Length: 54
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 60
	}

	public NativeQueue`1(AllocatorHandle allocator) { }

	public ParallelWriter<T> AsParallelWriter() { }

	public ReadOnly<T> AsReadOnly() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[IsReadOnly]
	private void CheckRead() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckWrite() { }

	public void Clear() { }

	public T Dequeue() { }

	public override void Dispose() { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	public void Enqueue(T value) { }

	[IsReadOnly]
	public int get_Count() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public bool IsEmpty() { }

	public T Peek() { }

	public NativeArray<T> ToArray(AllocatorHandle allocator) { }

	public bool TryDequeue(out T item) { }

}

