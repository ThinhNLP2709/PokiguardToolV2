/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	internal class RenderGraphResourceRegistry // TypeDefIndex: 5952
	{
		// Fields
		private const int kSharedResourceLifetime = 30; // Metadata: 0x00662C2F
		private static RenderGraphResourceRegistry m_CurrentRegistry; // 0x00
		private RenderGraphResourcesData[] m_RenderGraphResources; // 0x10
		private DynamicArray<RendererListResource> m_RendererListResources; // 0x18
		private DynamicArray<RendererListLegacyResource> m_RendererListLegacyResources; // 0x20
		private RenderGraphDebugParams m_RenderGraphDebug; // 0x28
		private int m_CurrentFrameIndex; // 0x30
		private int m_ExecutionCount; // 0x34
		private RTHandle m_CurrentBackbuffer; // 0x38
		private const int kInitialRendererListCount = 256; // Metadata: 0x00662C30
		private List<RendererList> m_ActiveRendererLists; // 0x40
		private static readonly RenderTargetIdentifier emptyId; // 0x08
		internal bool forceManualClearOfResource; // 0x48
	
		// Properties
		internal static RenderGraphResourceRegistry current { get; set; } // 0x0000000181EEA770-0x0000000181EEA7C0 0x0000000181EEA7C0-0x0000000181EEA830
	
		// Nested types
		private delegate bool ResourceCreateCallback(InternalRenderGraphContext rgContext, IRenderGraphResource res); // TypeDefIndex: 5953; 0x0000000180A70FB0-0x0000000180A70FC0
	
		private delegate void ResourceCallback(InternalRenderGraphContext rgContext, IRenderGraphResource res); // TypeDefIndex: 5954; 0x0000000180A70FB0-0x0000000180A70FC0
	
		private class RenderGraphResourcesData // TypeDefIndex: 5955
		{
			// Fields
			public DynamicArray<IRenderGraphResource> resourceArray; // 0x10
			public int sharedResourcesCount; // 0x18
			public IRenderGraphResourcePool pool; // 0x20
			public ResourceCreateCallback createResourceCallback; // 0x28
			public ResourceCallback releaseResourceCallback; // 0x30
	
			// Constructors
			public RenderGraphResourcesData(); // 0x0000000181EEA970-0x0000000181EEAA20
	
			// Methods
			public void Clear(bool onException, int frameIndex); // 0x0000000181EEA8C0-0x0000000181EEA950
			public void Cleanup(); // 0x0000000181EEA830-0x0000000181EEA8C0
			public void PurgeUnusedGraphicsResources(int frameIndex); // 0x0000000181EEA950-0x0000000181EEA970
			public int AddNewRenderGraphResource<ResType>(out ref ResType outRes, bool pooledResource = true /* Metadata: 0x00662C32 */)
				where ResType : IRenderGraphResource, new();
		}
	
		// Constructors
		private RenderGraphResourceRegistry(); // 0x0000000181EE9F80-0x0000000181EEA0C0
		internal RenderGraphResourceRegistry(RenderGraphDebugParams renderGraphDebug); // 0x0000000181EEA0C0-0x0000000181EEA770
		static RenderGraphResourceRegistry(); // 0x0000000181EE9F10-0x0000000181EE9F80
	
		// Methods
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckTextureResource(TextureResource texResource); // 0x0000000181EE4360-0x0000000181EE4420
		internal RTHandle GetTexture([IsReadOnly] in TextureHandle handle); // 0x0000000181EE7700-0x0000000181EE7790
		internal RTHandle GetTexture(int index); // 0x0000000181EE7790-0x0000000181EE7840
		internal string GetName([IsReadOnly] in TextureHandle handle); // 0x0000000181EE66E0-0x0000000181EE6780
		internal bool TextureNeedsFallback([IsReadOnly] in TextureHandle handle); // 0x0000000181EE9570-0x0000000181EE9610
		internal RendererList GetRendererList([IsReadOnly] in RendererListHandle handle); // 0x0000000181EE7150-0x0000000181EE7270
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckBufferResource(BufferResource bufferResource); // 0x0000000181EE40A0-0x0000000181EE4160
		internal GraphicsBuffer GetBuffer([IsReadOnly] in BufferHandle handle); // 0x0000000181EE6460-0x0000000181EE6590
		internal GraphicsBuffer GetBuffer(int index); // 0x0000000181EE63B0-0x0000000181EE6460
		internal RayTracingAccelerationStructure GetRayTracingAccelerationStructure([IsReadOnly] in RayTracingAccelerationStructureHandle handle); // 0x0000000181EE68B0-0x0000000181EE69E0
		internal int GetSharedResourceCount(RenderGraphResourceType type); // 0x0000000181EE7380-0x0000000181EE73C0
		internal void BeginRenderGraph(int executionCount); // 0x0000000181EE3FB0-0x0000000181EE40A0
		internal void BeginExecute(int currentFrameIndex); // 0x0000000181EE3DB0-0x0000000181EE3FB0
		internal void EndExecute(); // 0x0000000181EE5FC0-0x0000000181EE6070
		internal void EnableIntraFrameMemoryAliasing(bool enabled); // 0x0000000181EE5F60-0x0000000181EE5FC0
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckHandleValidity([IsReadOnly] in ResourceHandle res); // 0x00000001802E76C0-0x00000001802E76D0
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void CheckHandleValidity(RenderGraphResourceType type, int index); // 0x0000000181EE4160-0x0000000181EE4360
		internal ResourceHandle IncrementWriteCount([IsReadOnly] in ResourceHandle res); // 0x0000000181EE87D0-0x0000000181EE8930
		internal void IncrementReadCount([IsReadOnly] in ResourceHandle res); // 0x0000000181EE86F0-0x0000000181EE87D0
		internal ResourceHandle GetLatestVersionHandle([IsReadOnly] in ResourceHandle res); // 0x0000000181EE65A0-0x0000000181EE66E0
		internal ResourceHandle GetZeroVersionHandle([IsReadOnly] in ResourceHandle res); // 0x0000000181EE7840-0x0000000181EE78B0
		internal IRenderGraphResource GetResourceLowLevel([IsReadOnly] in ResourceHandle res); // 0x0000000181EE72B0-0x0000000181EE7380
		internal string GetRenderGraphResourceName([IsReadOnly] in ResourceHandle res); // 0x0000000181EE6A50-0x0000000181EE6B30
		internal string GetRenderGraphResourceName(RenderGraphResourceType type, int index); // 0x0000000181EE69E0-0x0000000181EE6A50
		internal bool IsRenderGraphResourceImported([IsReadOnly] in ResourceHandle res); // 0x0000000181EE8B40-0x0000000181EE8C10
		internal bool IsRenderGraphResourceBackBuffer([IsReadOnly] in ResourceHandle res); // 0x0000000181EE8A10-0x0000000181EE8AE0
		internal bool IsRenderGraphResourceShared(RenderGraphResourceType type, int index); // 0x0000000181EE8C90-0x0000000181EE8CD0
		internal bool IsRenderGraphResourceShared([IsReadOnly] in ResourceHandle res); // 0x0000000181EE8C10-0x0000000181EE8C90
		internal bool IsGraphicsResourceCreated([IsReadOnly] in ResourceHandle res); // 0x0000000181EE8930-0x0000000181EE8A10
		internal bool IsRendererListCreated([IsReadOnly] in RendererListHandle res); // 0x0000000181EE8CD0-0x0000000181EE8DC0
		internal bool IsRenderGraphResourceImported(RenderGraphResourceType type, int index); // 0x0000000181EE8AE0-0x0000000181EE8B40
		internal int GetRenderGraphResourceTransientIndex([IsReadOnly] in ResourceHandle res); // 0x0000000181EE6B30-0x0000000181EE6C00
		internal TextureHandle ImportTexture([IsReadOnly] in RTHandle rt, bool isBuiltin = false /* Metadata: 0x00662C29 */); // 0x0000000181EE8220-0x0000000181EE8270
		internal TextureHandle ImportTexture([IsReadOnly] in RTHandle rt, [IsReadOnly] in ImportResourceParams importParams, bool isBuiltin = false /* Metadata: 0x00662C2A */); // 0x0000000181EE8270-0x0000000181EE86F0
		internal TextureHandle ImportTexture([IsReadOnly] in RTHandle rt, RenderTargetInfo info, [IsReadOnly] in ImportResourceParams importParams); // 0x0000000181EE7E10-0x0000000181EE8220
		internal TextureHandle CreateSharedTexture([IsReadOnly] in TextureDesc desc, bool explicitRelease); // 0x0000000181EE5430-0x0000000181EE56F0
		internal void RefreshSharedTextureDesc([IsReadOnly] in TextureHandle texture, [IsReadOnly] in TextureDesc desc); // 0x0000000181EE8F90-0x0000000181EE9040
		internal void ReleaseSharedTexture([IsReadOnly] in TextureHandle texture); // 0x0000000181EE9270-0x0000000181EE9350
		internal TextureHandle ImportBackbuffer(RenderTargetIdentifier rt, [IsReadOnly] in RenderTargetInfo info, [IsReadOnly] in ImportResourceParams importParams); // 0x0000000181EE78B0-0x0000000181EE7B60
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void ValidateRenderTarget([IsReadOnly] in ResourceHandle res); // 0x0000000181EE9940-0x0000000181EE9A00
		internal void GetRenderTargetInfo([IsReadOnly] in ResourceHandle res, out RenderTargetInfo outInfo); // 0x0000000181EE6C00-0x0000000181EE7150
		internal GraphicsFormat GetFormat(GraphicsFormat color, GraphicsFormat depthStencil); // 0x0000000181EE6590-0x0000000181EE65A0
		[Conditional("UNITY_ENABLE_CHECKS")]
		internal void ValidateFormat(GraphicsFormat color, GraphicsFormat depthStencil); // 0x0000000181EE9850-0x0000000181EE9940
		internal TextureHandle CreateTexture([IsReadOnly] in TextureDesc desc, int transientPassIndex = -1 /* Metadata: 0x00662C2B */); // 0x0000000181EE5C00-0x0000000181EE5D80
		internal void SetTextureAsMemoryLess([IsReadOnly] in ResourceHandle handle); // 0x0000000181EE94E0-0x0000000181EE9570
		internal int GetResourceCount(RenderGraphResourceType type); // 0x0000000181EE7270-0x0000000181EE72B0
		internal int GetTextureResourceCount(); // 0x0000000181EE73C0-0x0000000181EE7400
		internal TextureResource GetTextureResource([IsReadOnly] in ResourceHandle handle); // 0x0000000181EE7610-0x0000000181EE7700
		internal TextureResource GetTextureResource(int index); // 0x0000000181EE7550-0x0000000181EE7610
		internal ref TextureDesc GetTextureResourceDesc([IsReadOnly] in ResourceHandle handle, bool noThrowOnInvalidDesc = false /* Metadata: 0x00662C2C */); // 0x0000000181EE7400-0x0000000181EE7550
		internal RendererListHandle CreateRendererList([IsReadOnly] in RendererListDesc desc); // 0x0000000181EE4F10-0x0000000181EE5130
		internal RendererListHandle CreateRendererList([IsReadOnly] in RendererListParams desc); // 0x0000000181EE4DD0-0x0000000181EE4F10
		internal RendererListHandle CreateShadowRendererList(ScriptableRenderContext context, ref ShadowDrawingSettings shadowDrawinSettings); // 0x0000000181EE5350-0x0000000181EE5430
		internal RendererListHandle CreateGizmoRendererList(ScriptableRenderContext context, [IsReadOnly] in Camera camera, [IsReadOnly] in GizmoSubset gizmoSubset); // 0x0000000181EE4A20-0x0000000181EE4B20
		internal RendererListHandle CreateUIOverlayRendererList(ScriptableRenderContext context, [IsReadOnly] in Camera camera, [IsReadOnly] in UISubset uiSubset); // 0x0000000181EE5D80-0x0000000181EE5E80
		internal RendererListHandle CreateWireOverlayRendererList(ScriptableRenderContext context, [IsReadOnly] in Camera camera); // 0x0000000181EE5E80-0x0000000181EE5F60
		internal RendererListHandle CreateSkyboxRendererList(ScriptableRenderContext context, [IsReadOnly] in Camera camera); // 0x0000000181EE56F0-0x0000000181EE57D0
		internal RendererListHandle CreateSkyboxRendererList(ScriptableRenderContext context, [IsReadOnly] in Camera camera, Matrix4x4 projectionMatrix, Matrix4x4 viewMatrix); // 0x0000000181EE5980-0x0000000181EE5AF0
		internal RendererListHandle CreateSkyboxRendererList(ScriptableRenderContext context, [IsReadOnly] in Camera camera, Matrix4x4 projectionMatrixL, Matrix4x4 viewMatrixL, Matrix4x4 projectionMatrixR, Matrix4x4 viewMatrixR); // 0x0000000181EE57D0-0x0000000181EE5980
		internal BufferHandle ImportBuffer(GraphicsBuffer graphicsBuffer); // 0x0000000181EE7B60-0x0000000181EE7CB0
		internal BufferHandle CreateBuffer([IsReadOnly] in BufferDesc desc, int transientPassIndex = -1 /* Metadata: 0x00662C2D */); // 0x0000000181EE48C0-0x0000000181EE4A20
		internal ref BufferDesc GetBufferResourceDesc([IsReadOnly] in ResourceHandle handle, bool noThrowOnInvalidDesc = false /* Metadata: 0x00662C2E */); // 0x0000000181EE60B0-0x0000000181EE6200
		internal int GetBufferResourceCount(); // 0x0000000181EE6070-0x0000000181EE60B0
		private BufferResource GetBufferResource([IsReadOnly] in ResourceHandle handle); // 0x0000000181EE62C0-0x0000000181EE63B0
		private BufferResource GetBufferResource(int index); // 0x0000000181EE6200-0x0000000181EE62C0
		private RayTracingAccelerationStructureResource GetRayTracingAccelerationStructureResource([IsReadOnly] in ResourceHandle handle); // 0x0000000181EE67C0-0x0000000181EE68B0
		internal int GetRayTracingAccelerationStructureResourceCount(); // 0x0000000181EE6780-0x0000000181EE67C0
		internal RayTracingAccelerationStructureHandle ImportRayTracingAccelerationStructure([IsReadOnly] in RayTracingAccelerationStructure accelStruct, string name); // 0x0000000181EE7CB0-0x0000000181EE7E10
		internal void UpdateSharedResourceLastFrameIndex(int type, int index); // 0x0000000181EE9610-0x0000000181EE9670
		internal void UpdateSharedResourceLastFrameIndex([IsReadOnly] in ResourceHandle handle); // 0x0000000181EE9670-0x0000000181EE9710
		private void ManageSharedRenderGraphResources(); // 0x0000000181EE8DC0-0x0000000181EE8F10
		internal bool CreatePooledResource(InternalRenderGraphContext rgContext, int type, int index); // 0x0000000181EE4CB0-0x0000000181EE4DD0
		internal bool CreatePooledResource(InternalRenderGraphContext rgContext, [IsReadOnly] in ResourceHandle handle); // 0x0000000181EE4B20-0x0000000181EE4CB0
		private bool CreateTextureCallback(InternalRenderGraphContext rgContext, IRenderGraphResource res); // 0x0000000181EE5AF0-0x0000000181EE5C00
		internal bool ClearResource(InternalRenderGraphContext rgContext, int type, int index); // 0x0000000181EE4550-0x0000000181EE4640
		private void ClearTexture(InternalRenderGraphContext rgContext, TextureResource resource); // 0x0000000181EE4640-0x0000000181EE47A0
		internal void ReleasePooledResource(InternalRenderGraphContext rgContext, int type, int index); // 0x0000000181EE9190-0x0000000181EE9270
		internal void ReleasePooledResource(InternalRenderGraphContext rgContext, [IsReadOnly] in ResourceHandle handle); // 0x0000000181EE9040-0x0000000181EE9190
		private void ReleaseTextureCallback(InternalRenderGraphContext rgContext, IRenderGraphResource res); // 0x0000000181EE9350-0x0000000181EE94E0
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void ValidateTextureDesc([IsReadOnly] in TextureDesc desc); // 0x0000000181EE9C50-0x0000000181EE9F10
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void ValidateRendererListDesc([IsReadOnly] in RendererListDesc desc); // 0x0000000181EE9A00-0x0000000181EE9C50
		[Conditional("UNITY_ENABLE_CHECKS")]
		private void ValidateBufferDesc([IsReadOnly] in BufferDesc desc); // 0x0000000181EE9710-0x0000000181EE9850
		internal void CreateRendererLists(List<RendererListHandle> rendererLists, ScriptableRenderContext context); // 0x0000000181EE5130-0x0000000181EE5350
		internal void Clear(bool onException); // 0x0000000181EE47A0-0x0000000181EE48C0
		internal void PurgeUnusedGraphicsResources(); // 0x0000000181EE8F10-0x0000000181EE8F90
		internal void Cleanup(); // 0x0000000181EE4420-0x0000000181EE4550
	}
}
