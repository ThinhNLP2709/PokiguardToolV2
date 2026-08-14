namespace UnityEngine.Rendering.Universal;

internal class PostProcessPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Light, Camera, Vector3, Single> <>9__99_0; //Field offset: 0x8
		public static Func<Light, Camera, Vector3, Single> <>9__99_1; //Field offset: 0x10
		public static BaseRenderFunc<UpdateCameraResolutionPassData, UnsafeGraphContext> <>9__123_0; //Field offset: 0x18
		public static BaseRenderFunc<StopNaNsPassData, RasterGraphContext> <>9__125_0; //Field offset: 0x20
		public static BaseRenderFunc<SMAASetupPassData, RasterGraphContext> <>9__128_0; //Field offset: 0x28
		public static BaseRenderFunc<SMAAPassData, RasterGraphContext> <>9__128_1; //Field offset: 0x30
		public static BaseRenderFunc<SMAAPassData, RasterGraphContext> <>9__128_2; //Field offset: 0x38
		public static BaseRenderFunc<SMAAPassData, RasterGraphContext> <>9__128_3; //Field offset: 0x40
		public static BaseRenderFunc<UberSetupBloomPassData, RasterGraphContext> <>9__130_0; //Field offset: 0x48
		public static BaseRenderFunc<BloomPassData, UnsafeGraphContext> <>9__133_0; //Field offset: 0x50
		public static BaseRenderFunc<DoFGaussianPassData, UnsafeGraphContext> <>9__136_0; //Field offset: 0x58
		public static BaseRenderFunc<DoFBokehPassData, UnsafeGraphContext> <>9__138_0; //Field offset: 0x60
		public static BaseRenderFunc<PaniniProjectionPassData, RasterGraphContext> <>9__140_0; //Field offset: 0x68
		public static BaseRenderFunc<MotionBlurPassData, RasterGraphContext> <>9__146_0; //Field offset: 0x70
		public static BaseRenderFunc<LensFlarePassData, UnsafeGraphContext> <>9__148_0; //Field offset: 0x78
		public static Func<Light, Camera, Vector3, Single> <>9__149_1; //Field offset: 0x80
		public static Func<Light, Camera, Vector3, Single> <>9__149_2; //Field offset: 0x88
		public static BaseRenderFunc<LensFlarePassData, UnsafeGraphContext> <>9__149_0; //Field offset: 0x90
		public static BaseRenderFunc<LensFlareScreenSpacePassData, UnsafeGraphContext> <>9__151_0; //Field offset: 0x98
		public static BaseRenderFunc<PostProcessingFinalSetupPassData, RasterGraphContext> <>9__154_0; //Field offset: 0xA0
		public static BaseRenderFunc<PostProcessingFinalFSRScalePassData, RasterGraphContext> <>9__156_0; //Field offset: 0xA8
		public static BaseRenderFunc<PostProcessingFinalBlitPassData, RasterGraphContext> <>9__159_0; //Field offset: 0xB0
		public static BaseRenderFunc<UberPostPassData, RasterGraphContext> <>9__163_0; //Field offset: 0xB8
		public static BaseRenderFunc<PostFXSetupPassData, RasterGraphContext> <>9__165_0; //Field offset: 0xC0

		private static <>c() { }

		public <>c() { }

		internal float <LensFlareDataDriven>b__99_0(Light light, Camera cam, Vector3 wo) { }

		internal float <LensFlareDataDriven>b__99_1(Light light, Camera cam, Vector3 wo) { }

		internal void <LensFlareDataDrivenComputeOcclusion>b__148_0(LensFlarePassData data, UnsafeGraphContext ctx) { }

		internal void <RenderBloomTexture>b__133_0(BloomPassData data, UnsafeGraphContext context) { }

		internal void <RenderDoFBokeh>b__138_0(DoFBokehPassData data, UnsafeGraphContext context) { }

		internal void <RenderDoFGaussian>b__136_0(DoFGaussianPassData data, UnsafeGraphContext context) { }

		internal void <RenderFinalBlit>b__159_0(PostProcessingFinalBlitPassData data, RasterGraphContext context) { }

		internal void <RenderFinalFSRScale>b__156_0(PostProcessingFinalFSRScalePassData data, RasterGraphContext context) { }

		internal void <RenderFinalSetup>b__154_0(PostProcessingFinalSetupPassData data, RasterGraphContext context) { }

		internal void <RenderLensFlareDataDriven>b__149_0(LensFlarePassData data, UnsafeGraphContext ctx) { }

		internal float <RenderLensFlareDataDriven>b__149_1(Light light, Camera cam, Vector3 wo) { }

		internal float <RenderLensFlareDataDriven>b__149_2(Light light, Camera cam, Vector3 wo) { }

		internal void <RenderLensFlareScreenSpace>b__151_0(LensFlareScreenSpacePassData data, UnsafeGraphContext context) { }

		internal void <RenderMotionBlur>b__146_0(MotionBlurPassData data, RasterGraphContext context) { }

		internal void <RenderPaniniProjection>b__140_0(PaniniProjectionPassData data, RasterGraphContext context) { }

		internal void <RenderPostProcessingRenderGraph>b__165_0(PostFXSetupPassData data, RasterGraphContext context) { }

		internal void <RenderSMAA>b__128_0(SMAASetupPassData data, RasterGraphContext context) { }

		internal void <RenderSMAA>b__128_1(SMAAPassData data, RasterGraphContext context) { }

		internal void <RenderSMAA>b__128_2(SMAAPassData data, RasterGraphContext context) { }

		internal void <RenderSMAA>b__128_3(SMAAPassData data, RasterGraphContext context) { }

		internal void <RenderStopNaN>b__125_0(StopNaNsPassData data, RasterGraphContext context) { }

		internal void <RenderUberPost>b__163_0(UberPostPassData data, RasterGraphContext context) { }

		internal void <UberPostSetupBloomPass>b__130_0(UberSetupBloomPassData data, RasterGraphContext context) { }

		internal void <UpdateCameraResolution>b__123_0(UpdateCameraResolutionPassData data, UnsafeGraphContext ctx) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass90_0
	{
		public RTHandle source; //Field offset: 0x0
		public RTHandle destination; //Field offset: 0x8
		public PostProcessPass <>4__this; //Field offset: 0x10
		public int amountOfPassesRemaining; //Field offset: 0x18
		public CommandBuffer cmd; //Field offset: 0x20

	}

	public struct BloomMaterialParams
	{
		internal Vector4 parameters; //Field offset: 0x0
		internal bool highQualityFiltering; //Field offset: 0x10
		internal bool enableAlphaOutput; //Field offset: 0x11

		internal bool Equals(ref BloomMaterialParams other) { }

	}

	private class BloomPassData
	{
		internal int mipCount; //Field offset: 0x10
		internal Material material; //Field offset: 0x18
		internal Material[] upsampleMaterials; //Field offset: 0x20
		internal TextureHandle sourceTexture; //Field offset: 0x28
		internal TextureHandle[] bloomMipUp; //Field offset: 0x38
		internal TextureHandle[] bloomMipDown; //Field offset: 0x40

		public BloomPassData() { }

	}

	private class DoFBokehPassData
	{
		internal Vector4[] bokehKernel; //Field offset: 0x10
		internal int downSample; //Field offset: 0x18
		internal float uvMargin; //Field offset: 0x1C
		internal Vector4 cocParams; //Field offset: 0x20
		internal bool useFastSRGBLinearConversion; //Field offset: 0x30
		internal TextureHandle sourceTexture; //Field offset: 0x34
		internal TextureHandle depthTexture; //Field offset: 0x44
		internal Material material; //Field offset: 0x58
		internal Material materialCoC; //Field offset: 0x60
		internal TextureHandle halfCoCTexture; //Field offset: 0x68
		internal TextureHandle fullCoCTexture; //Field offset: 0x78
		internal TextureHandle pingTexture; //Field offset: 0x88
		internal TextureHandle pongTexture; //Field offset: 0x98
		internal TextureHandle destination; //Field offset: 0xA8

		public DoFBokehPassData() { }

	}

	private class DoFGaussianPassData
	{
		internal int downsample; //Field offset: 0x10
		internal RenderingData renderingData; //Field offset: 0x18
		internal Vector3 cocParams; //Field offset: 0x40
		internal bool highQualitySamplingValue; //Field offset: 0x4C
		internal TextureHandle sourceTexture; //Field offset: 0x50
		internal TextureHandle depthTexture; //Field offset: 0x60
		internal Material material; //Field offset: 0x70
		internal Material materialCoC; //Field offset: 0x78
		internal TextureHandle halfCoCTexture; //Field offset: 0x80
		internal TextureHandle fullCoCTexture; //Field offset: 0x90
		internal TextureHandle pingTexture; //Field offset: 0xA0
		internal TextureHandle pongTexture; //Field offset: 0xB0
		internal RenderTargetIdentifier[] multipleRenderTargets; //Field offset: 0xC0
		internal TextureHandle destination; //Field offset: 0xC8

		public DoFGaussianPassData() { }

	}

	internal struct FinalBlitSettings
	{
		public bool isFxaaEnabled; //Field offset: 0x0
		public bool isFsrEnabled; //Field offset: 0x1
		public bool isTaaSharpeningEnabled; //Field offset: 0x2
		public bool requireHDROutput; //Field offset: 0x3
		public bool resolveToDebugScreen; //Field offset: 0x4
		public bool isAlphaOutputEnabled; //Field offset: 0x5
		public Operation hdrOperations; //Field offset: 0x8

		public static FinalBlitSettings Create() { }

	}

	private class LensFlarePassData
	{
		internal TextureHandle destinationTexture; //Field offset: 0x10
		internal RenderTextureDescriptor sourceDescriptor; //Field offset: 0x20
		internal UniversalCameraData cameraData; //Field offset: 0x58
		internal Material material; //Field offset: 0x60
		internal Rect viewport; //Field offset: 0x68
		internal float paniniDistance; //Field offset: 0x78
		internal float paniniCropToFit; //Field offset: 0x7C
		internal float width; //Field offset: 0x80
		internal float height; //Field offset: 0x84
		internal bool usePanini; //Field offset: 0x88

		public LensFlarePassData() { }

	}

	private class LensFlareScreenSpacePassData
	{
		internal TextureHandle destinationTexture; //Field offset: 0x10
		internal TextureHandle streakTmpTexture; //Field offset: 0x20
		internal TextureHandle streakTmpTexture2; //Field offset: 0x30
		internal TextureHandle originalBloomTexture; //Field offset: 0x40
		internal TextureHandle screenSpaceLensFlareBloomMipTexture; //Field offset: 0x50
		internal TextureHandle result; //Field offset: 0x60
		internal RenderTextureDescriptor sourceDescriptor; //Field offset: 0x70
		internal Camera camera; //Field offset: 0xA8
		internal Material material; //Field offset: 0xB0
		internal ScreenSpaceLensFlare lensFlareScreenSpace; //Field offset: 0xB8
		internal int downsample; //Field offset: 0xC0

		public LensFlareScreenSpacePassData() { }

	}

	private class MaterialLibrary
	{
		public readonly Material stopNaN; //Field offset: 0x10
		public readonly Material subpixelMorphologicalAntialiasing; //Field offset: 0x18
		public readonly Material gaussianDepthOfField; //Field offset: 0x20
		public readonly Material gaussianDepthOfFieldCoC; //Field offset: 0x28
		public readonly Material bokehDepthOfField; //Field offset: 0x30
		public readonly Material bokehDepthOfFieldCoC; //Field offset: 0x38
		public readonly Material cameraMotionBlur; //Field offset: 0x40
		public readonly Material paniniProjection; //Field offset: 0x48
		public readonly Material bloom; //Field offset: 0x50
		public readonly Material[] bloomUpsample; //Field offset: 0x58
		public readonly Material temporalAntialiasing; //Field offset: 0x60
		public readonly Material scalingSetup; //Field offset: 0x68
		public readonly Material easu; //Field offset: 0x70
		public readonly Material uber; //Field offset: 0x78
		public readonly Material finalPass; //Field offset: 0x80
		public readonly Material lensFlareDataDriven; //Field offset: 0x88
		public readonly Material lensFlareScreenSpace; //Field offset: 0x90

		public MaterialLibrary(PostProcessData data) { }

		internal void Cleanup() { }

		private Material Load(Shader shader) { }

	}

	private class MotionBlurPassData
	{
		internal TextureHandle destinationTexture; //Field offset: 0x10
		internal TextureHandle sourceTexture; //Field offset: 0x20
		internal TextureHandle motionVectors; //Field offset: 0x30
		internal Material material; //Field offset: 0x40
		internal int passIndex; //Field offset: 0x48
		internal Camera camera; //Field offset: 0x50
		internal XRPass xr; //Field offset: 0x58
		internal float intensity; //Field offset: 0x60
		internal float clamp; //Field offset: 0x64
		internal bool enableAlphaOutput; //Field offset: 0x68

		public MotionBlurPassData() { }

	}

	private class PaniniProjectionPassData
	{
		internal TextureHandle destinationTexture; //Field offset: 0x10
		internal TextureHandle sourceTexture; //Field offset: 0x20
		internal RenderTextureDescriptor sourceTextureDesc; //Field offset: 0x30
		internal Material material; //Field offset: 0x68
		internal Vector4 paniniParams; //Field offset: 0x70
		internal bool isPaniniGeneric; //Field offset: 0x80

		public PaniniProjectionPassData() { }

	}

	private class PostFXSetupPassData
	{

		public PostFXSetupPassData() { }

	}

	private class PostProcessingFinalBlitPassData
	{
		internal TextureHandle destinationTexture; //Field offset: 0x10
		internal TextureHandle sourceTexture; //Field offset: 0x20
		internal Material material; //Field offset: 0x30
		internal UniversalCameraData cameraData; //Field offset: 0x38
		internal FinalBlitSettings settings; //Field offset: 0x40

		public PostProcessingFinalBlitPassData() { }

	}

	private class PostProcessingFinalFSRScalePassData
	{
		internal TextureHandle destinationTexture; //Field offset: 0x10
		internal TextureHandle sourceTexture; //Field offset: 0x20
		internal Material material; //Field offset: 0x30
		internal bool enableAlphaOutput; //Field offset: 0x38

		public PostProcessingFinalFSRScalePassData() { }

	}

	private class PostProcessingFinalSetupPassData
	{
		internal TextureHandle destinationTexture; //Field offset: 0x10
		internal TextureHandle sourceTexture; //Field offset: 0x20
		internal Material material; //Field offset: 0x30
		internal UniversalCameraData cameraData; //Field offset: 0x38

		public PostProcessingFinalSetupPassData() { }

	}

	private static class ShaderConstants
	{
		public static readonly int _TempTarget; //Field offset: 0x0
		public static readonly int _TempTarget2; //Field offset: 0x4
		public static readonly int _StencilRef; //Field offset: 0x8
		public static readonly int _StencilMask; //Field offset: 0xC
		public static readonly int _FullCoCTexture; //Field offset: 0x10
		public static readonly int _HalfCoCTexture; //Field offset: 0x14
		public static readonly int _DofTexture; //Field offset: 0x18
		public static readonly int _CoCParams; //Field offset: 0x1C
		public static readonly int _BokehKernel; //Field offset: 0x20
		public static readonly int _BokehConstants; //Field offset: 0x24
		public static readonly int _PongTexture; //Field offset: 0x28
		public static readonly int _PingTexture; //Field offset: 0x2C
		public static readonly int _Metrics; //Field offset: 0x30
		public static readonly int _AreaTexture; //Field offset: 0x34
		public static readonly int _SearchTexture; //Field offset: 0x38
		public static readonly int _EdgeTexture; //Field offset: 0x3C
		public static readonly int _BlendTexture; //Field offset: 0x40
		public static readonly int _ColorTexture; //Field offset: 0x44
		public static readonly int _Params; //Field offset: 0x48
		public static readonly int _SourceTexLowMip; //Field offset: 0x4C
		public static readonly int _Bloom_Params; //Field offset: 0x50
		public static readonly int _Bloom_Texture; //Field offset: 0x54
		public static readonly int _LensDirt_Texture; //Field offset: 0x58
		public static readonly int _LensDirt_Params; //Field offset: 0x5C
		public static readonly int _LensDirt_Intensity; //Field offset: 0x60
		public static readonly int _Distortion_Params1; //Field offset: 0x64
		public static readonly int _Distortion_Params2; //Field offset: 0x68
		public static readonly int _Chroma_Params; //Field offset: 0x6C
		public static readonly int _Vignette_Params1; //Field offset: 0x70
		public static readonly int _Vignette_Params2; //Field offset: 0x74
		public static readonly int _Vignette_ParamsXR; //Field offset: 0x78
		public static readonly int _Lut_Params; //Field offset: 0x7C
		public static readonly int _UserLut_Params; //Field offset: 0x80
		public static readonly int _InternalLut; //Field offset: 0x84
		public static readonly int _UserLut; //Field offset: 0x88
		public static readonly int _DownSampleScaleFactor; //Field offset: 0x8C
		public static readonly int _FlareOcclusionRemapTex; //Field offset: 0x90
		public static readonly int _FlareOcclusionTex; //Field offset: 0x94
		public static readonly int _FlareOcclusionIndex; //Field offset: 0x98
		public static readonly int _FlareTex; //Field offset: 0x9C
		public static readonly int _FlareColorValue; //Field offset: 0xA0
		public static readonly int _FlareData0; //Field offset: 0xA4
		public static readonly int _FlareData1; //Field offset: 0xA8
		public static readonly int _FlareData2; //Field offset: 0xAC
		public static readonly int _FlareData3; //Field offset: 0xB0
		public static readonly int _FlareData4; //Field offset: 0xB4
		public static readonly int _FlareData5; //Field offset: 0xB8
		public static readonly int _FullscreenProjMat; //Field offset: 0xBC
		public static Int32[] _BloomMipUp; //Field offset: 0xC0
		public static Int32[] _BloomMipDown; //Field offset: 0xC8

		private static ShaderConstants() { }

	}

	private class SMAAPassData
	{
		internal TextureHandle destinationTexture; //Field offset: 0x10
		internal TextureHandle sourceTexture; //Field offset: 0x20
		internal TextureHandle depthStencilTexture; //Field offset: 0x30
		internal TextureHandle blendTexture; //Field offset: 0x40
		internal Material material; //Field offset: 0x50

		public SMAAPassData() { }

	}

	private class SMAASetupPassData
	{
		internal Vector4 metrics; //Field offset: 0x10
		internal Texture2D areaTexture; //Field offset: 0x20
		internal Texture2D searchTexture; //Field offset: 0x28
		internal float stencilRef; //Field offset: 0x30
		internal float stencilMask; //Field offset: 0x34
		internal AntialiasingQuality antialiasingQuality; //Field offset: 0x38
		internal Material material; //Field offset: 0x40

		public SMAASetupPassData() { }

	}

	private class StopNaNsPassData
	{
		internal TextureHandle stopNaNTarget; //Field offset: 0x10
		internal TextureHandle sourceTexture; //Field offset: 0x20
		internal Material stopNaN; //Field offset: 0x30

		public StopNaNsPassData() { }

	}

	private class UberPostPassData
	{
		internal TextureHandle destinationTexture; //Field offset: 0x10
		internal TextureHandle sourceTexture; //Field offset: 0x20
		internal TextureHandle lutTexture; //Field offset: 0x30
		internal Vector4 lutParams; //Field offset: 0x40
		internal TextureHandle userLutTexture; //Field offset: 0x50
		internal Vector4 userLutParams; //Field offset: 0x60
		internal Material material; //Field offset: 0x70
		internal UniversalCameraData cameraData; //Field offset: 0x78
		internal TonemappingMode toneMappingMode; //Field offset: 0x80
		internal bool isHdrGrading; //Field offset: 0x84
		internal bool isBackbuffer; //Field offset: 0x85
		internal bool enableAlphaOutput; //Field offset: 0x86
		internal bool hasFinalPass; //Field offset: 0x87

		public UberPostPassData() { }

	}

	private class UberSetupBloomPassData
	{
		internal Vector4 bloomParams; //Field offset: 0x10
		internal Vector4 dirtScaleOffset; //Field offset: 0x20
		internal float dirtIntensity; //Field offset: 0x30
		internal Texture dirtTexture; //Field offset: 0x38
		internal bool highQualityFilteringValue; //Field offset: 0x40
		internal TextureHandle bloomTexture; //Field offset: 0x44
		internal Material uberMaterial; //Field offset: 0x58

		public UberSetupBloomPassData() { }

	}

	private class UpdateCameraResolutionPassData
	{
		internal Vector2Int newCameraTargetSize; //Field offset: 0x10

		public UpdateCameraResolutionPassData() { }

	}

	private const string _UpscaledColorTargetName = "_UpscaledColorTarget"; //Field offset: 0x0
	private static readonly ProfilingSampler m_ProfilingRenderPostProcessing; //Field offset: 0x0
	private const string _TemporalAATargetName = "_TemporalAATarget"; //Field offset: 0x0
	private const int k_GaussianDoFPassComputeCoc = 0; //Field offset: 0x0
	private const int k_GaussianDoFPassDownscalePrefilter = 1; //Field offset: 0x0
	private const int k_GaussianDoFPassBlurH = 2; //Field offset: 0x0
	private const int k_GaussianDoFPassBlurV = 3; //Field offset: 0x0
	private const int k_GaussianDoFPassComposite = 4; //Field offset: 0x0
	private const int k_BokehDoFPassComputeCoc = 0; //Field offset: 0x0
	private const string k_RenderFinalPostProcessingTag = "Blit Final PostProcessing"; //Field offset: 0x0
	private const int k_BokehDoFPassDownscalePrefilter = 1; //Field offset: 0x0
	private const int k_BokehDoFPassPostFilter = 3; //Field offset: 0x0
	private const int k_BokehDoFPassComposite = 4; //Field offset: 0x0
	private const int k_MaxPyramidSize = 16; //Field offset: 0x0
	private const int k_BokehDoFPassBlur = 2; //Field offset: 0x0
	private const string k_RenderPostProcessingTag = "Blit PostProcessing Effects"; //Field offset: 0x0
	private static readonly ProfilingSampler m_ProfilingRenderFinalPostProcessing; //Field offset: 0x8
	internal static readonly int k_ShaderPropertyId_ViewProjM; //Field offset: 0x10
	internal static readonly int k_ShaderPropertyId_PrevViewProjM; //Field offset: 0x14
	internal static readonly int k_ShaderPropertyId_ViewProjMStereo; //Field offset: 0x18
	internal static readonly int k_ShaderPropertyId_PrevViewProjMStereo; //Field offset: 0x1C
	private static readonly int s_CameraDepthTextureID; //Field offset: 0x20
	private RenderTextureDescriptor m_Descriptor; //Field offset: 0xB8
	private RTHandle m_Source; //Field offset: 0xF0
	private RTHandle m_Destination; //Field offset: 0xF8
	private RTHandle m_Depth; //Field offset: 0x100
	private RTHandle m_InternalLut; //Field offset: 0x108
	private RTHandle m_MotionVectors; //Field offset: 0x110
	private RTHandle m_FullCoCTexture; //Field offset: 0x118
	private RTHandle m_HalfCoCTexture; //Field offset: 0x120
	private RTHandle m_PingTexture; //Field offset: 0x128
	private RTHandle m_PongTexture; //Field offset: 0x130
	private RTHandle[] m_BloomMipDown; //Field offset: 0x138
	private RTHandle[] m_BloomMipUp; //Field offset: 0x140
	private TextureHandle[] _BloomMipUp; //Field offset: 0x148
	private TextureHandle[] _BloomMipDown; //Field offset: 0x150
	private RTHandle m_BlendTexture; //Field offset: 0x158
	private RTHandle m_EdgeColorTexture; //Field offset: 0x160
	private RTHandle m_EdgeStencilTexture; //Field offset: 0x168
	private RTHandle m_TempTarget; //Field offset: 0x170
	private RTHandle m_TempTarget2; //Field offset: 0x178
	private RTHandle m_StreakTmpTexture; //Field offset: 0x180
	private RTHandle m_StreakTmpTexture2; //Field offset: 0x188
	private RTHandle m_ScreenSpaceLensFlareResult; //Field offset: 0x190
	private RTHandle m_UserLut; //Field offset: 0x198
	private MaterialLibrary m_Materials; //Field offset: 0x1A0
	private PostProcessData m_Data; //Field offset: 0x1A8
	private DepthOfField m_DepthOfField; //Field offset: 0x1B0
	private MotionBlur m_MotionBlur; //Field offset: 0x1B8
	private ScreenSpaceLensFlare m_LensFlareScreenSpace; //Field offset: 0x1C0
	private PaniniProjection m_PaniniProjection; //Field offset: 0x1C8
	private Bloom m_Bloom; //Field offset: 0x1D0
	private LensDistortion m_LensDistortion; //Field offset: 0x1D8
	private ChromaticAberration m_ChromaticAberration; //Field offset: 0x1E0
	private Vignette m_Vignette; //Field offset: 0x1E8
	private ColorLookup m_ColorLookup; //Field offset: 0x1F0
	private ColorAdjustments m_ColorAdjustments; //Field offset: 0x1F8
	private Tonemapping m_Tonemapping; //Field offset: 0x200
	private FilmGrain m_FilmGrain; //Field offset: 0x208
	private readonly GraphicsFormat m_DefaultColorFormat; //Field offset: 0x210
	private bool m_DefaultColorFormatIsAlpha; //Field offset: 0x214
	private readonly GraphicsFormat m_SMAAEdgeFormat; //Field offset: 0x218
	private readonly GraphicsFormat m_GaussianCoCFormat; //Field offset: 0x21C
	private int m_DitheringTextureIndex; //Field offset: 0x220
	private RenderTargetIdentifier[] m_MRT2; //Field offset: 0x228
	private Vector4[] m_BokehKernel; //Field offset: 0x230
	private int m_BokehHash; //Field offset: 0x238
	private float m_BokehMaxRadius; //Field offset: 0x23C
	private float m_BokehRCPAspect; //Field offset: 0x240
	private bool m_IsFinalPass; //Field offset: 0x244
	private bool m_HasFinalPass; //Field offset: 0x245
	private bool m_EnableColorEncodingIfNeeded; //Field offset: 0x246
	private bool m_UseFastSRGBLinearConversion; //Field offset: 0x247
	private bool m_SupportScreenSpaceLensFlare; //Field offset: 0x248
	private bool m_SupportDataDrivenLensFlare; //Field offset: 0x249
	private bool m_ResolveToScreen; //Field offset: 0x24A
	private bool m_UseSwapBuffer; //Field offset: 0x24B
	private RTHandle m_ScalingSetupTarget; //Field offset: 0x250
	private RTHandle m_UpscaledTarget; //Field offset: 0x258
	private Material m_BlitMaterial; //Field offset: 0x260
	private BloomMaterialParams m_BloomParamsPrev; //Field offset: 0x268

	private static PostProcessPass() { }

	public PostProcessPass(RenderPassEvent evt, PostProcessData data, ref PostProcessParams postProcessParams) { }

	[CompilerGenerated]
	private RTHandle <Render>g__GetDestination|90_1(ref <>c__DisplayClass90_0 unnamed_param_0) { }

	[CompilerGenerated]
	private RTHandle <Render>g__GetSource|90_0(ref <>c__DisplayClass90_0 unnamed_param_0) { }

	[CompilerGenerated]
	private void <Render>g__Swap|90_2(ref ScriptableRenderer r, ref <>c__DisplayClass90_0 unnamed_param_1) { }

	private Vector2 CalcCropExtents(Camera camera, float d) { }

	private Vector2 CalcViewExtents(Camera camera) { }

	public bool CanRunOnTile() { }

	public void Cleanup() { }

	public void Dispose() { }

	private void DoBokehDepthOfField(CommandBuffer cmd, RTHandle source, RTHandle destination, Rect pixelRect, bool enableAlphaOutput) { }

	private void DoDepthOfField(ref CameraData cameraData, CommandBuffer cmd, RTHandle source, RTHandle destination, Rect pixelRect) { }

	private void DoGaussianDepthOfField(CommandBuffer cmd, RTHandle source, RTHandle destination, Rect pixelRect, bool enableAlphaOutput) { }

	private void DoLensFlareScreenSpace(Camera camera, CommandBuffer cmd, RenderTargetIdentifier source, RTHandle originalBloomTexture, RTHandle screenSpaceLensFlareBloomMipTexture) { }

	private void DoMotionBlur(CommandBuffer cmd, RTHandle source, RTHandle destination, RTHandle motionVectors, ref CameraData cameraData) { }

	private void DoPaniniProjection(Camera camera, CommandBuffer cmd, RTHandle source, RTHandle destination) { }

	private void DoSubpixelMorphologicalAntialiasing(ref CameraData cameraData, CommandBuffer cmd, RTHandle source, RTHandle destination) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private RenderTextureDescriptor GetCompatibleDescriptor() { }

	private RenderTextureDescriptor GetCompatibleDescriptor(int width, int height, GraphicsFormat format, GraphicsFormat depthStencilFormat = 0) { }

	internal static RenderTextureDescriptor GetCompatibleDescriptor(RenderTextureDescriptor desc, int width, int height, GraphicsFormat format, GraphicsFormat depthStencilFormat = 0) { }

	private static float GetLensFlareLightAttenuation(Light light, Camera cam, Vector3 wo) { }

	private static float GetMaxBokehRadiusInPixels(float viewportHeight) { }

	private bool IsAlphaFormat(GraphicsFormat format) { }

	private bool IsHDRFormat(GraphicsFormat format) { }

	private void LensFlareDataDriven(ref UniversalCameraData cameraData, CommandBuffer cmd, RenderTargetIdentifier source, bool usePanini, float paniniDistance, float paniniCropToFit) { }

	private void LensFlareDataDrivenComputeOcclusion(ref UniversalCameraData cameraData, CommandBuffer cmd, RenderTargetIdentifier source, bool usePanini, float paniniDistance, float paniniCropToFit) { }

	private void LensFlareDataDrivenComputeOcclusion(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) { }

	private void PrepareBokehKernel(float maxRadius, float rcpAspect) { }

	private void Render(CommandBuffer cmd, ref RenderingData renderingData) { }

	public void RenderBloomTexture(RenderGraph renderGraph, in TextureHandle source, out TextureHandle destination, bool enableAlphaOutput) { }

	public void RenderDoF(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, in TextureHandle source, out TextureHandle destination) { }

	public void RenderDoFBokeh(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, in TextureHandle source, in TextureHandle destination, ref Material dofMaterial) { }

	public void RenderDoFGaussian(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, in TextureHandle source, TextureHandle destination, ref Material dofMaterial) { }

	public void RenderFinalBlit(RenderGraph renderGraph, UniversalCameraData cameraData, in TextureHandle source, in TextureHandle overlayUITexture, in TextureHandle postProcessingTarget, ref FinalBlitSettings settings) { }

	public void RenderFinalFSRScale(RenderGraph renderGraph, in TextureHandle source, in TextureHandle destination, bool enableAlphaOutput) { }

	private void RenderFinalPass(CommandBuffer cmd, ref RenderingData renderingData) { }

	public void RenderFinalPassRenderGraph(RenderGraph renderGraph, ContextContainer frameData, in TextureHandle source, in TextureHandle overlayUITexture, in TextureHandle postProcessingTarget, bool enableColorEncodingIfNeeded) { }

	public void RenderFinalSetup(RenderGraph renderGraph, UniversalCameraData cameraData, in TextureHandle source, in TextureHandle destination, ref FinalBlitSettings settings) { }

	public void RenderLensFlareDataDriven(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, in TextureHandle destination) { }

	public TextureHandle RenderLensFlareScreenSpace(RenderGraph renderGraph, Camera camera, in TextureHandle destination, TextureHandle originalBloomTexture, TextureHandle screenSpaceLensFlareBloomMipTexture, bool enableXR) { }

	public void RenderMotionBlur(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, in TextureHandle source, out TextureHandle destination) { }

	public void RenderPaniniProjection(RenderGraph renderGraph, Camera camera, in TextureHandle source, out TextureHandle destination) { }

	public void RenderPostProcessingRenderGraph(RenderGraph renderGraph, ContextContainer frameData, in TextureHandle activeCameraColorTexture, in TextureHandle lutTexture, in TextureHandle overlayUITexture, in TextureHandle postProcessingTarget, bool hasFinalPass, bool resolveToDebugScreen, bool enableColorEndingIfNeeded) { }

	public void RenderSMAA(RenderGraph renderGraph, UniversalResourceData resourceData, AntialiasingQuality antialiasingQuality, in TextureHandle source, out TextureHandle SMAATarget) { }

	public void RenderStopNaN(RenderGraph renderGraph, RenderTextureDescriptor cameraTargetDescriptor, in TextureHandle activeCameraColor, out TextureHandle stopNaNTarget) { }

	private void RenderSTP(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, ref TextureHandle source, out TextureHandle destination) { }

	private void RenderTemporalAA(RenderGraph renderGraph, UniversalResourceData resourceData, UniversalCameraData cameraData, ref TextureHandle source, out TextureHandle destination) { }

	public void RenderUberPost(RenderGraph renderGraph, ContextContainer frameData, UniversalCameraData cameraData, UniversalPostProcessingData postProcessingData, in TextureHandle sourceTexture, in TextureHandle destTexture, in TextureHandle lutTexture, in TextureHandle overlayUITexture, bool requireHDROutput, bool enableAlphaOutput, bool resolveToDebugScreen, bool hasFinalPass) { }

	private bool RequireHDROutput(UniversalCameraData cameraData) { }

	private bool RequireSRGBConversionBlitToBackBuffer(bool requireSrgbConversion) { }

	private static void ScaleViewportAndBlit(RasterCommandBuffer cmd, RTHandle sourceTextureHdl, RTHandle dest, UniversalCameraData cameraData, Material material, bool hasFinalPass) { }

	public void Setup(in RenderTextureDescriptor baseDescriptor, in RTHandle source, bool resolveToScreen, in RTHandle depth, in RTHandle internalLut, in RTHandle motionVectors, bool hasFinalPass, bool enableColorEncoding) { }

	public void Setup(in RenderTextureDescriptor baseDescriptor, in RTHandle source, RTHandle destination, in RTHandle depth, in RTHandle internalLut, bool hasFinalPass, bool enableColorEncoding) { }

	private void SetupBloom(CommandBuffer cmd, RTHandle source, Material uberMaterial, bool enableAlphaOutput) { }

	private void SetupChromaticAberration(Material material) { }

	private void SetupColorGrading(CommandBuffer cmd, ref RenderingData renderingData, Material material) { }

	private void SetupDithering(UniversalCameraData cameraData, Material material) { }

	public void SetupFinalPass(in RTHandle source, bool useSwapBuffer = false, bool enableColorEncoding = true) { }

	private void SetupGrain(UniversalCameraData cameraData, Material material) { }

	private void SetupHDROutput(HDRDisplayInformation hdrDisplayInformation, ColorGamut hdrDisplayColorGamut, Material material, Operation hdrOperations, bool rendersOverlayUI) { }

	private void SetupLensDistortion(Material material, bool isSceneView) { }

	private void SetupVignette(Material material, XRPass xrPass) { }

	private TextureHandle TryGetCachedUserLutTextureHandle(RenderGraph renderGraph) { }

	public void UberPostSetupBloomPass(RenderGraph rendergraph, in TextureHandle bloomTexture, Material uberMaterial) { }

	private void UpdateCameraResolution(RenderGraph renderGraph, UniversalCameraData cameraData, Vector2Int newCameraTargetSize) { }

	internal static void UpdateMotionBlurMatrices(ref Material material, Camera camera, XRPass xr) { }

}

