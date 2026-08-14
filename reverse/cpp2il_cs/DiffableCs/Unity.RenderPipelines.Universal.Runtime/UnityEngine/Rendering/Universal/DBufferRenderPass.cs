namespace UnityEngine.Rendering.Universal;

internal class DBufferRenderPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__36_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <RecordRenderGraph>b__36_0(PassData data, RasterGraphContext rgContext) { }

	}

	private class PassData
	{
		internal DecalDrawDBufferSystem drawSystem; //Field offset: 0x10
		internal DBufferSettings settings; //Field offset: 0x18
		internal Material dBufferClear; //Field offset: 0x20
		internal ProfilingSampler dBufferClearSampler; //Field offset: 0x28
		internal bool decalLayers; //Field offset: 0x30
		internal RTHandle dBufferDepth; //Field offset: 0x38
		internal RTHandle[] dBufferColorHandles; //Field offset: 0x40
		internal RendererListHandle rendererList; //Field offset: 0x48

		public PassData() { }

	}

	internal static String[] s_DBufferNames; //Field offset: 0x0
	internal static string s_DBufferDepthName; //Field offset: 0x8
	private static readonly int s_SSAOTextureID; //Field offset: 0x10
	private DecalDrawDBufferSystem m_DrawSystem; //Field offset: 0xB8
	private DBufferSettings m_Settings; //Field offset: 0xC0
	private Material m_DBufferClear; //Field offset: 0xC8
	private FilteringSettings m_FilteringSettings; //Field offset: 0xD0
	private List<ShaderTagId> m_ShaderTagIdList; //Field offset: 0xF0
	private ProfilingSampler m_DBufferClearSampler; //Field offset: 0xF8
	private bool m_DecalLayers; //Field offset: 0x100
	private RTHandle m_DBufferDepth; //Field offset: 0x108
	private PassData m_PassData; //Field offset: 0x110
	[CompilerGenerated]
	private RTHandle[] <dBufferColorHandles>k__BackingField; //Field offset: 0x118
	[CompilerGenerated]
	private RTHandle <depthHandle>k__BackingField; //Field offset: 0x120
	private TextureHandle[] dbufferHandles; //Field offset: 0x128

	internal RTHandle[] dBufferColorHandles
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	internal RTHandle dBufferDepth
	{
		internal get { } //Length: 8
	}

	internal RTHandle depthHandle
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 19
	}

	private static DBufferRenderPass() { }

	public DBufferRenderPass(Material dBufferClear, DBufferSettings settings, DecalDrawDBufferSystem drawSystem, bool decalLayers) { }

	private static void Clear(CommandBuffer cmd, PassData passData) { }

	public void Dispose() { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	private static void ExecutePass(RasterCommandBuffer cmd, PassData passData, RendererList rendererList, bool renderGraph) { }

	[CompilerGenerated]
	internal RTHandle[] get_dBufferColorHandles() { }

	internal RTHandle get_dBufferDepth() { }

	[CompilerGenerated]
	internal RTHandle get_depthHandle() { }

	private void InitPassData(ref PassData passData) { }

	private RendererListParams InitRendererListParams(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData) { }

	public virtual void OnCameraCleanup(CommandBuffer cmd) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) { }

	public virtual void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData) { }

	[CompilerGenerated]
	private void set_dBufferColorHandles(RTHandle[] value) { }

	[CompilerGenerated]
	private void set_depthHandle(RTHandle value) { }

	private static void SetGlobalTextures(CommandBuffer cmd, PassData passData) { }

	private static void SetKeywords(RasterCommandBuffer cmd, PassData passData) { }

	public void Setup(in CameraData cameraData) { }

	public void Setup(in CameraData cameraData, RTHandle depthTextureHandle) { }

}

