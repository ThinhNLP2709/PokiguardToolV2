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
	internal sealed class UberPostProcessPass : PostProcessPass // TypeDefIndex: 9637
	{
		// Fields
		private Material m_Material; // 0x68
		private Texture2D[] m_FilmGrainTextures; // 0x70
		private Texture m_DitherTexture; // 0x78
		private RTHandle m_UserLut; // 0x80
		private FilteringOperation m_FilteringOperation; // 0x88
		private HDROutputUtils.Operation m_HdrOperations; // 0x8C
		private bool m_IsValid; // 0x90
		private bool m_IsFinalPass; // 0x91
		private bool m_RequireSRGBConversionBlit; // 0x92
		private bool m_RenderOverlayUI; // 0x93
		private const string _CameraColorAfterPostProcessingName = "_CameraColorAfterPostProcessing"; // Metadata: 0x0069EDF1
	
		// Nested types
		public enum FilteringOperation // TypeDefIndex: 9638
		{
			Linear = 0,
			Point = 1
		}
	
		private class UberPostPassData // TypeDefIndex: 9639
		{
			// Fields
			internal TextureHandle destinationTexture; // 0x10
			internal TextureHandle sourceTexture; // 0x20
			internal TextureHandle internalLutTexture; // 0x30
			internal Material material; // 0x40
			internal UniversalCameraData cameraData; // 0x48
			internal Tonemapping tonemapping; // 0x50
			internal FilteringOperation filteringOperation; // 0x58
			internal HDROutputUtils.Operation hdrOperations; // 0x5C
			internal bool isHdrGrading; // 0x60
			internal LutParams lut; // 0x64
			internal BloomParams bloom; // 0xA8
			internal LensDistortionParams lensDistortion; // 0xE8
			internal ChromaticAberrationParams chromaticAberration; // 0x10C
			internal VignetteParams vignette; // 0x114
			internal FilmGrainParams filmGrain; // 0x148
			internal DitheringParams dither; // 0x168
			internal bool isActiveTargetBackBuffer; // 0x180
			internal bool useFastSRGBLinearConversion; // 0x181
			internal bool requireSRGBConversionBlit; // 0x182
	
			// Constructors
			public UberPostPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		internal struct LutParams // TypeDefIndex: 9640
		{
			// Fields
			public TextureHandle internalLutTexture; // 0x00
			public TextureHandle activeUserLutTexture; // 0x10
			public Vector4 internalLutParams; // 0x20
			public Vector4 userLutParams; // 0x30
	
			// Methods
			public void Setup(ColorAdjustments colorAdjustments, ColorLookup colorLookup, int lutHeight, TextureHandle internalLutTexture, TextureHandle activeUserLutTexture); // 0x0000000181FAB9E0-0x0000000181FABA30
			public void Apply(Material material); // 0x0000000181FAB880-0x0000000181FAB9E0
			public static void CalcColorLutParams(ColorAdjustments colorAdjustments, ColorLookup colorLookup, int lutHeight, out Vector4 internalLutParams, out Vector4 userLutParams); // 0x0000000181FA0DB0-0x0000000181FA12D0
		}
	
		internal struct BloomParams // TypeDefIndex: 9641
		{
			// Fields
			public TextureHandle activeBloomTexture; // 0x00
			public Vector4 bloomParams; // 0x10
			public Texture dirtTexture; // 0x20
			public Vector4 dirtScaleOffset; // 0x28
			public float dirtIntensity; // 0x38
			public bool highQualityFiltering; // 0x3C
	
			// Methods
			public bool IsActive(); // 0x0000000181FA31E0-0x0000000181FA3230
			public void Setup(Bloom bloom, [IsReadOnly] in TextureDesc srcDesc, TextureHandle activeBloomTexture); // 0x0000000181FA3230-0x0000000181FA3290
			public void Apply(Material material); // 0x0000000181FA2B50-0x0000000181FA2D20
			public static void CalcBloomParams(Bloom bloom, [IsReadOnly] in TextureDesc srcDesc, out Vector4 bloomParams, out bool highQualityFiltering, out Texture dirtTexture, out Vector4 dirtScaleOffset, out float dirtIntensity); // 0x0000000181FA2D20-0x0000000181FA31E0
		}
	
		internal struct LensDistortionParams // TypeDefIndex: 9642
		{
			// Fields
			public Vector4 lensDistortionParams1; // 0x00
			public Vector4 lensDistortionParams2; // 0x10
			public bool lensDistortionActive; // 0x20
	
			// Methods
			public bool IsActive(); // 0x0000000180F1D2E0-0x0000000180F1D2F0
			public void Setup(LensDistortion lensDistortion, bool isSceneViewCamera); // 0x0000000181FA9510-0x0000000181FA9570
			public void Apply(Material material); // 0x0000000181FA9440-0x0000000181FA9510
			public static void CalcLensDistortionParams(LensDistortion lensDistortion, out Vector4 lensDistortionParams1, out Vector4 lensDistortionParams2); // 0x0000000181FA0910-0x0000000181FA0DB0
		}
	
		internal struct ChromaticAberrationParams // TypeDefIndex: 9643
		{
			// Fields
			public float chromaticAberrationIntensity; // 0x00
			public bool chromaticAberrationActive; // 0x04
	
			// Methods
			public bool IsActive(); // 0x00000001813282D0-0x00000001813282E0
			public void Setup(ChromaticAberration chromaticAberration); // 0x0000000181FA5290-0x0000000181FA52F0
			public void Apply(Material material); // 0x0000000181FA51F0-0x0000000181FA5290
		}
	
		internal struct VignetteParams // TypeDefIndex: 9644
		{
			// Fields
			public Vector4 vignetteParams1; // 0x00
			public Vector4 vignetteParams2; // 0x10
			public Vector4 vignetteXRCenter; // 0x20
			public bool hasXRCenter; // 0x30
	
			// Methods
			public void Setup(Vignette vignette, int width, int height, XRPass xrPass); // 0x0000000181FC1210-0x0000000181FC1360
			public void Apply(Material material); // 0x0000000181FC1120-0x0000000181FC1210
			public static void CalcVignetteParams(Vignette vignette, int width, int height, XRPass xrPass, out Vector4 vignetteParams1, out Vector4 vignetteParams2); // 0x0000000181FA16D0-0x0000000181FA1910
		}
	
		internal struct FilmGrainParams // TypeDefIndex: 9645
		{
			// Fields
			public Texture activeGrainTexture; // 0x00
			public Vector4 tilingParams; // 0x08
			public Vector2 grainParams; // 0x18
			private const float k_FilmGrainIntensityScale = 4f; // Metadata: 0x0069EE13
	
			// Methods
			public bool IsActive(); // 0x0000000181FA7AA0-0x0000000181FA7AF0
			public void Setup(FilmGrain filmGrain, Texture2D[] filmGrainTextures, int pixelWidth, int pixelHeight); // 0x0000000181FA0760-0x0000000181FA0910
			public void Apply(Material material); // 0x0000000181FA7A10-0x0000000181FA7AA0
			internal static void CalcFilmGrainParams(FilmGrain filmGrain, Texture2D[] filmGrainTextures, out Texture grainTexture, out Vector2 grainParams); // 0x0000000181F55920-0x0000000181F55CB0
		}
	
		internal struct DitheringParams // TypeDefIndex: 9646
		{
			// Fields
			public Texture activeDitherTexture; // 0x00
			public Vector4 tilingParams; // 0x08
	
			// Methods
			public bool IsActive(); // 0x0000000181FA7960-0x0000000181FA79B0
			public void Setup(Texture ditherTexture, int pixelWidth, int pixelHeight); // 0x0000000181FA06F0-0x0000000181FA0760
			public void Apply(Material material); // 0x0000000181FA7870-0x0000000181FA7960
		}
	
		internal static class ShaderConstants // TypeDefIndex: 9647
		{
			// Fields
			public static readonly int _Distortion_Params1; // 0x00
			public static readonly int _Distortion_Params2; // 0x04
			public static readonly int _Chroma_Params; // 0x08
			public static readonly int _Vignette_Params1; // 0x0C
			public static readonly int _Vignette_Params2; // 0x10
			public static readonly int _Vignette_ParamsXR; // 0x14
			public static readonly int _InternalLut; // 0x18
			public static readonly int _Lut_Params; // 0x1C
			public static readonly int _UserLut; // 0x20
			public static readonly int _UserLut_Params; // 0x24
			public static readonly int _Bloom_Texture; // 0x28
			public static readonly int _Bloom_Params; // 0x2C
			public static readonly int _LensDirt_Texture; // 0x30
			public static readonly int _LensDirt_Params; // 0x34
			public static readonly int _LensDirt_Intensity; // 0x38
	
			// Constructors
			static ShaderConstants(); // 0x0000000181FB4B30-0x0000000181FB4DE0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9648
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<UberPostPassData, RasterGraphContext> __9__16_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FBEF80-0x0000000181FBEFF0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__16_0(UberPostPassData data, RasterGraphContext context); // 0x0000000181FBADD0-0x0000000181FBB7F0
		}
	
		// Constructors
		public UberPostProcessPass(Shader shader, Texture2D[] filmGrainTextures); // 0x0000000181FC0CB0-0x0000000181FC0DD0
	
		// Methods
		public override void Dispose(); // 0x0000000181FBF300-0x0000000181FBF380
		public void Setup(Texture ditherTexture, FilteringOperation filteringOperation, HDROutputUtils.Operation hdrOperations, bool requireSRGBConversionBlit, bool isFinalPass, bool renderOverlayUI); // 0x0000000181FC0A00-0x0000000181FC0A70
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FBF380-0x0000000181FC0A00
		private TextureHandle TryGetCachedUserLutTextureHandle(RenderGraph renderGraph, ColorLookup colorLookup); // 0x0000000181FC0A70-0x0000000181FC0CB0
	}
}
