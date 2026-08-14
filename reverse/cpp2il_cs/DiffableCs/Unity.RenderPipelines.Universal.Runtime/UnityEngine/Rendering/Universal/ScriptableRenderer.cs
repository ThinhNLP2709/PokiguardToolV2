namespace UnityEngine.Rendering.Universal;

public abstract class ScriptableRenderer : IDisposable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, UnsafeGraphContext> <>9__138_0; //Field offset: 0x8
		public static BaseRenderFunc<VFXProcessCameraPassData, UnsafeGraphContext> <>9__140_0; //Field offset: 0x10
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__141_0; //Field offset: 0x18
		public static BaseRenderFunc<BeginXRPassData, RasterGraphContext> <>9__147_0; //Field offset: 0x20
		public static BaseRenderFunc<EndXRPassData, RasterGraphContext> <>9__149_0; //Field offset: 0x28
		public static BaseRenderFunc<DummyData, UnsafeGraphContext> <>9__151_0; //Field offset: 0x30

		private static <>c() { }

		public <>c() { }

		internal void <BeginRenderGraphXRRendering>b__147_0(BeginXRPassData data, RasterGraphContext context) { }

		internal void <EndRenderGraphXRRendering>b__149_0(EndXRPassData data, RasterGraphContext context) { }

		internal void <InitRenderGraphFrame>b__138_0(PassData data, UnsafeGraphContext rgContext) { }

		internal void <ProcessVFXCameraCommand>b__140_0(VFXProcessCameraPassData data, UnsafeGraphContext context) { }

		internal void <SetEditorTarget>b__151_0(DummyData data, UnsafeGraphContext context) { }

		internal void <SetupRenderGraphCameraProperties>b__141_0(PassData data, RasterGraphContext context) { }

	}

	private class BeginXRPassData
	{
		internal UniversalCameraData cameraData; //Field offset: 0x10

		public BeginXRPassData() { }

	}

	private class DrawGizmosPassData
	{
		public RendererListHandle gizmoRenderList; //Field offset: 0x10

		public DrawGizmosPassData() { }

	}

	private class DrawWireOverlayPassData
	{
		public RendererListHandle wireOverlayList; //Field offset: 0x10

		public DrawWireOverlayPassData() { }

	}

	private class DummyData
	{

		public DummyData() { }

	}

	private class EndXRPassData
	{
		public UniversalCameraData cameraData; //Field offset: 0x10

		public EndXRPassData() { }

	}

	private class PassData
	{
		internal ScriptableRenderer renderer; //Field offset: 0x10
		internal UniversalCameraData cameraData; //Field offset: 0x18
		internal bool isTargetBackbuffer; //Field offset: 0x20
		internal Vector2Int cameraTargetSizeCopy; //Field offset: 0x24

		public PassData() { }

	}

	private static class Profiling
	{
		internal static class RenderBlock
		{
			private const string k_Name = "RenderPassBlock"; //Field offset: 0x0
			public static readonly ProfilingSampler beforeRendering; //Field offset: 0x0
			public static readonly ProfilingSampler mainRenderingOpaque; //Field offset: 0x8
			public static readonly ProfilingSampler mainRenderingTransparent; //Field offset: 0x10
			public static readonly ProfilingSampler afterRendering; //Field offset: 0x18

			private static RenderBlock() { }

		}

		internal static class RenderPass
		{
			private const string k_Name = "ScriptableRenderPass"; //Field offset: 0x0
			public static readonly ProfilingSampler configure; //Field offset: 0x0
			public static readonly ProfilingSampler setRenderPassAttachments; //Field offset: 0x8

			private static RenderPass() { }

		}

		public static readonly ProfilingSampler setMRTAttachmentsList; //Field offset: 0x0
		private const string k_Name = "ScriptableRenderer"; //Field offset: 0x0
		public static readonly ProfilingSampler setAttachmentList; //Field offset: 0x8
		public static readonly ProfilingSampler execute; //Field offset: 0x10
		public static readonly ProfilingSampler setupFrameData; //Field offset: 0x18
		public static readonly ProfilingSampler setPerCameraShaderVariables; //Field offset: 0x20
		public static readonly ProfilingSampler sortRenderPasses; //Field offset: 0x28
		public static readonly ProfilingSampler recordRenderGraph; //Field offset: 0x30
		public static readonly ProfilingSampler setupLights; //Field offset: 0x38
		public static readonly ProfilingSampler setupCamera; //Field offset: 0x40
		public static readonly ProfilingSampler vfxProcessCamera; //Field offset: 0x48
		public static readonly ProfilingSampler addRenderPasses; //Field offset: 0x50
		public static readonly ProfilingSampler setupRenderPasses; //Field offset: 0x58
		public static readonly ProfilingSampler clearRenderingState; //Field offset: 0x60
		public static readonly ProfilingSampler internalStartRendering; //Field offset: 0x68
		public static readonly ProfilingSampler internalFinishRenderingCommon; //Field offset: 0x70
		public static readonly ProfilingSampler drawGizmos; //Field offset: 0x78
		public static readonly ProfilingSampler drawWireOverlay; //Field offset: 0x80
		internal static readonly ProfilingSampler beginXRRendering; //Field offset: 0x88
		internal static readonly ProfilingSampler endXRRendering; //Field offset: 0x90
		internal static readonly ProfilingSampler initRenderGraphFrame; //Field offset: 0x98
		internal static readonly ProfilingSampler setEditorTarget; //Field offset: 0xA0

		private static Profiling() { }

	}

	public struct RenderBlocks : IDisposable
	{
		internal struct BlockRange : IDisposable
		{
			private int m_Current; //Field offset: 0x0
			private int m_End; //Field offset: 0x4

			public int Current
			{
				 get { } //Length: 3
			}

			public BlockRange(int begin, int end) { }

			public override void Dispose() { }

			public int get_Current() { }

			public BlockRange GetEnumerator() { }

			public bool MoveNext() { }

		}

		private NativeArray<RenderPassEvent> m_BlockEventLimits; //Field offset: 0x0
		private NativeArray<Int32> m_BlockRanges; //Field offset: 0x10
		private NativeArray<Int32> m_BlockRangeLengths; //Field offset: 0x20

		public RenderBlocks(List<ScriptableRenderPass> activeRenderPassQueue) { }

		public override void Dispose() { }

		private void FillBlockRanges(List<ScriptableRenderPass> activeRenderPassQueue) { }

		public int GetLength(int index) { }

		public BlockRange GetRange(int index) { }

	}

	internal class RenderingFeatures
	{
		[CompilerGenerated]
		private bool <cameraStacking>k__BackingField; //Field offset: 0x10
		[CompilerGenerated]
		private bool <msaa>k__BackingField; //Field offset: 0x11

		[Obsolete("cameraStacking has been deprecated use SupportedCameraRenderTypes() in ScriptableRenderer instead.", True)]
		public bool cameraStacking
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public bool msaa
		{
			[CompilerGenerated]
			 get { } //Length: 5
			[CompilerGenerated]
			 set { } //Length: 4
		}

		public RenderingFeatures() { }

		[CompilerGenerated]
		public bool get_cameraStacking() { }

		[CompilerGenerated]
		public bool get_msaa() { }

		[CompilerGenerated]
		public void set_cameraStacking(bool value) { }

		[CompilerGenerated]
		public void set_msaa(bool value) { }

	}

	private static class RenderPassBlock
	{
		public static readonly int BeforeRendering; //Field offset: 0x0
		public static readonly int MainRenderingOpaque; //Field offset: 0x4
		public static readonly int MainRenderingTransparent; //Field offset: 0x8
		public static readonly int AfterRendering; //Field offset: 0xC

		private static RenderPassBlock() { }

	}

	public struct RenderPassDescriptor
	{
		internal int w; //Field offset: 0x0
		internal int h; //Field offset: 0x4
		internal int samples; //Field offset: 0x8
		internal int depthID; //Field offset: 0xC

		internal RenderPassDescriptor(int width, int height, int sampleCount, int rtID) { }

	}

	private class VFXProcessCameraPassData
	{
		internal UniversalRenderingData renderingData; //Field offset: 0x10
		internal Camera camera; //Field offset: 0x18
		internal VFXCameraXRSettings cameraXRSettings; //Field offset: 0x20
		internal XRPass xrPass; //Field offset: 0x30

		public VFXProcessCameraPassData() { }

	}

	internal const int kRenderPassMapSize = 10; //Field offset: 0x0
	internal const int kRenderPassMaxCount = 20; //Field offset: 0x0
	private const int k_RenderPassBlockCount = 4; //Field offset: 0x0
	internal static ScriptableRenderer current; //Field offset: 0x0
	private static bool m_UseOptimizedStoreActions; //Field offset: 0x8
	protected static readonly RTHandle k_CameraTarget; //Field offset: 0x10
	private static RenderTargetIdentifier[] m_ActiveColorAttachmentIDs; //Field offset: 0x18
	private static RTHandle[] m_ActiveColorAttachments; //Field offset: 0x20
	private static RTHandle m_ActiveDepthAttachment; //Field offset: 0x28
	private static RenderBufferStoreAction[] m_ActiveColorStoreActions; //Field offset: 0x30
	private static RenderBufferStoreAction m_ActiveDepthStoreAction; //Field offset: 0x38
	private static RenderTargetIdentifier[][] m_TrimmedColorAttachmentCopyIDs; //Field offset: 0x40
	private static RTHandle[][] m_TrimmedColorAttachmentCopies; //Field offset: 0x48
	private static Plane[] s_Planes; //Field offset: 0x50
	private static Vector4[] s_VectorPlanes; //Field offset: 0x58
	private int m_LastBeginSubpassPassIndex; //Field offset: 0x10
	private Dictionary<Hash128, Int32[]> m_MergeableRenderPassesMap; //Field offset: 0x18
	private Int32[][] m_MergeableRenderPassesMapArrays; //Field offset: 0x20
	private Hash128[] m_PassIndexToPassHash; //Field offset: 0x28
	private Dictionary<Hash128, Int32> m_RenderPassesAttachmentCount; //Field offset: 0x30
	private int m_firstPassIndexOfLastMergeableGroup; //Field offset: 0x38
	private AttachmentDescriptor[] m_ActiveColorAttachmentDescriptors; //Field offset: 0x40
	private AttachmentDescriptor m_ActiveDepthAttachmentDescriptor; //Field offset: 0x48
	private Boolean[] m_IsActiveColorAttachmentTransient; //Field offset: 0xC0
	internal RenderBufferStoreAction[] m_FinalColorStoreAction; //Field offset: 0xC8
	internal RenderBufferStoreAction m_FinalDepthStoreAction; //Field offset: 0xD0
	[CompilerGenerated]
	private ProfilingSampler <profilingExecute>k__BackingField; //Field offset: 0xD8
	internal bool hasReleasedRTs; //Field offset: 0xE0
	[CompilerGenerated]
	private readonly DebugHandler <DebugHandler>k__BackingField; //Field offset: 0xE8
	[CompilerGenerated]
	private RenderingFeatures <supportedRenderingFeatures>k__BackingField; //Field offset: 0xF0
	[CompilerGenerated]
	private GraphicsDeviceType[] <unsupportedGraphicsDeviceTypes>k__BackingField; //Field offset: 0xF8
	private StoreActionsOptimization m_StoreActionsOptimizationSetting; //Field offset: 0x100
	private List<ScriptableRenderPass> m_ActiveRenderPassQueue; //Field offset: 0x108
	private List<ScriptableRendererFeature> m_RendererFeatures; //Field offset: 0x110
	private RTHandle m_CameraColorTarget; //Field offset: 0x118
	private RTHandle m_CameraDepthTarget; //Field offset: 0x120
	private RTHandle m_CameraResolveTarget; //Field offset: 0x128
	private bool m_FirstTimeCameraColorTargetIsBound; //Field offset: 0x130
	private bool m_FirstTimeCameraDepthTargetIsBound; //Field offset: 0x131
	private bool m_IsPipelineExecuting; //Field offset: 0x132
	internal bool disableNativeRenderPassInFeatures; //Field offset: 0x133
	internal bool useRenderPassEnabled; //Field offset: 0x134
	private ContextContainer m_frameData; //Field offset: 0x138
	[CompilerGenerated]
	private bool <useDepthPriming>k__BackingField; //Field offset: 0x140
	[CompilerGenerated]
	private bool <stripShadowsOffVariants>k__BackingField; //Field offset: 0x141
	[CompilerGenerated]
	private bool <stripAdditionalLightOffVariants>k__BackingField; //Field offset: 0x142

	protected List<ScriptableRenderPass> activeRenderPassQueue
	{
		 get { } //Length: 8
	}

	[Obsolete("Use cameraColorTargetHandle", True)]
	public RenderTargetIdentifier cameraColorTarget
	{
		 get { } //Length: 78
	}

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public RTHandle cameraColorTargetHandle
	{
		 get { } //Length: 114
	}

	[EditorBrowsable(EditorBrowsableState::Never (1))]
	[Obsolete("cameraDepth has been renamed to cameraDepthTarget. (UnityUpgradable) -> cameraDepthTarget", True)]
	public RenderTargetIdentifier cameraDepth
	{
		 get { } //Length: 54
	}

	[Obsolete("Use cameraDepthTargetHandle", True)]
	public RenderTargetIdentifier cameraDepthTarget
	{
		 get { } //Length: 78
	}

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public RTHandle cameraDepthTargetHandle
	{
		 get { } //Length: 114
	}

	internal DebugHandler DebugHandler
	{
		[CompilerGenerated]
		internal get { } //Length: 8
	}

	internal ContextContainer frameData
	{
		internal get { } //Length: 8
	}

	protected ProfilingSampler profilingExecute
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	protected List<ScriptableRendererFeature> rendererFeatures
	{
		 get { } //Length: 8
	}

	internal bool stripAdditionalLightOffVariants
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	internal bool stripShadowsOffVariants
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	public RenderingFeatures supportedRenderingFeatures
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	public override bool supportsGPUOcclusion
	{
		 get { } //Length: 3
	}

	internal override bool supportsNativeRenderPassRendergraphCompiler
	{
		internal get { } //Length: 3
	}

	public GraphicsDeviceType[] unsupportedGraphicsDeviceTypes
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 19
	}

	internal bool useDepthPriming
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	private static ScriptableRenderer() { }

	public ScriptableRenderer(ScriptableRendererData data) { }

	internal void AddRenderPasses(ref RenderingData renderingData) { }

	 int AdjustAndGetScreenMSAASamples(RenderGraph renderGraph, bool useIntermediateColorTarget) { }

	internal static bool AreAttachmentIndicesCompatible(ScriptableRenderPass lastSubPass, ScriptableRenderPass currentSubPass) { }

	internal void BeginRenderGraphXRRendering(RenderGraph renderGraph) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	private void BeginXRRendering(CommandBuffer cmd, ScriptableRenderContext context, ref CameraData cameraData) { }

	private static void CalculateBillboardProperties(in Matrix4x4 worldToCameraMatrix, out Vector3 billboardTangent, out Vector3 billboardNormal, out float cameraXZAngle) { }

	internal void CalculateSplitEventRange(RenderPassEvent startInjectionPoint, RenderPassEvent targetEvent, out RenderPassEvent startEvent, out RenderPassEvent splitEvent, out RenderPassEvent endEvent) { }

	internal void Clear(CameraRenderType cameraType) { }

	private static void ClearRenderingState(IBaseCommandBuffer cmd) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal void ConfigureCameraColorTarget(RTHandle colorTarget) { }

	[Obsolete("Use RTHandles for colorTarget and depthTarget", True)]
	public void ConfigureCameraTarget(RenderTargetIdentifier colorTarget, RenderTargetIdentifier depthTarget) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal void ConfigureCameraTarget(RTHandle colorTarget, RTHandle depthTarget, RTHandle resolveTarget) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void ConfigureCameraTarget(RTHandle colorTarget, RTHandle depthTarget) { }

	internal static Hash128 CreateRenderPassHash(RenderPassDescriptor desc, uint hashIndex) { }

	internal static Hash128 CreateRenderPassHash(int width, int height, int depthID, int sample, uint hashIndex) { }

	public override void Dispose() { }

	protected override void Dispose(bool disposing) { }

	[Conditional("UNITY_EDITOR")]
	private void DrawGizmos(ScriptableRenderContext context, Camera camera, GizmoSubset gizmoSubset, ref RenderingData renderingData) { }

	internal void DrawRenderGraphGizmos(RenderGraph renderGraph, ContextContainer frameData, TextureHandle color, TextureHandle depth, GizmoSubset gizmoSubset) { }

	internal void DrawRenderGraphWireOverlay(RenderGraph renderGraph, ContextContainer frameData, TextureHandle color) { }

	[Conditional("UNITY_EDITOR")]
	private void DrawWireOverlay(ScriptableRenderContext context, Camera camera) { }

	internal override void EnableSwapBufferMSAA(bool enable) { }

	internal void EndRenderGraphXRRendering(RenderGraph renderGraph) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	private void EndXRRendering(CommandBuffer cmd, ScriptableRenderContext context, ref CameraData cameraData) { }

	public void EnqueuePass(ScriptableRenderPass pass) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	private void ExecuteBlock(int blockIndex, in RenderBlocks renderBlocks, ScriptableRenderContext context, ref RenderingData renderingData, bool submit = false) { }

	internal void ExecuteNativeRenderPass(ScriptableRenderContext context, ScriptableRenderPass renderPass, UniversalCameraData cameraData, ref RenderingData renderingData) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	private void ExecuteRenderPass(ScriptableRenderContext context, ScriptableRenderPass renderPass, UniversalCameraData cameraData, ref RenderingData renderingData) { }

	internal static int FindAttachmentDescriptorIndexInList(int attachmentIdx, AttachmentDescriptor attachmentDescriptor, AttachmentDescriptor[] attachmentDescriptors) { }

	internal static int FindAttachmentDescriptorIndexInList(RenderTargetIdentifier target, AttachmentDescriptor[] attachmentDescriptors) { }

	internal void FinishRenderGraphRendering(CommandBuffer cmd) { }

	public override void FinishRendering(CommandBuffer cmd) { }

	protected List<ScriptableRenderPass> get_activeRenderPassQueue() { }

	public RenderTargetIdentifier get_cameraColorTarget() { }

	public RTHandle get_cameraColorTargetHandle() { }

	public RenderTargetIdentifier get_cameraDepth() { }

	public RenderTargetIdentifier get_cameraDepthTarget() { }

	public RTHandle get_cameraDepthTargetHandle() { }

	[CompilerGenerated]
	internal DebugHandler get_DebugHandler() { }

	internal ContextContainer get_frameData() { }

	[CompilerGenerated]
	protected ProfilingSampler get_profilingExecute() { }

	protected List<ScriptableRendererFeature> get_rendererFeatures() { }

	[CompilerGenerated]
	internal bool get_stripAdditionalLightOffVariants() { }

	[CompilerGenerated]
	internal bool get_stripShadowsOffVariants() { }

	[CompilerGenerated]
	public RenderingFeatures get_supportedRenderingFeatures() { }

	public override bool get_supportsGPUOcclusion() { }

	internal override bool get_supportsNativeRenderPassRendergraphCompiler() { }

	[CompilerGenerated]
	public GraphicsDeviceType[] get_unsupportedGraphicsDeviceTypes() { }

	[CompilerGenerated]
	internal bool get_useDepthPriming() { }

	protected static ClearFlag GetCameraClearFlag(UniversalCameraData cameraData) { }

	protected static ClearFlag GetCameraClearFlag(ref CameraData cameraData) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal override RTHandle GetCameraColorBackBuffer(CommandBuffer cmd) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal override RTHandle GetCameraColorFrontBuffer(CommandBuffer cmd) { }

	internal static RTHandle GetFirstAllocatedRTHandle(ScriptableRenderPass pass) { }

	internal static void GetRenderTextureDescriptor(UniversalCameraData cameraData, ScriptableRenderPass renderPass, out RenderTextureDescriptor targetRT) { }

	internal static uint GetSubPassAttachmentIndicesCount(ScriptableRenderPass pass) { }

	internal static uint GetValidColorAttachmentCount(AttachmentDescriptor[] colorAttachments) { }

	internal static int GetValidInputAttachmentCount(ScriptableRenderPass renderPass) { }

	internal static int GetValidPassIndexCount(Int32[] array) { }

	private RenderPassDescriptor InitializeRenderPassDescriptor(UniversalCameraData cameraData, ScriptableRenderPass renderPass) { }

	private void InitRenderGraphFrame(RenderGraph renderGraph) { }

	private void InternalFinishRenderingCommon(CommandBuffer cmd, bool resolveFinalTarget) { }

	private void InternalFinishRenderingExecute(ScriptableRenderContext context, CommandBuffer cmd, bool resolveFinalTarget) { }

	private void InternalStartRendering(ScriptableRenderContext context, ref RenderingData renderingData) { }

	internal bool InterruptFramebufferFetch(FramebufferFetchEvent fetchEvent, RenderPassEvent startInjectionPoint, RenderPassEvent endInjectionPoint) { }

	private bool IsDepthOnlyRenderTexture(RenderTexture t) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	private bool IsRenderPassEnabled(ScriptableRenderPass renderPass) { }

	internal bool IsSceneFilteringEnabled(Camera camera) { }

	public override void OnBeginRenderGraphFrame() { }

	public override void OnEndRenderGraphFrame() { }

	internal override void OnFinishRenderGraphRendering(CommandBuffer cmd) { }

	internal void OnPreCullRenderPasses(in CameraData cameraData) { }

	internal override void OnRecordRenderGraph(RenderGraph renderGraph, ScriptableRenderContext context) { }

	internal static bool PassHasInputAttachments(ScriptableRenderPass renderPass) { }

	internal void ProcessVFXCameraCommand(RenderGraph renderGraph) { }

	internal void RecordCustomRenderGraphPasses(RenderGraph renderGraph, RenderPassEvent injectionPoint) { }

	internal void RecordCustomRenderGraphPasses(RenderGraph renderGraph, RenderPassEvent startInjectionPoint, RenderPassEvent endInjectionPoint) { }

	internal void RecordCustomRenderGraphPassesInEventRange(RenderGraph renderGraph, RenderPassEvent eventStart, RenderPassEvent eventEnd) { }

	internal void RecordRenderGraph(RenderGraph renderGraph, ScriptableRenderContext context) { }

	internal override void ReleaseRenderTargets() { }

	internal void ResetNativeRenderPassFrameData() { }

	[CompilerGenerated]
	protected void set_profilingExecute(ProfilingSampler value) { }

	[CompilerGenerated]
	internal void set_stripAdditionalLightOffVariants(bool value) { }

	[CompilerGenerated]
	internal void set_stripShadowsOffVariants(bool value) { }

	[CompilerGenerated]
	public void set_supportedRenderingFeatures(RenderingFeatures value) { }

	[CompilerGenerated]
	public void set_unsupportedGraphicsDeviceTypes(GraphicsDeviceType[] value) { }

	[CompilerGenerated]
	internal void set_useDepthPriming(bool value) { }

	internal static void SetCameraMatrices(RasterCommandBuffer cmd, UniversalCameraData cameraData, bool setInverseMatrices, bool isTargetFlipped) { }

	public static void SetCameraMatrices(CommandBuffer cmd, UniversalCameraData cameraData, bool setInverseMatrices) { }

	public static void SetCameraMatrices(CommandBuffer cmd, ref CameraData cameraData, bool setInverseMatrices) { }

	private void SetEditorTarget(RenderGraph renderGraph) { }

	internal void SetNativeRenderPassAttachmentList(ScriptableRenderPass renderPass, UniversalCameraData cameraData, RTHandle passColorAttachment, RTHandle passDepthAttachment, ClearFlag finalClearFlag, Color finalClearColor) { }

	internal void SetNativeRenderPassMRTAttachmentList(ScriptableRenderPass renderPass, UniversalCameraData cameraData, bool needCustomCameraColorClear, ClearFlag cameraClearFlag) { }

	private void SetPerCameraBillboardProperties(RasterCommandBuffer cmd, UniversalCameraData cameraData) { }

	private void SetPerCameraClippingPlaneProperties(RasterCommandBuffer cmd, UniversalCameraData cameraData) { }

	private void SetPerCameraClippingPlaneProperties(RasterCommandBuffer cmd, in UniversalCameraData cameraData, bool isTargetFlipped) { }

	internal void SetPerCameraProperties(ScriptableRenderContext context, UniversalCameraData cameraData, Camera camera, CommandBuffer cmd) { }

	private void SetPerCameraShaderVariables(RasterCommandBuffer cmd, UniversalCameraData cameraData, Vector2Int cameraTargetSizeCopy, bool isTargetFlipped) { }

	private void SetPerCameraShaderVariables(RasterCommandBuffer cmd, UniversalCameraData cameraData) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	private void SetRenderPassAttachments(CommandBuffer cmd, ScriptableRenderPass renderPass, UniversalCameraData cameraData) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal static void SetRenderTarget(CommandBuffer cmd, RTHandle colorAttachment, RTHandle depthAttachment, ClearFlag clearFlag, Color clearColor) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal static void SetRenderTarget(CommandBuffer cmd, RTHandle colorAttachment, RTHandle depthAttachment, ClearFlag clearFlag, Color clearColor, RenderBufferStoreAction colorStoreAction, RenderBufferStoreAction depthStoreAction) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	private static void SetRenderTarget(CommandBuffer cmd, RTHandle colorAttachment, RenderBufferLoadAction colorLoadAction, RenderBufferStoreAction colorStoreAction, RTHandle depthAttachment, RenderBufferLoadAction depthLoadAction, RenderBufferStoreAction depthStoreAction, ClearFlag clearFlags, Color clearColor) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	private static void SetRenderTarget(CommandBuffer cmd, RTHandle[] colorAttachments, RenderTargetIdentifier[] colorAttachmentIDs, RTHandle depthAttachment, ClearFlag clearFlag, Color clearColor) { }

	private static void SetShaderTimeValues(IBaseCommandBuffer cmd, float time, float deltaTime, float smoothDeltaTime) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public abstract void Setup(ScriptableRenderContext context, ref RenderingData renderingData) { }

	public override void SetupCullingParameters(ref ScriptableCullingParameters cullingParameters, ref CameraData cameraData) { }

	internal void SetupInputAttachmentIndices(ScriptableRenderPass pass) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public override void SetupLights(ScriptableRenderContext context, ref RenderingData renderingData) { }

	internal void SetupNativeRenderPassFrameData(UniversalCameraData cameraData, bool isRenderPassEnabled) { }

	internal void SetupRenderGraphCameraProperties(RenderGraph renderGraph, bool isTargetBackbuffer) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	protected void SetupRenderPasses(in RenderingData renderingData) { }

	internal void SetupTransientInputAttachments(int attachmentCount) { }

	internal static void SortStable(List<ScriptableRenderPass> list) { }

	public override int SupportedCameraStackingTypes() { }

	public bool SupportsCameraStackingType(CameraRenderType cameraRenderType) { }

	protected private override bool SupportsMotionVectors() { }

	internal override void SwapColorBuffer(CommandBuffer cmd) { }

	internal void UpdateFinalStoreActions(Int32[] currentMergeablePasses, UniversalCameraData cameraData, bool isLastMergeableGroup) { }

}

