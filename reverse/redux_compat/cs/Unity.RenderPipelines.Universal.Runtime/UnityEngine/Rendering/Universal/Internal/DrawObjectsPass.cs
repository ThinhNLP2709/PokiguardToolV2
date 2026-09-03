/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal.Internal
{
	public class DrawObjectsPass : ScriptableRenderPass // TypeDefIndex: 9919
	{
		// Fields
		private FilteringSettings m_FilteringSettings; // 0x60
		private RenderStateBlock m_RenderStateBlock; // 0x80
		private List<ShaderTagId> m_ShaderTagIdList; // 0xF0
		private bool m_IsOpaque; // 0xF8
		public bool m_ShouldTransparentsReceiveShadows; // 0xF9
		[CompilerGenerated]
		private bool _shouldTransparentsReceiveSSR_k__BackingField; // 0xFA
		private static readonly int s_DrawObjectPassDataPropID; // 0x00
	
		// Properties
		public bool shouldTransparentsReceiveSSR { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001820383E0-0x00000001820383F0 0x00000001820383F0-0x0000000182038400
	
		// Nested types
		internal class PassData // TypeDefIndex: 9920
		{
			// Fields
			internal TextureHandle albedoHdl; // 0x10
			internal TextureHandle depthHdl; // 0x20
			internal TextureHandle screenSpaceIrradianceHdl; // 0x30
			internal TextureHandle screenSpaceReflectionHdl; // 0x40
			internal UniversalCameraData cameraData; // 0x50
			internal UniversalShadowData shadowData; // 0x58
			internal bool isOpaque; // 0x60
			internal bool shouldTransparentsReceiveShadows; // 0x61
			internal bool shouldTransparentsReceiveSSR; // 0x62
			internal uint batchLayerMask; // 0x64
			internal bool isActiveTargetBackBuffer; // 0x68
			internal RendererListHandle rendererListHdl; // 0x6C
			internal RendererListHandle objectsWithErrorRendererListHdl; // 0x78
			internal DebugRendererLists debugRendererLists; // 0x88
			internal RendererList rendererList; // 0x90
			internal RendererList objectsWithErrorRendererList; // 0xA8
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9921
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__19_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182041660-0x00000001820416D0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__19_0(PassData data, RasterGraphContext context); // 0x0000000182040AD0-0x0000000182040E80
		}
	
		// Constructors
		public DrawObjectsPass(string profilerTag, ShaderTagId[] shaderTagIds, bool opaque, RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask, StencilState stencilState, int stencilReference); // 0x0000000182038170-0x00000001820382C0
		public DrawObjectsPass(string profilerTag, bool opaque, RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask, StencilState stencilState, int stencilReference); // 0x0000000182038030-0x0000000182038170
		internal DrawObjectsPass(ProfilingSampler sampler, bool opaque, RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask, StencilState stencilState, int stencilReference); // 0x00000001820382C0-0x00000001820383E0
		static DrawObjectsPass(); // 0x0000000182037FE0-0x0000000182038030
	
		// Methods
		internal void Init(bool opaque, RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask, StencilState stencilState, int stencilReference, ShaderTagId[] shaderTagIds = null); // 0x0000000182036E70-0x00000001820371D0
		internal static void ExecutePass(RasterCommandBuffer cmd, PassData data, RendererList rendererList, RendererList objectsWithErrorRendererList, bool yFlip); // 0x0000000182036620-0x00000001820369C0
		internal void InitPassData(UniversalCameraData cameraData, UniversalShadowData shadowData, ref PassData passData, uint batchLayerMask, bool isActiveTargetBackBuffer = false /* Metadata: 0x0069FD99 */); // 0x00000001820369C0-0x0000000182036A80
		internal void InitRendererLists(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, ref PassData passData, RenderGraph renderGraph, bool zWriteOff); // 0x0000000182036A80-0x0000000182036E70
		internal static bool CanDisableZWrite(UniversalCameraData cameraData, bool isOpaque); // 0x00000001820365D0-0x0000000182036620
		internal void Render(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle colorTarget, [IsReadOnly] in TextureHandle depthTarget, [IsReadOnly] in TextureHandle mainShadowsTexture, [IsReadOnly] in TextureHandle additionalShadowsTexture, uint batchLayerMask = 4294967295 /* Metadata: 0x0069FD9A */, bool isMainOpaquePass = false /* Metadata: 0x0069FD9B */); // 0x00000001820371D0-0x0000000182037FE0
	}
}
