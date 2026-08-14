namespace UnityEngine.Rendering.Universal;

internal class DecalPreviewPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__8_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <RecordRenderGraph>b__8_0(PassData data, RasterGraphContext rgContext) { }

	}

	private class PassData
	{
		internal RendererListHandle rendererList; //Field offset: 0x10

		public PassData() { }

	}

	private FilteringSettings m_FilteringSettings; //Field offset: 0xB8
	private List<ShaderTagId> m_ShaderTagIdList; //Field offset: 0xD8
	private ProfilingSampler m_ProfilingSampler; //Field offset: 0xE0
	private PassData m_PassData; //Field offset: 0xE8

	public DecalPreviewPass() { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList) { }

	public virtual void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData) { }

}

