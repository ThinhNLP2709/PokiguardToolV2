/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[BurstCompile]
	internal static class CPUDrawInstanceDataBurst // TypeDefIndex: 12735
	{
		// Nested types
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RemoveDrawInstanceIndices_00000017_PostfixBurstDelegate([IsReadOnly] in NativeArray<int> drawInstanceIndicesSorted, ref NativeList<DrawInstance> drawInstances, ref NativeParallelHashMap<RangeKey, int> rangeHash, ref NativeParallelHashMap<DrawKey, int> batchHash, ref NativeList<DrawRange> drawRanges, ref NativeList<DrawBatch> drawBatches); // TypeDefIndex: 12736; 0x0000000180ED8BF0-0x0000000180ED8C10
	
		internal static class RemoveDrawInstanceIndices_00000017_BurstDirectCall // TypeDefIndex: 12737
		{
			// Fields
			private static IntPtr Pointer; // 0x00
	
			// Methods
			private static void ClearFunctionPointer(); // 0x0000000181F19F40-0x0000000181F19F80
			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr param_000183fd); // 0x0000000181F19F80-0x0000000181F1A0F0
			private static IntPtr GetFunctionPointer(); // 0x0000000181F1A0F0-0x0000000181F1A250
			public static void Invoke([IsReadOnly] in NativeArray<int> drawInstanceIndicesSorted, ref NativeList<DrawInstance> drawInstances, ref NativeParallelHashMap<RangeKey, int> rangeHash, ref NativeParallelHashMap<DrawKey, int> batchHash, ref NativeList<DrawRange> drawRanges, ref NativeList<DrawBatch> drawBatches); // 0x0000000181F1A250-0x0000000181F1A480
		}
	
		// Methods
		private static void RemoveDrawRange([IsReadOnly] in RangeKey key, ref NativeParallelHashMap<RangeKey, int> rangeHash, ref NativeList<DrawRange> drawRanges); // 0x0000000181F03DB0-0x0000000181F03E90
		private static void RemoveDrawBatch([IsReadOnly] in DrawKey key, ref NativeParallelHashMap<RangeKey, int> rangeHash, ref NativeParallelHashMap<DrawKey, int> batchHash, ref NativeList<DrawRange> drawRanges, ref NativeList<DrawBatch> drawBatches); // 0x0000000181F03BB0-0x0000000181F03DA0
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		public static void RemoveDrawInstanceIndices([IsReadOnly] in NativeArray<int> drawInstanceIndicesSorted, ref NativeList<DrawInstance> drawInstances, ref NativeParallelHashMap<RangeKey, int> rangeHash, ref NativeParallelHashMap<DrawKey, int> batchHash, ref NativeList<DrawRange> drawRanges, ref NativeList<DrawBatch> drawBatches); // 0x0000000181F03DA0-0x0000000181F03DB0
		[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
		[MonoPInvokeCallback(typeof(RemoveDrawInstanceIndices_00000017_PostfixBurstDelegate))]
		internal static void RemoveDrawInstanceIndices_BurstManaged([IsReadOnly] in NativeArray<int> drawInstanceIndicesSorted, ref NativeList<DrawInstance> drawInstances, ref NativeParallelHashMap<RangeKey, int> rangeHash, ref NativeParallelHashMap<DrawKey, int> batchHash, ref NativeList<DrawRange> drawRanges, ref NativeList<DrawBatch> drawBatches); // 0x0000000181F033D0-0x0000000181F03520
	}
}
