/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
	internal struct HashMapHelper<TKey> // TypeDefIndex: 11687
		where TKey : struct, IEquatable<TKey>
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal unsafe byte* Ptr;
		[NativeDisableUnsafePtrRestriction]
		internal unsafe TKey* Keys;
		[NativeDisableUnsafePtrRestriction]
		internal unsafe int* Next;
		[NativeDisableUnsafePtrRestriction]
		internal unsafe int* Buckets;
		internal int Count;
		internal int Capacity;
		internal int Log2MinGrowth;
		internal int BucketCapacity;
		internal int AllocatedIndex;
		internal int FirstFreeIdx;
		internal int SizeOfTValue;
		internal AllocatorManager.AllocatorHandle Allocator;
		internal const int kMinCapacity = 256; // Metadata: 0x006A1D1D
		internal const int kMaxCapacity = 536870912; // Metadata: 0x006A1D1F
	
		// Properties
		internal bool IsCreated { [IsReadOnly] get; }
		internal bool IsEmpty { [IsReadOnly] get; }
	
		// Nested types
		internal struct Enumerator // TypeDefIndex: 11688
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal unsafe HashMapHelper<TKey>* m_Data;
			internal int m_Index;
			internal int m_BucketIndex;
			internal int m_NextIndex;
	
			// Constructors
			internal unsafe Enumerator(HashMapHelper<TKey>* data);
	
			// Methods
			internal bool MoveNext();
			internal void Reset();
			internal KVPair<TKey, TValue> GetCurrent<TValue>()
				where TValue : struct;
			internal TKey GetCurrentKey();
		}
	
		// Methods
		internal int CalcCapacityCeilPow2(int capacity);
		internal static int GetBucketSize(int capacity);
		internal void Clear();
		internal void Init(int capacity, int sizeOfValueT, int minGrowth, AllocatorManager.AllocatorHandle allocator);
		internal void Dispose();
		internal static unsafe HashMapHelper<TKey>* Alloc(int capacity, int sizeOfValueT, int minGrowth, AllocatorManager.AllocatorHandle allocator);
		internal static unsafe void Free(HashMapHelper<TKey>* data);
		internal void Resize(int newCapacity);
		internal void ResizeExact(int newCapacity, int newBucketCapacity);
		internal void TrimExcess();
		internal static long CalculateDataSize(int capacity, int bucketCapacity, int sizeOfTValue, out long outKeyOffset, out long outNextOffset, out long outBucketOffset);
		[IsReadOnly]
		internal int GetCount();
		private int GetBucket([IsReadOnly] in ref TKey key);
		internal int TryAdd([IsReadOnly] in ref TKey key);
		internal int Find(TKey key);
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		internal bool TryGetValue<TValue>(TKey key, out ref TValue item)
			where TValue : struct;
		internal int TryRemove(TKey key);
		internal bool MoveNextSearch(ref int bucketIndex, ref int nextIndex, out int index);
		internal bool MoveNext(ref int bucketIndex, ref int nextIndex, out int index);
		internal NativeArray<TKey> GetKeyArray(AllocatorManager.AllocatorHandle allocator);
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		internal NativeArray<TValue> GetValueArray<TValue>(AllocatorManager.AllocatorHandle allocator)
			where TValue : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		internal NativeKeyValueArrays<TKey, TValue> GetKeyValueArrays<TValue>(AllocatorManager.AllocatorHandle allocator)
			where TValue : struct;
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private void CheckIndexOutOfBounds(int idx);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckCapacity(int capacity);
	}
}
