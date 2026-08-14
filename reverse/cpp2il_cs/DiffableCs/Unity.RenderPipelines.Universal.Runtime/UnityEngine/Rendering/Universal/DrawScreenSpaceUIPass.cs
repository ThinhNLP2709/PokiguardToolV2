namespace UnityEngine.Rendering.Universal;

internal class DrawScreenSpaceUIPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__17_0; //Field offset: 0x8
		public static BaseRenderFunc<UnsafePassData, UnsafeGraphContext> <>9__17_1; //Field offset: 0x10
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__18_0; //Field offset: 0x18
		public static BaseRenderFunc<UnsafePassData, UnsafeGraphContext> <>9__18_1; //Field offset: 0x20

		private static <>c() { }

		public <>c() { }

		internal void <RenderOffscreen>b__17_0(PassData data, RasterGraphContext context) { }

		internal void <RenderOffscreen>b__17_1(UnsafePassData data, UnsafeGraphContext context) { }

		internal void <RenderOverlay>b__18_0(PassData data, RasterGraphContext context) { }

		internal void <RenderOverlay>b__18_1(UnsafePassData data, UnsafeGraphContext context) { }

	}

	private class PassData
	{
		internal RendererListHandle rendererList; //Field offset: 0x10

		public PassData() { }

	}

	private class UnsafePassData
	{
		internal RendererListHandle rendererList; //Field offset: 0x10
		internal TextureHandle colorTarget; //Field offset: 0x1C

		public UnsafePassData() { }

	}

	private static readonly int s_CameraDepthTextureID; //Field offset: 0x0
	private static readonly int s_CameraOpaqueTextureID; //Field offset: 0x4
	private PassData m_PassData; //Field offset: 0xB8
	private RTHandle m_ColorTarget; //Field offset: 0xC0
	private RTHandle m_DepthTarget; //Field offset: 0xC8
	private bool m_RenderOffscreen; //Field offset: 0xD0

	private static DrawScreenSpaceUIPass() { }

	public DrawScreenSpaceUIPass(RenderPassEvent evt, bool renderOffscreen) { }

	public static void ConfigureColorDescriptor(ref RenderTextureDescriptor descriptor, int cameraWidth, int cameraHeight) { }

	public static void ConfigureDepthDescriptor(ref RenderTextureDescriptor descriptor, GraphicsFormat depthStencilFormat, int cameraWidth, int cameraHeight) { }

	public void Dispose() { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer commandBuffer, PassData passData, RendererList rendererList) { }

	private static void ExecutePass(UnsafeCommandBuffer commandBuffer, UnsafePassData passData, RendererList rendererList) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) { }

	internal void RenderOffscreen(RenderGraph renderGraph, ContextContainer frameData, GraphicsFormat depthStencilFormat, out TextureHandle output) { }

	internal void RenderOverlay(RenderGraph renderGraph, ContextContainer frameData, in TextureHandle colorBuffer, in TextureHandle depthBuffer) { }

	public void Setup(UniversalCameraData cameraData, GraphicsFormat depthStencilFormat) { }

}

