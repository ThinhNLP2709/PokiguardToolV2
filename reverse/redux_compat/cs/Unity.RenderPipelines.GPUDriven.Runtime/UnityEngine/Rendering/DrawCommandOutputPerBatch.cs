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
	internal struct DrawCommandOutputPerBatch : IJobParallelFor // TypeDefIndex: 12844
	{
		// Fields
		[ReadOnly]
		public BinningConfig binningConfig; // 0x00
		[ReadOnly]
		public NativeParallelHashMap<GPUArchetypeHandle, BatchID> batchIDs; // 0x08
		[ReadOnly]
		public GPUInstanceDataBuffer.ReadOnly instanceDataBuffer; // 0x18
		[ReadOnly]
		public NativeList<DrawBatch> drawBatches; // 0x78
		[ReadOnly]
		public NativeArray<int> drawInstanceIndices; // 0x80
		[ReadOnly]
		public RenderWorld renderWorld; // 0x90
		[ReadOnly]
		public NativeArray<byte> rendererVisibilityMasks; // 0x270
		[ReadOnly]
		public NativeArray<byte> rendererMeshLodSettings; // 0x280
		[ReadOnly]
		public NativeArray<byte> rendererCrossFadeValues; // 0x290
		[DeallocateOnJobCompletion]
		[ReadOnly]
		public NativeArray<int> batchBinAllocOffsets; // 0x2A0
		[DeallocateOnJobCompletion]
		[ReadOnly]
		public NativeArray<int> batchBinCounts; // 0x2B0
		[DeallocateOnJobCompletion]
		[ReadOnly]
		public NativeArray<int> batchDrawCommandOffsets; // 0x2C0
		[DeallocateOnJobCompletion]
		[ReadOnly]
		public NativeArray<short> binConfigIndices; // 0x2D0
		[DeallocateOnJobCompletion]
		[ReadOnly]
		public NativeArray<int> binVisibleInstanceOffsets; // 0x2E0
		[DeallocateOnJobCompletion]
		[ReadOnly]
		public NativeArray<int> binVisibleInstanceCounts; // 0x2F0
		[ReadOnly]
		public NativeArray<BatchCullingOutputDrawCommands> cullingOutput; // 0x300
		[ReadOnly]
		public IndirectBufferLimits indirectBufferLimits; // 0x310
		[ReadOnly]
		public GraphicsBufferHandle visibleInstancesBufferHandle; // 0x318
		[ReadOnly]
		public GraphicsBufferHandle indirectArgsBufferHandle; // 0x31C
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<IndirectBufferAllocInfo> indirectBufferAllocInfo; // 0x320
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<IndirectDrawInfo> indirectDrawInfoGlobalArray; // 0x330
		[NativeDisableContainerSafetyRestriction]
		[NoAlias]
		public NativeArray<IndirectInstanceInfo> indirectInstanceInfoGlobalArray; // 0x340
	
		// Methods
		private int EncodeGPUInstanceIndexAndCrossFade(int rendererIndex, bool negateCrossFade); // 0x0000000181F1F880-0x0000000181F1FA40
		private bool IsInstanceFlipped(int rendererIndex); // 0x0000000181F20520-0x0000000181F20660
		private bool IsMeshLodVisible(int batchLodLevel, int rendererIndex, bool supportsCrossFade, ref bool negateCrossfade); // 0x0000000181F20660-0x0000000181F206C0
		public void Execute(int batchIndex); // 0x0000000181F1FA40-0x0000000181F20520
	}
}
