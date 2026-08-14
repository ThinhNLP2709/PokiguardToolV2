namespace UnityEngine.Rendering.Universal;

public abstract class ScriptableRenderPass : IRenderGraphRecorder
{
	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public static RTHandle k_CameraTarget; //Field offset: 0x0
	[CompilerGenerated]
	private RenderPassEvent <renderPassEvent>k__BackingField; //Field offset: 0x10
	private RenderBufferStoreAction[] m_ColorStoreActions; //Field offset: 0x18
	private RenderBufferStoreAction m_DepthStoreAction; //Field offset: 0x20
	[CompilerGenerated]
	private bool <requiresIntermediateTexture>k__BackingField; //Field offset: 0x24
	private Boolean[] m_OverriddenColorStoreActions; //Field offset: 0x28
	private bool m_OverriddenDepthStoreAction; //Field offset: 0x30
	private ProfilingSampler m_ProfingSampler; //Field offset: 0x38
	private string m_PassName; //Field offset: 0x40
	private RenderGraphSettings m_RenderGraphSettings; //Field offset: 0x48
	[CompilerGenerated]
	private bool <overrideCameraTarget>k__BackingField; //Field offset: 0x50
	[CompilerGenerated]
	private bool <isBlitRenderPass>k__BackingField; //Field offset: 0x51
	[CompilerGenerated]
	private bool <useNativeRenderPass>k__BackingField; //Field offset: 0x52
	[CompilerGenerated]
	private bool <breakGBufferAndDeferredRenderPass>k__BackingField; //Field offset: 0x53
	[CompilerGenerated]
	private int <renderPassQueueIndex>k__BackingField; //Field offset: 0x54
	internal NativeArray<Int32> m_ColorAttachmentIndices; //Field offset: 0x58
	internal NativeArray<Int32> m_InputAttachmentIndices; //Field offset: 0x68
	[CompilerGenerated]
	private GraphicsFormat[] <renderTargetFormat>k__BackingField; //Field offset: 0x78
	private RTHandle[] m_ColorAttachments; //Field offset: 0x80
	internal RTHandle[] m_InputAttachments; //Field offset: 0x88
	internal Boolean[] m_InputAttachmentIsTransient; //Field offset: 0x90
	private RTHandle m_DepthAttachment; //Field offset: 0x98
	private ScriptableRenderPassInput m_Input; //Field offset: 0xA0
	private ClearFlag m_ClearFlag; //Field offset: 0xA4
	private Color m_ClearColor; //Field offset: 0xA8

	internal bool breakGBufferAndDeferredRenderPass
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	public Color clearColor
	{
		 get { } //Length: 14
	}

	public ClearFlag clearFlag
	{
		 get { } //Length: 7
	}

	[Obsolete("Use colorAttachmentHandle", True)]
	public RenderTargetIdentifier[] colorAttachment
	{
		 get { } //Length: 78
	}

	public RTHandle colorAttachmentHandle
	{
		 get { } //Length: 42
	}

	public RTHandle[] colorAttachmentHandles
	{
		 get { } //Length: 8
	}

	[Obsolete("Use colorAttachmentHandles", True)]
	public RenderTargetIdentifier[] colorAttachments
	{
		 get { } //Length: 78
	}

	public RenderBufferStoreAction[] colorStoreActions
	{
		 get { } //Length: 5
	}

	[Obsolete("Use depthAttachmentHandle", True)]
	public RenderTargetIdentifier depthAttachment
	{
		 get { } //Length: 78
	}

	public RTHandle depthAttachmentHandle
	{
		 get { } //Length: 8
	}

	public RenderBufferStoreAction depthStoreAction
	{
		 get { } //Length: 4
	}

	public ScriptableRenderPassInput input
	{
		 get { } //Length: 7
	}

	internal bool isBlitRenderPass
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal Boolean[] overriddenColorStoreActions
	{
		internal get { } //Length: 5
	}

	internal bool overriddenDepthStoreAction
	{
		internal get { } //Length: 5
	}

	internal bool overrideCameraTarget
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	protected private string passName
	{
		private get { } //Length: 5
	}

	protected private ProfilingSampler profilingSampler
	{
		private get { } //Length: 148
		private set { } //Length: 108
	}

	public RenderPassEvent renderPassEvent
	{
		[CompilerGenerated]
		 get { } //Length: 4
		[CompilerGenerated]
		 set { } //Length: 4
	}

	internal int renderPassQueueIndex
	{
		[CompilerGenerated]
		internal get { } //Length: 4
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	internal GraphicsFormat[] renderTargetFormat
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 13
	}

	public bool requiresIntermediateTexture
	{
		[CompilerGenerated]
		 get { } //Length: 5
		[CompilerGenerated]
		 set { } //Length: 4
	}

	internal bool useNativeRenderPass
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	private static ScriptableRenderPass() { }

	public ScriptableRenderPass() { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void Blit(CommandBuffer cmd, ref RenderingData data, RTHandle source, Material material, int passIndex = 0) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void Blit(CommandBuffer cmd, ref RenderingData data, Material material, int passIndex = 0) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void Blit(CommandBuffer cmd, RTHandle source, RTHandle destination, Material material = null, int passIndex = 0) { }

	[Obsolete("Use RTHandles for source and destination", True)]
	public void Blit(CommandBuffer cmd, RenderTargetIdentifier source, RenderTargetIdentifier destination, Material material = null, int passIndex = 0) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void ConfigureClear(ClearFlag clearFlag, Color clearColor) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void ConfigureColorStoreAction(RenderBufferStoreAction storeAction, uint attachmentIndex = 0) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void ConfigureColorStoreActions(RenderBufferStoreAction[] storeActions) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void ConfigureDepthStoreAction(RenderBufferStoreAction storeAction) { }

	public void ConfigureInput(ScriptableRenderPassInput passInput) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal void ConfigureInputAttachments(RTHandle input, bool isTransient = false) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal void ConfigureInputAttachments(RTHandle[] inputs, Boolean[] isTransient) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal void ConfigureInputAttachments(RTHandle[] inputs) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void ConfigureTarget(RTHandle[] colorAttachments) { }

	[Obsolete("Use RTHandles for colorAttachments", True)]
	public void ConfigureTarget(RenderTargetIdentifier[] colorAttachments) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void ConfigureTarget(RTHandle colorAttachment) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal void ConfigureTarget(RTHandle[] colorAttachments, RTHandle depthAttachment, GraphicsFormat[] formats) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void ConfigureTarget(RTHandle[] colorAttachments, RTHandle depthAttachment) { }

	[Obsolete("Use RTHandles for colorAttachments and depthAttachment", True)]
	public void ConfigureTarget(RenderTargetIdentifier[] colorAttachments, RenderTargetIdentifier depthAttachment) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void ConfigureTarget(RTHandle colorAttachment, RTHandle depthAttachment) { }

	[Obsolete("Use RTHandles for colorAttachment and depthAttachment", True)]
	public void ConfigureTarget(RenderTargetIdentifier colorAttachment, RenderTargetIdentifier depthAttachment) { }

	[Obsolete("Use RTHandle for colorAttachment", True)]
	public void ConfigureTarget(RenderTargetIdentifier colorAttachment) { }

	public DrawingSettings CreateDrawingSettings(ShaderTagId shaderTagId, ref RenderingData renderingData, SortingCriteria sortingCriteria) { }

	public DrawingSettings CreateDrawingSettings(ShaderTagId shaderTagId, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, SortingCriteria sortingCriteria) { }

	public DrawingSettings CreateDrawingSettings(List<ShaderTagId> shaderTagIdList, ref RenderingData renderingData, SortingCriteria sortingCriteria) { }

	public DrawingSettings CreateDrawingSettings(List<ShaderTagId> shaderTagIdList, UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, SortingCriteria sortingCriteria) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	[EditorBrowsable(EditorBrowsableState::Never (1))]
	public override void FrameCleanup(CommandBuffer cmd) { }

	[CompilerGenerated]
	internal bool get_breakGBufferAndDeferredRenderPass() { }

	public Color get_clearColor() { }

	public ClearFlag get_clearFlag() { }

	public RenderTargetIdentifier[] get_colorAttachment() { }

	public RTHandle get_colorAttachmentHandle() { }

	public RTHandle[] get_colorAttachmentHandles() { }

	public RenderTargetIdentifier[] get_colorAttachments() { }

	public RenderBufferStoreAction[] get_colorStoreActions() { }

	public RenderTargetIdentifier get_depthAttachment() { }

	public RTHandle get_depthAttachmentHandle() { }

	public RenderBufferStoreAction get_depthStoreAction() { }

	public ScriptableRenderPassInput get_input() { }

	[CompilerGenerated]
	internal bool get_isBlitRenderPass() { }

	internal Boolean[] get_overriddenColorStoreActions() { }

	internal bool get_overriddenDepthStoreAction() { }

	[CompilerGenerated]
	internal bool get_overrideCameraTarget() { }

	protected private string get_passName() { }

	protected private ProfilingSampler get_profilingSampler() { }

	[CompilerGenerated]
	public RenderPassEvent get_renderPassEvent() { }

	[CompilerGenerated]
	internal int get_renderPassQueueIndex() { }

	[CompilerGenerated]
	internal GraphicsFormat[] get_renderTargetFormat() { }

	[CompilerGenerated]
	public bool get_requiresIntermediateTexture() { }

	[CompilerGenerated]
	internal bool get_useNativeRenderPass() { }

	internal static DebugHandler GetActiveDebugHandler(UniversalCameraData cameraData) { }

	internal static int GetRenderPassEventRange(RenderPassEvent renderPassEvent) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal bool IsInputAttachmentTransient(int idx) { }

	public override void OnCameraCleanup(CommandBuffer cmd) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public override void OnFinishCameraStackRendering(CommandBuffer cmd) { }

	public static bool op_GreaterThan(ScriptableRenderPass lhs, ScriptableRenderPass rhs) { }

	public static bool op_LessThan(ScriptableRenderPass lhs, ScriptableRenderPass rhs) { }

	public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public void ResetTarget() { }

	[CompilerGenerated]
	internal void set_breakGBufferAndDeferredRenderPass(bool value) { }

	[CompilerGenerated]
	internal void set_isBlitRenderPass(bool value) { }

	[CompilerGenerated]
	internal void set_overrideCameraTarget(bool value) { }

	protected private void set_profilingSampler(ProfilingSampler value) { }

	[CompilerGenerated]
	public void set_renderPassEvent(RenderPassEvent value) { }

	[CompilerGenerated]
	internal void set_renderPassQueueIndex(int value) { }

	[CompilerGenerated]
	internal void set_renderTargetFormat(GraphicsFormat[] value) { }

	[CompilerGenerated]
	public void set_requiresIntermediateTexture(bool value) { }

	[CompilerGenerated]
	internal void set_useNativeRenderPass(bool value) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	internal void SetInputAttachmentTransient(int idx, bool isTransient) { }

}

