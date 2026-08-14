namespace UnityEngine.Rendering.Universal;

internal class DebugRendererLists
{
	private readonly DebugHandler m_DebugHandler; //Field offset: 0x10
	private readonly FilteringSettings m_FilteringSettings; //Field offset: 0x18
	private List<DebugRenderSetup> m_DebugRenderSetups; //Field offset: 0x38
	private List<RendererList> m_ActiveDebugRendererList; //Field offset: 0x40
	private List<RendererListHandle> m_ActiveDebugRendererListHdl; //Field offset: 0x48

	public DebugRendererLists(DebugHandler debugHandler, FilteringSettings filteringSettings) { }

	private void CreateDebugRenderSetups(FilteringSettings filteringSettings) { }

	internal void CreateRendererListsWithDebugRenderState(ScriptableRenderContext context, ref CullingResults cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref RenderStateBlock renderStateBlock) { }

	internal void CreateRendererListsWithDebugRenderState(RenderGraph renderGraph, ref CullingResults cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref RenderStateBlock renderStateBlock) { }

	private void DisposeDebugRenderLists() { }

	internal void DrawWithRendererList(RasterCommandBuffer cmd) { }

	internal void PrepareRendererListForRasterPass(IRasterRenderGraphBuilder builder) { }

}

