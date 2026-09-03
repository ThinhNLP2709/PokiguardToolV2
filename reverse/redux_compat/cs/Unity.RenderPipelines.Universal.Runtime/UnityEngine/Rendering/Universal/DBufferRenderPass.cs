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

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DBufferRenderPass : ScriptableRenderPass // TypeDefIndex: 9403
	{
		// Fields
		internal static readonly string[] s_DBufferNames; // 0x00
		internal static readonly string s_DBufferDepthName; // 0x08
		private static readonly int s_SSAOTextureID; // 0x10
		private DecalDrawDBufferSystem m_DrawSystem; // 0x60
		private DBufferSettings m_Settings; // 0x68
		private FilteringSettings m_FilteringSettings; // 0x70
		private List<ShaderTagId> m_ShaderTagIdList; // 0x90
		private bool m_DecalLayers; // 0x98
		private TextureHandle[] dbufferHandles; // 0xA0
	
		// Nested types
		private class PassData // TypeDefIndex: 9404
		{
			// Fields
			internal DecalDrawDBufferSystem drawSystem; // 0x10
			internal DBufferSettings settings; // 0x18
			internal bool decalLayers; // 0x20
			internal RTHandle dBufferDepth; // 0x28
			internal RTHandle[] dBufferColorHandles; // 0x30
			internal RendererListHandle rendererList; // 0x38
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9405
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__15_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181F85D30-0x0000000181F85DA0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__15_0(PassData data, RasterGraphContext rgContext); // 0x0000000181F855E0-0x0000000181F857C0
		}
	
		// Constructors
		public DBufferRenderPass(Material dBufferClear, DBufferSettings settings, DecalDrawDBufferSystem drawSystem, bool decalLayers); // 0x0000000181F6D9A0-0x0000000181F6DCD0
		static DBufferRenderPass(); // 0x0000000181F6D800-0x0000000181F6D9A0
	
		// Methods
		private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList, bool renderGraph); // 0x0000000181F6BB70-0x0000000181F6BBE0
		private static void SetKeywords(RasterCommandBuffer cmd, PassData passData); // 0x0000000181F6D6E0-0x0000000181F6D800
		private void InitPassData(ref PassData passData); // 0x0000000181F6BBE0-0x0000000181F6BC50
		private RendererListParams InitRendererListParams(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData); // 0x0000000181F6BC50-0x0000000181F6BEC0
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181F6BFE0-0x0000000181F6D6E0
		public override void OnCameraCleanup(CommandBuffer cmd); // 0x0000000181F6BEC0-0x0000000181F6BFE0
	}
}
