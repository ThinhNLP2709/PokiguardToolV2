namespace Unity.Collections.LowLevel.Unsafe;

[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
internal struct HashMapHelper
{
	public struct Enumerator
	{
		[NativeDisableUnsafePtrRestriction]
		internal HashMapHelper<TKey>* m_Data; //Field offset: 0x0
		internal int m_Index; //Field offset: 0x0
		internal int m_BucketIndex; //Field offset: 0x0
		internal int m_NextIndex; //Field offset: 0x0

		internal Enumerator(HashMapHelper<TKey>* data) { }

		internal KVPair<TKey, TValue> GetCurrent() { }

		internal TKey GetCurrentKey() { }

		internal bool MoveNext() { }

		internal void Reset() { }

	}

	internal const int kMinimumCapacity = 256; //Field offset: 0x0
	[NativeDisableUnsafePtrRestriction]
	internal Byte* Ptr; //Field offset: 0x0
	[NativeDisableUnsafePtrRestriction]
	internal TKey* Keys; //Field offset: 0x0
	[NativeDisableUnsafePtrRestriction]
	internal Int32* Next; //Field offset: 0x0
	[NativeDisableUnsafePtrRestriction]
	internal Int32* Buckets; //Field offset: 0x0
	internal int Count; //Field offset: 0x0
	internal int Capacity; //Field offset: 0x0
	internal int Log2MinGrowth; //Field offset: 0x0
	internal int BucketCapacity; //Field offset: 0x0
	internal int AllocatedIndex; //Field offset: 0x0
	internal int FirstFreeIdx; //Field offset: 0x0
	internal int SizeOfTValue; //Field offset: 0x0
	internal AllocatorHandle Allocator; //Field offset: 0x0

	internal bool IsCreated
	{
		[IsReadOnly]
		internal get { } //Length: 8
	}

	internal bool IsEmpty
	{
		[IsReadOnly]
		internal get { } //Length: 54
	}

	internal static HashMapHelper<TKey>* Alloc(int capacity, int sizeOfValueT, int minGrowth, AllocatorHandle allocator) { }

	internal int CalcCapacityCeilPow2(int capacity) { }

	internal static int CalculateDataSize(int capacity, int bucketCapacity, int sizeOfTValue, out int outKeyOffset, out int outNextOffset, out int outBucketOffset) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	[Conditional("UNITY_DOTS_DEBUG")]
	private void CheckIndexOutOfBounds(int idx) { }

	internal void Clear() { }

	internal void Dispose() { }

	internal int Find(TKey key) { }

	internal static void Free(HashMapHelper<TKey>* data) { }

	[IsReadOnly]
	internal bool get_IsCreated() { }

	[IsReadOnly]
	internal bool get_IsEmpty() { }

	private int GetBucket(in TKey key) { }

	internal static int GetBucketSize(int capacity) { }

	[IsReadOnly]
	internal int GetCount() { }

	internal NativeArray<TKey> GetKeyArray(AllocatorHandle allocator) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays(AllocatorHandle allocator) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal NativeArray<TValue> GetValueArray(AllocatorHandle allocator) { }

	internal void Init(int capacity, int sizeOfValueT, int minGrowth, AllocatorHandle allocator) { }

	internal bool MoveNext(ref int bucketIndex, ref int nextIndex, out int index) { }

	internal bool MoveNextSearch(ref int bucketIndex, ref int nextIndex, out int index) { }

	internal void Resize(int newCapacity) { }

	internal void ResizeExact(int newCapacity, int newBucketCapacity) { }

	internal void TrimExcess() { }

	internal int TryAdd(in TKey key) { }

	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal bool TryGetValue(TKey key, out TValue item) { }

	internal int TryRemove(TKey key) { }

}

