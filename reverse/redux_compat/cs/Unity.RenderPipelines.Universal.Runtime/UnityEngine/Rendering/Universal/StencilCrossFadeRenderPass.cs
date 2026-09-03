/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal sealed class StencilCrossFadeRenderPass // TypeDefIndex: 9674
	{
		// Fields
		private Material[] m_StencilDitherMaskSeedMaterials; // 0x10
		private readonly int _StencilDitherPattern; // 0x18
		private readonly int _StencilRefDitherMask; // 0x1C
		private readonly int _StencilWriteDitherMask; // 0x20
		private readonly ProfilingSampler m_ProfilingSampler; // 0x28
	
		// Nested types
		private class PassData // TypeDefIndex: 9675
		{
			// Fields
			public TextureHandle depthTarget; // 0x10
			public Material[] stencilDitherMaskSeedMaterials; // 0x20
	
			// Constructors
			public PassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9676
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__8_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FD71F0-0x0000000181FD7260
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Render_b__8_0(PassData data, RasterGraphContext context); // 0x0000000181FD6A10-0x0000000181FD6C40
		}
	
		// Constructors
		internal StencilCrossFadeRenderPass(Shader shader); // 0x0000000181FD56D0-0x0000000181FD59C0
	
		// Methods
		public void Dispose(); // 0x0000000181FD5090-0x0000000181FD5160
		public void Render(RenderGraph renderGraph, ScriptableRenderContext context, [IsReadOnly] in TextureHandle depthTarget); // 0x0000000181FD5330-0x0000000181FD56D0
		private static void ExecutePass(RasterCommandBuffer cmd, RTHandle depthTarget, Material[] stencilDitherMaskSeedMaterials); // 0x0000000181FD5160-0x0000000181FD5330
	}
}
