/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal.Internal
{
	public class AdditionalLightsShadowCasterPass : ScriptableRenderPass // TypeDefIndex: 9889
	{
		// Fields
		[NoAutoStaticsCleanup]
		[Obsolete("AdditionalLightsShadowCasterPass.m_AdditionalShadowsBufferId was deprecated. Shadow slice matrix is now passed to the GPU using an entry in buffer m_AdditionalLightsWorldToShadow_SSBO. Fast Enter Playmode is not supported. #from(2021.1) #breakingFrom(2023.1)", true)]
		public static int m_AdditionalShadowsBufferId; // 0x00
		[NoAutoStaticsCleanup]
		[Obsolete("AdditionalLightsShadowCasterPass.m_AdditionalShadowsIndicesId was deprecated. Shadow slice index is now passed to the GPU using last member of an entry in buffer m_AdditionalShadowParams_SSBO #from(2021.1). Fast Enter Playmode is not supported. #breakingFrom(2023.1)", true)]
		public static int m_AdditionalShadowsIndicesId; // 0x04
		internal RTHandle m_AdditionalLightsShadowmapHandle; // 0x60
		private GraphicsFormat shadowmapDepthStencilFormat; // 0x68
		private int renderTargetWidth; // 0x6C
		private int renderTargetHeight; // 0x70
		private bool m_CreateEmptyShadowmap; // 0x74
		private bool m_SetKeywordForEmptyShadowmap; // 0x75
		private bool m_IssuedMessageAboutShadowSlicesTooMany; // 0x76
		private bool m_IssuedMessageAboutShadowMapsRescale; // 0x77
		private bool m_IssuedMessageAboutShadowMapsTooBig; // 0x78
		private bool m_IssuedMessageAboutRemovedShadowSlices; // 0x79
		private static bool m_IssuedMessageAboutPointLightHardShadowResolutionTooSmall; // 0x08
		private static bool m_IssuedMessageAboutPointLightSoftShadowResolutionTooSmall; // 0x09
		private readonly bool m_UsePersistentConstantBuffer; // 0x7A
		private readonly int m_MaxVisibleAdditionalLights; // 0x7C
		private float m_MaxShadowDistanceSq; // 0x80
		private float m_CascadeBorder; // 0x84
		private bool[] m_VisibleLightIndexToIsCastingShadows; // 0x88
		private short[] m_VisibleLightIndexToAdditionalLightIndex; // 0x90
		private short[] m_AdditionalLightIndexToVisibleLightIndex; // 0x98
		private Vector4[] m_AdditionalLightIndexToShadowParams; // 0xA0
		private Matrix4x4[] m_AdditionalLightShadowSliceIndexTo_WorldShadowMatrix; // 0xA8
		private ShadowSliceData[] m_AdditionalLightsShadowSlices; // 0xB0
		private readonly List<byte> m_GlobalShadowSliceIndexToPerLightShadowSliceIndex; // 0xB8
		private readonly List<short> m_ShadowSliceToAdditionalLightIndex; // 0xC0
		private readonly Dictionary<int, ulong> m_ShadowRequestsHashes; // 0xC8
		private readonly ProfilingSampler m_ProfilingSetupSampler; // 0xD0
		private RenderTextureDescriptor m_AdditionalLightShadowDescriptor; // 0xD8
		private const float k_LightTypeIdentifierInShadowParams_Spot = 0f; // Metadata: 0x0069FC9B
		private const float k_LightTypeIdentifierInShadowParams_Point = 1f; // Metadata: 0x0069FC9F
		private const string k_AdditionalLightShadowMapTextureName = "_AdditionalLightsShadowmapTexture"; // Metadata: 0x0069FCA3
		private const int k_WorldToShadowChannel = 0; // Metadata: 0x0069FCC5
		private const int k_ShadowParamsChannel = 4; // Metadata: 0x0069FCC6
		private const int k_AdditionalLightShadowsChannelCount = 5; // Metadata: 0x0069FCC7
		private const string k_AdditionalLightShadowsCBName = "Additional Light Shadows Buffer"; // Metadata: 0x0069FCC8
		private const string k_EmptyAdditionalLightShadowsCBName = "Empty Additional Light Shadows Buffer"; // Metadata: 0x0069FCE8
		private NativeArray<Vector4> m_AdditionalLightShadowsData; // 0x110
		private GraphicsBuffer m_AdditionalLightShadowsBuffer; // 0x120
		private GraphicsBuffer m_EmptyAdditionalLightShadowsBuffer; // 0x128
		private static readonly Vector4 c_DefaultShadowParams; // 0x0C
		private static Vector4 s_EmptyAdditionalShadowFadeParams; // 0x1C
		private static Vector4[] s_EmptyAdditionalLightIndexToShadowParams; // 0x30
		private static bool isAdditionalShadowParamsDirty; // 0x38
	
		// Nested types
		private static class AdditionalShadowsConstantBuffer // TypeDefIndex: 9890
		{
			// Fields
			public static readonly int _AdditionalLightsWorldToShadow; // 0x00
			public static readonly int _AdditionalShadowParams; // 0x04
			public static readonly int _AdditionalShadowOffset0; // 0x08
			public static readonly int _AdditionalShadowOffset1; // 0x0C
			public static readonly int _AdditionalShadowFadeParams; // 0x10
			public static readonly int _AdditionalShadowmapSize; // 0x14
			public static readonly int _AdditionalLightsShadowmapID; // 0x18
			public static readonly int _AdditionalLightShadowsBufferID; // 0x1C
	
			// Constructors
			static AdditionalShadowsConstantBuffer(); // 0x000000018201FFF0-0x0000000182020170
		}
	
		private class PassData // TypeDefIndex: 9891
		{
			// Fields
			internal int shadowmapID; // 0x10
			internal bool emptyShadowmap; // 0x14
			internal bool setKeywordForEmptyShadowmap; // 0x15
			internal bool usePersistentConstantBuffer; // 0x16
			internal bool stripShadowsOffVariants; // 0x17
			internal Vector2Int allocatedShadowAtlasSize; // 0x18
			internal TextureHandle shadowmapTexture; // 0x20
			internal UniversalLightData lightData; // 0x30
			internal UniversalShadowData shadowData; // 0x38
			internal AdditionalLightsShadowCasterPass pass; // 0x40
			internal readonly RendererListHandle[] shadowRendererListsHdl; // 0x48
	
			// Constructors
			public PassData(); // 0x000000018202F4B0-0x000000018202F510
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9892
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__71_0; // 0x08
			public static BaseRenderFunc<PassData, RasterGraphContext> __9__72_0; // 0x10
	
			// Constructors
			static __c(); // 0x0000000182030760-0x00000001820307D0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _FetchShadowMapAndSetParameters_b__71_0(PassData data, RasterGraphContext context); // 0x00000001820301F0-0x0000000182030500
			internal void _Render_b__72_0(PassData data, RasterGraphContext context); // 0x0000000182030580-0x0000000182030670
		}
	
		// Constructors
		public AdditionalLightsShadowCasterPass(RenderPassEvent evt); // 0x000000018201FC10-0x000000018201FFF0
		static AdditionalLightsShadowCasterPass(); // 0x000000018201FBD0-0x000000018201FC10
	
		// Methods
		private void EnsureBuffersCreated(); // 0x000000018201A500-0x000000018201A7A0
		public void Dispose(); // 0x000000018201A3F0-0x000000018201A500
		internal void ReleaseRenderTargets(); // 0x0000000181F904B0-0x0000000181F904D0
		internal static float CalcGuardAngle(float frustumAngleInDegrees, float guardBandSizeInTexels, float sliceResolutionInTexels); // 0x0000000182019FD0-0x000000018201A060
		internal static float GetPointLightShadowFrustumFovBiasInDegrees(int shadowSliceResolution, bool shadowFiltering); // 0x000000018201B070-0x000000018201B330
		private ulong ResolutionLog2ForHash(int resolution); // 0x000000018201C9A0-0x000000018201C9F0
		private ulong ComputeShadowRequestHash(UniversalLightData lightData, UniversalShadowData shadowData); // 0x000000018201A0A0-0x000000018201A3F0
		private float GetLightTypeIdentifierForShadowParams(LightType lightType); // 0x000000018201ADB0-0x000000018201ADD0
		private bool UsesBakedShadows(Light light); // 0x000000018201FB90-0x000000018201FBD0
		public bool Setup(ref RenderingData renderingData); // 0x000000018201D7A0-0x000000018201D8A0
		internal TextureHandle GetOrCreateShadowMapTexture(RenderGraph renderGraph, UniversalShadowData shadowData); // 0x000000018201ADD0-0x000000018201B070
		public bool Setup(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, UniversalShadowData shadowData); // 0x000000018201D770-0x000000018201D7A0
		public bool Setup(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, UniversalShadowData shadowData, bool stencilBuffer); // 0x000000018201D8A0-0x000000018201FA50
		private void UpdateTextureDescriptorIfNeeded(); // 0x000000018201FA50-0x000000018201FB90
		private bool AnyAdditionalLightHasMixedShadows(UniversalLightData lightData); // 0x0000000182019E30-0x0000000182019FD0
		private bool SetupForEmptyRendering(bool stripShadowsOffVariants, bool shadowsEnabled, UniversalLightData lightData, UniversalShadowData shadowData); // 0x000000018201D1E0-0x000000018201D770
		public int GetShadowLightIndexFromLightIndex(int visibleLightIndex); // 0x000000018201B330-0x000000018201B3A0
		private void Clear(); // 0x000000018201A060-0x000000018201A0A0
		internal static void SetShadowParamsForEmptyShadowmap(RasterCommandBuffer rasterCommandBuffer, UniversalShadowData shadowData); // 0x000000018201CB90-0x000000018201CD40
		private void RenderAdditionalShadowmapAtlas(RasterCommandBuffer cmd, ref PassData data); // 0x000000018201B730-0x000000018201C160
		private void SetShadowGlobalKeywordsAndConstants(RasterCommandBuffer cmd, ref PassData data, Vector2Int allocatedShadowAtlasSize, bool additionalLightHasSoftShadows, bool anyShadowSliceRenderer, bool mainLightHasSoftShadows); // 0x000000018201C9F0-0x000000018201CB90
		private void SetupAdditionalLightsShadowReceiverConstants(RasterCommandBuffer cmd, Vector2Int allocatedShadowAtlasSize, bool usePersistentCBuffer, bool softShadows); // 0x000000018201CD40-0x000000018201D1E0
		private void InitPassData(ref PassData passData, UniversalCameraData cameraData, UniversalLightData lightData, UniversalShadowData shadowData); // 0x000000018201B3A0-0x000000018201B480
		private void InitRendererLists(ref CullingResults cullResults, ref PassData passData, RenderGraph renderGraph); // 0x000000018201B480-0x000000018201B730
		internal TextureHandle FetchShadowMapAndSetParameters(RenderGraph graph, ContextContainer frameData); // 0x000000018201A7A0-0x000000018201ADB0
		internal TextureHandle Render(RenderGraph graph, ContextContainer frameData); // 0x000000018201C160-0x000000018201C9A0
	}
}
