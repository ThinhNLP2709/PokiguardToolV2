namespace UnityEngine.Rendering.Universal;

internal class DecalForwardEmissivePass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__10_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <RecordRenderGraph>b__10_0(PassData data, RasterGraphContext rgContext) { }

	}

	private class PassData
	{
		internal DecalDrawFowardEmissiveSystem drawSystem; //Field offset: 0x10
		internal RendererListHandle rendererList; //Field offset: 0x18

		public PassData() { }

	}

	private FilteringSettings m_FilteringSettings; //Field offset: 0xB8
	private List<ShaderTagId> m_ShaderTagIdList; //Field offset: 0xD8
	private DecalDrawFowardEmissiveSystem m_DrawSystem; //Field offset: 0xE0
	private PassData m_PassData; //Field offset: 0xE8

	public DecalForwardEmissivePass(DecalDrawFowardEmissiveSystem drawSystem) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList) { }

	private void InitPassData(ref PassData passData) { }

	private RendererListParams InitRendererListParams(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData) { }

	public virtual void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData) { }

}

