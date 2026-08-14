namespace UnityEngine.Rendering.Universal;

internal class ProbeVolumeDebugPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<WriteApvData, ComputeGraphContext> <>9__7_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__7_0(WriteApvData data, ComputeGraphContext ctx) { }

	}

	private class WriteApvData
	{
		public ComputeShader computeShader; //Field offset: 0x10
		public BufferHandle resultBuffer; //Field offset: 0x18
		public Vector2 clickCoordinates; //Field offset: 0x24
		public TextureHandle depthBuffer; //Field offset: 0x2C
		public TextureHandle normalBuffer; //Field offset: 0x3C

		public WriteApvData() { }

	}

	private ComputeShader m_ComputeShader; //Field offset: 0xB8
	private RTHandle m_DepthTexture; //Field offset: 0xC0
	private RTHandle m_NormalTexture; //Field offset: 0xC8

	public ProbeVolumeDebugPass(RenderPassEvent evt, ComputeShader computeShader) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	internal void Render(RenderGraph renderGraph, ContextContainer frameData, TextureHandle depthPyramidBuffer, TextureHandle normalBuffer) { }

	public void Setup(RTHandle depthBuffer, RTHandle normalBuffer) { }

}

