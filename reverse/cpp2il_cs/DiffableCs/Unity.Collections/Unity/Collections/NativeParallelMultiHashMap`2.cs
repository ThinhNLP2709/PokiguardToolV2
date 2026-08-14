namespace Unity.Collections;

[DebuggerTypeProxy(typeof(NativeParallelMultiHashMapDebuggerTypeProxy`2))]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
[NativeContainer]
public struct NativeParallelMultiHashMap : INativeDisposable, IDisposable, IEnumerable<KeyValue`2<TKey, TValue>>, IEnumerable
{
	internal struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
	{
		internal NativeParallelMultiHashMap<TKey, TValue> hashmap; //Field offset: 0x0
		internal TKey key; //Field offset: 0x0
		internal byte isFirst; //Field offset: 0x0
		private TValue value; //Field offset: 0x0
		private NativeParallelMultiHashMapIterator<TKey> iterator; //Field offset: 0x0

		public override TValue Current
		{
			 get { } //Length: 4
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 94
		}

		public override void Dispose() { }

		public override TValue get_Current() { }

		public Enumerator<TKey, TValue> GetEnumerator() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct KeyValueEnumerator : IEnumerator<KeyValue`2<TKey, TValue>>, IEnumerator, IDisposable
	{
		internal UnsafeParallelHashMapDataEnumerator m_Enumerator; //Field offset: 0x0

		public override KeyValue<TKey, TValue> Current
		{
			[IsReadOnly]
			 get { } //Length: 82
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 168
		}

		public override void Dispose() { }

		[IsReadOnly]
		public override KeyValue<TKey, TValue> get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[NativeContainer]
	[NativeContainerIsAtomicWriteOnly]
	internal struct ParallelWriter
	{
		internal ParallelWriter<TKey, TValue> m_Writer; //Field offset: 0x0

		public int Capacity
		{
			[IsReadOnly]
			 get { } //Length: 49
		}

		public int m_ThreadIndex
		{
			 get { } //Length: 4
		}

		public void Add(TKey key, TValue item) { }

		[IsReadOnly]
		public int get_Capacity() { }

		public int get_m_ThreadIndex() { }

	}

	[DebuggerDisplay("Count = {m_HashMapData.Count()}, Capacity = {m_HashMapData.Capacity}, IsCreated = {m_HashMapData.IsCreated}, IsEmpty = {IsEmpty}")]
	[DebuggerTypeProxy(typeof(NativeParallelHashMapDebuggerTypeProxy`2))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct ReadOnly : IEnumerable<KeyValue`2<TKey, TValue>>, IEnumerable
	{
		internal UnsafeParallelMultiHashMap<TKey, TValue> m_MultiHashMapData; //Field offset: 0x0

		public int Capacity
		{
			[IsReadOnly]
			 get { } //Length: 49
		}

		public bool IsCreated
		{
			[IsReadOnly]
			 get { } //Length: 40
		}

		public bool IsEmpty
		{
			[IsReadOnly]
			 get { } //Length: 161
		}

		internal ReadOnly(UnsafeParallelMultiHashMap<TKey, TValue> container) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckRead() { }

		[IsReadOnly]
		public bool ContainsKey(TKey key) { }

		[IsReadOnly]
		public int Count() { }

		[IsReadOnly]
		public int get_Capacity() { }

		[IsReadOnly]
		public bool get_IsCreated() { }

		[IsReadOnly]
		public bool get_IsEmpty() { }

		public KeyValueEnumerator<TKey, TValue> GetEnumerator() { }

		[IsReadOnly]
		public NativeArray<TKey> GetKeyArray(AllocatorHandle allocator) { }

		[IsReadOnly]
		public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorHandle allocator) { }

		[IsReadOnly]
		public NativeArray<TValue> GetValueArray(AllocatorHandle allocator) { }

		private override IEnumerator<KeyValue`2<TKey, TValue>> System.Collections.Generic.IEnumerable<Unity.Collections.LowLevel.Unsafe.KeyValue<TKey,TValue>>.GetEnumerator() { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		[IsReadOnly]
		private void ThrowKeyNotPresent(TKey key) { }

		[IsReadOnly]
		public bool TryGetFirstValue(TKey key, out TValue item, out NativeParallelMultiHashMapIterator<TKey>& it) { }

		[IsReadOnly]
		public bool TryGetNextValue(out TValue item, ref NativeParallelMultiHashMapIterator<TKey>& it) { }

	}

	internal UnsafeParallelMultiHashMap<TKey, TValue> m_MultiHashMapData; //Field offset: 0x0

	public int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 49
		 set { } //Length: 67
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 40
	}

	public bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 88
	}

	public NativeParallelMultiHashMap`2(int capacity, AllocatorHandle allocator) { }

	public void Add(TKey key, TValue item) { }

	public ParallelWriter<TKey, TValue> AsParallelWriter() { }

	public ReadOnly<TKey, TValue> AsReadOnly() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[IsReadOnly]
	private void CheckRead() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckWrite() { }

	public void Clear() { }

	public bool ContainsKey(TKey key) { }

	[IsReadOnly]
	public int Count() { }

	public int CountValuesForKey(TKey key) { }

	public override void Dispose() { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	[IsReadOnly]
	public int get_Capacity() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public bool get_IsEmpty() { }

	public KeyValueEnumerator<TKey, TValue> GetEnumerator() { }

	public NativeArray<TKey> GetKeyArray(AllocatorHandle allocator) { }

	public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorHandle allocator) { }

	public NativeArray<TValue> GetValueArray(AllocatorHandle allocator) { }

	public Enumerator<TKey, TValue> GetValuesForKey(TKey key) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(AllocatorHandle)})]
	internal void Initialize(int capacity, ref U allocator) { }

	public void Remove(NativeParallelMultiHashMapIterator<TKey> it) { }

	public int Remove(TKey key) { }

	public void set_Capacity(int value) { }

	public bool SetValue(TValue item, NativeParallelMultiHashMapIterator<TKey> it) { }

	private override IEnumerator<KeyValue`2<TKey, TValue>> System.Collections.Generic.IEnumerable<Unity.Collections.LowLevel.Unsafe.KeyValue<TKey,TValue>>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	public bool TryGetFirstValue(TKey key, out TValue item, out NativeParallelMultiHashMapIterator<TKey>& it) { }

	public bool TryGetNextValue(out TValue item, ref NativeParallelMultiHashMapIterator<TKey>& it) { }

}

