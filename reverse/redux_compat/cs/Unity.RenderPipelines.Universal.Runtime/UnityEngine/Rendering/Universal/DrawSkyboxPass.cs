/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public class DrawSkyboxPass : ScriptableRenderPass // TypeDefIndex: 9561
	{
		// Nested types
		private class PassData // TypeDefIndex: 9562
		{
			// Fields
			internal XRPass xr; // 0x10
			internal RendererListHandle skyRendererListHandle; // 0x18
			internal Material material; // 0x28
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9563
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__5_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181F9B250-0x0000000181F9B2C0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__5_0(PassData data, RasterGraphContext context); // 0x0000000181F9AE70-0x0000000181F9AF70
		}
	
		// Constructors
		public DrawSkyboxPass(RenderPassEvent evt); // 0x0000000181F8FD00-0x0000000181F8FD80
	
		// Methods
		private RendererListHandle CreateSkyBoxRendererList(RenderGraph renderGraph, UniversalCameraData cameraData); // 0x0000000181F8F020-0x0000000181F8F400
		private static void ExecutePass(RasterCommandBuffer cmd, XRPass xr, RendererList rendererList); // 0x0000000181F8F400-0x0000000181F8F4D0
		private void InitPassData(ref PassData passData, [IsReadOnly] in XRPass xr, [IsReadOnly] in RendererListHandle handle); // 0x0000000181F8F4D0-0x0000000181F8F520
		internal void Render(RenderGraph renderGraph, ContextContainer frameData, ScriptableRenderContext context, [IsReadOnly] in TextureHandle colorTarget, [IsReadOnly] in TextureHandle depthTarget, Material skyboxMaterial); // 0x0000000181F8F520-0x0000000181F8FD00
	}
}
