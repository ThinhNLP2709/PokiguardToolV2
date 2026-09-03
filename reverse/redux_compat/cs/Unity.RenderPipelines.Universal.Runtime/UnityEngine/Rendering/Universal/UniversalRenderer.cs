/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal.Internal;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public sealed class UniversalRenderer : ScriptableRenderer // TypeDefIndex: 9858
	{
		// Fields
		private const int k_FinalBlitPassQueueOffset = 1; // Metadata: 0x0069FBD7
		private const int k_AfterFinalBlitPassQueueOffset = 2; // Metadata: 0x0069FBD8
		private const int k_AfterXRCopyDepthQueueOffset = 3; // Metadata: 0x0069FBD9
		private DepthOnlyPass m_DepthPrepass; // 0x58
		private DepthNormalOnlyPass m_DepthNormalPrepass; // 0x60
		private MotionVectorRenderPass m_MotionVectorPass; // 0x68
		private MainLightShadowCasterPass m_MainLightShadowCasterPass; // 0x70
		private AdditionalLightsShadowCasterPass m_AdditionalLightsShadowCasterPass; // 0x78
		private GBufferPass m_GBufferPass; // 0x80
		private DeferredPass m_DeferredPass; // 0x88
		private DrawObjectsPass m_RenderOpaqueForwardOnlyPass; // 0x90
		private DrawObjectsPass m_RenderOpaqueForwardPass; // 0x98
		private DrawObjectsWithRenderingLayersPass m_RenderOpaqueForwardWithRenderingLayersPass; // 0xA0
		private DrawSkyboxPass m_DrawSkyboxPass; // 0xA8
		private CopyDepthPass m_CopyDepthPass; // 0xB0
		private CopyColorPass m_CopyColorPass; // 0xB8
		private DrawObjectsPass m_RenderTransparentForwardPass; // 0xC0
		private InvokeOnRenderObjectCallbackPass m_OnRenderObjectCallbackPass; // 0xC8
		private FinalBlitPass m_FinalBlitPass; // 0xD0
		private FinalBlitPass m_OffscreenUICoverPrepass; // 0xD8
		private CapturePass m_CapturePass; // 0xE0
		private XROcclusionMeshPass m_XROcclusionMeshPass; // 0xE8
		private CopyDepthPass m_XRCopyDepthPass; // 0xF0
		private XRDepthMotionPass m_XRDepthMotionPass; // 0xF8
		private DrawScreenSpaceUIPass m_DrawOffscreenUIPass; // 0x100
		private DrawScreenSpaceUIPass m_DrawOverlayUIPass; // 0x108
		private CopyColorPass m_HistoryRawColorCopyPass; // 0x110
		private CopyColorPass m_HistoryBeforeTransparentsColorCopyPass; // 0x118
		private CopyDepthPass m_HistoryRawDepthCopyPass; // 0x120
		private StencilCrossFadeRenderPass m_StencilCrossFadeRenderPass; // 0x128
		private RTHandle m_TargetColorHandle; // 0x130
		private RTHandle m_TargetDepthHandle; // 0x138
		private ForwardLights m_ForwardLights; // 0x140
		private DeferredLights m_DeferredLights; // 0x148
		private RenderingMode m_RenderingMode; // 0x150
		private DepthPrimingMode m_DepthPrimingMode; // 0x154
		private CopyDepthMode m_CopyDepthMode; // 0x158
		private DepthFormat m_CameraDepthAttachmentFormat; // 0x15C
		private DepthFormat m_CameraDepthTextureFormat; // 0x160
		private bool m_ShadowmapStencil; // 0x164
		private StencilState m_DefaultStencilState; // 0x165
		private LightCookieManager m_LightCookieManager; // 0x178
		private IntermediateTextureMode m_IntermediateTextureMode; // 0x180
		private Material m_BlitMaterial; // 0x188
		private Material m_BlitHDRMaterial; // 0x190
		private Material m_SamplingMaterial; // 0x198
		private Material m_BlitOffscreenUICoverMaterial; // 0x1A0
		private Material m_BackdropFilterCompositeMaterial; // 0x1A8
		private Material m_StencilDeferredMaterial; // 0x1B0
		private Material m_ClusterDeferredMaterial; // 0x1B8
		private Material m_CameraMotionVecMaterial; // 0x1C0
		[CompilerGenerated]
		private bool _postProcessEnabled_k__BackingField; // 0x1C8
		[CompilerGenerated]
		private LayerMask _prepassLayerMask_k__BackingField; // 0x1CC
		[CompilerGenerated]
		private LayerMask _opaqueLayerMask_k__BackingField; // 0x1D0
		[CompilerGenerated]
		private LayerMask _transparentLayerMask_k__BackingField; // 0x1D4
		[CompilerGenerated]
		private bool _shadowTransparentReceive_k__BackingField; // 0x1D8
		[CompilerGenerated]
		private readonly bool _useTileOnlyMode_k__BackingField; // 0x1D9
		private ValidationHandler m_ValidationHandler; // 0x1E0
		private Material m_DebugBlitMaterial; // 0x1E8
		[NoAutoStaticsCleanup]
		private static readonly RTHandle[] s_RenderGraphCameraColorHandles; // 0x00
		[NoAutoStaticsCleanup]
		private static RTHandle s_RenderGraphCameraDepthHandle; // 0x08
		[NoAutoStaticsCleanup]
		private static int s_CurrentColorHandle; // 0x10
		[NoAutoStaticsCleanup]
		private static RTHandle s_RenderGraphDebugTextureHandle; // 0x18
		[NoAutoStaticsCleanup]
		private static RTHandle s_OffscreenUIColorHandle; // 0x20
		[NoAutoStaticsCleanup]
		private static bool s_RequiresIntermediateAttachments; // 0x28
		private bool m_RequiresRenderingLayer; // 0x1F0
		private RenderingLayerUtils.Event m_RenderingLayersEvent; // 0x1F4
		private RenderingLayerUtils.MaskSize m_RenderingLayersMaskSize; // 0x1F8
		private bool m_RenderingLayerProvidesRenderObjectPass; // 0x1FC
		private bool m_RenderingLayerProvidesByDepthNormalPass; // 0x1FD
		private string m_RenderingLayersTextureName; // 0x200
		private ColorGradingLutPass m_ColorGradingLutPassRenderGraph; // 0x208
		private PostProcess m_PostProcess; // 0x210
		private const string _CameraTargetAttachmentAName = "_CameraTargetAttachmentA"; // Metadata: 0x0069FBDA
		private const string _CameraTargetAttachmentBName = "_CameraTargetAttachmentB"; // Metadata: 0x0069FBF3
		private const string _SingleCameraTargetAttachmentName = "_CameraTargetAttachment"; // Metadata: 0x0069FC0C
		private const string _CameraDepthAttachmentName = "_CameraDepthAttachment"; // Metadata: 0x0069FC24
		private bool m_IssuedGPUOcclusionUnsupportedMsg; // 0x218
	
		// Properties
		internal RenderingMode renderingModeRequested { get; } // 0x0000000181C405B0-0x0000000181C405C0 
		internal bool shadowmapStencil { get; } // 0x0000000182019890-0x00000001820198A0 
		private bool deferredModeUnsupported { get; } // 0x0000000182019470-0x0000000182019660 
		internal RenderingMode renderingModeActual { get; } // 0x0000000182019830-0x0000000182019880 
		internal bool usesDeferredLighting { get; } // 0x0000000182019A10-0x0000000182019AD0 
		internal bool usesClusterLightLoop { get; } // 0x0000000182019950-0x0000000182019A10 
		internal bool accurateGbufferNormals { get; } // 0x0000000182019310-0x0000000182019330 
		internal bool needTransparencyPass { get; } // 0x0000000182019660-0x0000000182019730 
		public DepthPrimingMode depthPrimingMode { get; set; } // 0x0000000181C4BB00-0x0000000181C4BB10 0x0000000182019AD0-0x0000000182019AE0
		internal bool postProcessEnabled { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182019810-0x0000000182019820 0x0000000182019AE0-0x0000000182019AF0
		internal DeferredLights deferredLights { get; } // 0x000000018033D220-0x000000018033D230 
		internal LayerMask prepassLayerMask { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182019820-0x0000000182019830 0x0000000182019AF0-0x0000000182019B00
		internal LayerMask opaqueLayerMask { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DAAA10-0x0000000181DAAA20 0x0000000181DAAA60-0x0000000181DAAA70
		internal LayerMask transparentLayerMask { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181DAAA00-0x0000000181DAAA10 0x0000000181DAAA50-0x0000000181DAAA60
		internal bool shadowTransparentReceive { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182019880-0x0000000182019890 0x0000000182019B00-0x0000000182019B10
		internal bool useTileOnlyMode { [CompilerGenerated] get; } // 0x0000000181974C40-0x0000000181974C50 
		internal GraphicsFormat cameraDepthTextureFormat { get; } // 0x0000000182019390-0x00000001820193F0 
		internal GraphicsFormat cameraDepthAttachmentFormat { get; } // 0x0000000182019330-0x0000000182019390 
		private RTHandle currentRenderGraphCameraColorHandle { get; } // 0x00000001820193F0-0x0000000182019470 
		private RTHandle nextRenderGraphCameraColorHandle { get; } // 0x0000000182019730-0x0000000182019810 
		public override bool supportsGPUOcclusion { get; } // 0x00000001820198A0-0x0000000182019950 
	
		// Nested types
		private struct RenderPassInputSummary // TypeDefIndex: 9859
		{
			// Fields
			internal bool requiresDepthTexture; // 0x00
			internal bool requiresNormalsTexture; // 0x01
			internal bool requiresColorTexture; // 0x02
			internal bool requiresMotionVectors; // 0x03
			internal RenderPassEvent requiresNormalTextureEarliestEvent; // 0x04
			internal RenderPassEvent requiresDepthTextureEarliestEvent; // 0x08
		}
	
		private class CopyToDebugTexturePassData // TypeDefIndex: 9860
		{
			// Fields
			internal TextureHandle src; // 0x10
			internal TextureHandle dest; // 0x20
	
			// Constructors
			public CopyToDebugTexturePassData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[IsReadOnly]
		private struct ClearCameraParams // TypeDefIndex: 9861
		{
			// Fields
			internal readonly bool mustClearColor; // 0x00
			internal readonly bool mustClearDepth; // 0x01
			internal readonly Color clearValue; // 0x04
	
			// Constructors
			internal ClearCameraParams(bool clearColor, bool clearDepth, Color clearVal); // 0x0000000182020170-0x0000000182020180
		}
	
		private enum OccluderPass // TypeDefIndex: 9862
		{
			None = 0,
			DepthPrepass = 1,
			ForwardOpaque = 2,
			GBuffer = 3
		}
	
		private enum DepthCopySchedule // TypeDefIndex: 9863
		{
			DuringPrepass = 0,
			AfterPrepass = 1,
			AfterGBuffer = 2,
			AfterOpaques = 3,
			AfterSkybox = 4,
			AfterTransparents = 5,
			None = 6
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9864
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static BaseRenderFunc<CopyToDebugTexturePassData, RasterGraphContext> __9__135_0; // 0x08
			public static Predicate<ScriptableRenderPass> __9__196_0; // 0x10
	
			// Constructors
			static __c(); // 0x0000000182030840-0x00000001820308B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _BlitEmptyTexture_b__135_0(CopyToDebugTexturePassData data, RasterGraphContext context); // 0x0000000182030120-0x00000001820301F0
			internal bool _OnAfterRendering_b__196_0(ScriptableRenderPass x); // 0x0000000182030500-0x0000000182030530
		}
	
		// Constructors
		public UniversalRenderer(UniversalRendererData data); // 0x0000000182017C40-0x0000000182019310
		static UniversalRenderer(); // 0x0000000182017BC0-0x0000000182017C40
	
		// Methods
		public override int SupportedCameraStackingTypes(); // 0x0000000182017230-0x0000000182017260
		protected internal override bool SupportsMotionVectors(); // 0x00000001802E7990-0x00000001802E79A0
		protected internal override bool SupportsCameraOpaque(); // 0x0000000182017260-0x0000000182017280
		protected internal override bool SupportsCameraNormals(); // 0x00000001802E7990-0x00000001802E79A0
		internal int CurrentBackbufferMSAASamples(); // 0x000000018200F160-0x000000018200F2F0
		internal override void UpdateSupportedRenderingFeatures(); // 0x00000001820178A0-0x0000000182017BC0
		protected override void Dispose(bool disposing); // 0x000000018200F510-0x000000018200F780
		internal override void ReleaseRenderTargets(); // 0x0000000182014A20-0x0000000182014A60
		public static bool IsOffscreenDepthTexture(ref CameraData cameraData); // 0x0000000182010910-0x0000000182010A10
		public static bool IsOffscreenDepthTexture(UniversalCameraData cameraData); // 0x0000000182010880-0x0000000182010910
		private static bool IsWebGL(); // 0x00000001802E7840-0x00000001802E7850
		private static bool IsGLESDevice(); // 0x0000000182010860-0x0000000182010880
		private static bool IsGLDevice(); // 0x0000000182010800-0x0000000182010860
		private static bool HasActiveRenderFeatures(List<ScriptableRendererFeature> rendererFeatures); // 0x000000018200FE60-0x000000018200FF50
		private static bool HasPassesRequiringIntermediateTexture(List<ScriptableRenderPass> activeRenderPassQueue); // 0x000000018200FF90-0x0000000182010080
		private static void SetupVFXCameraBuffer(UniversalCameraData cameraData); // 0x0000000182016FF0-0x0000000182017230
		public override void SetupCullingParameters(ref ScriptableCullingParameters cullingParameters, ref CameraData cameraData); // 0x0000000182015B00-0x0000000182015E90
		public override void FinishRendering(CommandBuffer cmd); // 0x00000001802E76C0-0x00000001802E76D0
		private static RenderPassInputSummary GetRenderPassInputs(List<ScriptableRenderPass> activeRenderPassQueue); // 0x000000018200FB20-0x000000018200FC00
		private void AddRequirementsOfInternalFeatures(ref RenderPassInputSummary inputSummary, UniversalCameraData cameraData, bool postProcessingEnabled, bool renderingLayerProvidesByDepthNormalPass, MotionVectorRenderPass motionVectorPass, CopyDepthMode copyDepthMode); // 0x000000018200BD50-0x000000018200BF10
		internal static bool PlatformRequiresExplicitMsaaResolve(); // 0x0000000182014940-0x0000000182014970
		private static bool RequiresIntermediateColorTexture(UniversalCameraData cameraData, [IsReadOnly] in RenderPassInputSummary renderPassInputs, bool usesDeferredLighting, bool applyPostProcessing); // 0x0000000182015420-0x0000000182015730
		private static bool IsScalableBufferManagerUsed(UniversalCameraData cameraData); // 0x0000000182010A10-0x0000000182010AA0
		private static bool CanCopyDepth(UniversalCameraData cameraData); // 0x000000018200C850-0x000000018200C950
		private bool DebugHandlerRequireDepthPass(UniversalCameraData cameraData); // 0x000000018200F2F0-0x000000018200F370
		private void CreateDebugTexture(RenderTextureDescriptor descriptor); // 0x000000018200D120-0x000000018200D240
		private Rect CalculateUVRect(UniversalCameraData cameraData, float width, float height); // 0x000000018200C7E0-0x000000018200C850
		private void CorrectForTextureAspectRatio(ref float width, ref float height, float sourceWidth, float sourceHeight); // 0x000000018200CC50-0x000000018200CC90
		private void SetupRenderGraphFinalPassDebug(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000182015E90-0x0000000182016AF0
		private void SetupAfterPostRenderGraphFinalPassDebug(RenderGraph renderGraph, ContextContainer frameData); // 0x0000000182015930-0x0000000182015B00
		private void BlitToDebugTexture(RenderGraph renderGraph, [IsReadOnly] in TextureHandle source, [IsReadOnly] in TextureHandle destination, bool isSourceTextureColor = false /* Metadata: 0x0069FBB8 */); // 0x000000018200C390-0x000000018200C690
		private void BlitEmptyTexture(RenderGraph renderGraph, [IsReadOnly] in TextureHandle destination, string passName = "Copy To Debug Texture" /* Metadata: 0x0069FBB9 */); // 0x000000018200BF50-0x000000018200C390
		private void CleanupRenderGraphResources(); // 0x000000018200C950-0x000000018200CB70
		public static TextureHandle CreateRenderGraphTexture(RenderGraph renderGraph, RenderTextureDescriptor desc, string name, bool clear, FilterMode filterMode = FilterMode.Point /* Metadata: 0x0069FBCF */, TextureWrapMode wrapMode = TextureWrapMode.Clamp /* Metadata: 0x0069FBD0 */); // 0x000000018200EB40-0x000000018200EC60
		internal static TextureHandle CreateRenderGraphTexture(RenderGraph renderGraph, [IsReadOnly] in RenderTextureDescriptor desc, string name, bool clear, Color color, FilterMode filterMode = FilterMode.Point /* Metadata: 0x0069FBD1 */, TextureWrapMode wrapMode = TextureWrapMode.Clamp /* Metadata: 0x0069FBD2 */, bool discardOnLastUse = false /* Metadata: 0x0069FBD3 */); // 0x000000018200ED60-0x000000018200EEA0
		internal static void GetTextureDesc([IsReadOnly] in RenderTextureDescriptor desc, out TextureDesc rgDesc); // 0x000000018200FC00-0x000000018200FE60
		internal static void GetIntermediateTextureDesc(UniversalCameraData cameraData, out TextureDesc desc); // 0x000000018200FAA0-0x000000018200FB20
		internal static bool HasMatchingAttachmentProperties([IsReadOnly] in RenderTargetInfo rtInfo, [IsReadOnly] in TextureDesc texDesc); // 0x000000018200FF50-0x000000018200FF90
		internal static TextureHandle CreateRenderGraphTexture(RenderGraph renderGraph, [IsReadOnly] in TextureDesc desc, string name, bool clear, Color clearColor, FilterMode filterMode = FilterMode.Point /* Metadata: 0x0069FBD4 */, TextureWrapMode wrapMode = TextureWrapMode.Clamp /* Metadata: 0x0069FBD5 */, bool discardOnLastUse = false /* Metadata: 0x0069FBD6 */); // 0x000000018200EC60-0x000000018200ED60
		private bool RequiresIntermediateAttachments(UniversalCameraData cameraData, [IsReadOnly] in RenderPassInputSummary renderPassInputs, bool requireCopyFromDepth, bool applyPostProcessing, bool overlayUIRequiresComposition); // 0x0000000182015300-0x0000000182015420
		private void UpdateCameraHistory(UniversalCameraData cameraData); // 0x0000000182017280-0x00000001820173D0
		private void CreateRenderGraphCameraRenderTargets(RenderGraph renderGraph, bool isCameraTargetOffscreenDepth, bool requireIntermediateAttachments, bool depthTextureIsDepthFormat); // 0x000000018200DFB0-0x000000018200EB40
		private ClearCameraParams GetClearCameraParams(UniversalCameraData cameraData); // 0x000000018200F890-0x000000018200FAA0
		private void SetupTargetHandles(UniversalCameraData cameraData); // 0x0000000182016C30-0x0000000182016FF0
		private void SetupRenderingLayers(int msaaSamples); // 0x0000000182016B80-0x0000000182016C30
		internal void SetupRenderGraphLights(RenderGraph renderGraph, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData); // 0x0000000182016AF0-0x0000000182016B80
		private void RenderRawColorDepthHistory(RenderGraph renderGraph, UniversalCameraData cameraData, UniversalResourceData resourceData); // 0x0000000182014DD0-0x0000000182015200
		private void RenderBeforeTransparentsColorHistory(RenderGraph renderGraph, UniversalCameraData cameraData, UniversalResourceData resourceData); // 0x0000000182014A60-0x0000000182014CF0
		public override void OnBeginRenderGraphFrame(); // 0x0000000182012220-0x0000000182012280
		internal override void OnRecordRenderGraph(RenderGraph renderGraph, ScriptableRenderContext context); // 0x0000000182013EC0-0x0000000182014940
		public override void OnEndRenderGraphFrame(); // 0x0000000182012280-0x00000001820122E0
		internal override void OnFinishRenderGraphRendering(CommandBuffer cmd); // 0x00000001820122E0-0x0000000182012370
		private void OnOffscreenDepthTextureRendering(RenderGraph renderGraph, ScriptableRenderContext context, UniversalResourceData resourceData, UniversalCameraData cameraData); // 0x0000000182013990-0x0000000182013EC0
		private void OnBeforeRendering(RenderGraph renderGraph); // 0x0000000182011DF0-0x0000000182012220
		private void UpdateInstanceOccluders(RenderGraph renderGraph, UniversalCameraData cameraData, TextureHandle depthTexture); // 0x00000001820173D0-0x00000001820178A0
		private void InstanceOcclusionTest(RenderGraph renderGraph, UniversalCameraData cameraData, OcclusionTest occlusionTest); // 0x00000001820104C0-0x0000000182010690
		private void RecordCustomPassesWithDepthCopyAndMotion(RenderGraph renderGraph, UniversalResourceData resourceData, RenderPassEvent earliestDepthReadEvent, RenderPassEvent currentEvent, bool renderMotionVectors); // 0x0000000182014970-0x0000000182014A20
		private static bool AllowPartialDepthNormalsPrepass(bool isDeferred, RenderPassInputSummary renderPassInputSummary, bool useDepthPriming); // 0x000000018200BF10-0x000000018200BF50
		private static DepthCopySchedule CalculateDepthCopySchedule(RenderPassEvent earliestDepthReadEvent, bool hasFullPrepass); // 0x000000018200C690-0x000000018200C6D0
		private DepthCopySchedule CalculateDepthCopySchedules(UniversalCameraData cameraData, [IsReadOnly] in RenderPassInputSummary renderPassInputs, bool isDeferred, bool requiresDepthPrepass, bool hasFullPrepass); // 0x000000018200C6D0-0x000000018200C7E0
		private void CopyDepthToDepthTexture(RenderGraph renderGraph, UniversalResourceData resourceData); // 0x000000018200CB70-0x000000018200CC50
		private void RenderMotionVectors(RenderGraph renderGraph, UniversalResourceData resourceData); // 0x0000000182014CF0-0x0000000182014DD0
		private void ExecuteScheduledDepthCopyWithMotion(RenderGraph renderGraph, UniversalResourceData resourceData, bool renderMotionVectors); // 0x000000018200F780-0x000000018200F890
		private void OnMainRendering(RenderGraph renderGraph, ScriptableRenderContext context, [IsReadOnly] in RenderPassInputSummary renderPassInputs, bool requiresPrepass); // 0x0000000182012370-0x0000000182013990
		private void OnAfterRendering(RenderGraph renderGraph, bool applyPostProcessing); // 0x0000000182010AA0-0x0000000182011DF0
		private bool RequirePrepassForTextures(UniversalCameraData cameraData, [IsReadOnly] in RenderPassInputSummary renderPassInputs); // 0x0000000182015200-0x0000000182015300
		private static bool IsDepthPrimingEnabledRenderGraph(UniversalCameraData cameraData, [IsReadOnly] in RenderPassInputSummary renderPassInputs, DepthPrimingMode depthPrimingMode, bool requirePrepassForTextures, bool usesDeferredLighting); // 0x0000000182010690-0x0000000182010800
		internal void SetRenderingLayersGlobalTextures(RenderGraph renderGraph); // 0x0000000182015730-0x0000000182015930
		private void ImportBackBuffers(RenderGraph renderGraph, UniversalCameraData cameraData, Color clearBackgroundColor, bool isCameraTargetOffscreenDepth); // 0x0000000182010080-0x00000001820104C0
		private void CreateIntermediateCameraColorAttachment(RenderGraph renderGraph, UniversalCameraData cameraData, [IsReadOnly] in TextureDesc cameraDescriptor, bool clearColor, Color clearBackgroundColor); // 0x000000018200D240-0x000000018200D690
		private void CreateIntermediateCameraDepthAttachment(RenderGraph renderGraph, UniversalCameraData cameraData, [IsReadOnly] in TextureDesc cameraDescriptor, bool clearDepth, Color clearBackgroundDepth, bool depthTextureIsDepthFormat); // 0x000000018200D690-0x000000018200DA40
		private void CreateCameraDepthCopyTexture(RenderGraph renderGraph, TextureDesc descriptor, bool isDepthTexture, Color clearColor); // 0x000000018200CC90-0x000000018200CE80
		private void CreateMotionVectorTextures(RenderGraph renderGraph, TextureDesc descriptor); // 0x000000018200DA40-0x000000018200DCD0
		private void CreateCameraNormalsTexture(RenderGraph renderGraph, TextureDesc descriptor); // 0x000000018200CE80-0x000000018200D120
		private void CreateRenderingLayersTexture(RenderGraph renderGraph, TextureDesc descriptor); // 0x000000018200EEA0-0x000000018200F160
		private void CreateOffscreenUITexture(RenderGraph renderGraph, TextureDesc descriptor); // 0x000000018200DCD0-0x000000018200DFB0
		private void DepthNormalPrepassRender(RenderGraph renderGraph, RenderPassInputSummary renderPassInputs, [IsReadOnly] in TextureHandle depthTarget, uint batchLayerMask, bool setGlobalDepth, bool setGlobalTextures, bool partialPass); // 0x000000018200F370-0x000000018200F510
	}
}
