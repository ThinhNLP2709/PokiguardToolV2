namespace UnityEngine.Rendering.Universal.Internal;

internal class DrawObjectsWithRenderingLayersPass : DrawObjectsPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<RenderingLayersPassData, RasterGraphContext> <>9__7_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__7_0(RenderingLayersPassData data, RasterGraphContext context) { }

	}

	private class RenderingLayersPassData
	{
		internal PassData basePassData; //Field offset: 0x10
		internal MaskSize maskSize; //Field offset: 0x18

		public RenderingLayersPassData() { }

	}

	private RTHandle[] m_ColorTargetIndentifiers; //Field offset: 0x160
	private RTHandle m_DepthTargetIndentifiers; //Field offset: 0x168

	public DrawObjectsWithRenderingLayersPass(URPProfileId profilerTag, bool opaque, RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask, StencilState stencilState, int stencilReference) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	internal void Render(RenderGraph renderGraph, ContextContainer frameData, TextureHandle colorTarget, TextureHandle renderingLayersTexture, TextureHandle depthTarget, TextureHandle mainShadowsTexture, TextureHandle additionalShadowsTexture, MaskSize maskSize, uint batchLayerMask = 4294967295) { }

	public void Setup(RTHandle colorAttachment, RTHandle renderingLayersTexture, RTHandle depthAttachment) { }

}

