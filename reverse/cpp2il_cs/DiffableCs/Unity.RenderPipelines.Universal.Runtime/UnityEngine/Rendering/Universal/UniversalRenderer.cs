namespace UnityEngine.Rendering.Universal;

public sealed class UniversalRenderer : ScriptableRenderer
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<ScriptableRenderPass> <>9__111_0; //Field offset: 0x8
		public static Predicate<ScriptableRenderPass> <>9__111_1; //Field offset: 0x10
		public static BaseRenderFunc<CopyToDebugTexturePassData, RasterGraphContext> <>9__140_0; //Field offset: 0x18
		public static Predicate<ScriptableRenderPass> <>9__196_0; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal void <BlitEmptyTexture>b__140_0(CopyToDebugTexturePassData data, RasterGraphContext context) { }

		internal bool <OnAfterRendering>b__196_0(ScriptableRenderPass x) { }

		internal bool <Setup>b__111_0(ScriptableRenderPass x) { }

		internal bool <Setup>b__111_1(ScriptableRenderPass x) { }

	}

	private enum ColorCopySchedule
	{
		AfterSkybox = 0,
		None = 1,
	}

	private class CopyToDebugTexturePassData
	{
		internal TextureHandle src; //Field offset: 0x10
		internal TextureHandle dest; //Field offset: 0x20

		public CopyToDebugTexturePassData() { }

	}

	private enum DepthCopySchedule
	{
		DuringPrepass = 0,
		AfterPrepass = 1,
		AfterGBuffer = 2,
		AfterOpaques = 3,
		AfterSkybox = 4,
		AfterTransparents = 5,
		None = 6,
	}

	private static class Profiling
	{
		private const string k_Name = "UniversalRenderer"; //Field offset: 0x0
		public static readonly ProfilingSampler createCameraRenderTarget; //Field offset: 0x0

		private static Profiling() { }

	}

	private struct RenderPassInputSummary
	{
		internal bool requiresDepthTexture; //Field offset: 0x0
		internal bool requiresDepthPrepass; //Field offset: 0x1
		internal bool requiresNormalsTexture; //Field offset: 0x2
		internal bool requiresColorTexture; //Field offset: 0x3
		internal bool requiresColorTextureCreated; //Field offset: 0x4
		internal bool requiresMotionVectors; //Field offset: 0x5
		internal RenderPassEvent requiresDepthNormalAtEvent; //Field offset: 0x8
		internal RenderPassEvent requiresDepthTextureEarliestEvent; //Field offset: 0xC

	}

	private struct TextureCopySchedules
	{
		internal DepthCopySchedule depth; //Field offset: 0x0
		internal ColorCopySchedule color; //Field offset: 0x4

	}

	private const GraphicsFormat k_DepthStencilFormatDefault = 94; //Field offset: 0x0
	private const int k_FinalBlitPassQueueOffset = 1; //Field offset: 0x0
	private const int k_AfterFinalBlitPassQueueOffset = 2; //Field offset: 0x0
	private static readonly List<ShaderTagId> k_DepthNormalsOnly; //Field offset: 0x0
	private const string _CameraUpscaledTargetAttachmentBName = "_CameraUpscaledTargetAttachmentB"; //Field offset: 0x0
	private const string _CameraUpscaledTargetAttachmentAName = "_CameraUpscaledTargetAttachmentA"; //Field offset: 0x0
	private const string _CameraTargetAttachmentBName = "_CameraTargetAttachmentB"; //Field offset: 0x0
	private const string _CameraTargetAttachmentAName = "_CameraTargetAttachmentA"; //Field offset: 0x0
	private static RTHandle[] m_RenderGraphCameraColorHandles; //Field offset: 0x8
	private static RTHandle[] m_RenderGraphUpscaledCameraColorHandles; //Field offset: 0x10
	private static RTHandle m_RenderGraphCameraDepthHandle; //Field offset: 0x18
	private static int m_CurrentColorHandle; //Field offset: 0x20
	private static bool m_UseUpscaledColorHandle; //Field offset: 0x24
	private static RTHandle m_RenderGraphDebugTextureHandle; //Field offset: 0x28
	private static bool m_CreateColorAttachment; //Field offset: 0x30
	private static bool m_CreateDepthAttachment; //Field offset: 0x31
	private bool m_Clustering; //Field offset: 0x148
	private DepthOnlyPass m_DepthPrepass; //Field offset: 0x150
	private DepthNormalOnlyPass m_DepthNormalPrepass; //Field offset: 0x158
	private CopyDepthPass m_PrimedDepthCopyPass; //Field offset: 0x160
	private MotionVectorRenderPass m_MotionVectorPass; //Field offset: 0x168
	private MainLightShadowCasterPass m_MainLightShadowCasterPass; //Field offset: 0x170
	private AdditionalLightsShadowCasterPass m_AdditionalLightsShadowCasterPass; //Field offset: 0x178
	private GBufferPass m_GBufferPass; //Field offset: 0x180
	private CopyDepthPass m_GBufferCopyDepthPass; //Field offset: 0x188
	private DeferredPass m_DeferredPass; //Field offset: 0x190
	private DrawObjectsPass m_RenderOpaqueForwardOnlyPass; //Field offset: 0x198
	private DrawObjectsPass m_RenderOpaqueForwardPass; //Field offset: 0x1A0
	private DrawObjectsWithRenderingLayersPass m_RenderOpaqueForwardWithRenderingLayersPass; //Field offset: 0x1A8
	private DrawSkyboxPass m_DrawSkyboxPass; //Field offset: 0x1B0
	private CopyDepthPass m_CopyDepthPass; //Field offset: 0x1B8
	private CopyColorPass m_CopyColorPass; //Field offset: 0x1C0
	private TransparentSettingsPass m_TransparentSettingsPass; //Field offset: 0x1C8
	private DrawObjectsPass m_RenderTransparentForwardPass; //Field offset: 0x1D0
	private InvokeOnRenderObjectCallbackPass m_OnRenderObjectCallbackPass; //Field offset: 0x1D8
	private FinalBlitPass m_FinalBlitPass; //Field offset: 0x1E0
	private CapturePass m_CapturePass; //Field offset: 0x1E8
	private XROcclusionMeshPass m_XROcclusionMeshPass; //Field offset: 0x1F0
	private CopyDepthPass m_XRCopyDepthPass; //Field offset: 0x1F8
	private XRDepthMotionPass m_XRDepthMotionPass; //Field offset: 0x200
	private DrawScreenSpaceUIPass m_DrawOffscreenUIPass; //Field offset: 0x208
	private DrawScreenSpaceUIPass m_DrawOverlayUIPass; //Field offset: 0x210
	private CopyColorPass m_HistoryRawColorCopyPass; //Field offset: 0x218
	private CopyDepthPass m_HistoryRawDepthCopyPass; //Field offset: 0x220
	internal RenderTargetBufferSystem m_ColorBufferSystem; //Field offset: 0x228
	internal RTHandle m_ActiveCameraColorAttachment; //Field offset: 0x230
	private RTHandle m_ColorFrontBuffer; //Field offset: 0x238
	internal RTHandle m_ActiveCameraDepthAttachment; //Field offset: 0x240
	internal RTHandle m_CameraDepthAttachment; //Field offset: 0x248
	private RTHandle m_TargetColorHandle; //Field offset: 0x250
	private RTHandle m_TargetDepthHandle; //Field offset: 0x258
	internal RTHandle m_DepthTexture; //Field offset: 0x260
	private RTHandle m_NormalsTexture; //Field offset: 0x268
	private RTHandle m_DecalLayersTexture; //Field offset: 0x270
	private RTHandle m_OpaqueColor; //Field offset: 0x278
	private RTHandle m_MotionVectorColor; //Field offset: 0x280
	private RTHandle m_MotionVectorDepth; //Field offset: 0x288
	private ForwardLights m_ForwardLights; //Field offset: 0x290
	private DeferredLights m_DeferredLights; //Field offset: 0x298
	private RenderingMode m_RenderingMode; //Field offset: 0x2A0
	private DepthPrimingMode m_DepthPrimingMode; //Field offset: 0x2A4
	private CopyDepthMode m_CopyDepthMode; //Field offset: 0x2A8
	private DepthFormat m_CameraDepthAttachmentFormat; //Field offset: 0x2AC
	private DepthFormat m_CameraDepthTextureFormat; //Field offset: 0x2B0
	private bool m_DepthPrimingRecommended; //Field offset: 0x2B4
	private StencilState m_DefaultStencilState; //Field offset: 0x2B5
	private LightCookieManager m_LightCookieManager; //Field offset: 0x2C8
	private IntermediateTextureMode m_IntermediateTextureMode; //Field offset: 0x2D0
	private bool m_VulkanEnablePreTransform; //Field offset: 0x2D4
	private Material m_BlitMaterial; //Field offset: 0x2D8
	private Material m_BlitHDRMaterial; //Field offset: 0x2E0
	private Material m_SamplingMaterial; //Field offset: 0x2E8
	private Material m_StencilDeferredMaterial; //Field offset: 0x2F0
	private Material m_CameraMotionVecMaterial; //Field offset: 0x2F8
	private PostProcessPasses m_PostProcessPasses; //Field offset: 0x300
	[CompilerGenerated]
	private LayerMask <opaqueLayerMask>k__BackingField; //Field offset: 0x340
	[CompilerGenerated]
	private LayerMask <transparentLayerMask>k__BackingField; //Field offset: 0x344
	private Material m_DebugBlitMaterial; //Field offset: 0x348
	private bool m_RequiresRenderingLayer; //Field offset: 0x350
	private Event m_RenderingLayersEvent; //Field offset: 0x354
	private MaskSize m_RenderingLayersMaskSize; //Field offset: 0x358
	private bool m_RenderingLayerProvidesRenderObjectPass; //Field offset: 0x35C
	private bool m_RenderingLayerProvidesByDepthNormalPass; //Field offset: 0x35D
	private string m_RenderingLayersTextureName; //Field offset: 0x360
	private bool m_IssuedGPUOcclusionUnsupportedMsg; //Field offset: 0x368

	internal bool accurateGbufferNormals
	{
		internal get { } //Length: 25
	}

	internal GraphicsFormat cameraDepthAttachmentFormat
	{
		internal get { } //Length: 22
	}

	internal GraphicsFormat cameraDepthTextureFormat
	{
		internal get { } //Length: 22
	}

	internal RTHandle colorGradingLut
	{
		internal get { } //Length: 8
	}

	internal ColorGradingLutPass colorGradingLutPass
	{
		internal get { } //Length: 8
	}

	private RTHandle currentRenderGraphCameraColorHandle
	{
		private get { } //Length: 196
	}

	internal DeferredLights deferredLights
	{
		internal get { } //Length: 8
	}

	public DepthPrimingMode depthPrimingMode
	{
		 get { } //Length: 7
		 set { } //Length: 7
	}

	internal PostProcessPass finalPostProcessPass
	{
		internal get { } //Length: 8
	}

	internal bool needTransparencyPass
	{
		internal get { } //Length: 194
	}

	private RTHandle nextRenderGraphCameraColorHandle
	{
		private get { } //Length: 113
	}

	internal LayerMask opaqueLayerMask
	{
		[CompilerGenerated]
		internal get { } //Length: 7
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	internal PostProcessPass postProcessPass
	{
		internal get { } //Length: 8
	}

	internal RenderingMode renderingModeActual
	{
		internal get { } //Length: 128
	}

	internal RenderingMode renderingModeRequested
	{
		internal get { } //Length: 7
	}

	public virtual bool supportsGPUOcclusion
	{
		 get { } //Length: 152
	}

	internal virtual bool supportsNativeRenderPassRendergraphCompiler
	{
		internal get { } //Length: 3
	}

	internal LayerMask transparentLayerMask
	{
		[CompilerGenerated]
		internal get { } //Length: 7
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	private static UniversalRenderer() { }

	public UniversalRenderer(UniversalRendererData data) { }

	private bool AllowPartialDepthNormalsPrepass(bool isDeferred, RenderPassEvent requiresDepthNormalEvent) { }

	private void BlitEmptyTexture(RenderGraph renderGraph, TextureHandle destination, string passName = "Copy To Debug Texture") { }

	private void BlitToDebugTexture(RenderGraph renderGraph, TextureHandle source, TextureHandle destination, bool isSourceTextureColor = false) { }

	private DepthCopySchedule CalculateDepthCopySchedule(RenderPassEvent earliestDepthReadEvent, bool hasFullPrepass) { }

	private TextureCopySchedules CalculateTextureCopySchedules(UniversalCameraData cameraData, RenderPassInputSummary renderPassInputs, bool isDeferred, bool requiresDepthPrepass, bool hasFullPrepass) { }

	private Rect CalculateUVRect(UniversalCameraData cameraData, float width, float height) { }

	private Rect CalculateUVRect(UniversalCameraData cameraData, int textureHeightPercent) { }

	private bool CameraHasPostProcessingWithDepth(UniversalCameraData cameraData) { }

	private bool CanCopyDepth(UniversalCameraData cameraData) { }

	private void CleanupRenderGraphResources() { }

	private void CopyDepthToDepthTexture(RenderGraph renderGraph, UniversalResourceData resourceData) { }

	private void CorrectForTextureAspectRatio(ref float width, ref float height, float sourceWidth, float sourceHeight) { }

	private void CreateAfterPostProcessTexture(RenderGraph renderGraph, RenderTextureDescriptor descriptor) { }

	private void CreateCameraDepthCopyTexture(RenderGraph renderGraph, RenderTextureDescriptor descriptor, bool isDepthTexture) { }

	private void CreateCameraNormalsTexture(RenderGraph renderGraph, RenderTextureDescriptor descriptor) { }

	private void CreateCameraRenderTarget(ScriptableRenderContext context, ref RenderTextureDescriptor descriptor, CommandBuffer cmd, UniversalCameraData cameraData) { }

	private void CreateDebugTexture(RenderTextureDescriptor descriptor) { }

	private void CreateMotionVectorTextures(RenderGraph renderGraph, RenderTextureDescriptor descriptor) { }

	private void CreateRenderGraphCameraRenderTargets(RenderGraph renderGraph, bool isCameraTargetOffscreenDepth) { }

	internal static TextureHandle CreateRenderGraphTexture(RenderGraph renderGraph, RenderTextureDescriptor desc, string name, bool clear, Color color, FilterMode filterMode = 0, TextureWrapMode wrapMode = 1) { }

	public static TextureHandle CreateRenderGraphTexture(RenderGraph renderGraph, RenderTextureDescriptor desc, string name, bool clear, FilterMode filterMode = 0, TextureWrapMode wrapMode = 1) { }

	private void CreateRenderingLayersTexture(RenderGraph renderGraph, RenderTextureDescriptor descriptor) { }

	private bool DebugHandlerRequireDepthPass(UniversalCameraData cameraData) { }

	private void DepthNormalPrepassRender(RenderGraph renderGraph, RenderPassInputSummary renderPassInputs, TextureHandle depthTarget, uint batchLayerMask, bool setGlobalDepth, bool setGlobalTextures) { }

	protected virtual void Dispose(bool disposing) { }

	internal virtual void EnableSwapBufferMSAA(bool enable) { }

	private void EnqueueDeferred(RenderTextureDescriptor cameraTargetDescriptor, bool hasDepthPrepass, bool hasNormalPrepass, bool hasRenderingLayerPrepass, bool applyMainShadow, bool applyAdditionalShadow) { }

	private void ExecuteScheduledDepthCopyWithMotion(RenderGraph renderGraph, UniversalResourceData resourceData, bool renderMotionVectors) { }

	public virtual void FinishRendering(CommandBuffer cmd) { }

	internal bool get_accurateGbufferNormals() { }

	internal GraphicsFormat get_cameraDepthAttachmentFormat() { }

	internal GraphicsFormat get_cameraDepthTextureFormat() { }

	internal RTHandle get_colorGradingLut() { }

	internal ColorGradingLutPass get_colorGradingLutPass() { }

	private RTHandle get_currentRenderGraphCameraColorHandle() { }

	internal DeferredLights get_deferredLights() { }

	public DepthPrimingMode get_depthPrimingMode() { }

	internal PostProcessPass get_finalPostProcessPass() { }

	internal bool get_needTransparencyPass() { }

	private RTHandle get_nextRenderGraphCameraColorHandle() { }

	[CompilerGenerated]
	internal LayerMask get_opaqueLayerMask() { }

	internal PostProcessPass get_postProcessPass() { }

	internal RenderingMode get_renderingModeActual() { }

	internal RenderingMode get_renderingModeRequested() { }

	public virtual bool get_supportsGPUOcclusion() { }

	internal virtual bool get_supportsNativeRenderPassRendergraphCompiler() { }

	[CompilerGenerated]
	internal LayerMask get_transparentLayerMask() { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal virtual RTHandle GetCameraColorBackBuffer(CommandBuffer cmd) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal virtual RTHandle GetCameraColorFrontBuffer(CommandBuffer cmd) { }

	private RenderPassInputSummary GetRenderPassInputs(bool isTemporalAAEnabled, bool postProcessingEnabled) { }

	internal bool HasActiveRenderFeatures() { }

	internal bool HasPassesRequiringIntermediateTexture() { }

	private void InstanceOcclusionTest(RenderGraph renderGraph, UniversalCameraData cameraData, OcclusionTest occlusionTest) { }

	private bool IsDepthPrimingEnabled(UniversalCameraData cameraData) { }

	private bool IsGLDevice() { }

	private bool IsGLESDevice() { }

	public static bool IsOffscreenDepthTexture(ref CameraData cameraData) { }

	public static bool IsOffscreenDepthTexture(UniversalCameraData cameraData) { }

	private bool IsWebGL() { }

	private void OnAfterRendering(RenderGraph renderGraph) { }

	private void OnBeforeRendering(RenderGraph renderGraph) { }

	public virtual void OnBeginRenderGraphFrame() { }

	public virtual void OnEndRenderGraphFrame() { }

	internal virtual void OnFinishRenderGraphRendering(CommandBuffer cmd) { }

	private void OnMainRendering(RenderGraph renderGraph, ScriptableRenderContext context) { }

	private void OnOffscreenDepthTextureRendering(RenderGraph renderGraph, ScriptableRenderContext context, UniversalResourceData resourceData, UniversalCameraData cameraData) { }

	internal virtual void OnRecordRenderGraph(RenderGraph renderGraph, ScriptableRenderContext context) { }

	private bool PlatformRequiresExplicitMsaaResolve() { }

	private void RecordCustomPassesWithDepthCopyAndMotion(RenderGraph renderGraph, UniversalResourceData resourceData, RenderPassEvent earliestDepthReadEvent, RenderPassEvent currentEvent, bool renderMotionVectors) { }

	internal virtual void ReleaseRenderTargets() { }

	private void RenderMotionVectors(RenderGraph renderGraph, UniversalResourceData resourceData) { }

	private void RenderRawColorDepthHistory(RenderGraph renderGraph, UniversalCameraData cameraData, UniversalResourceData resourceData) { }

	private bool RequireDepthPrepass(UniversalCameraData cameraData, ref RenderPassInputSummary renderPassInputs) { }

	private bool RequireDepthTexture(UniversalCameraData cameraData, bool requiresDepthPrepass, ref RenderPassInputSummary renderPassInputs) { }

	private void RequiresColorAndDepthAttachments(RenderGraph renderGraph, out bool createColorTexture, out bool createDepthTexture, UniversalCameraData cameraData, ref RenderPassInputSummary renderPassInputs) { }

	private bool RequiresIntermediateColorTexture(UniversalCameraData cameraData, ref RenderPassInputSummary renderPassInputs) { }

	public void set_depthPrimingMode(DepthPrimingMode value) { }

	[CompilerGenerated]
	internal void set_opaqueLayerMask(LayerMask value) { }

	[CompilerGenerated]
	internal void set_transparentLayerMask(LayerMask value) { }

	internal void SetRenderingLayersGlobalTextures(RenderGraph renderGraph) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Setup(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private void SetupAfterPostRenderGraphFinalPassDebug(RenderGraph renderGraph, ContextContainer frameData) { }

	public virtual void SetupCullingParameters(ref ScriptableCullingParameters cullingParameters, ref CameraData cameraData) { }

	private void SetupFinalPassDebug(UniversalCameraData cameraData) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void SetupLights(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private void SetupRawColorDepthHistory(UniversalCameraData cameraData, ref RenderTextureDescriptor cameraTargetDescriptor) { }

	private void SetupRenderGraphFinalPassDebug(RenderGraph renderGraph, ContextContainer frameData) { }

	internal void SetupRenderGraphLights(RenderGraph renderGraph, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData) { }

	private void SetupRenderingLayers(int msaaSamples) { }

	private void SetupVFXCameraBuffer(UniversalCameraData cameraData) { }

	private bool ShouldApplyPostProcessing(bool postProcessEnabled) { }

	public virtual int SupportedCameraStackingTypes() { }

	protected private virtual bool SupportsMotionVectors() { }

	internal virtual void SwapColorBuffer(CommandBuffer cmd) { }

	private void UpdateCameraHistory(UniversalCameraData cameraData) { }

	private void UpdateInstanceOccluders(RenderGraph renderGraph, UniversalCameraData cameraData, TextureHandle depthTexture) { }

}

