namespace UnityEngine.Rendering.Universal.Internal;

public class DepthOnlyPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__20_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__20_0(PassData data, RasterGraphContext context) { }

	}

	private class PassData
	{
		internal RendererListHandle rendererList; //Field offset: 0x10

		public PassData() { }

	}

	private static readonly ShaderTagId k_ShaderTagId; //Field offset: 0x0
	private static readonly int s_CameraDepthTextureID; //Field offset: 0x4
	[CompilerGenerated]
	private RTHandle <destination>k__BackingField; //Field offset: 0xB8
	private GraphicsFormat depthStencilFormat; //Field offset: 0xC0
	[CompilerGenerated]
	private ShaderTagId <shaderTagId>k__BackingField; //Field offset: 0xC4
	private PassData m_PassData; //Field offset: 0xC8
	private FilteringSettings m_FilteringSettings; //Field offset: 0xD0

	private RTHandle destination
	{
		[CompilerGenerated]
		private get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	internal ShaderTagId shaderTagId
	{
		[CompilerGenerated]
		internal get { } //Length: 7
		[CompilerGenerated]
		internal set { } //Length: 7
	}

	private static DepthOnlyPass() { }

	public DepthOnlyPass(RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, RendererList rendererList) { }

	[CompilerGenerated]
	private RTHandle get_destination() { }

	[CompilerGenerated]
	internal ShaderTagId get_shaderTagId() { }

	private RendererListParams InitRendererListParams(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) { }

	internal void Render(RenderGraph renderGraph, ContextContainer frameData, ref TextureHandle cameraDepthTexture, uint batchLayerMask, bool setGlobalDepth) { }

	[CompilerGenerated]
	private void set_destination(RTHandle value) { }

	[CompilerGenerated]
	internal void set_shaderTagId(ShaderTagId value) { }

	public void Setup(RenderTextureDescriptor baseDescriptor, RTHandle depthAttachmentHandle) { }

}

