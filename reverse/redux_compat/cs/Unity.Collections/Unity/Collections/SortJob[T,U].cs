/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[2] {typeof(int), typeof(NativeSortExtension.DefaultComparer<int>) })]
	public struct SortJob<T, U> // TypeDefIndex: 11616
		where T : struct
		where U : IComparer<T>
	{
		// Fields
		public unsafe T* Data;
		public U Comp;
		public int Length;
	
		// Nested types
		[BurstCompile]
		public struct SegmentSort : IJobParallelFor // TypeDefIndex: 11617
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal unsafe T* Data;
			internal U Comp;
			internal int Length;
			internal int SegmentWidth;
	
			// Methods
			public void Execute(int index);
		}
	
		[BurstCompile]
		public struct SegmentSortMerge : IJob // TypeDefIndex: 11618
		{
			// Fields
			[NativeDisableUnsafePtrRestriction]
			internal unsafe T* Data;
			internal U Comp;
			internal int Length;
			internal int SegmentWidth;
	
			// Methods
			public void Execute();
		}
	
		// Methods
		public JobHandle Schedule(JobHandle inputDeps = default);
	}
}
