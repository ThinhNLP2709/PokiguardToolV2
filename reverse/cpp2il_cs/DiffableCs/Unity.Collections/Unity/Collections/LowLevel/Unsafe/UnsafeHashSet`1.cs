namespace Unity.Collections.LowLevel.Unsafe;

[DebuggerTypeProxy(typeof(UnsafeHashSetDebuggerTypeProxy`1))]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
public struct UnsafeHashSet : INativeDisposable, IDisposable, IEnumerable<T>, IEnumerable
{
	internal struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		internal Enumerator<T> m_Enumerator; //Field offset: 0x0

		public override T Current
		{
			 get { } //Length: 181
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
	internal struct ReadOnly : IEnumerable<T>, IEnumerable
	{
		internal HashMapHelper<T> m_Data; //Field offset: 0x0

		public int Capacity
		{
			[IsReadOnly]
			 get { } //Length: 4
		}

		public int Count
		{
			[IsReadOnly]
			 get { } //Length: 4
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

		internal ReadOnly(ref HashMapHelper<T>& data) { }

		[IsReadOnly]
		public bool Contains(T item) { }

		[IsReadOnly]
		public int get_Capacity() { }

		[IsReadOnly]
		public int get_Count() { }

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

	internal HashMapHelper<T> m_Data; //Field offset: 0x0

	public int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 4
		 set { } //Length: 126
	}

	public int Count
	{
		[IsReadOnly]
		 get { } //Length: 4
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

	public UnsafeHashSet`1(int initialCapacity, AllocatorHandle allocator) { }

	public bool Add(T item) { }

	public ReadOnly<T> AsReadOnly() { }

	public void Clear() { }

	public bool Contains(T item) { }

	public override void Dispose() { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	[IsReadOnly]
	public int get_Capacity() { }

	[IsReadOnly]
	public int get_Count() { }

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

	public void TrimExcess() { }

}

