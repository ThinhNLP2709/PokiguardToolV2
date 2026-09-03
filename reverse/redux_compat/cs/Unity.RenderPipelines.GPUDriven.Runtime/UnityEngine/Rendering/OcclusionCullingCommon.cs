/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 16: Unity.RenderPipelines.GPUDriven.Runtime.dll - Assembly: Unity.RenderPipelines.GPUDriven.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12730-13007

namespace UnityEngine.Rendering
{
	internal class OcclusionCullingCommon : IDisposable // TypeDefIndex: 12888
	{
		// Fields
		private static readonly int s_MaxContextGCFrame; // 0x00
		private Material m_DebugOcclusionTestMaterial; // 0x10
		private Material m_OccluderDebugViewMaterial; // 0x18
		private ComputeShader m_OcclusionDebugCS; // 0x20
		private int m_ClearOcclusionDebugKernel; // 0x28
		private ComputeShader m_OccluderDepthPyramidCS; // 0x30
		private int m_OccluderDepthDownscaleKernel; // 0x38
		private int m_FrameIndex; // 0x3C
		private SilhouettePlaneCache m_SilhouettePlaneCache; // 0x40
		private NativeParallelHashMap<EntityId, int> m_ViewIDToIndexMap; // 0x68
		private List<OccluderContext> m_OccluderContextData; // 0x78
		private NativeList<OccluderContextSlot> m_OccluderContextSlots; // 0x80
		private NativeList<int> m_FreeOccluderContexts; // 0x88
		private NativeArray<OcclusionCullingCommonShaderVariables> m_CommonShaderVariables; // 0x90
		private ComputeBuffer m_CommonConstantBuffer; // 0xA0
		private NativeArray<OcclusionCullingDebugShaderVariables> m_DebugShaderVariables; // 0xA8
		private ComputeBuffer m_DebugConstantBuffer; // 0xB8
		private ProfilingSampler m_ProfilingSamplerUpdateOccluders; // 0xC0
		private ProfilingSampler m_ProfilingSamplerOcclusionTestOverlay; // 0xC8
		private ProfilingSampler m_ProfilingSamplerOccluderOverlay; // 0xD0
		private BaseRenderFunc<OcclusionTestOverlaySetupPassData, ComputeGraphContext> m_ComputePassRenderFunc; // 0xD8
		private BaseRenderFunc<OcclusionTestOverlayPassData, RasterGraphContext> m_RasterPassRenderFunc; // 0xE0
	
		// Nested types
		private struct OccluderContextSlot // TypeDefIndex: 12889
		{
			// Fields
			public bool valid; // 0x00
			public int lastUsedFrameIndex; // 0x04
			public EntityId viewID; // 0x08
		}
	
		private static class ShaderIDs // TypeDefIndex: 12890
		{
			// Fields
			public static readonly int OcclusionCullingCommonShaderVariables; // 0x00
			public static readonly int _OccluderDepthPyramid; // 0x04
			public static readonly int _OcclusionDebugOverlay; // 0x08
			public static readonly int OcclusionCullingDebugShaderVariables; // 0x0C
	
			// Constructors
			static ShaderIDs(); // 0x0000000181F487A0-0x0000000181F48870
		}
	
		private class OcclusionTestOverlaySetupPassData // TypeDefIndex: 12891
		{
			// Fields
			public OcclusionCullingDebugShaderVariables cb; // 0x10
	
			// Constructors
			public OcclusionTestOverlaySetupPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class OcclusionTestOverlayPassData // TypeDefIndex: 12892
		{
			// Fields
			public BufferHandle debugPyramid; // 0x10
	
			// Constructors
			public OcclusionTestOverlayPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private struct DebugOccluderViewData // TypeDefIndex: 12893
		{
			// Fields
			public int passIndex; // 0x00
			public Rect viewport; // 0x04
			public bool valid; // 0x14
		}
	
		private class OccluderOverlayPassData // TypeDefIndex: 12894
		{
			// Fields
			public Material debugMaterial; // 0x10
			public RTHandle occluderTexture; // 0x18
			public Rect viewport; // 0x20
			public int passIndex; // 0x30
			public Vector2 validRange; // 0x34
	
			// Constructors
			public OccluderOverlayPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class UpdateOccludersPassData // TypeDefIndex: 12895
		{
			// Fields
			public OccluderParameters occluderParams; // 0x10
			public List<OccluderSubviewUpdate> occluderSubviewUpdates; // 0x38
			public OccluderHandles occluderHandles; // 0x40
			public GPUResidentContext grdContext; // 0x60
	
			// Constructors
			public UpdateOccludersPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 12896
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<OccluderOverlayPassData, RasterGraphContext> __9__34_0; // 0x08
			public static BaseRenderFunc<UpdateOccludersPassData, ComputeGraphContext> __9__39_0; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181F4B200-0x0000000181F4B270
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RenderDebugOccluderOverlay_b__34_0(OccluderOverlayPassData data, RasterGraphContext ctx); // 0x0000000181F49BD0-0x0000000181F49D90
			internal void _UpdateInstanceOccluders_b__39_0(UpdateOccludersPassData data, ComputeGraphContext context); // 0x0000000181F49D90-0x0000000181F4A140
		}
	
		// Constructors
		public OcclusionCullingCommon(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static OcclusionCullingCommon(); // 0x0000000181F46240-0x0000000181F46280
	
		// Methods
		internal void Initialize(GPUResidentDrawerResources resources); // 0x0000000181F43350-0x0000000181F43870
		internal static bool UseOcclusionDebug([IsReadOnly] in OccluderContext occluderCtx); // 0x0000000181F46230-0x0000000181F46240
		internal void PrepareCulling(ComputeCommandBuffer cmd, [IsReadOnly] in OccluderContext occluderCtx, [IsReadOnly] in OcclusionCullingSettings settings, [IsReadOnly] in InstanceOcclusionTestSubviewSettings subviewSettings, [IsReadOnly] in OcclusionTestComputeShader shader, bool useOcclusionDebug); // 0x0000000181F43A80-0x0000000181F43FE0
		internal static void SetDepthPyramid(ComputeCommandBuffer cmd, [IsReadOnly] in OcclusionTestComputeShader shader, int kernel, [IsReadOnly] in OccluderHandles occluderHandles); // 0x0000000181F45070-0x0000000181F45130
		internal static void SetDebugPyramid(ComputeCommandBuffer cmd, [IsReadOnly] in OcclusionTestComputeShader shader, int kernel, [IsReadOnly] in OccluderHandles occluderHandles); // 0x0000000181F44F80-0x0000000181F45070
		public void RenderDebugOcclusionTestOverlay(RenderGraph renderGraph, DebugDisplayGPUResidentDrawer debugSettings, EntityId viewID, TextureHandle colorBuffer); // 0x0000000181F448A0-0x0000000181F44F80
		public void RenderDebugOccluderOverlay(RenderGraph renderGraph, DebugDisplayGPUResidentDrawer debugSettings, Vector2 screenPos, float maxHeight, TextureHandle colorBuffer); // 0x0000000181F442F0-0x0000000181F448A0
		private void DispatchDebugClear(ComputeCommandBuffer cmd, EntityId viewID); // 0x0000000181F42930-0x0000000181F42C40
		private OccluderHandles PrepareOccluders(RenderGraph renderGraph, [IsReadOnly] in OccluderParameters occluderParams); // 0x0000000181F43FE0-0x0000000181F442F0
		private void CreateFarDepthPyramid(ComputeCommandBuffer cmd, [IsReadOnly] in OccluderParameters occluderParams, ReadOnlySpan<OccluderSubviewUpdate> occluderSubviewUpdates, [IsReadOnly] in OccluderHandles occluderHandles); // 0x0000000181F42550-0x0000000181F427D0
		public bool UpdateInstanceOccluders(RenderGraph renderGraph, GPUResidentContext grdContext, [IsReadOnly] in OccluderParameters occluderParams, ReadOnlySpan<OccluderSubviewUpdate> occluderSubviewUpdates); // 0x0000000181F45790-0x0000000181F45F70
		internal void UpdateSilhouettePlanes(EntityId viewID, NativeArray<Plane> planes); // 0x0000000181F46200-0x0000000181F46230
		internal OcclusionCullingDebugOutput GetOcclusionTestDebugOutput(EntityId viewID); // 0x0000000181F42FD0-0x0000000181F43340
		public void UpdateOccluderStats(DebugRendererBatcherStats debugStats); // 0x0000000181F45F70-0x0000000181F46200
		internal bool HasOccluderContext(EntityId viewID); // 0x0000000181F43340-0x0000000181F43350
		internal bool GetOccluderContext(EntityId viewID, out OccluderContext occluderContext); // 0x0000000181F42EA0-0x0000000181F42FD0
		internal void UpdateFrame(); // 0x0000000181F45430-0x0000000181F45790
		private int NewContext(EntityId viewID); // 0x0000000181F43870-0x0000000181F43A80
		private void DeleteContext(EntityId viewID); // 0x0000000181F427D0-0x0000000181F42930
		public void Dispose(); // 0x0000000181F42C40-0x0000000181F42EA0
		[CompilerGenerated]
		private void _Initialize_b__23_0(OcclusionTestOverlaySetupPassData data, ComputeGraphContext ctx); // 0x0000000181F45130-0x0000000181F45300
		[CompilerGenerated]
		private void _Initialize_b__23_1(OcclusionTestOverlayPassData data, RasterGraphContext ctx); // 0x0000000181F45300-0x0000000181F45430
	}
}
