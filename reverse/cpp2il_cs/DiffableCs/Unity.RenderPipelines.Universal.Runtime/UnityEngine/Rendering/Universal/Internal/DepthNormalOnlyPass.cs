namespace UnityEngine.Rendering.Universal.Internal;

public class DepthNormalOnlyPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__42_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__42_0(PassData data, RasterGraphContext context) { }

	}

	private class PassData
	{
		internal TextureHandle cameraDepthTexture; //Field offset: 0x10
		internal TextureHandle cameraNormalsTexture; //Field offset: 0x20
		internal bool enableRenderingLayers; //Field offset: 0x30
		internal MaskSize maskSize; //Field offset: 0x34
		internal RendererListHandle rendererList; //Field offset: 0x38

		public PassData() { }

	}

	private static readonly List<ShaderTagId> k_DepthNormals; //Field offset: 0x0
	private static readonly RTHandle[] k_ColorAttachment1; //Field offset: 0x8
	private static readonly RTHandle[] k_ColorAttachment2; //Field offset: 0x10
	private static readonly int s_CameraDepthTextureID; //Field offset: 0x18
	private static readonly int s_CameraNormalsTextureID; //Field offset: 0x1C
	private static readonly int s_CameraRenderingLayersTextureID; //Field offset: 0x20
	[CompilerGenerated]
	private List<ShaderTagId> <shaderTagIds>k__BackingField; //Field offset: 0xB8
	[CompilerGenerated]
	private RTHandle <depthHandle>k__BackingField; //Field offset: 0xC0
	[CompilerGenerated]
	private RTHandle <normalHandle>k__BackingField; //Field offset: 0xC8
	[CompilerGenerated]
	private RTHandle <renderingLayersHandle>k__BackingField; //Field offset: 0xD0
	[CompilerGenerated]
	private bool <enableRenderingLayers>k__BackingField; //Field offset: 0xD8
	[CompilerGenerated]
	private MaskSize <renderingLayersMaskSize>k__BackingField; //Field offset: 0xDC
	private FilteringSettings m_FilteringSettings; //Field offset: 0xE0
	private PassData m_PassData; //Field offset: 0x100

	private RTHandle depthHandle
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	internal bool enableRenderingLayers
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	private RTHandle normalHandle
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	private RTHandle renderingLayersHandle
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	internal MaskSize renderingLayersMaskSize
	{
		[CompilerGenerated]
		internal get { } //Length: 7
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	internal List<ShaderTagId> shaderTagIds
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 19
	}

	private static DepthNormalOnlyPass() { }

	public DepthNormalOnlyPass(RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList) { }

	[CompilerGenerated]
	private RTHandle get_depthHandle() { }

	[CompilerGenerated]
	internal bool get_enableRenderingLayers() { }

	[CompilerGenerated]
	private RTHandle get_normalHandle() { }

	[CompilerGenerated]
	private RTHandle get_renderingLayersHandle() { }

	[CompilerGenerated]
	internal MaskSize get_renderingLayersMaskSize() { }

	[CompilerGenerated]
	internal List<ShaderTagId> get_shaderTagIds() { }

	public static GraphicsFormat GetGraphicsFormat() { }

	private RendererListParams InitRendererListParams(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData) { }

	public virtual void OnCameraCleanup(CommandBuffer cmd) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) { }

	internal void Render(RenderGraph renderGraph, ContextContainer frameData, TextureHandle cameraNormalsTexture, TextureHandle cameraDepthTexture, TextureHandle renderingLayersTexture, uint batchLayerMask, bool setGlobalDepth, bool setGlobalTextures) { }

	[CompilerGenerated]
	private void set_depthHandle(RTHandle value) { }

	[CompilerGenerated]
	internal void set_enableRenderingLayers(bool value) { }

	[CompilerGenerated]
	private void set_normalHandle(RTHandle value) { }

	[CompilerGenerated]
	private void set_renderingLayersHandle(RTHandle value) { }

	[CompilerGenerated]
	internal void set_renderingLayersMaskSize(MaskSize value) { }

	[CompilerGenerated]
	internal void set_shaderTagIds(List<ShaderTagId> value) { }

	public void Setup(RTHandle depthHandle, RTHandle normalHandle) { }

	public void Setup(RTHandle depthHandle, RTHandle normalHandle, RTHandle decalLayerHandle) { }

}

