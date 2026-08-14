namespace UnityEngine.Rendering.Universal;

internal static class ShaderGlobalKeywords
{
	public static GlobalKeyword MainLightShadows; //Field offset: 0x0
	public static GlobalKeyword MainLightShadowCascades; //Field offset: 0x10
	public static GlobalKeyword MainLightShadowScreen; //Field offset: 0x20
	public static GlobalKeyword CastingPunctualLightShadow; //Field offset: 0x30
	public static GlobalKeyword AdditionalLightsVertex; //Field offset: 0x40
	public static GlobalKeyword AdditionalLightsPixel; //Field offset: 0x50
	public static GlobalKeyword ForwardPlus; //Field offset: 0x60
	public static GlobalKeyword AdditionalLightShadows; //Field offset: 0x70
	public static GlobalKeyword ReflectionProbeBoxProjection; //Field offset: 0x80
	public static GlobalKeyword ReflectionProbeBlending; //Field offset: 0x90
	public static GlobalKeyword SoftShadows; //Field offset: 0xA0
	public static GlobalKeyword SoftShadowsLow; //Field offset: 0xB0
	public static GlobalKeyword SoftShadowsMedium; //Field offset: 0xC0
	public static GlobalKeyword SoftShadowsHigh; //Field offset: 0xD0
	public static GlobalKeyword MixedLightingSubtractive; //Field offset: 0xE0
	public static GlobalKeyword LightmapShadowMixing; //Field offset: 0xF0
	public static GlobalKeyword ShadowsShadowMask; //Field offset: 0x100
	public static GlobalKeyword LightLayers; //Field offset: 0x110
	public static GlobalKeyword RenderPassEnabled; //Field offset: 0x120
	public static GlobalKeyword BillboardFaceCameraPos; //Field offset: 0x130
	public static GlobalKeyword LightCookies; //Field offset: 0x140
	public static GlobalKeyword DepthNoMsaa; //Field offset: 0x150
	public static GlobalKeyword DepthMsaa2; //Field offset: 0x160
	public static GlobalKeyword DepthMsaa4; //Field offset: 0x170
	public static GlobalKeyword DepthMsaa8; //Field offset: 0x180
	public static GlobalKeyword DBufferMRT1; //Field offset: 0x190
	public static GlobalKeyword DBufferMRT2; //Field offset: 0x1A0
	public static GlobalKeyword DBufferMRT3; //Field offset: 0x1B0
	public static GlobalKeyword DecalNormalBlendLow; //Field offset: 0x1C0
	public static GlobalKeyword DecalNormalBlendMedium; //Field offset: 0x1D0
	public static GlobalKeyword DecalNormalBlendHigh; //Field offset: 0x1E0
	public static GlobalKeyword DecalLayers; //Field offset: 0x1F0
	public static GlobalKeyword WriteRenderingLayers; //Field offset: 0x200
	public static GlobalKeyword ScreenSpaceOcclusion; //Field offset: 0x210
	public static GlobalKeyword _SPOT; //Field offset: 0x220
	public static GlobalKeyword _DIRECTIONAL; //Field offset: 0x230
	public static GlobalKeyword _POINT; //Field offset: 0x240
	public static GlobalKeyword _DEFERRED_STENCIL; //Field offset: 0x250
	public static GlobalKeyword _DEFERRED_FIRST_LIGHT; //Field offset: 0x260
	public static GlobalKeyword _DEFERRED_MAIN_LIGHT; //Field offset: 0x270
	public static GlobalKeyword _GBUFFER_NORMALS_OCT; //Field offset: 0x280
	public static GlobalKeyword _DEFERRED_MIXED_LIGHTING; //Field offset: 0x290
	public static GlobalKeyword LIGHTMAP_ON; //Field offset: 0x2A0
	public static GlobalKeyword DYNAMICLIGHTMAP_ON; //Field offset: 0x2B0
	public static GlobalKeyword _ALPHATEST_ON; //Field offset: 0x2C0
	public static GlobalKeyword DIRLIGHTMAP_COMBINED; //Field offset: 0x2D0
	public static GlobalKeyword _DETAIL_MULX2; //Field offset: 0x2E0
	public static GlobalKeyword _DETAIL_SCALED; //Field offset: 0x2F0
	public static GlobalKeyword _CLEARCOAT; //Field offset: 0x300
	public static GlobalKeyword _CLEARCOATMAP; //Field offset: 0x310
	public static GlobalKeyword DEBUG_DISPLAY; //Field offset: 0x320
	public static GlobalKeyword LOD_FADE_CROSSFADE; //Field offset: 0x330
	public static GlobalKeyword USE_UNITY_CROSSFADE; //Field offset: 0x340
	public static GlobalKeyword _EMISSION; //Field offset: 0x350
	public static GlobalKeyword _RECEIVE_SHADOWS_OFF; //Field offset: 0x360
	public static GlobalKeyword _SURFACE_TYPE_TRANSPARENT; //Field offset: 0x370
	public static GlobalKeyword _ALPHAPREMULTIPLY_ON; //Field offset: 0x380
	public static GlobalKeyword _ALPHAMODULATE_ON; //Field offset: 0x390
	public static GlobalKeyword _NORMALMAP; //Field offset: 0x3A0
	public static GlobalKeyword _ADD_PRECOMPUTED_VELOCITY; //Field offset: 0x3B0
	public static GlobalKeyword EDITOR_VISUALIZATION; //Field offset: 0x3C0
	public static GlobalKeyword FoveatedRenderingNonUniformRaster; //Field offset: 0x3D0
	public static GlobalKeyword DisableTexture2DXArray; //Field offset: 0x3E0
	public static GlobalKeyword BlitSingleSlice; //Field offset: 0x3F0
	public static GlobalKeyword XROcclusionMeshCombined; //Field offset: 0x400
	public static GlobalKeyword SCREEN_COORD_OVERRIDE; //Field offset: 0x410
	public static GlobalKeyword DOWNSAMPLING_SIZE_2; //Field offset: 0x420
	public static GlobalKeyword DOWNSAMPLING_SIZE_4; //Field offset: 0x430
	public static GlobalKeyword DOWNSAMPLING_SIZE_8; //Field offset: 0x440
	public static GlobalKeyword DOWNSAMPLING_SIZE_16; //Field offset: 0x450
	public static GlobalKeyword EVALUATE_SH_MIXED; //Field offset: 0x460
	public static GlobalKeyword EVALUATE_SH_VERTEX; //Field offset: 0x470
	public static GlobalKeyword ProbeVolumeL1; //Field offset: 0x480
	public static GlobalKeyword ProbeVolumeL2; //Field offset: 0x490
	public static GlobalKeyword _OUTPUT_DEPTH; //Field offset: 0x4A0
	public static GlobalKeyword LinearToSRGBConversion; //Field offset: 0x4B0
	public static GlobalKeyword _ENABLE_ALPHA_OUTPUT; //Field offset: 0x4C0

	public static void InitializeShaderGlobalKeywords() { }

}

