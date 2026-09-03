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
	internal sealed class FinalPostProcessPass : PostProcessPass // TypeDefIndex: 9594
	{
		// Fields
		private static readonly ProfilingSampler k_ProfilingSampler; // 0x00
		private Material m_Material; // 0x68
		private Texture2D[] m_FilmGrainTextures; // 0x70
		private bool m_IsValid; // 0x78
		private Texture m_DitherTexture; // 0x80
		private FilteringOperation m_FilteringOperation; // 0x88
		private HDROutputUtils.Operation m_HdrOperations; // 0x8C
		private bool m_ApplySrgbEncoding; // 0x90
		private bool m_ApplyFxaa; // 0x91
		private bool m_RenderOverlayUI; // 0x92
	
		// Nested types
		public enum FilteringOperation // TypeDefIndex: 9595
		{
			Linear = 0,
			Point = 1,
			TaaSharpening = 2,
			FsrSharpening = 3
		}
	
		private class PostProcessingFinalBlitPassData // TypeDefIndex: 9596
		{
			// Fields
			internal TextureHandle destinationTexture; // 0x10
			internal TextureHandle sourceTexture; // 0x20
			internal Material material; // 0x30
			internal UniversalCameraData cameraData; // 0x38
			internal Tonemapping tonemapping; // 0x40
			internal FilteringOperation filteringOperation; // 0x48
			internal HDROutputUtils.Operation hdrOperations; // 0x4C
			internal UberPostProcessPass.FilmGrainParams filmGrain; // 0x50
			internal UberPostProcessPass.DitheringParams dithering; // 0x70
			internal bool applySrgbEncoding; // 0x88
			internal bool applyFxaa; // 0x89
	
			// Constructors
			public PostProcessingFinalBlitPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		public static class ShaderConstants // TypeDefIndex: 9597
		{
			// Fields
			public static readonly int _SourceSize; // 0x00
			public static readonly int _BlitScaleBias; // 0x04
			public static readonly int _BlitTexture; // 0x08
	
			// Constructors
			static ShaderConstants(); // 0x0000000181FB52C0-0x0000000181FB5370
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9598
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PostProcessingFinalBlitPassData, RasterGraphContext> __9__15_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBEDC0-0x0000000181FBEE30
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__15_0(PostProcessingFinalBlitPassData data, RasterGraphContext context); // 0x0000000181FBA690-0x0000000181FBADD0
		}
	
		// Constructors
		public FinalPostProcessPass(Shader shader, Texture2D[] filmGrainTextures); // 0x0000000181FA85E0-0x0000000181FA86F0
		static FinalPostProcessPass(); // 0x0000000181FA8570-0x0000000181FA85E0
	
		// Methods
		public override void Dispose(); // 0x0000000181FA7AF0-0x0000000181FA7B50
		public void Setup(Texture ditherTexture, FilteringOperation filteringOperation, HDROutputUtils.Operation hdrOperations, bool applySrgbEncoding, bool applyFxaa, bool renderOverlayUI); // 0x0000000181FA8500-0x0000000181FA8570
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FA7B50-0x0000000181FA8500
	}
}
