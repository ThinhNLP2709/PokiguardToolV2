namespace Unity.Collections.LowLevel.Unsafe;

[DebuggerTypeProxy(typeof(UnsafeParallelMultiHashMapDebuggerTypeProxy`2))]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
public struct UnsafeParallelMultiHashMap : INativeDisposable, IDisposable, IEnumerable<KeyValue`2<TKey, TValue>>, IEnumerable
{
	internal struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
	{
		internal UnsafeParallelMultiHashMap<TKey, TValue> hashmap; //Field offset: 0x0
		internal TKey key; //Field offset: 0x0
		internal bool isFirst; //Field offset: 0x0
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

	internal struct KeyValueEnumerator : IEnumerator<KeyValue`2<TKey, TValue>>, IEnumerator, IDisposable
	{
		internal UnsafeParallelHashMapDataEnumerator m_Enumerator; //Field offset: 0x0

		public override KeyValue<TKey, TValue> Current
		{
			 get { } //Length: 79
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 153
		}

		public override void Dispose() { }

		public override KeyValue<TKey, TValue> get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	internal struct ParallelWriter
	{
		[NativeDisableUnsafePtrRestriction]
		internal UnsafeParallelHashMapData* m_Buffer; //Field offset: 0x0
		[NativeSetThreadIndex]
		internal int m_ThreadIndex; //Field offset: 0x0

		public int Capacity
		{
			[IsReadOnly]
			 get { } //Length: 25
		}

		public void Add(TKey key, TValue item) { }

		[IsReadOnly]
		public int get_Capacity() { }

	}

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
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

		[IsReadOnly]
		public bool TryGetFirstValue(TKey key, out TValue item, out NativeParallelMultiHashMapIterator<TKey>& it) { }

		[IsReadOnly]
		public bool TryGetNextValue(out TValue item, ref NativeParallelMultiHashMapIterator<TKey>& it) { }

	}

	[NativeDisableUnsafePtrRestriction]
	internal UnsafeParallelHashMapData* m_Buffer; //Field offset: 0x0
	internal AllocatorHandle m_AllocatorLabel; //Field offset: 0x0

	public int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 25
		 set { } //Length: 132
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 8
	}

	public bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 56
	}

	public UnsafeParallelMultiHashMap`2(int capacity, AllocatorHandle allocator) { }

	public void Add(TKey key, TValue item) { }

	public ParallelWriter<TKey, TValue> AsParallelWriter() { }

	public ReadOnly<TKey, TValue> AsReadOnly() { }

	public void Clear() { }

	[IsReadOnly]
	public bool ContainsKey(TKey key) { }

	[IsReadOnly]
	public int Count() { }

	[IsReadOnly]
	public int CountValuesForKey(TKey key) { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	public override void Dispose() { }

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

	public Enumerator<TKey, TValue> GetValuesForKey(TKey key) { }

	public void Remove(NativeParallelMultiHashMapIterator<TKey> it) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public void Remove(TKey key, TValueEQ value) { }

	public int Remove(TKey key) { }

	public void set_Capacity(int value) { }

	public bool SetValue(TValue item, NativeParallelMultiHashMapIterator<TKey> it) { }

	private override IEnumerator<KeyValue`2<TKey, TValue>> System.Collections.Generic.IEnumerable<Unity.Collections.LowLevel.Unsafe.KeyValue<TKey,TValue>>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	[IsReadOnly]
	public bool TryGetFirstValue(TKey key, out TValue item, out NativeParallelMultiHashMapIterator<TKey>& it) { }

	[IsReadOnly]
	public bool TryGetNextValue(out TValue item, ref NativeParallelMultiHashMapIterator<TKey>& it) { }

}

