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
	internal static class SSAOUtils // TypeDefIndex: 9660
	{
		// Fields
		internal const string k_SSAOTextureName = "_ScreenSpaceOcclusionTexture"; // Metadata: 0x0069EE2E
	
		// Nested types
		internal static class ShaderConstants // TypeDefIndex: 9661
		{
			// Fields
			public static readonly int _AmbientOcclusionParam; // 0x00
			public static readonly int _SSAOParams; // 0x04
			public static readonly int _SSAOBlueNoiseParams; // 0x08
			public static readonly int _BlueNoiseTexture; // 0x0C
			public static readonly int _SSAOFinalTexture; // 0x10
			public static readonly int _CameraViewXExtent; // 0x14
			public static readonly int _CameraViewYExtent; // 0x18
			public static readonly int _CameraViewZExtent; // 0x1C
			public static readonly int _ProjectionParams2; // 0x20
			public static readonly int _CameraViewProjections; // 0x24
			public static readonly int _CameraViewTopLeftCorner; // 0x28
			public static readonly int _CameraNormalsTexture; // 0x2C
			public static readonly int _BlitScaleBias; // 0x30
			public static readonly int _BlitTexture; // 0x34
			public static readonly int _SourceSize; // 0x38
	
			// Constructors
			static ShaderConstants(); // 0x0000000181FD3CE0-0x0000000181FD3F90
		}
	
		internal enum BlurTypes // TypeDefIndex: 9662
		{
			Bilateral = 0,
			Gaussian = 1,
			Kawase = 2
		}
	
		internal enum ShaderPasses // TypeDefIndex: 9663
		{
			AmbientOcclusion = 0,
			BilateralBlurHorizontal = 1,
			BilateralBlurVertical = 2,
			BilateralBlurFinal = 3,
			BilateralAfterOpaque = 4,
			GaussianBlurHorizontal = 5,
			GaussianBlurVertical = 6,
			GaussianAfterOpaque = 7,
			KawaseBlur = 8,
			KawaseAfterOpaque = 9,
			BoxAfterOpaque = 10
		}
	
		internal struct CameraViewData // TypeDefIndex: 9664
		{
			// Fields
			public Vector4[] topLeftCorner; // 0x00
			public Vector4[] xExtent; // 0x08
			public Vector4[] yExtent; // 0x10
			public Vector4[] zExtent; // 0x18
			public Matrix4x4[] viewProjections; // 0x20
	
			// Methods
			public static CameraViewData Create(); // 0x0000000181FC1570-0x0000000181FC1660
		}
	
		[IsReadOnly]
		internal struct SSAOMaterialParams // TypeDefIndex: 9665
		{
			// Fields
			internal readonly bool orthographicCamera; // 0x00
			internal readonly bool aoBlueNoise; // 0x01
			internal readonly bool aoInterleavedGradient; // 0x02
			internal readonly bool sampleCountHigh; // 0x03
			internal readonly bool sampleCountMedium; // 0x04
			internal readonly bool sampleCountLow; // 0x05
			internal readonly bool sourceDepthNormals; // 0x06
			internal readonly bool sourceDepthHigh; // 0x07
			internal readonly bool sourceDepthMedium; // 0x08
			internal readonly bool sourceDepthLow; // 0x09
			internal readonly Vector4 ssaoParams; // 0x0C
	
			// Constructors
			internal SSAOMaterialParams(ScreenSpaceAmbientOcclusionSettings settings, UniversalCameraData cameraData, [IsReadOnly] in TextureDesc cameraColorDesc); // 0x0000000181FCD100-0x0000000181FCD200
	
			// Methods
			internal bool Equals([IsReadOnly] in SSAOMaterialParams other); // 0x0000000181FCD010-0x0000000181FCD100
		}
	
		internal class RasterAOPassData // TypeDefIndex: 9666
		{
			// Fields
			internal bool afterOpaque; // 0x10
			internal ScreenSpaceAmbientOcclusionSettings.BlurQualityOptions blurQuality; // 0x14
			internal Material material; // 0x18
			internal float directLightingStrength; // 0x20
			internal Vector4 sourceSize; // 0x24
			internal TextureHandle aoTexture; // 0x34
			internal TextureHandle finalTexture; // 0x44
			internal TextureHandle blurTexture; // 0x54
			internal TextureHandle cameraNormalsTexture; // 0x64
	
			// Constructors
			public RasterAOPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		internal class BlurPassData // TypeDefIndex: 9667
		{
			// Fields
			internal TextureHandle srcTexture; // 0x10
			internal TextureHandle dstTexture; // 0x20
			internal Material material; // 0x30
			internal UniversalCameraData cameraData; // 0x38
			internal int pass; // 0x40
			internal ScreenSpaceAmbientOcclusionSettings.BlurQualityOptions blurQuality; // 0x44
			internal bool afterOpaque; // 0x48
	
			// Constructors
			public BlurPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		internal class CleanupPassData // TypeDefIndex: 9668
		{
			// Fields
			internal float directLightingStrength; // 0x10
	
			// Constructors
			public CleanupPassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9669
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<RasterAOPassData, RasterGraphContext> __9__21_0; // 0x08
			public static BaseRenderFunc<BlurPassData, RasterGraphContext> __9__22_0; // 0x10
			public static BaseRenderFunc<CleanupPassData, RasterGraphContext> __9__24_0; // 0x18
	
			// Constructors
			static __c(); // 0x0000000181FD7180-0x0000000181FD71F0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _RecordRasterAOPass_b__21_0(RasterAOPassData data, RasterGraphContext ctx); // 0x0000000181FD5E50-0x0000000181FD5FD0
			internal void _RecordBlurStep_b__22_0(BlurPassData data, RasterGraphContext ctx); // 0x0000000181FD5C20-0x0000000181FD5D50
			internal void _RecordCleanupPass_b__24_0(CleanupPassData data, RasterGraphContext ctx); // 0x0000000181FD5D50-0x0000000181FD5E50
		}
	
		// Methods
		internal static float CalculateRadius(ScreenSpaceAmbientOcclusionSettings settings); // 0x0000000181FB18F0-0x0000000181FB1930
		internal static Vector4 CalculateCommonParams(ScreenSpaceAmbientOcclusionSettings settings, float radius); // 0x0000000181FB1850-0x0000000181FB18A0
		internal static Vector4 CalculateProjectionParams2(UniversalCameraData cameraData); // 0x0000000181FB18A0-0x0000000181FB18F0
		internal static Vector2 GetR2Offset(); // 0x0000000181FB2050-0x0000000181FB20A0
		internal static Vector4 CalculateBlueNoiseParams(UniversalCameraData cameraData, Texture2D noiseTexture); // 0x0000000181FB1720-0x0000000181FB1850
		internal static Texture2D GetBlueNoiseTexture(Texture2D[] blueNoiseTextures, int index); // 0x0000000181FB1EA0-0x0000000181FB1EE0
		internal static int AdvanceBlueNoiseIndex(ScreenSpaceAmbientOcclusionSettings settings, Texture2D[] blueNoiseTextures, int currentIndex); // 0x0000000181FB16E0-0x0000000181FB1720
		internal static BlurTypes GetBlurType(ScreenSpaceAmbientOcclusionSettings.BlurQualityOptions quality); // 0x0000000181FB1EE0-0x0000000181FB1F60
		internal static void SetupCameraViewMatrices(UniversalCameraData cameraData, ref CameraViewData viewData); // 0x0000000181FB31F0-0x0000000181FB3990
		internal static bool IsYFlip(RasterGraphContext ctx, [IsReadOnly] in TextureHandle srcTexture, [IsReadOnly] in TextureHandle dstTexture); // 0x0000000181FB20A0-0x0000000181FB2120
		internal static Vector4 ComputeScaleBias([IsReadOnly] in TextureHandle source, bool yFlip); // 0x0000000181FB1930-0x0000000181FB1A30
		internal static void SetupKeywordsAndParameters(Material material, ScreenSpaceAmbientOcclusionSettings settings, UniversalCameraData cameraData, [IsReadOnly] in TextureDesc cameraColorDesc, ref CameraViewData viewData, Texture2D[] blueNoiseTextures, int blueNoiseTextureIndex, ref SSAOMaterialParams prevParams); // 0x0000000181FB3990-0x0000000181FB3F80
		internal static void RecordRasterAOPass(RenderGraph renderGraph, ProfilingSampler profilingSampler, Material material, ScreenSpaceAmbientOcclusionSettings settings, TextureHandle aoTexture, TextureHandle cameraDepthTexture, TextureHandle cameraNormalsTexture, [IsReadOnly] in TextureDesc cameraColorDesc); // 0x0000000181FB2C70-0x0000000181FB31F0
		internal static void RecordBlurStep(RenderGraph renderGraph, ProfilingSampler profilingSampler, Material material, ScreenSpaceAmbientOcclusionSettings settings, UniversalCameraData cameraData, string blurPassName, [IsReadOnly] in TextureHandle src, [IsReadOnly] in TextureHandle dst, int pass, bool isLastPass); // 0x0000000181FB2420-0x0000000181FB28F0
		internal static void RecordBlurChain(RenderGraph renderGraph, ProfilingSampler profilingSampler, Material material, ScreenSpaceAmbientOcclusionSettings settings, UniversalCameraData cameraData, TextureHandle aoTexture, TextureHandle blurTexture, TextureHandle finalTexture); // 0x0000000181FB2120-0x0000000181FB2420
		internal static void RecordCleanupPass(RenderGraph renderGraph, ProfilingSampler profilingSampler, float directLightingStrength, TextureHandle finalTexture); // 0x0000000181FB28F0-0x0000000181FB2C70
		internal static TextureDesc GetCameraColorDescriptor(RenderGraph renderGraph, [IsReadOnly] in TextureHandle source, bool useDynamicScale); // 0x0000000181FB1F60-0x0000000181FB2050
		internal static void CreateRenderTextureHandles(RenderGraph renderGraph, UniversalResourceData resourceData, [IsReadOnly] in TextureDesc cameraColorDesc, ScreenSpaceAmbientOcclusionSettings settings, bool supportsR8, BlurTypes blurType, bool enableRandomWrite, out TextureHandle aoTexture, out TextureHandle blurTexture, out TextureHandle temporalTexture, out TextureHandle finalTexture); // 0x0000000181FB1A30-0x0000000181FB1EA0
	}
}
