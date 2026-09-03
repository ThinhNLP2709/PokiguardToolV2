/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal class InstanceCuller : IDisposable // TypeDefIndex: 12853
	{
		// Fields
		private NativeParallelHashMap<int, AnimatedFadeData> m_LODParamsToCameraID; // 0x10
		private ParallelBitArray m_CompactedVisibilityMasks; // 0x20
		private JobHandle m_CompactedVisibilityMasksJobsHandle; // 0x40
		private IndirectBufferContextStorage m_IndirectStorage; // 0x50
		private OcclusionTestComputeShader m_OcclusionTestShader; // 0xD8
		private int m_ResetDrawArgsKernel; // 0xF8
		private int m_CopyInstancesKernel; // 0xFC
		private int m_CullInstancesKernel; // 0x100
		private DebugRendererBatcherStats m_DebugStats; // 0x108
		private NativeArray<int> m_CullingDebugCounters; // 0x110
		private InstanceCullerSplitDebugArray m_SplitDebugArray; // 0x120
		private InstanceOcclusionEventDebugArray m_OcclusionEventDebugArray; // 0x140
		private ProfilingSampler m_ProfilingSampleInstanceOcclusionTest; // 0x198
		private NativeArray<InstanceOcclusionCullerShaderVariables> m_ShaderVariables; // 0x1A0
		private ComputeBuffer m_ConstantBuffer; // 0x1B0
		private CommandBuffer m_CommandBuffer; // 0x1B8
	
		// Nested types
		private struct AnimatedFadeData // TypeDefIndex: 12854
		{
			// Fields
			public EntityId cameraID; // 0x00
			public JobHandle jobHandle; // 0x08
		}
	
		private static class ShaderIDs // TypeDefIndex: 12855
		{
			// Fields
			public static readonly int InstanceOcclusionCullerShaderVariables; // 0x00
			public static readonly int _DrawInfo; // 0x04
			public static readonly int _InstanceInfo; // 0x08
			public static readonly int _DispatchArgs; // 0x0C
			public static readonly int _DrawArgs; // 0x10
			public static readonly int _InstanceIndices; // 0x14
			public static readonly int _InstanceDataBuffer; // 0x18
			public static readonly int _OccluderDepthPyramid; // 0x1C
			public static readonly int _OcclusionDebugCounters; // 0x20
	
			// Constructors
			static ShaderIDs(); // 0x0000000181F2DD00-0x0000000181F2DEB0
		}
	
		private class InstanceOcclusionTestPassData // TypeDefIndex: 12856
		{
			// Fields
			public GPUResidentContext grdContext; // 0x10
			public OcclusionCullingSettings settings; // 0x18
			public InstanceOcclusionTestSubviewSettings subviewSettings; // 0x28
			public OccluderHandles occluderHandles; // 0x3C
			public IndirectBufferContextHandles bufferHandles; // 0x58
	
			// Constructors
			public InstanceOcclusionTestPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 12857
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<InstanceOcclusionTestPassData, ComputeGraphContext> __9__29_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181F2DF20-0x0000000181F2DF90
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _InstanceOcclusionTest_b__29_0(InstanceOcclusionTestPassData data, ComputeGraphContext context); // 0x0000000181F2DEB0-0x0000000181F2DF20
		}
	
		// Constructors
		public InstanceCuller(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void Initialize(GPUResidentDrawerResources resources, DebugRendererBatcherStats debugStats = null); // 0x0000000181F25780-0x0000000181F25BC0
		private JobHandle AnimateCrossFades([IsReadOnly] in RenderWorld renderWorld, [IsReadOnly] in BatchCullingContext context, out RenderWorld.PerCameraInstanceData perCameraInstanceData, out bool hasAnimatedCrossfade); // 0x0000000181F23A20-0x0000000181F240A0
		private JobHandle ScheduleFrustumCullingJob([IsReadOnly] in BatchCullingContext context, [IsReadOnly] in RenderWorld renderWorld, [IsReadOnly] in NativeParallelHashMap<EntityId, MeshInfo> meshMap, NativeList<LODGroupCullingData> lodGroupCullingData, [IsReadOnly] in BinningConfig binningConfig, float smallMeshScreenPercentage, float4 shadowSmallMeshScreenPercentages, OcclusionCullingCommon occlusionCullingCommon, [IsReadOnly] in IncludeExcludeListFilter includeExcludeListFilter, NativeArray<byte> rendererVisibilityMasks, NativeArray<byte> rendererMeshLodSettings, NativeArray<byte> rendererCrossFadeValues); // 0x0000000181F26460-0x0000000181F26C10
		private int ComputeWorstCaseDrawCommandCount([IsReadOnly] in BatchCullingContext cc, BinningConfig binningConfig, CPUDrawInstanceData drawInstanceData); // 0x0000000181F240A0-0x0000000181F24110
		public JobHandle CreateCullJobTree([IsReadOnly] in BatchCullingContext context, BatchCullingOutput cullingOutput, [IsReadOnly] in RenderWorld renderWorld, [IsReadOnly] in NativeParallelHashMap<EntityId, MeshInfo> meshMap, [IsReadOnly] in GPUInstanceDataBuffer.ReadOnly instanceDataBuffer, NativeList<LODGroupCullingData> lodGroupCullingData, CPUDrawInstanceData drawInstanceData, NativeParallelHashMap<GPUArchetypeHandle, BatchID> batchIDs, float smallMeshScreenPercentage, float4 shadowSmallMeshScreenPercentages, OcclusionCullingCommon occlusionCullingCommon, [IsReadOnly] in IncludeExcludeListFilter includeExcludeListFilter); // 0x0000000181F24110-0x0000000181F25040
		private JobHandle ScheduleCompactedVisibilityMaskJob([IsReadOnly] in RenderWorld renderWorld, NativeArray<byte> rendererVisibilityMasks, JobHandle cullingJobHandle); // 0x0000000181F26250-0x0000000181F26460
		public void InstanceOccludersUpdated(EntityId viewID, int subviewMask, OcclusionCullingCommon occlusionCullingCommon); // 0x0000000181F25BC0-0x0000000181F25CD0
		private void DisposeCompactVisibilityMasks(); // 0x0000000181F25040-0x0000000181F25070
		private void DisposeSceneViewHiddenBits(); // 0x00000001802E76C0-0x00000001802E76D0
		public ParallelBitArray GetCompactedVisibilityMasks(bool syncCullingJobs); // 0x0000000181F25740-0x0000000181F25780
		public void InstanceOcclusionTest(RenderGraph renderGraph, [IsReadOnly] in OcclusionCullingSettings settings, ReadOnlySpan<SubviewOcclusionTest> subviewOcclusionTests, GPUResidentContext grdContext); // 0x0000000181F25CD0-0x0000000181F26220
		internal void EnsureValidOcclusionTestResults(EntityId viewID); // 0x0000000181F251C0-0x0000000181F25500
		private void AddOcclusionCullingDispatch(ComputeCommandBuffer cmd, [IsReadOnly] in OcclusionCullingSettings settings, [IsReadOnly] in InstanceOcclusionTestSubviewSettings subviewSettings, [IsReadOnly] in IndirectBufferContextHandles bufferHandles, [IsReadOnly] in OccluderHandles occluderHandles, GPUResidentContext grdContext); // 0x0000000181F22CF0-0x0000000181F23A20
		private void FlushDebugCounters(); // 0x0000000181F25500-0x0000000181F25740
		private void OnBeginSceneViewCameraRendering(); // 0x00000001802E76C0-0x00000001802E76D0
		private void OnEndSceneViewCameraRendering(); // 0x00000001802E76C0-0x00000001802E76D0
		public void UpdateFrame(int cameraCount); // 0x0000000181F26C10-0x0000000181F26C90
		public void OnBeginCameraRendering(Camera camera); // 0x0000000181F26220-0x0000000181F26250
		public void OnEndCameraRendering(Camera camera); // 0x0000000181F26220-0x0000000181F26250
		public void Dispose(); // 0x0000000181F25070-0x0000000181F251C0
	}
}
