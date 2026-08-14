namespace UnityEngine.Rendering.Universal;

internal class DebugRenderSetup : IDisposable
{
	private readonly DebugHandler m_DebugHandler; //Field offset: 0x10
	private readonly FilteringSettings m_FilteringSettings; //Field offset: 0x18
	private readonly int m_Index; //Field offset: 0x38

	private DebugDisplaySettingsLighting LightingSettings
	{
		private get { } //Length: 39
	}

	private DebugDisplaySettingsMaterial MaterialSettings
	{
		private get { } //Length: 39
	}

	private DebugDisplaySettingsRendering RenderingSettings
	{
		private get { } //Length: 39
	}

	internal DebugRenderSetup(DebugHandler debugHandler, int index, FilteringSettings filteringSettings) { }

	internal void Begin(RasterCommandBuffer cmd) { }

	internal DrawingSettings CreateDrawingSettings(DrawingSettings drawingSettings) { }

	internal void CreateRendererList(ScriptableRenderContext context, ref CullingResults cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref RenderStateBlock renderStateBlock, ref RendererList rendererList) { }

	internal void CreateRendererList(RenderGraph renderGraph, ref CullingResults cullResults, ref DrawingSettings drawingSettings, ref FilteringSettings filteringSettings, ref RenderStateBlock renderStateBlock, ref RendererListHandle rendererListHdl) { }

	public override void Dispose() { }

	internal void DrawWithRendererList(RasterCommandBuffer cmd, ref RendererList rendererList) { }

	internal void End(RasterCommandBuffer cmd) { }

	private DebugDisplaySettingsLighting get_LightingSettings() { }

	private DebugDisplaySettingsMaterial get_MaterialSettings() { }

	private DebugDisplaySettingsRendering get_RenderingSettings() { }

	internal int GetIndex() { }

	internal RenderStateBlock GetRenderStateBlock(RenderStateBlock renderStateBlock) { }

}

