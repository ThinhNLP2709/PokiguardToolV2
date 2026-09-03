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
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public sealed class UniversalRenderPipeline : RenderPipeline // TypeDefIndex: 9825
	{
		// Fields
		public const string k_ShaderTagName = "UniversalPipeline"; // Metadata: 0x0069F239
		internal const string k_UpscalerName_Auto = "Automatic"; // Metadata: 0x0069F24B
		internal const string k_UpscalerName_Point = "Nearest-Neighbor"; // Metadata: 0x0069F255
		internal const string k_UpscalerName_Linear = "Bilinear"; // Metadata: 0x0069F266
		internal const string k_UpscalerName_FSR1 = "FidelityFX Super Resolution 1.0"; // Metadata: 0x0069F26F
		internal const string k_UpscalerName_STP = "Spatial-Temporal Post-Processing"; // Metadata: 0x0069F28F
		internal static readonly int k_UpscalerHash_Point; // 0x00
		internal static readonly int k_UpscalerHash_Linear; // 0x04
		internal static readonly int k_UpscalerHash_FSR1; // 0x08
		internal static readonly int k_UpscalerHash_STP; // 0x0C
		internal const int k_DefaultRenderingLayerMask = 1; // Metadata: 0x0069F2B0
		private readonly DebugDisplaySettingsUI m_DebugDisplaySettingsUI; // 0x18
		private UniversalRenderPipelineGlobalSettings m_GlobalSettings; // 0x20
		private bool m_FrameNeedsRealBackbufferMSAA; // 0x28
		private int m_FramesSinceRealBackbufferMSAANeeded; // 0x2C
		internal const int realBackbufferMSAADowngradeDelayFrames = 6; // Metadata: 0x0069F2B1
		[CompilerGenerated]
		private UniversalRenderPipelineRuntimeTextures _runtimeTextures_k__BackingField; // 0x30
		[NoAutoStaticsCleanup]
		internal static RenderGraph s_RenderGraph; // 0x10
		[NoAutoStaticsCleanup]
		internal static RTHandleResourcePool s_RTHandlePool; // 0x18
		internal bool apvIsEnabled; // 0x38
		[NoAutoStaticsCleanup]
		internal static bool requireOffscreenUICoverPrepass; // 0x20
		[NoAutoStaticsCleanup]
		internal static bool offscreenUIRenderedInCurrentFrame; // 0x21
		private readonly UniversalRenderPipelineAsset pipelineAsset; // 0x40
		private static LODParameters cachedLODParameters; // 0x24
		internal bool enableHDROutputOnce; // 0x48
		internal bool warnedRuntimeSwitchHDROutputToSDROutput; // 0x49
		private static readonly Vector4 k_DefaultLightPosition; // 0x40
		private static readonly Vector4 k_DefaultLightColor; // 0x50
		private static readonly Vector4 k_DefaultLightAttenuation; // 0x60
		private static readonly Vector4 k_DefaultLightSpotDirection; // 0x70
		private static readonly Vector4 k_DefaultLightsProbeChannel; // 0x80
		private static readonly List<Vector4> s_ShadowBiasData; // 0x90
		private static readonly List<int> s_ShadowResolutionData; // 0x98
		private Comparison<Camera> cameraComparison; // 0x50
		private static readonly Lightmapping.RequestLightsDelegate s_LightsDelegate; // 0xA0
	
		// Properties
		public static float maxShadowBias { get; } // 0x000000018200BB80-0x000000018200BB90 
		public static float minRenderScale { get; } // 0x000000018200BD40-0x000000018200BD50 
		public static float maxRenderScale { get; } // 0x000000018200BB70-0x000000018200BB80 
		public static int maxNumIterationsEnclosingSphere { get; } // 0x000000018200BB60-0x000000018200BB70 
		public static int maxPerObjectLights { get; } // 0x0000000180740830-0x0000000180740840 
		public static int maxVisibleAdditionalLights { get; } // 0x000000018200BBF0-0x000000018200BCC0 
		internal static int lightsPerTile { get; } // 0x000000018200BB10-0x000000018200BB60 
		internal static int maxZBinWords { get; } // 0x0000000180A2FBA0-0x0000000180A2FBB0 
		internal static int maxTileWords { get; } // 0x000000018200BB90-0x000000018200BBF0 
		internal static int maxVisibleReflectionProbes { get; } // 0x000000018200BCC0-0x000000018200BD40 
		internal UniversalRenderPipelineRuntimeTextures runtimeTextures { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public override RenderPipelineGlobalSettings defaultSettings { get; } // 0x00000001802F8630-0x00000001802F8640 
		public static UniversalRenderPipelineAsset asset { get; } // 0x000000018200BA70-0x000000018200BB10 
	
		// Nested types
		internal static class CameraMetadataCache // TypeDefIndex: 9826
		{
			// Fields
			private static readonly Dictionary<EntityId, CameraMetadataCacheEntry> s_MetadataCache; // 0x00
	
			// Nested types
			public class CameraMetadataCacheEntry // TypeDefIndex: 9827
			{
				// Fields
				public ProfilingSampler sampler; // 0x10
	
				// Constructors
				public CameraMetadataCacheEntry(); // 0x00000001802E5CB0-0x00000001802E5CC0
			}
	
			// Constructors
			static CameraMetadataCache(); // 0x0000000181FF7030-0x0000000181FF70C0
	
			// Methods
			public static CameraMetadataCacheEntry GetCached(Camera camera); // 0x0000000181FF6A40-0x0000000181FF6BE0
			private static void RemoveDeletedCameras(); // 0x0000000181FF6BE0-0x0000000181FF7030
			public static void Clear(); // 0x0000000181FF69E0-0x0000000181FF6A40
		}
	
		internal static class Profiling // TypeDefIndex: 9828
		{
			// Nested types
			public static class Pipeline // TypeDefIndex: 9829
			{
				// Fields
				private const string k_Name = "UniversalRenderPipeline"; // Metadata: 0x0069F2B2
				public static readonly ProfilingSampler initializeCameraData; // 0x00
				public static readonly ProfilingSampler initializeStackedCameraData; // 0x08
				public static readonly ProfilingSampler initializeAdditionalCameraData; // 0x10
				public static readonly ProfilingSampler initializeRenderingData; // 0x18
				public static readonly ProfilingSampler initializeShadowData; // 0x20
				public static readonly ProfilingSampler initializeLightData; // 0x28
				public static readonly ProfilingSampler buildAdditionalLightsShadowAtlasLayout; // 0x30
				public static readonly ProfilingSampler getPerObjectLightFlags; // 0x38
				public static readonly ProfilingSampler getMainLightIndex; // 0x40
				public static readonly ProfilingSampler setupPerFrameShaderConstants; // 0x48
				public static readonly ProfilingSampler setupPerCameraShaderConstants; // 0x50
	
				// Nested types
				public static class Renderer // TypeDefIndex: 9830
				{
					// Fields
					private const string k_Name = "ScriptableRenderer"; // Metadata: 0x0069F2CA
					public static readonly ProfilingSampler setupCullingParameters; // 0x00
	
					// Constructors
					static Renderer(); // 0x0000000181FF8A40-0x0000000181FF8AD0
				}
	
				public static class Context // TypeDefIndex: 9831
				{
					// Fields
					private const string k_Name = "ScriptableRenderContext"; // Metadata: 0x0069F2DD
					public static readonly ProfilingSampler submit; // 0x00
	
					// Constructors
					static Context(); // 0x0000000181FF7780-0x0000000181FF7810
				}
	
				// Constructors
				static Pipeline(); // 0x0000000181FF7CA0-0x0000000181FF80B0
			}
		}
	
		[IsReadOnly]
		private struct CameraRenderingScope : IDisposable // TypeDefIndex: 9832
		{
			// Fields
			private static readonly ProfilingSampler beginCameraRenderingSampler; // 0x00
			private static readonly ProfilingSampler endCameraRenderingSampler; // 0x08
			private readonly ScriptableRenderContext m_Context; // 0x00
			private readonly Camera m_Camera; // 0x08
	
			// Constructors
			public CameraRenderingScope(ScriptableRenderContext context, Camera camera); // 0x0000000181FF7280-0x0000000181FF7380
			static CameraRenderingScope(); // 0x0000000181FF71A0-0x0000000181FF7280
	
			// Methods
			public void Dispose(); // 0x0000000181FF70C0-0x0000000181FF71A0
		}
	
		[IsReadOnly]
		private struct ContextRenderingScope : IDisposable // TypeDefIndex: 9833
		{
			// Fields
			private static readonly ProfilingSampler beginContextRenderingSampler; // 0x00
			private static readonly ProfilingSampler endContextRenderingSampler; // 0x08
			private readonly ScriptableRenderContext m_Context; // 0x00
			private readonly List<Camera> m_Cameras; // 0x08
	
			// Constructors
			public ContextRenderingScope(ScriptableRenderContext context, List<Camera> cameras); // 0x0000000181FF7680-0x0000000181FF7780
			static ContextRenderingScope(); // 0x0000000181FF75A0-0x0000000181FF7680
	
			// Methods
			public void Dispose(); // 0x0000000181FF74D0-0x0000000181FF75A0
		}
	
		public class SingleCameraRequest // TypeDefIndex: 9834
		{
			// Fields
			public RenderTexture destination; // 0x10
			public int mipLevel; // 0x18
			public CubemapFace face; // 0x1C
			public int slice; // 0x20
	
			// Constructors
			public SingleCameraRequest(); // 0x0000000181FFAEB0-0x0000000181FFAEC0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9835
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<Camera> __9__51_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181FFB5C0-0x0000000181FFB630
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _.ctor_b__51_0(Camera camera1, Camera camera2); // 0x0000000181FFB500-0x0000000181FFB550
			internal void _.cctor_b__138_0(Light[] requests, NativeArray<LightDataGI> lightsOutput); // 0x0000000181FFAF10-0x0000000181FFB390
		}
	
		// Constructors
		public UniversalRenderPipeline(UniversalRenderPipelineAsset asset); // 0x000000018200B140-0x000000018200BA70
		static UniversalRenderPipeline(); // 0x000000018200AE70-0x000000018200B140
	
		// Methods
		public override string ToString(); // 0x0000000182009E40-0x0000000182009E60
		protected override void Dispose(bool disposing); // 0x0000000182001D80-0x00000001820022A0
		private void DisposeAdditionalCameraData(); // 0x0000000182001CA0-0x0000000182001D80
		protected override void Render(ScriptableRenderContext renderContext, List<Camera> cameras); // 0x0000000182008DB0-0x0000000182008E70
		private void RenderCameras(ScriptableRenderContext renderContext, List<Camera> cameras); // 0x0000000182006920-0x00000001820071A0
		internal void RequireRealBackbufferMSAA(); // 0x000000018060A130-0x000000018060A140
		private void ApplyRealBackbufferMSAARequest(); // 0x0000000181FFEDC0-0x0000000181FFEE70
		private void RequestRealBackbufferMSAA(int samples); // 0x0000000182008E70-0x0000000182008EF0
		protected override bool IsRenderRequestSupported<RequestData>(Camera camera, RequestData data);
		protected override void ProcessRenderRequests<RequestData>(ScriptableRenderContext context, Camera camera, RequestData renderRequest);
		[Obsolete("RenderSingleCamera is obsolete, please use RenderPipeline.SubmitRenderRequest with UniversalRenderer.SingleCameraRequest as RequestData type. #from(2023.1)")]
		public static void RenderSingleCamera(ScriptableRenderContext context, Camera camera); // 0x0000000182008D50-0x0000000182008DB0
		internal static void RenderSingleCameraInternal(ScriptableRenderContext context, Camera camera, bool isLastBaseCamera = true /* Metadata: 0x0069F237 */); // 0x00000001820071A0-0x00000001820072F0
		internal static void RenderSingleCameraInternal(ScriptableRenderContext context, Camera camera, ref UniversalAdditionalCameraData additionalCameraData, bool isLastBaseCamera = true /* Metadata: 0x0069F238 */); // 0x00000001820072F0-0x00000001820077A0
		private static bool TryGetCullingParameters(UniversalCameraData cameraData, out ScriptableCullingParameters cullingParams); // 0x0000000182009E60-0x000000018200A170
		private static void RenderSingleCamera(ScriptableRenderContext context, UniversalCameraData cameraData); // 0x00000001820077A0-0x0000000182008D50
		private static void CreateShadowAtlasAndCullShadowCasters(UniversalLightData lightData, UniversalShadowData shadowData, UniversalCameraData cameraData, ref CullingResults cullResults, ref ScriptableRenderContext context); // 0x0000000182000990-0x0000000182000BA0
		private static void RenderCameraStack(ScriptableRenderContext context, Camera baseCamera, bool isLastBaseCamera); // 0x0000000182005190-0x0000000182006920
		private static void UpdateCameraData(UniversalCameraData baseCameraData, [IsReadOnly] in XRPass xr); // 0x000000018200A170-0x000000018200A5E0
		private static void UpdateOffscreenUIRendering(UniversalCameraData cameraData, bool finalOutputHDR); // 0x000000018200A7A0-0x000000018200A890
		private static void UpdateVolumeFramework(Camera camera, UniversalAdditionalCameraData additionalCameraData); // 0x000000018200AB30-0x000000018200AE70
		private static bool CheckPostProcessForDepth(UniversalCameraData cameraData); // 0x0000000181FFF460-0x0000000181FFF620
		private static bool CheckPostProcessForDepth(); // 0x0000000181FFF620-0x0000000181FFF780
		internal static void SetSupportedRenderingFeatures(UniversalRenderPipelineAsset pipelineAsset); // 0x00000001820093F0-0x0000000182009530
		private static ScriptableRenderer GetRenderer(Camera camera, UniversalAdditionalCameraData additionalCameraData); // 0x0000000182002EB0-0x0000000182002F80
		internal static void InitializeScaledDimensions(Camera camera, UniversalCameraData cameraData); // 0x00000001820046A0-0x0000000182004730
		private static UniversalCameraData CreateCameraData(ContextContainer frameData, Camera camera, UniversalAdditionalCameraData additionalCameraData); // 0x0000000181FFFAC0-0x0000000182000210
		private static void InitializeStackedCameraData(Camera baseCamera, UniversalAdditionalCameraData baseAdditionalCameraData, UniversalCameraData cameraData); // 0x0000000182004730-0x0000000182004E40
		private static void InitializeAdditionalCameraData(Camera camera, UniversalAdditionalCameraData additionalCameraData, bool resolveFinalTarget, bool isLastBaseCamera, UniversalCameraData cameraData); // 0x00000001820032E0-0x0000000182004160
		private static UniversalRenderingData CreateRenderingData(ContextContainer frameData, UniversalRenderPipelineAsset settings, CommandBuffer cmd, RenderingMode? renderingMode, ScriptableRenderer renderer); // 0x0000000182000810-0x0000000182000990
		private static UniversalShadowData CreateShadowData(ContextContainer frameData, UniversalRenderPipelineAsset urpAsset, RenderingMode? renderingMode); // 0x0000000182000BA0-0x0000000182001C50
		private static CullContextData CreateCullContextData(ContextContainer frameData, ScriptableRenderContext context); // 0x0000000182000210-0x0000000182000280
		private static Vector3 GetMainLightCascadeSplit(int mainLightShadowCascadesCount, UniversalRenderPipelineAsset urpAsset); // 0x00000001820029E0-0x0000000182002A80
		private static void InitializeMainLightShadowResolution(UniversalShadowData shadowData); // 0x00000001820045C0-0x00000001820046A0
		private static UniversalPostProcessingData CreatePostProcessingData(ContextContainer frameData, UniversalRenderPipelineAsset settings); // 0x0000000182000540-0x0000000182000630
		private static UniversalResourceData CreateUniversalResourceData(ContextContainer frameData); // 0x0000000182001C50-0x0000000182001CA0
		private static UniversalLightData CreateLightData(ContextContainer frameData, UniversalRenderPipelineAsset settings, NativeArray<VisibleLight> visibleLights, RenderingMode? renderingMode); // 0x0000000182000280-0x0000000182000540
		private static void ApplyTaaRenderingDebugOverrides(ref TemporalAA.Settings taaSettings); // 0x0000000181FFEE70-0x0000000181FFEF20
		private static void UpdateTemporalAAData(UniversalCameraData cameraData, UniversalAdditionalCameraData additionalCameraData); // 0x000000018200A890-0x000000018200A9E0
		private static void UpdateTemporalAATargets(UniversalCameraData cameraData); // 0x000000018200A9E0-0x000000018200AB30
		private static void UpdateCameraStereoMatrices(Camera camera, XRPass xr); // 0x000000018200A5E0-0x000000018200A7A0
		private static PerObjectData GetPerObjectLightFlags(UniversalLightData universalLightData, UniversalRenderPipelineAsset settings, RenderingMode? renderingMode); // 0x0000000182002D10-0x0000000182002E60
		private static int GetBrightestDirectionalLightIndex(UniversalRenderPipelineAsset settings, NativeArray<VisibleLight> visibleLights); // 0x00000001820022A0-0x0000000182002400
		private static int GetMainLightIndex(UniversalRenderPipelineAsset settings, NativeArray<VisibleLight> visibleLights); // 0x0000000182002A80-0x0000000182002D10
		private void SetupPerFrameShaderConstants(); // 0x0000000182009AF0-0x0000000182009DE0
		private static void SetupPerCameraShaderConstants(CommandBuffer cmd); // 0x0000000182009530-0x0000000182009AF0
		private static void CheckAndApplyDebugSettings(ref RenderingData renderingData); // 0x0000000181FFF090-0x0000000181FFF460
		private static ImageUpscalingFilter ResolveUpscalingFilterSelection(Vector2 imageSize, float renderScale, UpscalingFilterSelection selection); // 0x0000000182008EF0-0x00000001820090F0
		internal static bool HDROutputForMainDisplayIsActive(); // 0x0000000182003190-0x00000001820032E0
		internal static bool HDROutputForAnyDisplayIsActive(); // 0x0000000182003100-0x0000000182003190
		private void SetHDRState(List<Camera> cameras); // 0x00000001820090F0-0x00000001820093F0
		internal static void GetHDROutputLuminanceParameters(HDROutputUtils.HDRDisplayInformation hdrDisplayInformation, ColorGamut hdrDisplayColorGamut, Tonemapping tonemapping, out Vector4 hdrOutputParameters); // 0x0000000182002500-0x0000000182002640
		internal static void GetHDROutputGradingParameters(Tonemapping tonemapping, out Vector4 hdrOutputParameters); // 0x0000000182002400-0x0000000182002500
		private static void ApplyAdaptivePerformance(UniversalCameraData cameraData); // 0x0000000181FFEB60-0x0000000181FFEDC0
		private static void ApplyAdaptivePerformance(ContextContainer frameData); // 0x0000000181FFE8F0-0x0000000181FFEB60
		private static AdditionalLightsShadowAtlasLayout BuildAdditionalLightsShadowAtlasLayout(UniversalLightData lightData, UniversalShadowData shadowData, UniversalCameraData cameraData); // 0x0000000181FFEF20-0x0000000181FFF090
		private static void AdjustUIOverlayOwnership(int cameraCount); // 0x0000000181FFE840-0x0000000181FFE8F0
		public static bool IsGameCamera(Camera camera); // 0x0000000182004E40-0x0000000182004F10
		private void SortCameras(List<Camera> cameras); // 0x0000000182009DE0-0x0000000182009E40
		private int GetLastBaseCameraIndex(List<Camera> cameras); // 0x00000001820027B0-0x0000000182002890
		internal static GraphicsFormat MakeRenderTextureGraphicsFormat(bool isHdrEnabled, HDRColorBufferPrecision requestHDRColorBufferPrecision, bool needsAlpha); // 0x0000000182004F10-0x0000000182004F80
		internal static GraphicsFormat MakeUnormRenderTextureGraphicsFormat(); // 0x0000000182004F80-0x0000000182004FB0
		internal static void CreateBackbufferInfo(Camera camera, UniversalCameraData cameraData, bool needsAlpha); // 0x0000000181FFF780-0x0000000181FFFAC0
		internal static int GetIntermediateTexturesMSAA(UniversalCameraData cameraData, ScriptableRenderer renderer); // 0x0000000182002640-0x00000001820027B0
		internal static RenderTextureDescriptor CreateRenderTextureDescriptor(Camera camera, UniversalCameraData cameraData, int msaaSamples); // 0x0000000182000630-0x0000000182000810
		public static void GetLightAttenuationAndSpotDirection(UnityEngine.LightType lightType, float lightRange, Matrix4x4 lightLocalToWorldMatrix, float spotAngle, float? innerSpotAngle, out Vector4 lightAttenuation, out Vector4 lightSpotDir); // 0x0000000182002890-0x00000001820029E0
		internal static void GetPunctualLightDistanceAttenuation(float lightRange, ref Vector4 lightAttenuation); // 0x0000000182002E60-0x0000000182002EB0
		internal static void GetSpotAngleAttenuation(float spotAngle, float? innerSpotAngle, ref Vector4 lightAttenuation); // 0x0000000182002F80-0x00000001820030B0
		internal static void GetSpotDirection(ref Matrix4x4 lightLocalToWorldMatrix, out Vector4 lightSpotDir); // 0x00000001820030B0-0x0000000182003100
		public static void InitializeLightConstants_Common(NativeArray<VisibleLight> lights, int lightIndex, out Vector4 lightPos, out Vector4 lightColor, out Vector4 lightAttenuation, out Vector4 lightSpotDir, out Vector4 lightOcclusionProbeChannel); // 0x0000000182004160-0x00000001820045C0
		private static void RecordAndExecuteRenderGraph(RenderGraph renderGraph, ScriptableRenderContext context, ScriptableRenderer renderer, CommandBuffer cmd, Camera camera); // 0x0000000182004FB0-0x0000000182005190
	}
}
