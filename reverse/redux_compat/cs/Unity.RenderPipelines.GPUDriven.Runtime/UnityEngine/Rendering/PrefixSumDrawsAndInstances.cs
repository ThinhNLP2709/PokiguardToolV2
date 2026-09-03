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
	internal struct PrefixSumDrawsAndInstances : IJob // TypeDefIndex: 12843
	{
		// Fields
		[ReadOnly]
		public NativeList<DrawRange> drawRanges; // 0x00
		[ReadOnly]
		public NativeArray<int> drawBatchIndices; // 0x08
		[ReadOnly]
		public NativeArray<int> batchBinAllocOffsets; // 0x18
		[ReadOnly]
		public NativeArray<int> batchBinCounts; // 0x28
		[ReadOnly]
		public NativeArray<int> binVisibleInstanceCounts; // 0x38
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeArray<int> batchDrawCommandOffsets; // 0x48
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeArray<int> binVisibleInstanceOffsets; // 0x58
		[NativeDisableUnsafePtrRestriction]
		public NativeArray<BatchCullingOutputDrawCommands> cullingOutput; // 0x68
		[ReadOnly]
		public IndirectBufferLimits indirectBufferLimits; // 0x78
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<IndirectBufferAllocInfo> indirectBufferAllocInfo; // 0x80
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<int> indirectAllocationCounters; // 0x90
	
		// Methods
		public void Execute(); // 0x0000000181F299C0-0x0000000181F29E80
	}
}
