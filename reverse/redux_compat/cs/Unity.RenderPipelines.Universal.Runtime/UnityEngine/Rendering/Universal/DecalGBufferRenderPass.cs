/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal.Internal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class DecalGBufferRenderPass : ScriptableRenderPass // TypeDefIndex: 9440
	{
		// Fields
		private FilteringSettings m_FilteringSettings; // 0x60
		private List<ShaderTagId> m_ShaderTagIdList; // 0x80
		private DecalDrawGBufferSystem m_DrawSystem; // 0x88
		private DecalScreenSpaceSettings m_Settings; // 0x90
		private DeferredLights m_DeferredLights; // 0x98
		private bool m_DecalLayers; // 0xA0
	
		// Nested types
		private class PassData // TypeDefIndex: 9441
		{
			// Fields
			internal DecalDrawGBufferSystem drawSystem; // 0x10
			internal DecalScreenSpaceSettings settings; // 0x18
			internal bool decalLayers; // 0x20
			internal UniversalCameraData cameraData; // 0x28
			internal RendererListHandle rendererList; // 0x30
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9442
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__11_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181F85B70-0x0000000181F85BE0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__11_0(PassData data, RasterGraphContext rgContext); // 0x0000000181F85410-0x0000000181F855E0
		}
	
		// Constructors
		public DecalGBufferRenderPass(DecalScreenSpaceSettings settings, DecalDrawGBufferSystem drawSystem, bool decalLayers); // 0x0000000181F7A900-0x0000000181F7AC10
	
		// Methods
		internal void Setup(DeferredLights deferredLights); // 0x00000001806CCE20-0x00000001806CCE40
		private void InitPassData(UniversalCameraData cameraData, ref PassData passData); // 0x0000000181F79C60-0x0000000181F79CF0
		private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList); // 0x0000000181F79AC0-0x0000000181F79C60
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181F79E10-0x0000000181F7A900
		public override void OnCameraCleanup(CommandBuffer cmd); // 0x0000000181F79CF0-0x0000000181F79E10
	}
}
