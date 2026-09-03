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
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
	internal struct UnsafeParallelHashMapBase<TKey, TValue> // TypeDefIndex: 11716
		where TKey : struct, IEquatable<TKey>
		where TValue : struct
	{
		// Fields
		private const int SentinelRefilling = -2; // Metadata: 0x006A1D3D
		private const int SentinelSwapInProgress = -3; // Metadata: 0x006A1D3E
	
		// Methods
		internal static unsafe void Clear(UnsafeParallelHashMapData* data);
		internal static unsafe int AllocEntry(UnsafeParallelHashMapData* data, int threadIndex);
		internal static unsafe void FreeEntry(UnsafeParallelHashMapData* data, int idx, int threadIndex);
		internal static unsafe bool TryAddAtomic(UnsafeParallelHashMapData* data, TKey key, TValue item, int threadIndex);
		internal static unsafe void AddAtomicMulti(UnsafeParallelHashMapData* data, TKey key, TValue item, int threadIndex);
		internal static unsafe bool TryAdd(UnsafeParallelHashMapData* data, TKey key, TValue item, bool isMultiHashMap, AllocatorManager.AllocatorHandle allocation);
		internal static unsafe int Remove(UnsafeParallelHashMapData* data, TKey key, bool isMultiHashMap);
		internal static unsafe void Remove(UnsafeParallelHashMapData* data, NativeParallelMultiHashMapIterator<TKey> it);
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		internal static unsafe void RemoveKeyValue<TValueEQ>(UnsafeParallelHashMapData* data, TKey key, TValueEQ value)
			where TValueEQ : struct, IEquatable<TValueEQ>;
		internal static unsafe bool TryGetFirstValueAtomic(UnsafeParallelHashMapData* data, TKey key, out ref TValue item, out NativeParallelMultiHashMapIterator<TKey> it);
		internal static unsafe bool TryGetNextValueAtomic(UnsafeParallelHashMapData* data, out ref TValue item, ref NativeParallelMultiHashMapIterator<TKey> it);
		internal static unsafe bool SetValue(UnsafeParallelHashMapData* data, ref NativeParallelMultiHashMapIterator<TKey> it, ref ref TValue item);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckOutOfCapacity(int idx, int keyCapacity);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static unsafe void CheckIndexOutOfBounds(UnsafeParallelHashMapData* data, int idx);
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void ThrowFull();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void ThrowInvalidIterator();
	}
}
