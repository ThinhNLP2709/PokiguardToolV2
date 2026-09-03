/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering
{
	internal class MipGenerator // TypeDefIndex: 9299
	{
		// Fields
		private ComputeShader m_ColorPyramidCS; // 0x10
		private ComputeShader m_DepthPyramidCS; // 0x18
		private Shader m_ColorPyramidPS; // 0x20
		private Material m_ColorPyramidPSMat; // 0x28
		private MaterialPropertyBlock m_PropertyBlockBlur; // 0x30
		private int m_DepthDownsampleKernel; // 0x38
		private int m_ColorDownsampleKernel; // 0x3C
		private int m_ColorGaussianKernel; // 0x40
		private bool m_PreferCompute; // 0x44
		private bool m_SupportCompute; // 0x45
		private LocalKeyword m_DisableTexture2DArrayColorKeyword; // 0x48
		private LocalKeyword m_DisableTexture2DArrayColorPSKeyword; // 0x60
		private LocalKeyword m_DisableTexture2DArrayDepthKeyword; // 0x78
		private LocalKeyword m_EnableCheckerboardKeyword; // 0x90
		public static readonly int _DepthMipChain; // 0x00
		public static readonly int _DepthPyramidConstants; // 0x04
		public static readonly int _Size; // 0x08
		public static readonly int _Source; // 0x0C
		public static readonly int _Destination; // 0x10
		public static readonly int _SourceMip; // 0x14
		public static readonly int _SrcScaleBias; // 0x18
		public static readonly int _SrcUvLimits; // 0x1C
		public static readonly string k_EnableCheckerboard; // 0x20
		public const int k_MinimumResolutionGaussian = 8; // Metadata: 0x0069E942
	
		// Nested types
		private class DepthPyramidPassData // TypeDefIndex: 9300
		{
			// Fields
			public PackedMipChainInfo info; // 0x10
			public ComputeShader cs; // 0x50
			public int kernel; // 0x58
			public TextureHandle depthTexture; // 0x5C
			public LocalKeyword disableTexture2DArrayKeyword; // 0x70
			public LocalKeyword enableCheckerboardKeyword; // 0x88
	
			// Constructors
			public DepthPyramidPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class PassDataMipChainRaster // TypeDefIndex: 9301
		{
			// Fields
			public MaterialPropertyBlock propertyBlock; // 0x10
			public Material material; // 0x18
			public TextureHandle source; // 0x20
			public int dstMipWidth; // 0x30
			public int dstMipHeight; // 0x34
			public int srcMipLevel; // 0x38
			public float scaleX; // 0x3C
			public float scaleY; // 0x40
			public float blurSourceTextureWidth; // 0x44
			public float blurSourceTextureHeight; // 0x48
			public LocalKeyword disableTexture2DArrayKeyword; // 0x50
			public bool sourceIsArray; // 0x68
	
			// Constructors
			public PassDataMipChainRaster(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private class PassDataMipChainCompute // TypeDefIndex: 9302
		{
			// Fields
			public int numTheadGroupX; // 0x10
			public int numTheadGroupY; // 0x14
			public int numTheadGroupZ; // 0x18
			public int srcMipWidth; // 0x1C
			public int srcMipHeight; // 0x20
			public int dstMipWidth; // 0x24
			public int dstMipHeight; // 0x28
			public int srcMipLevel; // 0x2C
			public TextureHandle tempDownsamplePyramid; // 0x30
			public TextureHandle destination; // 0x40
			public ComputeShader cs; // 0x50
			public LocalKeyword disableTexture2DArrayKeyword; // 0x58
			public int downsampleKernel; // 0x70
			public int gaussianKernel; // 0x74
			public bool sourceIsArray; // 0x78
	
			// Constructors
			public PassDataMipChainCompute(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9303
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<DepthPyramidPassData, ComputeGraphContext> __9__27_0; // 0x08
			public static BaseRenderFunc<PassDataMipChainRaster, RasterGraphContext> __9__30_0; // 0x10
			public static BaseRenderFunc<PassDataMipChainRaster, RasterGraphContext> __9__30_1; // 0x18
			public static BaseRenderFunc<PassDataMipChainCompute, ComputeGraphContext> __9__30_2; // 0x20
	
			// Constructors
			static __c(); // 0x0000000181F62440-0x0000000181F624B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RenderMinDepthPyramid_b__27_0(DepthPyramidPassData data, ComputeGraphContext context); // 0x0000000181F60FB0-0x0000000181F61560
			internal void _RenderColorGaussianPyramid_b__30_0(PassDataMipChainRaster data, RasterGraphContext context); // 0x0000000181F60BF0-0x0000000181F60C60
			internal void _RenderColorGaussianPyramid_b__30_1(PassDataMipChainRaster data, RasterGraphContext context); // 0x0000000181F60C60-0x0000000181F60CD0
			internal void _RenderColorGaussianPyramid_b__30_2(PassDataMipChainCompute data, ComputeGraphContext context); // 0x0000000181F60CD0-0x0000000181F60FB0
		}
	
		// Constructors
		public MipGenerator(bool preferCompute = true /* Metadata: 0x0069E941 */); // 0x0000000181F59260-0x0000000181F596F0
		static MipGenerator(); // 0x0000000181F590A0-0x0000000181F59260
	
		// Methods
		public void Release(); // 0x0000000181F57580-0x0000000181F575D0
		public void RenderMinDepthPyramid(RenderGraph renderGraph, TextureHandle depthTexture, ref PackedMipChainInfo depthBufferMipChainInfo); // 0x0000000181F58C50-0x0000000181F590A0
		public int RenderColorGaussianPyramid(RenderGraph renderGraph, Vector2Int size, TextureHandle source, TextureHandle destination); // 0x0000000181F575D0-0x0000000181F58C50
		private static void MipChainRasterBlurExecutePass(PassDataMipChainRaster data, RasterGraphContext context, bool isVertical); // 0x0000000181F57280-0x0000000181F57580
	}
}
