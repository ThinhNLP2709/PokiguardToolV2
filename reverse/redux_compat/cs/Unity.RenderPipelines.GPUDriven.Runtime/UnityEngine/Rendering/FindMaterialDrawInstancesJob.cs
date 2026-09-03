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
	internal struct FindMaterialDrawInstancesJob : IJobParallelForBatch // TypeDefIndex: 12741
	{
		// Fields
		public const int k_MaxBatchSize = 128; // Metadata: 0x006A7587
		[ReadOnly]
		public NativeArray<uint> materialsSorted; // 0x00
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[ReadOnly]
		public NativeList<DrawInstance> drawInstances; // 0x10
		[WriteOnly]
		public NativeList<int> outDrawInstanceIndicesWriter; // 0x18
	
		// Methods
		public void Execute(int startIndex, int count); // 0x0000000181F07000-0x0000000181F07100
	}
}
