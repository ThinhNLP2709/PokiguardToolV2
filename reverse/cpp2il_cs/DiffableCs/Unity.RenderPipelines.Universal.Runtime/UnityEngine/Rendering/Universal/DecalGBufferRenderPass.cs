namespace UnityEngine.Rendering.Universal;

internal class DecalGBufferRenderPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__15_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <RecordRenderGraph>b__15_0(PassData data, RasterGraphContext rgContext) { }

	}

	private class PassData
	{
		internal DecalDrawGBufferSystem drawSystem; //Field offset: 0x10
		internal DecalScreenSpaceSettings settings; //Field offset: 0x18
		internal bool decalLayers; //Field offset: 0x20
		internal UniversalCameraData cameraData; //Field offset: 0x28
		internal RendererListHandle rendererList; //Field offset: 0x30

		public PassData() { }

	}

	private FilteringSettings m_FilteringSettings; //Field offset: 0xB8
	private List<ShaderTagId> m_ShaderTagIdList; //Field offset: 0xD8
	private DecalDrawGBufferSystem m_DrawSystem; //Field offset: 0xE0
	private DecalScreenSpaceSettings m_Settings; //Field offset: 0xE8
	private DeferredLights m_DeferredLights; //Field offset: 0xF0
	private RTHandle[] m_GbufferAttachments; //Field offset: 0xF8
	private bool m_DecalLayers; //Field offset: 0x100
	private PassData m_PassData; //Field offset: 0x108

	public DecalGBufferRenderPass(DecalScreenSpaceSettings settings, DecalDrawGBufferSystem drawSystem, bool decalLayers) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList) { }

	private void InitPassData(UniversalCameraData cameraData, ref PassData passData) { }

	public virtual void OnCameraCleanup(CommandBuffer cmd) { }

	public virtual void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData) { }

	internal void Setup(DeferredLights deferredLights) { }

}

