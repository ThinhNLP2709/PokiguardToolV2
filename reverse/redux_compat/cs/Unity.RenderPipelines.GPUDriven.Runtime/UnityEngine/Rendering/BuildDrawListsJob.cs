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
	[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
	internal struct BuildDrawListsJob : IJobParallelFor // TypeDefIndex: 12739
	{
		// Fields
		public const int k_IntsPerCacheLine = 16; // Metadata: 0x006A7584
		[ReadOnly]
		public NativeParallelHashMap<DrawKey, int> batchHash; // 0x00
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeList<DrawInstance> drawInstances; // 0x10
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeList<DrawBatch> drawBatches; // 0x18
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeArray<int> internalDrawIndex; // 0x20
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeArray<int> drawInstanceIndices; // 0x30
	
		// Methods
		private static unsafe int IncrementCounter(int* counter); // 0x0000000181F03B90-0x0000000181F03BB0
		public void Execute(int index); // 0x0000000181F03AE0-0x0000000181F03B90
	}
}
