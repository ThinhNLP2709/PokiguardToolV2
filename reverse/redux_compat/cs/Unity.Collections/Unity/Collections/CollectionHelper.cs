/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility]
	public static class CollectionHelper // TypeDefIndex: 11479
	{
		// Fields
		public const int CacheLineSize = 64; // Metadata: 0x006A1BDD
	
		// Nested types
		internal struct LongDoubleUnion // TypeDefIndex: 11480
		{
			// Fields
			internal long longValue; // 0x00
			internal double doubleValue; // 0x00
		}
	
		[BurstCompile]
		public struct DummyJob : IJob // TypeDefIndex: 11481
		{
			// Methods
			public void Execute(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Methods
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckAllocator(AllocatorManager.AllocatorHandle allocator); // 0x0000000181C8C740-0x0000000181C8C7F0
		public static int Log2Floor(int value); // 0x0000000181C8CC40-0x0000000181C8CC90
		public static int Log2Ceil(int value); // 0x0000000181C8CC00-0x0000000181C8CC40
		public static int Align(int size, int alignmentPowerOfTwo); // 0x0000000181C8C6E0-0x0000000181C8C700
		public static long Align(long size, int alignmentPowerOfTwo); // 0x0000000181C8C720-0x0000000181C8C740
		public static ulong Align(ulong size, ulong alignmentPowerOfTwo); // 0x0000000181C8C700-0x0000000181C8C720
		internal static unsafe void* AlignPointer(void* ptr, int alignmentPowerOfTwo); // 0x0000000181C8C6C0-0x0000000181C8C6E0
		public static unsafe bool IsAligned(void* p, int alignmentPowerOfTwo); // 0x0000000181C8CBE0-0x0000000181C8CBF0
		public static bool IsAligned(ulong offset, int alignmentPowerOfTwo); // 0x0000000181C8CBE0-0x0000000181C8CBF0
		public static bool IsPowerOfTwo(int value); // 0x0000000181C8CBF0-0x0000000181C8CC00
		public static unsafe uint Hash(void* ptr, int bytes); // 0x0000000181C8CBB0-0x0000000181C8CBE0
		[ExcludeFromBurstCompatTesting("Used only for debugging, and uses managed strings")]
		internal static void WriteLayout(Type type); // 0x0000000181C8CCB0-0x0000000181C8CEF0
		internal static bool ShouldDeallocate(AllocatorManager.AllocatorHandle allocator); // 0x0000000181C8CC90-0x0000000181C8CCB0
		internal static int AssumePositive(int value); // 0x0000000180815D70-0x0000000180815D80
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		[GenerateTestsForBurstCompatibility(RequiredUnityDefine = "ENABLE_UNITY_COLLECTIONS_CHECKS", GenericTypeArguments = new Type[1] {typeof(NativeArray<int>) })]
		internal static void CheckIsUnmanaged<T>();
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckIntPositivePowerOfTwo(int value); // 0x0000000181C8CA70-0x0000000181C8CB10
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckUlongPositivePowerOfTwo(ulong value); // 0x0000000181C8CB10-0x0000000181C8CBB0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckIndexInRange(int index, int length); // 0x0000000181C8C9C0-0x0000000181C8CA70
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckCapacityInRange(int capacity, int maxCapacity, int length); // 0x0000000181C8C7F0-0x0000000181C8C9C0
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		internal static void CheckCapacityInRange(int capacity, int length); // 0x00000001802E76C0-0x00000001802E76D0
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(AllocatorManager.AllocatorHandle) })]
		public static NativeArray<T> CreateNativeArray<T, U>(int length, ref ref U allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1BDA */)
			where T : struct
			where U : struct, AllocatorManager.IAllocator;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static NativeArray<T> CreateNativeArray<T>(int length, AllocatorManager.AllocatorHandle allocator, NativeArrayOptions options = NativeArrayOptions.ClearMemory /* Metadata: 0x006A1BDB */)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static NativeArray<T> CreateNativeArray<T>(NativeArray<T> array, AllocatorManager.AllocatorHandle allocator)
			where T : struct;
		[ExcludeFromBurstCompatTesting("Managed array")]
		public static NativeArray<T> CreateNativeArray<T>(T[] array, AllocatorManager.AllocatorHandle allocator)
			where T : struct;
		[ExcludeFromBurstCompatTesting("Managed array")]
		public static NativeArray<T> CreateNativeArray<T, U>(T[] array, ref ref U allocator)
			where T : struct
			where U : struct, AllocatorManager.IAllocator;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void DisposeNativeArray<T>(NativeArray<T> nativeArray, AllocatorManager.AllocatorHandle allocator)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static void Dispose<T>(NativeArray<T> nativeArray)
			where T : struct;
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckConvertArguments<T>(int length)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static unsafe NativeArray<T> ConvertExistingDataToNativeArray<T>(void* dataPointer, int length, AllocatorManager.AllocatorHandle allocator, bool setTempMemoryHandle = false /* Metadata: 0x006A1BDC */)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[1] {typeof(int) })]
		public static NativeArray<T> ConvertExistingNativeListToNativeArray<T>(ref NativeList<T> nativeList, int length, AllocatorManager.AllocatorHandle allocator)
			where T : struct;
		[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[3] {typeof(int), typeof(int), typeof(AllocatorManager.AllocatorHandle) })]
		public static NativeParallelMultiHashMap<TKey, TValue> CreateNativeParallelMultiHashMap<TKey, TValue, U>(int length, ref ref U allocator)
			where TKey : struct, IEquatable<TKey>
			where TValue : struct
			where U : struct, AllocatorManager.IAllocator;
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		[GenerateTestsForBurstCompatibility(RequiredUnityDefine = "ENABLE_UNITY_COLLECTIONS_CHECKS", GenericTypeArguments = new Type[1] {typeof(DummyJob) })]
		public static void CheckReflectionDataCorrect<T>(IntPtr reflectionData);
		[BurstDiscard]
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		[Conditional("UNITY_DOTS_DEBUG")]
		private static void CheckReflectionDataCorrectInternal<T>(IntPtr reflectionData, ref bool burstCompiled);
	}
}
