namespace Unity.Collections.LowLevel.Unsafe;

[DebuggerTypeProxy(typeof(UnsafeHashMapDebuggerTypeProxy`2))]
[DefaultMember("Item")]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
public struct UnsafeHashMap : INativeDisposable, IDisposable, IEnumerable<KVPair`2<TKey, TValue>>, IEnumerable
{
	internal struct Enumerator : IEnumerator<KVPair`2<TKey, TValue>>, IEnumerator, IDisposable
	{
		internal Enumerator<TKey> m_Enumerator; //Field offset: 0x0

		public override KVPair<TKey, TValue> Current
		{
			 get { } //Length: 79
		}

		private override object System.Collections.IEnumerator.Current
		{
			private get { } //Length: 153
		}

		public override void Dispose() { }

		public override KVPair<TKey, TValue> get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

		private override object System.Collections.IEnumerator.get_Current() { }

	}

	[DefaultMember("Item")]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	internal struct ReadOnly : IEnumerable<KVPair`2<TKey, TValue>>, IEnumerable
	{
		[NativeDisableUnsafePtrRestriction]
		internal HashMapHelper<TKey> m_Data; //Field offset: 0x0

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
			 get { } //Length: 40
		}

		public bool IsEmpty
		{
			[IsReadOnly]
			 get { } //Length: 86
		}

		public TValue Item
		{
			[IsReadOnly]
			 get { } //Length: 110
		}

		internal ReadOnly(ref HashMapHelper<TKey>& data) { }

		[IsReadOnly]
		public bool ContainsKey(TKey key) { }

		[IsReadOnly]
		public int get_Capacity() { }

		[IsReadOnly]
		public int get_Count() { }

		[IsReadOnly]
		public bool get_IsCreated() { }

		[IsReadOnly]
		public bool get_IsEmpty() { }

		[IsReadOnly]
		public TValue get_Item(TKey key) { }

		[IsReadOnly]
		public Enumerator<TKey, TValue> GetEnumerator() { }

		[IsReadOnly]
		public NativeArray<TKey> GetKeyArray(AllocatorHandle allocator) { }

		[IsReadOnly]
		public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorHandle allocator) { }

		[IsReadOnly]
		public NativeArray<TValue> GetValueArray(AllocatorHandle allocator) { }

		private override IEnumerator<KVPair`2<TKey, TValue>> System.Collections.Generic.IEnumerable<Unity.Collections.KVPair<TKey,TValue>>.GetEnumerator() { }

		private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[IsReadOnly]
		public bool TryGetValue(TKey key, out TValue item) { }

	}

	[NativeDisableUnsafePtrRestriction]
	internal HashMapHelper<TKey> m_Data; //Field offset: 0x0

	public int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 4
		 set { } //Length: 67
	}

	public int Count
	{
		[IsReadOnly]
		 get { } //Length: 4
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 40
	}

	public bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 86
	}

	public TValue Item
	{
		 get { } //Length: 88
		 set { } //Length: 194
	}

	public UnsafeHashMap`2(int initialCapacity, AllocatorHandle allocator) { }

	public void Add(TKey key, TValue item) { }

	public ReadOnly<TKey, TValue> AsReadOnly() { }

	public void Clear() { }

	public bool ContainsKey(TKey key) { }

	public override JobHandle Dispose(JobHandle inputDeps) { }

	public override void Dispose() { }

	[IsReadOnly]
	public int get_Capacity() { }

	[IsReadOnly]
	public int get_Count() { }

	[IsReadOnly]
	public bool get_IsCreated() { }

	[IsReadOnly]
	public bool get_IsEmpty() { }

	public TValue get_Item(TKey key) { }

	public Enumerator<TKey, TValue> GetEnumerator() { }

	public NativeArray<TKey> GetKeyArray(AllocatorHandle allocator) { }

	public NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorHandle allocator) { }

	public NativeArray<TValue> GetValueArray(AllocatorHandle allocator) { }

	public bool Remove(TKey key) { }

	public void set_Capacity(int value) { }

	public void set_Item(TKey key, TValue value) { }

	private override IEnumerator<KVPair`2<TKey, TValue>> System.Collections.Generic.IEnumerable<Unity.Collections.KVPair<TKey,TValue>>.GetEnumerator() { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void ThrowKeyAlreadyAdded(TKey key) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void ThrowKeyNotPresent(TKey key) { }

	public void TrimExcess() { }

	public bool TryAdd(TKey key, TValue item) { }

	public bool TryGetValue(TKey key, out TValue item) { }

}

