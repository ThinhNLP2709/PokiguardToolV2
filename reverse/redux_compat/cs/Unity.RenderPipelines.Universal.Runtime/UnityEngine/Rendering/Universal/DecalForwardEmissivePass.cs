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
	internal class DecalForwardEmissivePass : ScriptableRenderPass // TypeDefIndex: 9407
	{
		// Fields
		private FilteringSettings m_FilteringSettings; // 0x60
		private List<ShaderTagId> m_ShaderTagIdList; // 0x80
		private DecalDrawFowardEmissiveSystem m_DrawSystem; // 0x88
	
		// Nested types
		private class PassData // TypeDefIndex: 9408
		{
			// Fields
			internal DecalDrawFowardEmissiveSystem drawSystem; // 0x10
			internal RendererListHandle rendererList; // 0x18
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9409
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__8_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181F85A90-0x0000000181F85B00
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__8_0(PassData data, RasterGraphContext rgContext); // 0x0000000181F85830-0x0000000181F858E0
		}
	
		// Constructors
		public DecalForwardEmissivePass(DecalDrawFowardEmissiveSystem drawSystem); // 0x0000000181F797B0-0x0000000181F79AC0
	
		// Methods
		private void InitPassData(ref PassData passData); // 0x0000000181F78CD0-0x0000000181F78D00
		private RendererListParams InitRendererListParams(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData); // 0x0000000181F78D00-0x0000000181F78F60
		private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList); // 0x0000000181F6BB70-0x0000000181F6BBE0
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181F78F60-0x0000000181F797B0
	}
}
