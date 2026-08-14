namespace UnityEngine.Rendering.Universal;

internal class DecalScreenSpaceRenderPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__12_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <RecordRenderGraph>b__12_0(PassData data, RasterGraphContext rgContext) { }

	}

	private class PassData
	{
		internal DecalDrawScreenSpaceSystem drawSystem; //Field offset: 0x10
		internal DecalScreenSpaceSettings settings; //Field offset: 0x18
		internal bool decalLayers; //Field offset: 0x20
		internal bool isGLDevice; //Field offset: 0x21
		internal TextureHandle colorTarget; //Field offset: 0x24
		internal UniversalCameraData cameraData; //Field offset: 0x38
		internal RendererListHandle rendererList; //Field offset: 0x40

		public PassData() { }

	}

	private FilteringSettings m_FilteringSettings; //Field offset: 0xB8
	private List<ShaderTagId> m_ShaderTagIdList; //Field offset: 0xD8
	private DecalDrawScreenSpaceSystem m_DrawSystem; //Field offset: 0xE0
	private DecalScreenSpaceSettings m_Settings; //Field offset: 0xE8
	private bool m_DecalLayers; //Field offset: 0xF0
	private PassData m_PassData; //Field offset: 0xF8

	public DecalScreenSpaceRenderPass(DecalScreenSpaceSettings settings, DecalDrawScreenSpaceSystem drawSystem, bool decalLayers) { }

	private RendererListParams CreateRenderListParams(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList) { }

	private void InitPassData(UniversalCameraData cameraData, ref PassData passData) { }

	public virtual void OnCameraCleanup(CommandBuffer cmd) { }

	public virtual void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData) { }

}

