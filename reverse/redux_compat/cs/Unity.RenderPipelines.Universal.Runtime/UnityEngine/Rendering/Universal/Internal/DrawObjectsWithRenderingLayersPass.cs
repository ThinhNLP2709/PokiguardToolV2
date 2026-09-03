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
	internal class DrawObjectsWithRenderingLayersPass : DrawObjectsPass // TypeDefIndex: 9922
	{
		// Nested types
		private class RenderingLayersPassData // TypeDefIndex: 9923
		{
			// Fields
			internal DrawObjectsPass.PassData basePassData; // 0x10
			internal RenderingLayerUtils.MaskSize maskSize; // 0x18
	
			// Constructors
			public RenderingLayersPassData(); // 0x000000018203FA50-0x000000018203FAC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9924
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<RenderingLayersPassData, RasterGraphContext> __9__2_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182041740-0x00000001820417B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__2_0(RenderingLayersPassData data, RasterGraphContext context); // 0x00000001820410B0-0x00000001820413C0
		}
	
		// Constructors
		internal DrawObjectsWithRenderingLayersPass(ProfilingSampler sampler, bool opaque, RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask, StencilState stencilState, int stencilReference); // 0x0000000182038FB0-0x0000000182039100
	
		// Methods
		internal void Render(RenderGraph renderGraph, ContextContainer frameData, [IsReadOnly] in TextureHandle colorTarget, [IsReadOnly] in TextureHandle renderingLayersTexture, [IsReadOnly] in TextureHandle depthTarget, [IsReadOnly] in TextureHandle mainShadowsTexture, [IsReadOnly] in TextureHandle additionalShadowsTexture, RenderingLayerUtils.MaskSize maskSize, uint batchLayerMask = 4294967295 /* Metadata: 0x0069FD9C */); // 0x0000000182038400-0x0000000182038FB0
	}
}
