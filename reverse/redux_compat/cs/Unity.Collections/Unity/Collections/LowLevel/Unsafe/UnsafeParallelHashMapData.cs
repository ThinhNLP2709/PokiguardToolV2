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
	[GenerateTestsForBurstCompatibility]
	internal struct UnsafeParallelHashMapData // TypeDefIndex: 11713
	{
		// Fields
		internal unsafe byte* values; // 0x00
		internal unsafe byte* keys; // 0x08
		internal unsafe byte* next; // 0x10
		internal unsafe byte* buckets; // 0x18
		internal int keyCapacity; // 0x20
		internal int bucketCapacityMask; // 0x24
		internal int allocatedIndexLength; // 0x28
		internal const int kMaxCapacity = 1073741823; // Metadata: 0x006A1D35
		private const int kFirstFreeTLSOffset = 64; // Metadata: 0x006A1D3A
		internal const int IntsPerCacheLine = 16; // Metadata: 0x006A1D3C
	
		// Properties
		internal unsafe int* firstFreeTLS { get; } // 0x0000000181CA89C0-0x0000000181CA89D0 
	
		// Methods
		internal static long GetBucketSize(int capacity); // 0x0000000181CAC020-0x0000000181CAC030
		internal static int GrowCapacity(int capacity); // 0x0000000181CAC0E0-0x0000000181CAC0F0
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		internal static unsafe void AllocateHashMap<TKey, TValue>(int length, long bucketLength, AllocatorManager.AllocatorHandle label, out UnsafeParallelHashMapData* outBuf)
			where TKey : struct
			where TValue : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		internal static unsafe void ReallocateHashMap<TKey, TValue>(UnsafeParallelHashMapData* data, int newCapacity, long newBucketCapacity, AllocatorManager.AllocatorHandle label)
			where TKey : struct
			where TValue : struct;
		internal static unsafe void DeallocateHashMap(UnsafeParallelHashMapData* data, AllocatorManager.AllocatorHandle allocator); // 0x0000000181CABFB0-0x0000000181CABFF0
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		internal static long CalculateDataSize<TKey, TValue>(int length, long bucketLength, out long keyOffset, out long nextOffset, out long bucketOffset)
			where TKey : struct
			where TValue : struct;
		internal static unsafe bool IsEmpty(UnsafeParallelHashMapData* data); // 0x0000000181CAC0F0-0x0000000181CAC140
		internal static unsafe int GetCount(UnsafeParallelHashMapData* data); // 0x0000000181CAC030-0x0000000181CAC0E0
		internal static unsafe bool MoveNextSearch(UnsafeParallelHashMapData* data, ref int bucketIndex, ref int nextIndex, out int index); // 0x0000000181CAC140-0x0000000181CAC1E0
		internal static unsafe bool MoveNext(UnsafeParallelHashMapData* data, ref int bucketIndex, ref int nextIndex, out int index); // 0x0000000181CAC1E0-0x0000000181CAC2A0
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		internal static unsafe void GetKeyArray<TKey>(UnsafeParallelHashMapData* data, NativeArray<TKey> result)
			where TKey : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		internal static unsafe void GetValueArray<TValue>(UnsafeParallelHashMapData* data, NativeArray<TValue> result)
			where TValue : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		internal static unsafe void GetKeyValueArrays<TKey, TValue>(UnsafeParallelHashMapData* data, NativeKeyValueArrays<TKey, TValue> result)
			where TKey : struct
			where TValue : struct;
		internal UnsafeParallelHashMapBucketData GetBucketData(); // 0x0000000181CABFF0-0x0000000181CAC020
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static unsafe void CheckHashMapReallocateDoesNotShrink(UnsafeParallelHashMapData* data, int newCapacity); // 0x0000000181CABF40-0x0000000181CABFB0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckCapacity(int capacity); // 0x0000000181CABE80-0x0000000181CABF40
	}
}
