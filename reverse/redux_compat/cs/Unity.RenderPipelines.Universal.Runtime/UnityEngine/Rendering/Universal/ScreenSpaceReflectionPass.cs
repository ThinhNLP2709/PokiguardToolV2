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
	internal class ScreenSpaceReflectionPass : ScriptableRenderPass // TypeDefIndex: 9738
	{
		// Fields
		private const string k_ScreenSpaceReflectionTextureName = "_ScreenSpaceReflectionTexture"; // Metadata: 0x0069EFE5
		private const string k_HiZTrace = "_HIZ_TRACE"; // Metadata: 0x0069F003
		private const string k_UseMotionVectors = "_USE_MOTION_VECTORS"; // Metadata: 0x0069F00E
		private const string k_RefineDepth = "_REFINE_DEPTH"; // Metadata: 0x0069F022
		private Material m_Material; // 0x60
		private Material m_BlitMaterial; // 0x68
		private bool m_AfterOpaque; // 0x70
		private readonly ProfilingSampler m_ProfilingSampler; // 0x78
		private readonly ProfilingSampler m_DepthPyramidSampler; // 0x80
		private readonly ProfilingSampler m_UpscalingSampler; // 0x88
		private readonly ProfilingSampler m_FinalBlitSampler; // 0x90
		private MipGenerator m_MipGenerator; // 0x98
		private PackedMipChainInfo m_PackedMipChainInfo; // 0xA0
	
		// Nested types
		public class SharedSSRData : ContextItem // TypeDefIndex: 9739
		{
			// Fields
			public TextureHandle depthTransparentTexture; // 0x10
			public TextureHandle normalTransparentTexture; // 0x20
	
			// Constructors
			public SharedSSRData(); // 0x0000000181FD4FA0-0x0000000181FD5090
	
			// Methods
			public override void Reset(); // 0x0000000181FD4EC0-0x0000000181FD4FA0
		}
	
		private enum ShaderPasses // TypeDefIndex: 9740
		{
			Reflection = 0,
			BlitAfterOpaque = 1,
			BilinearUpscale = 2,
			BilateralUpscale = 3,
			TemporalFiltering = 4
		}
	
		internal static class ShaderConstants // TypeDefIndex: 9741
		{
			// Fields
			internal static readonly int _ReflectionParam; // 0x00
			internal static readonly int _ReflectionParam2; // 0x04
			internal static readonly int _MaxRayLength; // 0x08
			internal static readonly int _MaxRaySteps; // 0x0C
			internal static readonly int _Downsample; // 0x10
			internal static readonly int _ThicknessScaleAndBias; // 0x14
			internal static readonly int _CameraProjections; // 0x18
			internal static readonly int _CameraInverseProjections; // 0x1C
			internal static readonly int _CameraInverseViewProjections; // 0x20
			internal static readonly int _CameraViewProjections; // 0x24
			internal static readonly int _CameraViews; // 0x28
			internal static readonly int _CameraColorTexture; // 0x2C
			internal static readonly int _CameraDepthTexture; // 0x30
			internal static readonly int _CameraNormalsTexture; // 0x34
			internal static readonly int _SmoothnessTexture; // 0x38
			internal static readonly int _MotionVectorColorTexture; // 0x3C
			internal static readonly int _LastFrameCameraDepthTexture; // 0x40
			internal static readonly int _SsrDepthPyramidMaxMip; // 0x44
			internal static readonly int _SsrDepthPyramid; // 0x48
			internal static readonly int _SmoothnessAndStrengthAndClamp; // 0x4C
			internal static readonly int _ScreenEdgeFadeAndViewConeDot; // 0x50
			internal static readonly int _ReflectSky; // 0x54
			internal static readonly int _HitRefinementSteps; // 0x58
			internal static readonly int _DepthPyramidMipLevelOffsets; // 0x5C
			internal static readonly int _SourceSize; // 0x60
			internal static readonly int _CameraDeltaJitterOffset; // 0x64
			internal static readonly int _ReflectionHistoryTexture; // 0x68
			internal static readonly int _BaseBlendFactor; // 0x6C
	
			// Constructors
			static ShaderConstants(); // 0x0000000181FD4110-0x0000000181FD45F0
		}
	
		private class ScreenSpaceReflectionPassData // TypeDefIndex: 9742
		{
			// Fields
			internal UniversalCameraData cameraData; // 0x10
			internal Matrix4x4[] cameraInverseViewProjections; // 0x18
			internal Matrix4x4[] cameraViewProjections; // 0x20
			internal Matrix4x4[] cameraProjections; // 0x28
			internal Matrix4x4[] cameraInverseProjections; // 0x30
			internal Matrix4x4[] cameraViews; // 0x38
			internal Vector4[] depthPyramidMipOffsets; // 0x40
			internal Material material; // 0x48
			internal PackedMipChainInfo mipsInfo; // 0x50
			internal Vector2 previousJitter; // 0x90
			internal TextureHandle cameraColor; // 0x98
			internal TextureHandle cameraDepth; // 0xA8
			internal TextureHandle cameraNormalsTexture; // 0xB8
			internal TextureHandle smoothnessTexture; // 0xC8
			internal TextureHandle ssrTexture; // 0xD8
			internal TextureHandle blackTexture; // 0xE8
			internal TextureHandle lastFrameCameraDepth; // 0xF8
			internal TextureHandle lastFrameCameraColor; // 0x108
			internal TextureHandle motionVectorColor; // 0x118
			internal TextureHandle depthPyramidTexture; // 0x128
			internal float minimumSmoothness; // 0x138
			internal float smoothnessFadeStart; // 0x13C
			internal float normalFade; // 0x140
			internal float screenEdgeFade; // 0x144
			internal float maxRayLength; // 0x148
			internal float rayLengthFade; // 0x14C
			internal float thicknessScale; // 0x150
			internal float thicknessBias; // 0x154
			internal float thicknessScaleFine; // 0x158
			internal float thicknessBiasFine; // 0x15C
			internal int hitRefinementSteps; // 0x160
			internal int maxRaySteps; // 0x164
			internal int resolutionScale; // 0x168
			internal float roughnessScale; // 0x16C
			internal float reflectionStrength; // 0x170
			internal float clampValue; // 0x174
			internal bool reflectSky; // 0x178
			internal bool afterOpaque; // 0x179
			internal bool linearMarching; // 0x17A
			internal bool useGaussianBlur; // 0x17B
	
			// Constructors
			public ScreenSpaceReflectionPassData(); // 0x0000000181FCE680-0x0000000181FCE790
		}
	
		private class TemporalFilteringPassData // TypeDefIndex: 9743
		{
			// Fields
			internal Material material; // 0x10
			internal TextureHandle ssrTexture; // 0x18
			internal TextureHandle reflectionHistory; // 0x28
			internal TextureHandle motionVectors; // 0x38
			internal float baseBlendFactor; // 0x48
	
			// Constructors
			public TemporalFilteringPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9744
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<ScreenSpaceReflectionPassData, RasterGraphContext> __9__21_0; // 0x08
			public static BaseRenderFunc<TemporalFilteringPassData, RasterGraphContext> __9__21_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181FD7260-0x0000000181FD72D0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRenderGraph_b__21_0(ScreenSpaceReflectionPassData ssrData, RasterGraphContext rgContext); // 0x0000000181FD5FD0-0x0000000181FD6820
			internal void _RecordRenderGraph_b__21_1(TemporalFilteringPassData data, RasterGraphContext ctx); // 0x0000000181FD6820-0x0000000181FD6A10
		}
	
		// Constructors
		public ScreenSpaceReflectionPass(); // 0x0000000181FD2FD0-0x0000000181FD3170
	
		// Methods
		public void Dispose(); // 0x0000000181FCF270-0x0000000181FCF2A0
		internal bool Setup(ScriptableRenderer renderer, Material material, Material blitMaterial, bool afterOpaque, UniversalRenderingData renderingData, CameraType cameraType); // 0x0000000181FD2DB0-0x0000000181FD2FD0
		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000181FCF2A0-0x0000000181FD1EA0
		private static void SetupKeywordsAndParameters(ref ScreenSpaceReflectionPassData data); // 0x0000000181FD2280-0x0000000181FD2DB0
		private void CalculateThicknessScaleAndBias(float nearClip, float farClip, float thickness, out float thicknessScale, out float thicknessBias); // 0x0000000181FCE790-0x0000000181FCE830
		private void CreateRenderTextureHandles(RenderGraph renderGraph, UniversalResourceData resourceData, ScreenSpaceReflectionVolumeSettings settings, out TextureHandle ssrTexture, out TextureHandle upscaleTexture, out TextureHandle mipGenTexture, out TextureHandle finalTexture, out TextureHandle depthPyramidTexture); // 0x0000000181FCE830-0x0000000181FCF270
		private static void RenderDepthHistory(RenderGraph renderGraph, UniversalCameraData cameraData, TextureHandle cameraDepthTexture); // 0x0000000181FD1EA0-0x0000000181FD2280
	}
}
