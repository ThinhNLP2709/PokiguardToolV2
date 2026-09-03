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
	internal struct CompactVisibilityMasksJob : IJobParallelForBatch // TypeDefIndex: 12845
	{
		// Fields
		public const int MaxBatchSize = 64; // Metadata: 0x006A75EC
		[ReadOnly]
		public NativeArray<byte> rendererVisibilityMasks; // 0x00
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public ParallelBitArray compactedVisibilityMasks; // 0x10
	
		// Methods
		public void Execute(int startIndex, int count); // 0x0000000181F1DD20-0x0000000181F1DD70
	}
}
