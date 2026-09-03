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
using UnityEngine;
using UnityEngine.Rendering;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	[BurstCompile(DisableSafetyChecks = true, OptimizeFor = OptimizeFor.Performance)]
	internal struct AllocateBinsPerBatch : IJobParallelFor // TypeDefIndex: 12842
	{
		// Fields
		[ReadOnly]
		public BinningConfig binningConfig; // 0x00
		[ReadOnly]
		public NativeList<DrawBatch> drawBatches; // 0x08
		[ReadOnly]
		public NativeArray<int> drawInstanceIndices; // 0x10
		[ReadOnly]
		public RenderWorld renderWorld; // 0x20
		[ReadOnly]
		public NativeArray<byte> rendererVisibilityMasks; // 0x200
		[ReadOnly]
		public NativeArray<byte> rendererMeshLodSettings; // 0x210
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeArray<int> batchBinAllocOffsets; // 0x220
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeArray<int> batchBinCounts; // 0x230
		[DeallocateOnJobCompletion]
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<int> binAllocCounter; // 0x240
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeArray<short> binConfigIndices; // 0x250
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		[WriteOnly]
		public NativeArray<int> binVisibleInstanceCounts; // 0x260
		[ReadOnly]
		public int debugCounterIndexBase; // 0x270
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<int> splitDebugCounters; // 0x278
	
		// Methods
		private bool IsInstanceFlipped(int rendererIndex); // 0x0000000181F1D3B0-0x0000000181F1D4F0
		private bool IsMeshLodVisible(int batchLodLevel, int rendererIndex, bool supportsCrossFade); // 0x0000000181F1D4F0-0x0000000181F1D540
		private static int GetPrimitiveCount(int indexCount, MeshTopology topology, bool nativeQuads); // 0x0000000181F1D340-0x0000000181F1D3B0
		public void Execute(int batchIndex); // 0x0000000181F1CC90-0x0000000181F1D340
	}
}
