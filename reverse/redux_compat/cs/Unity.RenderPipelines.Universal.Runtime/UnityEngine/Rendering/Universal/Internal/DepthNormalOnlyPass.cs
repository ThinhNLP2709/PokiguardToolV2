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
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal.Internal
{
	public class DepthNormalOnlyPass : ScriptableRenderPass // TypeDefIndex: 9913
	{
		// Fields
		[CompilerGenerated]
		private List<ShaderTagId> _shaderTagIds_k__BackingField; // 0x60
		[CompilerGenerated]
		private bool _enableRenderingLayers_k__BackingField; // 0x68
		[CompilerGenerated]
		private RenderingLayerUtils.MaskSize _renderingLayersMaskSize_k__BackingField; // 0x6C
		private FilteringSettings m_FilteringSettings; // 0x70
		private static readonly List<ShaderTagId> k_DepthNormals; // 0x00
		private static readonly List<ShaderTagId> k_DepthNormalsOnly; // 0x08
		internal static readonly string k_CameraNormalsTextureName; // 0x10
		private static readonly int s_CameraDepthTextureID; // 0x18
		private static readonly int s_CameraNormalsTextureID; // 0x1C
		private static readonly int s_CameraRenderingLayersTextureID; // 0x20
	
		// Properties
		internal List<ShaderTagId> shaderTagIds { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		internal bool enableRenderingLayers { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180B25580-0x0000000180B25590 0x0000000180B262C0-0x0000000180B262D0
		internal RenderingLayerUtils.MaskSize renderingLayersMaskSize { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C55C40-0x0000000180C55C50 0x0000000180C55C60-0x0000000180C55C70
	
		// Nested types
		private class PassData // TypeDefIndex: 9914
		{
			// Fields
			internal bool enableRenderingLayers; // 0x10
			internal bool outputSmoothness; // 0x11
			internal RenderingLayerUtils.MaskSize maskSize; // 0x14
			internal RendererListHandle rendererList; // 0x18
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9915
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__27_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182041510-0x0000000182041580
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__27_0(PassData data, RasterGraphContext context); // 0x0000000182040E80-0x00000001820410B0
		}
	
		// Constructors
		public DepthNormalOnlyPass(RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask, ProfilingSampler sampler = null); // 0x0000000182035610-0x0000000182035780
		static DepthNormalOnlyPass(); // 0x00000001820352F0-0x0000000182035610
	
		// Methods
		public static GraphicsFormat GetGraphicsFormat(); // 0x0000000182034330-0x0000000182034390
		public void Setup(RTHandle depthHandle, RTHandle normalHandle); // 0x00000001820352D0-0x00000001820352E0
		public void Setup(RTHandle depthHandle, RTHandle normalHandle, RTHandle decalLayerHandle); // 0x00000001820352E0-0x00000001820352F0
		private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList); // 0x0000000182034170-0x0000000182034330
		public override void OnCameraCleanup(CommandBuffer cmd); // 0x0000000182034650-0x0000000182034710
		private RendererListParams InitRendererListParams(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData); // 0x00000001820343B0-0x0000000182034650
		internal void Render(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle cameraNormalsTexture, [IsReadOnly] in TextureHandle depthTexture, [IsReadOnly] in TextureHandle renderingLayersTexture, uint batchLayerMask, bool setGlobalDepth, bool setGlobalNormalAndRenderingLayers, bool allowPartialPass); // 0x0000000182034710-0x00000001820352D0
		protected virtual SortingCriteria GetSortingCriteria(UniversalCameraData cameraData); // 0x0000000182034390-0x00000001820343B0
	}
}
