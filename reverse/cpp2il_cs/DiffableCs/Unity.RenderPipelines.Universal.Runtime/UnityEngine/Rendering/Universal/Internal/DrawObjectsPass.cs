namespace UnityEngine.Rendering.Universal.Internal;

public class DrawObjectsPass : ScriptableRenderPass
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static BaseRenderFunc<PassData, RasterGraphContext> <>9__17_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Render>b__17_0(PassData data, RasterGraphContext context) { }

	}

	public class PassData
	{
		internal TextureHandle albedoHdl; //Field offset: 0x10
		internal TextureHandle depthHdl; //Field offset: 0x20
		internal UniversalCameraData cameraData; //Field offset: 0x30
		internal bool isOpaque; //Field offset: 0x38
		internal bool shouldTransparentsReceiveShadows; //Field offset: 0x39
		internal uint batchLayerMask; //Field offset: 0x3C
		internal bool isActiveTargetBackBuffer; //Field offset: 0x40
		internal RendererListHandle rendererListHdl; //Field offset: 0x44
		internal RendererListHandle objectsWithErrorRendererListHdl; //Field offset: 0x50
		internal DebugRendererLists debugRendererLists; //Field offset: 0x60
		internal RendererList rendererList; //Field offset: 0x68
		internal RendererList objectsWithErrorRendererList; //Field offset: 0x80

		public PassData() { }

	}

	private static readonly int s_DrawObjectPassDataPropID; //Field offset: 0x0
	private FilteringSettings m_FilteringSettings; //Field offset: 0xB8
	private RenderStateBlock m_RenderStateBlock; //Field offset: 0xD8
	private List<ShaderTagId> m_ShaderTagIdList; //Field offset: 0x148
	private bool m_IsOpaque; //Field offset: 0x150
	public bool m_IsActiveTargetBackBuffer; //Field offset: 0x151
	public bool m_ShouldTransparentsReceiveShadows; //Field offset: 0x152
	private PassData m_PassData; //Field offset: 0x158

	private static DrawObjectsPass() { }

	public DrawObjectsPass(string profilerTag, ShaderTagId[] shaderTagIds, bool opaque, RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask, StencilState stencilState, int stencilReference) { }

	public DrawObjectsPass(string profilerTag, bool opaque, RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask, StencilState stencilState, int stencilReference) { }

	internal DrawObjectsPass(URPProfileId profileId, bool opaque, RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask, StencilState stencilState, int stencilReference) { }

	[Obsolete("This rendering path is for compatibility mode only (when Render Graph is disabled). Use Render Graph API instead.", False)]
	public virtual void Execute(ScriptableRenderContext context, ref RenderingData renderingData) { }

	internal static void ExecutePass(RasterCommandBuffer cmd, PassData data, RendererList rendererList, RendererList objectsWithErrorRendererList, bool yFlip) { }

	internal void Init(bool opaque, RenderPassEvent evt, RenderQueueRange renderQueueRange, LayerMask layerMask, StencilState stencilState, int stencilReference, ShaderTagId[] shaderTagIds = null) { }

	internal void InitPassData(UniversalCameraData cameraData, ref PassData passData, uint batchLayerMask, bool isActiveTargetBackBuffer = false) { }

	internal void InitRendererLists(UniversalRenderingData renderingData, UniversalCameraData cameraData, UniversalLightData lightData, ref PassData passData, ScriptableRenderContext context, RenderGraph renderGraph, bool useRenderGraph) { }

	internal void Render(RenderGraph renderGraph, ContextContainer frameData, TextureHandle colorTarget, TextureHandle depthTarget, TextureHandle mainShadowsTexture, TextureHandle additionalShadowsTexture, uint batchLayerMask = 4294967295) { }

}

