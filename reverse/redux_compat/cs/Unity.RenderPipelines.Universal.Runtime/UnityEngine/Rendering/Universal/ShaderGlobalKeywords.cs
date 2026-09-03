/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal static class ShaderGlobalKeywords // TypeDefIndex: 9849
	{
		// Fields
		public static readonly GlobalKeyword MainLightShadows; // 0x00
		public static readonly GlobalKeyword MainLightShadowCascades; // 0x04
		public static readonly GlobalKeyword MainLightShadowScreen; // 0x08
		public static readonly GlobalKeyword CastingPunctualLightShadow; // 0x0C
		public static readonly GlobalKeyword AdditionalLightsVertex; // 0x10
		public static readonly GlobalKeyword AdditionalLightsPixel; // 0x14
		public static readonly GlobalKeyword ClusterLightLoop; // 0x18
		public static readonly GlobalKeyword AdditionalLightShadows; // 0x1C
		public static readonly GlobalKeyword ReflectionProbeBoxProjection; // 0x20
		public static readonly GlobalKeyword ReflectionProbeBlending; // 0x24
		public static readonly GlobalKeyword ReflectionProbeAtlas; // 0x28
		public static readonly GlobalKeyword ReflectionProbeRotation; // 0x2C
		public static readonly GlobalKeyword ScreenSpaceReflection; // 0x30
		public static readonly GlobalKeyword SoftShadows; // 0x34
		public static readonly GlobalKeyword SoftShadowsLow; // 0x38
		public static readonly GlobalKeyword SoftShadowsMedium; // 0x3C
		public static readonly GlobalKeyword SoftShadowsHigh; // 0x40
		public static readonly GlobalKeyword MixedLightingSubtractive; // 0x44
		public static readonly GlobalKeyword LightmapShadowMixing; // 0x48
		public static readonly GlobalKeyword ShadowsShadowMask; // 0x4C
		public static readonly GlobalKeyword LightLayers; // 0x50
		public static readonly GlobalKeyword RenderPassEnabled; // 0x54
		public static readonly GlobalKeyword BillboardFaceCameraPos; // 0x58
		public static readonly GlobalKeyword LightCookies; // 0x5C
		public static readonly GlobalKeyword VolumetricFog; // 0x60
		public static readonly GlobalKeyword DepthNoMsaa; // 0x64
		public static readonly GlobalKeyword DepthMsaa2; // 0x68
		public static readonly GlobalKeyword DepthMsaa4; // 0x6C
		public static readonly GlobalKeyword DepthMsaa8; // 0x70
		public static readonly GlobalKeyword DBufferMRT1; // 0x74
		public static readonly GlobalKeyword DBufferMRT2; // 0x78
		public static readonly GlobalKeyword DBufferMRT3; // 0x7C
		public static readonly GlobalKeyword DecalNormalBlendLow; // 0x80
		public static readonly GlobalKeyword DecalNormalBlendMedium; // 0x84
		public static readonly GlobalKeyword DecalNormalBlendHigh; // 0x88
		public static readonly GlobalKeyword DecalLayers; // 0x8C
		public static readonly GlobalKeyword WriteRenderingLayers; // 0x90
		public static readonly GlobalKeyword WriteSmoothness; // 0x94
		public static readonly GlobalKeyword ScreenSpaceOcclusion; // 0x98
		public static readonly GlobalKeyword ScreenSpaceIrradiance; // 0x9C
		public static readonly GlobalKeyword _SPOT; // 0xA0
		public static readonly GlobalKeyword _DIRECTIONAL; // 0xA4
		public static readonly GlobalKeyword _POINT; // 0xA8
		public static readonly GlobalKeyword _DEFERRED_STENCIL; // 0xAC
		public static readonly GlobalKeyword _DEFERRED_FIRST_LIGHT; // 0xB0
		public static readonly GlobalKeyword _DEFERRED_MAIN_LIGHT; // 0xB4
		public static readonly GlobalKeyword _GBUFFER_NORMALS_OCT; // 0xB8
		public static readonly GlobalKeyword _DEFERRED_MIXED_LIGHTING; // 0xBC
		public static readonly GlobalKeyword LIGHTMAP_ON; // 0xC0
		public static readonly GlobalKeyword DYNAMICLIGHTMAP_ON; // 0xC4
		public static readonly GlobalKeyword _ALPHATEST_ON; // 0xC8
		public static readonly GlobalKeyword DIRLIGHTMAP_COMBINED; // 0xCC
		public static readonly GlobalKeyword _DETAIL_MULX2; // 0xD0
		public static readonly GlobalKeyword _DETAIL_SCALED; // 0xD4
		public static readonly GlobalKeyword _CLEARCOAT; // 0xD8
		public static readonly GlobalKeyword _CLEARCOATMAP; // 0xDC
		public static readonly GlobalKeyword DEBUG_DISPLAY; // 0xE0
		public static readonly GlobalKeyword LOD_FADE_CROSSFADE; // 0xE4
		public static readonly GlobalKeyword USE_UNITY_CROSSFADE; // 0xE8
		public static readonly GlobalKeyword _EMISSION; // 0xEC
		public static readonly GlobalKeyword _RECEIVE_SHADOWS_OFF; // 0xF0
		public static readonly GlobalKeyword _SURFACE_TYPE_TRANSPARENT; // 0xF4
		public static readonly GlobalKeyword _ALPHAPREMULTIPLY_ON; // 0xF8
		public static readonly GlobalKeyword _ALPHAMODULATE_ON; // 0xFC
		public static readonly GlobalKeyword _NORMALMAP; // 0x100
		public static readonly GlobalKeyword _ADD_PRECOMPUTED_VELOCITY; // 0x104
		public static readonly GlobalKeyword EDITOR_VISUALIZATION; // 0x108
		public static readonly GlobalKeyword FoveatedRenderingNonUniformRaster; // 0x10C
		public static readonly GlobalKeyword DisableTexture2DXArray; // 0x110
		public static readonly GlobalKeyword BlitSingleSlice; // 0x114
		public static readonly GlobalKeyword XROcclusionMeshCombined; // 0x118
		public static readonly GlobalKeyword SCREEN_COORD_OVERRIDE; // 0x11C
		public static readonly GlobalKeyword DOWNSAMPLING_SIZE_2; // 0x120
		public static readonly GlobalKeyword DOWNSAMPLING_SIZE_4; // 0x124
		public static readonly GlobalKeyword DOWNSAMPLING_SIZE_8; // 0x128
		public static readonly GlobalKeyword DOWNSAMPLING_SIZE_16; // 0x12C
		public static readonly GlobalKeyword EVALUATE_SH_MIXED; // 0x130
		public static readonly GlobalKeyword EVALUATE_SH_VERTEX; // 0x134
		public static readonly GlobalKeyword ProbeVolumeL1; // 0x138
		public static readonly GlobalKeyword ProbeVolumeL2; // 0x13C
		public static readonly GlobalKeyword LIGHTMAP_BICUBIC_SAMPLING; // 0x140
		public static readonly GlobalKeyword _OUTPUT_DEPTH; // 0x144
		public static readonly GlobalKeyword LinearToSRGBConversion; // 0x148
		public static readonly GlobalKeyword _ENABLE_ALPHA_OUTPUT; // 0x14C
		public static readonly GlobalKeyword ForwardPlus; // 0x150
		public static readonly GlobalKeyword APPLICATION_SPACE_WARP_MOTION_TRANSPARENT; // 0x154
		public static readonly GlobalKeyword DEPTH_AS_INPUT_ATTACHMENT; // 0x158
		public static readonly GlobalKeyword DEPTH_AS_INPUT_ATTACHMENT_MSAA; // 0x15C
	
		// Constructors
		static ShaderGlobalKeywords(); // 0x0000000181FF8D20-0x0000000181FF9CC0
	
		// Methods
		public static void InitializeShaderGlobalKeywords(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
