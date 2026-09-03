/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public static class ShadowUtils // TypeDefIndex: 9785
	{
		// Fields
		internal static readonly bool m_ForceShadowPointSampling; // 0x00
		internal const int kMinimumPunctualLightHardShadowResolution = 8; // Metadata: 0x0069F0D5
		internal const int kMinimumPunctualLightSoftShadowResolution = 16; // Metadata: 0x0069F0D6
		private static bool s_WarnedNoShadowmapStencilFormat; // 0x01
	
		// Constructors
		static ShadowUtils(); // 0x0000000181FE9C60-0x0000000181FE9D20
	
		// Methods
		public static bool ExtractDirectionalLightMatrix(ref CullingResults cullResults, ref ShadowData shadowData, int shadowLightIndex, int cascadeIndex, int shadowmapWidth, int shadowmapHeight, int shadowResolution, float shadowNearPlane, out Vector4 cascadeSplitDistance, out ShadowSliceData shadowSliceData, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix); // 0x0000000181FE6BD0-0x0000000181FE6D40
		public static bool ExtractDirectionalLightMatrix(ref CullingResults cullResults, ref ShadowData shadowData, int shadowLightIndex, int cascadeIndex, int shadowmapWidth, int shadowmapHeight, int shadowResolution, float shadowNearPlane, out Vector4 cascadeSplitDistance, out ShadowSliceData shadowSliceData); // 0x0000000181FE6D40-0x0000000181FE6DE0
		public static bool ExtractDirectionalLightMatrix(ref CullingResults cullResults, UniversalShadowData shadowData, int shadowLightIndex, int cascadeIndex, int shadowmapWidth, int shadowmapHeight, int shadowResolution, float shadowNearPlane, out Vector4 cascadeSplitDistance, out ShadowSliceData shadowSliceData); // 0x0000000181FE6DE0-0x0000000181FE71B0
		public static bool ExtractSpotLightMatrix(ref CullingResults cullResults, ref ShadowData shadowData, int shadowLightIndex, out Matrix4x4 shadowMatrix, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData splitData); // 0x0000000181FE7430-0x0000000181FE74C0
		public static bool ExtractSpotLightMatrix(ref CullingResults cullResults, UniversalShadowData shadowData, int shadowLightIndex, out Matrix4x4 shadowMatrix, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData splitData); // 0x0000000181FE74C0-0x0000000181FE7690
		public static bool ExtractPointLightMatrix(ref CullingResults cullResults, ref ShadowData shadowData, int shadowLightIndex, CubemapFace cubemapFace, float fovBias, out Matrix4x4 shadowMatrix, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData splitData); // 0x0000000181FE73A0-0x0000000181FE7430
		public static bool ExtractPointLightMatrix(ref CullingResults cullResults, UniversalShadowData shadowData, int shadowLightIndex, CubemapFace cubemapFace, float fovBias, out Matrix4x4 shadowMatrix, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData splitData); // 0x0000000181FE71B0-0x0000000181FE73A0
		public static void RenderShadowSlice(CommandBuffer cmd, ref ScriptableRenderContext context, ref ShadowSliceData shadowSliceData, ref ShadowDrawingSettings settings, Matrix4x4 proj, Matrix4x4 view); // 0x0000000181FE8790-0x0000000181FE8960
		internal static void RenderShadowSlice(RasterCommandBuffer cmd, ref ShadowSliceData shadowSliceData, ref RendererList shadowRendererList, Matrix4x4 proj, Matrix4x4 view); // 0x0000000181FE8960-0x0000000181FE8B10
		public static void RenderShadowSlice(CommandBuffer cmd, ref ScriptableRenderContext context, ref ShadowSliceData shadowSliceData, ref ShadowDrawingSettings settings); // 0x0000000181FE8540-0x0000000181FE8790
		public static int GetMaxTileResolutionInAtlas(int atlasWidth, int atlasHeight, int tileCount); // 0x0000000181FE7770-0x0000000181FE77B0
		public static void ApplySliceTransform(ref ShadowSliceData shadowSliceData, int atlasWidth, int atlasHeight); // 0x0000000181FE6A40-0x0000000181FE6BD0
		public static Vector4 GetShadowBias(ref VisibleLight shadowLight, int shadowLightIndex, ref ShadowData shadowData, Matrix4x4 lightProjectionMatrix, float shadowResolution); // 0x0000000181FE7CC0-0x0000000181FE7DD0
		public static Vector4 GetShadowBias(ref VisibleLight shadowLight, int shadowLightIndex, UniversalShadowData shadowData, Matrix4x4 lightProjectionMatrix, float shadowResolution); // 0x0000000181FE7BB0-0x0000000181FE7CC0
		private static Vector4 GetShadowBias(ref VisibleLight shadowLight, int shadowLightIndex, List<Vector4> bias, bool supportsSoftShadows, Matrix4x4 lightProjectionMatrix, float shadowResolution); // 0x0000000181FE7840-0x0000000181FE7BB0
		internal static void GetScaleAndBiasForLinearDistanceFade(float fadeDistance, float border, out float scale, out float bias); // 0x0000000181FE77D0-0x0000000181FE7840
		public static void SetupShadowCasterConstantBuffer(CommandBuffer cmd, ref VisibleLight shadowLight, Vector4 shadowBias); // 0x0000000181FE8FE0-0x0000000181FE9260
		internal static void SetupShadowCasterConstantBuffer(RasterCommandBuffer cmd, ref VisibleLight shadowLight, Vector4 shadowBias); // 0x0000000181FE9260-0x0000000181FE9480
		internal static void SetShadowBias(RasterCommandBuffer cmd, Vector4 shadowBias); // 0x0000000181FE8DC0-0x0000000181FE8E50
		internal static void SetLightDirection(RasterCommandBuffer cmd, Vector3 lightDirection); // 0x0000000181FE8BC0-0x0000000181FE8C70
		internal static void SetLightPosition(RasterCommandBuffer cmd, Vector3 lightPosition); // 0x0000000181FE8C70-0x0000000181FE8D20
		internal static void SetCameraPosition(RasterCommandBuffer cmd, Vector3 worldSpaceCameraPos); // 0x0000000181FE8B10-0x0000000181FE8BC0
		private static RenderTextureDescriptor GetTemporaryShadowTextureDescriptor(int width, int height, int bits); // 0x0000000181FE8120-0x0000000181FE82D0
		[Obsolete("Use AllocShadowRT or ShadowRTReAllocateIfNeeded. #from(2022.1) #breakingFrom(2023.1)", true)]
		public static RenderTexture GetTemporaryShadowTexture(int width, int height, int bits); // 0x0000000181FE82D0-0x0000000181FE83D0
		public static bool ShadowRTNeedsReAlloc(RTHandle handle, int width, int height, int bits, int anisoLevel, float mipMapBias, string name); // 0x0000000181FE9480-0x0000000181FE9730
		public static RTHandle AllocShadowRT(int width, int height, int bits, int anisoLevel, float mipMapBias, string name); // 0x0000000181FE6910-0x0000000181FE6A40
		public static bool ShadowRTReAllocateIfNeeded(ref RTHandle handle, int width, int height, int bits, int anisoLevel = 1 /* Metadata: 0x0069F0CF */, float mipMapBias = 0f /* Metadata: 0x0069F0D0 */, string name = "" /* Metadata: 0x0069F0D4 */); // 0x0000000181FE9730-0x0000000181FE9B10
		private static Matrix4x4 GetShadowTransform(Matrix4x4 proj, Matrix4x4 view); // 0x0000000181FE7DD0-0x0000000181FE7FE0
		internal static float SoftShadowQualityToShaderProperty(Light light, bool softShadowsEnabled); // 0x0000000181FE9B10-0x0000000181FE9C60
		internal static bool SupportsPerLightSoftShadowQuality(); // 0x00000001802E7990-0x00000001802E79A0
		internal static void SetPerLightSoftShadowKeyword(RasterCommandBuffer cmd, UniversalShadowData shadowData, bool hasSoftShadows); // 0x0000000181FE8D20-0x0000000181FE8DC0
		internal static void SetSoftShadowQualityShaderKeywords(RasterCommandBuffer cmd, UniversalShadowData shadowData); // 0x0000000181FE8E50-0x0000000181FE8ED0
		internal static void SetSoftShadowQualityShaderKeywords(RasterCommandBuffer cmd, UniversalShadowData shadowData, bool enabled); // 0x0000000181FE8ED0-0x0000000181FE8FE0
		internal static bool IsValidShadowCastingLight(UniversalLightData lightData, int i); // 0x0000000181FE8410-0x0000000181FE8530
		internal static bool IsValidShadowCastingLight(UniversalLightData lightData, int i, LightType lightType, LightShadows lightShadows, float shadowStrength); // 0x0000000181FE83D0-0x0000000181FE8410
		internal static int GetPunctualLightShadowSlicesCount([IsReadOnly] in LightType lightType); // 0x0000000181FE77B0-0x0000000181FE77D0
		internal static bool FastApproximately(float a, float b); // 0x0000000181FE7750-0x0000000181FE7770
		internal static bool FastApproximately(Vector4 a, Vector4 b); // 0x0000000181FE7690-0x0000000181FE7750
		internal static int MinimalPunctualLightShadowResolution(bool softShadow); // 0x0000000181FE8530-0x0000000181FE8540
		internal static GraphicsFormat GetShadowmapDepthStencilFormat(bool stencilBuffer); // 0x0000000181FE7FE0-0x0000000181FE8120
	}
}
