namespace Unity.Collections;

[DebuggerTypeProxy(typeof(NativeHashMapDebuggerTypeProxy`2))]
[DefaultMember("Item")]
[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
[NativeContainer]
public struct NativeHashMap : INativeDisposable, IDisposable, IEnumerable<KVPair`2<TKey, TValue>>, IEnumerable
{
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct Enumerator : IEnumerator<KVPair`2<TKey, TValue>>, IEnumerator, IDisposable
	{
		[NativeDisableUnsafePtrRestriction]
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
	[NativeContainer]
	[NativeContainerIsReadOnly]
	internal struct ReadOnly : IEnumerable<KVPair`2<TKey, TValue>>, IEnumerable
	{
		[NativeDisableUnsafePtrRestriction]
		internal HashMapHelper<TKey>* m_Data; //Field offset: 0x0

		public int Capacity
		{
			[IsReadOnly]
			 get { } //Length: 25
		}

		public int Count
		{
			[IsReadOnly]
			 get { } //Length: 25
		}

		public bool IsCreated
		{
			[IsReadOnly]
			 get { } //Length: 60
		}

		public bool IsEmpty
		{
			[IsReadOnly]
			 get { } //Length: 181
		}

		public TValue Item
		{
			[IsReadOnly]
			 get { } //Length: 85
		}

		internal ReadOnly(ref NativeHashMap<TKey, TValue>& data) { }

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[IsReadOnly]
		private void CheckRead() { }

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

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		[IsReadOnly]
		private void ThrowKeyNotPresent(TKey key) { }

		[IsReadOnly]
		public bool TryGetValue(TKey key, out TValue item) { }

	}

	[NativeDisableUnsafePtrRestriction]
	internal HashMapHelper<TKey>* m_Data; //Field offset: 0x0

	public int Capacity
	{
		[IsReadOnly]
		 get { } //Length: 25
		 set { } //Length: 67
	}

	public int Count
	{
		[IsReadOnly]
		 get { } //Length: 25
	}

	public bool IsCreated
	{
		[IsReadOnly]
		 get { } //Length: 60
	}

	public bool IsEmpty
	{
		[IsReadOnly]
		 get { } //Length: 181
	}

	public TValue Item
	{
		 get { } //Length: 88
		 set { } //Length: 210
	}

	public NativeHashMap`2(int initialCapacity, AllocatorHandle allocator) { }

	public void Add(TKey key, TValue item) { }

	public ReadOnly<TKey, TValue> AsReadOnly() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[IsReadOnly]
	private void CheckRead() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private void CheckWrite() { }

	public void Clear() { }

	public bool ContainsKey(TKey key) { }

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

