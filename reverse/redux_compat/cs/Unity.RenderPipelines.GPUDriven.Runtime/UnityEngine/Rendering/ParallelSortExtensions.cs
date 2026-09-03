/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal static class ParallelSortExtensions // TypeDefIndex: 12999
	{
		// Fields
		internal const int kMinRadixSortArraySize = 2048; // Metadata: 0x006A769A
		private const int kMinRadixSortBatchSize = 256; // Metadata: 0x006A769C
	
		// Nested types
		internal enum ParallelSortValueType // TypeDefIndex: 13000
		{
			Int = 0,
			ULong = 1
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct RadixSortBucketCountJob<T> : IJobFor // TypeDefIndex: 13001
			where T : struct
		{
			// Fields
			[ReadOnly]
			public int radix;
			[ReadOnly]
			public int batchSize;
			[ReadOnly]
			public ParallelSortValueType valueType;
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			[ReadOnly]
			public NativeArray<T> array;
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			public NativeArray<int> buckets;
	
			// Methods
			public void Execute(int index);
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct RadixSortBatchPrefixSumJob<T> : IJobFor // TypeDefIndex: 13002
			where T : struct
		{
			// Fields
			[ReadOnly]
			public int radix;
			[ReadOnly]
			public int jobsCount;
			[ReadOnly]
			public int signBitRadixIndex;
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			[ReadOnly]
			public NativeArray<T> array;
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			public NativeArray<int> counter;
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			public NativeArray<int> indicesSum;
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			public NativeArray<int> buckets;
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			public NativeArray<int> indices;
	
			// Methods
			private static int AtomicIncrement(NativeArray<int> counter);
			private int JobIndexPrefixSum(int sum, int i);
			public void Execute(int index);
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct RadixSortPrefixSumJob : IJobFor // TypeDefIndex: 13003
		{
			// Fields
			[ReadOnly]
			public int jobsCount; // 0x00
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			public NativeArray<int> indicesSum; // 0x08
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			public NativeArray<int> indices; // 0x18
	
			// Methods
			public void Execute(int index); // 0x0000000181F4FD00-0x0000000181F4FD70
		}
	
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		internal struct RadixSortBucketSortJob<T> : IJobFor // TypeDefIndex: 13004
			where T : struct
		{
			// Fields
			[ReadOnly]
			public int radix;
			[ReadOnly]
			public int batchSize;
			[ReadOnly]
			public ParallelSortValueType valueType;
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			[ReadOnly]
			public NativeArray<T> array;
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			public NativeArray<int> indices;
			[NativeDisableContainerSafetyRestriction]
			[NoAlias]
			public NativeArray<T> arraySorted;
	
			// Methods
			public void Execute(int index);
		}
	
		// Methods
		private static int GetBucketIndex(int value, int radix); // 0x0000000181F4FA10-0x0000000181F4FA20
		private static int GetBucketIndex(ulong value, int radix); // 0x0000000181F4FA20-0x0000000181F4FA40
		private static void Swap<T>(ref NativeArray<T> a, ref NativeArray<T> b)
			where T : struct;
	
		// Extension methods
		internal static JobHandle ParallelSort<T>(this NativeArray<T> array)
			where T : struct, IComparable<T>;
	}
}
