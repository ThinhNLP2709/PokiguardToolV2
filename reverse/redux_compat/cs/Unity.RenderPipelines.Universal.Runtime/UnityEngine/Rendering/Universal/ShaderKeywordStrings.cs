/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public static class ShaderKeywordStrings // TypeDefIndex: 9850
	{
		// Fields
		public const string MainLightShadows = "_MAIN_LIGHT_SHADOWS"; // Metadata: 0x0069F303
		public const string MainLightShadowCascades = "_MAIN_LIGHT_SHADOWS_CASCADE"; // Metadata: 0x0069F317
		public const string MainLightShadowScreen = "_MAIN_LIGHT_SHADOWS_SCREEN"; // Metadata: 0x0069F333
		public const string CastingPunctualLightShadow = "_CASTING_PUNCTUAL_LIGHT_SHADOW"; // Metadata: 0x0069F34E
		public const string AdditionalLightsVertex = "_ADDITIONAL_LIGHTS_VERTEX"; // Metadata: 0x0069F36D
		public const string AdditionalLightsPixel = "_ADDITIONAL_LIGHTS"; // Metadata: 0x0069F387
		internal const string ClusterLightLoop = "_CLUSTER_LIGHT_LOOP"; // Metadata: 0x0069F39A
		public const string AdditionalLightShadows = "_ADDITIONAL_LIGHT_SHADOWS"; // Metadata: 0x0069F3AE
		public const string ReflectionProbeBoxProjection = "_REFLECTION_PROBE_BOX_PROJECTION"; // Metadata: 0x0069F3C8
		public const string ReflectionProbeBlending = "_REFLECTION_PROBE_BLENDING"; // Metadata: 0x0069F3E9
		public const string ReflectionProbeAtlas = "_REFLECTION_PROBE_ATLAS"; // Metadata: 0x0069F404
		public const string ReflectionProbeRotation = "REFLECTION_PROBE_ROTATION"; // Metadata: 0x0069F41C
		public const string ScreenSpaceReflection = "_SCREEN_SPACE_REFLECTION"; // Metadata: 0x0069F436
		public const string SoftShadows = "_SHADOWS_SOFT"; // Metadata: 0x0069F44F
		public const string SoftShadowsLow = "_SHADOWS_SOFT_LOW"; // Metadata: 0x0069F45D
		public const string SoftShadowsMedium = "_SHADOWS_SOFT_MEDIUM"; // Metadata: 0x0069F46F
		public const string SoftShadowsHigh = "_SHADOWS_SOFT_HIGH"; // Metadata: 0x0069F484
		public const string MixedLightingSubtractive = "_MIXED_LIGHTING_SUBTRACTIVE"; // Metadata: 0x0069F497
		public const string LightmapShadowMixing = "LIGHTMAP_SHADOW_MIXING"; // Metadata: 0x0069F4B3
		public const string ShadowsShadowMask = "SHADOWS_SHADOWMASK"; // Metadata: 0x0069F4CA
		public const string LightLayers = "_LIGHT_LAYERS"; // Metadata: 0x0069F4DD
		public const string RenderPassEnabled = "_RENDER_PASS_ENABLED"; // Metadata: 0x0069F4EB
		public const string BillboardFaceCameraPos = "BILLBOARD_FACE_CAMERA_POS"; // Metadata: 0x0069F500
		public const string LightCookies = "_LIGHT_COOKIES"; // Metadata: 0x0069F51A
		public const string VolumetricFog = "_VOLUMETRIC_FOG"; // Metadata: 0x0069F529
		public const string DepthNoMsaa = "_DEPTH_NO_MSAA"; // Metadata: 0x0069F539
		public const string DepthMsaa2 = "_DEPTH_MSAA_2"; // Metadata: 0x0069F548
		public const string DepthMsaa4 = "_DEPTH_MSAA_4"; // Metadata: 0x0069F556
		public const string DepthMsaa8 = "_DEPTH_MSAA_8"; // Metadata: 0x0069F564
		public const string LinearToSRGBConversion = "_LINEAR_TO_SRGB_CONVERSION"; // Metadata: 0x0069F572
		internal const string UseFastSRGBLinearConversion = "_USE_FAST_SRGB_LINEAR_CONVERSION"; // Metadata: 0x0069F58D
		public const string DBufferMRT1 = "_DBUFFER_MRT1"; // Metadata: 0x0069F5AE
		public const string DBufferMRT2 = "_DBUFFER_MRT2"; // Metadata: 0x0069F5BC
		public const string DBufferMRT3 = "_DBUFFER_MRT3"; // Metadata: 0x0069F5CA
		public const string DecalNormalBlendLow = "_DECAL_NORMAL_BLEND_LOW"; // Metadata: 0x0069F5D8
		public const string DecalNormalBlendMedium = "_DECAL_NORMAL_BLEND_MEDIUM"; // Metadata: 0x0069F5F0
		public const string DecalNormalBlendHigh = "_DECAL_NORMAL_BLEND_HIGH"; // Metadata: 0x0069F60B
		public const string DecalLayers = "_DECAL_LAYERS"; // Metadata: 0x0069F624
		public const string WriteRenderingLayers = "_WRITE_RENDERING_LAYERS"; // Metadata: 0x0069F632
		public const string WriteSmoothness = "_WRITE_SMOOTHNESS"; // Metadata: 0x0069F64A
		public const string SmaaLow = "_SMAA_PRESET_LOW"; // Metadata: 0x0069F65C
		public const string SmaaMedium = "_SMAA_PRESET_MEDIUM"; // Metadata: 0x0069F66D
		public const string SmaaHigh = "_SMAA_PRESET_HIGH"; // Metadata: 0x0069F681
		public const string PaniniGeneric = "_GENERIC"; // Metadata: 0x0069F693
		public const string PaniniUnitDistance = "_UNIT_DISTANCE"; // Metadata: 0x0069F69C
		public const string BloomLQ = "_BLOOM_LQ"; // Metadata: 0x0069F6AB
		public const string BloomHQ = "_BLOOM_HQ"; // Metadata: 0x0069F6B5
		public const string BloomLQDirt = "_BLOOM_LQ_DIRT"; // Metadata: 0x0069F6BF
		public const string BloomHQDirt = "_BLOOM_HQ_DIRT"; // Metadata: 0x0069F6CE
		public const string Distortion = "_DISTORTION"; // Metadata: 0x0069F6DD
		public const string ChromaticAberration = "_CHROMATIC_ABERRATION"; // Metadata: 0x0069F6E9
		public const string HDRGrading = "_HDR_GRADING"; // Metadata: 0x0069F6FF
		public const string HDROverlay = "_HDR_OVERLAY"; // Metadata: 0x0069F70C
		public const string TonemapACES = "_TONEMAP_ACES"; // Metadata: 0x0069F719
		public const string TonemapNeutral = "_TONEMAP_NEUTRAL"; // Metadata: 0x0069F727
		public const string FilmGrain = "_FILM_GRAIN"; // Metadata: 0x0069F738
		public const string Fxaa = "_FXAA"; // Metadata: 0x0069F744
		public const string Dithering = "_DITHERING"; // Metadata: 0x0069F74A
		public const string ScreenSpaceOcclusion = "_SCREEN_SPACE_OCCLUSION"; // Metadata: 0x0069F755
		public const string ScreenSpaceIrradiance = "_SCREEN_SPACE_IRRADIANCE"; // Metadata: 0x0069F76D
		public const string PointSampling = "_POINT_SAMPLING"; // Metadata: 0x0069F786
		public const string Rcas = "_RCAS"; // Metadata: 0x0069F796
		public const string EasuRcasAndHDRInput = "_EASU_RCAS_AND_HDR_INPUT"; // Metadata: 0x0069F79C
		public const string Gamma20 = "_GAMMA_20"; // Metadata: 0x0069F7B5
		public const string Gamma20AndHDRInput = "_GAMMA_20_AND_HDR_INPUT"; // Metadata: 0x0069F7BF
		public const string HighQualitySampling = "_HIGH_QUALITY_SAMPLING"; // Metadata: 0x0069F7D7
		public const string _SPOT = "_SPOT"; // Metadata: 0x0069F7EE
		public const string _DIRECTIONAL = "_DIRECTIONAL"; // Metadata: 0x0069F7F4
		public const string _POINT = "_POINT"; // Metadata: 0x0069F801
		public const string _DEFERRED_STENCIL = "_DEFERRED_STENCIL"; // Metadata: 0x0069F808
		public const string _DEFERRED_FIRST_LIGHT = "_DEFERRED_FIRST_LIGHT"; // Metadata: 0x0069F81A
		public const string _DEFERRED_MAIN_LIGHT = "_DEFERRED_MAIN_LIGHT"; // Metadata: 0x0069F830
		public const string _GBUFFER_NORMALS_OCT = "_GBUFFER_NORMALS_OCT"; // Metadata: 0x0069F845
		public const string _DEFERRED_MIXED_LIGHTING = "_DEFERRED_MIXED_LIGHTING"; // Metadata: 0x0069F85A
		public const string LIGHTMAP_ON = "LIGHTMAP_ON"; // Metadata: 0x0069F873
		public const string DYNAMICLIGHTMAP_ON = "DYNAMICLIGHTMAP_ON"; // Metadata: 0x0069F87F
		public const string _ALPHATEST_ON = "_ALPHATEST_ON"; // Metadata: 0x0069F892
		public const string DIRLIGHTMAP_COMBINED = "DIRLIGHTMAP_COMBINED"; // Metadata: 0x0069F8A0
		public const string _DETAIL_MULX2 = "_DETAIL_MULX2"; // Metadata: 0x0069F8B5
		public const string _DETAIL_SCALED = "_DETAIL_SCALED"; // Metadata: 0x0069F8C3
		public const string _CLEARCOAT = "_CLEARCOAT"; // Metadata: 0x0069F8D2
		public const string _CLEARCOATMAP = "_CLEARCOATMAP"; // Metadata: 0x0069F8DD
		public const string DEBUG_DISPLAY = "DEBUG_DISPLAY"; // Metadata: 0x0069F8EB
		public const string LOD_FADE_CROSSFADE = "LOD_FADE_CROSSFADE"; // Metadata: 0x0069F8F9
		public const string USE_UNITY_CROSSFADE = "USE_UNITY_CROSSFADE"; // Metadata: 0x0069F90C
		public const string _EMISSION = "_EMISSION"; // Metadata: 0x0069F920
		public const string _RECEIVE_SHADOWS_OFF = "_RECEIVE_SHADOWS_OFF"; // Metadata: 0x0069F92A
		public const string _SURFACE_TYPE_TRANSPARENT = "_SURFACE_TYPE_TRANSPARENT"; // Metadata: 0x0069F93F
		public const string _ALPHAPREMULTIPLY_ON = "_ALPHAPREMULTIPLY_ON"; // Metadata: 0x0069F959
		public const string _ALPHAMODULATE_ON = "_ALPHAMODULATE_ON"; // Metadata: 0x0069F96E
		public const string _NORMALMAP = "_NORMALMAP"; // Metadata: 0x0069F980
		public const string _ADD_PRECOMPUTED_VELOCITY = "_ADD_PRECOMPUTED_VELOCITY"; // Metadata: 0x0069F98B
		public const string EDITOR_VISUALIZATION = "EDITOR_VISUALIZATION"; // Metadata: 0x0069F9A5
		public const string FoveatedRenderingNonUniformRaster = "_FOVEATED_RENDERING_NON_UNIFORM_RASTER"; // Metadata: 0x0069F9BA
		public const string DisableTexture2DXArray = "DISABLE_TEXTURE2D_X_ARRAY"; // Metadata: 0x0069F9E1
		public const string BlitSingleSlice = "BLIT_SINGLE_SLICE"; // Metadata: 0x0069F9FB
		public const string XROcclusionMeshCombined = "XR_OCCLUSION_MESH_COMBINED"; // Metadata: 0x0069FA0D
		public const string SCREEN_COORD_OVERRIDE = "SCREEN_COORD_OVERRIDE"; // Metadata: 0x0069FA28
		public const string DOWNSAMPLING_SIZE_2 = "DOWNSAMPLING_SIZE_2"; // Metadata: 0x0069FA3E
		public const string DOWNSAMPLING_SIZE_4 = "DOWNSAMPLING_SIZE_4"; // Metadata: 0x0069FA52
		public const string DOWNSAMPLING_SIZE_8 = "DOWNSAMPLING_SIZE_8"; // Metadata: 0x0069FA66
		public const string DOWNSAMPLING_SIZE_16 = "DOWNSAMPLING_SIZE_16"; // Metadata: 0x0069FA7A
		public const string EVALUATE_SH_MIXED = "EVALUATE_SH_MIXED"; // Metadata: 0x0069FA8F
		public const string EVALUATE_SH_VERTEX = "EVALUATE_SH_VERTEX"; // Metadata: 0x0069FAA1
		public const string ProbeVolumeL1 = "PROBE_VOLUMES_L1"; // Metadata: 0x0069FAB4
		public const string ProbeVolumeL2 = "PROBE_VOLUMES_L2"; // Metadata: 0x0069FAC5
		public const string LIGHTMAP_BICUBIC_SAMPLING = "LIGHTMAP_BICUBIC_SAMPLING"; // Metadata: 0x0069FAD6
		public const string USE_LEGACY_LIGHTMAPS = "USE_LEGACY_LIGHTMAPS"; // Metadata: 0x0069FAF0
		public const string _OUTPUT_DEPTH = "_OUTPUT_DEPTH"; // Metadata: 0x0069FB05
		public const string _ENABLE_ALPHA_OUTPUT = "_ENABLE_ALPHA_OUTPUT"; // Metadata: 0x0069FB13
		internal const string ForwardPlus = "_FORWARD_PLUS"; // Metadata: 0x0069FB28
		internal const string APPLICATION_SPACE_WARP_MOTION_TRANSPARENT = "APPLICATION_SPACE_WARP_MOTION_TRANSPARENT"; // Metadata: 0x0069FB36
		public const string Msaa2 = "_MSAA_2"; // Metadata: 0x0069FB60
		public const string Msaa4 = "_MSAA_4"; // Metadata: 0x0069FB68
		public const string DEPTH_AS_INPUT_ATTACHMENT = "_DEPTH_AS_INPUT_ATTACHMENT"; // Metadata: 0x0069FB70
		public const string DEPTH_AS_INPUT_ATTACHMENT_MSAA = "_DEPTH_AS_INPUT_ATTACHMENT_MSAA"; // Metadata: 0x0069FB8B
	}
}
