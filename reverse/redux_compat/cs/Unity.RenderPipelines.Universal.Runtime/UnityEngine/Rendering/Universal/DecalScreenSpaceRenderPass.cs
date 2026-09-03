/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DecalScreenSpaceRenderPass : ScriptableRenderPass // TypeDefIndex: 9444
	{
		// Fields
		private FilteringSettings m_FilteringSettings; // 0x60
		private List<ShaderTagId> m_ShaderTagIdList; // 0x80
		private DecalDrawScreenSpaceSystem m_DrawSystem; // 0x88
		private DecalScreenSpaceSettings m_Settings; // 0x90
		private bool m_DecalLayers; // 0x98
	
		// Nested types
		private class PassData // TypeDefIndex: 9445
		{
			// Fields
			internal DecalDrawScreenSpaceSystem drawSystem; // 0x10
			internal DecalScreenSpaceSettings settings; // 0x18
			internal bool decalLayers; // 0x20
			internal bool isGLDevice; // 0x21
			internal TextureHandle colorTarget; // 0x24
			internal UniversalCameraData cameraData; // 0x38
			internal RendererListHandle rendererList; // 0x40
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9446
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__10_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181F85B00-0x0000000181F85B70
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__10_0(PassData data, RasterGraphContext rgContext); // 0x0000000181F851A0-0x0000000181F85410
		}
	
		// Constructors
		public DecalScreenSpaceRenderPass(DecalScreenSpaceSettings settings, DecalDrawScreenSpaceSystem drawSystem, bool decalLayers); // 0x0000000181F7DBE0-0x0000000181F7DEF0
	
		// Methods
		private RendererListParams CreateRenderListParams(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData); // 0x0000000181F7C970-0x0000000181F7CBC0
		private void InitPassData(UniversalCameraData cameraData, ref PassData passData); // 0x0000000181F7CD70-0x0000000181F7CE50
		private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList); // 0x0000000181F7CBC0-0x0000000181F7CD70
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181F7CF70-0x0000000181F7DBE0
		public override void OnCameraCleanup(CommandBuffer cmd); // 0x0000000181F7CE50-0x0000000181F7CF70
	}
}
