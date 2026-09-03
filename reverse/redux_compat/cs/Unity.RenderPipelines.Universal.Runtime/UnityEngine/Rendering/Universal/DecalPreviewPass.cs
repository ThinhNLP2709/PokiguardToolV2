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
	internal class DecalPreviewPass : ScriptableRenderPass // TypeDefIndex: 9411
	{
		// Fields
		private FilteringSettings m_FilteringSettings; // 0x60
		private List<ShaderTagId> m_ShaderTagIdList; // 0x80
		private ProfilingSampler m_ProfilingSampler; // 0x88
	
		// Nested types
		private class PassData // TypeDefIndex: 9412
		{
			// Fields
			internal RendererListHandle rendererList; // 0x10
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9413
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__6_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181F85C50-0x0000000181F85CC0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__6_0(PassData data, RasterGraphContext rgContext); // 0x0000000181F857C0-0x0000000181F85830
		}
	
		// Constructors
		public DecalPreviewPass(); // 0x0000000181F7B350-0x0000000181F7B580
	
		// Methods
		private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList); // 0x0000000181F7AC10-0x0000000181F7AC50
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181F7AC50-0x0000000181F7B350
	}
}
