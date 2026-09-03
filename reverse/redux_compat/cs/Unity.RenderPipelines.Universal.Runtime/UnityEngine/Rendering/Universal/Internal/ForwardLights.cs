/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal.Internal
{
	public class ForwardLights // TypeDefIndex: 9893
	{
		// Fields
		private const string k_SetupLightConstants = "Setup Light Constants"; // Metadata: 0x0069FD0E
		private static readonly ProfilingSampler m_ProfilingSampler; // 0x00
		private static readonly ProfilingSampler m_ProfilingSamplerFPSetup; // 0x08
		private static readonly ProfilingSampler m_ProfilingSamplerFPComplete; // 0x10
		private static readonly ProfilingSampler m_ProfilingSamplerFPUpload; // 0x18
		private MixedLightingSetup m_MixedLightingSetup; // 0x10
		private const string k_AdditionalLightsCBName = "Additional Lights Buffer"; // Metadata: 0x0069FD24
		private const int k_AdditionalLightsPositionChannel = 0; // Metadata: 0x0069FD3D
		private const int k_AdditionalLightsColorChannel = 1; // Metadata: 0x0069FD3E
		private const int k_AdditionalLightsAttenuationChannel = 2; // Metadata: 0x0069FD3F
		private const int k_AdditionalLightsSpotDirChannel = 3; // Metadata: 0x0069FD40
		private const int k_AdditionalLightsOcclusionChannel = 4; // Metadata: 0x0069FD41
		private const int k_AdditionalLightsChannelCount = 5; // Metadata: 0x0069FD42
		private NativeArray<Vector4> m_AdditionalLightsData; // 0x18
		private GraphicsBuffer m_AdditionalLightsBuffer; // 0x28
		private Vector4[] m_AdditionalLightPositions; // 0x30
		private Vector4[] m_AdditionalLightColors; // 0x38
		private Vector4[] m_AdditionalLightAttenuations; // 0x40
		private Vector4[] m_AdditionalLightSpotDirections; // 0x48
		private Vector4[] m_AdditionalLightOcclusionProbeChannels; // 0x50
		private float[] m_AdditionalLightsLayerMasks; // 0x58
		private int m_MaxVisibleAdditionalLights; // 0x60
		private bool m_UseConstantBuffer; // 0x64
		private bool m_UseForwardPlus; // 0x65
		private int m_DirectionalLightCount; // 0x68
		private int m_ActualTileWidth; // 0x6C
		private int2 m_TileResolution; // 0x70
		private JobHandle m_CullingHandle; // 0x78
		private const string k_ZBinCBName = "URP Z-Bin Buffer"; // Metadata: 0x0069FD43
		private NativeArray<uint> m_ZBins; // 0x88
		private GraphicsBuffer m_ZBinsBuffer; // 0x98
		private const string k_TileCBName = "URP Tile Buffer"; // Metadata: 0x0069FD54
		private NativeArray<uint> m_TileMasks; // 0xA0
		private GraphicsBuffer m_TileMasksBuffer; // 0xB0
		private LightCookieManager m_LightCookieManager; // 0xB8
		private ReflectionProbeManager m_ReflectionProbeManager; // 0xC0
		private int m_WordsPerTile; // 0x170
		private float m_ZBinScale; // 0x174
		private float m_ZBinOffset; // 0x178
		private int m_LightCount; // 0x17C
		private int m_BinCount; // 0x180
		private static readonly ProfilingSampler s_SetupForwardLights; // 0x20
	
		// Properties
		internal ReflectionProbeManager reflectionProbeManager { get; } // 0x000000018202E960-0x000000018202E9E0 
	
		// Nested types
		private static class LightShaderPropertyId // TypeDefIndex: 9894
		{
			// Fields
			public static readonly int _MainLightPosition; // 0x00
			public static readonly int _MainLightColor; // 0x04
			public static readonly int _MainLightOcclusionProbesChannel; // 0x08
			public static readonly int _MainLightLayerMask; // 0x0C
			public static readonly int _AdditionalLightsCount; // 0x10
			public static readonly int _AdditionalLightsBuffer; // 0x14
			public static readonly int _AdditionalLightsPosition; // 0x18
			public static readonly int _AdditionalLightsColor; // 0x1C
			public static readonly int _AdditionalLightsAttenuation; // 0x20
			public static readonly int _AdditionalLightsSpotDir; // 0x24
			public static readonly int _AdditionalLightOcclusionProbeChannel; // 0x28
			public static readonly int _AdditionalLightsLayerMasks; // 0x2C
			public static readonly int _ZBinBuffer; // 0x30
			public static readonly int _TileBuffer; // 0x34
			public static readonly int _FPParams0; // 0x38
			public static readonly int _FPParams1; // 0x3C
			public static readonly int _FPParams2; // 0x40
			public static readonly int _EnableProbeVolumes; // 0x44
	
			// Constructors
			static LightShaderPropertyId(); // 0x000000018202EB00-0x000000018202EE30
		}
	
		internal struct InitParams // TypeDefIndex: 9895
		{
			// Fields
			public LightCookieManager lightCookieManager; // 0x00
			public bool forwardPlus; // 0x08
	
			// Methods
			internal static InitParams Create(); // 0x000000018202E9E0-0x000000018202EB00
		}
	
		private class SetupLightPassData // TypeDefIndex: 9896
		{
			// Fields
			internal UniversalRenderingData renderingData; // 0x10
			internal UniversalCameraData cameraData; // 0x18
			internal UniversalLightData lightData; // 0x20
			internal ForwardLights forwardLights; // 0x28
	
			// Constructors
			public SetupLightPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9897
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<SetupLightPassData, UnsafeGraphContext> __9__58_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000182030920-0x0000000182030990
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _SetupRenderGraphLights_b__58_0(SetupLightPassData data, UnsafeGraphContext rgContext); // 0x0000000182030670-0x00000001820306C0
		}
	
		// Constructors
		public ForwardLights(); // 0x000000018202E490-0x000000018202E780
		internal ForwardLights(InitParams initParams); // 0x000000018202E780-0x000000018202E960
		static ForwardLights(); // 0x000000018202E2A0-0x000000018202E490
	
		// Methods
		private void CreateAdditionalLightsConstantBuffer(); // 0x0000000182029BC0-0x0000000182029CD0
		private void DisposeAdditionalLightsConstantBuffer(); // 0x0000000182029FA0-0x000000018202A060
		private void CreateAdditionalLightsLooseUniformArrays(); // 0x0000000182029CD0-0x0000000182029DC0
		private void CreateForwardPlusConstantBuffers(); // 0x0000000182029DC0-0x0000000182029FA0
		private void ResizeAdditionalLightsBuffer(int maxLights); // 0x000000018202B1E0-0x000000018202B220
		private static int AlignByteCount(int count, int align); // 0x0000000182029A90-0x0000000182029AB0
		private static void GetViewParams(bool isOrthographic, float4x4 viewToClip, out float viewPlaneBot, out float viewPlaneTop, out float4 viewToViewportScaleBias); // 0x000000018202A060-0x000000018202A230
		internal static JobHandle ScheduleClusteringJobs(bool hasMainLight, bool supportsAdditionalLights, NativeArray<VisibleLight> lights, NativeArray<VisibleReflectionProbe> probes, NativeArray<uint> zBins, NativeArray<uint> tileMasks, Fixed2<float4x4> worldToViews, Fixed2<float4x4> viewToClips, int viewCount, int2 screenResolution, float nearClipPlane, float farClipPlane, bool isOrthographic, out int localLightCount, out int directionalLightCount, out int binCount, out float zBinScale, out float zBinOffset, out int2 tileResolution, out int actualTileWidth, out int wordsPerTile); // 0x000000018202B220-0x000000018202C110
		internal void PreSetup(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData); // 0x000000018202A470-0x000000018202B1E0
		internal void SetupRenderGraphLights(RenderGraph renderGraph, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData); // 0x000000018202DEB0-0x000000018202E230
		internal void SetupLights(UnsafeCommandBuffer cmd, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData); // 0x000000018202CB60-0x000000018202D9B0
		internal void Cleanup(); // 0x0000000182029AB0-0x0000000182029BC0
		private void InitializeLightConstants(NativeArray<VisibleLight> lights, int lightIndex, bool supportsLightLayers, out Vector4 lightPos, out Vector4 lightColor, out Vector4 lightAttenuation, out Vector4 lightSpotDir, out Vector4 lightOcclusionProbeChannel, out uint lightLayerMask, out bool isSubtractive); // 0x000000018202A230-0x000000018202A470
		private void SetupShaderLightConstants(UnsafeCommandBuffer cmd, ref CullingResults cullResults, UniversalLightData lightData, bool reuseCullingResult); // 0x000000018202E230-0x000000018202E2A0
		private void SetupMainLightConstants(UnsafeCommandBuffer cmd, UniversalLightData lightData); // 0x000000018202D9B0-0x000000018202DD00
		private void SetupAdditionalLightConstants(UnsafeCommandBuffer cmd, ref CullingResults cullResults, UniversalLightData lightData, bool reuseCullingResult); // 0x000000018202C110-0x000000018202CB60
		private int SetupPerObjectLightIndices(CullingResults cullResults, UniversalLightData lightData, bool reuseCullingResult); // 0x000000018202DD00-0x000000018202DEB0
	}
}
