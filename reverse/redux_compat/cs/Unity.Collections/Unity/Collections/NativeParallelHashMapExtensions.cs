/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	public static class NativeParallelHashMapExtensions // TypeDefIndex: 11584
	{
		// Extension methods
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static int Unique<T>(this NativeArray<T> array)
			where T : struct, IEquatable<T>;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static ValueTuple<NativeArray<TKey>, int> GetUniqueKeyArray<TKey, TValue>(this UnsafeParallelMultiHashMap<TKey, TValue> container, AllocatorManager.AllocatorHandle allocator)
			where TKey : struct, IEquatable<TKey>, IComparable<TKey>
			where TValue : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static ValueTuple<NativeArray<TKey>, int> GetUniqueKeyArray<TKey, TValue>(this NativeParallelMultiHashMap<TKey, TValue> container, AllocatorManager.AllocatorHandle allocator)
			where TKey : struct, IEquatable<TKey>, IComparable<TKey>
			where TValue : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static UnsafeParallelHashMapBucketData GetUnsafeBucketData<TKey, TValue>(this NativeParallelHashMap<TKey, TValue> container)
			where TKey : struct, IEquatable<TKey>
			where TValue : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static UnsafeParallelHashMapBucketData GetUnsafeBucketData<TKey, TValue>(this NativeParallelMultiHashMap<TKey, TValue> container)
			where TKey : struct, IEquatable<TKey>
			where TValue : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(int) })]
		public static void Remove<TKey, TValue>(this NativeParallelMultiHashMap<TKey, TValue> container, TKey key, TValue value)
			where TKey : struct, IEquatable<TKey>
			where TValue : struct, IEquatable<TValue>;
	}
}
