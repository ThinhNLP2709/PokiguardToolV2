namespace UnityEngine.Rendering.Universal;

public class DrawSkyboxPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__7_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__7_0(PassData data, RasterGraphContext context) { }

	}

	private class PassData
	{
		internal XRPass xr; //Field offset: 0x10
		internal RendererListHandle skyRendererListHandle; //Field offset: 0x18
		internal Material material; //Field offset: 0x28

		public PassData() { }

	}


	public DrawSkyboxPass(RenderPassEvent evt) { }

	private RendererList CreateSkyboxRendererList(ScriptableRenderContext context, UniversalCameraData cameraData) { }

	private RendererListHandle CreateSkyBoxRendererList(RenderGraph renderGraph, UniversalCameraData cameraData) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, XRPass xr, RendererList rendererList) { }

	private void InitPassData(ref PassData passData, in XRPass xr, in RendererListHandle handle) { }

	internal void Render(RenderGraph renderGraph, ContextContainer frameData, ScriptableRenderContext context, TextureHandle colorTarget, TextureHandle depthTarget, Material skyboxMaterial) { }

}

