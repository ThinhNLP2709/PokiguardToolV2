/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal.Internal
{
	internal class GBufferPass : ScriptableRenderPass // TypeDefIndex: 9931
	{
		// Fields
		private static readonly int s_CameraNormalsTextureID; // 0x00
		private static readonly int s_CameraRenderingLayersTextureID; // 0x04
		private static readonly ShaderTagId s_ShaderTagLit; // 0x08
		private static readonly ShaderTagId s_ShaderTagSimpleLit; // 0x0C
		private static readonly ShaderTagId s_ShaderTagUnlit; // 0x10
		private static readonly ShaderTagId s_ShaderTagComplexLit; // 0x14
		private static readonly ShaderTagId s_ShaderTagBakedLit; // 0x18
		private static readonly ShaderTagId s_ShaderTagUniversalGBuffer; // 0x1C
		private static readonly ShaderTagId s_ShaderTagUniversalMaterialType; // 0x20
		private DeferredLights m_DeferredLights; // 0x60
		private static readonly ShaderTagId[] s_ShaderTagValues; // 0x28
		private RenderStateBlock[] m_RenderStateBlocks; // 0x68
		private FilteringSettings m_FilteringSettings; // 0x70
		private RenderStateBlock m_RenderStateBlock; // 0x90
	
		// Nested types
		private class PassData // TypeDefIndex: 9932
		{
			// Fields
			internal DeferredLights deferredLights; // 0x10
			internal RendererListHandle rendererListHdl; // 0x18
			internal RendererListHandle objectsWithErrorRendererListHdl; // 0x24
			internal TextureHandle screenSpaceIrradianceHdl; // 0x30
			internal TextureHandle screenSpaceReflectionHdl; // 0x40
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9933
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__18_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001820416D0-0x0000000182041740
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__18_0(PassData data, RasterGraphContext context); // 0x00000001820409A0-0x0000000182040AD0
		}
	
		// Constructors
		public GBufferPass(RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask, StencilState stencilState, int stencilReference, DeferredLights deferredLights); // 0x000000018203B970-0x000000018203C170
		static GBufferPass(); // 0x000000018203B670-0x000000018203B970
	
		// Methods
		private static void ExecutePass(RasterCommandBuffer cmd, PassData data, RendererList rendererList, RendererList errorRendererList); // 0x000000018203A2B0-0x000000018203A580
		private void InitRendererLists(ref PassData passData, ScriptableRenderContext context, RenderGraph renderGraph, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, uint batchLayerMask = 4294967295 /* Metadata: 0x0069FDC4 */); // 0x000000018203A580-0x000000018203A9F0
		internal void Render(RenderGraph renderGraph, ContextContainer frameData, bool setGlobalTextures, uint batchLayerMask = 4294967295 /* Metadata: 0x0069FDC5 */); // 0x000000018203A9F0-0x000000018203B670
	}
}
